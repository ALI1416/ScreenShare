using ScreenShare.Properties;
using ScreenShare.Model;
using ScreenShare.Util;
using ScreenShare.ScheduledTask;
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Reflection;
using System.Collections.Specialized;
using ScreenShare.Service;

namespace ScreenShare
{

    /// <summary>
    /// 主界面
    /// </summary>
    public partial class ScreenShare : Form
    {

        #region 公共方法

        /// <summary>
        /// 主程序
        /// </summary>
        public ScreenShare()
        {
            InitializeComponent();
            Init();
            // 图标
            MemoryStream stream = new MemoryStream();
            Resources.favicon.Save(stream);
            httpIconHeaderBytes = HttpService.GetBytes(HttpService.icoHeaderBytes, stream);
            // FPS
            fpsLabel.Parent = previewImg;
            // 日志
            Version version = Assembly.GetExecutingAssembly().GetName().Version;
            Log("欢迎使用屏幕共享软件！");
            Log("当前版本 " + version.Major + "." + version.Minor + "." + version.Build);
            Log("帮助与反馈 https://github.com/ALI1416/ScreenShare");
            Log("初始化完成！");
        }

        /// <summary>
        /// 启动
        /// </summary>
        public void Start()
        {
            // 启动http服务
            if (StatusManager.HttpService == null)
            {
                StatusManager.HttpService = new HttpService();
            }
            if (!StatusManager.HttpService.Start(StatusManager.IpList.ElementAt(ipAddressComboBox.SelectedIndex).Item2, (int)ipPortNud.Value, HttpResponseCallback))
            {
                Log("http服务启动失败！请尝试更改IP地址或端口号。");
                MessageBox.Show("http服务启动失败！请尝试更改IP地址或端口号。", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // 启动webSocket服务
            if (StatusManager.WebSocketService == null)
            {
                StatusManager.WebSocketService = new WebSocketService();
            }
            if (!StatusManager.WebSocketService.Start(StatusManager.IpList.ElementAt(ipAddressComboBox.SelectedIndex).Item2, 0, WebSocketClientCallback))
            {
                StatusManager.HttpService.Close();
                Log("webSocket服务启动失败！请尝试重启程序或联系开发者。");
                MessageBox.Show("webSocket服务启动失败！请尝试重启程序或联系开发者。", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            StatusManager.IsStarted = true;
            // 开启屏幕捕获任务
            CaptureScreenTask();
            // 设置UI状态为启用
            SetUiStatus(true);
            // 不显示预览图
            previewImg.Image.Dispose();
            previewImg.Image = null;
            Log("屏幕共享已开启。");
        }

        /// <summary>
        /// 终止
        /// </summary>
        public void Stop()
        {
            StatusManager.IsStarted = false;
            // 设置UI状态为停用
            SetUiStatus(false);
            // 关闭http服务
            StatusManager.HttpService.Close();
            // 关闭webSocket服务
            StatusManager.WebSocketService.Close();
            // 手动gc
            GC.Collect();
            Log("屏幕共享已停止。");
        }

        /// <summary>
        /// 自动刷新
        /// </summary>
        public void AutoRefresh()
        {
            if (Visible)
            {
                ScheduledTasks.FpsAutoRefresh(this, fpsLabel, (FormManager.Preview != null && FormManager.Preview.Visible) || (StatusManager.WebSocketService != null && StatusManager.WebSocketService.ClientOnlineCount() != 0));
            }
        }

        /// <summary>
        /// 获取分享地址
        /// </summary>
        /// <returns>分享地址</returns>
        public string ShareLinkText()
        {
            return shareLinkText.Text;
        }

        #endregion

        #region http服务处理

        /// <summary>
        /// 图标byte[]
        /// </summary>
        private static byte[] httpIconHeaderBytes;

        /// <summary>
        /// http响应回调函数
        /// </summary>
        /// <param name="path">路径</param>
        /// <param name="param">参数</param>
        /// <returns>返回值</returns>
        private byte[] HttpResponseCallback(string path, NameValueCollection param)
        {
            byte[] data;
            switch (path)
            {
                // 网页
                default:
                    {
                        data = Encoding.UTF8.GetBytes(HttpService.htmlHeader + Resources.index);
                        break;
                    }
                // 图标
                case "/favicon.ico":
                    {
                        data = httpIconHeaderBytes;
                        break;
                    }
                // API:获取视频信息
                case "/api/getVideoInfo":
                    {
                        string apiGetVideoInfo = "{\"width\":" + videoWNud.Value + ",\"height\":" + videoHNud.Value + ",\"frame\":" + videoFrameNud.Value + ",\"port\":";
                        // 开启加密
                        if (isEncryptionCb.Checked)
                        {
                            // 密码未输入或密码错误
                            if (param == null || (param["code"] != pwdText.Text))
                            {
                                apiGetVideoInfo += "0}";
                            }
                            // 密码正确
                            else
                            {
                                apiGetVideoInfo += StatusManager.WebSocketService.ServerPort() + "}";
                            }
                        }
                        // 未开启加密
                        else
                        {
                            apiGetVideoInfo += StatusManager.WebSocketService.ServerPort() + "}";
                        }
                        data = Encoding.UTF8.GetBytes(HttpService.jsonHeader + apiGetVideoInfo);
                        break;
                    }
            }
            return data;
        }

        #endregion

        #region webSocket服务处理

        /// <summary>
        /// webSocket客户端上下线回调函数
        /// </summary>
        /// <param name="client">客户端</param>
        /// <param name="online">上线或下线</param>
        private void WebSocketClientCallback(WebSocketClient client, bool online)
        {
            /* 更新在线数量 */
            string count = "当前在线用户数量：" + StatusManager.WebSocketService.ClientOnlineCount();
            // 利用委托，防止`线程间操作无效`
            Action<string> action = (data) =>
            {
                userCountLinkLabel.Text = data;
            };
            Invoke(action, count);
            /* 日志 */
            string log = "客户端 " + client.Ip + (online ? " 已上线。" : " 已下线。");
            Action<string> action2 = (data) =>
            {
                Log(data);
            };
            Invoke(action2, log);
        }

        #endregion

        #region 屏幕捕获

        /// <summary>
        /// 屏幕捕获任务
        /// </summary>
        private async void CaptureScreenTask()
        {
            // 获取参数
            int delay = videoFrameNud.Value == 0 ? 1 : (int)(1000 / videoFrameNud.Value);
            int videoQuality = (int)videoQualityNud.Value;
            bool isDisplayCursor = isDisplayCursorCb.Checked;
            Rectangle screen = new Rectangle((int)screenXNud.Value, (int)screenYNud.Value, (int)screenWNud.Value, (int)screenHNud.Value);
            Size video = new Size((int)videoWNud.Value, (int)videoHNud.Value);
            // 初始化
            Bitmap bitmap = ImageUtils.CaptureScreenArea(screen, isDisplayCursor);
            MemoryStream stream = new MemoryStream();
            stream.SetLength(0);
            ImageUtils.Save(bitmap, stream);
            UpdatePreviewImgWhileWorking(bitmap);
            // 普通
            if (screen.Size == video && videoQuality == 100)
            {
                // 开启共享
                while (StatusManager.IsStarted)
                {
                    // 获取`在线`并且`可发送数据`的用户列表
                    var list = StatusManager.WebSocketService.ClientOnlineAndNotTransmission();
                    // 符合条件的用户 或 正在预览
                    if (list.Count != 0 || (FormManager.Preview != null && FormManager.Preview.Visible))
                    {
                        try
                        {
                            // 捕获屏幕
                            bitmap = ImageUtils.CaptureScreenArea(screen, isDisplayCursor);
                            // 保存到内存流
                            stream.SetLength(0);
                            ImageUtils.Save(bitmap, stream);
                            if (list.Count != 0)
                            {
                                var data = stream.ToArray();
                                // 记录webSocket服务端访问记录
                                StatusManager.WebSocketService.Server.RecordAccess(list.Count * data.Length);
                                // 发送给webSocket客户端
                                StatusManager.WebSocketService.SendDataByClientList(list, data);
                            }
                            else
                            {
                                StatusManager.WebSocketService.Server.RecordAccess(0);
                            }
                            // 运行时更新预览图
                            UpdatePreviewImgWhileWorking(bitmap);
                        }
                        catch
                        {
                            // 捕获屏幕异常处理(bitmap已被释放掉)
                            CaptureScreenExceptionHandle(new Bitmap(stream));
                        }
                    }
                    // 延时
                    await Task.Delay(delay);
                }
                // 结束共享时更新预览图(bitmap已被释放掉)
                UpdatePreviewImg(new Bitmap(stream));
            }
            // 缩放
            else if (screen.Size != video && videoQualityNud.Value == 100)
            {
                while (StatusManager.IsStarted)
                {
                    var list = StatusManager.WebSocketService.ClientOnlineAndNotTransmission();
                    if (list.Count != 0 || (FormManager.Preview != null && FormManager.Preview.Visible))
                    {
                        try
                        {
                            bitmap = ImageUtils.ZoomImage(ImageUtils.CaptureScreenArea(screen, isDisplayCursor), video, true);
                            stream.SetLength(0);
                            ImageUtils.Save(bitmap, stream);
                            if (list.Count != 0)
                            {
                                var data = stream.ToArray();
                                StatusManager.WebSocketService.Server.RecordAccess(list.Count * data.Length);
                                StatusManager.WebSocketService.SendDataByClientList(list, data);
                            }
                            else
                            {
                                StatusManager.WebSocketService.Server.RecordAccess(0);
                            }
                            UpdatePreviewImgWhileWorking(bitmap);
                        }
                        catch
                        {
                            CaptureScreenExceptionHandle(new Bitmap(stream));
                        }
                    }
                    await Task.Delay(delay);
                }
                UpdatePreviewImg(new Bitmap(stream));
            }
            // 压缩
            else if (screen.Size == video && videoQuality != 100)
            {
                while (StatusManager.IsStarted)
                {
                    var list = StatusManager.WebSocketService.ClientOnlineAndNotTransmission();
                    if (list.Count != 0 || (FormManager.Preview != null && FormManager.Preview.Visible))
                    {
                        try
                        {
                            bitmap = ImageUtils.CaptureScreenArea(screen, isDisplayCursor);
                            stream.SetLength(0);
                            ImageUtils.QualitySave(bitmap, videoQuality, stream);
                            if (list.Count != 0)
                            {
                                var data = stream.ToArray();
                                StatusManager.WebSocketService.Server.RecordAccess(list.Count * data.Length);
                                StatusManager.WebSocketService.SendDataByClientList(list, data);
                            }
                            else
                            {
                                StatusManager.WebSocketService.Server.RecordAccess(0);
                            }
                            UpdatePreviewImgWhileWorking(bitmap);
                        }
                        catch
                        {
                            CaptureScreenExceptionHandle(new Bitmap(stream));
                        }
                    }
                    await Task.Delay(delay);
                }
                UpdatePreviewImg(new Bitmap(stream));
            }
            // 缩放+压缩
            else
            {
                while (StatusManager.IsStarted)
                {
                    var list = StatusManager.WebSocketService.ClientOnlineAndNotTransmission();
                    if (list.Count != 0 || (FormManager.Preview != null && FormManager.Preview.Visible))
                    {
                        try
                        {
                            bitmap = ImageUtils.ZoomImage(ImageUtils.CaptureScreenArea(screen, isDisplayCursor), video, true);
                            stream.SetLength(0);
                            ImageUtils.QualitySave(bitmap, videoQuality, stream);
                            if (list.Count != 0)
                            {
                                var data = stream.ToArray();
                                StatusManager.WebSocketService.Server.RecordAccess(list.Count * data.Length);
                                StatusManager.WebSocketService.SendDataByClientList(list, data);
                            }
                            else
                            {
                                StatusManager.WebSocketService.Server.RecordAccess(0);
                            }
                            UpdatePreviewImgWhileWorking(bitmap);
                        }
                        catch
                        {
                            CaptureScreenExceptionHandle(new Bitmap(stream));
                        }
                    }
                    await Task.Delay(delay);
                }
                UpdatePreviewImg(new Bitmap(stream));
            }
        }

        /// <summary>
        /// 捕获屏幕异常处理
        /// <param name="bitmap">Bitmap</param>
        /// </summary>
        private void CaptureScreenExceptionHandle(Bitmap bitmap)
        {
            Log("异常终止屏幕共享！可能是锁定了账户。");
            Stop();
            if (!Visible)
            {
                // 取消托盘
                NotifyIcon_Click(null, null);
            }
            // 更新预览图
            UpdatePreviewImg(bitmap);
        }

        #endregion

        #region 界面事件

        /// <summary>
        /// 初始化
        /// </summary>
        private void Init()
        {
            StatusManager.IsStarted = false;
            /* 头部 */
            // IP地址
            StatusManager.IpList = Utils.GetAllIPv4Address();
            ipAddressComboBox.Items.Clear();
            foreach (var ip in StatusManager.IpList)
            {
                ipAddressComboBox.Items.Add(ip.Item2 + " - " + ip.Item1);
            }
            ipAddressComboBox.SelectedIndex = 0;
            // 端口号
            ipPortNud.Value = 7070;
            // 分享地址
            shareLinkText.Text = "http://" + StatusManager.IpList.ElementAt(ipAddressComboBox.SelectedIndex).Item2 + ":" + ipPortNud.Value + "/";

            /* 加密传输 */
            // 开启加密
            isEncryptionCb.Checked = false;
            // 密码
            pwdText.Text = "";

            /* 选取位置 */
            // 全屏
            isFullScreenCb.Checked = true;
            // 显示器
            StatusManager.ScreenList = Utils.GetAllScreen();
            screenComboBox.Items.Clear();
            foreach (var screen in StatusManager.ScreenList)
            {
                screenComboBox.Items.Add(screen.Item1 + "[" + screen.Item2.Width + "x" + screen.Item2.Height + "]");
            }
            if (StatusManager.ScreenList.Count == 1)
            {
                screenComboBox.SelectedIndex = 0;
            }
            else
            {
                screenComboBox.SelectedIndex = 1;
            }
            Rectangle selectedScreen = StatusManager.ScreenList.ElementAt(screenComboBox.SelectedIndex).Item2;
            // X
            screenXNud.Minimum = selectedScreen.Left;
            screenXNud.Maximum = selectedScreen.Right - 2;
            screenXNud.Value = selectedScreen.X;
            // Y
            screenYNud.Minimum = selectedScreen.Top;
            screenYNud.Maximum = selectedScreen.Bottom - 2;
            screenYNud.Value = selectedScreen.Y;
            // 宽
            screenWNud.Maximum = selectedScreen.Width;
            screenWNud.Value = selectedScreen.Width;
            // 高
            screenHNud.Maximum = selectedScreen.Height;
            screenHNud.Value = selectedScreen.Height;

            /* 视频尺寸 */
            // 锁定缩放比
            isLockAspectRatioCb.Checked = true;
            // 缩放比例
            scalingNud.Value = 100;
            // 宽
            videoWNud.Value = selectedScreen.Width;
            // 高
            screenHNud.Value = selectedScreen.Height;

            /* 视频设置 */
            // 显示光标
            isDisplayCursorCb.Checked = true;
            // 每秒帧数
            videoFrameNud.Value = 5;
            // 视频质量
            videoQualityNud.Value = 100;

            /* 预览图像 */
            UpdatePreviewImgWithCaptureScreen();
        }

        /// <summary>
        /// 运行时更新预览图
        /// </summary>
        /// <param name="bitmap">Bitmap</param>
        private void UpdatePreviewImgWhileWorking(Bitmap bitmap)
        {
            if (FormManager.Preview != null && FormManager.Preview.Visible)
            {
                FormManager.Preview.UpdateImg(bitmap);
            }
            else
            {
                bitmap.Dispose();
            }
        }

        /// <summary>
        /// 更新预览图
        /// </summary>
        /// <param name="bitmap">Bitmap</param>
        private void UpdatePreviewImg(Bitmap bitmap)
        {
            if (previewImg.Image != null)
            {
                previewImg.Image.Dispose();
                previewImg.Image = null;
            }
            previewImg.Image = bitmap;
        }

        /// <summary>
        /// 通过捕获屏幕更新预览图
        /// </summary>
        private void UpdatePreviewImgWithCaptureScreen()
        {
            if (previewImg.Image != null)
            {
                previewImg.Image.Dispose();
                previewImg.Image = null;
            }
            previewImg.Image = ImageUtils.CaptureScreenArea(new Rectangle((int)screenXNud.Value, (int)screenYNud.Value, (int)screenWNud.Value, (int)screenHNud.Value), isDisplayCursorCb.Checked);
        }

        /// <summary>
        /// 设置UI状态
        /// </summary>
        /// <param name="enable">启用或停用屏幕共享</param>
        private void SetUiStatus(bool enable)
        {
            previewLabel.Visible
               = enable;
            ipAddressComboBox.Enabled
                = ipPortNud.Enabled
                = isEncryptionCb.Enabled
                = isFullScreenCb.Enabled
                = screenComboBox.Enabled
                = isLockAspectRatioCb.Enabled
                = isDisplayCursorCb.Enabled
                = videoFrameNud.Enabled
                = videoQualityNud.Enabled
                = reloadConfigBtn.Enabled
                = configBtn.Enabled
                = captureScreenCoordinatesBtn.Enabled
                = !enable;
            if (enable)
            {
                startSharingScreenBtn.Text = "停止共享";
                pwdText.Enabled
                    = screenXNud.Enabled
                    = screenYNud.Enabled
                    = screenWNud.Enabled
                    = screenHNud.Enabled
                    = scalingNud.Enabled
                    = videoWNud.Enabled
                    = videoHNud.Enabled
                    = !enable;
            }
            else
            {
                startSharingScreenBtn.Text = "开始共享";
                if (isEncryptionCb.Checked)
                {
                    pwdText.Enabled
                        = !enable;
                }
                if (!isFullScreenCb.Checked)
                {
                    screenXNud.Enabled
                        = screenYNud.Enabled
                        = screenWNud.Enabled
                        = screenHNud.Enabled
                        = !enable;
                }
                if (isLockAspectRatioCb.Checked)
                {
                    scalingNud.Enabled
                        = !enable;
                }
                else
                {
                    videoWNud.Enabled
                        = videoHNud.Enabled
                        = !enable;
                }
            }
        }

        /// <summary>
        /// 写日志
        /// </summary>
        /// <param name="text">内容</param>
        private void Log(string text)
        {
            logText.Text += DateTime.Now.ToString("HH:mm:ss ") + text + "\r\n";
            logText.SelectionStart = logText.Text.Length;
            logText.ScrollToCaret();
        }

        #endregion

        #region 界面触发事件

        /// <summary>
        /// 点击开始共享按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StartSharingScreenBtn_Click(object sender, EventArgs e)
        {
            if (StatusManager.IsStarted)
            {
                Stop();
            }
            else
            {
                Start();
            }
        }

        /// <summary>
        /// IP地址改变
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void IpAddressComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            shareLinkText.Text = "http://" + StatusManager.IpList.ElementAt(ipAddressComboBox.SelectedIndex).Item2 + ":" + ipPortNud.Value + "/";
        }

        /// <summary>
        /// IP端口号改变
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void IpPortNud_ValueChanged(object sender, EventArgs e)
        {
            shareLinkText.Text = "http://" + StatusManager.IpList.ElementAt(ipAddressComboBox.SelectedIndex).Item2 + ":" + ipPortNud.Value + "/";
        }

        /// <summary>
        /// 点击复制按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CopyBtn_Click(object sender, EventArgs e)
        {
            shareLinkText.Focus();
            shareLinkText.SelectAll();
            try
            {
                Clipboard.SetText(shareLinkText.Text);
                Log("分享地址已复制。");
            }
            catch
            {
                Log("复制失败！请手动复制。");
                MessageBox.Show("复制失败！请手动复制。", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 点击重新加载配置按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ReloadConfigBtn_Click(object sender, EventArgs e)
        {
            Init();
        }

        /// <summary>
        /// 点击用浏览器打开按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OpenBtn_Click(object sender, EventArgs e)
        {
            Process.Start(shareLinkText.Text);
        }

        /// <summary>
        /// 点击系统配置按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ConfigBtn_Click(object sender, EventArgs e)
        {
            if (FormManager.Config == null)
            {
                FormManager.Config = new Config();
            }
            FormManager.Config.ShowDialog();
        }

        /// <summary>
        /// 点击网站二维码按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void QrBtn_Click(object sender, EventArgs e)
        {
            if (FormManager.Qr == null)
            {
                FormManager.Qr = new Qr();
            }
            FormManager.Qr.ShowDialog();
        }

        /// <summary>
        /// 开启密码CheckBox状态改变
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void IsEncryptionCb_CheckStateChanged(object sender, EventArgs e)
        {
            pwdText.Enabled = ((CheckBox)sender).Checked;
        }

        /// <summary>
        /// 全屏CheckBox状态改变
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void IsFullScreenCb_CheckStateChanged(object sender, EventArgs e)
        {
            bool isChecked = ((CheckBox)sender).Checked;
            screenXNud.Enabled = screenYNud.Enabled = screenWNud.Enabled = screenHNud.Enabled = !isChecked;
            if (isChecked)
            {
                Rectangle selectedScreen = StatusManager.ScreenList.ElementAt(screenComboBox.SelectedIndex).Item2;
                screenXNud.Value = selectedScreen.X;
                screenYNud.Value = selectedScreen.Y;
                screenWNud.Value = selectedScreen.Width;
                screenHNud.Value = selectedScreen.Height;
            }
        }

        /// <summary>
        /// 显示器改变
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ScreenComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            Rectangle selectedScreen = StatusManager.ScreenList.ElementAt(screenComboBox.SelectedIndex).Item2;
            screenXNud.Minimum = selectedScreen.Left;
            screenXNud.Maximum = selectedScreen.Right - 1;
            screenXNud.Value = selectedScreen.X;
            screenYNud.Minimum = selectedScreen.Top;
            screenYNud.Maximum = selectedScreen.Bottom - 1;
            screenYNud.Value = selectedScreen.Y;
            screenWNud.Maximum = selectedScreen.Width;
            screenWNud.Value = selectedScreen.Width;
            screenHNud.Maximum = selectedScreen.Height;
            screenHNud.Value = selectedScreen.Height;
        }

        /// <summary>
        /// 屏幕的X发生改变
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ScreenXNud_ValueChanged(object sender, EventArgs e)
        {
            screenWNud.Maximum = StatusManager.ScreenList.ElementAt(screenComboBox.SelectedIndex).Item2.Right - screenXNud.Value;
            // TODO 屏幕的XY宽高同时发生改变可能会渲染多次预览图
            UpdatePreviewImgWithCaptureScreen();
        }

        /// <summary>
        /// 屏幕的Y发生改变
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ScreenYNud_ValueChanged(object sender, EventArgs e)
        {
            screenHNud.Maximum = StatusManager.ScreenList.ElementAt(screenComboBox.SelectedIndex).Item2.Bottom - screenYNud.Value;
            UpdatePreviewImgWithCaptureScreen();
        }

        /// <summary>
        /// 屏幕的宽发生改变
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ScreenWNud_ValueChanged(object sender, EventArgs e)
        {
            videoWNud.Value = screenWNud.Value * scalingNud.Value / 100;
            UpdatePreviewImgWithCaptureScreen();
        }

        /// <summary>
        /// 屏幕的高发生改变
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ScreenHNud_ValueChanged(object sender, EventArgs e)
        {
            videoHNud.Value = screenHNud.Value * scalingNud.Value / 100;
            UpdatePreviewImgWithCaptureScreen();
        }

        /// <summary>
        /// 点击选取屏幕坐标按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CaptureScreenCoordinatesBtn_Click(object sender, EventArgs e)
        {
            DrawScreen drawScreen = new DrawScreen(StatusManager.ScreenList.ElementAt(screenComboBox.SelectedIndex).Item2);
            if (drawScreen.ShowDialog() == DialogResult.OK)
            {
                Rectangle rect = drawScreen.rect;
                if (rect.Width != 0 && rect.Height != 0)
                {
                    isFullScreenCb.Checked = false;
                    screenXNud.Value = rect.X;
                    screenYNud.Value = rect.Y;
                    screenWNud.Value = rect.Width;
                    screenHNud.Value = rect.Height;
                }
            }
        }

        /// <summary>
        /// 锁定纵横比CheckBox状态改变
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void IsLockAspectRatioCb_CheckStateChanged(object sender, EventArgs e)
        {
            bool isChecked = ((CheckBox)sender).Checked;
            scalingNud.Enabled = isChecked;
            videoWNud.Enabled = videoHNud.Enabled = !isChecked;
            if (isChecked)
            {
                videoWNud.Value = screenWNud.Value * scalingNud.Value / 100;
                videoHNud.Value = screenHNud.Value * scalingNud.Value / 100;
            }
        }

        /// <summary>
        /// 视频的缩放比例发生改变
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ScalingNud_ValueChanged(object sender, EventArgs e)
        {
            videoWNud.Value = screenWNud.Value * scalingNud.Value / 100;
            videoHNud.Value = screenHNud.Value * scalingNud.Value / 100;
        }

        /// <summary>
        /// 点击预览图
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PreviewImg_Click(object sender, EventArgs e)
        {
            if (FormManager.Preview == null)
            {
                FormManager.Preview = new Preview();
            }
            if (!StatusManager.IsStarted)
            {
                FormManager.Preview.UpdateImg(new Bitmap(previewImg.Image));
            }
            FormManager.Preview.ShowDialog();
        }

        /// <summary>
        /// 点击预览图上的文字
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PreviewLabel_Click(object sender, EventArgs e)
        {
            PreviewImg_Click(sender, e);
        }

        /// <summary>
        /// 点击当前在线用户数量链接
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UserCountLinkLabel_Click(object sender, EventArgs e)
        {
            if (FormManager.History == null)
            {
                FormManager.History = new History();
            }
            FormManager.History.ShowDialog();
        }

        /// <summary>
        /// 点击清空日志链接
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClearLogLinkLabel_Click(object sender, EventArgs e)
        {
            logText.Text = "";
        }

        /// <summary>
        /// 点击关闭按钮前
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ScreenShare_FormClosing(object sender, FormClosingEventArgs e)
        {
            // 如果正在运行：托盘
            if (StatusManager.IsStarted)
            {
                if (previewImg.Image != null)
                {
                    // 不显示预览图
                    previewImg.Image.Dispose();
                    previewImg.Image = null;
                }
                e.Cancel = true;
                Visible = false;
                notifyIcon.Visible = true;
                Log("屏幕共享继续在后台运行！");
                notifyIcon.ShowBalloonTip(1000, "屏幕共享", "屏幕共享继续在后台运行！", ToolTipIcon.Info);
            }
        }

        /// <summary>
        /// 点击托盘图标
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NotifyIcon_Click(object sender, EventArgs e)
        {
            Visible = true;
            notifyIcon.Visible = false;
            Focus();
        }

        #endregion

    }

}
