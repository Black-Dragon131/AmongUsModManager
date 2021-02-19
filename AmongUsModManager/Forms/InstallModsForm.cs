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
        const string MODS_XML_URL = "https://aumm.black-dragon131.de/";
        const string MODS_XML_NAME = "mods.xml";
        private bool _shouldHideProgress = false;
        private WebClient _webClient;
        private List<Mod> _availableMods;
        private string _currentModPath = "";
        private InstalledMod _currentInstallingMod;

        public InstallModsForm()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            _webClient = new WebClient();
            _webClient.DownloadProgressChanged += WebClient_DownloadProgressChanged;
            _webClient.DownloadFileCompleted += WebClient_DownloadFileCompleted;

            _availableMods = new List<Mod>();

            DownloadModsXML();
        }

        private void WebClient_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            pgrbDownload.Visible = false;
            lblDownloadStatus.Visible = false;

            if (_shouldHideProgress)
            {
                PopulateList();
                _shouldHideProgress = false;
            }
            else
            {
                ExtractMod(_currentModPath);
            }
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

                _webClient.DownloadFileAsync(uri, location + "\\" + fileName);
            }
        }

        private void DownloadModsXML()
        {
            _shouldHideProgress = true;
            string url = Path.Combine(MODS_XML_URL, MODS_XML_NAME);
            DoDownload(url, Settings.configDir);
        }

        private void PopulateList()
        {
            string xml = Path.Combine(Settings.configDir, MODS_XML_NAME);

            // Deserialize to List
            var serializer = new XmlSerializer(typeof(Mods));

            var dataSource = new List<Mod>();
            using (var file = File.OpenText(xml))
            {
                Mods data = (Mods)serializer.Deserialize(file);
                foreach (var item in data.Mod)
                {
                    dataSource.Add(item);
                    _availableMods.Add(item);
                }
            }

            //Setup data binding
            cbAvailableMods.DisplayMember = "Name";
            cbAvailableMods.ValueMember = "Id";
            cbAvailableMods.DataSource = dataSource;
        }

        private int GetCurrentId()
        {
            return int.Parse((string)cbAvailableMods.SelectedValue);
        }

        private void cbAvailableMods_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = GetCurrentId();

            string text = _availableMods[id].Description.Replace("§", Environment.NewLine);
            lblAuthorName.Text = _availableMods[id].Author;
            txtModDescription.Text = text;
            pbModPreview.Load(_availableMods[id].Preview_url);
        }

        private void InstallMod()
        {
            if (string.IsNullOrEmpty(Settings.amongUsPath))
            {
                Utils.Alert("Can' t install mods as no Among Us path is set!", AlertForm.enmType.Error);
                return;
            }

            string parent = Directory.GetParent(Settings.amongUsPath).FullName;

            int id = GetCurrentId();
            string dest = Settings.folderName + "_" + _availableMods[id].Name.Replace(" ", "");
            _currentModPath = Path.Combine(parent, dest);

            bool copyOk = CopyFolder(Settings.amongUsPath, _currentModPath);

            _currentInstallingMod = new InstalledMod();
            _currentInstallingMod.Name = _availableMods[id].Name;
            _currentInstallingMod.Preview_url = _availableMods[id].Preview_url;
            _currentInstallingMod.Location = _currentModPath;
            _currentInstallingMod.Id = id.ToString();
            _currentInstallingMod.Description = _availableMods[id].Description;

            if (copyOk)
                DownloadMod(_currentModPath);
        }

        private void DownloadMod(string location)
        {
            if (_availableMods[GetCurrentId()].Github)
            {
                string url = _availableMods[GetCurrentId()].Download_url;

                _webClient.Headers.Add("user-agent", "Among Us Mod Manager");
                var json = _webClient.DownloadString(url);
                JObject modInfo = JObject.Parse(json);
                DateTime creationDate = (DateTime)modInfo["assets"][0]["created_at"];
                string downloadUrl = (string)modInfo["assets"][0]["browser_download_url"];
                _currentInstallingMod.CreationDate = creationDate.ToString("s");

                DoDownload(downloadUrl, location);
            }
        }

        private void ExtractMod(string targetPath)
        {
            Directory.GetFiles(targetPath, "*.zip").ToList()
            .ForEach(zipFilePath => {
                ZipFile.ExtractToDirectory(zipFilePath, targetPath);
            });

            AddModToInstalledMods();
        }

        private void AddModToInstalledMods()
        {
            int index = Settings.installedMods.FindIndex(f => f.Id == _currentInstallingMod.Id);
            if (index >= 0)
                Settings.installedMods.RemoveAt(index);

            Settings.installedMods.Add(_currentInstallingMod);
            Settings.SaveConfig();

            Utils.Alert($"{_currentInstallingMod.Name} installed.", AlertForm.enmType.Success);
        }

        private bool CopyFolder(string sourceFolder, string destFolder)
        {
            if (Directory.Exists(destFolder))
            {
                var result = MessageBox.Show("Mod already installed. Reinstall it?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.No)
                    return false;
                else
                    DeleteFolder(destFolder);
            }

            Directory.CreateDirectory(destFolder);

            string[] files = Directory.GetFiles(sourceFolder);
            foreach (string file in files)
            {
                string name = Path.GetFileName(file);
                string dest = Path.Combine(destFolder, name);
                File.Copy(file, dest);
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
