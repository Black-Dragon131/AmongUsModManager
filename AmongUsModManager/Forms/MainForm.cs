using AmongUsModManager.Forms;
using System;
using System.Drawing;
using System.Runtime.InteropServices;
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

        private const string aummVersion = "0.8";
        private Form _activeTab;
        private Button _activeButton;
        private readonly Color _highlightColor = Color.FromArgb(79, 93, 117);
        private readonly Color _normalColor = Color.FromArgb(45, 49, 66);

        public MainForm()
        {
            InitializeComponent();
            Init();

            // Round corners
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));

            if (_activeTab == null)
            {
                ChangeTab(new InstallModsForm(), btnMenuInstallMods);
            }
        }

        private void Init()
        {
            lblVersion.Text = $"AUMM v{aummVersion}";
            if (Settings.IsFirstRun())
            {
                MessageBox.Show("It seems like this is the first start.\r\nTrying to find Among Us automatically.\r\nIf I can't find it you have to select the path manually!", "Info");
                Settings.SearchInstallFolder();
                Settings.SaveConfig();
            }
        }

        private void ChangeTab(Form newTab, object btnSender)
        {
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
                _activeButton.BackColor = _normalColor;
            }

            _activeButton = button;
            button.BackColor = _highlightColor;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMenuInstallMods_Click(object sender, EventArgs e)
        {
            ChangeTab(new InstallModsForm(), sender);
        }

        private void btnMenuSettings_Click(object sender, EventArgs e)
        {
            ChangeTab(new SettingsForm(), sender);
        }

        private void btnMenuManageMods_Click(object sender, EventArgs e)
        {
            ChangeTab(new ManageModsForm(), sender);
        }
    }
}
