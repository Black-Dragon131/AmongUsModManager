
namespace XMLEditor
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
            this.lvMods = new System.Windows.Forms.ListView();
            this.lblName = new System.Windows.Forms.Label();
            this.tbModName = new System.Windows.Forms.TextBox();
            this.tbAuthor = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cbGithub = new System.Windows.Forms.CheckBox();
            this.cbBepInEx = new System.Windows.Forms.CheckBox();
            this.cbAppid = new System.Windows.Forms.CheckBox();
            this.tbPreview = new System.Windows.Forms.TextBox();
            this.tbDownload = new System.Windows.Forms.TextBox();
            this.tbDescription = new System.Windows.Forms.TextBox();
            this.numId = new System.Windows.Forms.NumericUpDown();
            this.pbPreview = new System.Windows.Forms.PictureBox();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numId)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPreview)).BeginInit();
            this.SuspendLayout();
            // 
            // lvMods
            // 
            this.lvMods.HideSelection = false;
            this.lvMods.Location = new System.Drawing.Point(12, 12);
            this.lvMods.MultiSelect = false;
            this.lvMods.Name = "lvMods";
            this.lvMods.Size = new System.Drawing.Size(296, 563);
            this.lvMods.TabIndex = 0;
            this.lvMods.UseCompatibleStateImageBehavior = false;
            this.lvMods.View = System.Windows.Forms.View.List;
            this.lvMods.SelectedIndexChanged += new System.EventHandler(this.lvMods_SelectedIndexChanged);
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(314, 12);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(57, 13);
            this.lblName.TabIndex = 1;
            this.lblName.Text = "Mod name";
            // 
            // tbModName
            // 
            this.tbModName.Location = new System.Drawing.Point(400, 9);
            this.tbModName.Name = "tbModName";
            this.tbModName.Size = new System.Drawing.Size(259, 20);
            this.tbModName.TabIndex = 2;
            // 
            // tbAuthor
            // 
            this.tbAuthor.Location = new System.Drawing.Point(400, 35);
            this.tbAuthor.Name = "tbAuthor";
            this.tbAuthor.Size = new System.Drawing.Size(259, 20);
            this.tbAuthor.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(314, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Author";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(314, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Preview URL";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(314, 94);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Download URL";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(314, 120);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Description";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(314, 209);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(16, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Id";
            // 
            // cbGithub
            // 
            this.cbGithub.AutoSize = true;
            this.cbGithub.Location = new System.Drawing.Point(317, 143);
            this.cbGithub.Name = "cbGithub";
            this.cbGithub.Size = new System.Drawing.Size(63, 17);
            this.cbGithub.TabIndex = 9;
            this.cbGithub.Text = "Github?";
            this.cbGithub.UseVisualStyleBackColor = true;
            // 
            // cbBepInEx
            // 
            this.cbBepInEx.AutoSize = true;
            this.cbBepInEx.Location = new System.Drawing.Point(317, 166);
            this.cbBepInEx.Name = "cbBepInEx";
            this.cbBepInEx.Size = new System.Drawing.Size(72, 17);
            this.cbBepInEx.TabIndex = 10;
            this.cbBepInEx.Text = "BepInEx?";
            this.cbBepInEx.UseVisualStyleBackColor = true;
            // 
            // cbAppid
            // 
            this.cbAppid.AutoSize = true;
            this.cbAppid.Location = new System.Drawing.Point(317, 189);
            this.cbAppid.Name = "cbAppid";
            this.cbAppid.Size = new System.Drawing.Size(59, 17);
            this.cbAppid.TabIndex = 11;
            this.cbAppid.Text = "Appid?";
            this.cbAppid.UseVisualStyleBackColor = true;
            // 
            // tbPreview
            // 
            this.tbPreview.Location = new System.Drawing.Point(400, 65);
            this.tbPreview.Name = "tbPreview";
            this.tbPreview.Size = new System.Drawing.Size(259, 20);
            this.tbPreview.TabIndex = 12;
            // 
            // tbDownload
            // 
            this.tbDownload.Location = new System.Drawing.Point(400, 91);
            this.tbDownload.Name = "tbDownload";
            this.tbDownload.Size = new System.Drawing.Size(259, 20);
            this.tbDownload.TabIndex = 13;
            // 
            // tbDescription
            // 
            this.tbDescription.Location = new System.Drawing.Point(400, 117);
            this.tbDescription.Name = "tbDescription";
            this.tbDescription.Size = new System.Drawing.Size(259, 20);
            this.tbDescription.TabIndex = 14;
            // 
            // numId
            // 
            this.numId.Location = new System.Drawing.Point(400, 207);
            this.numId.Name = "numId";
            this.numId.Size = new System.Drawing.Size(50, 20);
            this.numId.TabIndex = 15;
            // 
            // pbPreview
            // 
            this.pbPreview.Location = new System.Drawing.Point(317, 233);
            this.pbPreview.Name = "pbPreview";
            this.pbPreview.Size = new System.Drawing.Size(342, 342);
            this.pbPreview.TabIndex = 16;
            this.pbPreview.TabStop = false;
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(584, 204);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(75, 23);
            this.btnNew.TabIndex = 17;
            this.btnNew.Text = "New";
            this.btnNew.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(503, 204);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 18;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(671, 589);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.pbPreview);
            this.Controls.Add(this.numId);
            this.Controls.Add(this.tbDescription);
            this.Controls.Add(this.tbDownload);
            this.Controls.Add(this.tbPreview);
            this.Controls.Add(this.cbAppid);
            this.Controls.Add(this.cbBepInEx);
            this.Controls.Add(this.cbGithub);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbAuthor);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbModName);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.lvMods);
            this.Name = "MainForm";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.numId)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPreview)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvMods;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox tbModName;
        private System.Windows.Forms.TextBox tbAuthor;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox cbGithub;
        private System.Windows.Forms.CheckBox cbBepInEx;
        private System.Windows.Forms.CheckBox cbAppid;
        private System.Windows.Forms.TextBox tbPreview;
        private System.Windows.Forms.TextBox tbDownload;
        private System.Windows.Forms.TextBox tbDescription;
        private System.Windows.Forms.NumericUpDown numId;
        private System.Windows.Forms.PictureBox pbPreview;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnSave;
    }
}

