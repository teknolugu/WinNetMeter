using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinNetMeter.Shell.Model
{
    public class Configuration
    {
        private bool monitoring;
        private bool autoUpdate;
        private Language language;
        private string format;
        private string monitoredAdapter;

        public bool Monitoring { get => monitoring; set => monitoring = value; }
        public bool AutoUpdate { get => autoUpdate; set => autoUpdate = value; }
        internal Language Language { get => language; set => language = value; }
        public string Format { get => format; set => format = value; }
        public string MonitoredAdapter { get => monitoredAdapter; set => monitoredAdapter = value; }
       
    }
}
