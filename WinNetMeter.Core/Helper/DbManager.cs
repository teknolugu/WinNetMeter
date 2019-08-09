using System;
using System.Data.SQLite;
using System.IO;
using System.Windows.Forms;

namespace WinNetMeter.Core.Helper
{
    public class DbManager
    {
        private string dbPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"/WinNetMeter/data.db";
        private string connectionQuery;
        private SQLiteConnection connection;
        private SQLiteCommand command;

        public DbManager()
        {
            //Create SQLite file if not exists
            if (!File.Exists(dbPath)) CreateDatabase();
        }

        public void CreateDatabase()
        {
            //Check If directory exists
            if (!Directory.Exists(Path.GetDirectoryName(dbPath))) Directory.CreateDirectory(Path.GetDirectoryName(dbPath));

            //Create SQLite database file
            SQLiteConnection.CreateFile(dbPath);

            connection = new SQLiteConnection("DataSource=" + dbPath + ";Version=3");
            if (connection.State == System.Data.ConnectionState.Closed) connection.Open();

            //Create adapter table
            command = new SQLiteCommand("CREATE TABLE adapter(Id INTEGER PRIMARY KEY, Name TEXT NOT NULL)", connection);

            try
            {
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("There is an error when creating table " + Environment.NewLine + ex.Message, "An Error occurred", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            command.Dispose();

            //Create traffic table

            command = new SQLiteCommand("CREATE TABLE traffic(Id INTEGER PRIMARY KEY, Date VARCHAR(255), Sent TEXT NOT NULL, Received TEXT)", connection);

            try
            {
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("There is an error when creating table " + Environment.NewLine + ex.Message, "An Error occurred", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Insert(string value)
        {
        }
    }
}