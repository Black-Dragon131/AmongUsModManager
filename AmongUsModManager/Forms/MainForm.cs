using System;
using System.Diagnostics;
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

        private Form activeTab;
        private Button activeButton;
        private Color highlightColor = Color.FromArgb(79, 93, 117);
        private Color normalColor = Color.FromArgb(45, 49, 66);

        public MainForm()
        {
            InitializeComponent();
            Init();

            // Round corners
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));

            if (activeTab == null)
            {
                ChangeTab(new Forms.InstallModsForm(), btnMenuInstallMods);
            }
        }

        private void Init()
        {
            if(Settings.IsFirstRun())
            {
                MessageBox.Show("It seems like this is the first start.\r\nTrying to find Among Us automatically.\r\nIf I can't find it you have to select the path manually!","Info");
                Settings.SearchInstallFolder();
                Settings.SaveConfig();
            }
        }

        private void ChangeTab(Form newTab, object btnSender)
        {
            if(activeTab != null)
            {
                activeTab.Close();
            }

            activeTab = newTab;
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
            if(activeButton != null)
            {
                activeButton.BackColor = normalColor;
            }

            activeButton = button;
            button.BackColor = highlightColor;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMenuInstallMods_Click(object sender, EventArgs e)
        {
            ChangeTab(new Forms.InstallModsForm(), sender);
        }

        private void btnMenuSettings_Click(object sender, EventArgs e)
        {
            ChangeTab(new Forms.SettingsForm(), sender);
        }

        private void btnMenuManageMods_Click(object sender, EventArgs e)
        {
            ChangeTab(new Forms.ManageModsForm(), sender);
        }
    }
}
