using System;
using Serilog;
using WinNetMeter.Core.Helper;
using WinNetMeter.Core.Model;

namespace WinNetMeter.Core.Providers
{
    public static class SerilogProvider
    {
        public static ILogger Initialize()
        {
            var logPath = Settings.AppDirectory + @"\Storage\Logs\activity-.log".EnsureDirectory();

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