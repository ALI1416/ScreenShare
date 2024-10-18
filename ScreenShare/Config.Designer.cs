namespace ScreenShare
{
    partial class Config
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.systemConfigBox = new System.Windows.Forms.GroupBox();
            this.autoLaunchCb = new System.Windows.Forms.CheckBox();
            this.autoRunCb = new System.Windows.Forms.CheckBox();
            this.openConfigBtn = new System.Windows.Forms.Button();
            this.saveConfigBtn = new System.Windows.Forms.Button();
            this.programConfigBox = new System.Windows.Forms.GroupBox();
            this.programConfigText = new System.Windows.Forms.TextBox();
            this.ruleBox = new System.Windows.Forms.GroupBox();
            this.ruleText = new System.Windows.Forms.TextBox();
            this.blackBox = new System.Windows.Forms.GroupBox();
            this.openBlackCb = new System.Windows.Forms.CheckBox();
            this.blackText = new System.Windows.Forms.TextBox();
            this.whiteBox = new System.Windows.Forms.GroupBox();
            this.openWhiteCb = new System.Windows.Forms.CheckBox();
            this.whiteText = new System.Windows.Forms.TextBox();
            this.systemConfigBox.SuspendLayout();
            this.programConfigBox.SuspendLayout();
            this.ruleBox.SuspendLayout();
            this.blackBox.SuspendLayout();
            this.whiteBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // systemConfigBox
            // 
            this.systemConfigBox.Controls.Add(this.autoLaunchCb);
            this.systemConfigBox.Controls.Add(this.autoRunCb);
            this.systemConfigBox.Controls.Add(this.openConfigBtn);
            this.systemConfigBox.Controls.Add(this.saveConfigBtn);
            this.systemConfigBox.Location = new System.Drawing.Point(10, 10);
            this.systemConfigBox.Name = "systemConfigBox";
            this.systemConfigBox.Size = new System.Drawing.Size(230, 80);
            this.systemConfigBox.TabIndex = 0;
            this.systemConfigBox.TabStop = false;
            this.systemConfigBox.Text = "系统配置";
            // 
            // autoLaunchCb
            // 
            this.autoLaunchCb.AutoSize = true;
            this.autoLaunchCb.Location = new System.Drawing.Point(10, 20);
            this.autoLaunchCb.Name = "autoLaunchCb";
            this.autoLaunchCb.Size = new System.Drawing.Size(72, 16);
            this.autoLaunchCb.TabIndex = 0;
            this.autoLaunchCb.Text = "开机自启";
            this.autoLaunchCb.UseVisualStyleBackColor = true;
            // 
            // autoRunCb
            // 
            this.autoRunCb.AutoSize = true;
            this.autoRunCb.Location = new System.Drawing.Point(100, 20);
            this.autoRunCb.Name = "autoRunCb";
            this.autoRunCb.Size = new System.Drawing.Size(72, 16);
            this.autoRunCb.TabIndex = 1;
            this.autoRunCb.Text = "自动运行";
            this.autoRunCb.UseVisualStyleBackColor = true;
            // 
            // openConfigBtn
            // 
            this.openConfigBtn.Location = new System.Drawing.Point(10, 45);
            this.openConfigBtn.Name = "openConfigBtn";
            this.openConfigBtn.Size = new System.Drawing.Size(80, 23);
            this.openConfigBtn.TabIndex = 4;
            this.openConfigBtn.Text = "打开配置";
            this.openConfigBtn.UseVisualStyleBackColor = true;
            this.openConfigBtn.Click += new System.EventHandler(this.OpenConfigBtn_Click);
            // 
            // saveConfigBtn
            // 
            this.saveConfigBtn.Location = new System.Drawing.Point(140, 45);
            this.saveConfigBtn.Name = "saveConfigBtn";
            this.saveConfigBtn.Size = new System.Drawing.Size(80, 23);
            this.saveConfigBtn.TabIndex = 3;
            this.saveConfigBtn.Text = "保存配置";
            this.saveConfigBtn.UseVisualStyleBackColor = true;
            this.saveConfigBtn.Click += new System.EventHandler(this.SaveConfigBtn_Click);
            // 
            // programConfigBox
            // 
            this.programConfigBox.Controls.Add(this.programConfigText);
            this.programConfigBox.Location = new System.Drawing.Point(10, 100);
            this.programConfigBox.Name = "programConfigBox";
            this.programConfigBox.Size = new System.Drawing.Size(230, 200);
            this.programConfigBox.TabIndex = 5;
            this.programConfigBox.TabStop = false;
            this.programConfigBox.Text = "程序配置";
            // 
            // programConfigText
            // 
            this.programConfigText.BackColor = System.Drawing.SystemColors.Window;
            this.programConfigText.Location = new System.Drawing.Point(10, 20);
            this.programConfigText.Multiline = true;
            this.programConfigText.Name = "programConfigText";
            this.programConfigText.ReadOnly = true;
            this.programConfigText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.programConfigText.Size = new System.Drawing.Size(210, 170);
            this.programConfigText.TabIndex = 0;
            this.programConfigText.Text = "IP地址 127.0.0.1\r\n端口号 7070\r\n开启密码验证 False\r\n密码 \r\n全屏显示 True\r\n显示器 1(主)[1920x1080]\r\n显示器X" +
    " 0\r\n显示器Y 0\r\n显示器宽 1920\r\n显示器高 1080\r\n锁定纵横比 True\r\n缩放比例 100\r\n视频宽 1920\r\n视频高 1080\r\n显示光标" +
    " True\r\n每秒帧数 5\r\n视频质量 100";
            // 
            // ruleBox
            // 
            this.ruleBox.Controls.Add(this.ruleText);
            this.ruleBox.Location = new System.Drawing.Point(10, 310);
            this.ruleBox.Name = "ruleBox";
            this.ruleBox.Size = new System.Drawing.Size(230, 110);
            this.ruleBox.TabIndex = 4;
            this.ruleBox.TabStop = false;
            this.ruleBox.Text = "黑白名单规则";
            // 
            // ruleText
            // 
            this.ruleText.BackColor = System.Drawing.SystemColors.Window;
            this.ruleText.Location = new System.Drawing.Point(10, 20);
            this.ruleText.Multiline = true;
            this.ruleText.Name = "ruleText";
            this.ruleText.ReadOnly = true;
            this.ruleText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.ruleText.Size = new System.Drawing.Size(210, 80);
            this.ruleText.TabIndex = 1;
            this.ruleText.Text = "1.黑名单和白名单最多生效一个\r\n2.每条规则使用换行隔开\r\n3.通配符使用 * 例如 192.168.*.*\r\n4.范围使用 - 例如\r\n192.168.1.0" +
    " - 192.168.2.255\r\n5.通配符和范围不能同时使用";
            // 
            // blackBox
            // 
            this.blackBox.Controls.Add(this.openBlackCb);
            this.blackBox.Controls.Add(this.blackText);
            this.blackBox.Location = new System.Drawing.Point(250, 10);
            this.blackBox.Name = "blackBox";
            this.blackBox.Size = new System.Drawing.Size(250, 410);
            this.blackBox.TabIndex = 3;
            this.blackBox.TabStop = false;
            this.blackBox.Text = "黑名单";
            // 
            // openBlackCb
            // 
            this.openBlackCb.AutoSize = true;
            this.openBlackCb.Location = new System.Drawing.Point(10, 20);
            this.openBlackCb.Name = "openBlackCb";
            this.openBlackCb.Size = new System.Drawing.Size(84, 16);
            this.openBlackCb.TabIndex = 0;
            this.openBlackCb.Text = "开启黑名单";
            this.openBlackCb.UseVisualStyleBackColor = true;
            this.openBlackCb.CheckStateChanged += new System.EventHandler(this.OpenBlackCb_CheckStateChanged);
            // 
            // blackText
            // 
            this.blackText.Location = new System.Drawing.Point(10, 40);
            this.blackText.Multiline = true;
            this.blackText.Name = "blackText";
            this.blackText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.blackText.Size = new System.Drawing.Size(230, 360);
            this.blackText.TabIndex = 1;
            // 
            // whiteBox
            // 
            this.whiteBox.Controls.Add(this.openWhiteCb);
            this.whiteBox.Controls.Add(this.whiteText);
            this.whiteBox.Location = new System.Drawing.Point(510, 10);
            this.whiteBox.Name = "whiteBox";
            this.whiteBox.Size = new System.Drawing.Size(250, 410);
            this.whiteBox.TabIndex = 2;
            this.whiteBox.TabStop = false;
            this.whiteBox.Text = "白名单";
            // 
            // openWhiteCb
            // 
            this.openWhiteCb.AutoSize = true;
            this.openWhiteCb.Location = new System.Drawing.Point(10, 20);
            this.openWhiteCb.Name = "openWhiteCb";
            this.openWhiteCb.Size = new System.Drawing.Size(84, 16);
            this.openWhiteCb.TabIndex = 0;
            this.openWhiteCb.Text = "开启白名单";
            this.openWhiteCb.UseVisualStyleBackColor = true;
            this.openWhiteCb.CheckStateChanged += new System.EventHandler(this.OpenWhiteCb_CheckStateChanged);
            // 
            // whiteText
            // 
            this.whiteText.Location = new System.Drawing.Point(10, 40);
            this.whiteText.Multiline = true;
            this.whiteText.Name = "whiteText";
            this.whiteText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.whiteText.Size = new System.Drawing.Size(230, 360);
            this.whiteText.TabIndex = 1;
            // 
            // Config
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(768, 432);
            this.Controls.Add(this.programConfigBox);
            this.Controls.Add(this.systemConfigBox);
            this.Controls.Add(this.ruleBox);
            this.Controls.Add(this.blackBox);
            this.Controls.Add(this.whiteBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = global::ScreenShare.Properties.Resources.icon;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Config";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "系统配置";
            this.Load += new System.EventHandler(this.Config_Load);
            this.systemConfigBox.ResumeLayout(false);
            this.systemConfigBox.PerformLayout();
            this.programConfigBox.ResumeLayout(false);
            this.programConfigBox.PerformLayout();
            this.ruleBox.ResumeLayout(false);
            this.ruleBox.PerformLayout();
            this.blackBox.ResumeLayout(false);
            this.blackBox.PerformLayout();
            this.whiteBox.ResumeLayout(false);
            this.whiteBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        /* 系统配置 */
        /// <summary>
        /// 系统配置GroupBox
        /// </summary>
        private System.Windows.Forms.GroupBox systemConfigBox;
        /// <summary>
        /// 开机自启CheckBox
        /// </summary>
        private System.Windows.Forms.CheckBox autoLaunchCb;
        /// <summary>
        /// 自动运行CheckBox
        /// </summary>
        private System.Windows.Forms.CheckBox autoRunCb;
        /// <summary>
        /// 打开配置Button
        /// </summary>
        private System.Windows.Forms.Button openConfigBtn;
        /// <summary>
        /// 保存配置Button
        /// </summary>
        private System.Windows.Forms.Button saveConfigBtn;

        /* 程序配置 */
        /// <summary>
        /// 程序配置GroupBox
        /// </summary>
        private System.Windows.Forms.GroupBox programConfigBox;
        /// <summary>
        /// 程序配置TextBox
        /// </summary>
        private System.Windows.Forms.TextBox programConfigText;

        /* 黑白名单规则 */
        /// <summary>
        /// 黑白名单规则GroupBox
        /// </summary>
        private System.Windows.Forms.GroupBox ruleBox;
        /// <summary>
        /// 黑白名单规则TextBox
        /// </summary>
        private System.Windows.Forms.TextBox ruleText;

        /* 黑名单 */
        /// <summary>
        /// 黑名单GroupBox
        /// </summary>
        private System.Windows.Forms.GroupBox blackBox;
        /// <summary>
        /// 开启黑名单CheckBox
        /// </summary>
        private System.Windows.Forms.CheckBox openBlackCb;
        /// <summary>
        /// 黑名单TextBox
        /// </summary>
        private System.Windows.Forms.TextBox blackText;

        /* 白名单 */
        /// <summary>
        /// 白名单GroupBox
        /// </summary>
        private System.Windows.Forms.GroupBox whiteBox;
        /// <summary>
        /// 开启白名单CheckBox
        /// </summary>
        private System.Windows.Forms.CheckBox openWhiteCb;
        /// <summary>
        /// 白名单TextBox
        /// </summary>
        private System.Windows.Forms.TextBox whiteText;
    }
}
