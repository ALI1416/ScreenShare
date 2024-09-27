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
            this.autoLaunchBtn = new System.Windows.Forms.CheckBox();
            this.autoRunBtn = new System.Windows.Forms.CheckBox();
            this.resetConfigBtn = new System.Windows.Forms.Button();
            this.openConfigBtn = new System.Windows.Forms.Button();
            this.saveConfigBtn = new System.Windows.Forms.Button();
            this.ruleBox = new System.Windows.Forms.GroupBox();
            this.ruleLabel = new System.Windows.Forms.Label();
            this.blackBox = new System.Windows.Forms.GroupBox();
            this.openBlackCb = new System.Windows.Forms.CheckBox();
            this.blackText = new System.Windows.Forms.TextBox();
            this.whiteBox = new System.Windows.Forms.GroupBox();
            this.openWhiteCb = new System.Windows.Forms.CheckBox();
            this.whiteText = new System.Windows.Forms.TextBox();
            this.systemConfigBox.SuspendLayout();
            this.ruleBox.SuspendLayout();
            this.blackBox.SuspendLayout();
            this.whiteBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // systemConfigBox
            // 
            this.systemConfigBox.Controls.Add(this.autoLaunchBtn);
            this.systemConfigBox.Controls.Add(this.autoRunBtn);
            this.systemConfigBox.Controls.Add(this.resetConfigBtn);
            this.systemConfigBox.Controls.Add(this.openConfigBtn);
            this.systemConfigBox.Controls.Add(this.saveConfigBtn);
            this.systemConfigBox.Controls.Add(this.ruleBox);
            this.systemConfigBox.Location = new System.Drawing.Point(10, 10);
            this.systemConfigBox.Name = "systemConfigBox";
            this.systemConfigBox.Size = new System.Drawing.Size(290, 410);
            this.systemConfigBox.TabIndex = 0;
            this.systemConfigBox.TabStop = false;
            this.systemConfigBox.Text = "系统配置";
            // 
            // autoLaunchBtn
            // 
            this.autoLaunchBtn.AutoSize = true;
            this.autoLaunchBtn.Location = new System.Drawing.Point(10, 20);
            this.autoLaunchBtn.Name = "autoLaunchBtn";
            this.autoLaunchBtn.Size = new System.Drawing.Size(72, 16);
            this.autoLaunchBtn.TabIndex = 0;
            this.autoLaunchBtn.Text = "开机自启";
            this.autoLaunchBtn.UseVisualStyleBackColor = true;
            // 
            // autoRunBtn
            // 
            this.autoRunBtn.AutoSize = true;
            this.autoRunBtn.Location = new System.Drawing.Point(100, 20);
            this.autoRunBtn.Name = "autoRunBtn";
            this.autoRunBtn.Size = new System.Drawing.Size(72, 16);
            this.autoRunBtn.TabIndex = 1;
            this.autoRunBtn.Text = "自动运行";
            this.autoRunBtn.UseVisualStyleBackColor = true;
            // 
            // resetConfigBtn
            // 
            this.resetConfigBtn.Location = new System.Drawing.Point(10, 380);
            this.resetConfigBtn.Name = "resetConfigBtn";
            this.resetConfigBtn.Size = new System.Drawing.Size(80, 23);
            this.resetConfigBtn.TabIndex = 5;
            this.resetConfigBtn.Text = "重置配置";
            this.resetConfigBtn.UseVisualStyleBackColor = true;
            this.resetConfigBtn.Click += new System.EventHandler(this.ResetConfigBtn_Click);
            // 
            // openConfigBtn
            // 
            this.openConfigBtn.Location = new System.Drawing.Point(105, 380);
            this.openConfigBtn.Name = "openConfigBtn";
            this.openConfigBtn.Size = new System.Drawing.Size(80, 23);
            this.openConfigBtn.TabIndex = 4;
            this.openConfigBtn.Text = "打开配置";
            this.openConfigBtn.UseVisualStyleBackColor = true;
            this.openConfigBtn.Click += new System.EventHandler(this.OpenConfigBtn_Click);
            // 
            // saveConfigBtn
            // 
            this.saveConfigBtn.Location = new System.Drawing.Point(200, 380);
            this.saveConfigBtn.Name = "saveConfigBtn";
            this.saveConfigBtn.Size = new System.Drawing.Size(80, 23);
            this.saveConfigBtn.TabIndex = 3;
            this.saveConfigBtn.Text = "保存配置";
            this.saveConfigBtn.UseVisualStyleBackColor = true;
            this.saveConfigBtn.Click += new System.EventHandler(this.SaveConfigBtn_Click);
            // 
            // ruleBox
            // 
            this.ruleBox.Controls.Add(this.ruleLabel);
            this.ruleBox.Location = new System.Drawing.Point(10, 280);
            this.ruleBox.Name = "ruleBox";
            this.ruleBox.Size = new System.Drawing.Size(270, 90);
            this.ruleBox.TabIndex = 4;
            this.ruleBox.TabStop = false;
            this.ruleBox.Text = "黑白名单规则";
            // 
            // ruleLabel
            // 
            this.ruleLabel.AutoSize = true;
            this.ruleLabel.Location = new System.Drawing.Point(5, 20);
            this.ruleLabel.Name = "ruleLabel";
            this.ruleLabel.Size = new System.Drawing.Size(263, 60);
            this.ruleLabel.TabIndex = 0;
            this.ruleLabel.Text = "1.黑名单和白名单最多生效一个\r\n2.每条规则使用换行隔开\r\n3.通配符使用 * 例如 192.168.*.*\r\n4.范围使用 - 例如 192.168.1.0-" +
    "192.168.2.255\r\n5.通配符和范围不能同时使用";
            // 
            // blackBox
            // 
            this.blackBox.Controls.Add(this.openBlackCb);
            this.blackBox.Controls.Add(this.blackText);
            this.blackBox.Location = new System.Drawing.Point(310, 10);
            this.blackBox.Name = "blackBox";
            this.blackBox.Size = new System.Drawing.Size(220, 410);
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
            // 
            // blackText
            // 
            this.blackText.Location = new System.Drawing.Point(10, 40);
            this.blackText.Multiline = true;
            this.blackText.Name = "blackText";
            this.blackText.Size = new System.Drawing.Size(200, 360);
            this.blackText.TabIndex = 1;
            // 
            // whiteBox
            // 
            this.whiteBox.Controls.Add(this.openWhiteCb);
            this.whiteBox.Controls.Add(this.whiteText);
            this.whiteBox.Location = new System.Drawing.Point(540, 10);
            this.whiteBox.Name = "whiteBox";
            this.whiteBox.Size = new System.Drawing.Size(220, 410);
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
            // 
            // whiteText
            // 
            this.whiteText.Location = new System.Drawing.Point(10, 40);
            this.whiteText.Multiline = true;
            this.whiteText.Name = "whiteText";
            this.whiteText.Size = new System.Drawing.Size(200, 360);
            this.whiteText.TabIndex = 1;
            // 
            // Config
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(768, 432);
            this.Controls.Add(this.systemConfigBox);
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
            this.systemConfigBox.ResumeLayout(false);
            this.systemConfigBox.PerformLayout();
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
        private System.Windows.Forms.CheckBox autoLaunchBtn;
        /// <summary>
        /// 自动运行CheckBox
        /// </summary>
        private System.Windows.Forms.CheckBox autoRunBtn;
        /// <summary>
        /// 黑白名单规则CheckBox
        /// </summary>
        private System.Windows.Forms.GroupBox ruleBox;
        /// <summary>
        /// 黑白名单规则Label
        /// </summary>
        private System.Windows.Forms.Label ruleLabel;
        /// <summary>
        /// 重置配置Button
        /// </summary>
        private System.Windows.Forms.Button resetConfigBtn;
        /// <summary>
        /// 打开配置Button
        /// </summary>
        private System.Windows.Forms.Button openConfigBtn;
        /// <summary>
        /// 保存配置Button
        /// </summary>
        private System.Windows.Forms.Button saveConfigBtn;

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
