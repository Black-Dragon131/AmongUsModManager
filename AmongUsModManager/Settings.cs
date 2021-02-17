using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace AmongUsModManager
{ 
    static class Settings
    {
        public static string folderName = "Among Us";
        public static string exeName = "Among Us.exe";
        public static string amongUsPath;
        public static bool checkModUpdates;
        public static string configDir;
        public static List<InstalledMod> installedMods;

        private static string configPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        private static string configDirName = "AmongUsModManager";
        private static string configFileName = "settings.xml";
        private static string configFile;

        static Settings()
        {
            configDir = Path.Combine(configPath, configDirName);
            configFile = Path.Combine(configDir, configFileName);
            installedMods = new List<InstalledMod>();

            if (IsFirstRun())
            {
                amongUsPath = "";
                return;
            }
            
            LoadConfig();
        }

        public static bool IsFirstRun()
        {
            if (!Directory.Exists(configDir))
            {
                return true;
            }
            
            return false;            
        }

        public static bool LoadConfig()
        {
            if(!File.Exists(configFile))
            {
                return false;
            }

            var serializer = new XmlSerializer(typeof(Config));
            Debug.WriteLine(serializer);
            using (StreamReader file = File.OpenText(configFile))
            {
                Config data = (Config)serializer.Deserialize(file);
                amongUsPath = data.AmongUsPath;
                checkModUpdates = data.CheckModUpdates;

                foreach (var item in data.InstalledMods.InstalledMod)
                {
                    installedMods.Add(item);
                }
            }

            return true;
        }

        public static void SaveConfig()
        {
            // Check if config dir exists and create one if not
            if (!Directory.Exists(configDir))
            {
                Directory.CreateDirectory(configDir);
            }

            XmlSerializer xsSubmit = new XmlSerializer(typeof(Config));
            var config = new Config();
            var xml = "";

            config.AmongUsPath = amongUsPath;
            config.CheckModUpdates = checkModUpdates;

            InstalledMods mods = new InstalledMods();
            mods.InstalledMod = installedMods;
            config.InstalledMods = mods;

            XmlWriterSettings settings = new XmlWriterSettings { Indent = true };
            using (var stringWriter = new StringWriter())
            {
                using (XmlWriter writer = XmlWriter.Create(stringWriter, settings))
                {
                    xsSubmit.Serialize(writer, config);
                    xml = stringWriter.ToString();
                    File.WriteAllText(configFile, xml);
                }
            }
        }

        public static string GetFolderByDialog()
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    return fbd.SelectedPath;
                }
                else
                {
                    return null;
                }
            }
        }

        public static void CheckValidFolder(string installPath)
        {
            if (Path.GetFileName(installPath.TrimEnd(Path.DirectorySeparatorChar)) != folderName)
            {
                MessageBox.Show($"Selected folder doesn' t match '{folderName}'!\r\nPlease select the correct folder in settings.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            amongUsPath = installPath;
            Settings.SaveConfig();
        }

        public static void SearchInstallFolder()
        {
            string installPath = GetInstallDir();
            if (String.IsNullOrEmpty(installPath))
            {
                MessageBox.Show("Couldn' t find Among Us!\r\nPlease select base folder 'Among Us' in the following dialog.", "Warning",MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Debug.WriteLine("Install path not found. Select one...");
                // Show filebrowser dialog
                installPath = GetFolderByDialog();
            }

            CheckValidFolder(installPath);
        }

        private static string GetInstallDir()
        {
            object installPath = Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\Steam App 945360", "InstallLocation", null);
            if (installPath == null)
            {
                return "";
            }

            return installPath.ToString();
        }
    }
}
