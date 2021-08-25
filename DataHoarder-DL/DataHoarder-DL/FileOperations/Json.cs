using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;

namespace DataHoarder_DL.FileOperations
{
    class Json
    {
        public static Models.Instagram.IGData ParseMetadata(string JsonData)
        {
            //try
           // {
                var _settings = new JsonSerializerSettings() { };
                var _data = JsonConvert.DeserializeObject<Models.Instagram.IGData>(JsonData, _settings);
                return _data;
           // }
            ////catch (Exception ex)
            //
                //Utilities.Utilities.Logger.Error(ex.Message);
                //Utilities.Utilities.Logger.Debug(ex.InnerException);
                return null;
           // }
        }
        public static string SerializeMetadata(Models.Instagram.IGData data)
        {
            //try
           // {
                string json = JsonConvert.SerializeObject(data, Formatting.Indented);
                //File.WriteAllText(path, json);
                return json;
           // }
            //catch (Exception ex)
           // {
                //Utilities.Utilities.Logger.Error(ex.Message);
                //Utilities.Utilities.Logger.Debug(ex.InnerException);
            //    return false;
            //}
        }

    }
}
