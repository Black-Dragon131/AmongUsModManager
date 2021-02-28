using AmongUsModManager.Forms;
using System.Diagnostics;
using System.Drawing;

namespace AmongUsModManager
{
    static class Utils
    {
        public static readonly Color highlightColor = Color.FromArgb(79, 93, 117);
        public static readonly Color normalColor = Color.FromArgb(45, 49, 66);
        public static readonly Color btnHighlightColor = Color.FromArgb(239, 131, 84);

        public static void Alert(string msg, AlertForm.enmType type)
        {
            AlertForm frm = new AlertForm();
            frm.showAlert(msg, type);
        }

        public static void DebugOutput(string output)
        {
            Debug.WriteLine(output);
        }
    }
}
