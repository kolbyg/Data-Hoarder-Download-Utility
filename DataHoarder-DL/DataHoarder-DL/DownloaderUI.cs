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
        Logger logger = LogManager.GetCurrentClassLogger();
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
            NLog.Windows.Forms.RichTextBoxTarget.ReInitializeAllTextboxes(this);
            ApplyNewLogLevel();
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
            comboBox1.SelectedItem = Globals.Settings.LogLevel;
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
            logger.Debug("Refreshing Queue...");
            if (Globals.Settings.DLQueue == null)
                return;
            lsvQueue.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            lsvQueue.Items.Clear();
            foreach (Models.Queue.QueueItem queueItem in Globals.Settings.DLQueue.QueueItems)
            {
                ListViewItem item = new ListViewItem(queueItem.Order.ToString());
                switch (queueItem.ScrapeType)
                {
                    case Models.Queue.ScrapeTypes.TikTok:
                        item.SubItems.Add("TT");
                        break;
                    case Models.Queue.ScrapeTypes.Youtube:
                        item.SubItems.Add("IG");
                        break;
                    case Models.Queue.ScrapeTypes.Instagram:
                        item.SubItems.Add("YT");
                        break;
                }
                item.SubItems.Add(queueItem.URI);
                lsvQueue.Items.Add(item);
            }
            logger.Debug("Queue refresh completed.");
        }
        #region instagram
        private void btnIGScrape_Click(object sender, EventArgs e)
        {
            logger.Debug("Adding selected items to queue");
            foreach (ListViewItem item in lsvIGFollowed.SelectedItems)
            {
                Models.Queue.QueueItem queueItem = new Models.Queue.QueueItem()
                {
                    URI = item.Text,
                    MaxToScrape = Convert.ToInt32(nudIGMaxToScrape.Value),
                    ScrapeType = Models.Queue.ScrapeTypes.Instagram
                };
                formController.queue.AddToQueue(queueItem);
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
            logger.Debug("Populating IG list view...");
            if (Globals.Settings.InstagramSettings.FollowedUsers == null)
                return;
            lsvIGFollowed.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            lsvIGFollowed.Items.Clear();
            foreach (IGFollowedUser user in Globals.Settings.InstagramSettings.FollowedUsers)
            {
                ListViewItem item = new ListViewItem(user.AccountName);
                item.SubItems.Add(user.LastScraped.ToString());
                item.SubItems.Add(formController.ig.GetItemMetadataCount(user.AccountName).ToString());
                item.SubItems.Add(formController.ig.GetItemFileCount(user.AccountName).ToString());
                item.SubItems.Add(user.LastValidated.ToString());
                lsvIGFollowed.Items.Add(item);
            }
            logger.Debug("Done populating IG list view");
        }
        private void ptnIGParseOnly_Click(object sender, EventArgs e)
        {
            logger.Debug("Beginning parse only operation.");
            if (lsvIGFollowed.SelectedItems.Count > 1)
            {
                MessageBox.Show("This mode only supports a single selection.");
                return;
            }
            formController.ig.Parse(lsvIGFollowed.SelectedItems[0].Text);
            IGPopulateFollowed();
            Globals.Settings.Save();
            logger.Debug("Parsing completed.");
        }
        private void btnIGValidate_Click(object sender, EventArgs e)
        {
            logger.Debug("Begin validating IG data");
            formController.ig.Validate();
            IGPopulateFollowed();
            Globals.Settings.Save();
            logger.Debug("Completed validating IG data");
        }
        private void btnIGAddUser_Click(object sender, EventArgs e)
        {
            IGFollowedUser newUser = new IGFollowedUser(txtIGScrapeAcct.Text);
            if (Globals.Settings.InstagramSettings.FollowedUsers.Any(p => p.AccountName == newUser.AccountName))
                MessageBox.Show("User already exists and will not be added");
            else
            {
                Globals.Settings.InstagramSettings.FollowedUsers.Add(newUser);
                logger.Info("Added " + newUser.AccountName + " to list");
            }
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
                        logger.Info("Removed " + user.AccountName + " from list");
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
            {
                Globals.Settings.TikTokSettings.FollowedUsers.Add(newUser);
                logger.Info("Added " + newUser.AccountName + " to list");
            }
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
                        logger.Info("Removed " + user.AccountName + " from list");
                    }
                }
            }
            IGPopulateFollowed();
            Globals.Settings.Save();
        }

        private void btnTTScrape_Click(object sender, EventArgs e)
        {
            logger.Debug("Adding selected items to queue");
            foreach (ListViewItem item in lsvTTFollowed.SelectedItems)
            {
                //formController.tt.FetchData(item.Text, Convert.ToInt32(nudTTMaxToScrape.Value));

                Models.Queue.QueueItem queueItem = new Models.Queue.QueueItem()
                {
                    URI = item.Text,
                    MaxToScrape = Convert.ToInt32(nudIGMaxToScrape.Value),
                    ScrapeType = Models.Queue.ScrapeTypes.TikTok
                };
                formController.queue.AddToQueue(queueItem);
            }
            RefreshQueue();
            //TTPopulateFollowed();
            //Globals.Settings.Save();

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
            logger.Debug("Populating TT list view...");
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
            logger.Debug("Done populating IG list view");
        }
        #endregion

        private void btnTTParseOnly_Click(object sender, EventArgs e)
        {
            logger.Debug("Beginning parse only operation.");
            if (lsvTTFollowed.SelectedItems.Count > 1)
            {
                MessageBox.Show("This mode only supports a single selection.");
                return;
            }
            formController.tt.Parse(lsvTTFollowed.SelectedItems[0].Text);
            TTPopulateFollowed();
            Globals.Settings.Save();
            logger.Debug("Parsing completed.");
        }

        private void btnYTScrapeVideo_Click(object sender, EventArgs e)
        {
            logger.Debug("Adding selected items to queue");
            //formController.yt.FetchData(txtYTURL.Text, Controllers.YTScrapeType.Video);
            Models.Queue.QueueItem queueItem = new Models.Queue.QueueItem()
            {
                URI = txtYTURL.Text,
                ScrapeType = Models.Queue.ScrapeTypes.Youtube,
                YTScrapeType = Controllers.YTScrapeType.Video
            };
            formController.queue.AddToQueue(queueItem);
            RefreshQueue();
        }

        private void btnYTScrapePlaylist_Click(object sender, EventArgs e)
        {
            logger.Debug("Adding selected items to queue");
            //formController.yt.FetchData(txtYTURL.Text, Controllers.YTScrapeType.Playlist);
            Models.Queue.QueueItem queueItem = new Models.Queue.QueueItem()
            {
                URI = txtYTURL.Text,
                ScrapeType = Models.Queue.ScrapeTypes.Youtube,
                YTScrapeType = Controllers.YTScrapeType.Playlist
            };
            formController.queue.AddToQueue(queueItem);
            RefreshQueue();
        }

        private void btnYTScrapeChannel_Click(object sender, EventArgs e)
        {
            logger.Debug("Adding selected items to queue");
            //formController.yt.FetchData(txtYTURL.Text, Controllers.YTScrapeType.Channel);
            Models.Queue.QueueItem queueItem = new Models.Queue.QueueItem()
            {
                URI = txtYTURL.Text,
                ScrapeType = Models.Queue.ScrapeTypes.Youtube,
                YTScrapeType = Controllers.YTScrapeType.Channel
            };
            formController.queue.AddToQueue(queueItem);
            RefreshQueue();
        }

        private void btnProcessQueue_Click(object sender, EventArgs e)
        {
            logger.Debug("Begin processing Queue...");
            formController.queue.ProcessQueue(formController);
            logger.Debug("Queue completed, refreshing UI...");
            RefreshQueue();
            IGPopulateFollowed();
            TTPopulateFollowed();
        }

        private void btnAddToQueue_Click(object sender, EventArgs e)
        {
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Globals.Settings.LogLevel = comboBox1.SelectedItem.ToString();
            Globals.Settings.Save();
            ApplyNewLogLevel();
        }
        private void ApplyNewLogLevel()
        {
            foreach (var rule in LogManager.Configuration.LoggingRules)
            {
                rule.SetLoggingLevels(LogLevel.FromString(Globals.Settings.LogLevel), LogLevel.Fatal);
            }
            LogManager.ReconfigExistingLoggers();
            logger.Info("Logger has been reconfigured.");
        }
    }
}
