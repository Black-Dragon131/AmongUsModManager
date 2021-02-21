using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace AmongUsModManager.Forms
{
    public partial class ManageModsForm : Form
    {
        private int _currentSelectedIndex = -1;

        public ManageModsForm()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            PopulateList();
        }

        private void PopulateList()
        {
            //Setup data binding
            cbAvailableMods.DisplayMember = "Name";
            cbAvailableMods.ValueMember = "Id";
            cbAvailableMods.DataSource = Settings.installedMods;
        }

        private int GetCurrentId()
        {
            if (cbAvailableMods.DataSource != null)
                return int.Parse((string)cbAvailableMods.SelectedValue);
            else
                return -1;
        }

        private void cbAvailableMods_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = GetCurrentId();
            _currentSelectedIndex = Settings.installedMods.FindIndex(f => f.Id == id.ToString());

            if (_currentSelectedIndex >= 0)
            {
                btnDeleteMod.Enabled = true;
                btnStartMod.Enabled = true;
                string text = Settings.installedMods[_currentSelectedIndex].Description.Replace("§", Environment.NewLine);
                txtModDescription.Text = text;
               
                if (!String.IsNullOrEmpty(Settings.installedMods[_currentSelectedIndex].Preview_url))
                {
                    pbModPreview.Load(Settings.installedMods[_currentSelectedIndex].Preview_url);
                }
                else
                {
                    pbModPreview.Image = null;
                }
            }
        }

        private void DeleteFolder(string folder)
        {
            if (Directory.Exists(folder))
                Directory.Delete(folder, true);
            else
                Utils.Alert("Mod folder already deleted!", AlertForm.enmType.Error);
        }

        private void btnStartMod_Click(object sender, EventArgs e)
        {
            StartMod();
        }

        private void StartMod()
        {
            if (_currentSelectedIndex >= 0)
            {
                string startPath = Path.Combine(Settings.installedMods[_currentSelectedIndex].Location, Settings.exeName);
                Process.Start(startPath);
            }
        }

        private void btnDeleteMod_Click(object sender, EventArgs e)
        {
            DeleteMod();
        }

        private void DeleteMod()
        {
            if (_currentSelectedIndex >= 0)
            {
                DeleteFolder(Settings.installedMods[_currentSelectedIndex].Location);
                Settings.installedMods.RemoveAt(_currentSelectedIndex);
                Settings.SaveConfig();
                cbAvailableMods.DataSource = null;
                txtModDescription.Text = "";
                pbModPreview.Image = null;
                btnDeleteMod.Enabled = false;
                btnStartMod.Enabled = false;
                PopulateList();
            }
        }
    }
}
