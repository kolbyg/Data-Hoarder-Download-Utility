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
    public enum ScrapeType
    {
        Instagram,
        TikTok,
        YoutubeVideo,
        YoutubePlaylist,
        YoutubeChannel,
        Unknown
    }
    public enum ItemStatus
    {
        Idle,
        Pending,
        Scraping,
        Completed
    }
    public class TikTokSettings
    {
        [JsonProperty]
        public string LastScrapedUser = "arandomperson";
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
        public string LastScrapedUser = "arandomperson";
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
    public class UnifiedQueueItem
    {
        [JsonProperty]
        public Guid Id = Guid.NewGuid();
        [JsonProperty]
        public Guid ItemId;
        [JsonProperty]
        public ScrapeType ScrapeType;
        [JsonProperty]
        public int MaxToScrape;
        [JsonProperty]
        public string URI;
        [JsonProperty]
        public bool IsScraping = false;
        [JsonProperty]
        public bool ScrapingCompleted = false;
    }
    public class UnifiedScrapeItem
    {
        [JsonProperty]
        public Guid Id = Guid.NewGuid();
        [JsonProperty]
        public string URI;
        [JsonProperty]
        public string ShortName;
        [JsonProperty]
        public string FriendlyName;
        [JsonProperty]
        public ScrapeType ScrapeType;
        [JsonProperty]
        public DateTime LastScraped = DateTime.UnixEpoch;
        [JsonProperty]
        public DateTime LastValidated = DateTime.UnixEpoch;
        [JsonProperty]
        public int NumScraped = 0;
        [JsonProperty]
        public int NumFiles = 0;
        [JsonProperty]
        public long TotalSize = 0;
        [JsonProperty]
        public int ScrapeDaysMaximum = 30;
        [JsonProperty]
        public int MaxToScrape = 0;
        [JsonProperty]
        public string ItemPath;
        public void BuildDirectories()
        {
            switch (this.ScrapeType)
            {
                case ScrapeType.Instagram:
                    if (string.IsNullOrEmpty(this.FriendlyName)) throw new Exception("FriendlyName cannot be null for this scrape type!");
                    this.ItemPath = Globals.Settings.RootDownloadPath + "\\" + this.FriendlyName + "\\IG";
                    break;
                case ScrapeType.TikTok:
                    if (string.IsNullOrEmpty(this.FriendlyName)) throw new Exception("FriendlyName cannot be null for this scrape type!");
                    this.ItemPath = Globals.Settings.RootDownloadPath + "\\" + this.FriendlyName + "\\TT";
                    break;
                default:
                    if (string.IsNullOrEmpty(this.FriendlyName)) throw new Exception("FriendlyName cannot be null for this scrape type!");
                    this.ItemPath = Globals.Settings.RootDownloadPath + "\\" + this.FriendlyName + "\\Other";
                    break;

            }
            if (!Directory.Exists(Globals.Settings.RootDownloadPath + "\\" + FriendlyName)) { Directory.CreateDirectory(Globals.Settings.RootDownloadPath + "\\" + FriendlyName); }
        }
        public async Task Validate()
        {
            await Controllers.ValidationController.ValidateObject(this);
        }

    }
    public class SMTPSettings
    {
        [JsonProperty]
        public string SMTPServer;
        [JsonProperty]
        public string SMTPUser;
        [JsonProperty]
        public string SMTPPass;
        [JsonProperty]
        public string SMTPFrom;
        [JsonProperty]
        public string SMSMTPToTPUser;
        [JsonProperty]
        public int SMTPPort;
    }
    public class Settings
    {
        public void Save()
        {
            File.WriteAllText(Globals.SettingsPath, FileOperations.Json.SerializeSettings(Globals.Settings));
        }
        public void Initialize()
        {
            if (SettingsVersion <= 1)
            {
                //Migrate
                List<IGFollowedUser> IGUsersToRemove = new List<IGFollowedUser>();
                List<TTFollowedUser> TTUsersToRemove = new List<TTFollowedUser>();
                foreach (IGFollowedUser igFollowedUser in InstagramSettings.FollowedUsers)
                {
                    UnifiedScrapeItem item = new UnifiedScrapeItem()
                    {
                        FriendlyName = igFollowedUser.AccountName,
                        ScrapeType = ScrapeType.Instagram,
                        URI = "https://instagram.com/" + igFollowedUser.AccountName + "/",
                        ShortName = igFollowedUser.AccountName,
                        LastScraped = igFollowedUser.LastScraped,
                        LastValidated = igFollowedUser.LastValidated
                    };
                    ScrapeItems.Add(item);
                    item.BuildDirectories();
                    IGUsersToRemove.Add(igFollowedUser);
                }
                foreach(IGFollowedUser igFollowedUser in IGUsersToRemove)
                {
                    InstagramSettings.FollowedUsers.Remove(igFollowedUser);
                }
                foreach (TTFollowedUser ttFollowedUser in TikTokSettings.FollowedUsers)
                {
                    UnifiedScrapeItem item = new UnifiedScrapeItem()
                    {
                        FriendlyName = ttFollowedUser.AccountName,
                        ScrapeType = ScrapeType.TikTok,
                        URI = "https://www.tiktok.com/@" + ttFollowedUser.AccountName,
                        ShortName =ttFollowedUser.AccountName,
                        LastValidated = ttFollowedUser.LastValidated,
                        LastScraped = ttFollowedUser.LastScraped
                    };
                    ScrapeItems.Add(item);
                    item.BuildDirectories();
                    TTUsersToRemove.Add(ttFollowedUser);
                }
                foreach(TTFollowedUser ttFollowedUser in TTUsersToRemove)
                {
                    TikTokSettings.FollowedUsers.Remove(ttFollowedUser);
                }
                SettingsVersion = 2;
            }
            Save();
        }
        [JsonProperty]
        public int SettingsVersion = 1;
        [JsonProperty]
        public InstagramSettings InstagramSettings = new InstagramSettings();
        [JsonProperty]
        public TikTokSettings TikTokSettings = new TikTokSettings();
        [JsonProperty]
        public string RootDownloadPath = Environment.CurrentDirectory + "\\DL";
        [JsonProperty]
        public bool DisclaimerAccepted = false;
        [JsonProperty]
        public List<UnifiedQueueItem> UnifiedQueue = new List<UnifiedQueueItem>();
        [JsonProperty]
        public string LogLevel = "Info";
        [JsonProperty]
        public List<UnifiedScrapeItem> ScrapeItems = new List<UnifiedScrapeItem>();
        [JsonProperty]
        public SMTPSettings SMTPSettings = new SMTPSettings();
        [JsonProperty]
        public string WebhookURI;
        [JsonProperty]
        public string LogFolder;
        [JsonProperty]
        public bool LogErrorsToSMTP = false;
        [JsonProperty]
        public bool LogErrorsToWebhook = false;
        [JsonProperty]
        public bool Autoscrape = false;
        [JsonProperty]
        public bool Autoqueue = false;
        [JsonProperty]
        public int AutoscrapeEveryHours = 24;
        [JsonProperty]
        public bool RedirectScraperOutput = false;
        [JsonProperty]
        public bool AllowOverwrite = false;
        [JsonProperty]
        public bool AllowSimultaniousScraping = false;

    }
}
