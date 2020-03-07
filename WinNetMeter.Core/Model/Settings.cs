using WinNetMeter.Core.Helpers;
using WinNetMeter.Core.Providers;

namespace WinNetMeter.Core.Model
{
    public static class Settings
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
    }
}