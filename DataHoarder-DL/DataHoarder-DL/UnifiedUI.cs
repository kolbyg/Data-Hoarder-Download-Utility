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

namespace DataHoarder_DL
{
    public partial class UnifiedUI : Form
    {
        //TODO timers for autoadd, autoscrape
        //TODO Multiline text
        //TODO URI Parser
        //TODO Settings page
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
            LoadListView();
        }
        private void LoadListView()
        {
            foreach(UnifiedScrapeItem scrapeItem in Globals.Settings.ScrapeItems)
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
                listItem.SubItems.Add(Math.Round(ByteSize.FromBytes(scrapeItem.TotalSize).GigaBytes,2).ToString() + "GB");//TODO fix this, use GB
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
            Color BackColor = Color.White;
            Color ForeColor = Color.Black;
            if(IsErrorState)
            {
                BackColor = Color.Red;
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

        private void mainList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (mainList.SelectedItems.Count != 1)
                return;
            UnifiedScrapeItem scrapeItem = Globals.Settings.ScrapeItems.Find(x => x.Id == Guid.Parse(mainList.SelectedItems[0].Tag.ToString()));
            txtURI.Text = scrapeItem.URI;
            nudMaxScrape.Value = scrapeItem.MaxToScrape;
            nudMaxDays.Value = scrapeItem.ScrapeDaysMaximum;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (mainList.SelectedItems.Count > 1)
                return;
            else if (mainList.SelectedItems.Count == 0)
                return; //TODO create new item
            else
            {
                UnifiedScrapeItem scrapeItem = Globals.Settings.ScrapeItems.Find(x => x.Id == Guid.Parse(mainList.SelectedItems[0].Tag.ToString()));
                scrapeItem.URI = txtURI.Text;
                scrapeItem.ScrapeDaysMaximum = Convert.ToInt32(nudMaxDays.Value);
                scrapeItem.MaxToScrape = Convert.ToInt32(nudMaxScrape.Value);
                Globals.Settings.Save();
            }
        }

        private void btnQuickScrape_Click(object sender, EventArgs e)
        {
            //TODO
        }

        private void btnQueueItems_Click(object sender, EventArgs e)
        {
            foreach(ListViewItem listItem in mainList.SelectedItems)
            {
                //Get item by GUID in tag, store it locally
                UnifiedScrapeItem scrapeItem = Globals.Settings.ScrapeItems.Find(x=> x.Id == Guid.Parse(listItem.Tag.ToString()));
                //Ensure the item isnt already queued, if not, add it
                if(Globals.Settings.UnifiedQueue.Find(x=> x.ItemId == scrapeItem.Id) == null)
                {
                    UnifiedQueueItem queueItem = new UnifiedQueueItem()
                    {
                        MaxToScrape = scrapeItem.MaxToScrape,
                        ScrapeType = scrapeItem.ScrapeType,
                        URI = scrapeItem.URI,
                        ItemId = scrapeItem.Id
                    };
                    Globals.Settings.UnifiedQueue.Add(queueItem);
                }
            }
            RefreshList();
        }

        private async void runFullValidationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            await Controllers.ValidationController.ValidateAllObjects();
            RefreshList();
            Globals.Settings.Save();
        }

        private void btnAutoQueue_Click(object sender, EventArgs e)
        {
            foreach(UnifiedScrapeItem scrapeItem in Globals.Settings.ScrapeItems)
            {
                if(IsScrapingDue(scrapeItem))
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

        private void btnStartScraper_Click(object sender, EventArgs e)
        {
            scrapeController.ProcessQueue();
            RefreshList();
        }
    }
}
