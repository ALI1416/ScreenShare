namespace ScreenShare
{
    partial class History
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.topPanel = new System.Windows.Forms.Panel();
            this.autoRefreshCb = new System.Windows.Forms.CheckBox();
            this.onlyOnlineCb = new System.Windows.Forms.CheckBox();
            this.refreshLinkLabel = new System.Windows.Forms.LinkLabel();
            this.titleLabel = new System.Windows.Forms.Label();
            this.bottomPanel = new System.Windows.Forms.Panel();
            this.textLabel = new System.Windows.Forms.Label();
            this.tableDataGridView = new System.Windows.Forms.DataGridView();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ip = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.online = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.offline = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.interval = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.frameAvg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.byteAvg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.byteCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.topPanel.SuspendLayout();
            this.bottomPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tableDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // topPanel
            // 
            this.topPanel.Controls.Add(this.autoRefreshCb);
            this.topPanel.Controls.Add(this.onlyOnlineCb);
            this.topPanel.Controls.Add(this.refreshLinkLabel);
            this.topPanel.Controls.Add(this.titleLabel);
            this.topPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.topPanel.Location = new System.Drawing.Point(0, 0);
            this.topPanel.Name = "topPanel";
            this.topPanel.Size = new System.Drawing.Size(768, 50);
            this.topPanel.TabIndex = 1;
            // 
            // autoRefreshCb
            // 
            this.autoRefreshCb.AutoSize = true;
            this.autoRefreshCb.Checked = true;
            this.autoRefreshCb.CheckState = System.Windows.Forms.CheckState.Checked;
            this.autoRefreshCb.Location = new System.Drawing.Point(610, 30);
            this.autoRefreshCb.Name = "autoRefreshCb";
            this.autoRefreshCb.Size = new System.Drawing.Size(90, 16);
            this.autoRefreshCb.TabIndex = 2;
            this.autoRefreshCb.Text = "5秒自动刷新";
            this.autoRefreshCb.UseVisualStyleBackColor = true;
            // 
            // onlyOnlineCb
            // 
            this.onlyOnlineCb.AutoSize = true;
            this.onlyOnlineCb.Location = new System.Drawing.Point(10, 30);
            this.onlyOnlineCb.Name = "onlyOnlineCb";
            this.onlyOnlineCb.Size = new System.Drawing.Size(108, 16);
            this.onlyOnlineCb.TabIndex = 1;
            this.onlyOnlineCb.Text = "仅显示在线用户";
            this.toolTip.SetToolTip(this.onlyOnlineCb, "仅显示在线用户");
            this.onlyOnlineCb.UseVisualStyleBackColor = true;
            this.onlyOnlineCb.CheckStateChanged += new System.EventHandler(this.OnlyOnlineCheckBox_CheckStateChanged);
            // 
            // refreshLinkLabel
            // 
            this.refreshLinkLabel.AutoSize = true;
            this.refreshLinkLabel.Location = new System.Drawing.Point(710, 31);
            this.refreshLinkLabel.Name = "refreshLinkLabel";
            this.refreshLinkLabel.Size = new System.Drawing.Size(53, 12);
            this.refreshLinkLabel.TabIndex = 3;
            this.refreshLinkLabel.TabStop = true;
            this.refreshLinkLabel.Text = "手动刷新";
            this.toolTip.SetToolTip(this.refreshLinkLabel, "点击刷新");
            this.refreshLinkLabel.Click += new System.EventHandler(this.RefreshLinkLabel_Click);
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Font = new System.Drawing.Font("宋体", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.titleLabel.Location = new System.Drawing.Point(294, 12);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(180, 27);
            this.titleLabel.TabIndex = 0;
            this.titleLabel.Text = "用户在线历史";
            // 
            // bottomPanel
            // 
            this.bottomPanel.Controls.Add(this.textLabel);
            this.bottomPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bottomPanel.Location = new System.Drawing.Point(0, 412);
            this.bottomPanel.Name = "bottomPanel";
            this.bottomPanel.Size = new System.Drawing.Size(768, 20);
            this.bottomPanel.TabIndex = 0;
            // 
            // textLabel
            // 
            this.textLabel.AutoSize = true;
            this.textLabel.Location = new System.Drawing.Point(5, 5);
            this.textLabel.Name = "textLabel";
            this.textLabel.Size = new System.Drawing.Size(599, 12);
            this.textLabel.TabIndex = 0;
            this.textLabel.Text = "当前在线用户数量：0        累计访问用户数量：0        当前帧率(帧/秒)：0        传输数据总量(Mb)：0";
            // 
            // tableDataGridView
            // 
            this.tableDataGridView.AllowUserToAddRows = false;
            this.tableDataGridView.AllowUserToDeleteRows = false;
            this.tableDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.tableDataGridView.BackgroundColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.tableDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.tableDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tableDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.status,
            this.ip,
            this.online,
            this.offline,
            this.interval,
            this.frameAvg,
            this.byteAvg,
            this.byteCount});
            this.tableDataGridView.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableDataGridView.Location = new System.Drawing.Point(0, 50);
            this.tableDataGridView.Name = "tableDataGridView";
            this.tableDataGridView.ReadOnly = true;
            this.tableDataGridView.RowHeadersVisible = false;
            this.tableDataGridView.Size = new System.Drawing.Size(768, 362);
            this.tableDataGridView.TabIndex = 2;
            // 
            // status
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.status.DefaultCellStyle = dataGridViewCellStyle4;
            this.status.FillWeight = 64F;
            this.status.HeaderText = "状态";
            this.status.Name = "status";
            this.status.ReadOnly = true;
            // 
            // ip
            // 
            this.ip.FillWeight = 150F;
            this.ip.HeaderText = "IP地址";
            this.ip.Name = "ip";
            this.ip.ReadOnly = true;
            // 
            // online
            // 
            this.online.HeaderText = "上线时间";
            this.online.Name = "online";
            this.online.ReadOnly = true;
            // 
            // offline
            // 
            this.offline.HeaderText = "下线时间";
            this.offline.Name = "offline";
            this.offline.ReadOnly = true;
            // 
            // interval
            // 
            this.interval.HeaderText = "连接时长\n(分钟)";
            this.interval.Name = "interval";
            this.interval.ReadOnly = true;
            // 
            // frameAvg
            // 
            this.frameAvg.HeaderText = "每秒帧数\n(帧/秒)";
            this.frameAvg.Name = "frameAvg";
            this.frameAvg.ReadOnly = true;
            // 
            // byteAvg
            // 
            this.byteAvg.HeaderText = "传输速度\n(Kb/秒)";
            this.byteAvg.Name = "byteAvg";
            this.byteAvg.ReadOnly = true;
            // 
            // byteCount
            // 
            this.byteCount.HeaderText = "数据总量\n(Mb)";
            this.byteCount.Name = "byteCount";
            this.byteCount.ReadOnly = true;
            // 
            // History
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(768, 432);
            this.Controls.Add(this.topPanel);
            this.Controls.Add(this.tableDataGridView);
            this.Controls.Add(this.bottomPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = global::ScreenShare.Properties.Resources.icon;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "History";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "用户在线历史";
            this.topPanel.ResumeLayout(false);
            this.topPanel.PerformLayout();
            this.bottomPanel.ResumeLayout(false);
            this.bottomPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tableDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
       
        /* 头部 */
        /// <summary>
        /// 头部Panel
        /// </summary>
        private System.Windows.Forms.Panel topPanel;

        /// <summary>
        /// 用户在线历史Label
        /// </summary>
        private System.Windows.Forms.Label titleLabel;
        /// <summary>
        /// 仅显示在线用户CheckBox
        /// </summary>
        private System.Windows.Forms.CheckBox onlyOnlineCb;
        /// <summary>
        /// 5秒自动刷新CheckBox
        /// </summary>
        private System.Windows.Forms.CheckBox autoRefreshCb;
        /// <summary>
        /// 手动刷新LinkLabel
        /// </summary>
        private System.Windows.Forms.LinkLabel refreshLinkLabel;

        /* 底部 */
        /// <summary>
        /// 底部Panel
        /// </summary>
        private System.Windows.Forms.Panel bottomPanel;

        /// <summary>
        /// 文本Label
        /// </summary>
        private System.Windows.Forms.Label textLabel;

        /* 提示 */
        /// <summary>
        /// 提示ToolTip
        /// </summary>
        private System.Windows.Forms.ToolTip toolTip;

        /* 表格DataGridView */
        /// <summary>
        /// 表格DataGridView
        /// </summary>
        private System.Windows.Forms.DataGridView tableDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn status;
        private System.Windows.Forms.DataGridViewTextBoxColumn ip;
        private System.Windows.Forms.DataGridViewTextBoxColumn online;
        private System.Windows.Forms.DataGridViewTextBoxColumn offline;
        private System.Windows.Forms.DataGridViewTextBoxColumn interval;
        private System.Windows.Forms.DataGridViewTextBoxColumn frameAvg;
        private System.Windows.Forms.DataGridViewTextBoxColumn byteAvg;
        private System.Windows.Forms.DataGridViewTextBoxColumn byteCount;
    }
}