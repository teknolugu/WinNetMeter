using Serilog;
using System;
using WinNetMeter.Core.Model;

namespace WinNetMeter.Core.Providers
{
    public class EvolveProvider
    {
        public static void Initialize()
        {
            try
            {
                var cnx = SqliteProvider.InitSqLite();
                var evolve = new Evolve.Evolve(cnx, Log.Information)
                {
                    Locations = new[] { Settings.AppDirectory + @"\Storage\Migration" },
                    IsEraseDisabled = true,
                };

                evolve.Migrate();
            }
            catch (Exception ex)
            {
                Log.Error("Database migration failed.", ex);
                throw;
            }
        }
    }
}
