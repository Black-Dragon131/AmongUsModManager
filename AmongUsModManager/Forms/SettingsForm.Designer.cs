
namespace AmongUsModManager.Forms
{
    partial class SettingsForm
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
            this.lblPath = new System.Windows.Forms.Label();
            this.cbModUpdates = new System.Windows.Forms.CheckBox();
            this.txtBoxPath = new System.Windows.Forms.TextBox();
            this.btnSearchPath = new FontAwesome.Sharp.IconButton();
            this.btnSave = new FontAwesome.Sharp.IconButton();
            this.cbAummUpdates = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // lblPath
            // 
            this.lblPath.AutoSize = true;
            this.lblPath.Location = new System.Drawing.Point(12, 16);
            this.lblPath.Name = "lblPath";
            this.lblPath.Size = new System.Drawing.Size(93, 15);
            this.lblPath.TabIndex = 0;
            this.lblPath.Text = "Among Us Path:";
            // 
            // cbModUpdates
            // 
            this.cbModUpdates.AutoSize = true;
            this.cbModUpdates.FlatAppearance.BorderSize = 0;
            this.cbModUpdates.Location = new System.Drawing.Point(15, 66);
            this.cbModUpdates.Name = "cbModUpdates";
            this.cbModUpdates.Size = new System.Drawing.Size(151, 19);
            this.cbModUpdates.TabIndex = 2;
            this.cbModUpdates.Text = "Check for Mod Updates";
            this.cbModUpdates.UseVisualStyleBackColor = true;
            this.cbModUpdates.CheckedChanged += new System.EventHandler(this.cbModUpdates_CheckedChanged);
            // 
            // txtBoxPath
            // 
            this.txtBoxPath.BackColor = System.Drawing.SystemColors.Control;
            this.txtBoxPath.Location = new System.Drawing.Point(150, 12);
            this.txtBoxPath.Name = "txtBoxPath";
            this.txtBoxPath.ReadOnly = true;
            this.txtBoxPath.Size = new System.Drawing.Size(430, 23);
            this.txtBoxPath.TabIndex = 3;
            // 
            // btnSearchPath
            // 
            this.btnSearchPath.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(93)))), ((int)(((byte)(117)))));
            this.btnSearchPath.FlatAppearance.BorderSize = 0;
            this.btnSearchPath.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearchPath.ForeColor = System.Drawing.Color.White;
            this.btnSearchPath.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btnSearchPath.IconColor = System.Drawing.Color.Black;
            this.btnSearchPath.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnSearchPath.Location = new System.Drawing.Point(586, 11);
            this.btnSearchPath.Name = "btnSearchPath";
            this.btnSearchPath.Size = new System.Drawing.Size(44, 24);
            this.btnSearchPath.TabIndex = 4;
            this.btnSearchPath.Text = "...";
            this.btnSearchPath.UseVisualStyleBackColor = false;
            this.btnSearchPath.Click += new System.EventHandler(this.btnSearchPath_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(93)))), ((int)(((byte)(117)))));
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.IconChar = FontAwesome.Sharp.IconChar.Save;
            this.btnSave.IconColor = System.Drawing.Color.White;
            this.btnSave.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnSave.IconSize = 32;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.btnSave.Location = new System.Drawing.Point(524, 357);
            this.btnSave.Name = "btnSave";
            this.btnSave.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.btnSave.Size = new System.Drawing.Size(106, 41);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "Save";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // cbAummUpdates
            // 
            this.cbAummUpdates.AutoSize = true;
            this.cbAummUpdates.FlatAppearance.BorderSize = 0;
            this.cbAummUpdates.Location = new System.Drawing.Point(15, 41);
            this.cbAummUpdates.Name = "cbAummUpdates";
            this.cbAummUpdates.Size = new System.Drawing.Size(164, 19);
            this.cbAummUpdates.TabIndex = 6;
            this.cbAummUpdates.Text = "Check for AUMM Updates";
            this.cbAummUpdates.UseVisualStyleBackColor = true;
            this.cbAummUpdates.CheckedChanged += new System.EventHandler(this.cbAummUpdates_CheckedChanged);
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(642, 410);
            this.Controls.Add(this.cbAummUpdates);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnSearchPath);
            this.Controls.Add(this.txtBoxPath);
            this.Controls.Add(this.cbModUpdates);
            this.Controls.Add(this.lblPath);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SettingsForm";
            this.Text = "SETTINGS";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblPath;
        private System.Windows.Forms.CheckBox cbModUpdates;
        private System.Windows.Forms.TextBox txtBoxPath;
        private FontAwesome.Sharp.IconButton btnSearchPath;
        private FontAwesome.Sharp.IconButton btnSave;
        private System.Windows.Forms.CheckBox cbAummUpdates;
    }
}