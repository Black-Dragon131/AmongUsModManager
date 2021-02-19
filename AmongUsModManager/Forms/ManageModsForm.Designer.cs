
namespace AmongUsModManager.Forms
{
    partial class ManageModsForm
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
            this.cbAvailableMods = new System.Windows.Forms.ComboBox();
            this.txtModDescription = new System.Windows.Forms.TextBox();
            this.pbModPreview = new System.Windows.Forms.PictureBox();
            this.btnStartMod = new FontAwesome.Sharp.IconButton();
            this.btnDeleteMod = new FontAwesome.Sharp.IconButton();
            ((System.ComponentModel.ISupportInitialize)(this.pbModPreview)).BeginInit();
            this.SuspendLayout();
            // 
            // lblAviableMods
            // 
            this.lblAviableMods.AutoSize = true;
            this.lblAviableMods.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Underline);
            this.lblAviableMods.Location = new System.Drawing.Point(12, 16);
            this.lblAviableMods.Name = "lblAviableMods";
            this.lblAviableMods.Size = new System.Drawing.Size(87, 15);
            this.lblAviableMods.TabIndex = 0;
            this.lblAviableMods.Text = "Installed Mods:";
            // 
            // cbAvailableMods
            // 
            this.cbAvailableMods.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAvailableMods.FormattingEnabled = true;
            this.cbAvailableMods.Location = new System.Drawing.Point(109, 12);
            this.cbAvailableMods.Name = "cbAvailableMods";
            this.cbAvailableMods.Size = new System.Drawing.Size(239, 23);
            this.cbAvailableMods.TabIndex = 1;
            this.cbAvailableMods.SelectedIndexChanged += new System.EventHandler(this.cbAvailableMods_SelectedIndexChanged);
            // 
            // txtModDescription
            // 
            this.txtModDescription.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.txtModDescription.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtModDescription.Location = new System.Drawing.Point(12, 41);
            this.txtModDescription.Multiline = true;
            this.txtModDescription.Name = "txtModDescription";
            this.txtModDescription.ReadOnly = true;
            this.txtModDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtModDescription.Size = new System.Drawing.Size(336, 357);
            this.txtModDescription.TabIndex = 2;
            // 
            // pbModPreview
            // 
            this.pbModPreview.Location = new System.Drawing.Point(354, 12);
            this.pbModPreview.Name = "pbModPreview";
            this.pbModPreview.Size = new System.Drawing.Size(276, 260);
            this.pbModPreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbModPreview.TabIndex = 3;
            this.pbModPreview.TabStop = false;
            // 
            // btnStartMod
            // 
            this.btnStartMod.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(93)))), ((int)(((byte)(117)))));
            this.btnStartMod.Enabled = false;
            this.btnStartMod.FlatAppearance.BorderSize = 0;
            this.btnStartMod.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStartMod.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnStartMod.ForeColor = System.Drawing.Color.White;
            this.btnStartMod.IconChar = FontAwesome.Sharp.IconChar.Play;
            this.btnStartMod.IconColor = System.Drawing.Color.White;
            this.btnStartMod.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnStartMod.IconSize = 32;
            this.btnStartMod.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.btnStartMod.Location = new System.Drawing.Point(354, 278);
            this.btnStartMod.Name = "btnStartMod";
            this.btnStartMod.Size = new System.Drawing.Size(276, 41);
            this.btnStartMod.TabIndex = 4;
            this.btnStartMod.Text = "Start";
            this.btnStartMod.UseVisualStyleBackColor = false;
            this.btnStartMod.Click += new System.EventHandler(this.btnStartMod_Click);
            // 
            // btnDeleteMod
            // 
            this.btnDeleteMod.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(131)))), ((int)(((byte)(84)))));
            this.btnDeleteMod.Enabled = false;
            this.btnDeleteMod.FlatAppearance.BorderSize = 0;
            this.btnDeleteMod.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteMod.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnDeleteMod.ForeColor = System.Drawing.Color.White;
            this.btnDeleteMod.IconChar = FontAwesome.Sharp.IconChar.TrashAlt;
            this.btnDeleteMod.IconColor = System.Drawing.Color.White;
            this.btnDeleteMod.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnDeleteMod.IconSize = 32;
            this.btnDeleteMod.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.btnDeleteMod.Location = new System.Drawing.Point(354, 325);
            this.btnDeleteMod.Name = "btnDeleteMod";
            this.btnDeleteMod.Size = new System.Drawing.Size(276, 41);
            this.btnDeleteMod.TabIndex = 5;
            this.btnDeleteMod.Text = "Delete";
            this.btnDeleteMod.UseVisualStyleBackColor = false;
            this.btnDeleteMod.Click += new System.EventHandler(this.btnDeleteMod_Click);
            // 
            // ManageModsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(642, 410);
            this.Controls.Add(this.btnDeleteMod);
            this.Controls.Add(this.btnStartMod);
            this.Controls.Add(this.pbModPreview);
            this.Controls.Add(this.txtModDescription);
            this.Controls.Add(this.cbAvailableMods);
            this.Controls.Add(this.lblAviableMods);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ManageModsForm";
            this.Text = "MANAGE MODS";
            ((System.ComponentModel.ISupportInitialize)(this.pbModPreview)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblAviableMods;
        private System.Windows.Forms.ComboBox cbAvailableMods;
        private System.Windows.Forms.TextBox txtModDescription;
        private System.Windows.Forms.PictureBox pbModPreview;
        private FontAwesome.Sharp.IconButton btnStartMod;
        private FontAwesome.Sharp.IconButton btnDeleteMod;
    }
}