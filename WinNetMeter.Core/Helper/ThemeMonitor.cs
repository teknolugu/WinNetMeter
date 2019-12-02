using Microsoft.Win32.SafeHandles;
using System;
using System.Management;
using System.Runtime.InteropServices;
using System.Security.Principal;
using WinNetMeter.Core.Model;
using System.Windows.Forms;
using Microsoft.Win32;

namespace WinNetMeter.Core.Helper
{
    public class ThemeMonitor : IDisposable
    {
        private WqlEventQuery query;
        private bool disposed = false;
        private SafeHandle handle = new SafeFileHandle(IntPtr.Zero, true);
        private ManagementEventWatcher watcher;
        private RegistryManager registryManager;
        private readonly string path = Registry.CurrentUser + @"\\Software\\Microsoft\\Windows\\CurrentVersion\\Themes\\Personalize";

        public ThemeMonitor()
        {
            registryManager = new RegistryManager();
        }

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

        public void Start()
        {
            WindowsIdentity currentUser = WindowsIdentity.GetCurrent();
            query = new WqlEventQuery("SELECT * FROM RegistryTreeChangeEvent WHERE " +
                            "Hive = 'HKEY_USERS' " +
                             @"AND RootPath = '" + currentUser.User.Value + @"\\Software\\Microsoft\\Windows\\CurrentVersion\\Themes\\Personalize'");
            watcher = new ManagementEventWatcher(query);

            watcher.EventArrived += new EventArrivedEventHandler(OnThemeChanged);
            watcher.Start();
        }

        public WindowsTheme GetTheme()
        {
            var theme = registryManager.ReadFromRegistry(@"Software\Microsoft\Windows\CurrentVersion\Themes\Personalize", "SystemUsesLightTheme");
            return (WindowsTheme)theme;
        }

        private void Stop()
        {
            try
            {
                watcher.Stop();
            }
            catch{}
        }
   }

}
