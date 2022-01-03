using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace DataHoarder_DL.Models.Queue
{
    public class QueueItem
    {
        [JsonProperty]
        public int Order;
        [JsonProperty]
        public string URI;
        [JsonProperty]
        public int MaxToScrape;
        [JsonProperty]
        public Controllers.YTScrapeType YTScrapeType;
        [JsonProperty]
        public ScrapeTypes ScrapeType;
    }
    public enum ScrapeTypes
    {
        Youtube,
        TikTok,
        Instagram
    }
}
