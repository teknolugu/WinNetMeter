using System;
using System.Collections.Generic;
using System.Management;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.NetworkInformation;
using System.Diagnostics;

namespace WinNetMeter.Helper
{
    public class NetworkIntefaceModule
    {
        public List<string> GetActiveNetworkInterface()
        {
            List<string> adapters = new List<string>();
            ManagementObjectSearcher objectSearcher = new ManagementObjectSearcher("SELECT * FROM Win32_NetworkAdapter" + " WHERE NetConnectionStatus=2");
            foreach(ManagementObject obj  in objectSearcher.Get())
            {
                adapters.Add(obj["Name"].ToString());
            }
           
            return adapters;
        }

        public List<string> GetNetworkInterface()
        {
            List<string> adapters = new List<string>();
            PerformanceCounterCategory category = new PerformanceCounterCategory("Network Interface");
            foreach(string name in category.GetInstanceNames())
            {
                adapters.Add(name);
            }
            return adapters;
        }
    }
}
