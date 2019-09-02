using Microsoft.Win32.SafeHandles;
using System;
using System.Management;
using System.Runtime.InteropServices;
using System.Security.Principal;

namespace WinNetMeter.Core.Helper
{
    public class ThemeMonitor : IDisposable
    {
        private WqlEventQuery query;
        private bool disposed = false;
        private SafeHandle handle = new SafeFileHandle(IntPtr.Zero, true);
        private ManagementEventWatcher watcher;

        private EventHandler onThemeChanged;

        public EventHandler OnThemeChanged { get => onThemeChanged; set => onThemeChanged = value; }

        public void Dispose()
        {
            // Dispose of unmanaged resources.
            Dispose(true);
            // Suppress finalization
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

        private void Start()
        {
            WindowsIdentity currentUser = WindowsIdentity.GetCurrent();
            query = new WqlEventQuery("SELECT * FROM RegistryTreeChangeEvent WHERE " +
               "Hive = 'HKEY_USERS'" +
              @"AND RootPath = 'SOFTWARE\\Microsoft\\.NETFramework'");
            watcher = new ManagementEventWatcher(query);

            watcher.EventArrived += new EventArrivedEventHandler(OnThemeChanged);
            watcher.Start();
        }

        private void Stop()
        {
            try
            {
                watcher.Stop();
            }
            catch (Exception ex)
            {

            }
        }
   }

}
