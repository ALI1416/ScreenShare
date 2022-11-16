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
            this.screenLabel = new System.Windows.Forms.Label();
            this.screenComboBox = new System.Windows.Forms.ComboBox();
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
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
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
            this.ipAddressComboBox.Size = new System.Drawing.Size(350, 20);
            this.ipAddressComboBox.TabIndex = 2;
            this.toolTip.SetToolTip(this.ipAddressComboBox, "请选择分享IP地址");
            this.ipAddressComboBox.SelectedValueChanged += new System.EventHandler(this.IpAddressComboBox_SelectedValueChanged);
            // 
            // ipPortLabel
            // 
            this.ipPortLabel.AutoSize = true;
            this.ipPortLabel.Location = new System.Drawing.Point(424, 54);
            this.ipPortLabel.Name = "ipPortLabel";
            this.ipPortLabel.Size = new System.Drawing.Size(53, 12);
            this.ipPortLabel.TabIndex = 0;
            this.ipPortLabel.Text = "端口号：";
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
            this.ipPortNud.TabIndex = 3;
            this.toolTip.SetToolTip(this.ipPortNud, "IP地址对应的端口号");
            this.ipPortNud.Value = new decimal(new int[] {
            7070,
            0,
            0,
            0});
            this.ipPortNud.ValueChanged += new System.EventHandler(this.IpPortNud_ValueChanged);
            // 
            // reloadConfigBtn
            // 
            this.reloadConfigBtn.Location = new System.Drawing.Point(565, 50);
            this.reloadConfigBtn.Name = "reloadConfigBtn";
            this.reloadConfigBtn.Size = new System.Drawing.Size(90, 23);
            this.reloadConfigBtn.TabIndex = 4;
            this.reloadConfigBtn.Text = "重新加载配置";
            this.reloadConfigBtn.UseVisualStyleBackColor = true;
            this.reloadConfigBtn.Click += new System.EventHandler(this.ReloadConfigBtn_Click);
            // 
            // aboutBtn
            // 
            this.aboutBtn.Location = new System.Drawing.Point(705, 50);
            this.aboutBtn.Name = "aboutBtn";
            this.aboutBtn.Size = new System.Drawing.Size(55, 53);
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
            this.shareLinkText.Size = new System.Drawing.Size(440, 21);
            this.shareLinkText.TabIndex = 6;
            // 
            // copyBtn
            // 
            this.copyBtn.Location = new System.Drawing.Point(515, 80);
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
            this.openBtn.Location = new System.Drawing.Point(565, 80);
            this.openBtn.Name = "openBtn";
            this.openBtn.Size = new System.Drawing.Size(90, 23);
            this.openBtn.TabIndex = 8;
            this.openBtn.Text = "用浏览器打开";
            this.openBtn.UseVisualStyleBackColor = true;
            this.openBtn.Click += new System.EventHandler(this.OpenBtn_Click);
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
            this.isEncryptionCb.Size = new System.Drawing.Size(72, 16);
            this.isEncryptionCb.TabIndex = 1;
            this.isEncryptionCb.Text = "开启加密";
            this.toolTip.SetToolTip(this.isEncryptionCb, "开启后需要输入账号密码才能访问");
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
            this.toolTip.SetToolTip(this.accountText, "请输入账号");
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
            this.toolTip.SetToolTip(this.pwdText, "请输入密码");
            // 
            // coordinatesBox
            // 
            this.coordinatesBox.Controls.Add(this.isFullScreenCb);
            this.coordinatesBox.Controls.Add(this.screenLabel);
            this.coordinatesBox.Controls.Add(this.screenComboBox);
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
            this.toolTip.SetToolTip(this.isFullScreenCb, "是否选择全屏共享");
            this.isFullScreenCb.UseVisualStyleBackColor = true;
            this.isFullScreenCb.CheckStateChanged += new System.EventHandler(this.IsFullScreenCb_CheckStateChanged);
            // 
            // screenLabel
            // 
            this.screenLabel.AutoSize = true;
            this.screenLabel.Location = new System.Drawing.Point(69, 20);
            this.screenLabel.Name = "screenLabel";
            this.screenLabel.Size = new System.Drawing.Size(53, 12);
            this.screenLabel.TabIndex = 0;
            this.screenLabel.Text = "显示器：";
            // 
            // screenComboBox
            // 
            this.screenComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.screenComboBox.FormattingEnabled = true;
            this.screenComboBox.Location = new System.Drawing.Point(125, 16);
            this.screenComboBox.Name = "screenComboBox";
            this.screenComboBox.Size = new System.Drawing.Size(130, 20);
            this.screenComboBox.TabIndex = 2;
            this.toolTip.SetToolTip(this.screenComboBox, "请选择要共享的显示器");
            this.screenComboBox.SelectedValueChanged += new System.EventHandler(this.ScreenComboBox_SelectedValueChanged);
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
            this.toolTip.SetToolTip(this.screenXNud, "选取矩形左上角的横坐标X");
            this.screenXNud.ValueChanged += new System.EventHandler(this.ScreenXNud_ValueChanged);
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
            this.toolTip.SetToolTip(this.screenYNud, "选取矩形左上角的纵坐标Y");
            this.screenYNud.ValueChanged += new System.EventHandler(this.ScreenYNud_ValueChanged);
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
            this.toolTip.SetToolTip(this.isLockAspectRatioCb, "锁定纵横比");
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
            this.toolTip.SetToolTip(this.scalingNud, "相对于选取的矩形的缩放比例");
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
            this.toolTip.SetToolTip(this.videoWNud, "视频宽");
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
            this.toolTip.SetToolTip(this.videoHNud, "视频高");
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
            this.toolTip.SetToolTip(this.isDisplayCursorCb, "是否显示光标");
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
            this.toolTip.SetToolTip(this.videoFrameNud, "每秒刷新次数，数字越大越流畅");
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
            this.previewLabel.Visible = false;
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
            // notifyIcon
            // 
            this.notifyIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyIcon.Icon = global::ScreenShare.Properties.Resources.icon;
            this.notifyIcon.Text = "屏幕共享";
            this.notifyIcon.Click += new System.EventHandler(this.NotifyIcon_Click);
            // 
            // ScreenShare
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(768, 432);
            this.Controls.Add(this.previewLabel);
            this.Controls.Add(this.previewImg);
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
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = global::ScreenShare.Properties.Resources.icon;
            this.MaximizeBox = false;
            this.Name = "ScreenShare";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "屏幕共享";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ScreenShare_FormClosing);
            this.SizeChanged += new System.EventHandler(this.ScreenShare_SizeChanged);
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

        /* 头部 */
        /// <summary>
        /// 屏幕共享Label
        /// </summary>
        private System.Windows.Forms.Label shareScreenLabel;
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
        /// 重新加载配置Button
        /// </summary>
        private System.Windows.Forms.Button reloadConfigBtn;
        /// <summary>
        /// 关于Button
        /// </summary>
        private System.Windows.Forms.Button aboutBtn;
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

        /* 加密传输GroupBox */
        /// <summary>
        /// 加密传输GroupBox
        /// </summary>
        private System.Windows.Forms.GroupBox encryptionBox;
        /// <summary>
        /// 开启加密CheckBox
        /// </summary>
        private System.Windows.Forms.CheckBox isEncryptionCb;
        /// <summary>
        /// 账号Label
        /// </summary>
        private System.Windows.Forms.Label accountLabel;
        /// <summary>
        /// 账号TextBox
        /// </summary>
        private System.Windows.Forms.TextBox accountText;
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

        /* 视频尺寸GroupBox */
        /// <summary>
        /// 视频尺寸GroupBox
        /// </summary>
        private System.Windows.Forms.GroupBox scalingBox;
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
        private System.Windows.Forms.GroupBox videoBox;
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

        /* 开始分享按钮 */
        /// <summary>
        /// 开始分享Button
        /// </summary>
        private System.Windows.Forms.Button startSharingScreenBtn;

        /* 日志 */
        /// <summary>
        /// 日志TextBox
        /// </summary>
        private System.Windows.Forms.TextBox logText;

        /* 预览 */
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
