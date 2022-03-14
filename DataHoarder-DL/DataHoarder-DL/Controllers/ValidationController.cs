using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DataHoarder_DL.Controllers
{
    internal class ValidationController
    {
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
            string TypePath = "";
            switch (ScrapeItem.ScrapeType)
            {
                case ScrapeType.Instagram:
                    TypePath = Globals.Settings.RootDownloadPath + "\\IG\\media\\" + ScrapeItem.ShortName;
                    break;
                case ScrapeType.TikTok:
                    TypePath = Globals.Settings.RootDownloadPath + "\\TT\\media\\" + ScrapeItem.ShortName;
                    break;
            }
            ScrapeItem.TotalSize = await GetDirectorySize(TypePath);
            ScrapeItem.NumFiles = await GetNumFiles(TypePath);
        }
        private async static Task<long> GetDirectorySize(string Path)
        {
            if (String.IsNullOrEmpty(Path) || !Directory.Exists(Path))
                return 0;
            DirectoryInfo dirInfo = new DirectoryInfo(Path);
            long dirSize = await Task.Run(() => dirInfo.EnumerateFiles("*", SearchOption.AllDirectories).Sum(file => file.Length));
            return dirSize;
        }
        private async static Task<int> GetNumFiles(string Path)
        {
            if (String.IsNullOrEmpty(Path) || !Directory.Exists(Path))
                return 0;
            string[] files = await Task.Run(() =>Directory.GetFiles(Path, "*.*", SearchOption.AllDirectories));
            return files.Length;
        }
    }
}
