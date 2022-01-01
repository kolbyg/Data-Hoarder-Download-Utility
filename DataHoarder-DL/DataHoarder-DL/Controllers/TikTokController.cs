using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;
using DataHoarder_DL.Models.TikTok;
using System.Globalization;
using NLog;
using System.Net;

namespace DataHoarder_DL.Controllers
{
    class TikTokController
    {
        //string AuthUsername = "";
        //string AuthPass = "";
        string DLDir = Environment.CurrentDirectory;
        //string TimestampPath = Environment.CurrentDirectory + "\\timestamps";
        string MetadataPath = Environment.CurrentDirectory + "\\metadata";
        string MediaPath = Environment.CurrentDirectory + "\\media";
        string Cache = Environment.CurrentDirectory + "\\Cache";
        string ytdlpPath = Globals.BinDir + "\\yt-dlp";
        string PersonRootDir = Environment.CurrentDirectory + "\\UNKNOWN";
        bool Overwrite = false;
        Logger logger = LogManager.GetCurrentClassLogger();
        public TikTokController()
        {
            DLDir = Globals.Settings.RootDownloadPath + "\\TT";
            if (!Directory.Exists(DLDir)) { Directory.CreateDirectory(DLDir); }
            //TimestampPath = DLDir + "\\timestamps";
            MetadataPath = DLDir + "\\metadata";
            MediaPath = DLDir + "\\media";
            Cache = DLDir + "\\Cache";
        }

        public int GetItemCount(string username)
        {
            return 0;
                /**
            string path = GetUserPath(username);
            if (String.IsNullOrEmpty(path))
                return 0;
            TTData data = ParseTTData(path + "\\IG\\metadata\\_working.json");
            int totalAssetCount = 0;
            if (data.GraphImages != null)
            {
                foreach (GraphImage image in data.GraphImages)
                {
                    foreach (string URL in image.urls)
                    {
                        totalAssetCount++;
                    }
                }
            }
            if (data.GraphStories != null)
            {
                foreach (GraphStory story in data.GraphStories)
                {
                    foreach (string URL in story.urls)
                    {
                        totalAssetCount++;
                    }
                }
            }
            if (data.GraphProfileInfo != null && data.GraphProfileInfo.info.profile_pic_url != null)
            {
                totalAssetCount++;
            }
            return totalAssetCount;*/
        }
        public bool FetchData(string username, int MaxToScrape = 50)
        {
            logger.Info($"Begin fetching data for {username} with a maximum of {MaxToScrape}");
            //Validate();
            //TODO download of missing items using web request
            //ScrapeMetadata(username);
            ScrapeAllData(username, MaxToScrape);
            Parse(username);

            Globals.Settings.TikTokSettings.FollowedUsers.Find(x => x.AccountName == username).LastScraped = DateTime.Now;
            return false;

        }
        public bool Parse(string username)
        {
            logger.Info("Begin processing cached data");
            ProcessCache(username);
            return false;
        }
        private void ProcessCache(string username)
        {/**
            string CachedMetadata = $"{Cache}\\{username}.json";
            logger.Debug("Begin processing cache from " + CachedMetadata);

            //Process Directory Naming
            IGData tempdata = ParseIGData(CachedMetadata);
            UpdatePaths(tempdata, true);

            //Process Media
            if (!Directory.Exists(MediaPath)) { Directory.CreateDirectory(MediaPath); }
            logger.Debug("Begin processing media");
            //Process Images
            IGData queue = ParseIGData(CachedMetadata);
            if (queue.GraphImages != null)
            {
                logger.Debug("GraphImages is not null, processing");
                if (!Directory.Exists(MediaPath + "\\images")) { Directory.CreateDirectory(MediaPath + "\\images"); }
                foreach (GraphImage image in queue.GraphImages)
                {
                    foreach (string url in image.urls)
                    {
                        string fileName = URLtoName(url);
                        DateTimeOffset dto = DateTimeOffset.FromUnixTimeSeconds(image.taken_at_timestamp);
                        if (File.Exists(Cache + "\\" + fileName))
                        {
                            if (!File.Exists(MediaPath + "\\images\\" + dto.ToString("yyyyMMdd") + "-" + fileName) || Overwrite)
                                File.Move(Cache + "\\" + fileName, MediaPath + "\\images\\" + dto.ToString("yyyyMMdd") + "-" + fileName, Overwrite);

                            if (!Overwrite && File.Exists(Cache + "\\" + fileName))
                                File.Delete(Cache + "\\" + fileName);
                        }
                    }
                }
            }

            //Process Stories
            if (queue.GraphStories != null)
            {
                if (!Directory.Exists(MediaPath + "\\stories")) { Directory.CreateDirectory(MediaPath + "\\stories"); }
                foreach (GraphStory story in queue.GraphStories)
                {
                    foreach (string url in story.urls)
                    {
                        string fileName = URLtoName(url);
                        DateTimeOffset dto = DateTimeOffset.FromUnixTimeSeconds(story.taken_at_timestamp);
                        if (File.Exists(Cache + "\\" + fileName))
                        {
                            if (!File.Exists(MediaPath + "\\stories\\" + dto.ToString("yyyyMMdd") + "-" + fileName) || Overwrite)
                                File.Move(Cache + "\\" + fileName, MediaPath + "\\stories\\" + dto.ToString("yyyyMMdd") + "-" + fileName, Overwrite);

                            if (!Overwrite && File.Exists(Cache + "\\" + fileName))
                                File.Delete(Cache + "\\" + fileName);
                        }
                    }
                }
            }

            //Process Profile Pic
            if (queue.GraphProfileInfo != null)
            {
                if (!Directory.Exists(MediaPath + "\\profilepics")) { Directory.CreateDirectory(MediaPath + "\\profilepics"); }

                string fileName = URLtoName(queue.GraphProfileInfo.info.profile_pic_url);
                if (File.Exists(Cache + "\\" + fileName))
                {
                    if (!File.Exists(MediaPath + "\\profilepics\\" + fileName) || Overwrite)
                        File.Move(Cache + "\\" + fileName, MediaPath + "\\profilepics\\" + fileName, Overwrite);

                    if (!Overwrite && File.Exists(Cache + "\\" + fileName))
                        File.Delete(Cache + "\\" + fileName);
                }
            }

            //Process Metadata
            if (!Directory.Exists(MetadataPath)) { Directory.CreateDirectory(MetadataPath); }
            string ArchivePath = MetadataPath + "\\archive";
            if (!Directory.Exists(ArchivePath)) { Directory.CreateDirectory(ArchivePath); }

            if (File.Exists(CachedMetadata))
                File.Move(CachedMetadata, MetadataPath + "\\import.json");

            CombineUserJsonData(username, Directory.GetFiles(MetadataPath));

            //Archive Metadata
            foreach (string file in Directory.GetFiles(MetadataPath))
            {
                if (file.Substring(file.LastIndexOf('\\') + 1) == "_working.json") continue;
                string filename = file.Substring(file.LastIndexOf('\\') + 1);
                string destFilepath = ArchivePath + "\\" + DateTime.Now.ToString("yyyyMMddHHmmss") + "-" + filename;
                File.Move(file, destFilepath);
            }

            //Delete Cache Dir
            if (Directory.GetFiles(Cache).Length == 0 && Directory.GetDirectories(Cache).Length == 0)
            {
                Directory.Delete(Cache, false);
            }*/

        }
        public bool ScrapeAllData(string username, int MaxItemsToScrape)
        {
            logger.Info($"Begin data scraping for {username}, maximum {MaxItemsToScrape} items");
            if (!Directory.Exists(Cache)) { Directory.CreateDirectory(Cache); }
            string scrapeCommand = BuildScrapeCommand(username, Cache, MaxItemsToScrape);
            InvokeTTScraper(scrapeCommand);
            return false;
        }
        private string BuildScrapeCommand(string AccountToScrape, string DownloadPath, int MaxItemsToScrape)
        {
            //string namingTemplate = "{urlname}";
            logger.Debug("Building scrape command");
            logger.Debug("AccountToScrape: " + AccountToScrape);
            //logger.Debug("IGUsername: " + IGUsername);
            //logger.Debug("IGPassword: " + IGPassword);
            logger.Debug("DownloadPath: " + DownloadPath);
            //logger.Debug("TimestampPath: " + TimestampPath);
            //logger.Debug("IncludeMediaMetadata: " + IncludeMediaMetadata);
            //logger.Debug("IncludeProfileMetadata: " + IncludeProfileMetadata);
            //logger.Debug("WriteTimestampFile: " + WriteTimestampFile);
            logger.Debug("MaxItemsToScrape: " + MaxItemsToScrape);
            //logger.Debug("namingTemplate: " + namingTemplate);
            string scrapeCommandBase = $"-P \"{DownloadPath}\" --download-archive \"{DownloadPath + "\\" + AccountToScrape + ".history"}\" --write-info-json --write-playlist-metafiles \"https://www.tiktok.com/@{AccountToScrape}\"";
            if (MaxItemsToScrape != 0)
            {
                scrapeCommandBase += $" --maximum {MaxItemsToScrape}";
                logger.Debug("Adding max items to scrape");
            }
            return scrapeCommandBase;
        }
        private void InvokeTTScraper(string ScrapeCommand)
        {
            logger.Info("Invoking scraper with command: " + ScrapeCommand);
            Process p = new Process();
            p.StartInfo.Arguments = ScrapeCommand;
            p.StartInfo.WorkingDirectory = ytdlpPath;
            p.StartInfo.FileName = "youtube-dl.exe";
            p.StartInfo.CreateNoWindow = false;
            p.StartInfo.RedirectStandardError = false;
            p.StartInfo.RedirectStandardOutput = false;
            p.Start();
            logger.Debug("Waiting for scraping to complete");
            p.WaitForExit();
        }
    }
}
