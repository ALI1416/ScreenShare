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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tableDataGridView = new System.Windows.Forms.DataGridView();
            this.status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ip = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.online = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.offline = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.interval = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.refreshLinkLabel = new System.Windows.Forms.LinkLabel();
            this.onlyOnlineCheckBox = new System.Windows.Forms.CheckBox();
            this.titleLabel = new System.Windows.Forms.Label();
            this.topPanel = new System.Windows.Forms.Panel();
            this.bottomPanel = new System.Windows.Forms.Panel();
            this.countLabel = new System.Windows.Forms.Label();
            this.onlineCountLabel = new System.Windows.Forms.Label();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.tableDataGridView)).BeginInit();
            this.topPanel.SuspendLayout();
            this.bottomPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableDataGridView
            // 
            this.tableDataGridView.AllowUserToAddRows = false;
            this.tableDataGridView.AllowUserToDeleteRows = false;
            this.tableDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.tableDataGridView.BackgroundColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.tableDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.tableDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tableDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.status,
            this.ip,
            this.online,
            this.offline,
            this.interval});
            this.tableDataGridView.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableDataGridView.Location = new System.Drawing.Point(0, 50);
            this.tableDataGridView.Name = "tableDataGridView";
            this.tableDataGridView.ReadOnly = true;
            this.tableDataGridView.RowHeadersVisible = false;
            this.tableDataGridView.Size = new System.Drawing.Size(650, 362);
            this.tableDataGridView.TabIndex = 2;
            // 
            // status
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.status.DefaultCellStyle = dataGridViewCellStyle2;
            this.status.FillWeight = 50F;
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
            this.interval.FillWeight = 150F;
            this.interval.HeaderText = "连接时长\n(分钟)";
            this.interval.Name = "interval";
            this.interval.ReadOnly = true;
            // 
            // refreshLinkLabel
            // 
            this.refreshLinkLabel.AutoSize = true;
            this.refreshLinkLabel.Location = new System.Drawing.Point(610, 33);
            this.refreshLinkLabel.Name = "refreshLinkLabel";
            this.refreshLinkLabel.Size = new System.Drawing.Size(29, 12);
            this.refreshLinkLabel.TabIndex = 2;
            this.refreshLinkLabel.TabStop = true;
            this.refreshLinkLabel.Text = "刷新";
            this.toolTip.SetToolTip(this.refreshLinkLabel, "点击刷新");
            this.refreshLinkLabel.Click += new System.EventHandler(this.RefreshLinkLabel_Click);
            // 
            // onlyOnlineCheckBox
            // 
            this.onlyOnlineCheckBox.AutoSize = true;
            this.onlyOnlineCheckBox.Location = new System.Drawing.Point(10, 30);
            this.onlyOnlineCheckBox.Name = "onlyOnlineCheckBox";
            this.onlyOnlineCheckBox.Size = new System.Drawing.Size(108, 16);
            this.onlyOnlineCheckBox.TabIndex = 1;
            this.onlyOnlineCheckBox.Text = "仅显示在线用户";
            this.toolTip.SetToolTip(this.onlyOnlineCheckBox, "仅显示在线用户");
            this.onlyOnlineCheckBox.UseVisualStyleBackColor = true;
            this.onlyOnlineCheckBox.CheckStateChanged += new System.EventHandler(this.OnlyOnlineCheckBox_CheckStateChanged);
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Font = new System.Drawing.Font("宋体", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.titleLabel.Location = new System.Drawing.Point(235, 12);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(180, 27);
            this.titleLabel.TabIndex = 0;
            this.titleLabel.Text = "用户在线历史";
            // 
            // topPanel
            // 
            this.topPanel.Controls.Add(this.onlyOnlineCheckBox);
            this.topPanel.Controls.Add(this.refreshLinkLabel);
            this.topPanel.Controls.Add(this.titleLabel);
            this.topPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.topPanel.Location = new System.Drawing.Point(0, 0);
            this.topPanel.Name = "topPanel";
            this.topPanel.Size = new System.Drawing.Size(650, 50);
            this.topPanel.TabIndex = 1;
            // 
            // bottomPanel
            // 
            this.bottomPanel.Controls.Add(this.countLabel);
            this.bottomPanel.Controls.Add(this.onlineCountLabel);
            this.bottomPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bottomPanel.Location = new System.Drawing.Point(0, 412);
            this.bottomPanel.Name = "bottomPanel";
            this.bottomPanel.Size = new System.Drawing.Size(650, 20);
            this.bottomPanel.TabIndex = 0;
            // 
            // countLabel
            // 
            this.countLabel.AutoSize = true;
            this.countLabel.Location = new System.Drawing.Point(510, 5);
            this.countLabel.Name = "countLabel";
            this.countLabel.Size = new System.Drawing.Size(119, 12);
            this.countLabel.TabIndex = 0;
            this.countLabel.Text = "累计访问用户数量：0";
            // 
            // onlineCountLabel
            // 
            this.onlineCountLabel.AutoSize = true;
            this.onlineCountLabel.Location = new System.Drawing.Point(5, 5);
            this.onlineCountLabel.Name = "onlineCountLabel";
            this.onlineCountLabel.Size = new System.Drawing.Size(119, 12);
            this.onlineCountLabel.TabIndex = 0;
            this.onlineCountLabel.Text = "当前在线用户数量：0";
            // 
            // History
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(650, 432);
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
            ((System.ComponentModel.ISupportInitialize)(this.tableDataGridView)).EndInit();
            this.topPanel.ResumeLayout(false);
            this.topPanel.PerformLayout();
            this.bottomPanel.ResumeLayout(false);
            this.bottomPanel.PerformLayout();
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
        private System.Windows.Forms.CheckBox onlyOnlineCheckBox;
        /// <summary>
        /// 刷新LinkLabel
        /// </summary>
        private System.Windows.Forms.LinkLabel refreshLinkLabel;

        /* 底部 */
        /// <summary>
        /// 底部Panel
        /// </summary>
        private System.Windows.Forms.Panel bottomPanel;

        /* 表格DataGridView */
        /// <summary>
        /// 表格DataGridView
        /// </summary>
        private System.Windows.Forms.DataGridView tableDataGridView;
        /// <summary>
        /// 表格字段`状态`DataGridViewTextBoxColumn
        /// </summary>
        private System.Windows.Forms.DataGridViewTextBoxColumn status;
        /// <summary>
        /// 表格字段`IP地址`DataGridViewTextBoxColumn
        /// </summary>
        private System.Windows.Forms.DataGridViewTextBoxColumn ip;
        /// <summary>
        /// 表格字段`上线时间`DataGridViewTextBoxColumn
        /// </summary>
        private System.Windows.Forms.DataGridViewTextBoxColumn online;
        /// <summary>
        /// 表格字段`下线时间`DataGridViewTextBoxColumn
        /// </summary>
        private System.Windows.Forms.DataGridViewTextBoxColumn offline;
        /// <summary>
        /// 表格字段`连接时长(分钟)`DataGridViewTextBoxColumn
        /// </summary>
        private System.Windows.Forms.DataGridViewTextBoxColumn interval;

        /// <summary>
        /// 当前在线用户数量Label
        /// </summary>
        private System.Windows.Forms.Label onlineCountLabel;
        /// <summary>
        /// 累计访问用户数量Label
        /// </summary>
        private System.Windows.Forms.Label countLabel;

        /* 提示 */
        /// <summary>
        /// 提示ToolTip
        /// </summary>
        private System.Windows.Forms.ToolTip toolTip;
    }
}