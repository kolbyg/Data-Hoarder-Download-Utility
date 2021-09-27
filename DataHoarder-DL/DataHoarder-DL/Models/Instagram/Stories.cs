using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
#pragma warning disable

namespace DataHoarder_DL.Models.Instagram
{
    class TappableObject
    {
        [JsonProperty]
        public string __typename;
        [JsonProperty]
        public object attribution;
        [JsonProperty]
        public object custom_title;
        [JsonProperty]
        public string full_name;
        [JsonProperty]
        public decimal height;
        [JsonProperty]
        public string id;
        [JsonProperty]
        public string name;
        [JsonProperty]
        public bool is_private;
        [JsonProperty]
        public decimal rotation;
        [JsonProperty]
        public string username;
        [JsonProperty]
        public decimal width;
        [JsonProperty]
        public decimal x;
        [JsonProperty]
        public decimal y;
    }
    class VideoResource
    {
        [JsonProperty]
        public int config_height;
        [JsonProperty]
        public int config_width;
        [JsonProperty]
        public string mime_type;
        [JsonProperty]
        public string profile;
        [JsonProperty]
        public string src;
    }
    class GraphStory
    {
        [JsonProperty]
        public string __typename;
        [JsonProperty]
        public Dimensions dimensions;
        [JsonProperty]
        public List<ThumbnailResource> display_resources;
        [JsonProperty]
        public string display_url;
        [JsonProperty]
        public long expiring_at_timestamp;
        [JsonProperty]
        public bool highlight;
        [JsonProperty]
        public string id;
        [JsonProperty]
        public bool is_video;
        [JsonProperty]
        public string media_preview;
        [JsonProperty]
        public object overlay_image_resources;
        [JsonProperty]
        public Owner owner;
        [JsonProperty]
        public string shortcode;
        [JsonProperty]
        public bool should_log_client_event;
        [JsonProperty]
        public object story_app_attribution;
        [JsonProperty]
        public object story_cta_url;
        [JsonProperty]
        public object story_view_count;
        [JsonProperty]
        public long taken_at_timestamp;
        [JsonProperty]
        public List<TappableObject> tappable_objects;
        [JsonProperty]
        public string tracking_token;
        [JsonProperty]
        public List<string> urls;
        [JsonProperty]
        public string username;
        [JsonProperty]
        public float video_duration;
        [JsonProperty]
        public List<VideoResource> video_resources;


    }
}
