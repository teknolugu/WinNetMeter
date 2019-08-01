using Microsoft.Win32;
using System;
using WinNetMeter.Core.Model;

namespace WinNetMeter.Core.Helper
{
    public class RegistryManager
    {
        private Configuration config = new Configuration();
        private DatabaseConfiguration dbConfig = new DatabaseConfiguration();
        private StyleConfiguration styleConfig = new StyleConfiguration();
        private RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Software", true);
        private RegistryKey GeneralConfiguration;
        private RegistryKey DatabaseConfiguration;
        private RegistryKey StyleConfiguration;

        public RegistryManager()
        {
            CreateRegistry();

            if (GeneralConfiguration.GetValue("Monitoring") == null)
            {
                MakeDefaultConfiguration();
            }
        }

        public void Reset()
        {
            var appKey = key.OpenSubKey(@"WinNetMeter", true);
            foreach (string subKey in appKey.GetSubKeyNames())
            {
                try
                {
                    appKey.DeleteSubKeyTree(subKey);
                }
                catch
                {

                }
            }
        }
        public void MakeDefaultConfiguration()
        {
            //general configuration
            GeneralConfiguration.SetValue("Monitoring", true, RegistryValueKind.String);
            GeneralConfiguration.SetValue("AutoUpdate", false, RegistryValueKind.String);
            GeneralConfiguration.SetValue("Language", "English", RegistryValueKind.String);
            GeneralConfiguration.SetValue("Format", "Auto", RegistryValueKind.String);
            GeneralConfiguration.SetValue("TrafficLogging", false, RegistryValueKind.String);
            GeneralConfiguration.SetValue("MonitoredAdapter", "", RegistryValueKind.String);

            //database configuration
            DatabaseConfiguration.SetValue("TrafficLogging", false, RegistryValueKind.String);
            DatabaseConfiguration.SetValue("CustomLogLocation", "", RegistryValueKind.String);

            //style configuration
            StyleConfiguration.SetValue("BackgroundColor", "Black", RegistryValueKind.String);
            StyleConfiguration.SetValue("TextColor", "White", RegistryValueKind.String);
            StyleConfiguration.SetValue("Font", "Segoe UI", RegistryValueKind.String);
            StyleConfiguration.SetValue("Icon", "Arrow", RegistryValueKind.String);
        }

        public void CreateRegistry()
        {
            var parent = key.CreateSubKey("WinNetMeter", RegistryKeyPermissionCheck.ReadWriteSubTree);
            GeneralConfiguration = parent.CreateSubKey("General", RegistryKeyPermissionCheck.ReadWriteSubTree);
            DatabaseConfiguration = parent.CreateSubKey("Database", RegistryKeyPermissionCheck.ReadWriteSubTree);
            StyleConfiguration = parent.CreateSubKey("Style", RegistryKeyPermissionCheck.ReadWriteSubTree);
        }

        public void Save(string config, string value, ConfigurationType type)
        {
            switch (type)
            {
                case ConfigurationType.GeneralConfiguration:
                    GeneralConfiguration.SetValue(config, value, RegistryValueKind.String);
                    break;
                case ConfigurationType.DatabaseConfiguration:
                    DatabaseConfiguration.SetValue(config, value, RegistryValueKind.String);
                    break;
                case ConfigurationType.StyleConfiguration:
                    StyleConfiguration.SetValue(config, value, RegistryValueKind.String);
                    break;
            }
        }

        public void Save(Configuration config)
        {
            GeneralConfiguration.SetValue("Monitoring", config.Monitoring, RegistryValueKind.String);
            GeneralConfiguration.SetValue("AutoUpdate", config.AutoUpdate, RegistryValueKind.String);
            GeneralConfiguration.SetValue("Language", config.Language, RegistryValueKind.String);
            GeneralConfiguration.SetValue("Format", config.Format, RegistryValueKind.String);
            GeneralConfiguration.SetValue("MonitoredAdapter", config.MonitoredAdapter, RegistryValueKind.String);
        }

        public void Save(DatabaseConfiguration config)
        {
            DatabaseConfiguration.SetValue("TrafficLogging", config.TrafficLogging, RegistryValueKind.String);
            DatabaseConfiguration.SetValue("CustomLogLocation", config.CustomLogLocation, RegistryValueKind.String);
        }

        public void Save(StyleConfiguration config)
        {
            StyleConfiguration.SetValue("TextColor", config.TextColor, RegistryValueKind.String);
            StyleConfiguration.SetValue("Font", config.FontFamily, RegistryValueKind.String);
            StyleConfiguration.SetValue("Icon", config.Icon, RegistryValueKind.String);
        }

        public Configuration GetGeneralConfiguration()
        {
            config.Monitoring = Convert.ToBoolean(GeneralConfiguration.GetValue("Monitoring"));
            config.AutoUpdate = Convert.ToBoolean(GeneralConfiguration.GetValue("AutoUpdate"));
            config.Language = (Language)Enum.Parse(typeof(Language), GeneralConfiguration.GetValue("Language").ToString());
            config.Format = GeneralConfiguration.GetValue("Format").ToString();
            config.MonitoredAdapter = GeneralConfiguration.GetValue("MonitoredAdapter").ToString();

            return config;
        }

        public DatabaseConfiguration GetDatabaseConfiguration()
        {
            dbConfig.TrafficLogging = Convert.ToBoolean(DatabaseConfiguration.GetValue("TrafficLogging"));
            dbConfig.CustomLogLocation = DatabaseConfiguration.GetValue("CustomLogLocation").ToString();

            return dbConfig;
        }

        public StyleConfiguration GetStyleConfiguration()
        {
            styleConfig.TextColor = StyleConfiguration.GetValue("TextColor").ToString();
            styleConfig.FontFamily = StyleConfiguration.GetValue("Font").ToString();
            styleConfig.Icon = (IconStyle)Enum.Parse(typeof(IconStyle), StyleConfiguration.GetValue("Icon").ToString());

            return styleConfig;
        }

        public void SaveHwnd(string value)
        {
            var hwndLoc = key.OpenSubKey(@"WinNetMeter", true);
            hwndLoc.SetValue("hwnd", value, RegistryValueKind.String);
        }

        public void SaveExecutableLocation(string path)
        {
            var exeKey = key.OpenSubKey(@"WinNetMeter", true);
            exeKey.SetValue("ExecutablePath", path, RegistryValueKind.String);
        }
        public string GetExecutableLocation()
        {
            var exeKey = key.OpenSubKey(@"WinNetMeter", true);
            return exeKey.GetValue("ExecutablePath").ToString();
        }
        public string GetHwnd()
        {
            var hwndLoc = key.OpenSubKey(@"WinNetMeter", true);
            return hwndLoc.GetValue("hwnd").ToString();
        }
    }
}