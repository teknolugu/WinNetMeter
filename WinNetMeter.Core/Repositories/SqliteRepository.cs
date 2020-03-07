using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Serilog;
using WinNetMeter.Core.Helper;

namespace WinNetMeter.Core.Repositories
{
    public static class SqliteRepository
    {
        public static string DbPath { get; set; } = "Storage/Common/LocalStorage.db";

        public static SQLiteConnection InitSqLite()
        {
            Path.GetDirectoryName(DbPath).EnsureDirectory();

            var connBuilder = new SQLiteConnectionStringBuilder();
            connBuilder.DataSource = DbPath;
            connBuilder.JournalMode = SQLiteJournalModeEnum.Memory;
            connBuilder.Version = 3;

            // var connStr = $"Data Source={dbPath};Version=3;Journal Mode=Memory";
            var connStr = connBuilder.ConnectionString;
            if (File.Exists(DbPath)) return new SQLiteConnection(connStr);

            Log.Information($"Creating {DbPath} for LocalStorage");
            SQLiteConnection.CreateFile(DbPath);

            return new SQLiteConnection(connStr);
        }

        public static SQLiteConnection InitInMemorySqlite()
        {
            var connBuild = new SQLiteConnectionStringBuilder {DataSource = ":memory:"};
            return new SQLiteConnection(connBuild.ConnectionString);
        }
    }
}
