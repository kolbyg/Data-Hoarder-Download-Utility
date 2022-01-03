using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;

namespace DataHoarder_DL.Controllers
{
    public class QueueController
    {
        /*public void AddToQueue(Models.Queue.InstagramItem Item)
        {
            Globals.Settings.DLQueue.IGQueueItems.Add(Item);
            Globals.Settings.Save();
        }
        public void AddToQueue(Models.Queue.TikTokItem Item)
        {
            Globals.Settings.DLQueue.TTQueueItems.Add(Item);
            Globals.Settings.Save();
        }
        public void AddToQueue(Models.Queue.YoutubeItem Item)
        {
            Globals.Settings.DLQueue.YTQueueItems.Add(Item);
            Globals.Settings.Save();
        }*/
        Logger logger = LogManager.GetCurrentClassLogger();
        public QueueController()
        {

        }

        public void AddToQueue(Models.Queue.QueueItem Item)
        {
            Globals.Settings.DLQueue.QueueItems.Add(Item);
            Globals.Settings.Save();
        }
        public void ProcessQueue(Controllers.FormController formController)
        {
            //formController.LockForms();
            List<Models.Queue.QueueItem> successfullyScraped = new List<Models.Queue.QueueItem>();
            foreach (Models.Queue.QueueItem queueItem in Globals.Settings.DLQueue.QueueItems)
            {
                try
                {
                    switch (queueItem.ScrapeType)
                    {
                        case Models.Queue.ScrapeTypes.TikTok:
                            formController.tt.FetchData(queueItem.URI, Convert.ToInt32(queueItem.MaxToScrape));
                            break;
                        case Models.Queue.ScrapeTypes.Youtube:
                            formController.yt.FetchData(queueItem.URI, queueItem.YTScrapeType);
                            break;
                        case Models.Queue.ScrapeTypes.Instagram:
                            formController.ig.FetchData(queueItem.URI, Convert.ToInt32(queueItem.MaxToScrape));
                            break;
                    }
                    successfullyScraped.Add(queueItem);
                }
                catch (Exception ex)
                {
                    logger.Error(ex);
                }
            }
            foreach (Models.Queue.QueueItem item in successfullyScraped)
            {
                Globals.Settings.DLQueue.QueueItems.Remove(item);
            }
            Globals.Settings.Save();
        }
    }
}
