using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using DataHoarder_DL.Models;
using System.IO;

namespace DataHoarder_DL
{
    static class Globals
    {
        public static string SettingsPath = Environment.CurrentDirectory + "\\settings.json";
        //public static List<Module> Modules = new List<Module>();
        //public static string WorkingDir = Environment.CurrentDirectory + "\\data";
        //public static string MediaDir = Environment.CurrentDirectory + "\\media";
        //public static string CacheDir = Environment.CurrentDirectory + "\\cache";
        public static string BinDir = Environment.CurrentDirectory + "\\bin";
        public static Settings Settings;
    }
    public class Queue
    {
        [JsonProperty]
        public List<Models.Queue.InstagramItem> IGQueueItems = new List<Models.Queue.InstagramItem>();
        [JsonProperty]
        public List<Models.Queue.TikTokItem> TTQueueItems = new List<Models.Queue.TikTokItem>();
        [JsonProperty]
        public List<Models.Queue.YoutubeItem> YTQueueItems = new List<Models.Queue.YoutubeItem>();
        [JsonProperty]
        public bool ProcessAsync = false;
    }
    public class TikTokSettings
    {
        [JsonProperty]
        public string LastScrapedUser = "donaldtrump";
        [JsonProperty]
        public int DefaultMaxScrape = 20;
        [JsonProperty]
        public List<TTFollowedUser> FollowedUsers = new List<TTFollowedUser>();
    }
    public class TTFollowedUser
    {
        [JsonProperty]
        public string AccountName;
        [JsonProperty]
        public DateTime LastScraped = DateTime.UnixEpoch;
        [JsonProperty]
        public DateTime LastValidated = DateTime.UnixEpoch;
        public TTFollowedUser(string Username)
        {
            AccountName = Username;
        }
    }
    public class InstagramSettings
    {
        [JsonProperty]
        public string IGUsername = "user";
        [JsonProperty]
        public string IGPass = "hunter2";
        [JsonProperty]
        public string LastScrapedUser = "donaldtrump";
        [JsonProperty]
        public int DefaultMaxScrape = 20;
        [JsonProperty]
        public List<IGFollowedUser> FollowedUsers = new List<IGFollowedUser>();
    }
    public class IGFollowedUser
    {
        [JsonProperty]
        public string AccountName;
        [JsonProperty]
        public DateTime LastScraped = DateTime.UnixEpoch;
        [JsonProperty]
        public DateTime LastValidated = DateTime.UnixEpoch;
        public IGFollowedUser(string Username)
        {
            AccountName = Username;
        }
    }
    public class Settings
    {
        public void Save()
        {
            File.WriteAllText(Globals.SettingsPath, FileOperations.Json.SerializeSettings(Globals.Settings));
        }
        [JsonProperty]
        public InstagramSettings InstagramSettings = new InstagramSettings();
        [JsonProperty]
        public TikTokSettings TikTokSettings = new TikTokSettings();
        [JsonProperty]
        public string RootDownloadPath = Environment.CurrentDirectory + "\\DL";
        [JsonProperty]
        public bool DisclaimerAccepted = false;
        [JsonProperty]
        public Queue DLQueue = new Queue();
    }
}
