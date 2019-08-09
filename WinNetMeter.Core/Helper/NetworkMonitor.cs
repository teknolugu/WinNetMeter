using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Timers;
using Microsoft.Win32.SafeHandles;
using WinNetMeter.Core.Controllers;

namespace WinNetMeter.Core.Helper
{
    public class NetworkMonitor : IDisposable
    {
        private AdapterController adapter;
        private Timer monitor;
        private bool disposed = false;
        private SafeHandle handle = new SafeFileHandle(IntPtr.Zero, true);

        public NetworkMonitor(AdapterController adapterC)
        {
            this.adapter = adapterC;
            InitAdapter();
            monitor = new Timer();
            monitor.Interval = 1000;
            monitor.Elapsed += Monitor_Elapsed;
        }

        public void Dispose()
        {
            // Dispose of unmanaged resources.
            Dispose(true);
            // Suppress finalization.
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;
            if (disposing)
            {
                handle.Dispose();
            }
            disposed = true;
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
                if (name == adapter.AdapaterName)
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

        public void Stop()
        {
            monitor.Enabled = false;
        }
    }
}