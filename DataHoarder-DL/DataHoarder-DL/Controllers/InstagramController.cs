using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;
using DataHoarder_DL.Models.Instagram;
using System.Globalization;

namespace DataHoarder_DL.Controllers
{
    class InstagramController
    {
        string AuthUsername = "";
        string AuthPass = "";
        string DLDir = Environment.CurrentDirectory;
        string TimestampPath = Environment.CurrentDirectory + "\\timestamps";
        string MetadataPath = Environment.CurrentDirectory + "\\metadata";
        string MediaPath = Environment.CurrentDirectory + "\\media";
        string Cache = Environment.CurrentDirectory + "\\IGCache";
        string IGBinPath = Globals.BinDir + "\\instagram-scraper";
        string PersonRootDir = Environment.CurrentDirectory + "\\UNKNOWN";
        bool Overwrite = false;
        public InstagramController(string IGUser, string IGPass, string RootDLDir)
        {
            AuthUsername = IGUser;
            AuthPass = IGPass;
            DLDir = RootDLDir;
            if(!Directory.Exists(DLDir)) { Directory.CreateDirectory(DLDir); }
            TimestampPath = DLDir + "\\timestamps";
            MetadataPath = DLDir + "\\metadata";
            MediaPath = DLDir + "\\media";
            Cache = DLDir + "\\IGCache";
            if (!Directory.Exists(Cache)) { Directory.CreateDirectory(Cache); }
        }
        private string CombineUserJsonData(string username, string[] paths)
        {
            //Load all jsons into a list
            List<IGData> IGDataList = new List<IGData>();
            foreach(string path in paths)
                IGDataList.Add(ParseIGData(path));
            //combine into a single IGData object
            IGData combinedData = new IGData();
            combinedData.GraphImages = new List<GraphImage>();
            combinedData.GraphStories = new List<GraphStory>();
            foreach(IGData _data in IGDataList)
            {
                foreach(GraphImage _image in _data.GraphImages)
                {
                    combinedData.GraphImages.Add(_image);
                }
                foreach(GraphStory _story in _data.GraphStories)
                {
                    combinedData.GraphStories.Add(_story);
                }
                if(combinedData.GraphProfileInfo == null)
                {
                    combinedData.GraphProfileInfo = _data.GraphProfileInfo;
                }
            }
            IGData noDupes = new IGData
            {
                GraphImages = combinedData.GraphImages.GroupBy(x => x.id).Select(group => group.First()).ToList(),
                GraphStories = combinedData.GraphStories.GroupBy(x => x.id).Select(group => group.First()).ToList(),
                GraphProfileInfo = combinedData.GraphProfileInfo
            };
            string combinedpath = $"{MetadataPath}\\_working.json";
            File.WriteAllText(combinedpath, SerializeIGData(noDupes));
            return combinedpath;
        }
        public bool FetchData(string username, int MaxToScrape = 50)
        {
            Validate();
            //TODO download of missing items using web request
            //ScrapeMetadata(username);
            ScrapeAllData(username, MaxToScrape);
            Parse(username);

            return false;

        }
        public bool Validate()
        {
            List<IGData> WorkingData = ParseExistingData();
            List<IGData> ToDownload;
            if (WorkingData != null)
                ToDownload = ValidateDownloads(WorkingData);
            return false;
        }
        public bool Parse(string username)
        {
            ProcessCache(username);
            return false;
        }
        private string GetFullName(IGData Data)
        {
            TextInfo ti = new CultureInfo("en-US", false).TextInfo;
            string name = ti.ToTitleCase(Data.GraphProfileInfo.info.full_name.ToLower());
            name = name.Replace("'", "");
            return name;
        }
        private void ProcessCache(string username)
        {
            string CachedMetadata = $"{Cache}\\{username}.json";

            //Process Directory Naming
            IGData tempdata = ParseIGData(CachedMetadata);
            UpdatePaths(tempdata, true);

            //Process Media
            if (!Directory.Exists(MediaPath)) { Directory.CreateDirectory(MediaPath); }

            //Process Images
            IGData queue = ParseIGData(CachedMetadata);
            if (queue.GraphImages != null)
            {
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
            foreach(string file in Directory.GetFiles(MetadataPath))
            {
                if (file.Substring(file.LastIndexOf('\\')+1) == "_working.json") continue;
                string filename = file.Substring(file.LastIndexOf('\\')+1);
                string destFilepath = ArchivePath + "\\" + DateTime.Now.ToString("yyyyMMddHHmmss") + "-" + filename;
                File.Move(file, destFilepath);
            }

            //Delete Cache Dir
            if (Directory.GetFiles(Cache).Length == 0 && Directory.GetDirectories(Cache).Length == 0)
            {
                Directory.Delete(Cache, false);
            }

        }
        public bool ScrapeMetadata(string username)
        {
            return false;
        }
        public bool ScrapeAllData(string username, int MaxItemsToScrape)
        {
            string scrapeCommand = BuildScrapeCommand(username, AuthUsername, AuthPass, Cache, TimestampPath, true, true, false, MaxItemsToScrape);
            InvokeIGScraper(scrapeCommand);
            return false;
        }
        private string BuildScrapeCommand(string AccountToScrape, string IGUsername, string IGPassword, string DownloadPath, string TimestampPath, bool IncludeMediaMetadata, bool IncludeProfileMetadata, bool WriteTimestampFile, int MaxItemsToScrape)
        {
            string namingTemplate = "{urlname}";
            string scrapeCommandBase = $"app.py {AccountToScrape} -u {IGUsername} -p {IGPassword} --destination \"{DownloadPath}\" --template {namingTemplate}";
            if (IncludeMediaMetadata) {
                scrapeCommandBase += " --media-metadata";
            }
            if (IncludeProfileMetadata) {
                scrapeCommandBase += " --profile-metadata";
                    }
            if(MaxItemsToScrape != 0)
            {
                scrapeCommandBase += $" --maximum {MaxItemsToScrape}";
            }
            if (WriteTimestampFile)
            {
                scrapeCommandBase += $" --latest-stamps \"{TimestampPath}\\{AccountToScrape}\"";
            }
            return scrapeCommandBase;
        }
        private void InvokeIGScraper(string ScrapeCommand)
        {
            Process p = new Process();
            p.StartInfo.Arguments = ScrapeCommand;
            p.StartInfo.WorkingDirectory = IGBinPath;
            p.StartInfo.FileName = "python.exe";
            p.StartInfo.CreateNoWindow = false;
            p.StartInfo.RedirectStandardError = false;
            p.StartInfo.RedirectStandardOutput = false;
            p.Start();
            p.WaitForExit();
        }
        private void UpdatePaths(IGData Data, bool CreateDirectories = false)
        {
            PersonRootDir = DLDir + "\\" + GetFullName(Data);
            if (CreateDirectories)
                if (!Directory.Exists(PersonRootDir)) Directory.CreateDirectory(PersonRootDir);
            PersonRootDir += "\\IG";
            if (CreateDirectories)
                if (!Directory.Exists(PersonRootDir)) Directory.CreateDirectory(PersonRootDir);
            TimestampPath = PersonRootDir + "\\timestamps";
            MetadataPath = PersonRootDir + "\\metadata";
            MediaPath = PersonRootDir + "\\media";
        }
        public List<IGData> ValidateDownloads(List<IGData> DataToValidate)
        {
            List<IGData> missingDataList = new List<IGData>();
            foreach (IGData curData in DataToValidate)
            {
                IGData missingData = new IGData()
                {
                    GraphImages = new List<GraphImage>(),
                    GraphStories = new List<GraphStory>()
                };
                UpdatePaths(curData);
                if (curData.GraphImages != null)
                {
                    foreach (GraphImage image in curData.GraphImages)
                    {
                        foreach (string url in image.urls)
                        {
                            string fileName = URLtoName(url);
                            DateTimeOffset dto = DateTimeOffset.FromUnixTimeSeconds(image.taken_at_timestamp);
                            if (!File.Exists(MediaPath + "\\images\\" + dto.ToString("yyyyMMdd") + "-" + fileName))
                                missingData.GraphImages.Add(image);
                        }
                    }
                }

                if (curData.GraphStories != null)
                {
                    foreach (GraphStory story in curData.GraphStories)
                    {
                        foreach (string url in story.urls)
                        {
                            string fileName = URLtoName(url);
                            DateTimeOffset dto = DateTimeOffset.FromUnixTimeSeconds(story.taken_at_timestamp);
                            if (!File.Exists(MediaPath + "\\stories\\" + dto.ToString("yyyyMMdd") + "-" + fileName))
                                missingData.GraphStories.Add(story);
                        }
                    }
                }
                if (curData.GraphProfileInfo != null)
                {

                    string fileName = URLtoName(curData.GraphProfileInfo.info.profile_pic_url);
                    if (!File.Exists(MediaPath + "\\profilepics\\" + fileName))
                        missingData.GraphProfileInfo = curData.GraphProfileInfo;
                }
                if(missingData.GraphImages.Count > 0 || missingData.GraphStories.Count > 0 || missingData.GraphProfileInfo != null)
                {
                    missingDataList.Add(missingData);
                }
            }
            return missingDataList;
            
            
            /**Models.Instagram.IGData toDownload = new Models.Instagram.IGData()
            {
                GraphImages = new List<Models.Instagram.GraphImage>(),
                GraphStories = new List<Models.Instagram.GraphStory>()
            };
            List<string> mediaFiles = Directory.GetFiles($"{MediaPath}\\{username}").ToList();
            for (int x = 0;  x < mediaFiles.Count; x++)
            {
                mediaFiles[x] = mediaFiles[x].Substring(mediaFiles[x].LastIndexOf('\\') + 1);
                //mediaFiles[x] = mediaFiles[x].Substring(mediaFiles[x].IndexOf('-') + 1);
            }
            int urls = 0;
            //check images
            foreach(Models.Instagram.GraphImage image in data.GraphImages)
            {
                foreach(string url in image.urls)
                {
                    string filename = URLtoName(url);
                    if (!mediaFiles.Contains(filename))
                        toDownload.GraphImages.Add(image);
                    urls++;
                }
            }
            foreach(Models.Instagram.GraphStory story in data.GraphStories)
            {
                foreach (string url in story.urls)
                {
                    string filename = URLtoName(url);
                    if (!mediaFiles.Contains(filename))
                        toDownload.GraphStories.Add(story);
                    urls++;
                }
            }
            return;*/
        }
        private string URLtoName(string URL, bool IncludeDate = false)
        {
            string filename = URL.Remove(URL.IndexOf('?'));
            filename = filename.Substring(filename.LastIndexOf("/") + 1);
            return filename;
        }
        public List<IGData> ParseExistingData()
        {
            List<IGData> WorkingData = new List<IGData>();
            string RelativeMetadataDir = "\\IG\\metadata\\_working.json";
            foreach (string directory in Directory.GetDirectories(DLDir))
            {
                IGData curData = ParseIGData(directory + RelativeMetadataDir);
                WorkingData.Add(curData);
            }
            /**
            string currentMetadataDirectory = $"{MetadataPath}\\{username}";
            string[] _jsonfiles;
            if (Directory.Exists(currentMetadataDirectory))
            {
                _jsonfiles = Directory.GetFiles(currentMetadataDirectory);
                if (_jsonfiles.Length == 0)
                    return null; //todo
                else if (_jsonfiles.Length > 1)
                    return ParseIGData(CombineUserJsonData(username, _jsonfiles));
                else
                    return ParseIGData(_jsonfiles[0]);
            }
            else
            {
                return null;
            }*/
            return WorkingData;
        }
        public Models.Instagram.IGData ParseIGData(string path)
        {
            string jsondata = File.ReadAllText(path);
            return FileOperations.Json.ParseMetadata(jsondata);
        }
        public string SerializeIGData(Models.Instagram.IGData data)
        {
            return FileOperations.Json.SerializeMetadata(data);
        }
    }
}
