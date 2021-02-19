
namespace AmongUsModManager
{
    partial class MainForm
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.panelMenu = new System.Windows.Forms.Panel();
            this.btnMenuSettings = new FontAwesome.Sharp.IconButton();
            this.btnMenuManageMods = new FontAwesome.Sharp.IconButton();
            this.btnMenuInstallMods = new FontAwesome.Sharp.IconButton();
            this.panelLogo = new System.Windows.Forms.Panel();
            this.btnUpdate = new FontAwesome.Sharp.IconButton();
            this.lblVersion = new System.Windows.Forms.Label();
            this.panelTabContainer = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnClose = new FontAwesome.Sharp.IconButton();
            this.panelMenu.SuspendLayout();
            this.panelLogo.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMenu
            // 
            this.panelMenu.Controls.Add(this.btnMenuSettings);
            this.panelMenu.Controls.Add(this.btnMenuManageMods);
            this.panelMenu.Controls.Add(this.btnMenuInstallMods);
            this.panelMenu.Controls.Add(this.panelLogo);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelMenu.Location = new System.Drawing.Point(0, 0);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(160, 460);
            this.panelMenu.TabIndex = 0;
            // 
            // btnMenuSettings
            // 
            this.btnMenuSettings.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnMenuSettings.FlatAppearance.BorderSize = 0;
            this.btnMenuSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMenuSettings.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnMenuSettings.ForeColor = System.Drawing.Color.White;
            this.btnMenuSettings.IconChar = FontAwesome.Sharp.IconChar.Cog;
            this.btnMenuSettings.IconColor = System.Drawing.Color.White;
            this.btnMenuSettings.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnMenuSettings.IconSize = 32;
            this.btnMenuSettings.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnMenuSettings.Location = new System.Drawing.Point(0, 410);
            this.btnMenuSettings.Name = "btnMenuSettings";
            this.btnMenuSettings.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.btnMenuSettings.Size = new System.Drawing.Size(160, 50);
            this.btnMenuSettings.TabIndex = 3;
            this.btnMenuSettings.Text = "Settings";
            this.btnMenuSettings.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMenuSettings.UseVisualStyleBackColor = true;
            this.btnMenuSettings.Click += new System.EventHandler(this.btnMenuSettings_Click);
            // 
            // btnMenuManageMods
            // 
            this.btnMenuManageMods.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnMenuManageMods.FlatAppearance.BorderSize = 0;
            this.btnMenuManageMods.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMenuManageMods.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnMenuManageMods.ForeColor = System.Drawing.Color.White;
            this.btnMenuManageMods.IconChar = FontAwesome.Sharp.IconChar.Tools;
            this.btnMenuManageMods.IconColor = System.Drawing.Color.White;
            this.btnMenuManageMods.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnMenuManageMods.IconSize = 32;
            this.btnMenuManageMods.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnMenuManageMods.Location = new System.Drawing.Point(0, 100);
            this.btnMenuManageMods.Name = "btnMenuManageMods";
            this.btnMenuManageMods.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.btnMenuManageMods.Size = new System.Drawing.Size(160, 50);
            this.btnMenuManageMods.TabIndex = 2;
            this.btnMenuManageMods.Text = "Manage";
            this.btnMenuManageMods.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMenuManageMods.UseVisualStyleBackColor = true;
            this.btnMenuManageMods.Click += new System.EventHandler(this.btnMenuManageMods_Click);
            // 
            // btnMenuInstallMods
            // 
            this.btnMenuInstallMods.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnMenuInstallMods.FlatAppearance.BorderSize = 0;
            this.btnMenuInstallMods.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMenuInstallMods.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnMenuInstallMods.ForeColor = System.Drawing.Color.White;
            this.btnMenuInstallMods.IconChar = FontAwesome.Sharp.IconChar.Download;
            this.btnMenuInstallMods.IconColor = System.Drawing.Color.White;
            this.btnMenuInstallMods.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnMenuInstallMods.IconSize = 32;
            this.btnMenuInstallMods.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnMenuInstallMods.Location = new System.Drawing.Point(0, 50);
            this.btnMenuInstallMods.Name = "btnMenuInstallMods";
            this.btnMenuInstallMods.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.btnMenuInstallMods.Size = new System.Drawing.Size(160, 50);
            this.btnMenuInstallMods.TabIndex = 1;
            this.btnMenuInstallMods.Text = "Install";
            this.btnMenuInstallMods.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMenuInstallMods.UseVisualStyleBackColor = true;
            this.btnMenuInstallMods.Click += new System.EventHandler(this.btnMenuInstallMods_Click);
            // 
            // panelLogo
            // 
            this.panelLogo.Controls.Add(this.btnUpdate);
            this.panelLogo.Controls.Add(this.lblVersion);
            this.panelLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelLogo.Location = new System.Drawing.Point(0, 0);
            this.panelLogo.Name = "panelLogo";
            this.panelLogo.Size = new System.Drawing.Size(160, 50);
            this.panelLogo.TabIndex = 0;
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(131)))), ((int)(((byte)(84)))));
            this.btnUpdate.FlatAppearance.BorderSize = 0;
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.ForeColor = System.Drawing.Color.White;
            this.btnUpdate.IconChar = FontAwesome.Sharp.IconChar.ArrowAltCircleDown;
            this.btnUpdate.IconColor = System.Drawing.Color.White;
            this.btnUpdate.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnUpdate.IconSize = 36;
            this.btnUpdate.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.btnUpdate.Location = new System.Drawing.Point(0, 0);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Padding = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.btnUpdate.Size = new System.Drawing.Size(160, 50);
            this.btnUpdate.TabIndex = 0;
            this.btnUpdate.Text = "UPDATE NOW";
            this.btnUpdate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Visible = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // lblVersion
            // 
            this.lblVersion.AutoSize = true;
            this.lblVersion.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVersion.ForeColor = System.Drawing.Color.White;
            this.lblVersion.Location = new System.Drawing.Point(38, 17);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(49, 17);
            this.lblVersion.TabIndex = 4;
            this.lblVersion.Text = "AUMM";
            // 
            // panelTabContainer
            // 
            this.panelTabContainer.Location = new System.Drawing.Point(160, 50);
            this.panelTabContainer.Name = "panelTabContainer";
            this.panelTabContainer.Size = new System.Drawing.Size(642, 410);
            this.panelTabContainer.TabIndex = 1;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(328, 7);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(69, 30);
            this.lblTitle.TabIndex = 2;
            this.lblTitle.Text = "MAIN";
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(131)))), ((int)(((byte)(84)))));
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.IconChar = FontAwesome.Sharp.IconChar.Times;
            this.btnClose.IconColor = System.Drawing.Color.White;
            this.btnClose.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnClose.IconSize = 26;
            this.btnClose.Location = new System.Drawing.Point(765, 14);
            this.btnClose.Name = "btnClose";
            this.btnClose.Padding = new System.Windows.Forms.Padding(1, 3, 0, 0);
            this.btnClose.Size = new System.Drawing.Size(25, 25);
            this.btnClose.TabIndex = 3;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(49)))), ((int)(((byte)(66)))));
            this.ClientSize = new System.Drawing.Size(802, 460);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.panelTabContainer);
            this.Controls.Add(this.panelMenu);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AmongUsModManager";
            this.panelMenu.ResumeLayout(false);
            this.panelLogo.ResumeLayout(false);
            this.panelLogo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.Panel panelLogo;
        private System.Windows.Forms.Panel panelTabContainer;
        private System.Windows.Forms.Label lblTitle;
        private FontAwesome.Sharp.IconButton btnMenuSettings;
        private FontAwesome.Sharp.IconButton btnMenuManageMods;
        private FontAwesome.Sharp.IconButton btnMenuInstallMods;
        private FontAwesome.Sharp.IconButton btnClose;
        private System.Windows.Forms.Label lblVersion;
        private FontAwesome.Sharp.IconButton btnUpdate;
    }
}

