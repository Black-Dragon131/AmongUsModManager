using Microsoft.Win32;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace AmongUsModManager.Forms
{
    public partial class ManageModsForm : Form
    {
        private int currentSelectedIndex = -1;

        public ManageModsForm()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            PopulateList();
        }

        private void PopulateList()
        {
            //Setup data binding
            cbAvailableMods.DisplayMember = "Name";
            cbAvailableMods.ValueMember = "Id";
            cbAvailableMods.DataSource = Settings.installedMods;
        }

        private int GetCurrentId()
        {
            if (cbAvailableMods.DataSource != null)
                return int.Parse((string)cbAvailableMods.SelectedValue);
            else
                return -1;
        }

        private void cbAvailableMods_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = GetCurrentId();
            currentSelectedIndex = Settings.installedMods.FindIndex(f => f.Id == id.ToString());

            if (currentSelectedIndex >= 0)
            {
                btnDeleteMod.Enabled = true;
                btnStartMod.Enabled = true;
                string text = Settings.installedMods[currentSelectedIndex].Description.Replace("§", Environment.NewLine);
                txtModDescription.Text = text;
                pbModPreview.Load(Settings.installedMods[currentSelectedIndex].Preview_url);
            }
        }

        private void DeleteFolder(string folder)
        {
            Directory.Delete(folder, true);
        }

        private void btnStartMod_Click(object sender, EventArgs e)
        {
            StartMod();
        }

        private void StartMod()
        {
            if (currentSelectedIndex >= 0)
            {
                string startPath = Path.Combine(Settings.installedMods[currentSelectedIndex].Location, Settings.exeName);
                Process.Start(startPath);
            }
        }

        private void btnDeleteMod_Click(object sender, EventArgs e)
        {
            DeleteMod();
        }

        private void DeleteMod()
        {
            if (currentSelectedIndex >= 0)
            {
                DeleteFolder(Settings.installedMods[currentSelectedIndex].Location);
                Settings.installedMods.RemoveAt(currentSelectedIndex);
                Settings.SaveConfig();
                cbAvailableMods.DataSource = null;
                txtModDescription.Text = "";
                pbModPreview.Image = null;
                btnDeleteMod.Enabled = false;
                btnStartMod.Enabled = false;
                PopulateList();
            }
        }
    }
}
