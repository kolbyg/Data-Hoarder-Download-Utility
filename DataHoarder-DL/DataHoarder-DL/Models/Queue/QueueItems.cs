using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace DataHoarder_DL.Models.Queue
{
    public class TikTokItem
    {
        [JsonProperty]
        public int Order;
    }
    public class InstagramItem
    {
        [JsonProperty]
        public int Order;
        [JsonProperty]
        public string Username;
        [JsonProperty]
        public int MaxToScrape;
    }
    public class YoutubeItem
    {
        [JsonProperty]
        public int Order;
        [JsonProperty]
        public string Username;
        [JsonProperty]
        Controllers.YTScrapeType Type;
    }
}
