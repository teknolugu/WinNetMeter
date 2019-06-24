using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinNetMeter.Model
{
    public class Configuration
    {
        private bool monitoring;
        private bool autoUpdate;
        private Language language;
        private string format;
        private bool trafficLogging;
        private string monitoredAdapter;
        private string customLogLocation;

        public bool Monitoring { get => monitoring; set => monitoring = value; }
        public bool AutoUpdate { get => autoUpdate; set => autoUpdate = value; }
        public Language Language { get => language; set => language = value; }
        public string Format { get => format; set => format = value; }
        public bool TrafficLogging { get => trafficLogging; set => trafficLogging = value; }
        public string MonitoredAdapter { get => monitoredAdapter; set => monitoredAdapter = value; }
        public string CustomLogLocation { get => customLogLocation; set => customLogLocation = value; }
       
    }
}
