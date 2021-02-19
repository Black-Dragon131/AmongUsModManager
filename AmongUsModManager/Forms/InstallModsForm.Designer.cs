
namespace AmongUsModManager.Forms
{
    partial class InstallModsForm
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
            this.lblAviableMods = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.lblAuhor = new System.Windows.Forms.Label();
            this.lblAuthorName = new System.Windows.Forms.Label();
            this.lblDownloadStatus = new System.Windows.Forms.Label();
            this.cbAvailableMods = new System.Windows.Forms.ComboBox();
            this.txtModDescription = new System.Windows.Forms.TextBox();
            this.pbModPreview = new System.Windows.Forms.PictureBox();
            this.btnInstallMod = new FontAwesome.Sharp.IconButton();
            this.btnUpdate = new FontAwesome.Sharp.IconButton();
            this.pgrbDownload = new AmongUsModManager.CustomProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.pbModPreview)).BeginInit();
            this.SuspendLayout();
            // 
            // lblAviableMods
            // 
            this.lblAviableMods.AutoSize = true;
            this.lblAviableMods.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Underline);
            this.lblAviableMods.Location = new System.Drawing.Point(12, 16);
            this.lblAviableMods.Name = "lblAviableMods";
            this.lblAviableMods.Size = new System.Drawing.Size(91, 15);
            this.lblAviableMods.TabIndex = 0;
            this.lblAviableMods.Text = "Available Mods:";
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Underline);
            this.lblDescription.Location = new System.Drawing.Point(12, 73);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(70, 15);
            this.lblDescription.TabIndex = 1;
            this.lblDescription.Text = "Description:";
            // 
            // lblAuhor
            // 
            this.lblAuhor.AutoSize = true;
            this.lblAuhor.Font = new System.Drawing.Font("Segoe UI", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))));
            this.lblAuhor.Location = new System.Drawing.Point(12, 45);
            this.lblAuhor.Name = "lblAuhor";
            this.lblAuhor.Size = new System.Drawing.Size(56, 17);
            this.lblAuhor.TabIndex = 2;
            this.lblAuhor.Text = "Author:";
            // 
            // lblAuthorName
            // 
            this.lblAuthorName.AutoSize = true;
            this.lblAuthorName.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblAuthorName.Location = new System.Drawing.Point(67, 45);
            this.lblAuthorName.Name = "lblAuthorName";
            this.lblAuthorName.Size = new System.Drawing.Size(0, 17);
            this.lblAuthorName.TabIndex = 3;
            // 
            // lblDownloadStatus
            // 
            this.lblDownloadStatus.AutoSize = true;
            this.lblDownloadStatus.Location = new System.Drawing.Point(12, 383);
            this.lblDownloadStatus.Name = "lblDownloadStatus";
            this.lblDownloadStatus.Size = new System.Drawing.Size(120, 15);
            this.lblDownloadStatus.TabIndex = 4;
            this.lblDownloadStatus.Text = "Downloaded 100,00%";
            this.lblDownloadStatus.Visible = false;
            // 
            // cbAvailableMods
            // 
            this.cbAvailableMods.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAvailableMods.FormattingEnabled = true;
            this.cbAvailableMods.Location = new System.Drawing.Point(109, 12);
            this.cbAvailableMods.Name = "cbAvailableMods";
            this.cbAvailableMods.Size = new System.Drawing.Size(239, 23);
            this.cbAvailableMods.TabIndex = 5;
            this.cbAvailableMods.SelectedIndexChanged += new System.EventHandler(this.cbAvailableMods_SelectedIndexChanged);
            // 
            // txtModDescription
            // 
            this.txtModDescription.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.txtModDescription.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtModDescription.Location = new System.Drawing.Point(12, 91);
            this.txtModDescription.Multiline = true;
            this.txtModDescription.Name = "txtModDescription";
            this.txtModDescription.ReadOnly = true;
            this.txtModDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtModDescription.Size = new System.Drawing.Size(336, 289);
            this.txtModDescription.TabIndex = 6;
            // 
            // pbModPreview
            // 
            this.pbModPreview.Location = new System.Drawing.Point(354, 12);
            this.pbModPreview.Name = "pbModPreview";
            this.pbModPreview.Size = new System.Drawing.Size(276, 271);
            this.pbModPreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbModPreview.TabIndex = 7;
            this.pbModPreview.TabStop = false;
            // 
            // btnInstallMod
            // 
            this.btnInstallMod.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(93)))), ((int)(((byte)(117)))));
            this.btnInstallMod.FlatAppearance.BorderSize = 0;
            this.btnInstallMod.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInstallMod.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnInstallMod.ForeColor = System.Drawing.Color.White;
            this.btnInstallMod.IconChar = FontAwesome.Sharp.IconChar.Download;
            this.btnInstallMod.IconColor = System.Drawing.Color.White;
            this.btnInstallMod.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnInstallMod.IconSize = 32;
            this.btnInstallMod.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.btnInstallMod.Location = new System.Drawing.Point(354, 289);
            this.btnInstallMod.Name = "btnInstallMod";
            this.btnInstallMod.Padding = new System.Windows.Forms.Padding(20, 0, 20, 0);
            this.btnInstallMod.Size = new System.Drawing.Size(276, 43);
            this.btnInstallMod.TabIndex = 8;
            this.btnInstallMod.Text = "Install";
            this.btnInstallMod.UseVisualStyleBackColor = false;
            this.btnInstallMod.Click += new System.EventHandler(this.btnInstallMod_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(93)))), ((int)(((byte)(117)))));
            this.btnUpdate.Enabled = false;
            this.btnUpdate.FlatAppearance.BorderSize = 0;
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnUpdate.ForeColor = System.Drawing.Color.White;
            this.btnUpdate.IconChar = FontAwesome.Sharp.IconChar.SyncAlt;
            this.btnUpdate.IconColor = System.Drawing.Color.White;
            this.btnUpdate.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnUpdate.IconSize = 32;
            this.btnUpdate.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.btnUpdate.Location = new System.Drawing.Point(354, 337);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Padding = new System.Windows.Forms.Padding(20, 0, 20, 0);
            this.btnUpdate.Size = new System.Drawing.Size(276, 43);
            this.btnUpdate.TabIndex = 9;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Visible = false;
            // 
            // pgrbDownload
            // 
            this.pgrbDownload.Location = new System.Drawing.Point(138, 383);
            this.pgrbDownload.Name = "pgrbDownload";
            this.pgrbDownload.Size = new System.Drawing.Size(492, 15);
            this.pgrbDownload.TabIndex = 10;
            this.pgrbDownload.Visible = false;
            // 
            // InstallModsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(642, 410);
            this.Controls.Add(this.pgrbDownload);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnInstallMod);
            this.Controls.Add(this.pbModPreview);
            this.Controls.Add(this.txtModDescription);
            this.Controls.Add(this.cbAvailableMods);
            this.Controls.Add(this.lblDownloadStatus);
            this.Controls.Add(this.lblAuthorName);
            this.Controls.Add(this.lblAuhor);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.lblAviableMods);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "InstallModsForm";
            this.Text = "INSTALL MODS";
            ((System.ComponentModel.ISupportInitialize)(this.pbModPreview)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblAviableMods;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Label lblAuhor;
        private System.Windows.Forms.Label lblAuthorName;
        private System.Windows.Forms.Label lblDownloadStatus;
        private System.Windows.Forms.ComboBox cbAvailableMods;
        private System.Windows.Forms.TextBox txtModDescription;
        private System.Windows.Forms.PictureBox pbModPreview;
        private FontAwesome.Sharp.IconButton btnInstallMod;
        private FontAwesome.Sharp.IconButton btnUpdate;
        private CustomProgressBar pgrbDownload;
    }
}