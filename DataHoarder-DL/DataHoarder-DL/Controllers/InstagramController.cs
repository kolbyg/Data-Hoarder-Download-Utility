using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;
using DataHoarder_DL.Models.Instagram;
using System.Globalization;
using NLog;
using System.Net;

namespace DataHoarder_DL.Controllers
{
    public class InstagramController
    {
        static string cookieJar = Globals.Settings.RootDownloadPath + "\\ig.cookie";
        string AuthUsername = "";
        string AuthPass = "";
        string DLDir = Environment.CurrentDirectory;
        string TimestampPath;// = Environment.CurrentDirectory + "\\timestamps";
        string MetadataPath;// = Environment.CurrentDirectory + "\\metadata";
        string MediaPath;// = Environment.CurrentDirectory + "\\media";
        string CachePath;// = Environment.CurrentDirectory + "\\IGCache";
        string IGBinPath = Globals.BinDir + "\\instagram-scraper";
        bool Overwrite = false;
        static Logger logger = LogManager.GetCurrentClassLogger();
        public InstagramController()
        {
            AuthUsername = Globals.Settings.InstagramSettings.IGUsername;
            AuthPass = Globals.Settings.InstagramSettings.IGPass;
        }
        private string CombineUserJsonData(string username, string[] paths)
        {
            logger.Debug("Begin combining json data");
            //Load all jsons into a list
            List<IGData> IGDataList = new List<IGData>();
            foreach (string path in paths)
            {
                logger.Debug($"Adding {path}");
                IGDataList.Add(ParseIGData(path));
            }
            //combine into a single IGData object
            logger.Debug("Preparing combined IGData object");
            IGData combinedData = new IGData();
            combinedData.GraphImages = new List<GraphImage>();
            combinedData.GraphStories = new List<GraphStory>();
            foreach(IGData _data in IGDataList)
            {
                if (_data.GraphImages != null)
                {
                    foreach (GraphImage _image in _data.GraphImages)
                    {
                        combinedData.GraphImages.Add(_image);
                    }
                }
                if (_data.GraphStories != null)
                {
                    foreach (GraphStory _story in _data.GraphStories)
                    {
                        combinedData.GraphStories.Add(_story);
                    }
                }
                if(combinedData.GraphProfileInfo == null)
                {
                    combinedData.GraphProfileInfo = _data.GraphProfileInfo;
                }
            }
            logger.Debug("Combined object created, removing duplicates...");
            IGData noDupes = new IGData
            {
                GraphImages = combinedData.GraphImages.GroupBy(x => x.id).Select(group => group.First()).ToList(),
                GraphStories = combinedData.GraphStories.GroupBy(x => x.id).Select(group => group.First()).ToList(),
                GraphProfileInfo = combinedData.GraphProfileInfo
            };
            string combinedpath = $"{MetadataPath}\\_working.json";
            logger.Debug($"Final list created, saving to {combinedpath}");
            File.WriteAllText(combinedpath, SerializeIGData(noDupes));
            return combinedpath;
        }
        public void BuildPaths(UnifiedScrapeItem ScrapeItem)
        {
            logger.Trace("Verifying and creating directories");

            if (!Directory.Exists(ScrapeItem.ItemPath)) { Directory.CreateDirectory(ScrapeItem.ItemPath); }
            MetadataPath = ScrapeItem.ItemPath + "\\metadata";
            if (!Directory.Exists(MetadataPath)) { Directory.CreateDirectory(MetadataPath); }
            TimestampPath = ScrapeItem.ItemPath + "\\timestamps";
            if (!Directory.Exists(TimestampPath)) { Directory.CreateDirectory(TimestampPath); }
            MediaPath = ScrapeItem.ItemPath + "\\media";
            if (!Directory.Exists(MediaPath)) { Directory.CreateDirectory(MediaPath); }
            CachePath = ScrapeItem.ItemPath + "\\cache";
            if (!Directory.Exists(CachePath)) { Directory.CreateDirectory(CachePath); }
        }
        public async Task<bool> FetchData(UnifiedQueueItem QueueItem)
        {
            try
            {
                logger.Info($"Begin fetching data for {QueueItem.URI} with a maximum of {QueueItem.MaxToScrape}");
                UnifiedScrapeItem ScrapeItem = Globals.Settings.ScrapeItems.Find(x => x.Id == QueueItem.ItemId);
                BuildPaths(ScrapeItem);
                QueueItem.IsScraping = true;
                ScrapeAllData(QueueItem.URI, QueueItem.MaxToScrape);
                Parse(QueueItem.URI);
                await ScrapeItem.Validate();
                //await ScrapeItem.Validate();
                //TODO download of missing items using web request

                ScrapeItem.LastScraped = DateTime.Now;
                QueueItem.IsScraping = false;
                return true;
            }
            catch(Exception ex)
            {
                logger.Error(ex.ToString());
                return false;
            }

        }
        private void DownloadMissing(List<IGData> MissingData)
        {
            /**using (var client = new WebClient)
            {
                foreach (IGData data in MissingData)
                {
                    foreach(GraphImage image in data.GraphImages)
                    {
                        client.DownloadFile(image.)
                    }
                    foreach (GraphStory story in data.GraphStories)
                    {

                    }
                }
            }*/
        }
        public bool Parse(string username)
        {
            logger.Info("Begin processing cached data");
            ProcessCache(username);
            return false;
        }
        /*private string GetFullName(IGData Data)
        { TODO Code block deactivated for now, will reuse for the browser one day
            logger.Debug("Begin retrieving full_name from GraphProfileInfo");
            TextInfo ti = new CultureInfo("en-US", false).TextInfo;
            string name = ti.ToTitleCase(Data.GraphProfileInfo.info.full_name.ToLower());
            logger.Debug($"Name retrieved as {name}, parsing invalid characters");
            name = name.Replace("'", "");
            logger.Debug($"Final name is {name}, returning...");
            return name;
        }*/
        private void ProcessCache(string username)
        {
            string CachedMetadata = $"{CachePath}\\{username}.json";
            logger.Debug("Begin processing cache from "+ CachedMetadata);

            //Process Directory Naming
            IGData tempdata = ParseIGData(CachedMetadata);
            //UpdatePaths(tempdata, true);
            string UserMediaPath = MediaPath;
            string UserMetadataPath = MetadataPath;

            //Process Media
            if (!Directory.Exists(UserMediaPath)) { Directory.CreateDirectory(UserMediaPath); }
            logger.Debug("Begin processing media");
            //Process Images
            IGData queue = ParseIGData(CachedMetadata);
            if (queue.GraphImages != null)
            {
                logger.Debug("GraphImages is not null, processing");
                if (!Directory.Exists(UserMediaPath + "\\images")) { Directory.CreateDirectory(UserMediaPath + "\\images"); }
                foreach (GraphImage image in queue.GraphImages)
                {
                    foreach (string url in image.urls)
                    {
                        string fileName = URLtoName(url);
                        DateTimeOffset dto = DateTimeOffset.FromUnixTimeSeconds(image.taken_at_timestamp);
                        if (File.Exists(CachePath + "\\" + fileName))
                        {
                            if (!File.Exists(UserMediaPath + "\\images\\" + dto.ToString("yyyyMMdd") + "-" + fileName) || Overwrite)
                                File.Move(CachePath + "\\" + fileName, UserMediaPath + "\\images\\" + dto.ToString("yyyyMMdd") + "-" + fileName, Overwrite);
                           
                            if (!Overwrite && File.Exists(CachePath + "\\" + fileName))
                                File.Delete(CachePath + "\\" + fileName);
                        }
                    }
                }
            }

            //Process Stories
            if (queue.GraphStories != null)
            {
                if (!Directory.Exists(UserMediaPath + "\\stories")) { Directory.CreateDirectory(UserMediaPath + "\\stories"); }
                foreach (GraphStory story in queue.GraphStories)
                {
                    foreach (string url in story.urls)
                    {
                        string fileName = URLtoName(url);
                        DateTimeOffset dto = DateTimeOffset.FromUnixTimeSeconds(story.taken_at_timestamp);
                        if (File.Exists(CachePath + "\\" + fileName))
                        {
                            if (!File.Exists(UserMediaPath + "\\stories\\" + dto.ToString("yyyyMMdd") + "-" + fileName) || Overwrite)
                                File.Move(CachePath + "\\" + fileName, UserMediaPath + "\\stories\\" + dto.ToString("yyyyMMdd") + "-" + fileName, Overwrite);

                            if (!Overwrite && File.Exists(CachePath + "\\" + fileName))
                                File.Delete(CachePath + "\\" + fileName);
                        }
                    }
                }
            }

            //Process Profile Pic
            if (queue.GraphProfileInfo != null)
            {
                if (!Directory.Exists(UserMediaPath + "\\profilepics")) { Directory.CreateDirectory(UserMediaPath + "\\profilepics"); }

                string fileName = URLtoName(queue.GraphProfileInfo.info.profile_pic_url);
                if (File.Exists(CachePath + "\\" + fileName))
                {
                    if (!File.Exists(UserMediaPath + "\\profilepics\\" + fileName) || Overwrite)
                        File.Move(CachePath + "\\" + fileName, UserMediaPath + "\\profilepics\\" + fileName, Overwrite);

                    if (!Overwrite && File.Exists(CachePath + "\\" + fileName))
                        File.Delete(CachePath + "\\" + fileName);
                }
            }

            //Process Metadata
            if (!Directory.Exists(UserMetadataPath)) { Directory.CreateDirectory(UserMetadataPath); }
            string ArchivePath = UserMetadataPath + "\\archive";
            if (!Directory.Exists(ArchivePath)) { Directory.CreateDirectory(ArchivePath); }

            if (File.Exists(CachedMetadata))
                File.Move(CachedMetadata, UserMetadataPath + "\\import.json");

            CombineUserJsonData(username, Directory.GetFiles(UserMetadataPath));

            //Archive Metadata
            foreach(string file in Directory.GetFiles(UserMetadataPath))
            {
                if (file.Substring(file.LastIndexOf('\\')+1) == "_working.json") continue;
                string filename = file.Substring(file.LastIndexOf('\\')+1);
                string destFilepath = ArchivePath + "\\" + DateTime.Now.ToString("yyyyMMddHHmmss") + "-" + filename;
                File.Move(file, destFilepath);
            }

            //Delete Cache Dir
            if (Directory.GetFiles(CachePath).Length == 0 && Directory.GetDirectories(CachePath).Length == 0)
            {
                //Directory.Delete(CachePath, false);
            }

        }
        public bool ScrapeAllData(string username, int MaxItemsToScrape)
        {
            logger.Info($"Begin data scraping for {username}, maximum {MaxItemsToScrape} items");
            string scrapeCommand = BuildScrapeCommand(username, AuthUsername, AuthPass, CachePath, TimestampPath, true, true, false, MaxItemsToScrape);
            InvokeIGScraper(scrapeCommand);
            return false;
        }
        private string BuildScrapeCommand(string AccountToScrape, string IGUsername, string IGPassword, string DownloadPath, string TimestampPath, bool IncludeMediaMetadata, bool IncludeProfileMetadata, bool WriteTimestampFile, int MaxItemsToScrape)
        {
            string namingTemplate = "{urlname}";
            logger.Debug("Building scrape command");
            logger.Debug("AccountToScrape: " + AccountToScrape);
            logger.Debug("IGUsername: " + IGUsername);
            logger.Debug("IGPassword: " + IGPassword);
            logger.Debug("DownloadPath: " + DownloadPath);
            logger.Debug("TimestampPath: " + TimestampPath);
            logger.Debug("IncludeMediaMetadata: " + IncludeMediaMetadata);
            logger.Debug("IncludeProfileMetadata: " + IncludeProfileMetadata);
            logger.Debug("WriteTimestampFile: " + WriteTimestampFile);
            logger.Debug("MaxItemsToScrape: " + MaxItemsToScrape);
            logger.Debug("namingTemplate: " + namingTemplate);
            logger.Debug("CookieJar: " + cookieJar);
            string scrapeCommandBase = $"app.py {AccountToScrape} -u {IGUsername} -p {IGPassword} --destination \"{DownloadPath}\" --cookiejar \"{cookieJar}\" --template \"{namingTemplate}\"";
            if (IncludeMediaMetadata) {
                scrapeCommandBase += " --media-metadata";
                logger.Debug("Adding media metadata");
            }
            if (IncludeProfileMetadata) {
                scrapeCommandBase += " --profile-metadata";
                logger.Debug("Adding profile metadata");
            }
            if(MaxItemsToScrape != 0)
            {
                scrapeCommandBase += $" --maximum {MaxItemsToScrape}";
                logger.Debug("Adding max items to scrape");
            }
            if (WriteTimestampFile)
            {
                scrapeCommandBase += $" --latest-stamps \"{TimestampPath}\\{AccountToScrape}\"";
                logger.Debug("Adding latest stamps");
            }
            return scrapeCommandBase;
        }
        private void InvokeIGScraper(string ScrapeCommand)
        {
            logger.Info("Invoking scraper with command: " + ScrapeCommand);
            Process p = new Process();
            p.StartInfo.Arguments = ScrapeCommand;
            p.StartInfo.WorkingDirectory = IGBinPath;
            p.StartInfo.FileName = "python.exe";
            p.StartInfo.CreateNoWindow = false;
            p.StartInfo.UseShellExecute = false;
            //p.StartInfo.RedirectStandardError = false;
            //p.StartInfo.RedirectStandardOutput = false;
            p.Start();
            logger.Debug("Waiting for scraping to complete");
            //string output = p.StandardOutput.ReadToEnd();
            //string error = p.StandardError.ReadToEnd();
            p.WaitForExit();
            /*if (!String.IsNullOrEmpty(output))
                logger.Debug(output);
            if (!String.IsNullOrEmpty(error))
                logger.Error(error);*/
        }
        /*private void UpdatePaths(IGData Data, bool CreateDirectories = false)
        {
            logger.Debug($"Updating paths, CreateDirectories is {CreateDirectories}, DLDir is {DLDir}");
            PersonRootDir = DLDir + "\\" + Data.GraphProfileInfo.username;
            logger.Debug($"Setting PersonRootDir to {PersonRootDir}");
            if (CreateDirectories)
                if (!Directory.Exists(PersonRootDir)) Directory.CreateDirectory(PersonRootDir);
            //PersonRootDir += "\\IG";
            if (CreateDirectories)
                if (!Directory.Exists(PersonRootDir)) Directory.CreateDirectory(PersonRootDir);
            TimestampPath = PersonRootDir + "\\timestamps";
            MetadataPath = PersonRootDir + "\\metadata";
            MediaPath = PersonRootDir + "\\media";
            logger.Debug($"Directories updated, PersonRootDir is now {PersonRootDir}");
        }*/
        internal static string URLtoName(string URL, bool IncludeDate = false)
        {
            logger.Trace($"Translating URL to name original is {URL}");
            string filename = URL.Remove(URL.IndexOf('?'));
            filename = filename.Substring(filename.LastIndexOf("/") + 1);
            logger.Trace($"Resulting filename is {filename}");
            return filename;
        }
        public static  IGData ParseIGData(string path)
        {
            string jsondata = File.ReadAllText(path);
            return FileOperations.Json.ParseMetadata(jsondata);
        }
        public static  string SerializeIGData(IGData data)
        {
            return FileOperations.Json.SerializeMetadata(data);
        }
    }
}
