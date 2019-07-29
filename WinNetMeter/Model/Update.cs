using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinNetMeter.Model
{
    class Update
    {
        private string dashboardVersion;
        private string updaterVersion;
        private string shellVersion;
        private string description;
        private List<string> changelog;

        public List<string> Changelog { get => changelog; set => changelog = value; }
        public string DashboardVersion { get => dashboardVersion; set => dashboardVersion = value; }
    } 
}
