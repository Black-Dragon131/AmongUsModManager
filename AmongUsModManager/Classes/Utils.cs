using AmongUsModManager.Forms;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Security.Principal;

namespace AmongUsModManager
{
    static class Utils
    {
        public const int majorVersion = 1;
        public const int minorVersion = 0;

        public static readonly Color highlightColor = Color.FromArgb(79, 93, 117);
        public static readonly Color normalColor = Color.FromArgb(45, 49, 66);
        public static readonly Color btnHighlightColor = Color.FromArgb(239, 131, 84);

        public static readonly string userAgent = $"Among Us Mod Manager v{majorVersion}.{minorVersion}";

        public static void Alert(string msg, AlertForm.enmType type)
        {
            AlertForm frm = new AlertForm();
            frm.showAlert(msg, type);
        }

        public static void DebugOutput(string output)
        {
            Debug.WriteLine(output);
        }

        public static bool hasWriteAccess(string folderPath)
        {
            try
            {
                using (FileStream fs = File.Create(
                    Path.Combine(
                        folderPath,
                        Path.GetRandomFileName()
                    ),
                    1,
                    FileOptions.DeleteOnClose)
                )
                { }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool IsAdministrator()
        {
            bool isAdmin;

            using (WindowsIdentity identity = WindowsIdentity.GetCurrent())
            {
                WindowsPrincipal principal = new WindowsPrincipal(identity);
                isAdmin = principal.IsInRole(WindowsBuiltInRole.Administrator);
            }

            return isAdmin;
        }
    }
}
