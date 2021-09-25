using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace DataHoarder_DL
{
    public partial class Preloader : Form
    {
        public Preloader()
        {
            InitializeComponent();
        }

        private void Preloader_Load(object sender, EventArgs e)
        {
            //LoadThings
            CheckUpdates();
            LoadModules();
            LoadSettings();
            this.Close();

        }
        private void LoadSettings()
        {
            if (!File.Exists(Globals.SettingsPath))
            {
                File.WriteAllText(Globals.SettingsPath,FileOperations.Json.SerializeSettings(new Settings()));
            }
            Globals.Settings = FileOperations.Json.ParseSettings(File.ReadAllText(Globals.SettingsPath));
        }
        private void LoadModules()
        {
            //load module info from jsons

        }
        private void CheckUpdates()
        {
            //UpdateModules();
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }
    }
}
