
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
            this.txtBoxPath = new System.Windows.Forms.TextBox();
            this.btnSearchPath = new System.Windows.Forms.Button();
            this.btnSave = new FontAwesome.Sharp.IconButton();
            this.cbModUpdates = new System.Windows.Forms.CheckBox();
            this.lblCheckModUpdates = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblPath
            // 
            this.lblPath.AutoSize = true;
            this.lblPath.Location = new System.Drawing.Point(12, 15);
            this.lblPath.Name = "lblPath";
            this.lblPath.Size = new System.Drawing.Size(93, 15);
            this.lblPath.TabIndex = 0;
            this.lblPath.Text = "Among Us Path:";
            // 
            // txtBoxPath
            // 
            this.txtBoxPath.Location = new System.Drawing.Point(150, 12);
            this.txtBoxPath.Name = "txtBoxPath";
            this.txtBoxPath.ReadOnly = true;
            this.txtBoxPath.Size = new System.Drawing.Size(430, 23);
            this.txtBoxPath.TabIndex = 2;
            // 
            // btnSearchPath
            // 
            this.btnSearchPath.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(93)))), ((int)(((byte)(117)))));
            this.btnSearchPath.FlatAppearance.BorderSize = 0;
            this.btnSearchPath.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearchPath.ForeColor = System.Drawing.Color.White;
            this.btnSearchPath.Location = new System.Drawing.Point(586, 11);
            this.btnSearchPath.Name = "btnSearchPath";
            this.btnSearchPath.Size = new System.Drawing.Size(44, 24);
            this.btnSearchPath.TabIndex = 3;
            this.btnSearchPath.Text = "...";
            this.btnSearchPath.UseVisualStyleBackColor = false;
            this.btnSearchPath.Click += new System.EventHandler(this.btnSearchPath_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(93)))), ((int)(((byte)(117)))));
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
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
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Save";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // cbModUpdates
            // 
            this.cbModUpdates.AutoSize = true;
            this.cbModUpdates.Location = new System.Drawing.Point(150, 40);
            this.cbModUpdates.Name = "cbModUpdates";
            this.cbModUpdates.Size = new System.Drawing.Size(15, 14);
            this.cbModUpdates.TabIndex = 6;
            this.cbModUpdates.UseVisualStyleBackColor = true;
            this.cbModUpdates.CheckedChanged += new System.EventHandler(this.cbModUpdates_CheckedChanged);
            // 
            // lblCheckModUpdates
            // 
            this.lblCheckModUpdates.AutoSize = true;
            this.lblCheckModUpdates.Location = new System.Drawing.Point(12, 40);
            this.lblCheckModUpdates.Name = "lblCheckModUpdates";
            this.lblCheckModUpdates.Size = new System.Drawing.Size(132, 15);
            this.lblCheckModUpdates.TabIndex = 7;
            this.lblCheckModUpdates.Text = "Check for Mod Updates";
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(642, 410);
            this.Controls.Add(this.lblCheckModUpdates);
            this.Controls.Add(this.cbModUpdates);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnSearchPath);
            this.Controls.Add(this.txtBoxPath);
            this.Controls.Add(this.lblPath);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SettingsForm";
            this.Text = "SETTINGS";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblPath;
        private System.Windows.Forms.TextBox txtBoxPath;
        private System.Windows.Forms.Button btnSearchPath;
        private FontAwesome.Sharp.IconButton btnSave;
        private System.Windows.Forms.CheckBox cbModUpdates;
        private System.Windows.Forms.Label lblCheckModUpdates;
    }
}