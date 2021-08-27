using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;
using DataHoarder_DL.Models.Instagram;

namespace DataHoarder_DL.Controllers
{
    class InstagramController
    {
        string AuthUsername = "";
        string AuthPass = "";
        string TimestampPath = Environment.CurrentDirectory + "\\timestamps";
        string MetadataPath = Environment.CurrentDirectory + "\\metadata";
        string MediaPath = Environment.CurrentDirectory + "\\media";
        string Cache = Environment.CurrentDirectory + "\\IGCache";
        string IGBinPath = Globals.BinDir + "\\instagram-scraper";
        public InstagramController(string IGUser, string IGPass)
        {
            AuthUsername = IGUser;
            AuthPass = IGPass;
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
            }
            IGData noDupes = new IGData
            {
                GraphImages = combinedData.GraphImages.GroupBy(x => x.id).Select(group => group.First()).ToList(),
                GraphStories = combinedData.GraphStories.GroupBy(x => x.id).Select(group => group.First()).ToList()
            };
            string combinedpath = $"{MetadataPath}\\{username}\\_working.json";
            File.WriteAllText(combinedpath, SerializeIGData(noDupes));
            return combinedpath;
        }
        public bool FetchData(string username)
        {
            //IGData IGData = ParseExistingData(username);
            //IGData ToDownload;
           // if (IGData != null)
            //    ToDownload = ValidateDownloads(username, IGData);
            //do download of missing items using web request
            //ScrapeMetadata(username);
            ScrapeAllData(username);
            ProcessCache(username);

            return false;

        }
        private void ProcessCache(string username)
        {
            //Process Media
            string DestinationPath = MediaPath + "\\" + username;
            if (!Directory.Exists(DestinationPath)) { Directory.CreateDirectory(DestinationPath); }

            string CachedMetadata = $"{Cache}\\{username}.json";

            IGData queue = ParseIGData(CachedMetadata);
            if (queue.GraphImages != null)
            {
                if (!Directory.Exists(DestinationPath + "\\images")) { Directory.CreateDirectory(DestinationPath + "\\images"); }
                foreach (GraphImage image in queue.GraphImages)
                {
                    foreach (string url in image.urls)
                    {
                        string fileName = URLtoName(url);
                        DateTimeOffset dto = DateTimeOffset.FromUnixTimeSeconds(image.taken_at_timestamp);
                        if (File.Exists(Cache + "\\" + fileName))
                        {
                            File.Move(Cache + "\\" + fileName, DestinationPath + "\\images\\" + dto.ToString("yyyyMMdd") + "-" + fileName);
                        }
                    }
                }
            }
            if (queue.GraphStories != null)
            {
                if (!Directory.Exists(DestinationPath + "\\stories")) { Directory.CreateDirectory(DestinationPath + "\\stories"); }
                foreach (GraphStory story in queue.GraphStories)
                {
                    foreach (string url in story.urls)
                    {
                        string fileName = URLtoName(url);
                        DateTimeOffset dto = DateTimeOffset.FromUnixTimeSeconds(story.taken_at_timestamp);
                        if (File.Exists(Cache + "\\" + fileName))
                        {
                            File.Move(Cache + "\\" + fileName, DestinationPath + "\\stories\\" + dto.ToString("yyyyMMdd") + "-" + fileName);
                        }
                    }
                }
            }
            //Process Metadata
            string MetadataDestination = MetadataPath + "\\" + username;
            if (!Directory.Exists(MetadataDestination)) { Directory.CreateDirectory(MetadataDestination); }

            if (File.Exists(CachedMetadata))
                File.Move(CachedMetadata, MetadataDestination + "\\import.json");

            CombineUserJsonData(username, Directory.GetFiles(MetadataDestination));

        }
        public bool ScrapeMetadata(string username)
        {
            return false;
        }
        public bool ScrapeAllData(string username)
        {
            InvokeIGScraper(username, AuthUsername, AuthPass, Cache, TimestampPath);
            return false;
        }
        private void InvokeIGScraper(string AccountToScrape, string IGUsername, string IGPassword, string DownloadPath, string TimestampPath, int MaxItemsToScrape = 50)
        {
            Process p = new Process();
            string namingTemplate = "{urlname}";
            string scrapeCommandBase = $"app.py {AccountToScrape} -u {IGUsername} -p {IGPassword} --media-metadata --destination \"{DownloadPath}\" --template {namingTemplate} --profile-metadata --maximum {MaxItemsToScrape}";// --latest-stamps \"{TimestampPath}\\{AccountToScrape}\"";
            p.StartInfo.Arguments = scrapeCommandBase;
            p.StartInfo.WorkingDirectory = IGBinPath;
            p.StartInfo.FileName = "python.exe";
            p.StartInfo.CreateNoWindow = false;
            p.StartInfo.RedirectStandardError = false;
            p.StartInfo.RedirectStandardOutput = false;
            p.Start();
            p.WaitForExit();
        }
        public Models.Instagram.IGData ValidateDownloads(string username, Models.Instagram.IGData data)
        {
            Models.Instagram.IGData toDownload = new Models.Instagram.IGData()
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
            return toDownload;
        }
        private string URLtoName(string URL, bool IncludeDate = false)
        {
            string filename = URL.Remove(URL.IndexOf('?'));
            filename = filename.Substring(filename.LastIndexOf("/") + 1);
            return filename;
        }
        public Models.Instagram.IGData ParseExistingData(string username)
        {
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
            }
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
