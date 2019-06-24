using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinNetMeter.Model
{
    class DatabaseConfiguration
    {
        bool trafficLogging;
        string customLogLocation;

        public string CustomLogLocation { get => customLogLocation; set => customLogLocation = value; }
        public bool TrafficLogging { get => trafficLogging; set => trafficLogging = value; }
    }
}
