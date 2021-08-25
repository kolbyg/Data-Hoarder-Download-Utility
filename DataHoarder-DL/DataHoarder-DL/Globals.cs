using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataHoarder_DL.Models;

namespace DataHoarder_DL
{
    static class Globals
    {
        public static List<Module> Modules = new List<Module>();
        public static string WorkingDir = Environment.CurrentDirectory + "\\data";
        public static string MediaDir = Environment.CurrentDirectory + "\\media";
        public static string CacheDir = Environment.CurrentDirectory + "\\cache";
    }
}
