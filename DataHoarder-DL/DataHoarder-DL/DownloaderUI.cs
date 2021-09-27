using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NLog;

namespace DataHoarder_DL
{
    public partial class DownloaderUI : Form
    {

        Controllers.InstagramController ig;
        public DownloaderUI()
        {
            InitializeComponent();
        }

        private void txtDLDir_TextChanged(object sender, EventArgs e)
        {
            Globals.Settings.RootDownloadPath = txtDLDir.Text;
            Globals.Settings.Save();
        }

        private void btnIGScrape_Click(object sender, EventArgs e)
        {
            foreach(ListViewItem item in lsvIGFollowed.SelectedItems)
            {
                ig.FetchData(item.Text, Convert.ToInt32(nudIGMaxToScrape.Value));
            }
            IGPopulateFollowed();
            Globals.Settings.Save();
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
            txtDLDir.Text = Globals.Settings.RootDownloadPath;
            nudIGMaxToScrape.Value = Globals.Settings.InstagramSettings.DefaultMaxScrape;
            ig = new Controllers.InstagramController();
            IGPopulateFollowed();
        }

        private void IGPopulateFollowed()
        {
            if (Globals.Settings.InstagramSettings.FollowedUsers == null)
                return;
            lsvIGFollowed.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            lsvIGFollowed.Items.Clear();
            foreach(IGFollowedUser user in Globals.Settings.InstagramSettings.FollowedUsers)
            {
                ListViewItem item = new ListViewItem(user.AccountName);
                item.SubItems.Add(user.LastScraped.ToString());
                item.SubItems.Add(ig.GetItemCount(user.AccountName).ToString());
                item.SubItems.Add(user.LastValidated.ToString());
                lsvIGFollowed.Items.Add(item);
            }
        }

        private void ptnIGParseOnly_Click(object sender, EventArgs e)
        {
            if(lsvIGFollowed.SelectedItems.Count > 1)
            {
                MessageBox.Show("This mode only supports a single selection.");
                return;
            }
            ig.Parse(lsvIGFollowed.SelectedItems[0].Text);
            IGPopulateFollowed();
            Globals.Settings.Save();
        }

        private void btnIGValidate_Click(object sender, EventArgs e)
        {
            ig.Validate();
            IGPopulateFollowed();
            Globals.Settings.Save();
        }

        private void btnIGAddUser_Click(object sender, EventArgs e)
        {
            IGFollowedUser newUser = new IGFollowedUser(txtIGScrapeAcct.Text);
            if (Globals.Settings.InstagramSettings.FollowedUsers.Any(p => p.AccountName == newUser.AccountName))
                MessageBox.Show("User already exists and will not be added");
            else
                Globals.Settings.InstagramSettings.FollowedUsers.Add(newUser);
            IGPopulateFollowed();
            Globals.Settings.Save();
        }

        private void btnIGRemoveUser_Click(object sender, EventArgs e)
        {
            if (lsvIGFollowed.SelectedItems != null)
            {
                foreach (ListViewItem item in lsvIGFollowed.SelectedItems)
                {
                    DialogResult result = MessageBox.Show($"Are you sure you want to remove {item.Text} from the followed list?\r\nDownloaded files will not be deleted.", "Confirm", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        IGFollowedUser user = Globals.Settings.InstagramSettings.FollowedUsers.Find(x => x.AccountName == item.Text);
                        Globals.Settings.InstagramSettings.FollowedUsers.Remove(user);
                    }
                }
            }
            IGPopulateFollowed();
            Globals.Settings.Save();
        }

        private void nudIGMaxToScrape_ValueChanged(object sender, EventArgs e)
        {
            Globals.Settings.InstagramSettings.DefaultMaxScrape = Convert.ToInt32(nudIGMaxToScrape.Value);
            Globals.Settings.Save();
        }
    }
}
