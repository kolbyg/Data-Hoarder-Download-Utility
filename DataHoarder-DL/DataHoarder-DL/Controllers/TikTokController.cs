﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;
using System.Globalization;
using NLog;
using System.Net;

namespace DataHoarder_DL.Controllers
{
    public class TikTokController
    {
        //string AuthUsername = "";
        //string AuthPass = "";
        public string MetadataPath { get; private set; }
        public string HistoryPath { get; private set; }
        public string MediaPath { get; private set; }
        public string CachePath { get; private set; }
        string ytdlpPath = Globals.BinDir + "\\yt-dlp";
        Logger logger = LogManager.GetCurrentClassLogger();
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
            try
            {
                logger.Info($"Begin fetching data for {QueueItem.URI} with a maximum of {QueueItem.MaxToScrape}");
                UnifiedScrapeItem ScrapeItem = Globals.Settings.ScrapeItems.Find(x => x.Id == QueueItem.ItemId);
                BuildPaths(ScrapeItem);
                QueueItem.IsScraping = true;
                //ScrapeMetadata(username);
                ScrapeAllData(QueueItem.URI, QueueItem.MaxToScrape);
                Parse(QueueItem.URI);
                await ScrapeItem.Validate();
                //Validate();
                //TODO download of missing items using web request
                ScrapeItem.LastScraped = DateTime.Now;
                QueueItem.IsScraping = false;
                return true;
            }
            catch (Exception ex)
            {
                logger.Error(ex.ToString);
                return false;
            }

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
                //Move history file first
                //File.Move(CachePath + $"\\{username}.history", HistoryPath + $"\\{username}.history");
                DirectoryInfo directoryInfo = new DirectoryInfo(CachePath);
                foreach (FileInfo file in directoryInfo.EnumerateFiles())
                {
                    if (file.Extension == ".json")
                    {
                        if (File.Exists(MetadataPath + "\\" + file.Name))
                        {
                            File.Move(MetadataPath + "\\" + file.Name, MetadataPath + "\\" + file.Name + "." + DateTime.Now.ToString("yyyyMMddHHmmss"));
                        }
                        file.MoveTo(MetadataPath + "\\" + file.Name);
                    }
                    else
                    {
                        file.MoveTo(MediaPath + "\\" + file.Name);
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
            }
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
            //p.StartInfo.RedirectStandardError = true;
            //p.StartInfo.RedirectStandardOutput = true;
            p.Start();
            logger.Debug("Waiting for TT scraping to complete");
            //streamreader? async?
            //string output = p.StandardOutput.ReadToEnd();
            //string error = p.StandardError.ReadToEnd();
            p.WaitForExit();
            //if (!String.IsNullOrEmpty(output))
           //     logger.Debug(output);
            //if (!String.IsNullOrEmpty(error))
            //    logger.Error(error);
        }
    }
}
