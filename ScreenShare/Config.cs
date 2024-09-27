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
        /// 点击重置配置按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ResetConfigBtn_Click(object sender, EventArgs e)
        {

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

        }

    }
}
