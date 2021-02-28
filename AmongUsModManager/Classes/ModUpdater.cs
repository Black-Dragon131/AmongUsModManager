﻿using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AmongUsModManager
{
    static class ModUpdater
    {
        public static List<Mod> availableMods;

        static ModUpdater()
        {
            availableMods = new List<Mod>();
        }

        private static string GetCurrentVersionDate(int modId)
        {
            string url = $"https://api.github.com/repos/{availableMods[modId].Download_url}/releases/latest";

            WebClient _webClient = new WebClient();
            _webClient.Headers.Add("user-agent", "Among Us Mod Manager");
            var json = _webClient.DownloadString(url);
            JObject modInfo = JObject.Parse(json);

            JArray items = (JArray)modInfo["assets"];
            int length = items.Count;

            for (int i = 0; i < length; i++)
            {
                DateTime creationDate = (DateTime)modInfo["assets"][i]["created_at"];
                string downloadUrl = (string)modInfo["assets"][i]["browser_download_url"];

                if (Path.GetExtension(downloadUrl) == ".zip")
                    return creationDate.ToString("s");
            }

            return null;
        }

        public static bool CheckForModUpdates(int modId)
        {
            if (Settings.IsModInstalled(modId))
            {
                DateTime remoteVersionTime = DateTime.Parse(GetCurrentVersionDate(modId));
                if (remoteVersionTime == null)
                    return false;

                DateTime localVersionTime = DateTime.Parse(Settings.GetInstalledModDate(modId));
                if (localVersionTime == null)
                    return false;

                if (remoteVersionTime > localVersionTime)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
