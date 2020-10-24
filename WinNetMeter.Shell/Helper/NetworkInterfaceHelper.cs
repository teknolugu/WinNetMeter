using System.Collections.Generic;
using System.Diagnostics;
using System.Management;

namespace WinNetMeter.Shell.Helper
{
    public class NetworkInterfaceHelper
    {
        public static List<string> GetActiveNetworkInterface()
        {
            List<string> adapters = new List<string>();
            var query = "SELECT * FROM Win32_NetworkAdapter WHERE NetConnectionStatus=2";
            var objectSearcher = new ManagementObjectSearcher(query);
            var objectCollection = objectSearcher.Get();

            foreach (var obj in objectCollection)
            {
                var name = obj["Name"].ToString();

                adapters.Add(name);
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