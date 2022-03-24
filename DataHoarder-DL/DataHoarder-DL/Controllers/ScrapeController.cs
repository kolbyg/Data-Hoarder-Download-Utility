using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataHoarder_DL.Controllers
{
    internal class ScrapeController
    {
        TikTokController tikTokController;
        InstagramController instagramController;
        YoutubeController youtubeController;
        bool PauseQueue = false;
        internal ScrapeController()
        {
            tikTokController = new TikTokController();
            instagramController = new InstagramController();
            youtubeController = new YoutubeController();
        }
        internal async void Pause()
        {
            PauseQueue = true;
        }
        internal async Task ProcessQueue()
        {
            //split the queue into one queue per type
            List<UnifiedQueueItem> Queue = Globals.Settings.UnifiedQueue;
            List<UnifiedQueueItem> IGQueue = Queue.FindAll(x => x.ScrapeType == ScrapeType.Instagram);
            List<UnifiedQueueItem> TTQueue = Queue.FindAll(x => x.ScrapeType == ScrapeType.TikTok);
            List<UnifiedQueueItem> YTQueue = Queue.FindAll(x => (x.ScrapeType == ScrapeType.YoutubePlaylist) || (x.ScrapeType == ScrapeType.YoutubeVideo) || (x.ScrapeType == ScrapeType.YoutubeChannel));
            await Task.WhenAll(ScrapeIG(IGQueue), ScrapeTT(TTQueue), ScrapeYT(YTQueue));
            //ScrapeTT(TTQueue);
            //ScrapeYT(YTQueue);
            //await WaitForQueue();
            CleanupQueue();
        }
        private void CleanupQueue()
        {
            List<UnifiedQueueItem> ItemsCompleted = new List<UnifiedQueueItem>();
            foreach (UnifiedQueueItem queueItem in Globals.Settings.UnifiedQueue)
            {
                if (queueItem.ScrapingCompleted)
                {
                    ItemsCompleted.Add(queueItem);

                }
            }
            foreach(UnifiedQueueItem completedQueueItem in ItemsCompleted)
            {
                Globals.Settings.UnifiedQueue.Remove(completedQueueItem);
            }
            Globals.Settings.Save();
        }
        private async Task WaitForQueue()
        {
            bool QueueFinished = false;
            while (!QueueFinished)
            {
                int ItemsLeft = 0;
                foreach(UnifiedQueueItem queueItem in Globals.Settings.UnifiedQueue)
                {
                    if (!queueItem.ScrapingCompleted)
                        ItemsLeft++;
                }
                if (ItemsLeft == 0) QueueFinished = true;
                if (PauseQueue) QueueFinished = true; //TODO also check status on IG/TT controllers, they need to be idle
                await Task.Delay(1000);
            }
        }
        private async Task ScrapeIG(List<UnifiedQueueItem> Queue)
        {
            foreach(UnifiedQueueItem item in Queue)
            {
                if (await instagramController.FetchData(item))
                    item.ScrapingCompleted = true;
            }
        }
        private async Task ScrapeYT(List<UnifiedQueueItem> Queue)
        {
            foreach (UnifiedQueueItem item in Queue)
            {
                if(await youtubeController.FetchData(item))
                item.ScrapingCompleted = true;
            }
        }
        private async Task ScrapeTT(List<UnifiedQueueItem> Queue)
        {
            foreach (UnifiedQueueItem item in Queue)
            {
                if (await tikTokController.FetchData(item))
                    item.ScrapingCompleted = true;
            }
        }
        internal void Kill()
        {
            //TODO
        }
        internal async void Stop()
        {
            //TODO
        }
    }
}
