﻿using ScreenShare.Properties;
using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace ScreenShare
{
    public partial class About : Form
    {

        public About()
        {
            InitializeComponent();
            webBrowser.DocumentText = Resources.about;
        }

        /// <summary>
        /// 点击超链接时，用外部浏览器打开(链接不能带有target)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WebBrowser_Navigating(object sender, WebBrowserNavigatingEventArgs e)
        {
            // 屏蔽自己
            if (!e.Url.ToString().Equals("about:blank", StringComparison.InvariantCultureIgnoreCase))
            {
                e.Cancel = true;
                Process.Start(e.Url.ToString());
            }
        }

    }
}
