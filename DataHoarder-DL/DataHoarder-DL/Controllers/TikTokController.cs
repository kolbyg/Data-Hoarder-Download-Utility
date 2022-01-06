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
    public class TikTokController
    {
        //string AuthUsername = "";
        //string AuthPass = "";
        string DLDir = Environment.CurrentDirectory;
        string MetadataPath;
        string HistoryPath;
        string MediaPath;
        string CachePath;
        string ytdlpPath = Globals.BinDir + "\\yt-dlp";
        bool Overwrite = false;
        Logger logger = LogManager.GetCurrentClassLogger();
        public TikTokController()
        {
            DLDir = Globals.Settings.RootDownloadPath + "\\TT";
            if (!Directory.Exists(DLDir)) { Directory.CreateDirectory(DLDir); }
            MetadataPath = DLDir + "\\metadata";
            if (!Directory.Exists(MetadataPath)) { Directory.CreateDirectory(MetadataPath); }
            HistoryPath = DLDir + "\\history";
            if (!Directory.Exists(HistoryPath)) { Directory.CreateDirectory(HistoryPath); }
            MediaPath = DLDir + "\\media";
            if (!Directory.Exists(MediaPath)) { Directory.CreateDirectory(MediaPath); }
            CachePath = DLDir + "\\cache";
            if (!Directory.Exists(CachePath)) { Directory.CreateDirectory(CachePath); }
        }
        public int GetItemFileCount(string username)
        {
            string path = GetUserMediaPath(username);
            if (String.IsNullOrEmpty(path) || !Directory.Exists(path) || Directory.GetFiles(path).Length == 0)
                return 0;
            string[] files = Directory.GetFiles(path, "*.*", SearchOption.AllDirectories);
            return files.Length;
        }
        private string GetUserMetadataPath(string username)
        {
            return MetadataPath + "\\" + username;
        }
        private string GetUserMediaPath(string username)
        {
            return MediaPath + "\\" + username;
        }
        public int GetItemMetadataCount(string username)
        {
            return 0;
            //TODO
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
        public bool Validate()
        {
            logger.Info("Begin data validation");
            try
            {
                List<string> MissingIDs = new List<string>();
                //Get all IDs from the history files
                foreach (string file in Directory.GetFiles(HistoryPath))
                {
                    string AccountName = file.Remove(file.LastIndexOf('.')).Substring(file.LastIndexOf('\\') + 1);

                    List<string> FileNames = Directory.GetFiles(GetUserMediaPath(AccountName), "*.*", SearchOption.AllDirectories).ToList();
                    List<string> FileIDs = new List<string>();
                    List<string> UserMissingIDs = new List<string>();
                    List<string> HistoryIDs = new List<string>();
                    //Parse filename list to trim off the non ID part
                    foreach (string filename in FileNames)
                    {
                        string fileID;
                        fileID = filename.Remove(filename.LastIndexOf(']'));
                        fileID = fileID.Substring(fileID.LastIndexOf('[') + 1);
                        FileIDs.Add(fileID);
                    }

                    List<string> lines = File.ReadAllLines(file).ToList();
                    foreach (string line in lines)
                    {
                        HistoryIDs.Add(line.Substring(line.LastIndexOf(' ') + 1));
                    }

                    //Check for IDs that are in the history but NOT downloaded as files
                    foreach (string item in HistoryIDs)
                    {
                        if (FileIDs.Contains(item))
                        {
                            logger.Trace("History ID " + item + " validated successfully");
                            continue;
                        }
                        else
                        {
                            logger.Info("Missing file detected! ID: " + item);
                            UserMissingIDs.Add(item);

                        }
                    }
                    //Check for IDs that are downloaded but NOT in the history
                    foreach (string item in FileIDs)
                    {
                        if (HistoryIDs.Contains(item))
                        {
                            logger.Trace("File ID " + item + " validated successfully");
                            continue;
                        }
                        else
                        {
                            logger.Info("Extra file detected! ID: " + item);
                            //TODO not sure what to do here, possibly nothing.
                        }
                    }
                    if (UserMissingIDs != null && UserMissingIDs.Count > 0)
                    {
                        MissingIDs.AddRange(UserMissingIDs);
                        //TODO do something with the missing items, download them?DownloadMissing(ToDownload);
                    }
                    else
                    {
                        TTFollowedUser user = Globals.Settings.TikTokSettings.FollowedUsers.Find(x => x.AccountName == AccountName);
                        if (user != null)
                            user.LastValidated = DateTime.Now;
                    }
                }
                logger.Info("Data validation has completed.");
                if (MissingIDs != null && MissingIDs.Count > 0)
                {
                    logger.Warn("Some files failed to validate and will be downloaded.");
                    //TODO do something with the missing items, download them?DownloadMissing(ToDownload);
                    return false;
                }
                return true;

            }
            catch (Exception ex)
            {
                logger.Error(ex.ToString());
                return false;
            }
        }
        public bool FetchData(string username, int MaxToScrape = 50)
        {
            logger.Info($"Begin fetching data for {username} with a maximum of {MaxToScrape}");
            //ScrapeMetadata(username);
            ScrapeAllData(username, MaxToScrape);
            Parse(username);
            Validate();
            //TODO download of missing items using web request

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
        {
            try
            {
                string PersonMediaDir = MediaPath + "\\" + username;
                if (!Directory.Exists(PersonMediaDir)) { Directory.CreateDirectory(PersonMediaDir); }
                string PersonMetadataDir = MetadataPath + "\\" + username;
                if (!Directory.Exists(PersonMetadataDir)) { Directory.CreateDirectory(PersonMetadataDir); }
                //Move history file first
                //File.Move(CachePath + $"\\{username}.history", HistoryPath + $"\\{username}.history");
                DirectoryInfo directoryInfo = new DirectoryInfo(CachePath);
                foreach (FileInfo file in directoryInfo.EnumerateFiles())
                {
                    if (file.Extension == ".json")
                    {
                        if (File.Exists(PersonMetadataDir + "\\" + file.Name))
                        {
                            File.Move(PersonMetadataDir + "\\" + file.Name, PersonMetadataDir + "\\" + file.Name + "." + DateTime.Now.ToString("yyyyMMddHHmmss"));
                        }
                        file.MoveTo(PersonMetadataDir + "\\" + file.Name);
                    }
                    else
                    {
                        file.MoveTo(PersonMediaDir + "\\" + file.Name);
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
            }
            /**
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
            string scrapeCommand = BuildScrapeCommand(username, CachePath, MaxItemsToScrape);
            InvokeTTScraper(scrapeCommand);
            return false;
        }
        private string BuildScrapeCommand(string AccountToScrape, string DownloadPath, int MaxItemsToScrape)
        {
            string OutputNameFormat = "[%(id)s].%(ext)s";
            logger.Debug("Building scrape command");
            logger.Debug("AccountToScrape: " + AccountToScrape);
            logger.Debug("DownloadPath: " + CachePath);
            logger.Debug("HistoryPath: " + HistoryPath);
            logger.Debug("MaxItemsToScrape: " + MaxItemsToScrape);
            logger.Debug("Output Name Format: " + OutputNameFormat);

            string scrapeCommandBase = $"-P \"{CachePath}\" --download-archive \"{HistoryPath + "\\" + AccountToScrape + ".history"}\" --write-info-json --write-playlist-metafiles -o \"{OutputNameFormat}\" \"https://www.tiktok.com/@{AccountToScrape}\"";
            /*if (MaxItemsToScrape != 0)
            {
                scrapeCommandBase += $" --maximum {MaxItemsToScrape}";
                logger.Debug("Adding max items to scrape");
            }*/
            return scrapeCommandBase;
        }
        private void InvokeTTScraper(string ScrapeCommand)
        {
            logger.Info("Invoking scraper with command: " + ScrapeCommand);
            Process p = new Process();
            p.StartInfo.Arguments = ScrapeCommand;
            p.StartInfo.WorkingDirectory = ytdlpPath;
            p.StartInfo.FileName = ytdlpPath + "\\" + "yt-dlp.exe";
            p.StartInfo.CreateNoWindow = false;
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.RedirectStandardOutput = true;
            p.Start();
            logger.Debug("Waiting for scraping to complete");

            string output = p.StandardOutput.ReadToEnd();
            string error = p.StandardError.ReadToEnd();
            p.WaitForExit();
            if (!String.IsNullOrEmpty(output))
                logger.Debug(output);
            if (!String.IsNullOrEmpty(error))
                logger.Error(error);
        }
    }
}
