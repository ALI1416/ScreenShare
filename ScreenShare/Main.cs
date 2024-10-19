using ScreenShare.Properties;
using ScreenShare.Model;
using ScreenShare.Util;
using ScreenShare.ScheduledTask;
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Collections.Specialized;
using ScreenShare.Service;
using IniParser;
using IniParser.Model;
using System.Drawing.Imaging;
using System.Web;

namespace ScreenShare
{

    /// <summary>
    /// 主界面
    /// </summary>
    public partial class Main : Form
    {

        #region 公共方法

        /// <summary>
        /// 主程序
        /// </summary>
        public Main()
        {
            InitializeComponent();
            // 日志
            Log("欢迎使用屏幕共享软件！");
            Log("当前版本 " + Constant.VERSION_NUMBER);
            Log("帮助与反馈 https://github.com/ALI1416/ScreenShare");
            // 初始化
            InitSystem();
            InitIni();
            InitForm();
            // 图标
            MemoryStream stream = new MemoryStream();
            Resources.favicon.Save(stream);
            httpIconHeaderBytes = HttpService.GetBytes(HttpService.icoHeaderBytes, stream);
            // FPS
            fpsLabel.Parent = previewImg;
            // 右键菜单
            ToolStripMenuItem reload = new ToolStripMenuItem("重新加载预览图(&R)");
            reload.Click += (sender, e) => UpdatePreviewImgWithCaptureScreen();
            ToolStripMenuItem save = new ToolStripMenuItem("保存图片到本地(&S)");
            save.Click += (sender, e) => SavePreviewImg();
            previewImgCms.Items.Add(reload);
            previewImgCms.Items.Add(save);
            Log("初始化完成！");
        }

        /// <summary>
        /// 第一次加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Main_Shown(object sender, EventArgs e)
        {
            if (IniConfig.System.AutoRun)
            {
                Start();
                Close();
            }
        }

        /// <summary>
        /// 初始化系统
        /// </summary>
        public void InitSystem()
        {
            // IP地址
            StatusManager.IpList = Utils.GetAllIPv4Address();
            ipAddressComboBox.Items.Clear();
            foreach (var ip in StatusManager.IpList)
            {
                ipAddressComboBox.Items.Add(ip.Item2 + " - " + ip.Item1);
            }
            ipAddressComboBox.SelectedIndex = 0;
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
        }

        /// <summary>
        /// 初始化INI配置
        /// </summary>
        public void InitIni()
        {
            SetDefaultIni();
            if (File.Exists(Constant.INI_PATH))
            {
                // 存在去读取
                try
                {
                    LoadIni();
                    Log("配置文件加载完成！");
                }
                catch (Exception e)
                {
                    StatusManager.IniOk = false;
                    Utils.ShowError("配置文件加载错误！");
                    Log("配置文件加载错误！\r\n路径：" + Constant.INI_PATH + "\r\n\r\n错误原因：\r\n" + e.Message);
                }
            }
            else
            {
                // 不存在去创建
                CreateIni();
                Log("配置文件不存在，已创建默认配置。");
            }
        }

        /// <summary>
        /// 加载INI配置
        /// </summary>
        public void LoadIni()
        {
            string error = "";
            FileIniDataParser parser = new FileIniDataParser();
            IniData iniData = parser.ReadFile(Constant.INI_PATH);
            /* 系统 */
            KeyDataCollection system = iniData["System"];
            /* 开机自启 */
            string autoLaunch = system["AutoLaunch"];
            if (autoLaunch != null)
            {
                try
                {
                    IniConfig.System.AutoLaunch = bool.Parse(autoLaunch);
                }
                catch (Exception e)
                {
                    error += "开机自启 [System] AutoLaunch = " + autoLaunch + " " + e.Message + "\r\n";
                }
            }
            /* 自动运行 */
            string autoRun = system["AutoRun"];
            if (autoRun != null)
            {
                try
                {
                    IniConfig.System.AutoRun = bool.Parse(autoRun);
                }
                catch (Exception e)
                {
                    error += "自动运行 [System] AutoRun = " + autoRun + " " + e.Message + "\r\n";
                }
            }
            /* 开启黑名单 */
            string openBlack = system["OpenBlack"];
            if (openBlack != null)
            {
                try
                {
                    IniConfig.System.OpenBlack = bool.Parse(openBlack);
                }
                catch (Exception e)
                {
                    error += "开启黑名单 [System] OpenBlack = " + openBlack + " " + e.Message + "\r\n";
                }
            }
            /* 开启白名单 */
            string openWhite = system["OpenWhite"];
            if (openWhite != null)
            {
                try
                {
                    IniConfig.System.OpenWhite = bool.Parse(openWhite);
                }
                catch (Exception e)
                {
                    error += "开启白名单 [System] OpenWhite = " + openWhite + " " + e.Message + "\r\n";
                }
            }
            /* 程序 */
            KeyDataCollection program = iniData["Program"];
            /* IP地址 */
            string ipAddress = program["IpAddress"];
            if (ipAddress != null)
            {
                int index = ipAddressComboBox.Items.IndexOf(ipAddress);
                // 找到
                if (index >= 0)
                {
                    ipAddressComboBox.SelectedIndex = index;
                }
            }
            /* 端口号 */
            string ipPort = program["IpPort"];
            if (ipPort != null)
            {
                try
                {
                    int ipPortParse = int.Parse(ipPort);
                    int ipPortMin = (int)ipPortNud.Minimum;
                    int ipPortMax = (int)ipPortNud.Maximum;
                    if (ipPortParse < ipPortMin || ipPortParse > ipPortMax)
                    {
                        error += "端口号 [Program] IpPort = " + ipPort + " 需要在[" + ipPortMin + "," + ipPortMax + "]范围内。\r\n";
                    }
                    else
                    {
                        IniConfig.Program.IpPort = ipPortParse;
                    }
                }
                catch (Exception e)
                {
                    error += "端口号 [Program] IpPort = " + ipPort + " " + e.Message + "\r\n";
                }
            }
            /* 开启密码验证 */
            string isEncryption = program["IsEncryption"];
            if (isEncryption != null)
            {
                try
                {
                    IniConfig.Program.IsEncryption = bool.Parse(isEncryption);
                }
                catch (Exception e)
                {
                    error += "开启密码验证 [Program] IsEncryption = " + isEncryption + " " + e.Message + "\r\n";
                }
            }
            /* 密码 */
            string pwd = program["Pwd"];
            if (pwd != null)
            {
                IniConfig.Program.Pwd = pwd;
            }
            /* 全屏显示 */
            string isFullScreen = program["IsFullScreen"];
            if (isFullScreen != null)
            {
                try
                {
                    IniConfig.Program.IsFullScreen = bool.Parse(isFullScreen);
                }
                catch (Exception e)
                {
                    error += "全屏显示 [Program] IsFullScreen = " + isFullScreen + " " + e.Message + "\r\n";
                }
            }
            /* 显示器 */
            bool screenFind = false;
            string screen = program["Screen"];
            if (screen != null)
            {
                int index = screenComboBox.Items.IndexOf(screen);
                // 找到
                if (index >= 0)
                {
                    screenComboBox.SelectedIndex = index;
                    screenFind = true;
                }
            }
            // 显示器
            var selectedScreen = StatusManager.ScreenList[screenComboBox.SelectedIndex].Item2;
            if (screenFind && !IniConfig.Program.IsFullScreen)
            {
                // 显示器匹配 并且 未启用全屏显示
                /* 显示器X */
                string screenX = program["ScreenX"];
                if (screenX != null)
                {
                    try
                    {
                        int screenXParse = int.Parse(screenX);
                        int screenXMin = selectedScreen.Left;
                        int screenXMax = selectedScreen.Right - 1;
                        if (screenXParse < screenXMin || screenXParse > screenXMax)
                        {
                            error += "显示器X [Program] ScreenX = " + screenX + " 需要在[" + screenXMin + "," + screenXMax + "]范围内。\r\n";
                            IniConfig.Program.ScreenX = selectedScreen.X;
                        }
                        else
                        {
                            IniConfig.Program.ScreenX = screenXParse;
                        }
                    }
                    catch (Exception e)
                    {
                        error += "显示器X [Program] ScreenX = " + screenX + " " + e.Message + "\r\n";
                    }
                }
                /* 显示器Y */
                string screenY = program["ScreenY"];
                if (screenY != null)
                {
                    try
                    {
                        int screenYParse = int.Parse(screenY);
                        int screenYMin = selectedScreen.Top;
                        int screenYMax = selectedScreen.Bottom - 1;
                        if (screenYParse < screenYMin || screenYParse > screenYMax)
                        {
                            error += "显示器Y [Program] ScreenY = " + screenY + " 需要在[" + screenYMin + "," + screenYMax + "]范围内。\r\n";
                            IniConfig.Program.ScreenY = selectedScreen.Y;
                        }
                        else
                        {
                            IniConfig.Program.ScreenY = screenYParse;
                        }
                    }
                    catch (Exception e)
                    {
                        error += "显示器Y [Program] ScreenY = " + screenY + " " + e.Message + "\r\n";
                    }
                }
                /* 显示器宽 */
                string screenW = program["ScreenW"];
                if (screenW != null)
                {
                    try
                    {
                        int screenWParse = int.Parse(screenW);
                        int screenWMin = (int)screenWNud.Minimum;
                        int screenWMax = selectedScreen.Width;
                        if (screenWParse < screenWMin || screenWParse > screenWMax)
                        {
                            error += "显示器宽 [Program] ScreenW = " + screenW + " 需要在[" + screenWMin + "," + screenWMax + "]范围内。\r\n";
                            IniConfig.Program.ScreenW = selectedScreen.Width;
                        }
                        else
                        {
                            IniConfig.Program.ScreenW = screenWParse;
                        }
                    }
                    catch (Exception e)
                    {
                        error += "显示器宽 [Program] ScreenW = " + screenW + " " + e.Message + "\r\n";
                    }
                }
                /* 显示器高 */
                string screenH = program["ScreenH"];
                if (screenH != null)
                {
                    try
                    {
                        int screenHParse = int.Parse(screenH);
                        int screenHMin = (int)screenHNud.Minimum;
                        int screenHMax = selectedScreen.Height;
                        if (screenHParse < screenHMin || screenHParse > screenHMax)
                        {
                            error += "显示器高 [Program] ScreenH = " + screenH + " 需要在[" + screenHMin + "," + screenHMax + "]范围内。\r\n";
                            IniConfig.Program.ScreenH = selectedScreen.Height;
                        }
                        else
                        {
                            IniConfig.Program.ScreenH = screenHParse;
                        }
                    }
                    catch (Exception e)
                    {
                        error += "显示器高 [Program] ScreenH = " + screenH + " " + e.Message + "\r\n";
                    }
                }
            }
            else
            {
                IniConfig.Program.ScreenX = selectedScreen.X;
                IniConfig.Program.ScreenY = selectedScreen.Y;
                IniConfig.Program.ScreenW = selectedScreen.Width;
                IniConfig.Program.ScreenH = selectedScreen.Height;
            }
            /* 锁定纵横比 */
            string isLockAspectRatio = program["IsLockAspectRatio"];
            if (isLockAspectRatio != null)
            {
                try
                {
                    IniConfig.Program.IsLockAspectRatio = bool.Parse(isLockAspectRatio);
                }
                catch (Exception e)
                {
                    error += "锁定纵横比 [Program] IsLockAspectRatio = " + isLockAspectRatio + " " + e.Message + "\r\n";
                }
            }
            if (screenFind && !IniConfig.Program.IsLockAspectRatio)
            {
                // 显示器匹配 并且 未锁定纵横比
                /* 视频宽 */
                string videoW = program["VideoW"];
                if (videoW != null)
                {
                    try
                    {
                        int videoWParse = int.Parse(videoW);
                        int videoWMin = (int)videoWNud.Minimum;
                        int videoWMax = selectedScreen.Width;
                        if (videoWParse < videoWMin || videoWParse > videoWMax)
                        {
                            error += "视频宽 [Program] VideoW = " + videoW + " 需要在[" + videoWMin + "," + videoWMax + "]范围内。\r\n";
                            IniConfig.Program.VideoW = selectedScreen.Width;
                        }
                        else
                        {
                            IniConfig.Program.VideoW = videoWParse;
                        }
                    }
                    catch (Exception e)
                    {
                        error += "视频宽 [Program] VideoW = " + videoW + " " + e.Message + "\r\n";
                    }
                }
                /* 视频高 */
                string videoH = program["VideoH"];
                if (videoH != null)
                {
                    try
                    {
                        int videoHParse = int.Parse(videoH);
                        int videoHMin = (int)videoHNud.Minimum;
                        int videoHMax = selectedScreen.Height;
                        if (videoHParse < videoHMin || videoHParse > videoHMax)
                        {
                            error += "视频高 [Program] VideoH = " + videoH + " 需要在[" + videoHMin + "," + videoHMax + "]范围内。\r\n";
                            IniConfig.Program.VideoH = selectedScreen.Height;
                        }
                        else
                        {
                            IniConfig.Program.VideoH = videoHParse;
                        }
                    }
                    catch (Exception e)
                    {
                        error += "视频高 [Program] VideoH = " + videoH + " " + e.Message + "\r\n";
                    }
                }
            }
            else
            {
                /* 缩放比例 */
                string scaling = program["Scaling"];
                if (scaling != null)
                {
                    try
                    {
                        int scalingParse = int.Parse(scaling);
                        int scalingMin = (int)scalingNud.Minimum;
                        int scalingMax = (int)scalingNud.Maximum;
                        if (scalingParse < scalingMin || scalingParse > scalingMax)
                        {
                            error += "缩放比例 [Program] Scaling = " + scaling + " 需要在[" + scalingMin + "," + scalingMax + "]范围内。\r\n";
                        }
                        else
                        {
                            IniConfig.Program.Scaling = scalingParse;
                        }
                    }
                    catch (Exception e)
                    {
                        error += "缩放比例 [Program] Scaling = " + scaling + " " + e.Message + "\r\n";
                    }
                }
                IniConfig.Program.VideoW = selectedScreen.Width;
                IniConfig.Program.VideoH = selectedScreen.Height;
            }
            /* 显示光标 */
            string isDisplayCursor = program["IsDisplayCursor"];
            if (isDisplayCursor != null)
            {
                try
                {
                    IniConfig.Program.IsDisplayCursor = bool.Parse(isDisplayCursor);
                }
                catch (Exception e)
                {
                    error += "显示光标 [Program] IsDisplayCursor = " + isDisplayCursor + " " + e.Message + "\r\n";
                }
            }
            /* 每秒帧数 */
            string videoFrame = program["VideoFrame"];
            if (videoFrame != null)
            {
                try
                {
                    int videoFrameParse = int.Parse(videoFrame);
                    int videoFrameMin = (int)videoFrameNud.Minimum;
                    int videoFrameMax = (int)videoFrameNud.Maximum;
                    if (videoFrameParse < videoFrameMin || videoFrameParse > videoFrameMax)
                    {
                        error += "每秒帧数 [Program] VideoFrame = " + videoFrame + " 需要在[" + videoFrameMin + "," + videoFrameMax + "]范围内。\r\n";
                    }
                    else
                    {
                        IniConfig.Program.VideoFrame = videoFrameParse;
                    }
                }
                catch (Exception e)
                {
                    error += "每秒帧数 [Program] VideoFrame = " + videoFrame + " " + e.Message + "\r\n";
                }
            }
            /* 视频质量 */
            string videoQuality = program["VideoQuality"];
            if (videoQuality != null)
            {
                try
                {
                    int videoQualityParse = int.Parse(videoQuality);
                    int videoQualityMin = (int)videoQualityNud.Minimum;
                    int videoQualityMax = (int)videoQualityNud.Maximum;
                    if (videoQualityParse < videoQualityMin || videoQualityParse > videoQualityMax)
                    {
                        error += "视频质量 [Program] VideoQuality = " + videoQuality + " 需要在[" + videoQualityMin + "," + videoQualityMax + "]范围内。\r\n";
                    }
                    else
                    {
                        IniConfig.Program.VideoQuality = videoQualityParse;
                    }
                }
                catch (Exception e)
                {
                    error += "视频质量 [Program] VideoQuality = " + videoQuality + " " + e.Message + "\r\n";
                }
            }
            /* 注册表 */
            if (IniConfig.System.AutoLaunch)
            {
                RegistryUtils.AutoLaunchOpen();
            }
            else
            {
                RegistryUtils.AutoLaunchClose();
            }
            if (error.Length != 0)
            {
                throw new Exception(error);
            }
        }

        /// <summary>
        /// 设置默认INI配置
        /// </summary>
        public void SetDefaultIni()
        {
            IniConfig.Program.IpAddress = (string)ipAddressComboBox.SelectedItem;
            IniConfig.Program.Screen = (string)screenComboBox.SelectedItem;
            var screen = StatusManager.ScreenList[screenComboBox.SelectedIndex];
            IniConfig.Program.ScreenX = screen.Item2.X;
            IniConfig.Program.ScreenY = screen.Item2.Y;
            IniConfig.Program.ScreenW = screen.Item2.Width;
            IniConfig.Program.ScreenH = screen.Item2.Height;
            IniConfig.Program.VideoW = screen.Item2.Width;
            IniConfig.Program.VideoH = screen.Item2.Height;
        }

        /// <summary>
        /// 创建INI配置
        /// </summary>
        public static void CreateIni()
        {
            SectionData system = new SectionData("System");
            system.Keys["AutoLaunch"] = IniConfig.System.AutoLaunch.ToString();
            system.Keys["AutoRun"] = IniConfig.System.AutoRun.ToString();
            system.Keys["OpenBlack"] = IniConfig.System.OpenBlack.ToString();
            system.Keys["OpenWhite"] = IniConfig.System.OpenWhite.ToString();
            SectionData program = new SectionData("Program");
            program.Keys["IpAddress"] = IniConfig.Program.IpAddress;
            program.Keys["IpPort"] = IniConfig.Program.IpPort.ToString();
            program.Keys["IsEncryption"] = IniConfig.Program.IsEncryption.ToString();
            program.Keys["Pwd"] = IniConfig.Program.Pwd;
            program.Keys["IsFullScreen"] = IniConfig.Program.IsFullScreen.ToString();
            program.Keys["Screen"] = IniConfig.Program.Screen;
            program.Keys["ScreenX"] = IniConfig.Program.ScreenX.ToString();
            program.Keys["ScreenY"] = IniConfig.Program.ScreenY.ToString();
            program.Keys["ScreenW"] = IniConfig.Program.ScreenW.ToString();
            program.Keys["ScreenH"] = IniConfig.Program.ScreenH.ToString();
            program.Keys["IsLockAspectRatio"] = IniConfig.Program.IsLockAspectRatio.ToString();
            program.Keys["Scaling"] = IniConfig.Program.Scaling.ToString();
            program.Keys["VideoW"] = IniConfig.Program.VideoW.ToString();
            program.Keys["VideoH"] = IniConfig.Program.VideoH.ToString();
            program.Keys["IsDisplayCursor"] = IniConfig.Program.IsDisplayCursor.ToString();
            program.Keys["VideoFrame"] = IniConfig.Program.VideoFrame.ToString();
            program.Keys["VideoQuality"] = IniConfig.Program.VideoQuality.ToString();
            SectionData blackList = new SectionData("BlackList");
            SectionData writeList = new SectionData("WriteList");
            SectionDataCollection sdc = new SectionDataCollection
            {
                system,
                program,
                blackList,
                writeList
            };
            IniData iniData = new IniData(sdc);
            Directory.CreateDirectory(Constant.INI_DIRECTORY);
            FileIniDataParser parser = new FileIniDataParser();
            parser.WriteFile(Constant.INI_PATH, iniData);
        }

        /// <summary>
        /// 保存INI配置
        /// </summary>
        public void SaveIni()
        {
            IniConfig.Program.IpAddress = (string)ipAddressComboBox.SelectedItem;
            IniConfig.Program.IpPort = (int)ipPortNud.Value;
            IniConfig.Program.IsEncryption = isEncryptionCb.Checked;
            IniConfig.Program.Pwd = pwdText.Text;
            IniConfig.Program.IsFullScreen = isFullScreenCb.Checked;
            IniConfig.Program.Screen = (string)screenComboBox.SelectedItem;
            IniConfig.Program.ScreenX = (int)screenXNud.Value;
            IniConfig.Program.ScreenY = (int)screenYNud.Value;
            IniConfig.Program.ScreenW = (int)screenWNud.Value;
            IniConfig.Program.ScreenH = (int)screenHNud.Value;
            IniConfig.Program.IsLockAspectRatio = isLockAspectRatioCb.Checked;
            IniConfig.Program.Scaling = (int)scalingNud.Value;
            IniConfig.Program.VideoW = (int)videoWNud.Value;
            IniConfig.Program.VideoH = (int)videoHNud.Value;
            IniConfig.Program.IsDisplayCursor = isDisplayCursorCb.Checked;
            IniConfig.Program.VideoFrame = (int)videoFrameNud.Value;
            IniConfig.Program.VideoQuality = (int)videoQualityNud.Value;
            CreateIni();
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
            if (!StatusManager.HttpService.Start(StatusManager.IpList[ipAddressComboBox.SelectedIndex].Item2, (int)ipPortNud.Value, HttpResponseCallback))
            {
                Log("http服务启动失败！请尝试更改IP地址或端口号。");
                Utils.ShowError("http服务启动失败！请尝试更改IP地址或端口号。");
                return;
            }
            // 启动webSocket服务
            if (StatusManager.WebSocketService == null)
            {
                StatusManager.WebSocketService = new WebSocketService();
            }
            if (!StatusManager.WebSocketService.Start(StatusManager.IpList[ipAddressComboBox.SelectedIndex].Item2, 0, WebSocketClientCallback))
            {
                StatusManager.HttpService.Close();
                Log("webSocket服务启动失败！请尝试重启程序或联系开发者。");
                Utils.ShowError("webSocket服务启动失败！请尝试重启程序或联系开发者。");
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
        public string GetShareLink()
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
        /// 初始化界面
        /// </summary>
        private void InitForm()
        {
            StatusManager.IsStarted = false;
            /* 头部 */
            // IP地址
            // 端口号
            ipPortNud.Value = IniConfig.Program.IpPort;
            // 分享地址
            shareLinkText.Text = "http://" + StatusManager.IpList[ipAddressComboBox.SelectedIndex].Item2 + ":" + ipPortNud.Value + "/";

            /* 加密传输 */
            // 开启加密
            isEncryptionCb.Checked = IniConfig.Program.IsEncryption;
            // 密码
            pwdText.Text = IniConfig.Program.Pwd;

            /* 选取位置 */
            // 全屏
            isFullScreenCb.Checked = IniConfig.Program.IsFullScreen;
            // 显示器
            Rectangle selectedScreen = StatusManager.ScreenList[screenComboBox.SelectedIndex].Item2;
            // X
            screenXNud.Minimum = selectedScreen.Left;
            screenXNud.Maximum = selectedScreen.Right - 1;
            screenXNud.Value = (int)IniConfig.Program.ScreenX;
            // Y
            screenYNud.Minimum = selectedScreen.Top;
            screenYNud.Maximum = selectedScreen.Bottom - 1;
            screenYNud.Value = (int)IniConfig.Program.ScreenY;
            // 宽
            screenWNud.Maximum = selectedScreen.Width;
            screenWNud.Value = (int)IniConfig.Program.ScreenW;
            // 高
            screenHNud.Maximum = selectedScreen.Height;
            screenHNud.Value = (int)IniConfig.Program.ScreenH;

            /* 视频尺寸 */
            // 锁定缩放比
            isLockAspectRatioCb.Checked = IniConfig.Program.IsLockAspectRatio;
            // 缩放比例
            scalingNud.Value = IniConfig.Program.Scaling;
            // 宽
            videoWNud.Maximum = selectedScreen.Width;
            videoWNud.Value = (int)IniConfig.Program.VideoW;
            // 高
            videoHNud.Maximum = selectedScreen.Height;
            videoHNud.Value = (int)IniConfig.Program.VideoH;

            /* 视频设置 */
            // 显示光标
            isDisplayCursorCb.Checked = IniConfig.Program.IsDisplayCursor;
            // 每秒帧数
            videoFrameNud.Value = IniConfig.Program.VideoFrame;
            // 视频质量
            videoQualityNud.Value = IniConfig.Program.VideoQuality;

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
        /// 保存预览图
        /// </summary>
        private void SavePreviewImg()
        {
            if (previewImg.Image != null)
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog
                {
                    InitialDirectory = Constant.PICTURE_DIRECTORY,
                    RestoreDirectory = true,
                    FileName = "预览图.png",
                    Filter = "PNG图片(*.png)|*.png"
                };
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string fileName = saveFileDialog.FileName;
                    previewImg.Image.Save(fileName, ImageFormat.Png);
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
                = configBtn.Enabled
                = captureScreenCoordinatesBtn.Enabled
                = !enable;
            if (enable)
            {
                startBtn.Text = "停止共享";
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
                startBtn.Text = "开始共享";
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
            shareLinkText.Text = "http://" + StatusManager.IpList[ipAddressComboBox.SelectedIndex].Item2 + ":" + ipPortNud.Value + "/";
        }

        /// <summary>
        /// IP端口号改变
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void IpPortNud_ValueChanged(object sender, EventArgs e)
        {
            shareLinkText.Text = "http://" + StatusManager.IpList[ipAddressComboBox.SelectedIndex].Item2 + ":" + ipPortNud.Value + "/";
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
                Utils.ShowError("复制失败！请手动复制。");
            }
        }

        /// <summary>
        /// 点击重新加载配置按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ReloadConfigBtn_Click(object sender, EventArgs e)
        {
            InitSystem();
            InitIni();
            InitForm();
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
                Rectangle selectedScreen = StatusManager.ScreenList[screenComboBox.SelectedIndex].Item2;
                screenXNud.Value = selectedScreen.X;
                screenYNud.Value = selectedScreen.Y;
                screenWNud.Value = selectedScreen.Width;
                screenHNud.Value = selectedScreen.Height;
                videoWNud.Value = selectedScreen.Width;
                videoHNud.Value = selectedScreen.Height;
            }
        }

        /// <summary>
        /// 显示器改变
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ScreenComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            Rectangle selectedScreen = StatusManager.ScreenList[screenComboBox.SelectedIndex].Item2;
            videoWNud.Maximum = selectedScreen.Width;
            videoWNud.Value = selectedScreen.Width;
            videoHNud.Maximum = selectedScreen.Height;
            videoHNud.Value = selectedScreen.Height;
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
            screenWNud.Maximum = StatusManager.ScreenList[screenComboBox.SelectedIndex].Item2.Right - screenXNud.Value;
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
            screenHNud.Maximum = StatusManager.ScreenList[screenComboBox.SelectedIndex].Item2.Bottom - screenYNud.Value;
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
            DrawScreen drawScreen = new DrawScreen(StatusManager.ScreenList[screenComboBox.SelectedIndex].Item2);
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
                    videoWNud.Value = rect.Width;
                    videoHNud.Value = rect.Height;
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
            if (((MouseEventArgs)e).Button == MouseButtons.Left)
            {
                // 左键
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
            else if (((MouseEventArgs)e).Button == MouseButtons.Right)
            {
                // 右键
                if (!StatusManager.IsStarted)
                {
                    previewImgCms.Show(previewImg, ((MouseEventArgs)e).Location);
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
        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (StatusManager.IsStarted)
            {
                // 如果正在运行：托盘
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
            else
            {
                // 保存配置
                if (StatusManager.IniOk)
                {
                    SaveIni();
                }
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
