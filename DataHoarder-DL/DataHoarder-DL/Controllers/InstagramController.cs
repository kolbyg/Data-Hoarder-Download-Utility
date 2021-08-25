using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

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
        public InstagramController(string IGUser, string IGPass)
        {
            AuthUsername = IGUser;
            AuthPass = IGPass;
        }
        private string CombineUserJsonData(string username, string[] paths)
        {
            //Load all jsons into a list
            List<Models.Instagram.IGData> IGDataList = new List<Models.Instagram.IGData>();
            foreach(string path in paths)
                IGDataList.Add(ParseIGData(path));
            //combine into a single IGData object
            Models.Instagram.IGData combinedData = new Models.Instagram.IGData();
            combinedData.GraphImages = new List<Models.Instagram.GraphImage>();
            combinedData.GraphStories = new List<Models.Instagram.GraphStory>();
            foreach(Models.Instagram.IGData _data in IGDataList)
            {
                foreach(Models.Instagram.GraphImage _image in _data.GraphImages)
                {
                    combinedData.GraphImages.Add(_image);
                }
                foreach(Models.Instagram.GraphStory _story in _data.GraphStories)
                {
                    combinedData.GraphStories.Add(_story);
                }
            }
            Models.Instagram.IGData noDupes = new Models.Instagram.IGData
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
            var IGData = ParseExistingData(username);
            var ToDownload = ValidateDownloads(username, IGData);
            //do download of missing items using web request
            ScrapeMetadata(username);
            ScrapeAllData(username);

            return false;

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
        private void InvokeIGScraper(string AccountToScrape, string IGUsername, string IGPassword, string DownloadPath, string TimestampPath)
        {
            Process pr = new Process();
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
                mediaFiles[x] = mediaFiles[x].Substring(mediaFiles[x].IndexOf('-') + 1);
            }
            int urls = 0;
            //check images
            foreach(Models.Instagram.GraphImage image in data.GraphImages)
            {
                foreach(string url in image.urls)
                {
                    string filename = url.Remove(url.IndexOf('?'));
                    filename = filename.Substring(filename.LastIndexOf("/")+1);
                    if (!mediaFiles.Contains(filename))
                        toDownload.GraphImages.Add(image);
                    urls++;
                }
            }
            foreach(Models.Instagram.GraphStory story in data.GraphStories)
            {
                foreach (string url in story.urls)
                {
                    string filename = url.Remove(url.IndexOf('?'));
                    filename = filename.Substring(filename.LastIndexOf("/") + 1);
                    if (!mediaFiles.Contains(filename))
                        toDownload.GraphStories.Add(story);
                    urls++;
                }
            }
            return toDownload;
        }
        public Models.Instagram.IGData ParseExistingData(string username)
        {
            string[] _jsonfiles = Directory.GetFiles($"{MetadataPath}\\{username}");
            if (_jsonfiles.Length == 0)
                return null; //todo
            else if (_jsonfiles.Length > 1)
                return ParseIGData(CombineUserJsonData(username, _jsonfiles));
            else
                return ParseIGData(_jsonfiles[0]);
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
