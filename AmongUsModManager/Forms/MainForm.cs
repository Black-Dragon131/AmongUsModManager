using AmongUsModManager.Forms;
using Newtonsoft.Json.Linq;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net;
using System.Runtime.InteropServices;
using System.Security.Principal;
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

        private const int majorVersion = 0;
        private const int minorVersion = 11;
        private const string UPDATE_BASE_URL = "https://aumm.black-dragon131.de/";

        #if DEBUG
            private const string UPDATE_JSON_NAME = "aumm_debug.json";
        #else
            private const string UPDATE_JSON_NAME = "aumm.json";
        #endif
        private const string UPDATE_NAME = "AmongUsModManager_new.exe";
        private const string UPDATER = "AUMMUpdater.exe";
        private Form _activeTab;
        private Button _activeButton;
        private WebClient _webClient;
        private bool _canSwitchTab = true;

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
            lblVersion.Text = $"AUMM v{majorVersion}.{minorVersion}";
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

            string json = _webClient.DownloadString(url);

            JObject aummUpdate = JObject.Parse(json);
            int remoteMajorVersion = (int)aummUpdate["version"]["major_version"];
            int remoteMinorVersion = (int)aummUpdate["version"]["minor_version"];

            if (remoteMajorVersion > majorVersion || remoteMinorVersion > minorVersion)
            {
                Utils.Alert("New AUMM version aviable.", AlertForm.enmType.Info);
                btnUpdate.Visible = true;
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
            bool isElevated;
            using (WindowsIdentity identity = WindowsIdentity.GetCurrent())
            {
                WindowsPrincipal principal = new WindowsPrincipal(identity);
                isElevated = principal.IsInRole(WindowsBuiltInRole.Administrator);
            }

            if (isElevated)
            {
                _webClient.DownloadFileCompleted += WebClient_DownloadFileCompleted;
                Uri uri = new Uri(Path.Combine(UPDATE_BASE_URL, UPDATE_NAME));
                string location = Application.StartupPath;

                _webClient.DownloadFileAsync(uri, location + "\\" + UPDATE_NAME);
            }
            else
            {
                MessageBox.Show("Update requires Admin rights. Restart with admin privilege","Warning",MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Utils.Alert("Restart with admin privilege.", AlertForm.enmType.Warning);
            }
        }

        private void WebClient_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            var result = MessageBox.Show("Update download complete. Would you like to install?", "Info", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (result == DialogResult.Yes)
            {
                Process.Start(UPDATER, UPDATE_NAME);
                Environment.Exit(0);
            }
        }

        public void DisableTabs()
        {
            _canSwitchTab = false;
        }

        public void EnableTabs()
        {
            _canSwitchTab = true;
        }
    }
}
