using WinNetMeter.Core.Helpers;
using WinNetMeter.Core.Providers;

namespace WinNetMeter.Shell.Model
{
    public static class AppSettings
    {
        public static string AppDirectory
        {
            get => RegistryProvider.ReadFromRegistry("General", "AppDirectory").ToString();
            set => RegistryProvider.WriteToRegistry("General", "AppDirectory", value);
        }

        public static string AppExePath
        {
            get => RegistryProvider.ReadFromRegistry("General", "AppExePath").ToString();
            set => RegistryProvider.WriteToRegistry("General", "AppExePath", value);
        }

        public static bool EnableMonitoring
        {
            get => RegistryProvider.ReadFromRegistry("General", "Monitoring").ToBool();
            set => RegistryProvider.WriteToRegistry("General", "Monitoring", value.ToString());
        }

        public static string MonitoredAdapter
        {
            get => RegistryProvider.ReadFromRegistry("General", "MonitoredAdapter").ToString();
            set => RegistryProvider.WriteToRegistry("General", "MonitoredAdapter", value.ToString());
        }

        public static bool EnableAutoUpdate
        {
            get => RegistryProvider.ReadFromRegistry("General", "AutoUpdate").ToBool();
            set => RegistryProvider.WriteToRegistry("General", "AutoUpdate", value.ToString());
        }

        public static string DBFilePath
        {
            get
            {
                var conf = RegistryProvider.ReadFromRegistry("Database", "DBFilePath");
                return conf == null ? "" : conf.ToString();
            }
            set => RegistryProvider.WriteToRegistry("Database", "DBFilePath", value);
        }

        public static string ShellHwnd
        {
            get => RegistryProvider.ReadFromRegistry("General", "hwnd").ToString();
            set => RegistryProvider.WriteToRegistry("General", "hwnd", value);
        }
    }
}