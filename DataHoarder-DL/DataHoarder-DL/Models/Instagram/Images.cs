using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace DataHoarder_DL.Models.Instagram
{
    class EdgeMediaPreviewLike
    {
        [JsonProperty]
        public int count;
    }
    class EdgeMediaToCaption
    {
        [JsonProperty]
        public List<EdgeMediaToCaptionEdge> edges;
    }
    class EdgeMediaToCaptionEdge
    {
        [JsonProperty]
        public EdgeMediaToCaptionNode node;
    }
    class EdgeMediaToCaptionNode
    {
        [JsonProperty]
        public string text;
    }
    class EdgeMediaToComment
    {
        [JsonProperty]
        public int count;
    }
    class GraphImage
    {
        [JsonProperty]
        public string __typename;
        [JsonProperty]
        public bool comments_disabled;
        [JsonProperty]
        public Dimensions dimensions;
        [JsonProperty]
        public string display_url;
        [JsonProperty]
        public EdgeMediaPreviewLike edge_media_preview_like;
        [JsonProperty]
        public EdgeMediaToCaption edge_media_to_caption;
        [JsonProperty]
        public EdgeMediaToComment edge_media_to_comment;
        [JsonProperty]
        public object gating_info;
        [JsonProperty]
        public string id;
        [JsonProperty]
        public bool is_video;
        [JsonProperty]
        public string media_preview;
        [JsonProperty]
        public Owner owner;
        [JsonProperty]
        public string shortcode;
        [JsonProperty]
        public List<string> tags;
        [JsonProperty]
        public long taken_at_timestamp;
        [JsonProperty]
        public List<ThumbnailResource> thumbnail_resources;
        [JsonProperty]
        public string thumbnail_src;
        [JsonProperty]
        public List<string> urls;
        [JsonProperty]
        public string username;
        [JsonProperty]
        public int video_view_count;
    }
}
