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
    public partial class DownloaderUI : Form
    {
        public DownloaderUI()
        {
            InitializeComponent();
        }

        private void txtDLDir_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnIGScrape_Click(object sender, EventArgs e)
        {
            Controllers.InstagramController ig = new Controllers.InstagramController(txtIGUser.Text, txtIGPass.Text, txtDLDir.Text);
            ig.FetchData(txtIGScrapeAcct.Text, Convert.ToInt32(nudIGMaxToScrape.Value));
        }

        private void txtIGScrapeAcct_TextChanged(object sender, EventArgs e)
        {
            Globals.Settings.InstagramSettings.LastScrapedUser = txtIGScrapeAcct.Text;
            Globals.Settings.Save();
        }

        private void txtIGUser_TextChanged(object sender, EventArgs e)
        {
            Globals.Settings.InstagramSettings.IGUsername = txtIGUser.Text;
            Globals.Settings.Save();
        }

        private void txtIGPass_TextChanged(object sender, EventArgs e)
        {
            Globals.Settings.InstagramSettings.IGPass = txtIGPass.Text;
            Globals.Settings.Save();
        }

        private void DownloaderUI_Load(object sender, EventArgs e)
        {
            txtIGPass.Text = Globals.Settings.InstagramSettings.IGPass;
            txtIGUser.Text = Globals.Settings.InstagramSettings.IGUsername;
            txtIGScrapeAcct.Text = Globals.Settings.InstagramSettings.LastScrapedUser;
            txtDLDir.Text = Environment.CurrentDirectory + "\\Casts";
        }

        private void ptnIGParseOnly_Click(object sender, EventArgs e)
        {
            Controllers.InstagramController ig = new Controllers.InstagramController(txtIGUser.Text, txtIGPass.Text, txtDLDir.Text);
            ig.ParseOnly(txtIGScrapeAcct.Text);
        }
    }
}
