using ScreenShare.Properties;
using ScreenShare.Util;
using ScreenShare.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScreenShare
{

    public partial class ScreenShare : Form
    {

        #region 参数

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
        /// http服务器
        /// </summary>
        private HttpListener httpServer;
        /// <summary>
        /// socket服务器
        /// </summary>
        private Socket socketServer;
        /// <summary>
        /// socket客户端
        /// </summary>
        private static readonly List<SocketClient> socketClientList = new List<SocketClient>();

        #endregion

        #region 公共方法

        /// <summary>
        /// 主程序
        /// </summary>
        public ScreenShare()
        {
            InitializeComponent();
            Init();
            Log("屏幕共享初始化完成！");
        }

        /// <summary>
        /// 启动
        /// </summary>
        public void Start()
        {
            // 启动http服务器
            if (!StartHttpServer())
            {
                Log("http服务器启动失败！请更换IP端口号或重启程序或联系开发者！");
                MessageBox.Show("http服务器启动失败！请更换IP端口号重启程序或联系开发者！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // 启动socket服务器
            if (!StartSocketServer())
            {
                CloseHttpServer();
                Log("socket服务器启动失败！请重启程序或联系开发者！");
                MessageBox.Show("socket服务器启动失败！请重启程序或联系开发者！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            isWorking = true;
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
            isWorking = false;
            // 设置UI状态为停用
            SetUiStatus(false);
            // 关闭http服务器
            CloseHttpServer();
            // 关闭socket服务器
            CloseSocketServer();
            // 手动gc
            GC.Collect();
            Log("屏幕共享已停止。");
        }

        #endregion

        #region http服务器

        /// <summary>
        /// 启动http服务器
        /// </summary>
        /// <returns>是否启动成功</returns>
        private bool StartHttpServer()
        {
            // 新建http服务器
            httpServer = new HttpListener
            {
                // 忽视客户端写入异常
                IgnoreWriteExceptions = true
            };
            // 指定URI
            httpServer.Prefixes.Add(shareLinkText.Text);
            try
            {
                // 开启http服务器
                httpServer.Start();
            }
            catch
            {
                // 端口号冲突
                return false;
            }
            // 异步监听客户端请求
            httpServer.BeginGetContext(HttpHandle, null);
            // 添加防火墙规则
            Utils.AddNetFw("ScreenShare", (int)ipPortNud.Value);
            return true;
        }

        /// <summary>
        /// 关闭http服务器
        /// </summary>
        private void CloseHttpServer()
        {
            // 删除防火墙规则
            Utils.RemoveNetFw((int)ipPortNud.Value);
            httpServer.Close();
        }

        /// <summary>
        /// http处理
        /// </summary>
        /// <param name="ar">IAsyncResult</param>
        private void HttpHandle(IAsyncResult ar)
        {
            try
            {
                // 继续异步监听客户端请求
                httpServer.BeginGetContext(HttpHandle, null);
            }
            catch
            {
                // 主动关闭http服务器
                return;
            }
            // 获取context对象
            var context = httpServer.EndGetContext(ar);
            var request = context.Request;
            var response = context.Response;
            // 设置response状态码：请求成功
            response.StatusCode = (int)HttpStatusCode.OK;
            switch (request.Url.LocalPath)
            {
                // 网页
                default:
                    {
                        // 设置response类型：网页
                        response.ContentType = "text/html;charset=UTF-8";
                        // 返回给客户端
                        HttpResponseWrite(response, Encoding.UTF8.GetBytes(Resources.index));
                        break;
                    }
                // 图标
                case "/favicon.ico":
                    {
                        // 设置response类型：图标
                        response.ContentType = "image/x-icon";
                        MemoryStream faviconStream = new MemoryStream();
                        Resources.favicon.Save(faviconStream);
                        HttpResponseWrite(response, faviconStream.ToArray());
                        break;
                    }
                // API:获取视频信息
                case "/api/getVideoInfo":
                    {
                        // 设置response类型：JSON
                        response.ContentType = "application/json;charset=UTF-8";
                        string apiGetVideoInfo = null;
                        // 开启加密
                        if (isEncryptionCb.Checked)
                        {
                            // 解决中文乱码问题
                            var pathAndQuery = request.Url.ToString().Split('?');
                            // 密码未输入或密码错误
                            if (pathAndQuery.Length != 2 || pathAndQuery[1] != ("code=" + pwdText.Text))
                            {
                                apiGetVideoInfo = "{\"width\":" + videoWNud.Value + ",\"height\":" + videoHNud.Value + ",\"frame\":" + videoFrameNud.Value + ",\"port\":0}";
                            }
                        }
                        // 无需密码或密码正确
                        if (apiGetVideoInfo == null)
                        {
                            apiGetVideoInfo = "{\"width\":" + videoWNud.Value + ",\"height\":" + videoHNud.Value + ",\"frame\":" + videoFrameNud.Value + ",\"port\":" + ((IPEndPoint)socketServer.LocalEndPoint).Port + "}";
                        }
                        HttpResponseWrite(response, Encoding.UTF8.GetBytes(apiGetVideoInfo));
                        break;
                    }
            }
            // 关闭连接
            response.Close();
        }

        /// <summary>
        /// http响应回复
        /// </summary>
        /// <param name="response">HttpListenerResponse</param>
        /// <param name="buffer">buffer</param>
        private static void HttpResponseWrite(HttpListenerResponse response, byte[] buffer)
        {
            try
            {
                // 返回给客户端
                response.OutputStream.Write(buffer, 0, buffer.Length);
            }
            catch
            {
                // 客户端主动关闭连接
            }
        }

        #endregion

        #region socket服务器

        /// <summary>
        /// 启动socket服务器
        /// <returns>是否启动成功</returns>
        /// </summary>
        private bool StartSocketServer()
        {
            try
            {
                // 新建socket服务器
                socketServer = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                // 指定URI
                socketServer.Bind(new IPEndPoint(IPAddress.Parse(ipList.ElementAt(ipAddressComboBox.SelectedIndex).Item2), 0));
                // 设置监听数量
                socketServer.Listen(10);
                // 异步监听客户端请求
                socketServer.BeginAccept(SocketHandle, null);
                // 添加防火墙规则
                Utils.AddNetFw("ScreenShare", ((IPEndPoint)socketServer.LocalEndPoint).Port);
            }
            // 未知错误
            catch
            {
                socketServer.Close();
                return false;
            }
            return true;
        }

        /// <summary>
        /// 关闭socket服务器
        /// </summary>
        private void CloseSocketServer()
        {
            // 删除防火墙规则
            Utils.RemoveNetFw(((IPEndPoint)socketServer.LocalEndPoint).Port);
            foreach (var socketClient in socketClientList.FindAll(e => e.Client != null))
            {
                socketClient.Close();
                UpdateSocketUi(socketClient.Ip, false);
            }
            socketServer.Close();
        }

        /// <summary>
        /// socket处理
        /// </summary>
        /// <param name="ar">IAsyncResult</param>
        private void SocketHandle(IAsyncResult ar)
        {
            try
            {
                // 继续异步监听客户端请求
                socketServer.BeginAccept(SocketHandle, null);
            }
            // 主动关闭socket服务器
            catch
            {
                return;
            }
            // 客户端上线
            SocketClientOnline(socketServer.EndAccept(ar));
        }

        /// <summary>
        /// socket客户端上线
        /// </summary>
        /// <param name="client">客户端</param>
        private void SocketClientOnline(Socket client)
        {
            // 已存在
            if (socketClientList.Exists(e => e.Client == client))
            {
                return;
            }
            SocketClient socketClient = null;
            try
            {
                socketClient = new SocketClient(client);
                // 设置超时10秒
                client.SendTimeout = 10000;
                // 接收消息
                client.BeginReceive(socketClient.Buffer, 0, socketClient.Buffer.Length, SocketFlags.None, SocketRecevice, socketClient);
                socketClientList.Add(socketClient);
                UpdateSocketUi(socketClient.Ip, true);
            }
            catch
            {
                if (socketClient != null)
                {
                    socketClient.Close();
                }
                return;
            }
        }

        /// <summary>
        /// socket客户端下线
        /// </summary>
        /// <param name="socketClient">SocketClient</param>
        private void SocketClientOffline(SocketClient socketClient)
        {
            // 不存在
            if (!socketClientList.FindAll(e => e.Client != null).Contains(socketClient))
            {
                return;
            }
            socketClient.Close();
            UpdateSocketUi(socketClient.Ip, false);
        }

        /// <summary>
        /// 接收socket消息
        /// </summary>
        /// <param name="ar">IAsyncResult</param>
        private void SocketRecevice(IAsyncResult ar)
        {
            // 获取当前客户端
            SocketClient socketClient = ar.AsyncState as SocketClient;
            try
            {
                // 获取接收数据长度
                int length = socketClient.Client.EndReceive(ar);
                // 客户端主动断开连接时，会发送0字节消息
                if (length == 0)
                {
                    SocketClientOffline(socketClient);
                    return;
                }
                // 首次连接
                if (socketClient.Buffer[0] == 71)
                {
                    // 解码消息
                    string msg = Encoding.UTF8.GetString(socketClient.Buffer, 0, length);
                    // 判断是否符合webSocket报文格式
                    if (msg.Contains("Sec-WebSocket-Key"))
                    {
                        // 握手
                        SocketSendRaw(socketClient, WebSocketUtils.HandShake(msg));
                        // 继续接收消息
                        socketClient.Client.BeginReceive(socketClient.Buffer, 0, length, SocketFlags.None, SocketRecevice, socketClient);
                    }
                    // 不符合格式，关闭连接
                    else
                    {
                        SocketClientOffline(socketClient);
                        return;
                    }
                }
                else
                {
                    // 继续接收消息
                    socketClient.Client.BeginReceive(socketClient.Buffer, 0, length, SocketFlags.None, SocketRecevice, socketClient);
                    string data = WebSocketUtils.DecodeDataString(socketClient.Buffer, length);
                    // 客户端关闭连接
                    if (data == null)
                    {
                        SocketClientOffline(socketClient);
                        return;
                    }
                    else
                    {
                        socketClient.Transmission = false;
                    }
                }
            }
            // 超时后失去连接、未知错误
            catch
            {
                SocketClientOffline(socketClient);
                return;
            }
        }

        /// <summary>
        /// socket发送原始消息
        /// </summary>
        /// <param name="socketClient">SocketClient</param>
        /// <param name="data">byte[]</param>
        private void SocketSendRaw(SocketClient socketClient, byte[] data)
        {
            try
            {
                // 发送消息
                socketClient.Client.BeginSend(data, 0, data.Length, SocketFlags.None, asyncResult =>
                {
                    try
                    {
                        socketClient.Client.EndSend(asyncResult);
                    }
                    // 已失去连接
                    catch
                    {
                        SocketClientOffline(socketClient);
                        return;
                    }
                }, null);
            }
            // 未知错误
            catch
            {
                SocketClientOffline(socketClient);
                return;
            }
        }

        /// <summary>
        /// socket发送MemoryStream
        /// </summary>
        /// <param name="stream">MemoryStream</param>
        /// <param name="list">List SocketClient</param>
        private void SocketSendMemoryStream(MemoryStream stream, List<SocketClient> list)
        {
            if (list.Count != 0)
            {
                var data = stream.ToArray();
                foreach (var client in list)
                {
                    SocketSendRaw(client, WebSocketUtils.CodedData(data, false));
                }
            }
        }

        /// <summary>
        /// 更新socket UI
        /// </summary>
        /// <param name="ip">ip</param>
        /// <param name="online">上线和下线</param>
        private void UpdateSocketUi(string ip, bool online)
        {
            /* 更新在线数量 */
            string count = "当前在线用户数量：" + socketClientList.FindAll(e => e.Client != null).Count;
            // 利用委托，防止`线程间操作无效`
            Action<string> action = (data) =>
            {
                userCountLinkLabel.Text = data;
            };
            Invoke(action, count);
            /* 日志 */
            string log = "客户端 " + ip + (online ? " 已上线。" : " 已下线。");
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
            Bitmap bitmap;
            MemoryStream stream = new MemoryStream();
            int delay = videoFrameNud.Value == 0 ? 1 : (int)(1000 / videoFrameNud.Value);
            int videoQuality = (int)videoQualityNud.Value;
            bool isDisplayCursor = isDisplayCursorCb.Checked;
            Rectangle screen = new Rectangle((int)screenXNud.Value, (int)screenYNud.Value, (int)screenWNud.Value, (int)screenHNud.Value);
            Size video = new Size((int)videoWNud.Value, (int)videoHNud.Value);
            // 普通
            if (screen.Size == video && videoQuality == 100)
            {
                // 开启共享
                while (isWorking)
                {
                    // 获取在线 并且 可发送数据的用户列表
                    var list = socketClientList.FindAll(e => (e.Client != null && !e.Transmission));
                    // 符合条件的用户 或 正在预览
                    if (list.Count != 0 || !(previewImg.Dock == DockStyle.None || WindowState == FormWindowState.Minimized))
                    {
                        try
                        {
                            // 捕获屏幕
                            bitmap = ImageUtils.CaptureScreenArea(screen, isDisplayCursor);
                            // 保存到内存流
                            stream.SetLength(0);
                            ImageUtils.Save(bitmap, stream);
                            // 发送给socket客户端
                            SocketSendMemoryStream(stream, list);
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
                while (isWorking)
                {
                    var list = socketClientList.FindAll(e => (e.Client != null && !e.Transmission));
                    if (list.Count != 0 || !(previewImg.Dock == DockStyle.None || WindowState == FormWindowState.Minimized))
                    {
                        try
                        {
                            bitmap = ImageUtils.ZoomImage(ImageUtils.CaptureScreenArea(screen, isDisplayCursor), video, true);
                            stream.SetLength(0);
                            ImageUtils.Save(bitmap, stream);
                            SocketSendMemoryStream(stream, list);
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
                while (isWorking)
                {
                    var list = socketClientList.FindAll(e => (e.Client != null && !e.Transmission));
                    if (list.Count != 0 || !(previewImg.Dock == DockStyle.None || WindowState == FormWindowState.Minimized))
                    {
                        try
                        {
                            bitmap = ImageUtils.CaptureScreenArea(screen, isDisplayCursor);
                            stream.SetLength(0);
                            ImageUtils.QualitySave(bitmap, videoQuality, stream);
                            SocketSendMemoryStream(stream, list);
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
                while (isWorking)
                {
                    var list = socketClientList.FindAll(e => (e.Client != null && !e.Transmission));
                    if (list.Count != 0 || !(previewImg.Dock == DockStyle.None || WindowState == FormWindowState.Minimized))
                    {
                        try
                        {
                            bitmap = ImageUtils.ZoomImage(ImageUtils.CaptureScreenArea(screen, isDisplayCursor), video, true);
                            stream.SetLength(0);
                            ImageUtils.QualitySave(bitmap, videoQuality, stream);
                            SocketSendMemoryStream(stream, list);
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
            // 预览图小窗口显示
            PreviewImgUiFullWindow(false);
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
            UpdatePreviewImgWithCaptureScreen();
        }

        /// <summary>
        /// 运行时更新预览图
        /// </summary>
        /// <param name="bitmap">Bitmap</param>
        private void UpdatePreviewImgWhileWorking(Bitmap bitmap)
        {
            // 不显示预览图
            if (previewImg.Dock == DockStyle.None || WindowState == FormWindowState.Minimized)
            {
                bitmap.Dispose();
            }
            // 更新预览图
            else
            {
                UpdatePreviewImg(bitmap);
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
        /// 预览图UI全窗口显示
        /// </summary>
        /// <param name="enable">是否</param>
        private void PreviewImgUiFullWindow(bool enable)
        {
            // 全窗口显示
            if (enable)
            {
                FormBorderStyle = FormBorderStyle.Sizable;
                MaximizeBox = true;
                startSharingScreenBtn.Enabled = false;
                topPanel.Visible = false;
                middlePanel.Visible = false;
                bottomPanel.Dock = DockStyle.Fill;
                previewImg.Dock = DockStyle.Fill;
                if (isWorking)
                {
                    previewLabel.Visible = false;
                }
            }
            // 小窗口显示
            else
            {
                Size = new Size(784, 471);
                WindowState = FormWindowState.Normal;
                FormBorderStyle = FormBorderStyle.FixedDialog;
                MaximizeBox = false;
                startSharingScreenBtn.Enabled = true;
                topPanel.Visible = true;
                middlePanel.Visible = true;
                bottomPanel.Dock = DockStyle.Bottom;
                previewImg.Dock = DockStyle.None;
                if (isWorking)
                {
                    previewLabel.Visible = true;
                }
            }
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
            UpdatePreviewImgWithCaptureScreen();
        }

        /// <summary>
        /// 屏幕的Y发生改变
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ScreenYNud_ValueChanged(object sender, EventArgs e)
        {
            screenHNud.Maximum = screenList.ElementAt(screenComboBox.SelectedIndex).Item2.Bottom - screenYNud.Value;
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
            // 全窗口显示
            if (previewImg.Dock == DockStyle.None)
            {
                PreviewImgUiFullWindow(true);
            }
            // 小窗口显示
            else
            {
                if (isWorking)
                {
                    // 不显示预览图
                    previewImg.Image.Dispose();
                    previewImg.Image = null;
                }
                PreviewImgUiFullWindow(false);
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
            // 最小化窗口
            if (WindowState == FormWindowState.Minimized)
            {
                // 释放预览图
                if (previewImg.Image != null)
                {
                    previewImg.Image.Dispose();
                    previewImg.Image = null;
                }
            }
            // 还原窗口：如果未在运行、未显示预览图
            else if (!isWorking && previewImg.Image == null)
            {
                // 更新预览图
                UpdatePreviewImgWithCaptureScreen();
            }
        }

        /// <summary>
        /// 点击当前在线用户数量链接
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UserCountLinkLabel_Click(object sender, EventArgs e)
        {
            new History(socketClientList).ShowDialog();
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
            // 如果正在运行，则托盘
            if (isWorking)
            {
                if (previewImg.Image != null)
                {
                    // 不显示预览图
                    previewImg.Image.Dispose();
                    previewImg.Image = null;
                }
                // 预览图小窗口显示
                PreviewImgUiFullWindow(false);
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
