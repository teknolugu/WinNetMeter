using SqlKata.Compilers;
using SqlKata.Execution;
using System.Data.SQLite;
using System.IO;
using Serilog;
using SqlKata;
using WinNetMeter.Core.Model;

namespace WinNetMeter.Shell.Helper
{
    internal static class SqlKataHelper
    {
        public static string DBFile { get; set; }

        public static Query OpenSqlite()
        {
            var appDirectory = Settings.AppDirectory;
            DBFile = Path.Combine(appDirectory, "Storage/Common/LocalStorage.db");

            if (!File.Exists(DBFile))
            {
                SQLiteConnection.CreateFile(DBFile);
                // throw new Exception($"DB file is not exist. File {dbFile}.");
            }

            var compiler = new SqliteCompiler();
            var connBuilder = new SQLiteConnectionStringBuilder()
            {
                DataSource = DBFile,
                CacheSize = 1024,
                SyncMode = SynchronizationModes.Full
            };

            var connection = new SQLiteConnection(connBuilder.ConnectionString);
            var query = new Query();

            var factory = new QueryFactory(connection, compiler);

            factory.Logger = result => Log.Debug("SQLiteExec: {0}", result);
            return factory.FromQuery(query);
        }
    }
}