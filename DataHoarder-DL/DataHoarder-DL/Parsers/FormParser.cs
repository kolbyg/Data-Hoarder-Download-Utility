using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataHoarder_DL.Parsers
{
    class FormParser
    {
        public enum DownloadType
        {
            Youtube,
            Instagram,
            Twitter,
            Unsupported
        }

        public static DownloadType ParseURL(string URL)
        {
            return DownloadType.Instagram;
        }
    }
}
