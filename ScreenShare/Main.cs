using ScreenShare.Properties;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScreenShare
{
    public partial class ScreenShare : Form
    {
        public int realScreenW;
        public int realScreenH;
        private bool isWorking = false;
        private List<Tuple<string, string>> ips;
        private HttpListener server = new HttpListener();
        private MemoryStream imageStream = new MemoryStream();
        private MemoryStream ico16 = new MemoryStream();
        private byte[] responseData;

        /// <summary>
        /// 启动
        /// </summary>
        public ScreenShare()
        {
            InitializeComponent();
            ScreenRealSize.Init();
            Resources.Ico16.Save(ico16, ImageFormat.Png);
            Size screenRealSize = ScreenRealSize.DESKTOP;
            realScreenW = screenRealSize.Width;
            realScreenH = screenRealSize.Height;
            screenWNud.Value = videoWNud.Value = screenWNud.Maximum = realScreenW;
            screenHNud.Value = videoHNud.Value = screenHNud.Maximum = realScreenH;
            ips = Util.GetAllIPv4Addresses();
            foreach (var ip in ips)
            {
                ipAddressComboBox.Items.Add(ip.Item2 + " - " + ip.Item1);
            }
            ipAddressComboBox.SelectedIndex = ipAddressComboBox.Items.Count - 1;
            Log("屏幕共享初始化完成！");
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
            string ipAddress = ips.ElementAt(ipAddressComboBox.SelectedIndex).Item2;
            int ipPort = (int)ipPortNud.Value;
            bool isEncryption = isEncryptionCb.Checked;
            string encryptionAccount = encryptionAccountText.Text;
            string encryptionPwd = encryptionPwdText.Text;
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
                else
                {
                    ctx.Response.ContentType = "image/png";
                    responseData = ico16.ToArray();
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
                    Rectangle r = ScreenRealSize.ConvertRectangle(rect);
                    isFullScreenCb.Checked = false;
                    screenXNud.Value = r.X;
                    screenYNud.Value = r.Y;
                    screenWNud.Value = r.Width;
                    screenHNud.Value = r.Height;
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
            encryptionAccountText.Enabled = encryptionPwdText.Enabled = ((CheckBox)sender).Checked;
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
                screenWNud.Value = realScreenW;
                screenHNud.Value = realScreenH;
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
            shareLinkText.Text = "http://" + ips.ElementAt(ipAddressComboBox.SelectedIndex).Item2 + ":" + ipPortNud.Value;
        }

        /// <summary>
        /// IP地址改变
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void IpAddressComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            shareLinkText.Text = "http://" + ips.ElementAt(ipAddressComboBox.SelectedIndex).Item2 + ":" + ipPortNud.Value;
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
                previewImg.Dock = DockStyle.None;
                Size clientSize = ClientSize;
                Point previewImgLocation = previewImg.Location;
                previewImg.Size = new Size(clientSize.Width - previewImgLocation.X - 9, clientSize.Height - previewImgLocation.Y - 11);
                previewImg.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            }
        }
    }
}
