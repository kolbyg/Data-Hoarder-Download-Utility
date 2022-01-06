using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;
using NLog;

namespace DataHoarder_DL.Controllers
{
    public enum YTScrapeType
    {
        Video,
        Channel,
        Playlist
    }
    public class YoutubeController
    {
        //string AuthUsername = "";
        //string AuthPass = "";
        string DLDir = Environment.CurrentDirectory;
        string MetadataPath;
        string HistoryPath;
        string HistoryFile = "yt.history";
        string MediaPath;
        string CachePath;
        string ytdlpPath = Globals.BinDir + "\\yt-dlp";
        string ffmpegPath = Globals.BinDir + "\\ffmpeg";
        bool Overwrite = false;
        Logger logger = LogManager.GetCurrentClassLogger();
        public YoutubeController()
        {
            DLDir = Globals.Settings.RootDownloadPath + "\\YT";
            if (!Directory.Exists(DLDir)) { Directory.CreateDirectory(DLDir); }
            //MetadataPath = DLDir + "\\metadata";
            //if (!Directory.Exists(MetadataPath)) { Directory.CreateDirectory(MetadataPath); }
            HistoryPath = DLDir + "\\history";
            if (!Directory.Exists(HistoryPath)) { Directory.CreateDirectory(HistoryPath); }
            //MediaPath = DLDir + "\\media";
            //if (!Directory.Exists(MediaPath)) { Directory.CreateDirectory(MediaPath); }
            CachePath = DLDir + "\\cache";
            if (!Directory.Exists(CachePath)) { Directory.CreateDirectory(CachePath); }
        }
        public bool FetchData(string username, YTScrapeType ScrapeType = YTScrapeType.Video)
        {
            logger.Info($"Begin fetching data for {username} with method: {ScrapeType}");
            //Validate();
            //TODO download of missing items using web request
            //ScrapeMetadata(username);
            ScrapeAllData(username, ScrapeType);
            //Parse(username);

            //Globals.Settings.TikTokSettings.FollowedUsers.Find(x => x.AccountName == username).LastScraped = DateTime.Now;
            return false;

        }
        public bool ScrapeAllData(string URL, YTScrapeType ScrapeType)
        {
            logger.Info($"Begin data scraping for {URL}, method: {ScrapeType}");
            string scrapeCommand = BuildScrapeCommand(URL, CachePath, ScrapeType);
            InvokeYTScraper(scrapeCommand);
            return false;
        }
        private string BuildScrapeCommand(string URL, string DownloadPath, YTScrapeType ScrapeType)
        {
            string OutputNameFormat = "[%(id)s].%(ext)s";
            logger.Debug("Building scrape command");
            logger.Debug("URL: " + URL);
            logger.Debug("DownloadPath: " + CachePath);
            logger.Debug("HistoryPath: " + HistoryPath);
            logger.Debug("Method: " + ScrapeType);
            logger.Debug("Output Name Format: " + OutputNameFormat);
            string scrapeCommandBase = "";
            switch (ScrapeType)
            {
                case YTScrapeType.Video:
                    scrapeCommandBase += $"-P \"{CachePath}\" -f bestvideo+bestaudio/best -ciw --ffmpeg-location \"{ffmpegPath}\" --download-archive \"{HistoryPath + "\\" + HistoryFile}\" --write-info-json --write-playlist-metafiles -o \"{OutputNameFormat}\" \"{URL}\"";
                    break;
                case YTScrapeType.Channel:
                    scrapeCommandBase += $"-P \"{CachePath}\" -f bestvideo+bestaudio/best -ciw --ffmpeg-location \"{ffmpegPath}\" --download-archive \"{HistoryPath + "\\" + HistoryFile}\" --write-info-json --write-playlist-metafiles -o \"{OutputNameFormat}\" \"{URL}\"";
                    break;
                case YTScrapeType.Playlist:
                    scrapeCommandBase += $"-P \"{CachePath}\" -f bestvideo+bestaudio/best -ciw --ffmpeg-location \"{ffmpegPath}\" --download-archive \"{HistoryPath + "\\" + HistoryFile}\" --write-info-json --write-playlist-metafiles -o \"{OutputNameFormat}\" --yes-playlist \"{URL}\"";
                    break;
            }
            
            return scrapeCommandBase;
        }
        private void InvokeYTScraper(string ScrapeCommand)
        {
            logger.Info("Invoking scraper with command: " + ScrapeCommand);
            Process p = new Process();
            p.StartInfo.Arguments = ScrapeCommand;
            p.StartInfo.WorkingDirectory = ytdlpPath;
            p.StartInfo.FileName = ytdlpPath + "\\" + "yt-dlp.exe";
            p.StartInfo.CreateNoWindow = false;
            p.StartInfo.RedirectStandardError = false;
            p.StartInfo.RedirectStandardOutput = false;
            p.Start();
            logger.Debug("Waiting for scraping to complete");
            p.WaitForExit();
        }
    }
}
