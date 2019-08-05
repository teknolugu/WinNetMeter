using System;
using WinNetMeter.Core.Helper;

namespace WinNetMeter.Core.Model
{
    public class EventLog
    {
        public static void WriteLog(string value)
        {
            RegistryManager registryManager = new RegistryManager();
            var appBase = registryManager.ReadFromRegistry("WinNetMeter", "AppBasePath");

            var path = $@"{appBase}\Sources\activity.log";
            var timeStamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            var data = $"{timeStamp} - {value}";

            FileHelper.WriteToFile(path, data);
        }
    }
}