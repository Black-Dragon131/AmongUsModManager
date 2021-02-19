using AmongUsModManager.Forms;
using System.Diagnostics;

namespace AmongUsModManager
{
    static class Utils
    {
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
