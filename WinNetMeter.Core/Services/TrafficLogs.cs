using System;
using System.Collections.Generic;
using System.Linq;
using SqlKata;
using SqlKata.Execution;
using WinNetMeter.Core.Helper;
using WinNetMeter.Core.Model;
using WinNetMeter.Core.Providers;

namespace WinNetMeter.Core.Services
{
    public class TrafficLogs
    {
        private static string tableName = "traffic_logs";

        public static bool Save(Dictionary<string, string> data)
        {
            var query = new QueryBuilder();
            return query.Insert(tableName, data);

            // var insert = new Query(tableName)
            //     .ExecForSqLite(true)
            //     .Insert(data);
            //
            // return insert > 0;
        }

        public static TrafficLog GetTrafficRate()
        {
            var currentDate = DateTime.Now.ToString("yyyy-MM-dd");
            var currentTime = DateTime.Now.AddSeconds(-1).ToString("HH:mm:ss");

            var query = new Query(tableName)
                .SelectRaw("date Date")
                .SelectRaw("time Time")
                .SelectRaw("avg(upload) UploadRate")
                .SelectRaw("avg(download) DownloadRate")
                .Select("adapter_name AdapterName")
                .Where("date",currentDate)
                .Where("time",currentTime)
                .ExecForSqLite()
                .Get<TrafficLog>().FirstOrDefault();

            return query;
        }
    }
}