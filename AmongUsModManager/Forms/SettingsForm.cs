﻿using System;
using System.Windows.Forms;

namespace AmongUsModManager.Forms
{
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            txtBoxPath.Text = Settings.amongUsPath;
            cbModUpdates.Checked = Settings.checkModUpdates;
            cbAummUpdates.Checked = Settings.checkAummUpdates;
        }

        private void btnSearchPath_Click(object sender, EventArgs e)
        {
            Settings.CheckValidFolder(Settings.GetFolderByDialog());
            Init();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Settings.amongUsPath = txtBoxPath.Text;
            Settings.SaveConfig();
        }

        private void cbModUpdates_CheckedChanged(object sender, EventArgs e)
        {
            Settings.checkModUpdates = cbModUpdates.Checked;
        }

        private void cbAummUpdates_CheckedChanged(object sender, EventArgs e)
        {
            Settings.checkAummUpdates = cbAummUpdates.Checked;
        }
    }
}