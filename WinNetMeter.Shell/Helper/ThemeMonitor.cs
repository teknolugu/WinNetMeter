using Microsoft.Win32.SafeHandles;
using System;
using System.Management;
using System.Runtime.InteropServices;
using System.Security.Principal;
using WinNetMeter.Core.Model;
using WinNetMeter.Core.Helper;
using System.Windows.Forms;

namespace WinNetMeter.Shell.Helper
{
    public class ThemeMonitor : IDisposable
    {
        private bool started = false;
        private bool disposed = false;
        private RegistryManager registryManager;
        public event EventHandler OnThemeChanged;

        SafeHandle handle = new SafeFileHandle(IntPtr.Zero, true);

        public ThemeMonitor()
        {
            registryManager = new RegistryManager();
        }

        public void Start()
        {
            if (!started)
            {
                var currentUser = WindowsIdentity.GetCurrent();

                var query = new WqlEventQuery("SELECT * FROM RegistryTreeChangeEvent WHERE Hive = 'HKEY_USERS' AND RootPath = '" + currentUser.User.Value + @"\\Software\\Microsoft\\Windows\\CurrentVersion\\Themes\\Personalize'");
                var watcher = new ManagementEventWatcher(query);
                watcher.EventArrived += (sender, args) => ThemeChanged();
                watcher.Start();
            }
        }

        private void ThemeChanged()
        {
            EventHandler handler = OnThemeChanged;
            handler?.Invoke(this, EventArgs.Empty);
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

    }
}