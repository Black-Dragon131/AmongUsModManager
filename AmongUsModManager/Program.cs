using System;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace AmongUsModManager
{
    static class Program
    {
        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        static void Main()
        {
            AppDomain currentDomain = AppDomain.CurrentDomain;
            currentDomain.UnhandledException += new UnhandledExceptionEventHandler(AllExceptionHandler);

            // Remove insecure protocols (SSL3, TLS 1.0, TLS 1.1)
            ServicePointManager.SecurityProtocol &= ~SecurityProtocolType.Ssl3;
            ServicePointManager.SecurityProtocol &= ~SecurityProtocolType.Tls;
            ServicePointManager.SecurityProtocol &= ~SecurityProtocolType.Tls11;
            // Add TLS 1.2
            ServicePointManager.SecurityProtocol |= SecurityProtocolType.Tls12;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }

        private static void AllExceptionHandler(object sender, UnhandledExceptionEventArgs args)
        {
            Exception e = (Exception)args.ExceptionObject;
            string exceptionFile = Path.Combine(Settings.configDir, "exceptions.log");

            if (!File.Exists(exceptionFile))
            {
                using (StreamWriter sw = File.CreateText(exceptionFile))
                {
                    sw.WriteLine("AllExceptionHandler caught : " + e.Message);
                    sw.WriteLine("Runtime terminating: {0}", args.IsTerminating);
                }
            }
            else
            {
                using (StreamWriter sw = File.AppendText(exceptionFile))
                {
                    sw.WriteLine("AllExceptionHandler caught : " + e.Message);
                    sw.WriteLine("Runtime terminating: {0}", args.IsTerminating);
                }
            }

            MessageBox.Show($"Unhandled exception occurred!. Please open an issue and add {exceptionFile} to it.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
