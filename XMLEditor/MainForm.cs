using AmongUsModManager;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace XMLEditor
{
    public partial class MainForm : Form
    {
        private const string _XML = "F:\\_Web\\AmongUsModManager\\mods.xml";

        public MainForm()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            // Deserialize to List
            var serializer = new XmlSerializer(typeof(Mods));

            using (var file = File.OpenText(_XML))
            {
                Mods data = (Mods)serializer.Deserialize(file);
                foreach (var item in data.Mod)
                {
                    lvMods.Items.Add(item.Name);
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }

        private void lvMods_SelectedIndexChanged(object sender, EventArgs e)
        {
            //tbModName.Text = lvMods.SelectedItems[0].Text;
        }
    }
}
