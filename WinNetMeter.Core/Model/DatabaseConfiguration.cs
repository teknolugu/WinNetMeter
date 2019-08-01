
namespace WinNetMeter.Core.Model
{
    public class DatabaseConfiguration
    {
        bool trafficLogging;
        string customLogLocation;

        public string CustomLogLocation { get => customLogLocation; set => customLogLocation = value; }
        public bool TrafficLogging { get => trafficLogging; set => trafficLogging = value; }
    }
}
