using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using NLog;
using DataHoarder_DL.Models.Instagram;

namespace DataHoarder_DL.Controllers
{
    internal class ValidationController
    {
        static Logger logger = LogManager.GetCurrentClassLogger();
        internal async static Task ValidateAllObjects()
        {
            //TODO, move this elsewhere
            foreach (UnifiedScrapeItem scrapeItem in Globals.Settings.ScrapeItems)
            {
                await ValidateObject(scrapeItem);
            }
        }
        internal async static Task ValidateObject(UnifiedScrapeItem ScrapeItem)
        {
            switch (ScrapeItem.ScrapeType)
            {
                case ScrapeType.Instagram:
                    IGData iGData = InstagramController.ParseIGData(ScrapeItem.ItemPath + "\\metadata\\_working.json");
                    logger.Info("Currently processing profile: " + iGData.GraphProfileInfo.username);
                    string UserMediaPath = ScrapeItem.ItemPath + "\\media";//GetUserMediaPath(iGData.GraphProfileInfo.username);
                    IGData missingData = new IGData()
                    {
                        GraphImages = new List<GraphImage>(),
                        GraphStories = new List<GraphStory>()
                    };
                    //UpdatePaths(iGData);
                    if (iGData.GraphImages != null)
                    {
                        logger.Trace("GraphImages is not null, parsing...");
                        foreach (GraphImage image in iGData.GraphImages)
                        {
                            logger.Trace("Working on Image ID: " + image.id);
                            foreach (string url in image.urls)
                            {
                                logger.Trace($"Working on Image URL {url}");
                                string fileName = InstagramController.URLtoName(url);
                                logger.Trace("Parsed unix timestamp as " + image.taken_at_timestamp);
                                DateTimeOffset dto = DateTimeOffset.FromUnixTimeSeconds(image.taken_at_timestamp);
                                if (!File.Exists(UserMediaPath + "\\images\\" + dto.ToString("yyyyMMdd") + "-" + fileName))
                                {
                                    logger.Warn("URL from Image ID " + image.id + " is missing, adding to list.");
                                    missingData.GraphImages.Add(image);
                                }
                                else
                                {
                                    logger.Trace("Found image URL, skipping...");
                                }
                            }
                        }
                    }
                    if (iGData.GraphStories != null)
                    {
                        logger.Trace("GraphStories is not null, parsing...");
                        foreach (GraphStory story in iGData.GraphStories)
                        {
                            logger.Trace("Working on Story ID: " + story.id);
                            foreach (string url in story.urls)
                            {
                                logger.Trace($"Working on Story URL {url}");
                                string fileName = InstagramController.URLtoName(url);
                                DateTimeOffset dto = DateTimeOffset.FromUnixTimeSeconds(story.taken_at_timestamp);
                                if (!File.Exists(UserMediaPath + "\\stories\\" + dto.ToString("yyyyMMdd") + "-" + fileName))
                                {
                                    logger.Warn("URL from Story ID " + story.id + " is missing, adding to list.");
                                    missingData.GraphStories.Add(story);
                                }
                                else
                                {
                                    logger.Trace("Found story URL, skipping...");
                                }
                            }
                        }
                    }
                    if (iGData.GraphProfileInfo != null)
                    {
                        logger.Trace("GraphProfileInfo is not null, parsing...");
                        string fileName = InstagramController.URLtoName(iGData.GraphProfileInfo.info.profile_pic_url);
                        if (!File.Exists(UserMediaPath + "\\profilepics\\" + fileName))
                        {
                            logger.Warn("Profile picture is missing, adding to list.");
                            missingData.GraphProfileInfo = iGData.GraphProfileInfo;
                        }
                        else
                        {
                            logger.Trace("Found profile pic, skipping...");
                        }
                    }
                    if (missingData.GraphImages.Count > 0 || missingData.GraphStories.Count > 0 || missingData.GraphProfileInfo != null)
                    {
                        logger.Info("Missing files were detected.");
                        if (missingData.GraphProfileInfo == null)
                        {
                            logger.Debug("Adding profile info");
                            missingData.GraphProfileInfo = iGData.GraphProfileInfo;
                        }
                        //missingDataList.Add(missingData);
                        //TODO do something with missing data
                    }
                    else
                    {
                        logger.Debug("Validation complete, no missing files found");
                        UnifiedScrapeItem user = Globals.Settings.ScrapeItems.Find(x => (x.ShortName == iGData.GraphProfileInfo.username) && (x.ScrapeType == ScrapeType.Instagram));
                        if (user != null)
                            user.LastValidated = DateTime.Now;
                    }
                    break;
                case ScrapeType.TikTok:
                    string AccountName = ScrapeItem.ShortName; // = file.Remove(file.LastIndexOf('.')).Substring(file.LastIndexOf('\\') + 1);
                    logger.Debug("Working on " + AccountName);
                    string UserHistoryFile = ScrapeItem.ItemPath + "\\history\\" + AccountName + ".history";
                    if (!File.Exists(UserHistoryFile))
                        break;
                    List<string> FileNames = Directory.GetFiles(ScrapeItem.ItemPath + "\\media", "*.*", SearchOption.AllDirectories).ToList();
                    List<string> FileIDs = new List<string>();
                    List<string> UserMissingIDs = new List<string>();
                    List<string> HistoryIDs = new List<string>();
                    //Parse filename list to trim off the non ID part
                    foreach (string filename in FileNames)
                    {
                        logger.Trace("Parsing filename: " + filename);
                        string fileID;
                        fileID = filename.Remove(filename.LastIndexOf(']'));
                        fileID = fileID.Substring(fileID.LastIndexOf('[') + 1);
                        FileIDs.Add(fileID);
                        logger.Trace("Resulting name: " + fileID);
                    }
                    //Parse the history to get IDs
                    List<string> lines = File.ReadAllLines(UserHistoryFile).ToList();
                    foreach (string line in lines)
                    {
                        logger.Trace("Reading ID from history: " + line);
                        HistoryIDs.Add(line.Substring(line.LastIndexOf(' ') + 1));
                    }
                    logger.Trace("History total lines: " + HistoryIDs.Count);
                    logger.Trace("Files total lines: " + FileIDs.Count);
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
                        logger.Trace("UserMissingIDs is not null, adding to MissingIDs");
                        //MissingIDs.AddRange(UserMissingIDs);
                        //TODO do something with the missing items, download them?DownloadMissing(ToDownload);
                    }
                    else
                    {
                        logger.Trace("Nothing missing, updating validation date");

                        ScrapeItem.LastValidated = DateTime.Now;
                    }
                    logger.Info("Data validation has completed.");
                    /* if (MissingIDs != null && MissingIDs.Count > 0)
                     {
                         logger.Warn("Some files failed to validate and will be downloaded.");
                         //TODO do something with the missing items, download them?DownloadMissing(ToDownload);
                         return false;
                     }*/


                    break;
            }
            ScrapeItem.TotalSize = await GetDirectorySize(ScrapeItem.ItemPath + "\\media");
            ScrapeItem.NumFiles = await GetNumFiles(ScrapeItem.ItemPath + "\\media");
            Globals.Settings.Save();
            //ScrapeItem.LastValidated = DateTime.Now;
        }
        private async static Task<long> GetDirectorySize(string Path)
        {
            logger.Debug("Getting directory size of " + Path);
            if (String.IsNullOrEmpty(Path) || !Directory.Exists(Path))
            {
                logger.Debug(Path + " does not exist, returning 0");
                return 0;
            }
            DirectoryInfo dirInfo = new DirectoryInfo(Path);
            long dirSize = await Task.Run(() => dirInfo.EnumerateFiles("*", SearchOption.AllDirectories).Sum(file => file.Length));
            logger.Debug(Path + " contains " + dirSize + " bytes");
            return dirSize;
        }
        private async static Task<int> GetNumFiles(string Path)
        {
            logger.Debug("Getting file count of " + Path);
            if (String.IsNullOrEmpty(Path) || !Directory.Exists(Path))
            {
                logger.Debug(Path + " does not exist, returning 0");
                return 0;
            }
            string[] files = await Task.Run(() =>Directory.GetFiles(Path, "*.*", SearchOption.AllDirectories));
            logger.Debug(Path + " contains " + files.Length + " files");
            return files.Length;
        }
    }
}
