using ScreenShare.Model;
using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace ScreenShare
{

    /// <summary>
    /// 系统配置
    /// </summary>
    public partial class Config : Form
    {

        /// <summary>
        /// 构造函数
        /// </summary>
        public Config()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 开启窗口后
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Config_Load(object sender, EventArgs e)
        {
            autoLaunchCb.Checked = IniConfig.System.AutoLaunch;
            autoRunCb.Checked = IniConfig.System.AutoRun;
            openBlackCb.Checked = IniConfig.System.OpenBlack;
            if (IniConfig.System.OpenBlack)
            {
                IniConfig.System.OpenWhite = false;
            }
            else
            {
                openWhiteCb.Checked = IniConfig.System.OpenWhite;
            }
            programConfigText.Text = "IP地址 " + IniConfig.Program.IpAddress +
                "\r\n端口号 " + IniConfig.Program.IpPort +
                "\r\n开启密码验证 " + IniConfig.Program.IsEncryption +
                "\r\n密码 " + IniConfig.Program.Pwd +
                "\r\n全屏显示 " + IniConfig.Program.IsFullScreen +
                "\r\n显示器 " + IniConfig.Program.Screen +
                "\r\n显示器X " + IniConfig.Program.ScreenX +
                "\r\n显示器Y " + IniConfig.Program.ScreenY +
                "\r\n显示器宽 " + IniConfig.Program.ScreenW +
                "\r\n显示器高 " + IniConfig.Program.ScreenH +
                "\r\n锁定纵横比 " + IniConfig.Program.IsLockAspectRatio +
                "\r\n缩放比例 " + IniConfig.Program.Scaling +
                "\r\n视频宽 " + IniConfig.Program.VideoW +
                "\r\n视频高 " + IniConfig.Program.VideoH +
                "\r\n显示光标 " + IniConfig.Program.IsDisplayCursor +
                "\r\n每秒帧数 " + IniConfig.Program.VideoFrame +
                "\r\n视频质量 " + IniConfig.Program.VideoQuality;
        }

        /// <summary>
        /// 点击打开配置按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OpenConfigBtn_Click(object sender, EventArgs e)
        {
            Process.Start("explorer.exe", Constant.INI_DIRECTORY);
        }

        /// <summary>
        /// 点击保存配置按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveConfigBtn_Click(object sender, EventArgs e)
        {
            IniConfig.System.AutoLaunch = autoLaunchCb.Checked;
            IniConfig.System.AutoRun = autoRunCb.Checked;
            IniConfig.System.OpenBlack = openBlackCb.Checked;
            IniConfig.System.OpenWhite = openWhiteCb.Checked;
            FormManager.Main.SaveIni();
        }

        /// <summary>
        /// 开启黑名单CheckBox状态改变
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OpenBlackCb_CheckStateChanged(object sender, EventArgs e)
        {
            bool isChecked = ((CheckBox)sender).Checked;
            if (isChecked && openWhiteCb.Checked)
            {
                openWhiteCb.Checked = false;
            }
        }

        /// <summary>
        /// 开启白名单CheckBox状态改变
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OpenWhiteCb_CheckStateChanged(object sender, EventArgs e)
        {
            bool isChecked = ((CheckBox)sender).Checked;
            if (isChecked && openBlackCb.Checked)
            {
                openBlackCb.Checked = false;
            }
        }

    }
}
