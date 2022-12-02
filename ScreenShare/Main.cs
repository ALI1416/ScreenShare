using ScreenShare.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScreenShare
{
    public partial class ScreenShare : Form
    {
        #region 参数和常量

        /********** 参数 **********/
        /// <summary>
        /// 已启动
        /// </summary>
        private bool isWorking = false;
        /// <summary>
        /// IP地址列表
        /// </summary>
        private List<Tuple<string, string>> ipList;
        /// <summary>
        /// 屏幕信息列表
        /// </summary>
        private List<Tuple<string, Rectangle>> screenList;
        /// <summary>
        /// 图标MemoryStream
        /// </summary>
        private readonly MemoryStream faviconStream = new MemoryStream();
        /// <summary>
        /// 图片MemoryStream
        /// </summary>
        private readonly MemoryStream imageStream = new MemoryStream();
        /// <summary>
        /// http服务器线程
        /// </summary>
        private Thread httpServerThread;
        /// <summary>
        /// http服务器
        /// </summary>
        private HttpListener httpServer;
        /// <summary>
        /// socket服务器线程
        /// </summary>
        private Thread socketServerThread;
        /// <summary>
        /// socket服务器
        /// </summary>
        private Socket socketServer;
        /// <summary>
        /// socket服务器端口号
        /// </summary>
        private int socketServerPort = 0;
        /// <summary>
        /// socket客户端
        /// </summary>
        private static readonly List<Socket> socketClient = new List<Socket>();
        /// <summary>
        /// socket接收数据缓冲区
        /// </summary>
        static readonly byte[] socketBuffer = new byte[1024];

        /********** 常量 **********/
        private readonly static byte[] socketResponseHeader = Encoding.ASCII.GetBytes("HTTP/1.1 200 OK\nContent-Type: multipart/x-mixed-replace; boundary=--boundary\n");
        private readonly static byte[] socketResponseEnd = Encoding.ASCII.GetBytes("\n");

        #endregion

        #region 方法

        /********** 主方法 **********/
        /// <summary>
        /// 启动
        /// </summary>
        public ScreenShare()
        {
            InitializeComponent();
            // 初始化图标
            Resources.favicon.Save(faviconStream);
            Init();
            Log("屏幕共享初始化完成！");
        }

        /********** 私有方法 **********/
        /// <summary>
        /// 初始化
        /// </summary>
        private void Init()
        {
            /* 头部 */
            // IP地址
            ipList = Utils.GetAllIPv4Address();
            ipAddressComboBox.Items.Clear();
            foreach (var ip in ipList)
            {
                ipAddressComboBox.Items.Add(ip.Item2 + " - " + ip.Item1);
            }
            ipAddressComboBox.SelectedIndex = 0;
            // 端口号
            ipPortNud.Value = 7070;
            // 分享地址
            shareLinkText.Text = "http://" + ipList.ElementAt(ipAddressComboBox.SelectedIndex).Item2 + ":" + ipPortNud.Value + "/";

            /* 加密传输 */
            // 开启加密
            isEncryptionCb.Checked = false;
            // 密码
            pwdText.Text = "";

            /* 选取位置 */
            // 全屏
            isFullScreenCb.Checked = true;
            // 显示器
            screenList = Utils.GetAllScreen();
            screenComboBox.Items.Clear();
            foreach (var screen in screenList)
            {
                screenComboBox.Items.Add(screen.Item1 + "[" + screen.Item2.Width + "x" + screen.Item2.Height + "]");
            }
            if (screenList.Count == 1)
            {
                screenComboBox.SelectedIndex = 0;
            }
            else
            {
                screenComboBox.SelectedIndex = 1;
            }
            Rectangle selectedScreen = screenList.ElementAt(screenComboBox.SelectedIndex).Item2;
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
            previewImg.Image = ImageUtils.CaptureScreenArea(new Rectangle((int)screenXNud.Value, (int)screenYNud.Value, (int)screenWNud.Value, (int)screenHNud.Value), isDisplayCursorCb.Checked);
        }

        /// <summary>
        /// 开启http服务器
        /// </summary>
        private async void HttpServerTask()
        {
            HttpListenerContext ctx;
            byte[] responseData;
            string html = Resources.indexHtml1 + videoWNud.Value + ";const imgHeight=" + videoHNud.Value + ";const frame=" + videoFrameNud.Value + Resources.indexHtml2;
            string apiGetVideoInfo = "{\"width\":" + videoWNud.Value + ",\"height\":" + videoHNud.Value + ",\"frame\":" + videoFrameNud.Value + "}";
            while (isWorking)
            {
                try
                {
                    ctx = await httpServer.GetContextAsync();
                    // 请求成功
                    ctx.Response.StatusCode = 200;
                    // 判断请求地址
                    switch (ctx.Request.Url.LocalPath)
                    {
                        // 图标
                        case "/favicon.ico":
                            {
                                ctx.Response.ContentType = "image/x-icon";
                                responseData = faviconStream.ToArray();
                                break;
                            }
                        // API:获取视频信息
                        case "/api/getVideoInfo":
                            {
                                ctx.Response.ContentType = "application/json;charset=UTF-8";
                                responseData = Encoding.UTF8.GetBytes(apiGetVideoInfo);
                                break;
                            }
                        // 网页
                        default:
                            {
                                ctx.Response.ContentType = "text/html;charset=UTF-8";
                                responseData = Encoding.UTF8.GetBytes(html);
                                break;
                            }
                    }
                    await ctx.Response.OutputStream.WriteAsync(responseData, 0, responseData.Length);
                    ctx.Response.Close();
                }
                catch
                {
                }
            }
        }


        /// <summary>
        /// 开启屏幕捕获
        /// </summary>
        private async void CaptureScreenTask()
        {
            Bitmap bitmap;
            int delay = (int)(1000 / videoFrameNud.Value);
            int videoQuality = (int)videoQualityNud.Value;
            Rectangle screen = new Rectangle((int)screenXNud.Value, (int)screenYNud.Value, (int)screenWNud.Value, (int)screenHNud.Value);
            Size video = new Size((int)videoWNud.Value, (int)videoHNud.Value);
            /* 判断捕获图片属性 */
            // 普通
            if (screen.Size == video && videoQuality == 100)
            {
                while (isWorking)
                {
                    try
                    {
                        bitmap = ImageUtils.CaptureScreenArea(screen, isDisplayCursorCb.Checked);
                        imageStream.SetLength(0);
                        ImageUtils.Save(bitmap, imageStream);
                        DisplayPreviewImg(bitmap);
                    }
                    catch (Win32Exception)
                    {
                        Log("异常终止屏幕共享！可能是锁定了账户。");
                        Stop();
                    }
                    catch
                    {
                    }
                    await Task.Delay(delay);
                }
            }
            // 缩放
            else if (screen.Size != video && videoQualityNud.Value == 100)
            {
                while (isWorking)
                {
                    try
                    {
                        bitmap = ImageUtils.ZoomImage(ImageUtils.CaptureScreenArea(screen, isDisplayCursorCb.Checked), video, true);
                        imageStream.SetLength(0);
                        ImageUtils.Save(bitmap, imageStream);
                        DisplayPreviewImg(bitmap);
                    }
                    catch (Win32Exception)
                    {
                        Log("异常终止屏幕共享！可能是锁定了账户。");
                        Stop();
                    }
                    catch
                    {
                    }
                    await Task.Delay(delay);
                }
            }
            // 压缩
            else if (screen.Size == video && videoQuality != 100)
            {
                while (isWorking)
                {
                    try
                    {
                        bitmap = ImageUtils.CaptureScreenArea(screen, isDisplayCursorCb.Checked);
                        imageStream.SetLength(0);
                        ImageUtils.QualitySave(bitmap, videoQuality, imageStream);
                        DisplayPreviewImg(bitmap);
                    }
                    catch (Win32Exception)
                    {
                        Log("异常终止屏幕共享！可能是锁定了账户。");
                        Stop();
                    }
                    catch
                    {
                    }
                    await Task.Delay(delay);
                }
            }
            // 缩放+压缩
            else
            {
                while (isWorking)
                {
                    try
                    {
                        bitmap = ImageUtils.ZoomImage(ImageUtils.CaptureScreenArea(screen, isDisplayCursorCb.Checked), video, true);
                        imageStream.SetLength(0);
                        ImageUtils.QualitySave(bitmap, videoQuality, imageStream);
                        DisplayPreviewImg(bitmap);
                    }
                    catch (Win32Exception)
                    {
                        Log("异常终止屏幕共享！可能是锁定了账户。");
                        Stop();
                    }
                    catch
                    {
                    }
                    await Task.Delay(delay);
                }
            }
        }

        /// <summary>
        /// 启动
        /// </summary>
        private void Start()
        {
            isWorking = true;
            startSharingScreenBtn.Text = "停止共享";
            // 设置选项不可选择
            SetEnable(false);
            try
            {
                // 启动http服务器
                StartHttpServer();
            }
            catch
            {
                Stop();
                Log("http服务器启动失败！请更换IP端口号或重启程序或联系开发者！");
                MessageBox.Show("http服务器启动失败！请更换IP端口号重启程序或联系开发者！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                // 启动socket服务器
                StartSocketServer();
            }
            catch
            {
                Stop();
                Log("socket服务器启动失败！请重启程序或联系开发者！");
                MessageBox.Show("socket服务器启动失败！请重启程序或联系开发者！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                // 开启http服务器
                httpServer = new HttpListener
                {
                    IgnoreWriteExceptions = true
                };
                httpServer.Prefixes.Clear();
                httpServer.Prefixes.Add(shareLinkText.Text);
                httpServer.Start();
                HttpServerTask();
                // 开启socket服务器
                socketServer = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                socketServer.Bind(new IPEndPoint(IPAddress.Parse(ipList.ElementAt(ipAddressComboBox.SelectedIndex).Item2), 0));
                socketServer.Listen(10);
                socketServerPort = ((IPEndPoint)socketServer.LocalEndPoint).Port;
                Log("" + socketServerPort);
            }
            catch
            {
                Stop();
                Log("启动失败！请重启程序或联系开发者！");
                MessageBox.Show("启动失败！请重启程序或联系开发者！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // 关闭图像预览
            //previewLabel.Visible = true;
            //previewImg.Image.Dispose();
            //previewImg.Image = null;
            //// 添加防火墙规则
            //Utils.AddNetFw("ScreenShare", (int)ipPortNud.Value);
            //Utils.AddNetFw("ScreenShare", socketServerPort);
            Log("屏幕共享已开启。");
        }

        /// <summary>
        /// 启动http服务器
        /// </summary>
        private void StartHttpServer()
        {
            // 新建http服务器
            httpServer = new HttpListener
            {
                // 忽视客户端写入异常
                IgnoreWriteExceptions = true
            };
            // 清空URI
            httpServer.Prefixes.Clear();
            // 指定URI
            httpServer.Prefixes.Add(shareLinkText.Text);
            // 开启http服务器
            httpServer.Start();
            // 异步监听客户端请求
            httpServer.BeginGetContext(HttpHandle, null);
        }

        /// <summary>
        /// 启动socket服务器
        /// </summary>
        private void StartSocketServer()
        {

        }

        /// <summary>
        /// 启动捕获屏幕
        /// </summary>
        private void StartCaptureScreen()
        {

        }

        /// <summary>
        /// http处理
        /// </summary>
        /// <param name="ar">IAsyncResult</param>
        private void HttpHandle(IAsyncResult ar)
        {
            // 继续异步监听客户端请求
            httpServer.BeginGetContext(HttpHandle, null);
            // 获取context对象
            var context = httpServer.EndGetContext(ar);
            var request = context.Request;
            var response = context.Response;
        }


        /// <summary>
        /// 终止
        /// </summary>
        private void Stop()
        {
            isWorking = false;
            startSharingScreenBtn.Text = "开始共享";
            // 关闭http服务器
            httpServer.Close();
            // 关闭socket服务器
            //socketServer.Close();
            //// 显示图像预览
            //previewLabel.Visible = false;
            //previewImg.Image = new Bitmap(imageStream);
            //// 删除防火墙规则
            //Utils.RemoveNetFw((int)ipPortNud.Value);
            //Utils.RemoveNetFw(socketServerPort);
            //// 设置选项可以选择
            //SetEnable(true);
            //// 手动gc
            //GC.Collect();
            Log("屏幕共享已停止。");
        }

        /// <summary>
        /// 显示预览图片
        /// </summary>
        /// <param name="bitmap">Bitmap</param>
        private void DisplayPreviewImg(Bitmap bitmap)
        {
            if (previewImg.Dock == DockStyle.None)
            {
                bitmap.Dispose();
            }
            else
            {
                previewImg.Image.Dispose();
                previewImg.Image = bitmap;
            }
        }

        /// <summary>
        /// 设置选项是否可以选择
        /// </summary>
        /// <param name="enable"></param>
        private void SetEnable(bool enable)
        {
            ipAddressComboBox.Enabled = enable;
            ipPortNud.Enabled = enable;
            isEncryptionCb.Enabled = enable;
            isFullScreenCb.Enabled = enable;
            screenComboBox.Enabled = enable;
            isLockAspectRatioCb.Enabled = enable;
            isDisplayCursorCb.Enabled = enable;
            videoFrameNud.Enabled = enable;
            videoQualityNud.Enabled = enable;
            reloadConfigBtn.Enabled = enable;
            captureScreenCoordinatesBtn.Enabled = enable;
            // 可选择
            if (enable)
            {
                if (isEncryptionCb.Checked)
                {
                    pwdText.Enabled = enable;
                }
                if (!isFullScreenCb.Checked)
                {
                    screenXNud.Enabled = enable;
                    screenYNud.Enabled = enable;
                    screenWNud.Enabled = enable;
                    screenHNud.Enabled = enable;
                }
                if (isLockAspectRatioCb.Checked)
                {
                    scalingNud.Enabled = enable;
                }
                else
                {
                    videoWNud.Enabled = enable;
                    videoHNud.Enabled = enable;
                }
            }
            // 不可选择
            else
            {
                pwdText.Enabled = enable;
                screenXNud.Enabled = enable;
                screenYNud.Enabled = enable;
                screenWNud.Enabled = enable;
                screenHNud.Enabled = enable;
                scalingNud.Enabled = enable;
                videoWNud.Enabled = enable;
                videoHNud.Enabled = enable;
            }
        }

        /// <summary>
        /// 写日志
        /// </summary>
        /// <param name="text">内容</param>
        private void Log(string text)
        {
            logText.Text += DateTime.Now.ToLongTimeString() + " : " + text + "\r\n";
            logText.SelectionStart = logText.Text.Length;
            logText.ScrollToCaret();
        }

        #endregion

        #region 界面事件

        /********** 界面事件 **********/
        /// <summary>
        /// 点击开始共享按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StartSharingScreenBtn_Click(object sender, EventArgs e)
        {
            if (isWorking)
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
            shareLinkText.Text = "http://" + ipList.ElementAt(ipAddressComboBox.SelectedIndex).Item2 + ":" + ipPortNud.Value + "/";
        }

        /// <summary>
        /// IP端口号改变
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void IpPortNud_ValueChanged(object sender, EventArgs e)
        {
            shareLinkText.Text = "http://" + ipList.ElementAt(ipAddressComboBox.SelectedIndex).Item2 + ":" + ipPortNud.Value + "/";
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
        /// 点击关于按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AboutBtn_Click(object sender, EventArgs e)
        {
            new About().ShowDialog();
        }

        /// <summary>
        /// 点击复制按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CopyBtn_Click(object sender, EventArgs e)
        {
            try
            {
                Clipboard.SetText(shareLinkText.Text);
                Log("分享链接已复制。");
            }
            catch
            {
                Log("复制失败！请手动复制。");
                MessageBox.Show("复制失败！请手动复制。", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
                Rectangle selectedScreen = screenList.ElementAt(screenComboBox.SelectedIndex).Item2;
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
            Rectangle selectedScreen = screenList.ElementAt(screenComboBox.SelectedIndex).Item2;
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
            screenWNud.Maximum = screenList.ElementAt(screenComboBox.SelectedIndex).Item2.Right - screenXNud.Value;
            // TODO 屏幕的XY宽高同时发生改变可能会渲染多次预览图
            previewImg.Image.Dispose();
            previewImg.Image = ImageUtils.CaptureScreenArea(new Rectangle((int)screenXNud.Value, (int)screenYNud.Value, (int)screenWNud.Value, (int)screenHNud.Value), isDisplayCursorCb.Checked);
        }

        /// <summary>
        /// 屏幕的Y发生改变
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ScreenYNud_ValueChanged(object sender, EventArgs e)
        {
            screenHNud.Maximum = screenList.ElementAt(screenComboBox.SelectedIndex).Item2.Bottom - screenYNud.Value;
            previewImg.Image.Dispose();
            previewImg.Image = ImageUtils.CaptureScreenArea(new Rectangle((int)screenXNud.Value, (int)screenYNud.Value, (int)screenWNud.Value, (int)screenHNud.Value), isDisplayCursorCb.Checked);
        }

        /// <summary>
        /// 屏幕的宽发生改变
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ScreenWNud_ValueChanged(object sender, EventArgs e)
        {
            videoWNud.Value = screenWNud.Value * scalingNud.Value / 100;
            if (previewImg.Image != null)
            {
                previewImg.Image.Dispose();
                previewImg.Image = ImageUtils.CaptureScreenArea(new Rectangle((int)screenXNud.Value, (int)screenYNud.Value, (int)screenWNud.Value, (int)screenHNud.Value), isDisplayCursorCb.Checked);
            }
        }

        /// <summary>
        /// 屏幕的高发生改变
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ScreenHNud_ValueChanged(object sender, EventArgs e)
        {
            videoHNud.Value = screenHNud.Value * scalingNud.Value / 100;
            if (previewImg.Image != null)
            {
                previewImg.Image.Dispose();
                previewImg.Image = ImageUtils.CaptureScreenArea(new Rectangle((int)screenXNud.Value, (int)screenYNud.Value, (int)screenWNud.Value, (int)screenHNud.Value), isDisplayCursorCb.Checked);
            }
        }

        /// <summary>
        /// 点击选取屏幕坐标按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CaptureScreenCoordinatesBtn_Click(object sender, EventArgs e)
        {
            DrawScreen drawScreen = new DrawScreen(screenList.ElementAt(screenComboBox.SelectedIndex).Item2);
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
            // 如果是小窗口，则切换到全屏
            if (previewImg.Dock == DockStyle.None)
            {
                previewImg.Dock = DockStyle.Fill;
                FormBorderStyle = FormBorderStyle.Sizable;
                MaximizeBox = true;
                if (isWorking)
                {
                    previewImg.Image = new Bitmap(imageStream);
                    previewLabel.Visible = false;
                }
            }
            // 如果是全屏，则切换到小窗口
            else
            {
                Size = new Size(784, 471);
                WindowState = FormWindowState.Normal;
                previewImg.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
                FormBorderStyle = FormBorderStyle.FixedDialog;
                MaximizeBox = false;
                if (isWorking)
                {
                    previewImg.Image.Dispose();
                    previewImg.Image = null;
                    previewLabel.Visible = true;
                }
            }
        }

        /// <summary>
        /// 点击预览图上的文字
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PreviewLabel_Click(object sender, EventArgs e)
        {
            PreviewImg_Click(null, null);
        }

        /// <summary>
        /// 窗口大小改变后
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ScreenShare_SizeChanged(object sender, EventArgs e)
        {
            // 最小化
            if (WindowState == FormWindowState.Minimized)
            {
                // 如果是全屏，则切换到小窗口
                if (previewImg.Dock == DockStyle.Fill)
                {
                    PreviewImg_Click(null, null);
                    // PreviewImg_Click可能会还原窗口，所以要重新最小化一次
                    WindowState = FormWindowState.Minimized;
                }
                // 如果未在运行
                if (!isWorking && previewImg.Image != null)
                {
                    previewImg.Image.Dispose();
                    previewImg.Image = null;
                }
            }
            // 如果未在运行、未显示预览图
            else if (!isWorking && previewImg.Image == null)
            {
                previewImg.Image = ImageUtils.CaptureScreenArea(new Rectangle((int)screenXNud.Value, (int)screenYNud.Value, (int)screenWNud.Value, (int)screenHNud.Value), isDisplayCursorCb.Checked);
            }
        }

        /// <summary>
        /// 点击当前在线用户数量链接
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UserCountLinkLabel_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 点击关闭按钮前
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ScreenShare_FormClosing(object sender, FormClosingEventArgs e)
        {
            // 如果正在运行，则托盘
            if (isWorking)
            {
                // 如果是全屏，则切换到小窗口
                if (previewImg.Dock == DockStyle.Fill)
                {
                    PreviewImg_Click(null, null);
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
