namespace ScreenShare
{
    partial class Main
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
            this.topPanel = new System.Windows.Forms.Panel();
            this.titleLabel = new System.Windows.Forms.Label();
            this.ipAddressComboBox = new System.Windows.Forms.ComboBox();
            this.ipAddressLabel = new System.Windows.Forms.Label();
            this.ipPortNud = new System.Windows.Forms.NumericUpDown();
            this.ipPortLabel = new System.Windows.Forms.Label();
            this.shareLinkText = new System.Windows.Forms.TextBox();
            this.shareLinkLabel = new System.Windows.Forms.Label();
            this.copyBtn = new System.Windows.Forms.Button();
            this.reloadConfigBtn = new System.Windows.Forms.Button();
            this.openBtn = new System.Windows.Forms.Button();
            this.configBtn = new System.Windows.Forms.Button();
            this.qrBtn = new System.Windows.Forms.Button();
            this.middlePanel = new System.Windows.Forms.Panel();
            this.encryptionBox = new System.Windows.Forms.GroupBox();
            this.isEncryptionCb = new System.Windows.Forms.CheckBox();
            this.pwdText = new System.Windows.Forms.TextBox();
            this.pwdLabel = new System.Windows.Forms.Label();
            this.coordinatesBox = new System.Windows.Forms.GroupBox();
            this.isFullScreenCb = new System.Windows.Forms.CheckBox();
            this.screenComboBox = new System.Windows.Forms.ComboBox();
            this.screenLabel = new System.Windows.Forms.Label();
            this.screenXNud = new System.Windows.Forms.NumericUpDown();
            this.screenXLabel = new System.Windows.Forms.Label();
            this.screenYNud = new System.Windows.Forms.NumericUpDown();
            this.screenYLabel = new System.Windows.Forms.Label();
            this.screenWNud = new System.Windows.Forms.NumericUpDown();
            this.screenWLabel = new System.Windows.Forms.Label();
            this.screenHNud = new System.Windows.Forms.NumericUpDown();
            this.screenHLabel = new System.Windows.Forms.Label();
            this.captureScreenCoordinatesBtn = new System.Windows.Forms.Button();
            this.videoOptionBox = new System.Windows.Forms.GroupBox();
            this.isLockAspectRatioCb = new System.Windows.Forms.CheckBox();
            this.scalingNud = new System.Windows.Forms.NumericUpDown();
            this.scalingLabel = new System.Windows.Forms.Label();
            this.videoWNud = new System.Windows.Forms.NumericUpDown();
            this.videoWLabel = new System.Windows.Forms.Label();
            this.videoHNud = new System.Windows.Forms.NumericUpDown();
            this.videoHLabel = new System.Windows.Forms.Label();
            this.videoSetBox = new System.Windows.Forms.GroupBox();
            this.isDisplayCursorCb = new System.Windows.Forms.CheckBox();
            this.videoFrameNud = new System.Windows.Forms.NumericUpDown();
            this.videoFrameLabel = new System.Windows.Forms.Label();
            this.videoQualityNud = new System.Windows.Forms.NumericUpDown();
            this.videoQualityLabel = new System.Windows.Forms.Label();
            this.userCountLinkLabel = new System.Windows.Forms.LinkLabel();
            this.bottomPanel = new System.Windows.Forms.Panel();
            this.fpsLabel = new System.Windows.Forms.Label();
            this.previewLabel = new System.Windows.Forms.Label();
            this.previewImg = new System.Windows.Forms.PictureBox();
            this.startBtn = new System.Windows.Forms.Button();
            this.logText = new System.Windows.Forms.TextBox();
            this.clearLogLinkLabel = new System.Windows.Forms.LinkLabel();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.topPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ipPortNud)).BeginInit();
            this.middlePanel.SuspendLayout();
            this.encryptionBox.SuspendLayout();
            this.coordinatesBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.screenXNud)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.screenYNud)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.screenWNud)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.screenHNud)).BeginInit();
            this.videoOptionBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scalingNud)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.videoWNud)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.videoHNud)).BeginInit();
            this.videoSetBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.videoFrameNud)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.videoQualityNud)).BeginInit();
            this.bottomPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.previewImg)).BeginInit();
            this.SuspendLayout();
            // 
            // topPanel
            // 
            this.topPanel.Controls.Add(this.titleLabel);
            this.topPanel.Controls.Add(this.ipAddressComboBox);
            this.topPanel.Controls.Add(this.ipAddressLabel);
            this.topPanel.Controls.Add(this.ipPortNud);
            this.topPanel.Controls.Add(this.ipPortLabel);
            this.topPanel.Controls.Add(this.shareLinkText);
            this.topPanel.Controls.Add(this.shareLinkLabel);
            this.topPanel.Controls.Add(this.copyBtn);
            this.topPanel.Controls.Add(this.reloadConfigBtn);
            this.topPanel.Controls.Add(this.openBtn);
            this.topPanel.Controls.Add(this.configBtn);
            this.topPanel.Controls.Add(this.qrBtn);
            this.topPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.topPanel.Location = new System.Drawing.Point(0, 0);
            this.topPanel.Name = "topPanel";
            this.topPanel.Size = new System.Drawing.Size(768, 110);
            this.topPanel.TabIndex = 2;
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Font = new System.Drawing.Font("宋体", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.titleLabel.Location = new System.Drawing.Point(322, 10);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(124, 27);
            this.titleLabel.TabIndex = 0;
            this.titleLabel.Text = "屏幕共享";
            // 
            // ipAddressComboBox
            // 
            this.ipAddressComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ipAddressComboBox.FormattingEnabled = true;
            this.ipAddressComboBox.Location = new System.Drawing.Point(70, 50);
            this.ipAddressComboBox.Name = "ipAddressComboBox";
            this.ipAddressComboBox.Size = new System.Drawing.Size(350, 20);
            this.ipAddressComboBox.TabIndex = 1;
            this.ipAddressComboBox.SelectedValueChanged += new System.EventHandler(this.IpAddressComboBox_SelectedValueChanged);
            // 
            // ipAddressLabel
            // 
            this.ipAddressLabel.AutoSize = true;
            this.ipAddressLabel.Location = new System.Drawing.Point(20, 54);
            this.ipAddressLabel.Name = "ipAddressLabel";
            this.ipAddressLabel.Size = new System.Drawing.Size(53, 12);
            this.ipAddressLabel.TabIndex = 0;
            this.ipAddressLabel.Text = "IP地址：";
            // 
            // ipPortNud
            // 
            this.ipPortNud.Location = new System.Drawing.Point(480, 50);
            this.ipPortNud.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.ipPortNud.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.ipPortNud.Name = "ipPortNud";
            this.ipPortNud.Size = new System.Drawing.Size(80, 21);
            this.ipPortNud.TabIndex = 2;
            this.ipPortNud.Value = new decimal(new int[] {
            7070,
            0,
            0,
            0});
            this.ipPortNud.ValueChanged += new System.EventHandler(this.IpPortNud_ValueChanged);
            // 
            // ipPortLabel
            // 
            this.ipPortLabel.AutoSize = true;
            this.ipPortLabel.Location = new System.Drawing.Point(430, 54);
            this.ipPortLabel.Name = "ipPortLabel";
            this.ipPortLabel.Size = new System.Drawing.Size(53, 12);
            this.ipPortLabel.TabIndex = 0;
            this.ipPortLabel.Text = "端口号：";
            // 
            // shareLinkText
            // 
            this.shareLinkText.BackColor = System.Drawing.SystemColors.Window;
            this.shareLinkText.Location = new System.Drawing.Point(70, 80);
            this.shareLinkText.Multiline = true;
            this.shareLinkText.Name = "shareLinkText";
            this.shareLinkText.ReadOnly = true;
            this.shareLinkText.Size = new System.Drawing.Size(440, 21);
            this.shareLinkText.TabIndex = 3;
            // 
            // shareLinkLabel
            // 
            this.shareLinkLabel.AutoSize = true;
            this.shareLinkLabel.Location = new System.Drawing.Point(8, 84);
            this.shareLinkLabel.Name = "shareLinkLabel";
            this.shareLinkLabel.Size = new System.Drawing.Size(65, 12);
            this.shareLinkLabel.TabIndex = 0;
            this.shareLinkLabel.Text = "分享地址：";
            // 
            // copyBtn
            // 
            this.copyBtn.Location = new System.Drawing.Point(515, 80);
            this.copyBtn.Name = "copyBtn";
            this.copyBtn.Size = new System.Drawing.Size(45, 23);
            this.copyBtn.TabIndex = 4;
            this.copyBtn.Text = "复制";
            this.copyBtn.UseVisualStyleBackColor = true;
            this.copyBtn.Click += new System.EventHandler(this.CopyBtn_Click);
            // 
            // reloadConfigBtn
            // 
            this.reloadConfigBtn.Location = new System.Drawing.Point(565, 50);
            this.reloadConfigBtn.Name = "reloadConfigBtn";
            this.reloadConfigBtn.Size = new System.Drawing.Size(100, 23);
            this.reloadConfigBtn.TabIndex = 5;
            this.reloadConfigBtn.Text = "重新加载配置";
            this.reloadConfigBtn.UseVisualStyleBackColor = true;
            this.reloadConfigBtn.Click += new System.EventHandler(this.ReloadConfigBtn_Click);
            // 
            // openBtn
            // 
            this.openBtn.Location = new System.Drawing.Point(565, 80);
            this.openBtn.Name = "openBtn";
            this.openBtn.Size = new System.Drawing.Size(100, 23);
            this.openBtn.TabIndex = 6;
            this.openBtn.Text = "用浏览器打开";
            this.openBtn.UseVisualStyleBackColor = true;
            this.openBtn.Click += new System.EventHandler(this.OpenBtn_Click);
            // 
            // configBtn
            // 
            this.configBtn.Location = new System.Drawing.Point(670, 50);
            this.configBtn.Name = "configBtn";
            this.configBtn.Size = new System.Drawing.Size(90, 23);
            this.configBtn.TabIndex = 7;
            this.configBtn.Text = "系统配置";
            this.configBtn.UseVisualStyleBackColor = true;
            this.configBtn.Click += new System.EventHandler(this.ConfigBtn_Click);
            // 
            // qrBtn
            // 
            this.qrBtn.Location = new System.Drawing.Point(670, 80);
            this.qrBtn.Name = "qrBtn";
            this.qrBtn.Size = new System.Drawing.Size(90, 23);
            this.qrBtn.TabIndex = 8;
            this.qrBtn.Text = "网站二维码";
            this.qrBtn.UseVisualStyleBackColor = true;
            this.qrBtn.Click += new System.EventHandler(this.QrBtn_Click);
            // 
            // middlePanel
            // 
            this.middlePanel.Controls.Add(this.encryptionBox);
            this.middlePanel.Controls.Add(this.coordinatesBox);
            this.middlePanel.Controls.Add(this.videoOptionBox);
            this.middlePanel.Controls.Add(this.videoSetBox);
            this.middlePanel.Controls.Add(this.userCountLinkLabel);
            this.middlePanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.middlePanel.Location = new System.Drawing.Point(0, 110);
            this.middlePanel.Name = "middlePanel";
            this.middlePanel.Size = new System.Drawing.Size(768, 110);
            this.middlePanel.TabIndex = 3;
            // 
            // encryptionBox
            // 
            this.encryptionBox.Controls.Add(this.isEncryptionCb);
            this.encryptionBox.Controls.Add(this.pwdText);
            this.encryptionBox.Controls.Add(this.pwdLabel);
            this.encryptionBox.Location = new System.Drawing.Point(10, 10);
            this.encryptionBox.Name = "encryptionBox";
            this.encryptionBox.Size = new System.Drawing.Size(140, 70);
            this.encryptionBox.TabIndex = 1;
            this.encryptionBox.TabStop = false;
            this.encryptionBox.Text = "密码验证";
            // 
            // isEncryptionCb
            // 
            this.isEncryptionCb.AutoSize = true;
            this.isEncryptionCb.Location = new System.Drawing.Point(10, 20);
            this.isEncryptionCb.Name = "isEncryptionCb";
            this.isEncryptionCb.Size = new System.Drawing.Size(48, 16);
            this.isEncryptionCb.TabIndex = 1;
            this.isEncryptionCb.Text = "开启";
            this.isEncryptionCb.UseVisualStyleBackColor = true;
            this.isEncryptionCb.CheckStateChanged += new System.EventHandler(this.IsEncryptionCb_CheckStateChanged);
            // 
            // pwdText
            // 
            this.pwdText.Enabled = false;
            this.pwdText.Location = new System.Drawing.Point(50, 40);
            this.pwdText.Name = "pwdText";
            this.pwdText.Size = new System.Drawing.Size(80, 21);
            this.pwdText.TabIndex = 2;
            // 
            // pwdLabel
            // 
            this.pwdLabel.AutoSize = true;
            this.pwdLabel.Location = new System.Drawing.Point(12, 44);
            this.pwdLabel.Name = "pwdLabel";
            this.pwdLabel.Size = new System.Drawing.Size(41, 12);
            this.pwdLabel.TabIndex = 0;
            this.pwdLabel.Text = "密码：";
            // 
            // coordinatesBox
            // 
            this.coordinatesBox.Controls.Add(this.isFullScreenCb);
            this.coordinatesBox.Controls.Add(this.screenComboBox);
            this.coordinatesBox.Controls.Add(this.screenLabel);
            this.coordinatesBox.Controls.Add(this.screenXNud);
            this.coordinatesBox.Controls.Add(this.screenXLabel);
            this.coordinatesBox.Controls.Add(this.screenYNud);
            this.coordinatesBox.Controls.Add(this.screenYLabel);
            this.coordinatesBox.Controls.Add(this.screenWNud);
            this.coordinatesBox.Controls.Add(this.screenWLabel);
            this.coordinatesBox.Controls.Add(this.screenHNud);
            this.coordinatesBox.Controls.Add(this.screenHLabel);
            this.coordinatesBox.Controls.Add(this.captureScreenCoordinatesBtn);
            this.coordinatesBox.Location = new System.Drawing.Point(160, 10);
            this.coordinatesBox.Name = "coordinatesBox";
            this.coordinatesBox.Size = new System.Drawing.Size(265, 100);
            this.coordinatesBox.TabIndex = 2;
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
            // screenComboBox
            // 
            this.screenComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.screenComboBox.FormattingEnabled = true;
            this.screenComboBox.Location = new System.Drawing.Point(125, 16);
            this.screenComboBox.Name = "screenComboBox";
            this.screenComboBox.Size = new System.Drawing.Size(130, 20);
            this.screenComboBox.TabIndex = 2;
            this.screenComboBox.SelectedValueChanged += new System.EventHandler(this.ScreenComboBox_SelectedValueChanged);
            // 
            // screenLabel
            // 
            this.screenLabel.AutoSize = true;
            this.screenLabel.Location = new System.Drawing.Point(75, 20);
            this.screenLabel.Name = "screenLabel";
            this.screenLabel.Size = new System.Drawing.Size(53, 12);
            this.screenLabel.TabIndex = 0;
            this.screenLabel.Text = "显示器：";
            // 
            // screenXNud
            // 
            this.screenXNud.Enabled = false;
            this.screenXNud.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.screenXNud.Location = new System.Drawing.Point(30, 40);
            this.screenXNud.Maximum = new decimal(new int[] {
            1919,
            0,
            0,
            0});
            this.screenXNud.Name = "screenXNud";
            this.screenXNud.Size = new System.Drawing.Size(50, 21);
            this.screenXNud.TabIndex = 3;
            this.screenXNud.ValueChanged += new System.EventHandler(this.ScreenXNud_ValueChanged);
            // 
            // screenXLabel
            // 
            this.screenXLabel.AutoSize = true;
            this.screenXLabel.Location = new System.Drawing.Point(10, 44);
            this.screenXLabel.Name = "screenXLabel";
            this.screenXLabel.Size = new System.Drawing.Size(23, 12);
            this.screenXLabel.TabIndex = 0;
            this.screenXLabel.Text = "X：";
            // 
            // screenYNud
            // 
            this.screenYNud.Enabled = false;
            this.screenYNud.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.screenYNud.Location = new System.Drawing.Point(30, 70);
            this.screenYNud.Maximum = new decimal(new int[] {
            1079,
            0,
            0,
            0});
            this.screenYNud.Name = "screenYNud";
            this.screenYNud.Size = new System.Drawing.Size(50, 21);
            this.screenYNud.TabIndex = 4;
            this.screenYNud.ValueChanged += new System.EventHandler(this.ScreenYNud_ValueChanged);
            // 
            // screenYLabel
            // 
            this.screenYLabel.AutoSize = true;
            this.screenYLabel.Location = new System.Drawing.Point(10, 74);
            this.screenYLabel.Name = "screenYLabel";
            this.screenYLabel.Size = new System.Drawing.Size(23, 12);
            this.screenYLabel.TabIndex = 0;
            this.screenYLabel.Text = "Y：";
            // 
            // screenWNud
            // 
            this.screenWNud.Enabled = false;
            this.screenWNud.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.screenWNud.Location = new System.Drawing.Point(120, 40);
            this.screenWNud.Maximum = new decimal(new int[] {
            1920,
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
            this.screenWNud.Value = new decimal(new int[] {
            1920,
            0,
            0,
            0});
            this.screenWNud.ValueChanged += new System.EventHandler(this.ScreenWNud_ValueChanged);
            // 
            // screenWLabel
            // 
            this.screenWLabel.AutoSize = true;
            this.screenWLabel.Location = new System.Drawing.Point(94, 44);
            this.screenWLabel.Name = "screenWLabel";
            this.screenWLabel.Size = new System.Drawing.Size(29, 12);
            this.screenWLabel.TabIndex = 0;
            this.screenWLabel.Text = "宽：";
            // 
            // screenHNud
            // 
            this.screenHNud.Enabled = false;
            this.screenHNud.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.screenHNud.Location = new System.Drawing.Point(120, 70);
            this.screenHNud.Maximum = new decimal(new int[] {
            1080,
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
            this.screenHNud.Value = new decimal(new int[] {
            1080,
            0,
            0,
            0});
            this.screenHNud.ValueChanged += new System.EventHandler(this.ScreenHNud_ValueChanged);
            // 
            // screenHLabel
            // 
            this.screenHLabel.AutoSize = true;
            this.screenHLabel.Location = new System.Drawing.Point(94, 74);
            this.screenHLabel.Name = "screenHLabel";
            this.screenHLabel.Size = new System.Drawing.Size(29, 12);
            this.screenHLabel.TabIndex = 0;
            this.screenHLabel.Text = "高：";
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
            // videoOptionBox
            // 
            this.videoOptionBox.Controls.Add(this.isLockAspectRatioCb);
            this.videoOptionBox.Controls.Add(this.scalingNud);
            this.videoOptionBox.Controls.Add(this.scalingLabel);
            this.videoOptionBox.Controls.Add(this.videoWNud);
            this.videoOptionBox.Controls.Add(this.videoWLabel);
            this.videoOptionBox.Controls.Add(this.videoHNud);
            this.videoOptionBox.Controls.Add(this.videoHLabel);
            this.videoOptionBox.Location = new System.Drawing.Point(435, 10);
            this.videoOptionBox.Name = "videoOptionBox";
            this.videoOptionBox.Size = new System.Drawing.Size(185, 100);
            this.videoOptionBox.TabIndex = 3;
            this.videoOptionBox.TabStop = false;
            this.videoOptionBox.Text = "视频尺寸";
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
            // scalingNud
            // 
            this.scalingNud.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.scalingNud.Location = new System.Drawing.Point(70, 40);
            this.scalingNud.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.scalingNud.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.scalingNud.Name = "scalingNud";
            this.scalingNud.Size = new System.Drawing.Size(50, 21);
            this.scalingNud.TabIndex = 2;
            this.scalingNud.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.scalingNud.ValueChanged += new System.EventHandler(this.ScalingNud_ValueChanged);
            // 
            // scalingLabel
            // 
            this.scalingLabel.AutoSize = true;
            this.scalingLabel.Location = new System.Drawing.Point(8, 44);
            this.scalingLabel.Name = "scalingLabel";
            this.scalingLabel.Size = new System.Drawing.Size(65, 12);
            this.scalingLabel.TabIndex = 0;
            this.scalingLabel.Text = "缩放比例：";
            // 
            // videoWNud
            // 
            this.videoWNud.Enabled = false;
            this.videoWNud.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
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
            // videoWLabel
            // 
            this.videoWLabel.AutoSize = true;
            this.videoWLabel.Location = new System.Drawing.Point(9, 74);
            this.videoWLabel.Name = "videoWLabel";
            this.videoWLabel.Size = new System.Drawing.Size(29, 12);
            this.videoWLabel.TabIndex = 0;
            this.videoWLabel.Text = "宽：";
            // 
            // videoHNud
            // 
            this.videoHNud.Enabled = false;
            this.videoHNud.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
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
            // videoHLabel
            // 
            this.videoHLabel.AutoSize = true;
            this.videoHLabel.Location = new System.Drawing.Point(99, 74);
            this.videoHLabel.Name = "videoHLabel";
            this.videoHLabel.Size = new System.Drawing.Size(29, 12);
            this.videoHLabel.TabIndex = 0;
            this.videoHLabel.Text = "高：";
            // 
            // videoSetBox
            // 
            this.videoSetBox.Controls.Add(this.isDisplayCursorCb);
            this.videoSetBox.Controls.Add(this.videoFrameNud);
            this.videoSetBox.Controls.Add(this.videoFrameLabel);
            this.videoSetBox.Controls.Add(this.videoQualityNud);
            this.videoSetBox.Controls.Add(this.videoQualityLabel);
            this.videoSetBox.Location = new System.Drawing.Point(630, 10);
            this.videoSetBox.Name = "videoSetBox";
            this.videoSetBox.Size = new System.Drawing.Size(130, 100);
            this.videoSetBox.TabIndex = 4;
            this.videoSetBox.TabStop = false;
            this.videoSetBox.Text = "视频设置";
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
            // videoFrameNud
            // 
            this.videoFrameNud.Location = new System.Drawing.Point(70, 40);
            this.videoFrameNud.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.videoFrameNud.Name = "videoFrameNud";
            this.videoFrameNud.Size = new System.Drawing.Size(50, 21);
            this.videoFrameNud.TabIndex = 2;
            this.toolTip.SetToolTip(this.videoFrameNud, "每秒刷新次数，数字越大越流畅\r\n为0时以最快速度刷新");
            this.videoFrameNud.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // videoFrameLabel
            // 
            this.videoFrameLabel.AutoSize = true;
            this.videoFrameLabel.Location = new System.Drawing.Point(8, 44);
            this.videoFrameLabel.Name = "videoFrameLabel";
            this.videoFrameLabel.Size = new System.Drawing.Size(65, 12);
            this.videoFrameLabel.TabIndex = 0;
            this.videoFrameLabel.Text = "每秒帧数：";
            // 
            // videoQualityNud
            // 
            this.videoQualityNud.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.videoQualityNud.Location = new System.Drawing.Point(70, 70);
            this.videoQualityNud.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.videoQualityNud.Name = "videoQualityNud";
            this.videoQualityNud.Size = new System.Drawing.Size(50, 21);
            this.videoQualityNud.TabIndex = 3;
            this.toolTip.SetToolTip(this.videoQualityNud, "视频清晰度，数字越大越清晰");
            this.videoQualityNud.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // videoQualityLabel
            // 
            this.videoQualityLabel.AutoSize = true;
            this.videoQualityLabel.Location = new System.Drawing.Point(8, 74);
            this.videoQualityLabel.Name = "videoQualityLabel";
            this.videoQualityLabel.Size = new System.Drawing.Size(65, 12);
            this.videoQualityLabel.TabIndex = 0;
            this.videoQualityLabel.Text = "视频质量：";
            // 
            // userCountLinkLabel
            // 
            this.userCountLinkLabel.AutoSize = true;
            this.userCountLinkLabel.Location = new System.Drawing.Point(10, 90);
            this.userCountLinkLabel.Name = "userCountLinkLabel";
            this.userCountLinkLabel.Size = new System.Drawing.Size(119, 12);
            this.userCountLinkLabel.TabIndex = 5;
            this.userCountLinkLabel.TabStop = true;
            this.userCountLinkLabel.Text = "当前在线用户数量：0";
            this.userCountLinkLabel.Click += new System.EventHandler(this.UserCountLinkLabel_Click);
            // 
            // bottomPanel
            // 
            this.bottomPanel.Controls.Add(this.fpsLabel);
            this.bottomPanel.Controls.Add(this.previewLabel);
            this.bottomPanel.Controls.Add(this.previewImg);
            this.bottomPanel.Controls.Add(this.startBtn);
            this.bottomPanel.Controls.Add(this.logText);
            this.bottomPanel.Controls.Add(this.clearLogLinkLabel);
            this.bottomPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bottomPanel.Location = new System.Drawing.Point(0, 220);
            this.bottomPanel.Name = "bottomPanel";
            this.bottomPanel.Size = new System.Drawing.Size(768, 212);
            this.bottomPanel.TabIndex = 1;
            // 
            // fpsLabel
            // 
            this.fpsLabel.AutoSize = true;
            this.fpsLabel.BackColor = System.Drawing.Color.Transparent;
            this.fpsLabel.ForeColor = System.Drawing.Color.Red;
            this.fpsLabel.Location = new System.Drawing.Point(10, 10);
            this.fpsLabel.Name = "fpsLabel";
            this.fpsLabel.Size = new System.Drawing.Size(59, 12);
            this.fpsLabel.TabIndex = 4;
            this.fpsLabel.Text = "0.00 FPS ";
            // 
            // previewLabel
            // 
            this.previewLabel.AutoSize = true;
            this.previewLabel.Location = new System.Drawing.Point(555, 100);
            this.previewLabel.Name = "previewLabel";
            this.previewLabel.Size = new System.Drawing.Size(77, 12);
            this.previewLabel.TabIndex = 0;
            this.previewLabel.Text = "点击此处预览";
            this.previewLabel.Visible = false;
            this.previewLabel.Click += new System.EventHandler(this.PreviewLabel_Click);
            // 
            // previewImg
            // 
            this.previewImg.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.previewImg.Location = new System.Drawing.Point(438, 18);
            this.previewImg.Margin = new System.Windows.Forms.Padding(0);
            this.previewImg.Name = "previewImg";
            this.previewImg.Size = new System.Drawing.Size(322, 182);
            this.previewImg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.previewImg.TabIndex = 0;
            this.previewImg.TabStop = false;
            this.previewImg.Click += new System.EventHandler(this.PreviewImg_Click);
            // 
            // startBtn
            // 
            this.startBtn.Font = new System.Drawing.Font("宋体", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.startBtn.Location = new System.Drawing.Point(125, 10);
            this.startBtn.Name = "startBtn";
            this.startBtn.Size = new System.Drawing.Size(185, 40);
            this.startBtn.TabIndex = 1;
            this.startBtn.Text = "开始共享";
            this.startBtn.UseVisualStyleBackColor = true;
            this.startBtn.Click += new System.EventHandler(this.StartSharingScreenBtn_Click);
            // 
            // logText
            // 
            this.logText.BackColor = System.Drawing.SystemColors.Window;
            this.logText.Location = new System.Drawing.Point(10, 60);
            this.logText.Multiline = true;
            this.logText.Name = "logText";
            this.logText.ReadOnly = true;
            this.logText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.logText.Size = new System.Drawing.Size(415, 140);
            this.logText.TabIndex = 3;
            // 
            // clearLogLinkLabel
            // 
            this.clearLogLinkLabel.AutoSize = true;
            this.clearLogLinkLabel.Location = new System.Drawing.Point(360, 40);
            this.clearLogLinkLabel.Name = "clearLogLinkLabel";
            this.clearLogLinkLabel.Size = new System.Drawing.Size(53, 12);
            this.clearLogLinkLabel.TabIndex = 2;
            this.clearLogLinkLabel.TabStop = true;
            this.clearLogLinkLabel.Text = "清空日志";
            this.clearLogLinkLabel.Click += new System.EventHandler(this.ClearLogLinkLabel_Click);
            // 
            // notifyIcon
            // 
            this.notifyIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyIcon.Icon = global::ScreenShare.Properties.Resources.icon;
            this.notifyIcon.Text = "屏幕共享";
            this.notifyIcon.Click += new System.EventHandler(this.NotifyIcon_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(768, 432);
            this.Controls.Add(this.topPanel);
            this.Controls.Add(this.middlePanel);
            this.Controls.Add(this.bottomPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = global::ScreenShare.Properties.Resources.icon;
            this.MaximizeBox = false;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "屏幕共享";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            this.topPanel.ResumeLayout(false);
            this.topPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ipPortNud)).EndInit();
            this.middlePanel.ResumeLayout(false);
            this.middlePanel.PerformLayout();
            this.encryptionBox.ResumeLayout(false);
            this.encryptionBox.PerformLayout();
            this.coordinatesBox.ResumeLayout(false);
            this.coordinatesBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.screenXNud)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.screenYNud)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.screenWNud)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.screenHNud)).EndInit();
            this.videoOptionBox.ResumeLayout(false);
            this.videoOptionBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scalingNud)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.videoWNud)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.videoHNud)).EndInit();
            this.videoSetBox.ResumeLayout(false);
            this.videoSetBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.videoFrameNud)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.videoQualityNud)).EndInit();
            this.bottomPanel.ResumeLayout(false);
            this.bottomPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.previewImg)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        /* 头部 */
        /// <summary>
        /// 头部Panel
        /// </summary>
        private System.Windows.Forms.Panel topPanel;
        /// <summary>
        /// 标题Label
        /// </summary>
        private System.Windows.Forms.Label titleLabel;
        /// <summary>
        /// IP地址Label
        /// </summary>
        private System.Windows.Forms.Label ipAddressLabel;
        /// <summary>
        /// IP地址ComboBox
        /// </summary>
        private System.Windows.Forms.ComboBox ipAddressComboBox;
        /// <summary>
        /// 端口号Label
        /// </summary>
        private System.Windows.Forms.Label ipPortLabel;
        /// <summary>
        /// IP地址NumericUpDown
        /// </summary>
        private System.Windows.Forms.NumericUpDown ipPortNud;
        /// <summary>
        /// 分享地址Label
        /// </summary>
        private System.Windows.Forms.Label shareLinkLabel;
        /// <summary>
        /// 分享地址TextBox
        /// </summary>
        private System.Windows.Forms.TextBox shareLinkText;
        /// <summary>
        /// 复制Button
        /// </summary>
        private System.Windows.Forms.Button copyBtn;
        /// <summary>
        /// 用浏览器打开Button
        /// </summary>
        private System.Windows.Forms.Button openBtn;
        /// <summary>
        /// 重新加载配置Button
        /// </summary>
        private System.Windows.Forms.Button reloadConfigBtn;
        /// <summary>
        /// 系统配置Button
        /// </summary>
        private System.Windows.Forms.Button configBtn;
        /// <summary>
        /// 网站二维码Button
        /// </summary>
        private System.Windows.Forms.Button qrBtn;

        /* 中部 */
        /// <summary>
        /// 中部Panel
        /// </summary>
        private System.Windows.Forms.Panel middlePanel;

        /* 密码验证GroupBox */
        /// <summary>
        /// 密码验证GroupBox
        /// </summary>
        private System.Windows.Forms.GroupBox encryptionBox;
        /// <summary>
        /// 开启CheckBox
        /// </summary>
        private System.Windows.Forms.CheckBox isEncryptionCb;
        /// <summary>
        /// 密码Label
        /// </summary>
        private System.Windows.Forms.Label pwdLabel;
        /// <summary>
        /// 密码TextBox
        /// </summary>
        private System.Windows.Forms.TextBox pwdText;

        /* 选取位置GroupBox */
        /// <summary>
        /// 选取位置GroupBox
        /// </summary>
        private System.Windows.Forms.GroupBox coordinatesBox;
        /// <summary>
        /// 全屏CheckBox
        /// </summary>
        private System.Windows.Forms.CheckBox isFullScreenCb;
        /// <summary>
        /// 显示器Label
        /// </summary>
        private System.Windows.Forms.Label screenLabel;
        /// <summary>
        /// 显示器ComboBox
        /// </summary>
        private System.Windows.Forms.ComboBox screenComboBox;
        /// <summary>
        /// X Label
        /// </summary>
        private System.Windows.Forms.Label screenXLabel;
        /// <summary>
        /// X NumericUpDown
        /// </summary>
        private System.Windows.Forms.NumericUpDown screenXNud;
        /// <summary>
        /// Y Label
        /// </summary>
        private System.Windows.Forms.Label screenYLabel;
        /// <summary>
        /// Y NumericUpDown
        /// </summary>
        private System.Windows.Forms.NumericUpDown screenYNud;
        /// <summary>
        /// 宽Label
        /// </summary>
        private System.Windows.Forms.Label screenWLabel;
        /// <summary>
        /// 宽NumericUpDown
        /// </summary>
        private System.Windows.Forms.NumericUpDown screenWNud;
        /// <summary>
        /// 高Label
        /// </summary>
        private System.Windows.Forms.Label screenHLabel;
        /// <summary>
        /// 高NumericUpDown
        /// </summary>
        private System.Windows.Forms.NumericUpDown screenHNud;
        /// <summary>
        /// 选取屏幕坐标Button
        /// </summary>
        private System.Windows.Forms.Button captureScreenCoordinatesBtn;

        /* 视频选项GroupBox */
        /// <summary>
        /// 视频选项GroupBox
        /// </summary>
        private System.Windows.Forms.GroupBox videoOptionBox;
        /// <summary>
        /// 锁定纵横比CheckBox
        /// </summary>
        private System.Windows.Forms.CheckBox isLockAspectRatioCb;
        /// <summary>
        /// 缩放比例Label
        /// </summary>
        private System.Windows.Forms.Label scalingLabel;
        /// <summary>
        /// 缩放比例NumericUpDown
        /// </summary>
        private System.Windows.Forms.NumericUpDown scalingNud;
        /// <summary>
        /// 宽Label
        /// </summary>
        private System.Windows.Forms.Label videoWLabel;
        /// <summary>
        /// 宽NumericUpDown
        /// </summary>
        private System.Windows.Forms.NumericUpDown videoWNud;
        /// <summary>
        /// 高Label
        /// </summary>
        private System.Windows.Forms.Label videoHLabel;
        /// <summary>
        /// 高NumericUpDown
        /// </summary>
        private System.Windows.Forms.NumericUpDown videoHNud;

        /* 视频设置GroupBox */
        /// <summary>
        /// 视频设置GroupBox
        /// </summary>
        private System.Windows.Forms.GroupBox videoSetBox;
        /// <summary>
        /// 显示光标CheckBox
        /// </summary>
        private System.Windows.Forms.CheckBox isDisplayCursorCb;
        /// <summary>
        /// 每秒帧数Label
        /// </summary>
        private System.Windows.Forms.Label videoFrameLabel;
        /// <summary>
        /// 每秒帧数NumericUpDown
        /// </summary>
        private System.Windows.Forms.NumericUpDown videoFrameNud;
        /// <summary>
        /// 视频质量Label
        /// </summary>
        private System.Windows.Forms.Label videoQualityLabel;
        /// <summary>
        /// 视频质量NumericUpDown
        /// </summary>
        private System.Windows.Forms.NumericUpDown videoQualityNud;

        /// <summary>
        /// 当前在线用户数量LinkLabel
        /// </summary>
        private System.Windows.Forms.LinkLabel userCountLinkLabel;

        /* 底部 */
        /// <summary>
        /// 底部Panel
        /// </summary>
        private System.Windows.Forms.Panel bottomPanel;
        /// <summary>
        /// 开始Button
        /// </summary>
        private System.Windows.Forms.Button startBtn;
        /// <summary>
        /// 日志TextBox
        /// </summary>
        private System.Windows.Forms.TextBox logText;
        /// <summary>
        /// FPS Label
        /// </summary>
        private System.Windows.Forms.Label fpsLabel;
        /// <summary>
        /// 清空日志LinkLabel
        /// </summary>
        private System.Windows.Forms.LinkLabel clearLogLinkLabel;
        /// <summary>
        /// 预览Label
        /// </summary>
        private System.Windows.Forms.Label previewLabel;
        /// <summary>
        /// 预览图像PictureBox
        /// </summary>
        private System.Windows.Forms.PictureBox previewImg;

        /* 提示 */
        /// <summary>
        /// 提示ToolTip
        /// </summary>
        private System.Windows.Forms.ToolTip toolTip;

        /* 通知 */
        /// <summary>
        /// 通知NotifyIcon
        /// </summary>
        private System.Windows.Forms.NotifyIcon notifyIcon;

    }
}
