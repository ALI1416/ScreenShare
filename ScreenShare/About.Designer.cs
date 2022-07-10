namespace ScreenShare
{
    partial class About
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
            this.name = new System.Windows.Forms.Label();
            this.version = new System.Windows.Forms.Label();
            this.authorLabel = new System.Windows.Forms.Label();
            this.authorLink = new System.Windows.Forms.LinkLabel();
            this.thankLabel = new System.Windows.Forms.Label();
            this.thankLink = new System.Windows.Forms.LinkLabel();
            this.thankLink2 = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // name
            // 
            this.name.AutoSize = true;
            this.name.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.name.Location = new System.Drawing.Point(55, 10);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(71, 16);
            this.name.TabIndex = 0;
            this.name.Text = "屏幕共享";
            // 
            // version
            // 
            this.version.AutoSize = true;
            this.version.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.version.Location = new System.Drawing.Point(50, 40);
            this.version.Name = "version";
            this.version.Size = new System.Drawing.Size(87, 16);
            this.version.TabIndex = 1;
            this.version.Text = "版本：V2.0";
            // 
            // authorLabel
            // 
            this.authorLabel.AutoSize = true;
            this.authorLabel.Location = new System.Drawing.Point(10, 70);
            this.authorLabel.Name = "authorLabel";
            this.authorLabel.Size = new System.Drawing.Size(41, 12);
            this.authorLabel.TabIndex = 2;
            this.authorLabel.Text = "作者：";
            // 
            // authorLink
            // 
            this.authorLink.AutoSize = true;
            this.authorLink.Location = new System.Drawing.Point(50, 70);
            this.authorLink.Name = "authorLink";
            this.authorLink.Size = new System.Drawing.Size(47, 12);
            this.authorLink.TabIndex = 3;
            this.authorLink.TabStop = true;
            this.authorLink.Text = "ALI1416";
            this.authorLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.AuthorLink_LinkClicked);
            // 
            // thankLabel
            // 
            this.thankLabel.AutoSize = true;
            this.thankLabel.Location = new System.Drawing.Point(10, 100);
            this.thankLabel.Name = "thankLabel";
            this.thankLabel.Size = new System.Drawing.Size(41, 12);
            this.thankLabel.TabIndex = 4;
            this.thankLabel.Text = "感谢：";
            // 
            // thankLink
            // 
            this.thankLink.AutoSize = true;
            this.thankLink.Location = new System.Drawing.Point(50, 100);
            this.thankLink.Name = "thankLink";
            this.thankLink.Size = new System.Drawing.Size(47, 12);
            this.thankLink.TabIndex = 5;
            this.thankLink.TabStop = true;
            this.thankLink.Text = "EslaMx7";
            this.thankLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.ThankLink_LinkClicked);
            // 
            // thankLink2
            // 
            this.thankLink2.AutoSize = true;
            this.thankLink2.Location = new System.Drawing.Point(50, 120);
            this.thankLink2.Name = "thankLink2";
            this.thankLink2.Size = new System.Drawing.Size(77, 12);
            this.thankLink2.TabIndex = 6;
            this.thankLink2.TabStop = true;
            this.thankLink2.Text = "xChivalrouSx";
            this.thankLink2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.ThankLink2_LinkClicked);
            // 
            // About
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(184, 161);
            this.Controls.Add(this.name);
            this.Controls.Add(this.version);
            this.Controls.Add(this.authorLabel);
            this.Controls.Add(this.authorLink);
            this.Controls.Add(this.thankLabel);
            this.Controls.Add(this.thankLink);
            this.Controls.Add(this.thankLink2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = global::ScreenShare.Properties.Resources.icon;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "About";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "关于";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label name;
        private System.Windows.Forms.Label version;
        private System.Windows.Forms.Label authorLabel;
        private System.Windows.Forms.LinkLabel authorLink;
        private System.Windows.Forms.Label thankLabel;
        private System.Windows.Forms.LinkLabel thankLink;
        private System.Windows.Forms.LinkLabel thankLink2;
    }
}