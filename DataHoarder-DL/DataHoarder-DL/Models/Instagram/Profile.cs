using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
#pragma warning disable

namespace DataHoarder_DL.Models.Instagram
{
    public class GraphProfileInfo
    {
        [JsonProperty]
        public ProfileInfo info;
        [JsonProperty]
        public long created_time;
        [JsonProperty]
        public string username;
    }
    public class ProfileInfo
    {
        [JsonProperty]
        public string biography;
        [JsonProperty]
        public long followers_count;
        [JsonProperty]
        public long following_count;
        [JsonProperty]
        public string full_name;
        [JsonProperty]
        public string id;
        [JsonProperty]
        public bool is_business_account;
        [JsonProperty]
        public bool is_joined_recently;
        [JsonProperty]
        public bool is_private;
        [JsonProperty]
        public long posts_count;
        [JsonProperty]
        public string profile_pic_url;
    }
}
