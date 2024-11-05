using ScreenShare.Model;
using ScreenShare.Util;
using System;
using System.Collections.Generic;
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
        /// 配置已被修改
        /// </summary>
        private static bool isChanged = false;

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
            string black = "";
            foreach (var item in IniConfig.BlackList)
            {
                black += item + "\r\n";
            }
            blackText.Text = black;
            string write = "";
            foreach (var item in IniConfig.WhiteList)
            {
                write += item + "\r\n";
            }
            whiteText.Text = write;
            isChanged = false;
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
            bool ok = true;
            if (!StatusManager.IniOk)
            {
                ok = MessageBox.Show("配置文件在启动时加载错误，确定覆盖吗？", "警告", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes;
            }
            if (ok)
            {
                if (SaveConfig())
                {
                    isChanged = false;
                }
            }
        }

        /// <summary>
        /// 保存配置
        /// </summary>
        /// <returns></returns>
        private bool SaveConfig()
        {
            string[] blackSplit = blackText.Text.Split('\r', '\n');
            List<string> blackList = new List<string>();
            foreach (var split in blackSplit)
            {
                if (split.Trim().Length > 0)
                {
                    string format = Main.ItemCorrectAndFormat(split);
                    if (format != null)
                    {
                        blackList.Add(format);
                    }
                    else
                    {
                        Utils.ShowError("黑名单存在非法值 " + split);
                        return false;
                    }
                }
            }
            string[] whiteSplit = whiteText.Text.Split('\r', '\n');
            List<string> whiteList = new List<string>();
            foreach (var split in whiteSplit)
            {
                if (split.Trim().Length > 0)
                {
                    string format = Main.ItemCorrectAndFormat(split);
                    if (format != null)
                    {
                        whiteList.Add(format);
                    }
                    else
                    {
                        Utils.ShowError("白名单存在非法值 " + split);
                        return false;
                    }
                }
            }
            StatusManager.IniOk = true;
            IniConfig.System.AutoLaunch = autoLaunchCb.Checked;
            IniConfig.System.AutoRun = autoRunCb.Checked;
            IniConfig.System.OpenBlack = openBlackCb.Checked;
            IniConfig.System.OpenWhite = openWhiteCb.Checked;
            IniConfig.BlackList = blackList;
            IniConfig.WhiteList = whiteList;
            FormManager.Main.SaveIni();
            return true;
        }

        /// <summary>
        /// 开机自启CheckBox状态改变
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AutoLaunchCb_CheckStateChanged(object sender, EventArgs e)
        {
            isChanged = true;
        }

        /// <summary>
        /// 自动运行CheckBox状态改变
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AutoRunCb_CheckStateChanged(object sender, EventArgs e)
        {
            isChanged = true;
        }

        /// <summary>
        /// 开启黑名单CheckBox状态改变
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OpenBlackCb_CheckStateChanged(object sender, EventArgs e)
        {
            isChanged = true;
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
            isChanged = true;
            bool isChecked = ((CheckBox)sender).Checked;
            if (isChecked && openBlackCb.Checked)
            {
                openBlackCb.Checked = false;
            }
        }

        /// <summary>
        /// 开启黑名单TextBox文本改变
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BlackText_TextChanged(object sender, EventArgs e)
        {
            isChanged = true;
        }

        /// <summary>
        /// 开启白名单TextBox文本改变
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WhiteText_TextChanged(object sender, EventArgs e)
        {
            isChanged = true;
        }

        /// <summary>
        /// 点击关闭按钮前
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Config_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (isChanged)
            {
                if (MessageBox.Show("配置文件还未保存，是否保存？", "建议", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (!SaveConfig())
                    {
                        e.Cancel = true;
                    }
                }
            }
        }

    }
}
