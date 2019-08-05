using System.Collections.Generic;
using WinNetMeter.Core.Helper;

namespace WinNetMeter.Core.Services
{
    public class TrafficLogs
    {
        private static string tableName = "traffic_logs";

        public static bool Save(Dictionary<string, string> data)
        {
            var query = new QueryBuilder();
            return query.Insert(tableName, data);
        }
    }
}