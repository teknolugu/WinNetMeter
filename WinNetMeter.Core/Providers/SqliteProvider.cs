using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Serilog;
using SqlKata;
using SqlKata.Compilers;
using SqlKata.Execution;

namespace WinNetMeter.Core.Providers
{
    static class SqliteProvider
    {
        static string dbPath = "Storage/Common/LocalStorage.db";

        private static SQLiteConnection InitSqLite()
        {
            var connBuilder = new SQLiteConnectionStringBuilder();
            connBuilder.DataSource = dbPath;
            connBuilder.JournalMode = SQLiteJournalModeEnum.Memory;
            connBuilder.Version = 3;

            // var connStr = $"Data Source={dbPath};Version=3;Journal Mode=Memory";
            var connStr = connBuilder.ConnectionString;
            if (File.Exists(dbPath)) return new SQLiteConnection(connStr);

            Log.Information($"Creating {dbPath} for LocalStorage");
            SQLiteConnection.CreateFile(dbPath);

            return new SQLiteConnection(connStr);
        }

        public static Query ExecForSqLite(this Query query, bool printSql = false)
        {
            // var connection = new SQLiteConnection(dbPath);
            var connection = InitSqLite();

            var factory = new QueryFactory(connection, new SqliteCompiler());

            if (printSql) factory.Logger = sqlResult => { Log.Debug($"SQLiteExec: {sqlResult}"); };

            return factory.FromQuery(query);
        }

        public static async Task<int> ExecForSqLite(this string sql, bool printSql = false, object param = null)
        {
            var connection = InitSqLite();

            var factory = new QueryFactory(connection, new SqliteCompiler());

            if (printSql) factory.Logger = sqlResult => { Log.Debug($"SQLiteExec: {sqlResult}"); };

            return await factory.StatementAsync(sql, param);
        }

        public static async Task<IEnumerable<dynamic>> ExecForSqLiteQuery(this string sql, bool printSql = false, object param = null)
        {
            var connection = InitSqLite();

            var factory = new QueryFactory(connection, new SqliteCompiler());

            if (printSql) factory.Logger = sqlResult => { Log.Debug($"SQLiteExec: {sqlResult}"); };

            return await factory.SelectAsync(sql, param);
        }

        public static async Task<int> DeleteDuplicateRow(this string tableName, string columnKey)
        {
            Log.Information("Deleting duplicate row(s)");
            var sql = $"DELETE FROM {tableName} " +
                      "WHERE rowid NOT IN( " +
                      "SELECT min(rowid) " +
                      "FROM fban_user " +
                      $"GROUP BY {columnKey});";

            var result = await sql.ExecForSqLite(true);
            Log.Information($"Deleted {result}");

            return result;
        }

        public static bool IfTableExist(this string tableName)
        {
            var query = new Query("sqlite_master")
                .Where("type", "table")
                .Where("name", tableName)
                .ExecForSqLite(true)
                .Get();

            var isExist = query.Any();

            Log.Debug($"Is {tableName} exist: {isExist}");

            return isExist;
        }

        public static async Task<bool> ExecuteFileForSqLite(this string filePath)
        {
            if (!File.Exists(filePath)) return false;

            var sql = File.ReadAllText(filePath);
            await sql.ExecForSqLite(true);

            return true;
        }
    }
}
