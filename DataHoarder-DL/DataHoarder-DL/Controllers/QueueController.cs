using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataHoarder_DL.Controllers
{
    public class QueueController
    {
        public void AddToQueue(Models.Queue.InstagramItem Item)
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
        }
        public void ProcessQueue(Controllers.FormController formController)
        {

        }
    }
}
