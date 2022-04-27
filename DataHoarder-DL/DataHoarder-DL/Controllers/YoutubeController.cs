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
        Logger logger = LogManager.GetCurrentClassLogger();
        public YoutubeController()
        {
        }
        public void BuildPaths(UnifiedScrapeItem ScrapeItem)
        {
            logger.Trace("Verifying and creating directories");

            if (!Directory.Exists(ScrapeItem.ItemPath)) { Directory.CreateDirectory(ScrapeItem.ItemPath); }
            MetadataPath = ScrapeItem.ItemPath + "\\metadata";
            if (!Directory.Exists(MetadataPath)) { Directory.CreateDirectory(MetadataPath); }
            HistoryPath = ScrapeItem.ItemPath + "\\history";
            if (!Directory.Exists(HistoryPath)) { Directory.CreateDirectory(HistoryPath); }
            MediaPath = ScrapeItem.ItemPath + "\\media";
            if (!Directory.Exists(MediaPath)) { Directory.CreateDirectory(MediaPath); }
            CachePath = ScrapeItem.ItemPath + "\\cache";
            if (!Directory.Exists(CachePath)) { Directory.CreateDirectory(CachePath); }
        }
        public async Task<bool> FetchData(UnifiedQueueItem QueueItem)
        {
            logger.Info($"Begin fetching data for {QueueItem.URI} with method: {QueueItem.ScrapeType}");
            UnifiedScrapeItem ScrapeItem = Globals.Settings.ScrapeItems.Find(x => x.Id == QueueItem.ItemId);
            BuildPaths(ScrapeItem);
            ScrapeAllData(QueueItem.URI, QueueItem.ScrapeType);
            //TODO, organize this somehow
            return false;

        }
        public bool ScrapeAllData(string URL, ScrapeType ScrapeType)
        {
            logger.Info($"Begin data scraping for {URL}, method: {ScrapeType}");
            string scrapeCommand = BuildScrapeCommand(URL, CachePath, ScrapeType);
            InvokeYTScraper(scrapeCommand);
            return false;
        }
        private string BuildScrapeCommand(string URL, string DownloadPath, ScrapeType ScrapeType)
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
                case ScrapeType.YoutubeVideo:
                    scrapeCommandBase += $"-P \"{CachePath}\" -f bestvideo+bestaudio/best -ciw --ffmpeg-location \"{ffmpegPath}\" --download-archive \"{HistoryPath + "\\" + HistoryFile}\" --write-info-json --write-playlist-metafiles -o \"{OutputNameFormat}\" \"{URL}\"";
                    break;
                case ScrapeType.YoutubeChannel:
                    scrapeCommandBase += $"-P \"{CachePath}\" -f bestvideo+bestaudio/best -ciw --ffmpeg-location \"{ffmpegPath}\" --download-archive \"{HistoryPath + "\\" + HistoryFile}\" --write-info-json --write-playlist-metafiles -o \"{OutputNameFormat}\" \"{URL}\"";
                    break;
                case ScrapeType.YoutubePlaylist:
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
            p.StartInfo.UseShellExecute = false;
            //p.StartInfo.RedirectStandardError = true;
            //p.StartInfo.RedirectStandardOutput = true;
            p.Start();
            logger.Debug("Waiting for scraping to complete");
            //string output = p.StandardOutput.ReadToEnd();
            //string error = p.StandardError.ReadToEnd();
            p.WaitForExit();
            //if (!String.IsNullOrEmpty(output))
            //    logger.Debug(output);
            //if (!String.IsNullOrEmpty(error))
            //    logger.Error(error);
        }
    }
}
