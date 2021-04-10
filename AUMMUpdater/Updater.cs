using Newtonsoft.Json.Linq;
using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

namespace AUMMUpdater
{
    class Updater
    {
        private const string UPDATE_JSON_URL = "https://aumm.black-dragon131.de/";
        private const string UPDATE_JSON_NAME = "aumm.json";
        private const int version = 1;
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

            if (CheckSignature(updateFile))
            {
                Update();
            }
        }

        private static void StartAUMM()
        {
            Console.WriteLine("Starting new version of AUMM...");
            Process.Start(AUMM_NAME);
            Environment.Exit(0);
        }

        private static bool CheckSignature(string file)
        {
            if (!File.Exists(file))
            {
                Console.WriteLine($"File {file} does not exist!");
                return false;
            }

            WebClient webClient = new WebClient();
            webClient.Headers.Add("user-agent", $"AUMM Updater v{version}");
            string url = UPDATE_JSON_URL + UPDATE_JSON_NAME;

            string json = webClient.DownloadString(url);

            JObject aummUpdate = JObject.Parse(json);

            X509Certificate2 cert = new X509Certificate2(Properties.Resources.aumm_public_key);

            SHA256 Sha256 = SHA256.Create();

            byte[] hash;
            using (FileStream stream = File.OpenRead(file))
            {
                hash = Sha256.ComputeHash(stream);
            }

            string remoteHash = (string)aummUpdate["version"]["signature_hash"];

            if (Convert.ToBase64String(hash) != remoteHash)
            {
                Console.WriteLine("Hash not correct! Retry update or open an issue.");
                DeleteFile(file);

                return false;
            }

            bool signatureOk = false;
            string remoteSignature = (string)aummUpdate["version"]["signature"];

            byte[] signature = Convert.FromBase64String(remoteSignature);

            using (RSA rsa = cert.GetRSAPublicKey())
            {
                signatureOk = rsa.VerifyHash(hash, signature, HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);
            }

            if (!signatureOk)
            {
                Console.WriteLine("Signature invalid! Please open an issue.");
                DeleteFile(file);

                return false;
            }

            return true;
        }

        private static void Update()
        {
            Console.WriteLine("Starting update...");

            if (RenameFile(AUMM_NAME, AUMM_NAME_BAK))
            {
                if (!RenameFile(updateFile, AUMM_NAME))
                {
                    if (RenameFile(AUMM_NAME_BAK, AUMM_NAME))
                    {
                        Console.WriteLine("Update unsuccessful! Update reverted...");
                    }
                }
                else
                {
                    DeleteFile(AUMM_NAME_BAK);
                    Console.WriteLine("Update successful.");
                }
            }

            Console.WriteLine("Finished update.");
            StartAUMM();
        }

        private static bool RenameFile(string oldName, string newName)
        {
            try
            {
                File.Move(oldName, newName);
                return true;
            }
            catch (Exception)
            {
                return false;
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
    }
}
