﻿using System;
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
        Controllers.FormController formController;
        public DownloaderUI(Controllers.FormController formController)
        {
            this.formController = formController;
            InitializeComponent();
        }
        private void txtDLDir_TextChanged(object sender, EventArgs e)
        {
            Globals.Settings.RootDownloadPath = txtDLDir.Text;
            Globals.Settings.Save();
        }
        private void DownloaderUI_Load(object sender, EventArgs e)
        {
            txtDLDir.Text = Globals.Settings.RootDownloadPath;
            txtIGPass.Text = Globals.Settings.InstagramSettings.IGPass;
            txtIGUser.Text = Globals.Settings.InstagramSettings.IGUsername;
            txtIGScrapeAcct.Text = Globals.Settings.InstagramSettings.LastScrapedUser;
            nudIGMaxToScrape.Value = Globals.Settings.InstagramSettings.DefaultMaxScrape;
            txtTTScrapeAcct.Text = Globals.Settings.TikTokSettings.LastScrapedUser;
            nudTTMaxToScrape.Value = Globals.Settings.TikTokSettings.DefaultMaxScrape;
            formController.ig = new Controllers.InstagramController();
            formController.tt = new Controllers.TikTokController();
            formController.yt = new Controllers.YoutubeController();
            formController.queue = new Controllers.QueueController();
            IGPopulateFollowed();
            TTPopulateFollowed();
            LoadQueue();
        }
        private void LoadQueue()
        {
            RefreshQueue();
        }
        private void RefreshQueue()
        {
            if (Globals.Settings.DLQueue == null)
                return;
            lsvQueue.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            lsvQueue.Items.Clear();
            foreach (Models.Queue.InstagramItem instagramItem in Globals.Settings.DLQueue.IGQueueItems)
            {
                ListViewItem item = new ListViewItem(instagramItem.Order.ToString());
                item.SubItems.Add("IG");
                item.SubItems.Add(instagramItem.Username);
                lsvQueue.Items.Add(item);
            }
        }
        #region instagram
        private void btnIGScrape_Click(object sender, EventArgs e)
        {
            foreach(ListViewItem item in lsvIGFollowed.SelectedItems)
            {
                //ig.FetchData(item.Text, Convert.ToInt32(nudIGMaxToScrape.Value));
                Models.Queue.InstagramItem instagramItem = new Models.Queue.InstagramItem()
                {
                    Username = item.Text,
                    MaxToScrape = Convert.ToInt32(nudIGMaxToScrape.Value)
                };
                formController.queue.AddToQueue(instagramItem);
            }
            RefreshQueue();
            //IGPopulateFollowed();
            //Globals.Settings.Save();
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
                item.SubItems.Add(formController.ig.GetItemMetadataCount(user.AccountName).ToString());
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
            formController.ig.Parse(lsvIGFollowed.SelectedItems[0].Text);
            IGPopulateFollowed();
            Globals.Settings.Save();
        }
        private void btnIGValidate_Click(object sender, EventArgs e)
        {
            formController.ig.Validate();
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
        #endregion
        #region tiktok
        private void btnTTAddUser_Click(object sender, EventArgs e)
        {
            TTFollowedUser newUser = new TTFollowedUser(txtTTScrapeAcct.Text);
            if (Globals.Settings.TikTokSettings.FollowedUsers.Any(p => p.AccountName == newUser.AccountName))
                MessageBox.Show("User already exists and will not be added");
            else
                Globals.Settings.TikTokSettings.FollowedUsers.Add(newUser);
            TTPopulateFollowed();
            Globals.Settings.Save();
        }

        private void btnTTRemoveUser_Click(object sender, EventArgs e)
        {
            if (lsvTTFollowed.SelectedItems != null)
            {
                foreach (ListViewItem item in lsvTTFollowed.SelectedItems)
                {
                    DialogResult result = MessageBox.Show($"Are you sure you want to remove {item.Text} from the followed list?\r\nDownloaded files will not be deleted.", "Confirm", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        TTFollowedUser user = Globals.Settings.TikTokSettings.FollowedUsers.Find(x => x.AccountName == item.Text);
                        Globals.Settings.TikTokSettings.FollowedUsers.Remove(user);
                    }
                }
            }
            IGPopulateFollowed();
            Globals.Settings.Save();
        }

        private void btnTTScrape_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in lsvTTFollowed.SelectedItems)
            {
                formController.tt.FetchData(item.Text, Convert.ToInt32(nudTTMaxToScrape.Value));
            }
            TTPopulateFollowed();
            Globals.Settings.Save();
        }

        private void txtTTScrapeAccount_TextChanged(object sender, EventArgs e)
        {
            Globals.Settings.TikTokSettings.LastScrapedUser = txtTTScrapeAcct.Text;
            Globals.Settings.Save();
        }

        private void nudTTMaxToScrape_ValueChanged(object sender, EventArgs e)
        {
            Globals.Settings.TikTokSettings.DefaultMaxScrape = Convert.ToInt32(nudTTMaxToScrape.Value);
            Globals.Settings.Save();
        }

        private void TTPopulateFollowed()
        {
            if (Globals.Settings.TikTokSettings.FollowedUsers == null)
                return;
            lsvTTFollowed.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            lsvTTFollowed.Items.Clear();
            foreach (TTFollowedUser user in Globals.Settings.TikTokSettings.FollowedUsers)
            {
                ListViewItem item = new ListViewItem(user.AccountName);
                item.SubItems.Add(user.LastScraped.ToString());
                item.SubItems.Add(formController.tt.GetItemFileCount(user.AccountName).ToString());
                item.SubItems.Add(user.LastValidated.ToString());
                lsvTTFollowed.Items.Add(item);
            }
        }
        #endregion

        private void btnTTParseOnly_Click(object sender, EventArgs e)
        {
            if (lsvTTFollowed.SelectedItems.Count > 1)
            {
                MessageBox.Show("This mode only supports a single selection.");
                return;
            }
            formController.tt.Parse(lsvTTFollowed.SelectedItems[0].Text);
            TTPopulateFollowed();
            Globals.Settings.Save();
        }

        private void btnYTScrapeVideo_Click(object sender, EventArgs e)
        {
            formController.yt.FetchData(txtYTURL.Text, Controllers.YTScrapeType.Video);
        }

        private void btnYTScrapePlaylist_Click(object sender, EventArgs e)
        {
            formController.yt.FetchData(txtYTURL.Text, Controllers.YTScrapeType.Playlist);
        }

        private void btnYTScrapeChannel_Click(object sender, EventArgs e)
        {
            formController.yt.FetchData(txtYTURL.Text, Controllers.YTScrapeType.Channel);
        }

        private void btnProcessQueue_Click(object sender, EventArgs e)
        {
            formController.queue.ProcessQueue(formController);
        }
    }
}
