using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Serilog;
using WinNetMeter.Core.Model;
using WinNetMeter.Core.Providers;

namespace WinNetMeter.Core.Helper
{
    public static class InitHelper
    {
        public static void InitializeAll()
        {
            RegistryProvider.Init();

            Settings.AppDirectory = Environment.CurrentDirectory;
            Settings.AppExePath = Assembly.GetExecutingAssembly().Location;

            SerilogProvider.Initialize();

            Log.Information("Starting App..");

            SqliteProvider.DbPath = Settings.AppDirectory + @"\Storage\Common\LocalStorage.db";

            // EvolveProvider.Initialize();
        }
    }
}