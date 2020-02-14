using WinNetMeter.Core.Helpers;
using WinNetMeter.Core.Providers;

namespace WinNetMeter.Core.Model
{
    public static class Settings
    {
        public static bool EnableMonitoring
        {
            get => RegistryProvider.ReadFromRegistry("General", "Monitoring").ToBool();
            set => RegistryProvider.WriteToRegistry("General", "Monitoring", value.ToString());
        }

        public static bool EnableAutoUpdate
        {
            get => RegistryProvider.ReadFromRegistry("General", "AutoUpdate").ToBool();
            set => RegistryProvider.WriteToRegistry("General", "AutoUpdate", value.ToString());
        }
    }
}
