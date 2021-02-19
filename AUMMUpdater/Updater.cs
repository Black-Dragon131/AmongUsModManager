using Newtonsoft.Json.Linq;
using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Security.Cryptography;

namespace AUMMUpdater
{
    class Updater
    {
        private const string UPDATE_XML_URL = "https://aumm.black-dragon131.de/";
        private const string UPDATE_XML_NAME = "aumm.json";
        private const string AUMM_NAME = "AmongUsModManager.exe";
        private const string AUMM_NAME_BAK = "AmongUsModManager_bak.exe";
        private static string updateFile;

        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("No update file provided.");
                Environment.Exit(1);
            }

            updateFile = args[0];

            Console.WriteLine($"Using file {updateFile} for update...");

            if(CheckHash(updateFile))
            {
                Update();
            }
        }

        private static bool CheckHash(string file)
        {
            if (!File.Exists(file))
            {
                Console.WriteLine($"File {file} does not exist!");
                return false;
            }

            WebClient webClient = new WebClient();
            string url = UPDATE_XML_URL + UPDATE_XML_NAME;

            string json = webClient.DownloadString(url);

            JObject aummUpdate = JObject.Parse(json);
            string remoteHash = (string)aummUpdate["version"]["hash"];
            string localHash = GetSHA256(file);

            if(remoteHash != localHash)
            {
                Console.WriteLine("Downloaded file is corrupt!");
                return false;
            }
            else
            {
                Console.WriteLine("Checksum OK");
                return true;
            }
        }

        private static void StartAUMM()
        {
            Console.WriteLine("Starting new version of AUMM...");
            Process.Start(AUMM_NAME);
            Environment.Exit(0);
        }

        private static void Update()
        {
            Console.WriteLine("Starting update...");
            RenameFile(AUMM_NAME, AUMM_NAME_BAK);
            RenameFile(updateFile, AUMM_NAME);
            if(CheckHash(AUMM_NAME))
            {
                DeleteFile(AUMM_NAME_BAK);
            }
            else
            {
                Console.WriteLine("Update unsuccessful! Reverting it...");
                RenameFile(AUMM_NAME_BAK, AUMM_NAME);
            }

            Console.WriteLine("Finished update.");
            StartAUMM();
        }

        private static void RenameFile(string oldName, string newName)
        {
            if (File.Exists(oldName))
            {
                File.Move(oldName, newName);
            }
            else
            {
                Console.WriteLine($"File {oldName} does not exist!");
            }
        }

        private static void DeleteFile(string file)
        {
            if (File.Exists(file))
            {
                File.Delete(file);
            }
            else
            {
                Console.WriteLine($"File {file} does not exist!");
            }
        }

        private static string GetSHA256(string file)
        {
            string sha256 = "";

            using (SHA256 mySHA256 = SHA256.Create())
            {
                FileInfo fileInfo = new FileInfo(file);

                try
                {
                    FileStream fileStream = fileInfo.Open(FileMode.Open);
                    fileStream.Position = 0;
                    byte[] hashValue = mySHA256.ComputeHash(fileStream);
                    fileStream.Close();

                    for (int i = 0; i < hashValue.Length; i++)
                    {
                        sha256 += $"{hashValue[i]:X2}";
                    }
                }
                catch (IOException e)
                {
                    Console.WriteLine($"I/O Exception: {e.Message}");
                }
                catch (UnauthorizedAccessException e)
                {
                    Console.WriteLine($"Access Exception: {e.Message}");
                }
            }

            return sha256;
        }
    }
}
