using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace AmongUsModManager.Forms
{
    public partial class ManageModsForm : Form
    {
        private int _currentSelectedIndex = -1;
        private bool _isRunning = false;
        Process auProc;

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
                return (int)cbAvailableMods.SelectedValue;
            else
                return -1;
        }

        private void cbAvailableMods_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = GetCurrentId();
            _currentSelectedIndex = Settings.installedMods.FindIndex(f => f.Id == id);

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
                    pbModPreview.Image = AmongUsModManager.Properties.Resources.nopreview;
                }

                if (ModUpdater.availableMods[id].Github && Settings.checkModUpdates)
                {
                    if (ModUpdater.CheckForModUpdates(ModUpdater.availableMods[id].Id))
                    {
                        lblUpdate.Visible = true;
                    }
                    else
                    {
                        lblUpdate.Visible = false;
                    }
                }
                else
                {
                    lblUpdate.Visible = false;
                }
            }
        }

        private void DeleteFolder(string folder)
        {
            if (Directory.Exists(folder))
            {
                try
                {
                    Directory.Delete(folder, true);
                    Utils.Alert("Mod deleted.", AlertForm.enmType.Success);
                }
                catch (Exception)
                {
                    Utils.Alert("Error deleting mod folder.", AlertForm.enmType.Error);
                }
                
            }
            else
                Utils.Alert("Mod folder already deleted!", AlertForm.enmType.Error);
        }

        private void btnStartMod_Click(object sender, EventArgs e)
        {
            if (_isRunning)
                StopAmongUs();
            else
                StartMod();
        }

        private void StopAmongUs()
        {
            try
            {
                auProc.Kill();
                AUClosed();
            }
            catch (Exception)
            {
                Utils.Alert("Couldn' t close Among Us", AlertForm.enmType.Error);
            }
        }

        private void StartMod()
        {
            if (_currentSelectedIndex >= 0)
            {
                try
                {
                    StartAmongUs();
                }
                catch (Exception)
                {
                    Utils.Alert("Couldn' t start Among Us", AlertForm.enmType.Error);
                }
            }
        }

        private void StartAmongUs()
        {
            string startPath = Path.Combine(Settings.installedMods[_currentSelectedIndex].Location, Settings.exeName);

            auProc = Process.Start(startPath);
            auProc.EnableRaisingEvents = true;
            auProc.Exited += AmongUs_Stopped;
            btnStartMod.Text = "Stop Among Us";
            btnStartMod.IconChar = FontAwesome.Sharp.IconChar.Stop;
            _isRunning = true;
            cbAvailableMods.Enabled = false;
            Utils.Alert("Among Us started. This can take some time.", AlertForm.enmType.Success);

            btnDeleteMod.Enabled = false;
        }

        private void AUClosed()
        {
            btnStartMod.Invoke(new Action(() => btnStartMod.Text = "Start"));
            btnStartMod.Invoke(new Action(() => btnStartMod.IconChar = FontAwesome.Sharp.IconChar.Play));
            
            _isRunning = false;
            btnDeleteMod.Invoke(new Action(() => btnDeleteMod.Enabled = true));
            cbAvailableMods.Invoke(new Action(() => cbAvailableMods.Enabled = true)); 
        }

        private void AmongUs_Stopped(object sender, EventArgs e)
        {
            AUClosed();
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
