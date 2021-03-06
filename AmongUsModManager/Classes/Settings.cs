﻿using AmongUsModManager.Forms;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;

namespace AmongUsModManager
{
    static class Settings
    {
        public static string folderName = "Among Us";
        public static string exeName = "Among Us.exe";
        public static string amongUsPath;
        public static bool checkModUpdates = true;
        public static bool checkAummUpdates = true;
        public static int updaterVersion;
        public static string configDir;
        public static List<InstalledMod> installedMods;

        private static string _configPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        private static string _configDirName = "AmongUsModManager";
        private static string _configFileName = "settings.xml";
        private static string _configFile;

        static Settings()
        {
            configDir = Path.Combine(_configPath, _configDirName);
            _configFile = Path.Combine(configDir, _configFileName);
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
            if(!File.Exists(_configFile))
            {
                return false;
            }

            var serializer = new XmlSerializer(typeof(Config));
            using (StreamReader file = File.OpenText(_configFile))
            {
                try
                {
                    Config data = (Config)serializer.Deserialize(file);
                    amongUsPath = data.AmongUsPath;
                    checkModUpdates = data.CheckModUpdates;
                    checkAummUpdates = data.CheckAummUpdates;
                    updaterVersion = data.UpdaterVersion;

                    foreach (var item in data.InstalledMods.InstalledMod)
                    {
                        installedMods.Add(item);
                    }
                }
                catch (Exception)
                {
                    try
                    {
                        file.Close();
                        File.Delete(_configFile);
                        SearchInstallFolder();
                        SaveConfig();
                        Utils.Alert("settings.xml was corrupt. I recreated it!", AlertForm.enmType.Warning);
                    }
                    catch (Exception)
                    {
                        Utils.Alert("settings.xml is corrupt, but I couldn' t fix it myself!", AlertForm.enmType.Error);
                    }
                }
            }

            return true;
        }

        public static void SaveConfig()
        {
            var config = new Config();

            // Check if config dir exists and create one if not
            if (!Directory.Exists(configDir))
            {
                try
                {
                    Directory.CreateDirectory(configDir);
                }
                catch (Exception)
                {
                    Utils.Alert("Couldn 't create config folder!", AlertForm.enmType.Error);
                }
                
            }

            XmlSerializer xsSubmit = new XmlSerializer(typeof(Config));
            
            config.AmongUsPath = amongUsPath;
            config.CheckModUpdates = checkModUpdates;
            config.CheckAummUpdates = checkAummUpdates;
            config.UpdaterVersion = updaterVersion;

            InstalledMods mods = new InstalledMods();
            mods.InstalledMod = installedMods;
            config.InstalledMods = mods;

            XmlWriterSettings settings = new XmlWriterSettings { Indent = true };
            using (var stringWriter = new StringWriter())
            {
                using (XmlWriter writer = XmlWriter.Create(stringWriter, settings))
                {
                    xsSubmit.Serialize(writer, config);
                    string xml = stringWriter.ToString();
                    File.WriteAllText(_configFile, xml);
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
            if (String.IsNullOrEmpty(installPath))
            {
                Utils.Alert("Among Us path not set!", AlertForm.enmType.Warning);
                return;
            }

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

        public static bool IsModInstalled(int id)
        {
            foreach (InstalledMod mod in installedMods)
            {
                if (mod.Id == id)
                {
                    return true;
                }
            }

            return false;
        }

        public static string GetInstalledModDate(int id)
        {
            foreach (InstalledMod mod in installedMods)
            {
                if (mod.Id == id)
                {
                    return mod.CreationDate;
                }
            }

            return null;
        }
    }
}
