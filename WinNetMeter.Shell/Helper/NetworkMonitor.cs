using System.Diagnostics;
using System.Timers;
using WinNetMeter.Shell.Controller;

namespace WinNetMeter.Shell.Helper
{
    internal class NetworkMonitor
    {
        private AdapterController adapter;
        private Timer monitor;

        public NetworkMonitor(AdapterController adapterC)
        {
            this.adapter = adapterC;
            InitAdapter();
            monitor = new Timer();
            monitor.Interval = 1000;
            monitor.Elapsed += Monitor_Elapsed;
        }

        private void Monitor_Elapsed(object sender, ElapsedEventArgs e)
        {
            adapter.Refresh();
        }

        public void InitAdapter()
        {
            PerformanceCounterCategory counterCategory = new PerformanceCounterCategory("Network Interface");

            foreach (string name in counterCategory.GetInstanceNames())
            {
                if(name == adapter.AdapaterName)
                {
                    adapter.DownloadSpeedCounter = new PerformanceCounter("Network Interface", "Bytes Received/sec", name);
                    adapter.UploadSpeedCounter = new PerformanceCounter("Network Interface", "Bytes Sent/sec", name);
                }

            }
        }

        public void Start()
        {
            if (!(this.adapter.AdapaterName == null))
            {
                adapter.Initialize();
                monitor.Enabled = true;
            }
        }
    }
}