using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinNetMeter.Core.Providers
{
    class NetAdapterProvider
    {
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
