using System.Collections.Generic;
using System.Diagnostics;
using System.Management;

namespace WinNetMeter.Core.Helper
{
    public class NetworkIntefaceModule
    {
        public List<string> GetActiveNetworkInterface()
        {
            List<string> adapters = new List<string>();
            ManagementObjectSearcher objectSearcher = new ManagementObjectSearcher("SELECT * FROM Win32_NetworkAdapter" + " WHERE NetConnectionStatus=2");
            foreach (ManagementObject obj in objectSearcher.Get())
            {
                adapters.Add(obj["Name"].ToString());
            }

            return adapters;
        }

        public List<string> GetNetworkInterface()
        {
            List<string> adapters = new List<string>();
            PerformanceCounterCategory category = new PerformanceCounterCategory("Network Interface");
            foreach (string name in category.GetInstanceNames())
            {
                adapters.Add(name);
            }
            return adapters;
        }
    }
}