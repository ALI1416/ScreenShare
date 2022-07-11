namespace ScreenShare
{
    partial class ScreenShare
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.shareScreenLabel = new System.Windows.Forms.Label();
            this.ipAddressLabel = new System.Windows.Forms.Label();
            this.ipAddressComboBox = new System.Windows.Forms.ComboBox();
            this.ipPortLabel = new System.Windows.Forms.Label();
            this.ipPortNud = new System.Windows.Forms.NumericUpDown();
            this.reloadConfigBtn = new System.Windows.Forms.Button();
            this.aboutBtn = new System.Windows.Forms.Button();
            this.shareLinkLabel = new System.Windows.Forms.Label();
            this.shareLinkText = new System.Windows.Forms.TextBox();
            this.copyBtn = new System.Windows.Forms.Button();
            this.openBtn = new System.Windows.Forms.Button();
            this.encryptionBox = new System.Windows.Forms.GroupBox();
            this.isEncryptionCb = new System.Windows.Forms.CheckBox();
            this.accountLabel = new System.Windows.Forms.Label();
            this.accountText = new System.Windows.Forms.TextBox();
            this.pwdLabel = new System.Windows.Forms.Label();
            this.pwdText = new System.Windows.Forms.TextBox();
            this.coordinatesBox = new System.Windows.Forms.GroupBox();
            this.isFullScreenCb = new System.Windows.Forms.CheckBox();
            this.displayLabel = new System.Windows.Forms.Label();
            this.displayComboBox = new System.Windows.Forms.ComboBox();
            this.screenXLabel = new System.Windows.Forms.Label();
            this.screenXNud = new System.Windows.Forms.NumericUpDown();
            this.screenYLabel = new System.Windows.Forms.Label();
            this.screenYNud = new System.Windows.Forms.NumericUpDown();
            this.screenWLabel = new System.Windows.Forms.Label();
            this.screenWNud = new System.Windows.Forms.NumericUpDown();
            this.screenHLabel = new System.Windows.Forms.Label();
            this.screenHNud = new System.Windows.Forms.NumericUpDown();
            this.captureScreenCoordinatesBtn = new System.Windows.Forms.Button();
            this.scalingBox = new System.Windows.Forms.GroupBox();
            this.isLockAspectRatioCb = new System.Windows.Forms.CheckBox();
            this.scalingLabel = new System.Windows.Forms.Label();
            this.scalingNud = new System.Windows.Forms.NumericUpDown();
            this.videoWLabel = new System.Windows.Forms.Label();
            this.videoWNud = new System.Windows.Forms.NumericUpDown();
            this.videoHLabel = new System.Windows.Forms.Label();
            this.videoHNud = new System.Windows.Forms.NumericUpDown();
            this.videoBox = new System.Windows.Forms.GroupBox();
            this.isDisplayCursorCb = new System.Windows.Forms.CheckBox();
            this.videoFrameLabel = new System.Windows.Forms.Label();
            this.videoFrameNud = new System.Windows.Forms.NumericUpDown();
            this.videoQualityLabel = new System.Windows.Forms.Label();
            this.videoQualityNud = new System.Windows.Forms.NumericUpDown();
            this.startSharingScreenBtn = new System.Windows.Forms.Button();
            this.logText = new System.Windows.Forms.TextBox();
            this.previewLabel = new System.Windows.Forms.Label();
            this.previewImg = new System.Windows.Forms.PictureBox();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ipPortNud)).BeginInit();
            this.encryptionBox.SuspendLayout();
            this.coordinatesBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.screenXNud)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.screenYNud)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.screenWNud)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.screenHNud)).BeginInit();
            this.scalingBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scalingNud)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.videoWNud)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.videoHNud)).BeginInit();
            this.videoBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.videoFrameNud)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.videoQualityNud)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.previewImg)).BeginInit();
            this.SuspendLayout();
            // 
            // shareScreenLabel
            // 
            this.shareScreenLabel.AutoSize = true;
            this.shareScreenLabel.Font = new System.Drawing.Font("宋体", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.shareScreenLabel.Location = new System.Drawing.Point(322, 10);
            this.shareScreenLabel.Name = "shareScreenLabel";
            this.shareScreenLabel.Size = new System.Drawing.Size(124, 27);
            this.shareScreenLabel.TabIndex = 0;
            this.shareScreenLabel.Text = "屏幕共享";
            // 
            // ipAddressLabel
            // 
            this.ipAddressLabel.AutoSize = true;
            this.ipAddressLabel.Location = new System.Drawing.Point(14, 54);
            this.ipAddressLabel.Name = "ipAddressLabel";
            this.ipAddressLabel.Size = new System.Drawing.Size(53, 12);
            this.ipAddressLabel.TabIndex = 0;
            this.ipAddressLabel.Text = "IP地址：";
            // 
            // ipAddressComboBox
            // 
            this.ipAddressComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ipAddressComboBox.FormattingEnabled = true;
            this.ipAddressComboBox.Location = new System.Drawing.Point(70, 50);
            this.ipAddressComboBox.Name = "ipAddressComboBox";
            this.ipAddressComboBox.Size = new System.Drawing.Size(345, 20);
            this.ipAddressComboBox.TabIndex = 2;
            this.ipAddressComboBox.SelectedValueChanged += new System.EventHandler(this.IpAddressComboBox_SelectedValueChanged);
            // 
            // ipPortLabel
            // 
            this.ipPortLabel.AutoSize = true;
            this.ipPortLabel.Location = new System.Drawing.Point(419, 54);
            this.ipPortLabel.Name = "ipPortLabel";
            this.ipPortLabel.Size = new System.Drawing.Size(53, 12);
            this.ipPortLabel.TabIndex = 0;
            this.ipPortLabel.Text = "端口号：";
            // 
            // ipPortNud
            // 
            this.ipPortNud.Location = new System.Drawing.Point(475, 50);
            this.ipPortNud.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.ipPortNud.Name = "ipPortNud";
            this.ipPortNud.Size = new System.Drawing.Size(80, 21);
            this.ipPortNud.TabIndex = 3;
            this.ipPortNud.Value = new decimal(new int[] {
            7070,
            0,
            0,
            0});
            this.ipPortNud.ValueChanged += new System.EventHandler(this.IpPortNud_ValueChanged);
            // 
            // reloadConfigBtn
            // 
            this.reloadConfigBtn.Location = new System.Drawing.Point(560, 50);
            this.reloadConfigBtn.Name = "reloadConfigBtn";
            this.reloadConfigBtn.Size = new System.Drawing.Size(90, 23);
            this.reloadConfigBtn.TabIndex = 4;
            this.reloadConfigBtn.Text = "重新加载配置";
            this.reloadConfigBtn.UseVisualStyleBackColor = true;
            // 
            // aboutBtn
            // 
            this.aboutBtn.Location = new System.Drawing.Point(710, 50);
            this.aboutBtn.Name = "aboutBtn";
            this.aboutBtn.Size = new System.Drawing.Size(50, 53);
            this.aboutBtn.TabIndex = 5;
            this.aboutBtn.Text = "关于";
            this.aboutBtn.UseVisualStyleBackColor = true;
            this.aboutBtn.Click += new System.EventHandler(this.AboutBtn_Click);
            // 
            // shareLinkLabel
            // 
            this.shareLinkLabel.AutoSize = true;
            this.shareLinkLabel.Location = new System.Drawing.Point(2, 84);
            this.shareLinkLabel.Name = "shareLinkLabel";
            this.shareLinkLabel.Size = new System.Drawing.Size(65, 12);
            this.shareLinkLabel.TabIndex = 0;
            this.shareLinkLabel.Text = "分享地址：";
            // 
            // shareLinkText
            // 
            this.shareLinkText.BackColor = System.Drawing.SystemColors.Window;
            this.shareLinkText.Location = new System.Drawing.Point(70, 80);
            this.shareLinkText.Name = "shareLinkText";
            this.shareLinkText.ReadOnly = true;
            this.shareLinkText.Size = new System.Drawing.Size(485, 21);
            this.shareLinkText.TabIndex = 6;
            // 
            // copyBtn
            // 
            this.copyBtn.Location = new System.Drawing.Point(560, 80);
            this.copyBtn.Name = "copyBtn";
            this.copyBtn.Size = new System.Drawing.Size(45, 23);
            this.copyBtn.TabIndex = 7;
            this.copyBtn.Text = "复制";
            this.toolTip.SetToolTip(this.copyBtn, "点击可以复制分享地址。");
            this.copyBtn.UseVisualStyleBackColor = true;
            this.copyBtn.Click += new System.EventHandler(this.CopyBtn_Click);
            // 
            // openBtn
            // 
            this.openBtn.Location = new System.Drawing.Point(610, 80);
            this.openBtn.Name = "openBtn";
            this.openBtn.Size = new System.Drawing.Size(90, 23);
            this.openBtn.TabIndex = 8;
            this.openBtn.Text = "用浏览器打开";
            this.openBtn.UseVisualStyleBackColor = true;
            // 
            // encryptionBox
            // 
            this.encryptionBox.Controls.Add(this.isEncryptionCb);
            this.encryptionBox.Controls.Add(this.accountLabel);
            this.encryptionBox.Controls.Add(this.accountText);
            this.encryptionBox.Controls.Add(this.pwdLabel);
            this.encryptionBox.Controls.Add(this.pwdText);
            this.encryptionBox.Location = new System.Drawing.Point(10, 120);
            this.encryptionBox.Name = "encryptionBox";
            this.encryptionBox.Size = new System.Drawing.Size(140, 100);
            this.encryptionBox.TabIndex = 9;
            this.encryptionBox.TabStop = false;
            this.encryptionBox.Text = "加密传输";
            // 
            // isEncryptionCb
            // 
            this.isEncryptionCb.AutoSize = true;
            this.isEncryptionCb.Location = new System.Drawing.Point(10, 20);
            this.isEncryptionCb.Name = "isEncryptionCb";
            this.isEncryptionCb.Size = new System.Drawing.Size(48, 16);
            this.isEncryptionCb.TabIndex = 1;
            this.isEncryptionCb.Text = "开启";
            this.toolTip.SetToolTip(this.isEncryptionCb, "开启后需要输入账号密码才能访问。");
            this.isEncryptionCb.UseVisualStyleBackColor = true;
            this.isEncryptionCb.CheckStateChanged += new System.EventHandler(this.IsEncryptionCb_CheckStateChanged);
            // 
            // accountLabel
            // 
            this.accountLabel.AutoSize = true;
            this.accountLabel.Location = new System.Drawing.Point(6, 44);
            this.accountLabel.Name = "accountLabel";
            this.accountLabel.Size = new System.Drawing.Size(41, 12);
            this.accountLabel.TabIndex = 0;
            this.accountLabel.Text = "账号：";
            // 
            // accountText
            // 
            this.accountText.Enabled = false;
            this.accountText.Location = new System.Drawing.Point(50, 40);
            this.accountText.Name = "accountText";
            this.accountText.Size = new System.Drawing.Size(80, 21);
            this.accountText.TabIndex = 2;
            // 
            // pwdLabel
            // 
            this.pwdLabel.AutoSize = true;
            this.pwdLabel.Location = new System.Drawing.Point(6, 74);
            this.pwdLabel.Name = "pwdLabel";
            this.pwdLabel.Size = new System.Drawing.Size(41, 12);
            this.pwdLabel.TabIndex = 0;
            this.pwdLabel.Text = "密码：";
            // 
            // pwdText
            // 
            this.pwdText.Enabled = false;
            this.pwdText.Location = new System.Drawing.Point(50, 70);
            this.pwdText.Name = "pwdText";
            this.pwdText.Size = new System.Drawing.Size(80, 21);
            this.pwdText.TabIndex = 3;
            // 
            // coordinatesBox
            // 
            this.coordinatesBox.Controls.Add(this.isFullScreenCb);
            this.coordinatesBox.Controls.Add(this.displayLabel);
            this.coordinatesBox.Controls.Add(this.displayComboBox);
            this.coordinatesBox.Controls.Add(this.screenXLabel);
            this.coordinatesBox.Controls.Add(this.screenXNud);
            this.coordinatesBox.Controls.Add(this.screenYLabel);
            this.coordinatesBox.Controls.Add(this.screenYNud);
            this.coordinatesBox.Controls.Add(this.screenWLabel);
            this.coordinatesBox.Controls.Add(this.screenWNud);
            this.coordinatesBox.Controls.Add(this.screenHLabel);
            this.coordinatesBox.Controls.Add(this.screenHNud);
            this.coordinatesBox.Controls.Add(this.captureScreenCoordinatesBtn);
            this.coordinatesBox.Location = new System.Drawing.Point(160, 120);
            this.coordinatesBox.Name = "coordinatesBox";
            this.coordinatesBox.Size = new System.Drawing.Size(265, 100);
            this.coordinatesBox.TabIndex = 10;
            this.coordinatesBox.TabStop = false;
            this.coordinatesBox.Text = "选取位置";
            // 
            // isFullScreenCb
            // 
            this.isFullScreenCb.AutoSize = true;
            this.isFullScreenCb.Checked = true;
            this.isFullScreenCb.CheckState = System.Windows.Forms.CheckState.Checked;
            this.isFullScreenCb.Location = new System.Drawing.Point(10, 20);
            this.isFullScreenCb.Name = "isFullScreenCb";
            this.isFullScreenCb.Size = new System.Drawing.Size(48, 16);
            this.isFullScreenCb.TabIndex = 1;
            this.isFullScreenCb.Text = "全屏";
            this.isFullScreenCb.UseVisualStyleBackColor = true;
            this.isFullScreenCb.CheckStateChanged += new System.EventHandler(this.IsFullScreenCb_CheckStateChanged);
            // 
            // displayLabel
            // 
            this.displayLabel.AutoSize = true;
            this.displayLabel.Location = new System.Drawing.Point(69, 20);
            this.displayLabel.Name = "displayLabel";
            this.displayLabel.Size = new System.Drawing.Size(53, 12);
            this.displayLabel.TabIndex = 0;
            this.displayLabel.Text = "显示器：";
            // 
            // displayComboBox
            // 
            this.displayComboBox.FormattingEnabled = true;
            this.displayComboBox.Location = new System.Drawing.Point(125, 16);
            this.displayComboBox.Name = "displayComboBox";
            this.displayComboBox.Size = new System.Drawing.Size(130, 20);
            this.displayComboBox.TabIndex = 2;
            // 
            // screenXLabel
            // 
            this.screenXLabel.AutoSize = true;
            this.screenXLabel.Location = new System.Drawing.Point(4, 44);
            this.screenXLabel.Name = "screenXLabel";
            this.screenXLabel.Size = new System.Drawing.Size(23, 12);
            this.screenXLabel.TabIndex = 0;
            this.screenXLabel.Text = "X：";
            // 
            // screenXNud
            // 
            this.screenXNud.Enabled = false;
            this.screenXNud.Location = new System.Drawing.Point(30, 40);
            this.screenXNud.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.screenXNud.Minimum = new decimal(new int[] {
            65536,
            0,
            0,
            -2147483648});
            this.screenXNud.Name = "screenXNud";
            this.screenXNud.Size = new System.Drawing.Size(50, 21);
            this.screenXNud.TabIndex = 3;
            this.toolTip.SetToolTip(this.screenXNud, "选取矩形左上角的横坐标X");
            // 
            // screenYLabel
            // 
            this.screenYLabel.AutoSize = true;
            this.screenYLabel.Location = new System.Drawing.Point(4, 74);
            this.screenYLabel.Name = "screenYLabel";
            this.screenYLabel.Size = new System.Drawing.Size(23, 12);
            this.screenYLabel.TabIndex = 0;
            this.screenYLabel.Text = "Y：";
            // 
            // screenYNud
            // 
            this.screenYNud.Enabled = false;
            this.screenYNud.Location = new System.Drawing.Point(30, 70);
            this.screenYNud.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.screenYNud.Minimum = new decimal(new int[] {
            65536,
            0,
            0,
            -2147483648});
            this.screenYNud.Name = "screenYNud";
            this.screenYNud.Size = new System.Drawing.Size(50, 21);
            this.screenYNud.TabIndex = 4;
            this.toolTip.SetToolTip(this.screenYNud, "选取矩形左上角的纵坐标Y");
            // 
            // screenWLabel
            // 
            this.screenWLabel.AutoSize = true;
            this.screenWLabel.Location = new System.Drawing.Point(88, 44);
            this.screenWLabel.Name = "screenWLabel";
            this.screenWLabel.Size = new System.Drawing.Size(29, 12);
            this.screenWLabel.TabIndex = 0;
            this.screenWLabel.Text = "宽：";
            // 
            // screenWNud
            // 
            this.screenWNud.Enabled = false;
            this.screenWNud.Location = new System.Drawing.Point(120, 40);
            this.screenWNud.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.screenWNud.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.screenWNud.Name = "screenWNud";
            this.screenWNud.Size = new System.Drawing.Size(50, 21);
            this.screenWNud.TabIndex = 5;
            this.toolTip.SetToolTip(this.screenWNud, "选取矩形的宽");
            this.screenWNud.Value = new decimal(new int[] {
            1920,
            0,
            0,
            0});
            this.screenWNud.ValueChanged += new System.EventHandler(this.ScreenWNud_ValueChanged);
            // 
            // screenHLabel
            // 
            this.screenHLabel.AutoSize = true;
            this.screenHLabel.Location = new System.Drawing.Point(88, 74);
            this.screenHLabel.Name = "screenHLabel";
            this.screenHLabel.Size = new System.Drawing.Size(29, 12);
            this.screenHLabel.TabIndex = 0;
            this.screenHLabel.Text = "高：";
            // 
            // screenHNud
            // 
            this.screenHNud.Enabled = false;
            this.screenHNud.Location = new System.Drawing.Point(120, 70);
            this.screenHNud.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.screenHNud.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.screenHNud.Name = "screenHNud";
            this.screenHNud.Size = new System.Drawing.Size(50, 21);
            this.screenHNud.TabIndex = 6;
            this.toolTip.SetToolTip(this.screenHNud, "选取矩形的高");
            this.screenHNud.Value = new decimal(new int[] {
            1080,
            0,
            0,
            0});
            this.screenHNud.ValueChanged += new System.EventHandler(this.ScreenHNud_ValueChanged);
            // 
            // captureScreenCoordinatesBtn
            // 
            this.captureScreenCoordinatesBtn.Location = new System.Drawing.Point(180, 40);
            this.captureScreenCoordinatesBtn.Name = "captureScreenCoordinatesBtn";
            this.captureScreenCoordinatesBtn.Size = new System.Drawing.Size(75, 51);
            this.captureScreenCoordinatesBtn.TabIndex = 7;
            this.captureScreenCoordinatesBtn.Text = "选取\r\n屏幕坐标";
            this.captureScreenCoordinatesBtn.UseVisualStyleBackColor = true;
            this.captureScreenCoordinatesBtn.Click += new System.EventHandler(this.CaptureScreenCoordinatesBtn_Click);
            // 
            // scalingBox
            // 
            this.scalingBox.Controls.Add(this.isLockAspectRatioCb);
            this.scalingBox.Controls.Add(this.scalingLabel);
            this.scalingBox.Controls.Add(this.scalingNud);
            this.scalingBox.Controls.Add(this.videoWLabel);
            this.scalingBox.Controls.Add(this.videoWNud);
            this.scalingBox.Controls.Add(this.videoHLabel);
            this.scalingBox.Controls.Add(this.videoHNud);
            this.scalingBox.Location = new System.Drawing.Point(435, 120);
            this.scalingBox.Name = "scalingBox";
            this.scalingBox.Size = new System.Drawing.Size(185, 100);
            this.scalingBox.TabIndex = 11;
            this.scalingBox.TabStop = false;
            this.scalingBox.Text = "视频尺寸";
            // 
            // isLockAspectRatioCb
            // 
            this.isLockAspectRatioCb.AutoSize = true;
            this.isLockAspectRatioCb.Checked = true;
            this.isLockAspectRatioCb.CheckState = System.Windows.Forms.CheckState.Checked;
            this.isLockAspectRatioCb.Location = new System.Drawing.Point(10, 20);
            this.isLockAspectRatioCb.Name = "isLockAspectRatioCb";
            this.isLockAspectRatioCb.Size = new System.Drawing.Size(84, 16);
            this.isLockAspectRatioCb.TabIndex = 1;
            this.isLockAspectRatioCb.Text = "锁定纵横比";
            this.isLockAspectRatioCb.UseVisualStyleBackColor = true;
            this.isLockAspectRatioCb.CheckStateChanged += new System.EventHandler(this.IsLockAspectRatioCb_CheckStateChanged);
            // 
            // scalingLabel
            // 
            this.scalingLabel.AutoSize = true;
            this.scalingLabel.Location = new System.Drawing.Point(2, 44);
            this.scalingLabel.Name = "scalingLabel";
            this.scalingLabel.Size = new System.Drawing.Size(65, 12);
            this.scalingLabel.TabIndex = 0;
            this.scalingLabel.Text = "缩放比例：";
            // 
            // scalingNud
            // 
            this.scalingNud.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.scalingNud.Location = new System.Drawing.Point(70, 40);
            this.scalingNud.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.scalingNud.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.scalingNud.Name = "scalingNud";
            this.scalingNud.Size = new System.Drawing.Size(50, 21);
            this.scalingNud.TabIndex = 2;
            this.toolTip.SetToolTip(this.scalingNud, "相对于选取的矩形的缩放比例，建议100%。最好不要修改，否则会卡顿。");
            this.scalingNud.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.scalingNud.ValueChanged += new System.EventHandler(this.ScalingNud_ValueChanged);
            // 
            // videoWLabel
            // 
            this.videoWLabel.AutoSize = true;
            this.videoWLabel.Location = new System.Drawing.Point(3, 74);
            this.videoWLabel.Name = "videoWLabel";
            this.videoWLabel.Size = new System.Drawing.Size(29, 12);
            this.videoWLabel.TabIndex = 0;
            this.videoWLabel.Text = "宽：";
            // 
            // videoWNud
            // 
            this.videoWNud.Enabled = false;
            this.videoWNud.Location = new System.Drawing.Point(35, 70);
            this.videoWNud.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.videoWNud.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.videoWNud.Name = "videoWNud";
            this.videoWNud.Size = new System.Drawing.Size(50, 21);
            this.videoWNud.TabIndex = 3;
            this.videoWNud.Value = new decimal(new int[] {
            1920,
            0,
            0,
            0});
            // 
            // videoHLabel
            // 
            this.videoHLabel.AutoSize = true;
            this.videoHLabel.Location = new System.Drawing.Point(93, 74);
            this.videoHLabel.Name = "videoHLabel";
            this.videoHLabel.Size = new System.Drawing.Size(29, 12);
            this.videoHLabel.TabIndex = 0;
            this.videoHLabel.Text = "高：";
            // 
            // videoHNud
            // 
            this.videoHNud.Enabled = false;
            this.videoHNud.Location = new System.Drawing.Point(125, 70);
            this.videoHNud.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.videoHNud.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.videoHNud.Name = "videoHNud";
            this.videoHNud.Size = new System.Drawing.Size(50, 21);
            this.videoHNud.TabIndex = 4;
            this.videoHNud.Value = new decimal(new int[] {
            1080,
            0,
            0,
            0});
            // 
            // videoBox
            // 
            this.videoBox.Controls.Add(this.isDisplayCursorCb);
            this.videoBox.Controls.Add(this.videoFrameLabel);
            this.videoBox.Controls.Add(this.videoFrameNud);
            this.videoBox.Controls.Add(this.videoQualityLabel);
            this.videoBox.Controls.Add(this.videoQualityNud);
            this.videoBox.Location = new System.Drawing.Point(630, 120);
            this.videoBox.Name = "videoBox";
            this.videoBox.Size = new System.Drawing.Size(130, 100);
            this.videoBox.TabIndex = 12;
            this.videoBox.TabStop = false;
            this.videoBox.Text = "视频设置";
            // 
            // isDisplayCursorCb
            // 
            this.isDisplayCursorCb.AutoSize = true;
            this.isDisplayCursorCb.Checked = true;
            this.isDisplayCursorCb.CheckState = System.Windows.Forms.CheckState.Checked;
            this.isDisplayCursorCb.Location = new System.Drawing.Point(10, 20);
            this.isDisplayCursorCb.Name = "isDisplayCursorCb";
            this.isDisplayCursorCb.Size = new System.Drawing.Size(72, 16);
            this.isDisplayCursorCb.TabIndex = 1;
            this.isDisplayCursorCb.Text = "显示光标";
            this.isDisplayCursorCb.UseVisualStyleBackColor = true;
            // 
            // videoFrameLabel
            // 
            this.videoFrameLabel.AutoSize = true;
            this.videoFrameLabel.Location = new System.Drawing.Point(2, 44);
            this.videoFrameLabel.Name = "videoFrameLabel";
            this.videoFrameLabel.Size = new System.Drawing.Size(65, 12);
            this.videoFrameLabel.TabIndex = 0;
            this.videoFrameLabel.Text = "每秒帧数：";
            // 
            // videoFrameNud
            // 
            this.videoFrameNud.Location = new System.Drawing.Point(70, 40);
            this.videoFrameNud.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.videoFrameNud.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.videoFrameNud.Name = "videoFrameNud";
            this.videoFrameNud.Size = new System.Drawing.Size(50, 21);
            this.videoFrameNud.TabIndex = 2;
            this.toolTip.SetToolTip(this.videoFrameNud, "每秒刷新次数，数字越大越流畅，建议5帧/秒。不要调太高，否则会卡顿。");
            this.videoFrameNud.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // videoQualityLabel
            // 
            this.videoQualityLabel.AutoSize = true;
            this.videoQualityLabel.Location = new System.Drawing.Point(2, 74);
            this.videoQualityLabel.Name = "videoQualityLabel";
            this.videoQualityLabel.Size = new System.Drawing.Size(65, 12);
            this.videoQualityLabel.TabIndex = 0;
            this.videoQualityLabel.Text = "视频质量：";
            // 
            // videoQualityNud
            // 
            this.videoQualityNud.Location = new System.Drawing.Point(70, 70);
            this.videoQualityNud.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.videoQualityNud.Name = "videoQualityNud";
            this.videoQualityNud.Size = new System.Drawing.Size(50, 21);
            this.videoQualityNud.TabIndex = 3;
            this.toolTip.SetToolTip(this.videoQualityNud, "视频清晰度，数字越大越清晰，建议100%。最好不要改，否则会卡顿。");
            this.videoQualityNud.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // startSharingScreenBtn
            // 
            this.startSharingScreenBtn.Font = new System.Drawing.Font("宋体", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.startSharingScreenBtn.Location = new System.Drawing.Point(125, 230);
            this.startSharingScreenBtn.Name = "startSharingScreenBtn";
            this.startSharingScreenBtn.Size = new System.Drawing.Size(185, 40);
            this.startSharingScreenBtn.TabIndex = 1;
            this.startSharingScreenBtn.Text = "开始共享";
            this.startSharingScreenBtn.UseVisualStyleBackColor = true;
            this.startSharingScreenBtn.Click += new System.EventHandler(this.StartSharingScreenBtn_Click);
            // 
            // logText
            // 
            this.logText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.logText.BackColor = System.Drawing.SystemColors.Window;
            this.logText.Location = new System.Drawing.Point(10, 280);
            this.logText.Multiline = true;
            this.logText.Name = "logText";
            this.logText.ReadOnly = true;
            this.logText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.logText.Size = new System.Drawing.Size(415, 140);
            this.logText.TabIndex = 0;
            this.logText.TabStop = false;
            // 
            // previewLabel
            // 
            this.previewLabel.AutoSize = true;
            this.previewLabel.Location = new System.Drawing.Point(545, 310);
            this.previewLabel.Name = "previewLabel";
            this.previewLabel.Size = new System.Drawing.Size(101, 24);
            this.previewLabel.TabIndex = 0;
            this.previewLabel.Text = "点击此处预览\r\n再次点击退出预览";
            this.previewLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // previewImg
            // 
            this.previewImg.Location = new System.Drawing.Point(435, 230);
            this.previewImg.Margin = new System.Windows.Forms.Padding(0);
            this.previewImg.Name = "previewImg";
            this.previewImg.Size = new System.Drawing.Size(325, 190);
            this.previewImg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.previewImg.TabIndex = 0;
            this.previewImg.TabStop = false;
            this.previewImg.Click += new System.EventHandler(this.PreviewImg_Click);
            // 
            // ScreenShare
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(768, 432);
            this.Controls.Add(this.shareScreenLabel);
            this.Controls.Add(this.ipAddressLabel);
            this.Controls.Add(this.ipAddressComboBox);
            this.Controls.Add(this.ipPortLabel);
            this.Controls.Add(this.ipPortNud);
            this.Controls.Add(this.reloadConfigBtn);
            this.Controls.Add(this.aboutBtn);
            this.Controls.Add(this.shareLinkLabel);
            this.Controls.Add(this.shareLinkText);
            this.Controls.Add(this.copyBtn);
            this.Controls.Add(this.openBtn);
            this.Controls.Add(this.encryptionBox);
            this.Controls.Add(this.coordinatesBox);
            this.Controls.Add(this.scalingBox);
            this.Controls.Add(this.videoBox);
            this.Controls.Add(this.startSharingScreenBtn);
            this.Controls.Add(this.logText);
            this.Controls.Add(this.previewLabel);
            this.Controls.Add(this.previewImg);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = global::ScreenShare.Properties.Resources.icon;
            this.MaximizeBox = false;
            this.Name = "ScreenShare";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "屏幕共享";
            ((System.ComponentModel.ISupportInitialize)(this.ipPortNud)).EndInit();
            this.encryptionBox.ResumeLayout(false);
            this.encryptionBox.PerformLayout();
            this.coordinatesBox.ResumeLayout(false);
            this.coordinatesBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.screenXNud)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.screenYNud)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.screenWNud)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.screenHNud)).EndInit();
            this.scalingBox.ResumeLayout(false);
            this.scalingBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scalingNud)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.videoWNud)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.videoHNud)).EndInit();
            this.videoBox.ResumeLayout(false);
            this.videoBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.videoFrameNud)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.videoQualityNud)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.previewImg)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        // 头部
        private System.Windows.Forms.Label shareScreenLabel;
        private System.Windows.Forms.Label ipAddressLabel;
        private System.Windows.Forms.ComboBox ipAddressComboBox;
        private System.Windows.Forms.Label ipPortLabel;
        private System.Windows.Forms.NumericUpDown ipPortNud;
        private System.Windows.Forms.Button reloadConfigBtn;
        private System.Windows.Forms.Button aboutBtn;
        private System.Windows.Forms.Label shareLinkLabel;
        private System.Windows.Forms.TextBox shareLinkText;
        private System.Windows.Forms.Button copyBtn;
        private System.Windows.Forms.Button openBtn;
        // 加密传输box
        private System.Windows.Forms.GroupBox encryptionBox;
        private System.Windows.Forms.CheckBox isEncryptionCb;
        private System.Windows.Forms.Label accountLabel;
        private System.Windows.Forms.TextBox accountText;
        private System.Windows.Forms.Label pwdLabel;
        private System.Windows.Forms.TextBox pwdText;
        // 选取位置box
        private System.Windows.Forms.GroupBox coordinatesBox;
        private System.Windows.Forms.CheckBox isFullScreenCb;
        private System.Windows.Forms.Label displayLabel;
        private System.Windows.Forms.ComboBox displayComboBox;
        private System.Windows.Forms.Label screenXLabel;
        private System.Windows.Forms.NumericUpDown screenXNud;
        private System.Windows.Forms.Label screenYLabel;
        private System.Windows.Forms.NumericUpDown screenYNud;
        private System.Windows.Forms.Label screenWLabel;
        private System.Windows.Forms.NumericUpDown screenWNud;
        private System.Windows.Forms.Label screenHLabel;
        private System.Windows.Forms.NumericUpDown screenHNud;
        private System.Windows.Forms.Button captureScreenCoordinatesBtn;
        // 视频尺寸box
        private System.Windows.Forms.GroupBox scalingBox;
        private System.Windows.Forms.CheckBox isLockAspectRatioCb;
        private System.Windows.Forms.Label scalingLabel;
        private System.Windows.Forms.NumericUpDown scalingNud;
        private System.Windows.Forms.Label videoWLabel;
        private System.Windows.Forms.NumericUpDown videoWNud;
        private System.Windows.Forms.Label videoHLabel;
        private System.Windows.Forms.NumericUpDown videoHNud;
        // 视频设置box
        private System.Windows.Forms.GroupBox videoBox;
        private System.Windows.Forms.CheckBox isDisplayCursorCb;
        private System.Windows.Forms.Label videoFrameLabel;
        private System.Windows.Forms.NumericUpDown videoFrameNud;
        private System.Windows.Forms.Label videoQualityLabel;
        private System.Windows.Forms.NumericUpDown videoQualityNud;
        // 开始分享按钮
        private System.Windows.Forms.Button startSharingScreenBtn;
        // 日志
        private System.Windows.Forms.TextBox logText;
        // 预览
        private System.Windows.Forms.Label previewLabel;
        private System.Windows.Forms.PictureBox previewImg;
        // 提示
        private System.Windows.Forms.ToolTip toolTip;
    }
}
