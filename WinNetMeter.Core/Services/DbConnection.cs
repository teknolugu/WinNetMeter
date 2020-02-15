using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Windows.Forms;
using System.IO;
using WinNetMeter.Core.Helper;
using WinNetMeter.Core.Model;

namespace WinNetMeter.Core.Services
{
    internal abstract class IDbConnection
    {
        public abstract int ExecNonQuery(string query); // Insert, Update, Delete

        public abstract DataTable ExecWithQuery(string query); // Select
    }

    internal class DbConnection : IDbConnection
    {
        private readonly SQLiteCommand _SqliteCommand;
        private readonly SQLiteConnection _SqliteConnection;
        private readonly SQLiteDataAdapter _SqliteDataAdapter;

        // private string dbFile = @"D:\Projek\CS.NET\WinTenGroup\WinNetMeter\Build\Debug\Sources\Store.db";
        private string dbFile = Settings.AppDirectory + @"\Storage\Common\LocalStorage.db";

        public DbConnection()
        {
            try
            {
                if (File.Exists(dbFile))
                {
                    var connString = $"Data Source={dbFile}";

                    _SqliteConnection = new SQLiteConnection(connString);
                    _SqliteCommand = new SQLiteCommand();
                    _SqliteDataAdapter = new SQLiteDataAdapter();
                }
                else
                {
                    throw new Exception($"DB file is not exist. File {dbFile}.");
                }
            }
            catch (Exception ex)
            {
                EventLog.WriteLog(ex.Message);
            }
        }

        private void OpenConnection()
        {
            if (_SqliteConnection.State == ConnectionState.Closed)
            {
                try
                {
                    _SqliteConnection.Open();
                }
                catch
                {
                    // Ignored
                }
            }
        }

        private void CloseConnection()
        {
            if (_SqliteConnection.State == ConnectionState.Closed)
            {
                try
                {
                    _SqliteConnection.Close();
                }
                catch
                {
                    // Ignored
                }
            }
        }

        public override int ExecNonQuery(string query)
        {
            var affectedRow = -1;
            try
            {
                OpenConnection();
                _SqliteCommand.Connection = _SqliteConnection;
                _SqliteCommand.CommandText = query;
                affectedRow = _SqliteCommand.ExecuteNonQuery();
            }
            catch
            {
                // Ignored
            }
            finally
            {
                CloseConnection();
            }

            return affectedRow;
        }

        public override DataTable ExecWithQuery(string query)
        {
            var result = new DataTable();
            try
            {
                OpenConnection();
                _SqliteCommand.Connection = _SqliteConnection;
                _SqliteCommand.CommandText = query;
                _SqliteDataAdapter.SelectCommand = _SqliteCommand;
                _SqliteDataAdapter.Fill(result);
            }
            catch
            {
                // Ignored
            }
            finally
            {
                CloseConnection();
            }

            return result;
        }
    }
}