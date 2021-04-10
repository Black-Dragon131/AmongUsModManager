using AmongUsModManager.Forms;
using Newtonsoft.Json.Linq;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;

namespace AmongUsModManager
{
    public partial class MainForm : Form
    {
        #region UI
        protected override CreateParams CreateParams
        {
            get
            {
                const int CS_DROPSHADOW = 0x20000;
                CreateParams cp = base.CreateParams;
                cp.ClassStyle |= CS_DROPSHADOW;
                return cp;
            }
        }

        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case 0x84:
                    base.WndProc(ref m);
                    if ((int)m.Result == 0x1)
                        m.Result = (IntPtr)0x2;
                    return;
            }

            base.WndProc(ref m);
        }
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
         (
               int nLeftRect,
               int nTopRect,
               int nRightRect,
               int nBottomRect,
               int nWidthEllipse,
               int nHeightEllipse

         );
        #endregion

        private const string UPDATE_BASE_URL = "https://aumm.black-dragon131.de/";

        #if DEBUG
            private const string UPDATE_JSON_NAME = "aumm_debug.json";
        #else
            private const string UPDATE_JSON_NAME = "aumm.json";
        #endif
        private const string UPDATE_NAME = "AmongUsModManager_new.exe";
        private const string UPDATER = "AUMMUpdater.exe";
        private const string UPDATER_UPDATE = "AUMMUpdater_new.exe";
        private const string UPDATER_UPDATE_BAK = "AUMMUpdater_bak.exe";
        private Form _activeTab;
        private Button _activeButton;
        private WebClient _webClient;
        private bool _canSwitchTab = true;
        JObject updateJson;

        public MainForm()
        {
            InitializeComponent();
            Init();

            // Round corners
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));

            if (_activeTab == null)
            {
                ChangeTab(new InstallModsForm(this), btnMenuInstallMods);
            }
        }

        private void Init()
        {
            lblVersion.Text = $"AUMM v{Utils.majorVersion}.{Utils.minorVersion}";
            if (Settings.IsFirstRun())
            {
                MessageBox.Show("Install mods at your own risk.\nI am not responsible for any damage caused by installing and using mods!\nI am not the creator of the mods. Contact the author if you have problems with a mod!", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Settings.SearchInstallFolder();
                Settings.SaveConfig();
            }

            _webClient = new WebClient();

            if (Settings.checkAummUpdates)
                CheckForUpdate();
        }

        private void CheckForUpdate()
        {
            string url = Path.Combine(UPDATE_BASE_URL, UPDATE_JSON_NAME);

            _webClient.Headers.Add("user-agent", Utils.userAgent);
            string json;

            try
            {
                json = _webClient.DownloadString(url);
            }
            catch (Exception)
            {
                Utils.Alert($"Couldn' t download {UPDATE_JSON_NAME}", AlertForm.enmType.Error);
                return;
            }

            try
            {
                updateJson = JObject.Parse(json);
            }
            catch (Exception)
            {
                return;
            }
            
            int remoteMajorVersion = (int)updateJson["version"]["major_version"];
            int remoteMinorVersion = (int)updateJson["version"]["minor_version"];

            if (remoteMajorVersion > Utils.majorVersion || (remoteMajorVersion >= Utils.majorVersion && remoteMinorVersion > Utils.minorVersion))
            {
                Utils.Alert("New AUMM version available.", AlertForm.enmType.Info);
                btnUpdate.Visible = true;
            }

            int remoteUpdaterVersion = (int)updateJson["updater_version"]["version"];
            if (remoteUpdaterVersion > Settings.updaterVersion)
            {
                Utils.Alert("New Updater version available.", AlertForm.enmType.Info);
                btnUpdaterUpdate.Visible = true;
            }
        }

        private void ChangeTab(Form newTab, object btnSender)
        {
            if (!_canSwitchTab)
                return;

            if (_activeTab != null)
            {
                _activeTab.Close();
            }

            _activeTab = newTab;
            newTab.TopLevel = false;
            newTab.FormBorderStyle = FormBorderStyle.None;
            newTab.Dock = DockStyle.Fill;
            this.panelTabContainer.Controls.Add(newTab);
            this.panelTabContainer.Tag = newTab;
            newTab.BringToFront();
            newTab.Show();
            lblTitle.Text = newTab.Text;
            HighlightButton((Button)btnSender);
        }

        private void HighlightButton(Button button)
        {
            if (_activeButton != null)
            {
                _activeButton.BackColor = Utils.normalColor;
            }

            _activeButton = button;
            button.BackColor = Utils.highlightColor;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMenuInstallMods_Click(object sender, EventArgs e)
        {
            ChangeTab(new InstallModsForm(this), sender);
        }

        private void btnMenuSettings_Click(object sender, EventArgs e)
        {
            ChangeTab(new SettingsForm(), sender);
        }

        private void btnMenuManageMods_Click(object sender, EventArgs e)
        {
            ChangeTab(new ManageModsForm(), sender);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (Utils.IsAdministrator() || Utils.hasWriteAccess(Application.StartupPath))
            {
                _webClient.DownloadFileCompleted += WebClient_DownloadAUMMUpdateCompleted;
                Uri uri = new Uri(Path.Combine(UPDATE_BASE_URL, UPDATE_NAME));
                string location = Application.StartupPath;

                _webClient.Headers.Add("user-agent", Utils.userAgent);
                _webClient.DownloadFileAsync(uri, location + "\\" + UPDATE_NAME);
            }
            else
            {
                var result = MessageBox.Show("Update requires Admin rights. Restart with admin privilege?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    string aumm = Process.GetCurrentProcess().MainModule.FileName;
                    ProcessStartInfo info = new ProcessStartInfo(aumm);
                    info.UseShellExecute = true;
                    info.Verb = "runas";
                    try
                    {
                        Process.Start(info);

                        Environment.Exit(0);
                    }
                    catch (Exception)
                    {
                        Utils.Alert("Couldn' t restart AUMM", AlertForm.enmType.Error);
                    }
                }
            }
        }

        public void DisableTabs()
        {
            _canSwitchTab = false;
            btnMenuInstallMods.Enabled = false;
            btnMenuManageMods.Enabled = false;
            btnMenuSettings.Enabled = false;
        }

        public void EnableTabs()
        {
            _canSwitchTab = true;
            btnMenuInstallMods.Enabled = true;
            btnMenuManageMods.Enabled = true;
            btnMenuSettings.Enabled = true;
        }

        private void btn_UpdaterUpdate_Click(object sender, EventArgs e)
        {
            btnUpdaterUpdate.Enabled = false;

            if (Utils.IsAdministrator() || Utils.hasWriteAccess(Application.StartupPath))
            {
                _webClient.DownloadFileCompleted += WebClient_DownloadUpdaterUpdateCompleted;
                Uri uri = new Uri(Path.Combine(UPDATE_BASE_URL, UPDATER_UPDATE));
                string location = Application.StartupPath;

                _webClient.Headers.Add("user-agent", Utils.userAgent);
                _webClient.DownloadFileAsync(uri, location + "\\" + UPDATER_UPDATE);
            }
            else
            {
                var result = MessageBox.Show("Update requires Admin rights. Restart with admin privilege?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    string aumm = Process.GetCurrentProcess().MainModule.FileName;
                    ProcessStartInfo info = new ProcessStartInfo(aumm);
                    info.UseShellExecute = true;
                    info.Verb = "runas";
                    try
                    {
                        Process.Start(info);

                        Environment.Exit(0);
                    }
                    catch (Exception)
                    {
                        Utils.Alert("Couldn' t restart AUMM", AlertForm.enmType.Error);
                    }
                }
            }
        }

        private void WebClient_DownloadAUMMUpdateCompleted(object sender, AsyncCompletedEventArgs e)
        {
            _webClient.DownloadFileCompleted -= WebClient_DownloadAUMMUpdateCompleted;
            var result = MessageBox.Show("Update download complete. Would you like to install?", "Info", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (result == DialogResult.Yes)
            {
                if (File.Exists(UPDATER))
                {
                    try
                    {
                        Process.Start(UPDATER, UPDATE_NAME);
                        Environment.Exit(0);
                    }
                    catch (Exception)
                    {
                        Utils.Alert("Couldn' t start updater.", AlertForm.enmType.Error);
                    }
                }
                else
                {
                    Utils.Alert("Updater not found! Was it deleted?", AlertForm.enmType.Error);
                }
            }
        }

        private void WebClient_DownloadUpdaterUpdateCompleted(object sender, AsyncCompletedEventArgs e)
        {
            _webClient.DownloadFileCompleted -= WebClient_DownloadUpdaterUpdateCompleted;
            
            UpdateUpdater();
        }

        private void UpdateUpdater()
        {
            if(CheckSignature())
            {
                DoUpdate();
            }

            btnUpdaterUpdate.Enabled = true;
        }

        private bool CheckSignature()
        {
            X509Certificate2 cert = new X509Certificate2(Properties.Resources.aumm_public_key);

            SHA256 Sha256 = SHA256.Create();

            byte[] hash;
            if(!File.Exists(UPDATER_UPDATE))
            {
                Utils.Alert($"{UPDATER_UPDATE} not found! Please try again.", AlertForm.enmType.Error);
                return false;
            }

            using (FileStream stream = File.OpenRead(UPDATER_UPDATE))
            {
                hash = Sha256.ComputeHash(stream);
            }

            string remoteHash = (string)updateJson["updater_version"]["signature_hash"];

            if (Convert.ToBase64String(hash) != remoteHash)
            {
                Utils.Alert("Hash not correct! Retry update or open an issue.", AlertForm.enmType.Error);
                DeleteFile(UPDATER_UPDATE);

                return false;
            }

            bool signatureOk = false;
            string remoteSignature = (string)updateJson["updater_version"]["signature"];

            byte[] signature = Convert.FromBase64String(remoteSignature);

            using (RSA rsa = cert.GetRSAPublicKey())
            {
                signatureOk = rsa.VerifyHash(hash, signature, HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);
            }

            if(!signatureOk)
            {
                Utils.Alert("Signature invalid! Please open an issue.", AlertForm.enmType.Error);
                DeleteFile(UPDATER_UPDATE);

                return false;
            }

            return true;
        }

        private void DoUpdate()
        {
            if(RenameFile(UPDATER, UPDATER_UPDATE_BAK))
            {
                if(!RenameFile(UPDATER_UPDATE, UPDATER))
                {
                    if(RenameFile(UPDATER_UPDATE_BAK, UPDATER))
                    {
                        Utils.Alert($"Couldn' t perform update. Rename _bak to {UPDATER}", AlertForm.enmType.Error);
                    }
                }
                else
                {
                    DeleteFile(UPDATER_UPDATE_BAK);
                    btnUpdaterUpdate.Visible = false;
                    Settings.updaterVersion = (int)updateJson["updater_version"]["version"];
                    Settings.SaveConfig();
                    Utils.Alert("Updated Updater successfully.", AlertForm.enmType.Success);
                }
            }
            else
            {
                Utils.Alert($"Couldn' t create bakcup of updater!", AlertForm.enmType.Error);
            }
        }

        private static bool RenameFile(string oldName, string newName)
        {
            try
            {
                File.Move(oldName, newName);
                return true;
            }
            catch (Exception)
            {
                return false;
            }            
        }

        private void DeleteFile(string file)
        {
            try
            {
                File.Delete(file);
            }
            catch (Exception)
            {
                Utils.Alert("Couldn' t delete corrupted file. Please delete manually.", AlertForm.enmType.Error);
            }
        }
    }
}
