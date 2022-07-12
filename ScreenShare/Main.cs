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
        /********** 初始化参数 **********/
        /// <summary>
        /// 已启动
        /// </summary>
        private bool isWorking = false;
        /// <summary>
        /// 分享地址
        /// </summary>
        private string shareLink;
        /// <summary>
        /// 开启加密
        /// </summary>
        private bool isEncryption;
        /// <summary>
        /// 账号
        /// </summary>
        private string account;
        /// <summary>
        /// 密码
        /// </summary>
        private string pwd;
        /// <summary>
        /// 显示器
        /// </summary>
        private Rectangle screen;
        /// <summary>
        /// 视频缩放比例
        /// </summary>
        private int scaling;
        /// <summary>
        /// 视频
        /// </summary>
        private Size video;
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

        /********** 其他参数 **********/
        /// <summary>
        /// IP地址列表
        /// </summary>
        private List<Tuple<string, string>> ipList;
        /// <summary>
        /// 屏幕信息列表
        /// </summary>
        private List<Tuple<string, Rectangle>> screenList;
        /// <summary>
        /// 服务器
        /// </summary>
        private readonly HttpListener server = new HttpListener();
        /// <summary>
        /// 图标
        /// </summary>
        private readonly MemoryStream faviconStream = new MemoryStream();
        /// <summary>
        /// 图片
        /// </summary>
        private readonly MemoryStream imageStream = new MemoryStream();
        /// <summary>
        /// 返回结果
        /// </summary>
        private byte[] responseData;

        /********** 主方法 **********/
        /// <summary>
        /// 启动
        /// </summary>
        public ScreenShare()
        {
            InitializeComponent();
            // 初始化
            Init();
            // 读取图标
            Resources.favicon.Save(faviconStream);
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
            ipList = GetAllIPv4Address();
            ipAddressComboBox.Items.Clear();
            foreach (var ip in ipList)
            {
                ipAddressComboBox.Items.Add(ip.Item2 + " - " + ip.Item1);
            }
            ipAddressComboBox.SelectedIndex = 0;
            // 端口号
            ipPortNud.Value = 7070;
            // 分享地址
            shareLinkText.Text = "http://" + ipList.ElementAt(ipAddressComboBox.SelectedIndex).Item2 + ":" + (int)ipPortNud.Value + "/";

            /* 加密传输 */
            // 开启加密
            isEncryptionCb.Checked = false;
            // 账号
            accountText.Text = "";
            // 密码
            pwdText.Text = "";

            /* 选取位置 */
            // 全屏
            isFullScreenCb.Checked = true;
            // 显示器
            screenList = GetAllScreen();
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
            Rectangle currentScreen = screenList.ElementAt(screenComboBox.SelectedIndex).Item2;
            // X
            screenXNud.Value = currentScreen.X;
            // Y
            screenYNud.Value = currentScreen.Y;
            // 宽
            screenWNud.Value = currentScreen.Width;
            // 高
            screenHNud.Value = currentScreen.Height;

            /* 视频尺寸 */
            // 锁定缩放比
            isLockAspectRatioCb.Checked = true;
            // 缩放比例
            scalingNud.Value = 100;
            // 宽
            videoWNud.Value = currentScreen.Width;
            // 高
            videoHNud.Value = currentScreen.Height;

            /* 视频设置 */
            // 显示光标
            isDisplayCursorCb.Checked = true;
            // 每秒帧数
            videoFrameNud.Value = 5;
            // 视频质量
            videoQualityNud.Value = 100;
        }

        /// <summary>
        /// 加载配置
        /// </summary>
        private void LoadConfig()
        {
            shareLink = shareLinkText.Text;
            isEncryption = isEncryptionCb.Checked;
            account = accountText.Text;
            pwd = pwdText.Text;
            screen = new Rectangle((int)screenXNud.Value, (int)screenYNud.Value, (int)screenWNud.Value, (int)screenHNud.Value);
            scaling = (int)scalingNud.Value;
            video = new Size((int)videoWNud.Value, (int)videoHNud.Value);
            isDisplayCursor = isDisplayCursorCb.Checked;
            videoFrame = (int)videoFrameNud.Value;
            videoQuality = (int)videoQualityNud.Value;
        }

        /// <summary>
        /// 开启HTTP服务
        /// </summary>
        private async void StartServerTask()
        {
            // 加载配置
            LoadConfig();
            // 构造网页
            string html = Resources.Html1 + (1000 / videoFrame) + Resources.Html2;
            server.Prefixes.Clear();
            server.Prefixes.Add(shareLink);
            server.Start();
            while (isWorking)
            {
                HttpListenerContext ctx = await server.GetContextAsync();
                // 开启加密
                if (isEncryption)
                {
                    // 判断请求头是否输入账号密码
                    if (!ctx.Request.Headers.AllKeys.Contains("Authorization"))
                    {
                        // 没有输入账号密码
                        ctx.Response.StatusCode = 401;
                        ctx.Response.AddHeader("WWW-Authenticate", "Basic realm=ScreenShare Authentication : ");
                        ctx.Response.Close();
                        continue;
                    }
                    else
                    {
                        // 已输入账号密码
                        // 获取到输入的账号密码
                        string auth1 = ctx.Request.Headers["Authorization"];
                        // 移除头部"Basic "字符串
                        auth1 = auth1.Remove(0, 6);
                        // 解码账号密码
                        auth1 = Encoding.UTF8.GetString(Convert.FromBase64String(auth1));
                        string auth2 = account + ":" + pwd;
                        // 账号密码错误
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
                // 请求成功
                ctx.Response.StatusCode = 200;
                // 获取请求地址
                string localPath = ctx.Request.Url.LocalPath;
                // 判断请求地址
                if (localPath == "/favicon.ico")
                {
                    // 图标
                    ctx.Response.ContentType = "image/x-icon";
                    responseData = faviconStream.ToArray();
                }
                else if (localPath == "/image")
                {
                    // 图片
                    ctx.Response.ContentType = "image/jpeg";
                    responseData = imageStream.ToArray();
                }
                else
                {
                    // 网页
                    ctx.Response.ContentType = "text/html;charset=UTF-8";
                    responseData = Encoding.UTF8.GetBytes(html);
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
            // 判断捕获图片属性
            if (screen.Size == video && videoQuality == 100)
            {
                // 正常
                while (isWorking)
                {
                    imageStream.SetLength(0);
                    CaptureScreenArea(screen, isDisplayCursor).Save(imageStream, ImageFormat.Jpeg);
                    previewImg.Image = new Bitmap(imageStream);
                    await Task.Delay(1000 / videoFrame);
                }
            }
            else if (screen.Size != video && videoQuality == 100)
            {
                // 缩放
                while (isWorking)
                {
                    imageStream.SetLength(0);
                    ZoomImage(CaptureScreenArea(screen, isDisplayCursor), video, scaling).Save(imageStream, ImageFormat.Jpeg);
                    previewImg.Image = new Bitmap(imageStream);
                    await Task.Delay(1000 / videoFrame);
                }
            }
            else if (screen.Size == video && videoQuality != 100)
            {
                // 压缩
                while (isWorking)
                {
                    imageStream.SetLength(0);
                    QualitySave(CaptureScreenArea(screen, isDisplayCursor), videoQuality, imageStream);
                    previewImg.Image = new Bitmap(imageStream);
                    await Task.Delay(1000 / videoFrame);
                }
            }
            else
            {
                // 缩放+压缩
                while (isWorking)
                {
                    imageStream.SetLength(0);
                    QualitySave(ZoomImage(CaptureScreenArea(screen, isDisplayCursor), video, scaling), videoQuality, imageStream);
                    previewImg.Image = new Bitmap(imageStream);
                    await Task.Delay(1000 / videoFrame);
                }
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
                screenWNud.Value = screen.Width;
                screenHNud.Value = screen.Height;
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
        /// 显示器改变
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ScreenComboBox_SelectedValueChanged(object sender, EventArgs e)
        {

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
        /// 重新加载配置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ReloadConfigBtn_Click(object sender, EventArgs e)
        {
            Init();
        }

        /// <summary>
        /// 用浏览器打开
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OpenBtn_Click(object sender, EventArgs e)
        {

        }

        /********** 图像工具类 **********/
        /// <summary>
        /// jpg图片的ImageCodecInfo
        /// </summary>
        private static readonly ImageCodecInfo jpgEncoder = GetEncoder(ImageFormat.Jpeg);

        /// <summary>
        /// 捕获指定区域屏幕截图
        /// </summary>
        /// <param name="r">矩形</param>
        /// <param name="captureCursor">捕获光标</param>
        /// <returns>Bitmap</returns>
        private static Bitmap CaptureScreenArea(Rectangle r, bool captureCursor)
        {
            try
            {
                Bitmap bitmap = new Bitmap(r.Width, r.Height);
                Graphics g = Graphics.FromImage(bitmap);
                g.CopyFromScreen(r.X, r.Y, 0, 0, r.Size, CopyPixelOperation.SourceCopy);
                if (captureCursor)
                {
                    Point p = Control.MousePosition;
                    g.DrawImage(Resources.cursor, new Point(p.X - r.X, p.Y - r.Y));
                    g.Dispose();
                    g = null;
                }
                return bitmap;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// 缩放图片
        /// <para>scale大于0时，size无效</para>
        /// <para>sourceBitmap会被释放掉</para>
        /// </summary>
        /// <param name="sourceBitmap">源图片bitmap</param>
        /// <param name="size">指定目的图片的尺寸</param>
        /// <param name="scale">指定目的图片相对于原图片的缩放比例(大于0，原尺寸数值为100)</param>
        /// <returns>Bitmap</returns>
        private static Bitmap ZoomImage(Bitmap sourceBitmap, Size size, int scale)
        {
            if (scale <= 0 || scale == 100)
            {
                return sourceBitmap;
            }
            try
            {
                if (scale > 0)
                {
                    size.Width = sourceBitmap.Width * scale / 100;
                    size.Height = sourceBitmap.Height * scale / 100;
                }
                Bitmap bitmap = new Bitmap(size.Width, size.Height);
                Graphics g = Graphics.FromImage(bitmap);
                g.DrawImage(sourceBitmap, new Rectangle(0, 0, size.Width, size.Height), 0, 0, sourceBitmap.Width, sourceBitmap.Height, GraphicsUnit.Pixel);
                g.Dispose();
                g = null;
                sourceBitmap.Dispose();
                sourceBitmap = null;
                return bitmap;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// 按质量保存图片到内存流
        /// <para>bitmap会被释放掉</para>
        /// </summary>
        /// <param name="bitmap">图片bitmap</param>
        /// <param name="quality">图片质量(0-100]</param>
        /// <param name="memoryStream">MemoryStream</param>
        private static void QualitySave(Bitmap bitmap, int quality, MemoryStream memoryStream)
        {
            if (quality < 0 || quality >= 100)
            {
                bitmap.Save(memoryStream, ImageFormat.Jpeg);
            }
            else
            {
                EncoderParameters encoderParameters = new EncoderParameters(1);
                encoderParameters.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, quality);
                bitmap.Save(memoryStream, jpgEncoder, encoderParameters);
            }
            bitmap.Dispose();
            bitmap = null;
        }

        /// <summary>
        /// 获取图片编码
        /// </summary>
        /// <param name="format">图片类型</param>
        /// <returns>ImageCodecInfo</returns>
        private static ImageCodecInfo GetEncoder(ImageFormat format)
        {
            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageDecoders();
            foreach (ImageCodecInfo codec in codecs)
            {
                if (codec.FormatID == format.Guid)
                {
                    return codec;
                }
            }
            return null;
        }

        /********** 工具类 **********/
        /// <summary>
        /// 获取所有的IP地址
        /// </summary>
        /// <returns>List&lt;Tuple&lt;名称, IP地址&gt;&gt;</returns>
        private static List<Tuple<string, string>> GetAllIPv4Address()
        {
            var ipList = new List<Tuple<string, string>>();
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

        /// <summary>
        /// 获取所有屏幕信息
        /// <para>当有1个屏幕时，返回1个Tuple</para>
        /// <para>当有n个屏幕时，
        /// 第一个(下标0)是全部屏幕的叠加态，
        /// 第二个(下标1)是主屏幕，
        /// 后面是其他屏幕，
        /// 总共返回n+1个Tuple
        /// </para>
        /// </summary>
        /// <returns>List&lt;Tuple&lt;名称, 屏幕Rectangle&gt;&gt;</returns>
        private static List<Tuple<string, Rectangle>> GetAllScreen()
        {
            var screenList = new List<Tuple<string, Rectangle>>();
            var screens = Screen.AllScreens;
            int screenLength = screens.Length;
            if (screenLength == 1)
            {
                screenList.Add(Tuple.Create(screens[0].DeviceName.Remove(0, 11) + "(主)", screens[0].Bounds));
            }
            else
            {
                for (int i = 0; i < screenLength; i++)
                {
                    if (screens[i].Primary)
                    {
                        screenList.Insert(0, Tuple.Create(screens[i].DeviceName.Remove(0, 11) + "(主)", screens[i].Bounds));
                    }
                    else
                    {
                        screenList.Add(Tuple.Create(screens[i].DeviceName.Remove(0, 11), screens[i].Bounds));
                    }
                }
                // 计算全部屏幕的叠加态
                int xMin = screenList.Min(t => t.Item2.Left);
                int yMin = screenList.Min(t => t.Item2.Top);
                int xMax = screenList.Max(t => t.Item2.Right);
                int yMax = screenList.Max(t => t.Item2.Bottom);
                screenList.Insert(0, Tuple.Create("0(全)", new Rectangle(xMin, yMin, xMax - xMin, yMax - yMin)));
            }
            return screenList;
        }

    }
}
