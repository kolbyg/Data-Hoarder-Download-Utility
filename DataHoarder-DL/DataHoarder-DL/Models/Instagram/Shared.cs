using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using System.Threading.Tasks;
#pragma warning disable

namespace DataHoarder_DL.Models.Instagram
{
    public class ThumbnailResource
    {
        [JsonProperty]
        public int config_height;
        [JsonProperty]
        public int config_width;
        [JsonProperty]
        public string src;
    }
    public class Owner
    {
        [JsonProperty]
        public string id;
        [JsonProperty]
        public string profile_pic_url;
        [JsonProperty]
        public string username;
    }
    public class Dimensions
    {
        [JsonProperty]
        public int height;
        [JsonProperty]
        public int width;
    }
    public class IGData
    {
        [JsonProperty]
        public List<GraphImage> GraphImages;
        [JsonProperty]
        public List<GraphStory> GraphStories;
        [JsonProperty]
        public GraphProfileInfo GraphProfileInfo;
    }
}
