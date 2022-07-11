using ScreenShare.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScreenShare
{
    public partial class ScreenShare : Form
    {
        /* 初始化参数 */
        /// <summary>
        /// 已启动
        /// </summary>
        private bool isWorking = false;
        /// <summary>
        /// IP地址下标
        /// </summary>
        private int ipAddressIndex;
        /// <summary>
        /// 端口号
        /// </summary>
        private int port;
        /// <summary>
        /// 分享地址
        /// </summary>
        private String shareLink;
        /// <summary>
        /// 开启加密
        /// </summary>
        private bool isEncryption;
        /// <summary>
        /// 账号
        /// </summary>
        private String account;
        /// <summary>
        /// 密码
        /// </summary>
        private String pwd;
        /// <summary>
        /// 开启全屏
        /// </summary>
        private bool isFullScreen;
        /// <summary>
        /// 显示器下标
        /// </summary>
        private int screenIndex;
        /// <summary>
        /// 显示器X
        /// </summary>
        private int screenX;
        /// <summary>
        /// 显示器Y
        /// </summary>
        private int screenY;
        /// <summary>
        /// 显示器宽
        /// </summary>
        private int screenWidth;
        /// <summary>
        /// 显示器高
        /// </summary>
        private int screenHeight;
        /// <summary>
        /// 视频缩放比例
        /// </summary>
        private int scaling;
        /// <summary>
        /// 视频X
        /// </summary>
        private int videoX;
        /// <summary>
        /// 视频Y
        /// </summary>
        private int videoY;
        /// <summary>
        /// 视频宽
        /// </summary>
        private int videoWidth;
        /// <summary>
        /// 视频高
        /// </summary>
        private int videoHeight;
        /// <summary>
        /// 显示光标
        /// </summary>
        private bool isDisplayCursor;
        /// <summary>
        /// 每秒帧数
        /// </summary>
        private int videoFrame;
        /// <summary>
        /// 视频质量
        /// </summary>
        private int videoQuality;

        /* 其他参数 */
        // IP地址列表
        private List<Tuple<string, string>> ipList;
        // 屏幕信息列表
        private Screen[] screenList;
        private int screenW;
        private int screenH;
        // 服务器
        private readonly HttpListener server = new HttpListener();
        // 图标
        private readonly MemoryStream faviconStream = new MemoryStream();
        // 图片
        private readonly MemoryStream imageStream = new MemoryStream();
        // 返回结果
        private byte[] responseData;

        /// <summary>
        /// 启动
        /// </summary>
        public ScreenShare()
        {
            InitializeComponent();
            Init();
            // 读取图标
            Resources.favicon.Save(faviconStream);
            screenW = screenList[0].Bounds.Width;
            screenH = screenList[0].Bounds.Height;
            screenWNud.Value = videoWNud.Value = screenWNud.Maximum = screenW;
            screenHNud.Value = videoHNud.Value = screenHNud.Maximum = screenH;
            Log("屏幕共享初始化完成！");
        }

        /// <summary>
        /// 初始化
        /// </summary>
        private void Init()
        {
            // 获取IP地址
            ipList = GetAllIPv4Addresses();
            foreach (var ip in ipList)
            {
                ipAddressComboBox.Items.Add(ip.Item2 + " - " + ip.Item1);
            }
            ipAddressComboBox.SelectedIndex = 0;
            // 获取屏幕信息
            screenList = Screen.AllScreens;
            foreach(var screen in screenList)
            {
                screenComboBox.Items.Add(screen.DeviceName.Remove(0,11) + " [" + screen.Bounds.Width + "x" + screen.Bounds.Height + "]");
            }
            screenComboBox.SelectedIndex = 0;
        }

        /// <summary>
        /// 点击开始共享按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StartSharingScreenBtn_Click(object sender, EventArgs e)
        {
            if (isWorking)
            {
                isWorking = false;
                Log("屏幕共享已停止。");
                startSharingScreenBtn.Text = "开始共享";
            }
            else
            {
                isWorking = true;
                Log("屏幕共享已开启。");
                startSharingScreenBtn.Text = "停止共享";
            }
            StartServerTask();
            CaptureScreenTask();
        }

        /// <summary>
        /// 开启服务
        /// </summary>
        private async void StartServerTask()
        {
            string ipAddress = ipList.ElementAt(ipAddressComboBox.SelectedIndex).Item2;
            int ipPort = (int)ipPortNud.Value;
            bool isEncryption = isEncryptionCb.Checked;
            string encryptionAccount = accountText.Text;
            string encryptionPwd = pwdText.Text;
            int videoFrame = (int)videoFrameNud.Value;
            string html = Resources.Html1 + (1000 / videoFrame) + Resources.Html2;
            server.Prefixes.Clear();
            server.Prefixes.Add("http://" + ipAddress + ":" + ipPort + "/");
            server.Start();
            while (isWorking)
            {
                HttpListenerContext ctx = await server.GetContextAsync();
                if (isEncryption)
                {
                    if (!ctx.Request.Headers.AllKeys.Contains("Authorization"))
                    {
                        ctx.Response.StatusCode = 401;
                        ctx.Response.AddHeader("WWW-Authenticate", "Basic realm=ScreenShare Authentication : ");
                        ctx.Response.Close();
                        continue;
                    }
                    else
                    {
                        string auth1 = ctx.Request.Headers["Authorization"];
                        auth1 = auth1.Remove(0, 6); // Remove "Basic " From The Header Value
                        auth1 = Encoding.UTF8.GetString(Convert.FromBase64String(auth1));
                        string auth2 = encryptionAccount + ":" + encryptionPwd;
                        if (auth1 != auth2)
                        {
                            responseData = Encoding.UTF8.GetBytes("<h1 style=\"color:red\">Not Authorized !!!");
                            ctx.Response.ContentType = "text/html";
                            ctx.Response.StatusCode = 401;
                            ctx.Response.AddHeader("WWW-Authenticate", "Basic realm=ScreenShare Authentication : ");
                            try
                            {
                                await ctx.Response.OutputStream.WriteAsync(responseData, 0, responseData.Length);
                            }
                            catch (Exception)
                            {
                            }
                            ctx.Response.Close();
                            continue;
                        }
                    }
                }
                ctx.Response.StatusCode = 200;
                string localPath = ctx.Request.Url.LocalPath;
                if (localPath == "/")
                {
                    ctx.Response.ContentType = "text/html;charset=UTF-8";
                    responseData = Encoding.UTF8.GetBytes(html);
                }
                else if (localPath == "/image")
                {
                    ctx.Response.ContentType = "image/jpeg";
                    responseData = imageStream.ToArray();
                }
                else if (localPath == "/favicon.ico")
                {
                    ctx.Response.ContentType = "image/x-icon";
                    responseData = faviconStream.ToArray();
                }
                try
                {
                    await ctx.Response.OutputStream.WriteAsync(responseData, 0, responseData.Length);
                }
                catch (Exception)
                {
                }
                ctx.Response.Close();
            }
        }

        /// <summary>
        /// 开启屏幕捕获
        /// </summary>
        private async void CaptureScreenTask()
        {
            int screenX = (int)screenXNud.Value;
            int screenY = (int)screenYNud.Value;
            int screenW = (int)screenWNud.Value;
            int screenH = (int)screenHNud.Value;
            int videoW = (int)videoWNud.Value;
            int videoH = (int)videoHNud.Value;
            int videoQuality = (int)videoQualityNud.Value;
            int videoFrame = (int)videoFrameNud.Value;
            bool isDisplayCursor = isDisplayCursorCb.Checked;
            Rectangle screen = new Rectangle(screenX, screenY, screenW, screenH);
            Size video = new Size(videoW, videoH);
            if (screen.Size == video && videoQuality == 100)//正常
            {
                while (isWorking)
                {
                    imageStream.SetLength(0);
                    ImageUtil.CaptureScreenArea(screen, isDisplayCursor).Save(imageStream, ImageFormat.Jpeg);
                    previewImg.Image = new Bitmap(imageStream);
                    await Task.Delay(1000 / videoFrame);
                }
            }
            else if (screen.Size != video && videoQuality == 100)//缩放
            {
                while (isWorking)
                {
                    ImageUtil.ZoomImage(ImageUtil.CaptureScreenArea(screen, isDisplayCursor), video, 0).Save(imageStream, ImageFormat.Jpeg);
                    await Task.Delay(1000 / videoFrame);
                }
            }
            else if (screen.Size == video && videoQuality != 100)//压缩
            {
                while (isWorking)
                {
                    imageStream.SetLength(0);
                    ImageUtil.QualitySave(ImageUtil.CaptureScreenArea(screen, isDisplayCursor), videoQuality, imageStream);
                    previewImg.Image = new Bitmap(imageStream);
                    await Task.Delay(1000 / videoFrame);
                }
            }
            else//缩放+压缩
            {
                while (isWorking)
                {
                    imageStream.SetLength(0);
                    ImageUtil.QualitySave(ImageUtil.ZoomImage(ImageUtil.CaptureScreenArea(screen, isDisplayCursor), video, 0), videoQuality, imageStream);
                    previewImg.Image = new Bitmap(imageStream);
                    await Task.Delay(1000 / videoFrame);
                }
            }
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
            Clipboard.SetText(shareLinkText.Text);
            Log("分享链接已复制。");
        }

        /// <summary>
        /// 点击选取屏幕坐标按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CaptureScreenCoordinatesBtn_Click(object sender, EventArgs e)
        {
            DrawScreen drawScreen = new DrawScreen();
            if (drawScreen.ShowDialog() == DialogResult.OK)
            {
                Rectangle rect = drawScreen.ResultRect;
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
        /// 是否开启密码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void IsEncryptionCb_CheckStateChanged(object sender, EventArgs e)
        {
            accountText.Enabled = pwdText.Enabled = ((CheckBox)sender).Checked;
        }

        /// <summary>
        /// 是否全屏
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void IsFullScreenCb_CheckStateChanged(object sender, EventArgs e)
        {
            bool isChecked = ((CheckBox)sender).Checked;
            screenXNud.Enabled = screenYNud.Enabled = screenWNud.Enabled = screenHNud.Enabled = !isChecked;
            if (isChecked)
            {
                screenXNud.Value = screenYNud.Value = 0;
                screenWNud.Value = screenW;
                screenHNud.Value = screenH;
            }
        }

        /// <summary>
        ///  截图的宽发生改变
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ScreenWNud_ValueChanged(object sender, EventArgs e)
        {
            videoWNud.Value = screenWNud.Value * scalingNud.Value / 100;
        }

        /// <summary>
        /// 截图的高发生改变
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ScreenHNud_ValueChanged(object sender, EventArgs e)
        {
            videoHNud.Value = screenHNud.Value * scalingNud.Value / 100;
        }

        /// <summary>
        /// 视频缩放比例发生改变
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ScalingNud_ValueChanged(object sender, EventArgs e)
        {
            videoWNud.Value = screenWNud.Value * scalingNud.Value / 100;
            videoHNud.Value = screenHNud.Value * scalingNud.Value / 100;
        }

        /// <summary>
        /// 是否锁定纵横比
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
        /// 写日志
        /// </summary>
        /// <param name="text"></param>
        private void Log(string text)
        {
            logText.Text += DateTime.Now.ToLongTimeString() + " : " + text + "\r\n";
            logText.SelectionStart = logText.Text.Length;
            logText.ScrollToCaret();
        }

        /// <summary>
        /// IP端口号改变
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void IpPortNud_ValueChanged(object sender, EventArgs e)
        {
            shareLinkText.Text = "http://" + ipList.ElementAt(ipAddressComboBox.SelectedIndex).Item2 + ":" + ipPortNud.Value;
        }

        /// <summary>
        /// IP地址改变
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void IpAddressComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            shareLinkText.Text = "http://" + ipList.ElementAt(ipAddressComboBox.SelectedIndex).Item2 + ":" + ipPortNud.Value;
        }

        /// <summary>
        /// 点击图片，全窗口展示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PreviewImg_Click(object sender, EventArgs e)
        {
            if (previewImg.Dock == DockStyle.None)
            {
                previewImg.Dock = DockStyle.Fill;
            }
            else
            {
                previewImg.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            }
        }

        /// <summary>
        /// 获取所有的IP地址
        /// </summary>
        /// <returns>List&lt;Tuple&lt;名称, IP地址&gt;&gt;</returns>
        public static List<Tuple<string, string>> GetAllIPv4Addresses()
        {
            List<Tuple<string, string>> ipList = new List<Tuple<string, string>>();
            foreach (var ni in NetworkInterface.GetAllNetworkInterfaces())
            {
                foreach (var ua in ni.GetIPProperties().UnicastAddresses)
                {
                    if (ua.Address.AddressFamily == AddressFamily.InterNetwork)
                    {
                        ipList.Add(Tuple.Create(ni.Name, ua.Address.ToString()));
                    }
                }
            }
            return ipList;
        }

    }
}
