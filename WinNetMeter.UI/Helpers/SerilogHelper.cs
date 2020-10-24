using System;
using System.IO;
using Serilog;
using WinNetMeter.Core.Helper;
using WinNetMeter.Core.Model;

namespace WinNetMeter.UI.Helpers
{
    public static class SerilogHelper
    {
        public static ILogger Initialize()
        {
            var appDir = Settings.AppDirectory;
            var logPath = Path.Combine(appDir, "Storage/Logs/UI-.log").EnsureDirectory();

            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.File(logPath,
                    rollingInterval: RollingInterval.Day,
                    flushToDiskInterval: TimeSpan.FromSeconds(1),
                    shared: true)
                .CreateLogger();

            return Log.Logger;
        }
    }
}