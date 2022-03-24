using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataHoarder_DL
{
    public partial class SettingsUI : Form
    {
        public SettingsUI()
        {
            InitializeComponent();
        }

        private void SettingsUI_Load(object sender, EventArgs e)
        {
            txtRootDir.Text = Globals.Settings.RootDownloadPath;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Globals.Settings.RootDownloadPath = txtRootDir.Text;
            Globals.Settings.Save();
            this.Close();
        }
    }
}
