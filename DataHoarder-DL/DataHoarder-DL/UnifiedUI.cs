using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ByteSizeLib;
using NLog;

namespace DataHoarder_DL
{
    public partial class UnifiedUI : Form
    {
        //TODO timers for autoadd, autoscrape
        //TODO Multiline text
        //TODO Settings page
        //TODO rework logging
        Logger logger = LogManager.GetCurrentClassLogger();
        Controllers.FormController formController;
        Controllers.ScrapeController scrapeController;
        public UnifiedUI(Controllers.FormController formController)
        {
            this.formController = formController;
            InitializeComponent();
            scrapeController = new Controllers.ScrapeController();
        }

        private void UnifiedUI_Load(object sender, EventArgs e)
        {
            NLog.Windows.Forms.RichTextBoxTarget.ReInitializeAllTextboxes(this);
            ApplyNewLogLevel();
            LoadListView();
        }
        private void LoadListView()
        {
            foreach (UnifiedScrapeItem scrapeItem in Globals.Settings.ScrapeItems)
            {
                ListViewItem listItem = new ListViewItem(scrapeItem.ScrapeType.ToString());
                //Short Name
                listItem.SubItems.Add(scrapeItem.ShortName);
                //URI
                listItem.SubItems.Add(scrapeItem.URI);
                //Status
                listItem.SubItems.Add(GetItemStatus(scrapeItem).ToString());
                //Last Validated
                listItem.SubItems.Add(scrapeItem.LastValidated.ToString());
                //Last Scraped
                listItem.SubItems.Add(FormatListviewTimestamp(scrapeItem.LastScraped.ToString(), IsScrapingDue(scrapeItem)));
                //# Files
                listItem.SubItems.Add(scrapeItem.NumFiles.ToString());
                //File Size
                listItem.SubItems.Add(Math.Round(ByteSize.FromBytes(scrapeItem.TotalSize).GigaBytes, 2).ToString() + "GB");//TODO fix this, use GB
                listItem.Tag = scrapeItem.Id;
                listItem.UseItemStyleForSubItems = false;
                mainList.Items.Add(listItem);
            }
        }
        private void RefreshList()
        {
            mainList.Items.Clear();
            LoadListView();
        }
        private bool IsScrapingDue(UnifiedScrapeItem ScrapeItem)
        {
            if (ScrapeItem.LastScraped.AddDays(ScrapeItem.ScrapeDaysMaximum) < DateTime.Now)
                return true;
            else return false;
        }
        private ListViewItem.ListViewSubItem FormatListviewTimestamp(string Text, bool IsErrorState)
        {
            Color BackColor = Color.Black;
            Color ForeColor = Color.Lime;
            if (IsErrorState)
            {
                BackColor = Color.Red;
                ForeColor = Color.Black;
            }
            ListViewItem.ListViewSubItem subItem = new ListViewItem.ListViewSubItem()
            {
                Text = Text,
                BackColor = BackColor,
                ForeColor = ForeColor,
            };
            return subItem;
        }
        private ItemStatus GetItemStatus(UnifiedScrapeItem scrapeItem)
        {
            //See if its in the queue
            UnifiedQueueItem queueItem = Globals.Settings.UnifiedQueue.Find(x => x.ItemId == scrapeItem.Id);
            if (queueItem == null) return ItemStatus.Idle;
            else if (queueItem.IsScraping) return ItemStatus.Scraping;
            else if (!queueItem.IsScraping) return ItemStatus.Pending;
            return ItemStatus.Idle;
        }
        private ScrapeType ParseItemType(string URI)
        {
            if (URI.Contains("instagram.com/")) return ScrapeType.Instagram;
            if (URI.Contains("tiktok.com/@")) return ScrapeType.TikTok;
            if (URI.Contains("youtube.com/watch?v=")) return ScrapeType.YoutubeVideo;
            if (URI.Contains("youtube.com/playlist?list=")) return ScrapeType.YoutubePlaylist;
            if (URI.Contains("youtube.com/c")) return ScrapeType.YoutubeChannel;
            return ScrapeType.Unknown;
        }
        private string ParseShortName(string URI, ScrapeType ScrapeType)
        {
            string Shortname = URI;
            switch (ScrapeType)
            {
                case ScrapeType.Instagram:
                    if (URI.EndsWith("/"))
                        Shortname = Shortname.Remove(Shortname.Length - 1);
                    Shortname = Shortname.Substring(Shortname.LastIndexOf('/') + 1);
                    break;
                case ScrapeType.TikTok:
                    if (URI.EndsWith("/"))
                        Shortname = Shortname.Remove(Shortname.Length - 1);
                    Shortname = Shortname.Substring(Shortname.LastIndexOf('@') + 1);
                    break;
                default:
                    break;
            }
            return Shortname;
        }
        private void mainList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (mainList.SelectedItems.Count != 1)
                return;
            UnifiedScrapeItem scrapeItem = Globals.Settings.ScrapeItems.Find(x => x.Id == Guid.Parse(mainList.SelectedItems[0].Tag.ToString()));
            txtURI.Text = scrapeItem.URI;
            nudMaxScrape.Value = scrapeItem.MaxToScrape;
            nudMaxDays.Value = scrapeItem.ScrapeDaysMaximum;
            txtFriendlyName.Text = scrapeItem.FriendlyName;
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (mainList.SelectedItems.Count > 1)
                return;
            else if (mainList.SelectedItems.Count == 0)
            {
                string[] URIstoAdd = txtURI.Text.Split(Environment.NewLine);
                foreach (string URItoAdd in URIstoAdd)
                {
                    ScrapeType scrapeType = ParseItemType(URItoAdd);
                    //ensure it doesnt exist already
                    UnifiedScrapeItem duplicateCheck = Globals.Settings.ScrapeItems.Find(x => (x.URI == URItoAdd) && (x.ScrapeType == scrapeType));
                    if (duplicateCheck != null)
                        continue; //TODO log duplicate warning
                    if (scrapeType == ScrapeType.Unknown)
                    {
                       MessageBox.Show("Unknown type detected");
                        //TODO, prompt for type
                    }
                    UnifiedScrapeItem newItem = new UnifiedScrapeItem()
                    {
                        FriendlyName = txtFriendlyName.Text,
                        ScrapeType = scrapeType,
                        URI = URItoAdd,
                        ScrapeDaysMaximum = Convert.ToInt32(nudMaxDays.Value),
                        MaxToScrape = Convert.ToInt32(nudMaxScrape.Value),
                        ShortName = ParseShortName(URItoAdd, scrapeType)
                    };
                    Globals.Settings.ScrapeItems.Add(newItem);
                    newItem.BuildDirectories();
                }
            }
            else
            {
                UnifiedScrapeItem scrapeItem = Globals.Settings.ScrapeItems.Find(x => x.Id == Guid.Parse(mainList.SelectedItems[0].Tag.ToString()));
                scrapeItem.URI = txtURI.Text;
                scrapeItem.ScrapeDaysMaximum = Convert.ToInt32(nudMaxDays.Value);
                scrapeItem.MaxToScrape = Convert.ToInt32(nudMaxScrape.Value);
                scrapeItem.FriendlyName = txtFriendlyName.Text;
            }
            Globals.Settings.Save();
            RefreshList();
        }

        private async void btnQuickScrape_Click(object sender, EventArgs e)
        {
            if (mainList.SelectedItems.Count > 0)
                return;
            else
            {
                string[] URIstoAdd = txtURI.Text.Split(Environment.NewLine);
                foreach (string URItoAdd in URIstoAdd)
                {
                    ScrapeType scrapeType = ParseItemType(URItoAdd);
                    //ensure it doesnt exist already
                    UnifiedScrapeItem duplicateCheck = Globals.Settings.ScrapeItems.Find(x => (x.URI == URItoAdd) && (x.ScrapeType == scrapeType));
                    if (duplicateCheck != null)
                        continue; //TODO log duplicate warning
                    if (scrapeType == ScrapeType.Unknown)
                    {
                        DialogResult confirmUnknown = MessageBox.Show("Unknown type detected, attempt to process with yt-dlp?", "Confirm", MessageBoxButtons.YesNo);
                        if (confirmUnknown == DialogResult.Yes)
                            scrapeType = ScrapeType.YoutubeVideo;
                        else
                            return;
                        //TODO, prompt for type
                    }
                    UnifiedScrapeItem newItem = new UnifiedScrapeItem()
                    {
                        FriendlyName = "Single Download",
                        ScrapeType = scrapeType,
                        URI = URItoAdd,
                        ScrapeDaysMaximum = Convert.ToInt32(nudMaxDays.Value),
                        MaxToScrape = Convert.ToInt32(nudMaxScrape.Value),
                        ShortName = ParseShortName(URItoAdd, scrapeType)
                    };
                    Globals.Settings.ScrapeItems.Add(newItem);
                    newItem.BuildDirectories();
                    UnifiedQueueItem queueItem = QueueItem(newItem);
                    Globals.Settings.UnifiedQueue.Add(queueItem);
                    scrapeController.ProcessQueue();
                    Globals.Settings.UnifiedQueue.Remove(queueItem);
                    Globals.Settings.ScrapeItems.Remove(newItem);

                }
            }
            Globals.Settings.Save();
            RefreshList();
        }
        private UnifiedQueueItem QueueItem(UnifiedScrapeItem ScrapeItem)
        {
            UnifiedQueueItem queueItem = new UnifiedQueueItem()
            {
                MaxToScrape = ScrapeItem.MaxToScrape,
                ScrapeType = ScrapeItem.ScrapeType,
                ItemId = ScrapeItem.Id
            };
            switch (ScrapeItem.ScrapeType)
            {
                case ScrapeType.Instagram:
                    queueItem.URI = ScrapeItem.ShortName;
                    break;
                case ScrapeType.TikTok:
                    queueItem.URI = ScrapeItem.ShortName;
                    break;
                default:
                    queueItem.URI = ScrapeItem.URI;
                    break;
            }
            return queueItem;
        }
        private void btnQueueItems_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem listItem in mainList.SelectedItems)
            {
                //Get item by GUID in tag, store it locally
                UnifiedScrapeItem scrapeItem = Globals.Settings.ScrapeItems.Find(x => x.Id == Guid.Parse(listItem.Tag.ToString()));
                //Ensure the item isnt already queued, if not, add it
                if (Globals.Settings.UnifiedQueue.Find(x => x.ItemId == scrapeItem.Id) == null)
                {

                    Globals.Settings.UnifiedQueue.Add(QueueItem(scrapeItem));
                }
            }
            Globals.Settings.Save();
            RefreshList();
        }

        private async void runFullValidationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            await Controllers.ValidationController.ValidateAllObjects();
            Globals.Settings.Save();
            RefreshList();
        }

        private void btnAutoQueue_Click(object sender, EventArgs e)
        {
            foreach (UnifiedScrapeItem scrapeItem in Globals.Settings.ScrapeItems)
            {
                if (IsScrapingDue(scrapeItem))
                {
                    UnifiedQueueItem queueItem = new UnifiedQueueItem()
                    {
                        ItemId = scrapeItem.Id,
                        ScrapeType = scrapeItem.ScrapeType,
                        MaxToScrape = scrapeItem.MaxToScrape,
                        URI = scrapeItem.URI
                    };
                    Globals.Settings.UnifiedQueue.Add(queueItem);
                }
            }
            RefreshList();
        }

        private void btnKillScraper_Click(object sender, EventArgs e)
        {
            scrapeController.Kill();
            RefreshList();
        }

        private void btnStopScraper_Click(object sender, EventArgs e)
        {
            scrapeController.Stop();
            RefreshList();
        }

        private void btnPauseScraper_Click(object sender, EventArgs e)
        {
            scrapeController.Pause();
            RefreshList();
        }

        private async void btnStartScraper_Click(object sender, EventArgs e)
        {
            await scrapeController.ProcessQueue();
            RefreshList();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in mainList.SelectedItems)
            {
                Globals.Settings.ScrapeItems.Remove(Globals.Settings.ScrapeItems.Find(x => x.Id == Guid.Parse(item.Tag.ToString())));
            }
            Globals.Settings.Save();
            RefreshList();
        }

        private void UnifiedUI_Click(object sender, EventArgs e)
        {
            ClearSelection();
        }
        private void ClearSelection()
        {
            mainList.SelectedItems.Clear();
            nudMaxDays.Value = 30;
            txtURI.Text = "";
            nudMaxScrape.Value = 0;
        }

        private void btnMultilineAdd_Click(object sender, EventArgs e)
        {
            txtURI.BringToFront();
            if (txtURI.Multiline)
            {
                txtURI.Multiline = false;
                txtURI.Height = 23;
            }
            else
            {
                txtURI.Multiline = true;
                txtURI.Height = 230;
            }
        }

        private void btnClearQueue_Click(object sender, EventArgs e)
        {
            Globals.Settings.UnifiedQueue.Clear();
            Globals.Settings.Save();
            RefreshList();
        }

        private async void validateSelectedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in mainList.SelectedItems)
            {
                await Globals.Settings.ScrapeItems.Find(x => x.Id == Guid.Parse(item.Tag.ToString())).Validate();
            }
            Globals.Settings.Save();
            RefreshList();
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SettingsUI settings = new SettingsUI();
            settings.ShowDialog();
        }

        private void fileBrowserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BrowserUI browser = new BrowserUI();
            browser.ShowDialog();
        }
    }
}
