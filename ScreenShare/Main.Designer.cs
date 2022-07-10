using ScreenShare.Properties;

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
            this.ShareScreenLabel = new System.Windows.Forms.Label();
            this.ipAddressLabel = new System.Windows.Forms.Label();
            this.shareLinkLabel = new System.Windows.Forms.Label();
            this.ipPortLabel = new System.Windows.Forms.Label();
            this.videoFrameLabel = new System.Windows.Forms.Label();
            this.isDisplayCursorCb = new System.Windows.Forms.CheckBox();
            this.ipAddressComboBox = new System.Windows.Forms.ComboBox();
            this.ipPortNud = new System.Windows.Forms.NumericUpDown();
            this.shareLinkText = new System.Windows.Forms.TextBox();
            this.aboutBtn = new System.Windows.Forms.Button();
            this.copyBtn = new System.Windows.Forms.Button();
            this.encryptionBox = new System.Windows.Forms.GroupBox();
            this.encryptionPwdText = new System.Windows.Forms.TextBox();
            this.encryptionAccountText = new System.Windows.Forms.TextBox();
            this.encryptionPwdLabel = new System.Windows.Forms.Label();
            this.encryptionAccountLabel = new System.Windows.Forms.Label();
            this.isEncryptionCb = new System.Windows.Forms.CheckBox();
            this.coordinatesBox = new System.Windows.Forms.GroupBox();
            this.screenHNud = new System.Windows.Forms.NumericUpDown();
            this.screenYNud = new System.Windows.Forms.NumericUpDown();
            this.screenWNud = new System.Windows.Forms.NumericUpDown();
            this.captureScreenCoordinatesBtn = new System.Windows.Forms.Button();
            this.screenXNud = new System.Windows.Forms.NumericUpDown();
            this.screenHLabel = new System.Windows.Forms.Label();
            this.screenYLabel = new System.Windows.Forms.Label();
            this.screenXLabel = new System.Windows.Forms.Label();
            this.screenWLabel = new System.Windows.Forms.Label();
            this.isFullScreenCb = new System.Windows.Forms.CheckBox();
            this.videoQualityLabel = new System.Windows.Forms.Label();
            this.scalingBox = new System.Windows.Forms.GroupBox();
            this.videoHNud = new System.Windows.Forms.NumericUpDown();
            this.videoWNud = new System.Windows.Forms.NumericUpDown();
            this.scalingNud = new System.Windows.Forms.NumericUpDown();
            this.videoHLabel = new System.Windows.Forms.Label();
            this.videoWLabel = new System.Windows.Forms.Label();
            this.scalingLabel = new System.Windows.Forms.Label();
            this.isLockAspectRatioCb = new System.Windows.Forms.CheckBox();
            this.startSharingScreenBtn = new System.Windows.Forms.Button();
            this.logText = new System.Windows.Forms.TextBox();
            this.videoBox = new System.Windows.Forms.GroupBox();
            this.videoQualityNud = new System.Windows.Forms.NumericUpDown();
            this.videoFrameNud = new System.Windows.Forms.NumericUpDown();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.previewImg = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.ipPortNud)).BeginInit();
            this.encryptionBox.SuspendLayout();
            this.coordinatesBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.screenHNud)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.screenYNud)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.screenWNud)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.screenXNud)).BeginInit();
            this.scalingBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.videoHNud)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.videoWNud)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.scalingNud)).BeginInit();
            this.videoBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.videoQualityNud)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.videoFrameNud)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.previewImg)).BeginInit();
            this.SuspendLayout();
            // 
            // ShareScreenLabel
            // 
            this.ShareScreenLabel.AutoSize = true;
            this.ShareScreenLabel.Font = new System.Drawing.Font("宋体", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ShareScreenLabel.Location = new System.Drawing.Point(322, 10);
            this.ShareScreenLabel.Name = "ShareScreenLabel";
            this.ShareScreenLabel.Size = new System.Drawing.Size(124, 27);
            this.ShareScreenLabel.TabIndex = 0;
            this.ShareScreenLabel.Text = "屏幕共享";
            // 
            // ipAddressLabel
            // 
            this.ipAddressLabel.AutoSize = true;
            this.ipAddressLabel.Location = new System.Drawing.Point(22, 54);
            this.ipAddressLabel.Name = "ipAddressLabel";
            this.ipAddressLabel.Size = new System.Drawing.Size(53, 12);
            this.ipAddressLabel.TabIndex = 1;
            this.ipAddressLabel.Text = "IP地址：";
            // 
            // shareLinkLabel
            // 
            this.shareLinkLabel.AutoSize = true;
            this.shareLinkLabel.Location = new System.Drawing.Point(10, 84);
            this.shareLinkLabel.Name = "shareLinkLabel";
            this.shareLinkLabel.Size = new System.Drawing.Size(65, 12);
            this.shareLinkLabel.TabIndex = 2;
            this.shareLinkLabel.Text = "分享地址：";
            // 
            // ipPortLabel
            // 
            this.ipPortLabel.AutoSize = true;
            this.ipPortLabel.Location = new System.Drawing.Point(424, 54);
            this.ipPortLabel.Name = "ipPortLabel";
            this.ipPortLabel.Size = new System.Drawing.Size(53, 12);
            this.ipPortLabel.TabIndex = 3;
            this.ipPortLabel.Text = "端口号：";
            // 
            // videoFrameLabel
            // 
            this.videoFrameLabel.AutoSize = true;
            this.videoFrameLabel.Location = new System.Drawing.Point(10, 44);
            this.videoFrameLabel.Name = "videoFrameLabel";
            this.videoFrameLabel.Size = new System.Drawing.Size(65, 12);
            this.videoFrameLabel.TabIndex = 4;
            this.videoFrameLabel.Text = "每秒帧数：";
            // 
            // isDisplayCursorCb
            // 
            this.isDisplayCursorCb.AutoSize = true;
            this.isDisplayCursorCb.Checked = true;
            this.isDisplayCursorCb.CheckState = System.Windows.Forms.CheckState.Checked;
            this.isDisplayCursorCb.Location = new System.Drawing.Point(10, 20);
            this.isDisplayCursorCb.Name = "isDisplayCursorCb";
            this.isDisplayCursorCb.Size = new System.Drawing.Size(72, 16);
            this.isDisplayCursorCb.TabIndex = 18;
            this.isDisplayCursorCb.Text = "显示光标";
            this.isDisplayCursorCb.UseVisualStyleBackColor = true;
            // 
            // ipAddressComboBox
            // 
            this.ipAddressComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ipAddressComboBox.FormattingEnabled = true;
            this.ipAddressComboBox.Location = new System.Drawing.Point(70, 50);
            this.ipAddressComboBox.Name = "ipAddressComboBox";
            this.ipAddressComboBox.Size = new System.Drawing.Size(344, 20);
            this.ipAddressComboBox.TabIndex = 1;
            this.ipAddressComboBox.SelectedValueChanged += new System.EventHandler(this.IpAddressComboBox_SelectedValueChanged);
            // 
            // ipPortNud
            // 
            this.ipPortNud.Location = new System.Drawing.Point(474, 50);
            this.ipPortNud.Maximum = new decimal(new int[] {
            65535,
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
            // shareLinkText
            // 
            this.shareLinkText.BackColor = System.Drawing.SystemColors.Window;
            this.shareLinkText.Location = new System.Drawing.Point(70, 80);
            this.shareLinkText.Name = "shareLinkText";
            this.shareLinkText.ReadOnly = true;
            this.shareLinkText.Size = new System.Drawing.Size(484, 21);
            this.shareLinkText.TabIndex = 3;
            // 
            // aboutBtn
            // 
            this.aboutBtn.Location = new System.Drawing.Point(714, 50);
            this.aboutBtn.Name = "aboutBtn";
            this.aboutBtn.Size = new System.Drawing.Size(45, 23);
            this.aboutBtn.TabIndex = 4;
            this.aboutBtn.Text = "关于";
            this.aboutBtn.UseVisualStyleBackColor = true;
            this.aboutBtn.Click += new System.EventHandler(this.AboutBtn_Click);
            // 
            // copyBtn
            // 
            this.copyBtn.Location = new System.Drawing.Point(564, 80);
            this.copyBtn.Name = "copyBtn";
            this.copyBtn.Size = new System.Drawing.Size(45, 23);
            this.copyBtn.TabIndex = 3;
            this.copyBtn.Text = "复制";
            this.toolTip.SetToolTip(this.copyBtn, "点击可以复制分享地址。");
            this.copyBtn.UseVisualStyleBackColor = true;
            this.copyBtn.Click += new System.EventHandler(this.CopyBtn_Click);
            // 
            // encryptionBox
            // 
            this.encryptionBox.Controls.Add(this.encryptionPwdText);
            this.encryptionBox.Controls.Add(this.encryptionAccountText);
            this.encryptionBox.Controls.Add(this.encryptionPwdLabel);
            this.encryptionBox.Controls.Add(this.encryptionAccountLabel);
            this.encryptionBox.Controls.Add(this.isEncryptionCb);
            this.encryptionBox.Location = new System.Drawing.Point(10, 120);
            this.encryptionBox.Name = "encryptionBox";
            this.encryptionBox.Size = new System.Drawing.Size(160, 100);
            this.encryptionBox.TabIndex = 13;
            this.encryptionBox.TabStop = false;
            this.encryptionBox.Text = "加密传输";
            // 
            // encryptionPwdText
            // 
            this.encryptionPwdText.Enabled = false;
            this.encryptionPwdText.Location = new System.Drawing.Point(50, 70);
            this.encryptionPwdText.Name = "encryptionPwdText";
            this.encryptionPwdText.Size = new System.Drawing.Size(100, 21);
            this.encryptionPwdText.TabIndex = 7;
            // 
            // encryptionAccountText
            // 
            this.encryptionAccountText.Enabled = false;
            this.encryptionAccountText.Location = new System.Drawing.Point(50, 40);
            this.encryptionAccountText.Name = "encryptionAccountText";
            this.encryptionAccountText.Size = new System.Drawing.Size(100, 21);
            this.encryptionAccountText.TabIndex = 6;
            // 
            // encryptionPwdLabel
            // 
            this.encryptionPwdLabel.AutoSize = true;
            this.encryptionPwdLabel.Location = new System.Drawing.Point(10, 74);
            this.encryptionPwdLabel.Name = "encryptionPwdLabel";
            this.encryptionPwdLabel.Size = new System.Drawing.Size(41, 12);
            this.encryptionPwdLabel.TabIndex = 2;
            this.encryptionPwdLabel.Text = "密码：";
            // 
            // encryptionAccountLabel
            // 
            this.encryptionAccountLabel.AutoSize = true;
            this.encryptionAccountLabel.Location = new System.Drawing.Point(10, 44);
            this.encryptionAccountLabel.Name = "encryptionAccountLabel";
            this.encryptionAccountLabel.Size = new System.Drawing.Size(41, 12);
            this.encryptionAccountLabel.TabIndex = 1;
            this.encryptionAccountLabel.Text = "账号：";
            // 
            // isEncryptionCb
            // 
            this.isEncryptionCb.AutoSize = true;
            this.isEncryptionCb.Location = new System.Drawing.Point(10, 20);
            this.isEncryptionCb.Name = "isEncryptionCb";
            this.isEncryptionCb.Size = new System.Drawing.Size(48, 16);
            this.isEncryptionCb.TabIndex = 5;
            this.isEncryptionCb.Text = "加密";
            this.toolTip.SetToolTip(this.isEncryptionCb, "开启后需要输入账号密码才能访问。");
            this.isEncryptionCb.UseVisualStyleBackColor = true;
            this.isEncryptionCb.CheckStateChanged += new System.EventHandler(this.IsEncryptionCb_CheckStateChanged);
            // 
            // coordinatesBox
            // 
            this.coordinatesBox.Controls.Add(this.screenHNud);
            this.coordinatesBox.Controls.Add(this.screenYNud);
            this.coordinatesBox.Controls.Add(this.screenWNud);
            this.coordinatesBox.Controls.Add(this.captureScreenCoordinatesBtn);
            this.coordinatesBox.Controls.Add(this.screenXNud);
            this.coordinatesBox.Controls.Add(this.screenHLabel);
            this.coordinatesBox.Controls.Add(this.screenYLabel);
            this.coordinatesBox.Controls.Add(this.screenXLabel);
            this.coordinatesBox.Controls.Add(this.screenWLabel);
            this.coordinatesBox.Controls.Add(this.isFullScreenCb);
            this.coordinatesBox.Location = new System.Drawing.Point(180, 120);
            this.coordinatesBox.Name = "coordinatesBox";
            this.coordinatesBox.Size = new System.Drawing.Size(180, 100);
            this.coordinatesBox.TabIndex = 14;
            this.coordinatesBox.TabStop = false;
            this.coordinatesBox.Text = "选取位置";
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
            this.screenHNud.TabIndex = 24;
            this.toolTip.SetToolTip(this.screenHNud, "选取矩形的高");
            this.screenHNud.Value = new decimal(new int[] {
            1080,
            0,
            0,
            0});
            this.screenHNud.ValueChanged += new System.EventHandler(this.ScreenHNud_ValueChanged);
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
            this.screenYNud.Name = "screenYNud";
            this.screenYNud.Size = new System.Drawing.Size(50, 21);
            this.screenYNud.TabIndex = 22;
            this.toolTip.SetToolTip(this.screenYNud, "选取矩形左上角的纵坐标Y");
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
            this.screenWNud.TabIndex = 23;
            this.toolTip.SetToolTip(this.screenWNud, "选取矩形的宽");
            this.screenWNud.Value = new decimal(new int[] {
            1920,
            0,
            0,
            0});
            this.screenWNud.ValueChanged += new System.EventHandler(this.ScreenWNud_ValueChanged);
            // 
            // captureScreenCoordinatesBtn
            // 
            this.captureScreenCoordinatesBtn.Location = new System.Drawing.Point(70, 14);
            this.captureScreenCoordinatesBtn.Name = "captureScreenCoordinatesBtn";
            this.captureScreenCoordinatesBtn.Size = new System.Drawing.Size(100, 23);
            this.captureScreenCoordinatesBtn.TabIndex = 9;
            this.captureScreenCoordinatesBtn.Text = "选取屏幕坐标";
            this.captureScreenCoordinatesBtn.UseVisualStyleBackColor = true;
            this.captureScreenCoordinatesBtn.Click += new System.EventHandler(this.CaptureScreenCoordinatesBtn_Click);
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
            this.screenXNud.Name = "screenXNud";
            this.screenXNud.Size = new System.Drawing.Size(50, 21);
            this.screenXNud.TabIndex = 21;
            this.toolTip.SetToolTip(this.screenXNud, "选取矩形左上角的横坐标X");
            // 
            // screenHLabel
            // 
            this.screenHLabel.AutoSize = true;
            this.screenHLabel.Location = new System.Drawing.Point(90, 74);
            this.screenHLabel.Name = "screenHLabel";
            this.screenHLabel.Size = new System.Drawing.Size(29, 12);
            this.screenHLabel.TabIndex = 4;
            this.screenHLabel.Text = "高：";
            // 
            // screenYLabel
            // 
            this.screenYLabel.AutoSize = true;
            this.screenYLabel.Location = new System.Drawing.Point(10, 74);
            this.screenYLabel.Name = "screenYLabel";
            this.screenYLabel.Size = new System.Drawing.Size(23, 12);
            this.screenYLabel.TabIndex = 2;
            this.screenYLabel.Text = "Y：";
            // 
            // screenXLabel
            // 
            this.screenXLabel.AutoSize = true;
            this.screenXLabel.Location = new System.Drawing.Point(10, 44);
            this.screenXLabel.Name = "screenXLabel";
            this.screenXLabel.Size = new System.Drawing.Size(23, 12);
            this.screenXLabel.TabIndex = 1;
            this.screenXLabel.Text = "X：";
            // 
            // screenWLabel
            // 
            this.screenWLabel.AutoSize = true;
            this.screenWLabel.Location = new System.Drawing.Point(90, 44);
            this.screenWLabel.Name = "screenWLabel";
            this.screenWLabel.Size = new System.Drawing.Size(29, 12);
            this.screenWLabel.TabIndex = 3;
            this.screenWLabel.Text = "宽：";
            // 
            // isFullScreenCb
            // 
            this.isFullScreenCb.AutoSize = true;
            this.isFullScreenCb.Checked = true;
            this.isFullScreenCb.CheckState = System.Windows.Forms.CheckState.Checked;
            this.isFullScreenCb.Location = new System.Drawing.Point(10, 20);
            this.isFullScreenCb.Name = "isFullScreenCb";
            this.isFullScreenCb.Size = new System.Drawing.Size(48, 16);
            this.isFullScreenCb.TabIndex = 8;
            this.isFullScreenCb.Text = "全屏";
            this.isFullScreenCb.UseVisualStyleBackColor = true;
            this.isFullScreenCb.CheckStateChanged += new System.EventHandler(this.IsFullScreenCb_CheckStateChanged);
            // 
            // videoQualityLabel
            // 
            this.videoQualityLabel.AutoSize = true;
            this.videoQualityLabel.Location = new System.Drawing.Point(10, 74);
            this.videoQualityLabel.Name = "videoQualityLabel";
            this.videoQualityLabel.Size = new System.Drawing.Size(65, 12);
            this.videoQualityLabel.TabIndex = 0;
            this.videoQualityLabel.Text = "视频质量：";
            // 
            // scalingBox
            // 
            this.scalingBox.Controls.Add(this.videoHNud);
            this.scalingBox.Controls.Add(this.videoWNud);
            this.scalingBox.Controls.Add(this.scalingNud);
            this.scalingBox.Controls.Add(this.videoHLabel);
            this.scalingBox.Controls.Add(this.videoWLabel);
            this.scalingBox.Controls.Add(this.scalingLabel);
            this.scalingBox.Controls.Add(this.isLockAspectRatioCb);
            this.scalingBox.Location = new System.Drawing.Point(370, 120);
            this.scalingBox.Name = "scalingBox";
            this.scalingBox.Size = new System.Drawing.Size(180, 100);
            this.scalingBox.TabIndex = 16;
            this.scalingBox.TabStop = false;
            this.scalingBox.Text = "视频尺寸";
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
            this.videoHNud.TabIndex = 26;
            this.videoHNud.Value = new decimal(new int[] {
            1080,
            0,
            0,
            0});
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
            this.videoWNud.TabIndex = 25;
            this.videoWNud.Value = new decimal(new int[] {
            1920,
            0,
            0,
            0});
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
            this.scalingNud.TabIndex = 15;
            this.toolTip.SetToolTip(this.scalingNud, "相对于选取的矩形的缩放比例，建议100%。最好不要修改，否则会卡顿。");
            this.scalingNud.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.scalingNud.ValueChanged += new System.EventHandler(this.ScalingNud_ValueChanged);
            // 
            // videoHLabel
            // 
            this.videoHLabel.AutoSize = true;
            this.videoHLabel.Location = new System.Drawing.Point(95, 74);
            this.videoHLabel.Name = "videoHLabel";
            this.videoHLabel.Size = new System.Drawing.Size(29, 12);
            this.videoHLabel.TabIndex = 3;
            this.videoHLabel.Text = "高：";
            // 
            // videoWLabel
            // 
            this.videoWLabel.AutoSize = true;
            this.videoWLabel.Location = new System.Drawing.Point(10, 74);
            this.videoWLabel.Name = "videoWLabel";
            this.videoWLabel.Size = new System.Drawing.Size(29, 12);
            this.videoWLabel.TabIndex = 2;
            this.videoWLabel.Text = "宽：";
            // 
            // scalingLabel
            // 
            this.scalingLabel.AutoSize = true;
            this.scalingLabel.Location = new System.Drawing.Point(10, 44);
            this.scalingLabel.Name = "scalingLabel";
            this.scalingLabel.Size = new System.Drawing.Size(65, 12);
            this.scalingLabel.TabIndex = 1;
            this.scalingLabel.Text = "缩放比例：";
            // 
            // isLockAspectRatioCb
            // 
            this.isLockAspectRatioCb.AutoSize = true;
            this.isLockAspectRatioCb.Checked = true;
            this.isLockAspectRatioCb.CheckState = System.Windows.Forms.CheckState.Checked;
            this.isLockAspectRatioCb.Location = new System.Drawing.Point(10, 20);
            this.isLockAspectRatioCb.Name = "isLockAspectRatioCb";
            this.isLockAspectRatioCb.Size = new System.Drawing.Size(84, 16);
            this.isLockAspectRatioCb.TabIndex = 14;
            this.isLockAspectRatioCb.Text = "锁定纵横比";
            this.isLockAspectRatioCb.UseVisualStyleBackColor = true;
            this.isLockAspectRatioCb.CheckStateChanged += new System.EventHandler(this.IsLockAspectRatioCb_CheckStateChanged);
            // 
            // startSharingScreenBtn
            // 
            this.startSharingScreenBtn.Font = new System.Drawing.Font("宋体", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.startSharingScreenBtn.Location = new System.Drawing.Point(95, 230);
            this.startSharingScreenBtn.Name = "startSharingScreenBtn";
            this.startSharingScreenBtn.Size = new System.Drawing.Size(180, 40);
            this.startSharingScreenBtn.TabIndex = 0;
            this.startSharingScreenBtn.Text = "开始共享";
            this.startSharingScreenBtn.UseVisualStyleBackColor = true;
            this.startSharingScreenBtn.Click += new System.EventHandler(this.StartSharingScreenBtn_Click);
            // 
            // logText
            // 
            this.logText.BackColor = System.Drawing.SystemColors.Window;
            this.logText.Location = new System.Drawing.Point(10, 280);
            this.logText.Multiline = true;
            this.logText.Name = "logText";
            this.logText.ReadOnly = true;
            this.logText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.logText.Size = new System.Drawing.Size(350, 141);
            this.logText.TabIndex = 21;
            this.logText.TabStop = false;
            // 
            // videoBox
            // 
            this.videoBox.Controls.Add(this.videoQualityNud);
            this.videoBox.Controls.Add(this.videoFrameNud);
            this.videoBox.Controls.Add(this.isDisplayCursorCb);
            this.videoBox.Controls.Add(this.videoFrameLabel);
            this.videoBox.Controls.Add(this.videoQualityLabel);
            this.videoBox.Location = new System.Drawing.Point(560, 120);
            this.videoBox.Name = "videoBox";
            this.videoBox.Size = new System.Drawing.Size(135, 100);
            this.videoBox.TabIndex = 20;
            this.videoBox.TabStop = false;
            this.videoBox.Text = "视频设置";
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
            this.videoQualityNud.TabIndex = 20;
            this.toolTip.SetToolTip(this.videoQualityNud, "视频清晰度，数字越大越清晰，建议100%。最好不要改，否则会卡顿。");
            this.videoQualityNud.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
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
            this.videoFrameNud.TabIndex = 19;
            this.toolTip.SetToolTip(this.videoFrameNud, "每秒刷新次数，数字越大越流畅，建议5帧/秒。不要调太高，否则会卡顿。");
            this.videoFrameNud.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // previewImg
            // 
            this.previewImg.Location = new System.Drawing.Point(375, 250);
            this.previewImg.Margin = new System.Windows.Forms.Padding(0);
            this.previewImg.Name = "previewImg";
            this.previewImg.Size = new System.Drawing.Size(320, 180);
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
            this.Controls.Add(this.previewImg);
            this.Controls.Add(this.logText);
            this.Controls.Add(this.videoBox);
            this.Controls.Add(this.startSharingScreenBtn);
            this.Controls.Add(this.scalingBox);
            this.Controls.Add(this.coordinatesBox);
            this.Controls.Add(this.encryptionBox);
            this.Controls.Add(this.copyBtn);
            this.Controls.Add(this.aboutBtn);
            this.Controls.Add(this.shareLinkText);
            this.Controls.Add(this.ipPortNud);
            this.Controls.Add(this.ipAddressComboBox);
            this.Controls.Add(this.ipPortLabel);
            this.Controls.Add(this.shareLinkLabel);
            this.Controls.Add(this.ipAddressLabel);
            this.Controls.Add(this.ShareScreenLabel);
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
            ((System.ComponentModel.ISupportInitialize)(this.screenHNud)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.screenYNud)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.screenWNud)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.screenXNud)).EndInit();
            this.scalingBox.ResumeLayout(false);
            this.scalingBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.videoHNud)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.videoWNud)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.scalingNud)).EndInit();
            this.videoBox.ResumeLayout(false);
            this.videoBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.videoQualityNud)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.videoFrameNud)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.previewImg)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label ShareScreenLabel;
        private System.Windows.Forms.Label ipAddressLabel;
        private System.Windows.Forms.Label shareLinkLabel;
        private System.Windows.Forms.Label ipPortLabel;
        private System.Windows.Forms.Label videoFrameLabel;
        private System.Windows.Forms.CheckBox isDisplayCursorCb;
        private System.Windows.Forms.ComboBox ipAddressComboBox;
        private System.Windows.Forms.NumericUpDown ipPortNud;
        private System.Windows.Forms.TextBox shareLinkText;
        private System.Windows.Forms.Button aboutBtn;
        private System.Windows.Forms.Button copyBtn;
        private System.Windows.Forms.GroupBox encryptionBox;
        private System.Windows.Forms.TextBox encryptionPwdText;
        private System.Windows.Forms.TextBox encryptionAccountText;
        private System.Windows.Forms.Label encryptionPwdLabel;
        private System.Windows.Forms.Label encryptionAccountLabel;
        private System.Windows.Forms.CheckBox isEncryptionCb;
        private System.Windows.Forms.GroupBox coordinatesBox;
        private System.Windows.Forms.Button captureScreenCoordinatesBtn;
        private System.Windows.Forms.Label screenHLabel;
        private System.Windows.Forms.Label screenYLabel;
        private System.Windows.Forms.Label screenXLabel;
        private System.Windows.Forms.Label screenWLabel;
        private System.Windows.Forms.CheckBox isFullScreenCb;
        private System.Windows.Forms.Label videoQualityLabel;
        private System.Windows.Forms.GroupBox scalingBox;
        private System.Windows.Forms.NumericUpDown scalingNud;
        private System.Windows.Forms.Label videoHLabel;
        private System.Windows.Forms.Label videoWLabel;
        private System.Windows.Forms.Label scalingLabel;
        private System.Windows.Forms.CheckBox isLockAspectRatioCb;
        private System.Windows.Forms.Button startSharingScreenBtn;
        private System.Windows.Forms.TextBox logText;
        private System.Windows.Forms.GroupBox videoBox;
        private System.Windows.Forms.NumericUpDown videoQualityNud;
        private System.Windows.Forms.NumericUpDown videoFrameNud;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.NumericUpDown screenHNud;
        private System.Windows.Forms.NumericUpDown screenYNud;
        private System.Windows.Forms.NumericUpDown screenWNud;
        private System.Windows.Forms.NumericUpDown screenXNud;
        private System.Windows.Forms.NumericUpDown videoHNud;
        private System.Windows.Forms.NumericUpDown videoWNud;
        private System.Windows.Forms.PictureBox previewImg;
    }
}

