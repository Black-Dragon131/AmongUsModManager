using FontAwesome.Sharp;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace AmongUsModManager.Forms
{
    public partial class InstallModsForm : Form
    {
        const string BASE_URL = "https://aumm.black-dragon131.de/";
    #if DEBUG
        const string MODS_XML = "mods_debug.xml";
    #else
        const string MODS_XML = "mods.xml";
    #endif
        const string APP_ID = "steam_appid.txt";
        const string BEPINEX = "BepInEx.zip";
        private bool _shouldHideProgress = false;
        private bool _updateMod = false;
        private WebClient _webClient;
        private string _currentModPath = "";
        private InstalledMod _currentInstallingMod;
        private MainForm _mainform;

        public InstallModsForm(MainForm mainForm)
        {
            InitializeComponent();
            _mainform = mainForm;
            Init();
        }

        private void Init()
        {
            _webClient = new WebClient();
            _webClient.DownloadProgressChanged += WebClient_DownloadProgressChanged;


            DownloadModsXML();
        }

        private void WebClient_DownloadModsXmlCompleted(object sender, AsyncCompletedEventArgs e)
        {
            pgrbDownload.Visible = false;
            lblDownloadStatus.Visible = false;

            _webClient.DownloadFileCompleted -= WebClient_DownloadModsXmlCompleted;
            PopulateList();
        }

        private void WebClient_DownloadModCompleted(object sender, AsyncCompletedEventArgs e)
        {
            pgrbDownload.Visible = false;
            lblDownloadStatus.Visible = false;

            _webClient.DownloadFileCompleted -= WebClient_DownloadModCompleted;
            ExtractMod(_currentModPath);
        }

        private void WebClient_DownloadBepInExCompleted(object sender, AsyncCompletedEventArgs e)
        {
            pgrbDownload.Visible = false;
            lblDownloadStatus.Visible = false;

            _webClient.DownloadFileCompleted -= WebClient_DownloadBepInExCompleted;
            DownloadMod();
        }

        private void WebClient_DownloadAppIdCompleted(object sender, AsyncCompletedEventArgs e)
        {
            pgrbDownload.Visible = false;
            lblDownloadStatus.Visible = false;

            _webClient.DownloadFileCompleted -= WebClient_DownloadAppIdCompleted;
        }

        private void WebClient_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            //Update progress bar & label
            Invoke(new MethodInvoker(delegate ()
            {
                pgrbDownload.Minimum = 0;
                double receive = double.Parse(e.BytesReceived.ToString());
                double total = double.Parse(e.TotalBytesToReceive.ToString());
                double percentage = receive / total * 100;
                lblDownloadStatus.Text = $"Downloaded {string.Format("{0:0.##}", percentage)}%";
                pgrbDownload.Value = int.Parse(Math.Truncate(percentage).ToString());
            }));
        }

        private void DoDownload(string url, string location)
        {
            if (!string.IsNullOrEmpty(url))
            {
                if (!_shouldHideProgress)
                {
                    pgrbDownload.Visible = true;
                    lblDownloadStatus.Text = "";
                    lblDownloadStatus.Visible = true;
                }
                Uri uri = new Uri(url);
                string fileName = Path.GetFileName(uri.AbsolutePath);

                _webClient.Headers.Add("user-agent", "Among Us Mod Manager");
                _webClient.DownloadFileAsync(uri, location + "\\" + fileName);
            }
        }

        private void DownloadModsXML()
        {
            _shouldHideProgress = true;
            string url = Path.Combine(BASE_URL, MODS_XML);

            _webClient.DownloadFileCompleted += WebClient_DownloadModsXmlCompleted;
            DoDownload(url, Settings.configDir);
        }

        private void PopulateList()
        {
            string xml = Path.Combine(Settings.configDir, MODS_XML);

            // Deserialize to List
            var serializer = new XmlSerializer(typeof(Mods));

            var dataSource = new List<Mod>();
            using (var file = File.OpenText(xml))
            {
                Mods data = (Mods)serializer.Deserialize(file);
                foreach (var item in data.Mod)
                {
                    dataSource.Add(item);
                    ModUpdater.availableMods.Add(item);
                }
            }

            //Setup data binding
            cbAvailableMods.DisplayMember = "Name";
            cbAvailableMods.ValueMember = "Id";
            cbAvailableMods.DataSource = dataSource;
        }

        private int GetCurrentId()
        {
            return (int)cbAvailableMods.SelectedValue;
        }

        private void cbAvailableMods_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = GetCurrentId();

            string text = ModUpdater.availableMods[id].Description.Replace("§", Environment.NewLine);
            lblAuthorName.Text = ModUpdater.availableMods[id].Author;
            txtModDescription.Text = text;
            if (!String.IsNullOrEmpty(ModUpdater.availableMods[id].Preview_url))
            {
                pbModPreview.Load(ModUpdater.availableMods[id].Preview_url);
            }
            else
            {
                pbModPreview.Image = AmongUsModManager.Properties.Resources.nopreview;
            }

            if (ModUpdater.availableMods[id].Github && Settings.checkModUpdates)
            {
                if(ModUpdater.CheckForModUpdates(ModUpdater.availableMods[id].Id))
                {
                    _updateMod = true;

                    btnInstallMod.BackColor = Utils.btnHighlightColor;
                    btnInstallMod.Text = "Update";
                    btnInstallMod.IconChar = IconChar.SyncAlt;
                }
                else
                {
                    ResetInstallButton();
                }
            }
            else
            {
                ResetInstallButton();
            }
        }

        private void InstallMod()
        {
            if (string.IsNullOrEmpty(Settings.amongUsPath))
            {
                Utils.Alert("Can' t install mods as no Among Us path is set!", AlertForm.enmType.Error);
                return;
            }

            _mainform.DisableTabs();
            btnInstallMod.Enabled = false;
            cbAvailableMods.Enabled = false;

            string parent = Directory.GetParent(Settings.amongUsPath).FullName;

            int id = GetCurrentId();
            string dest = Settings.folderName + "_" + ModUpdater.availableMods[id].Name.Replace(" ", "");
            _currentModPath = Path.Combine(parent, dest);

            bool copyOk = CopyFolder(Settings.amongUsPath, _currentModPath);

            _currentInstallingMod = new InstalledMod();
            _currentInstallingMod.Name = ModUpdater.availableMods[id].Name;
            _currentInstallingMod.Preview_url = ModUpdater.availableMods[id].Preview_url;
            _currentInstallingMod.Location = _currentModPath;
            _currentInstallingMod.Id = id;
            _currentInstallingMod.Description = ModUpdater.availableMods[id].Description;
            _currentInstallingMod.DownloadBepInEx = ModUpdater.availableMods[id].DownloadBepInEx;
            _currentInstallingMod.NeedsAppid = ModUpdater.availableMods[id].NeedsAppid;

            if (copyOk)
            {
                _shouldHideProgress = false;
                DownloadBepInEx();
            }
        }

        private void ResetInstallButton()
        {
            _updateMod = false;

            btnInstallMod.BackColor = Utils.highlightColor;
            btnInstallMod.Text = "Install";
            btnInstallMod.IconChar = IconChar.Download;
        }

        private void DownloadMod()
        {
            if (ModUpdater.availableMods[GetCurrentId()].Github)
            {
                string url = $"https://api.github.com/repos/{ModUpdater.availableMods[GetCurrentId()].Download_url}/releases/latest";

                _webClient.Headers.Add("user-agent", "Among Us Mod Manager");
                var json = _webClient.DownloadString(url);
                JObject modInfo = JObject.Parse(json);

                JArray items = (JArray)modInfo["assets"];
                int length = items.Count;
                string downloadUrl = "";

                for (int i = 0; i < length; i++)
                {
                    DateTime creationDate = (DateTime)modInfo["assets"][i]["created_at"];
                    downloadUrl = (string)modInfo["assets"][i]["browser_download_url"];
                    _currentInstallingMod.CreationDate = creationDate.ToString("s");

                    if (Path.GetExtension(downloadUrl) == ".zip")
                        break;
                }

                if (Path.GetExtension(downloadUrl) != ".zip")
                {
                    Utils.Alert("Download file not valid.", AlertForm.enmType.Error);
                    return;
                }

                _webClient.DownloadFileCompleted += WebClient_DownloadModCompleted;

                DoDownload(downloadUrl, _currentModPath);
            }
            else
            {
                _currentInstallingMod.CreationDate = DateTime.Now.ToString("s");
                _webClient.DownloadFileCompleted += WebClient_DownloadModCompleted;
                DoDownload(ModUpdater.availableMods[GetCurrentId()].Download_url, _currentModPath);
            }
        }

        private void ExtractMod(string targetPath)
        {
            Directory.GetFiles(targetPath, "*.zip").ToList()
            .ForEach(zipFilePath => {
                ZipFile.ExtractToDirectory(zipFilePath, targetPath);
            });

            CopyAppId();
            AddModToInstalledMods();
        }

        private void CopyAppId()
        {
            if (_currentInstallingMod.NeedsAppid)
            {
                string downloadUrl = Path.Combine(BASE_URL, APP_ID);
                _webClient.DownloadFileCompleted += WebClient_DownloadAppIdCompleted;
                _shouldHideProgress = false;
                DoDownload(downloadUrl, _currentModPath);
            }
        }

        private void DownloadBepInEx()
        {
            if (_currentInstallingMod.DownloadBepInEx)
            {
                _webClient.DownloadFileCompleted += WebClient_DownloadBepInExCompleted;
            
                string downloadUrl = Path.Combine(BASE_URL, BEPINEX);
                DoDownload(downloadUrl, _currentModPath);
            }
            else
            {
                DownloadMod();
            }
        }
        private void AddModToInstalledMods()
        {
            int index = Settings.installedMods.FindIndex(f => f.Id == _currentInstallingMod.Id);
            if (index >= 0)
                Settings.installedMods.RemoveAt(index);

            Settings.installedMods.Add(_currentInstallingMod);
            Settings.SaveConfig();

            if(_updateMod)
                Utils.Alert($"{_currentInstallingMod.Name} updated.", AlertForm.enmType.Success);
            else
                Utils.Alert($"{_currentInstallingMod.Name} installed.", AlertForm.enmType.Success);

            ResetInstallButton();
            btnInstallMod.Enabled = true;
            cbAvailableMods.Enabled = true;
            _mainform.EnableTabs();
        }

        private bool CopyFolder(string sourceFolder, string destFolder)
        {
            if(Settings.IsModInstalled(GetCurrentId()))
            {
                DialogResult result;

                if (_updateMod)
                    result = MessageBox.Show("Update mod?", "Info", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                else
                    result = MessageBox.Show("Mod already installed. Reinstall it?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.No)
                    return false;
                else
                    DeleteFolder(destFolder);
            }

            if (Directory.Exists(destFolder))
            {
                DeleteFolder(destFolder);
            }

            try
            {
                Directory.CreateDirectory(destFolder);
            }
            catch (Exception)
            {
                Utils.Alert("Couldn't create mod folder! Try again...", AlertForm.enmType.Error);
            }            

            string[] files = Directory.GetFiles(sourceFolder);
            foreach (string file in files)
            {
                string name = Path.GetFileName(file);
                string dest = Path.Combine(destFolder, name);
                try
                {
                    File.Copy(file, dest);
                }
                catch (Exception)
                {
                    Utils.Alert("Failed to copy folder.", AlertForm.enmType.Error);
                    Utils.Alert("Mod not installed.", AlertForm.enmType.Error);
                    return false;
                }                
            }
            string[] folders = Directory.GetDirectories(sourceFolder);
            foreach (string folder in folders)
            {
                string name = Path.GetFileName(folder);
                string dest = Path.Combine(destFolder, name);
                CopyFolder(folder, dest);
            }

            return true;
        }

        private void DeleteFolder(string folder)
        {
            Directory.Delete(folder, true);
        }

        private void btnInstallMod_Click(object sender, EventArgs e)
        {
            InstallMod();
        }
    }
}
