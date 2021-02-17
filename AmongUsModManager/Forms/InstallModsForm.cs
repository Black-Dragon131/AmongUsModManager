using Microsoft.Win32;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace AmongUsModManager.Forms
{
    public partial class InstallModsForm : Form
    {
        const string MODS_XML_URL = "https://aumm.black-dragon131.de/";
        const string MODS_XML_NAME = "mods.xml";
        private bool shouldHideProgress = false;
        private WebClient webClient;
        private List<Mod> availableMods;
        private string currentModPath = "";
        private InstalledMod currentInstallingMod;

        public InstallModsForm()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            webClient = new WebClient();
            webClient.DownloadProgressChanged += WebClient_DownloadProgressChanged;
            webClient.DownloadFileCompleted += WebClient_DownloadFileCompleted;

            availableMods = new List<Mod>();

            DownloadModsXML();
        }

        private void WebClient_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            //MessageBox.Show("Download complete!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            pgrbDownload.Visible = false;

            if (shouldHideProgress)
            {
                PopulateList();
                shouldHideProgress = false;
            }
            else
            {
                lblDownloadStatus.Text = "Download complete.";
                ExtractMod(currentModPath);
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
                if (!shouldHideProgress)
                {
                    pgrbDownload.Visible = true;
                    lblDownloadStatus.Text = "";
                    lblDownloadStatus.Visible = true;
                }
                Uri uri = new Uri(url);
                string fileName = Path.GetFileName(uri.AbsolutePath);

                webClient.DownloadFileAsync(uri, location + "\\" + fileName);
            }
        }

        private void DownloadModsXML()
        {
            shouldHideProgress = true;
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
                    availableMods.Add(item);
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

            string text = availableMods[id].Description.Replace("§", Environment.NewLine);
            lblAuthorName.Text = availableMods[id].Author;
            txtModDescription.Text = text;
            pbModPreview.Load(availableMods[id].Preview_url);
        }

        private void InstallMod()
        {
            if(string.IsNullOrEmpty(Settings.amongUsPath))
            {
                MessageBox.Show("Can' t install mods as no Among Us path is set!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string parent = Directory.GetParent(Settings.amongUsPath).FullName;

            int id = GetCurrentId();
            string dest = Settings.folderName + "_" + availableMods[id].Name.Replace(" ","");
            currentModPath = Path.Combine(parent, dest);

            bool copyOk = CopyFolder(Settings.amongUsPath, currentModPath);

            currentInstallingMod = new InstalledMod();
            currentInstallingMod.Name = availableMods[id].Name;
            currentInstallingMod.Preview_url = availableMods[id].Preview_url;
            currentInstallingMod.Location = currentModPath;
            currentInstallingMod.Id = id.ToString();
            currentInstallingMod.Description = availableMods[id].Description;

            if (copyOk)
                DownloadMod(currentModPath);
        }

        private void DownloadMod(string location)
        {
            if (availableMods[GetCurrentId()].Github)
            {
                string url = availableMods[GetCurrentId()].Download_url;
                
                webClient.Headers.Add("user-agent", "Among Us Mod Manager");
                var json = webClient.DownloadString(url);
                JObject modInfo = JObject.Parse(json);
                DateTime creationDate = (DateTime)modInfo["assets"][0]["created_at"];
                string downloadUrl = (string)modInfo["assets"][0]["browser_download_url"];
                //Debug.WriteLine(creationDate.ToString("s"));
                //Debug.WriteLine(downloadUrl);
                currentInstallingMod.CreationDate = creationDate.ToString("s");

                DoDownload(downloadUrl, location);
            }
        }

        private void ExtractMod(string targetPath)
        {
            lblDownloadStatus.Text = "Installing mod...";
            Directory.GetFiles(targetPath, "*.zip").ToList()
            .ForEach(zipFilePath => {
                ZipFile.ExtractToDirectory(zipFilePath, targetPath);
            });

            AddModToInstalledMods();
        }

        private void AddModToInstalledMods()
        {
            int index = Settings.installedMods.FindIndex(f => f.Id == currentInstallingMod.Id);
            if(index >= 0)
                Settings.installedMods.RemoveAt(index);

            Debug.WriteLine($"index: {index}; current:{currentInstallingMod.Id}");

            Settings.installedMods.Add(currentInstallingMod);
            Settings.SaveConfig();

            lblDownloadStatus.Text = "Mod installed.";
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
