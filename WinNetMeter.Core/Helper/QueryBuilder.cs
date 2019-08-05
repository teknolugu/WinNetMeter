using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using WinNetMeter.Core.Services;

namespace WinNetMeter.Core.Helper
{
    internal class QueryBuilder
    {
        private readonly DbConnection dbConnection;

        public QueryBuilder()
        {
            dbConnection = new DbConnection();
        }

        private static string SqlEscape(object str)
        {
            return Regex.Replace(str.ToString(), @"[\x00'""\b\n\r\t\cZ\\%]",
                delegate (Match match)
                {
                    var v = match.Value;
                    switch (v)
                    {
                        case "\x00": // ASCII NUL (0x00) character
                            return "\\0";

                        case "\b": // BACKSPACE character
                            return "\\b";

                        case "\n": // NEWLINE (linefeed) character
                            return "\\n";

                        case "\r": // CARRIAGE RETURN character
                            return "\\r";

                        case "\t": // TAB
                            return "\\t";

                        case "\u001A": // Ctrl-Z
                            return "\\Z";

                        default:
                            return "\\" + v;
                    }
                });
        }

        public bool IsTableExist(string tableName)
        {
            var isTableExist = false;

            var query = "SELECT * FROM " + tableName;
            var dTbl = dbConnection.ExecWithQuery(query);

            if (dTbl.Rows.Count > 0) isTableExist = true;

            return isTableExist;
        }

        public bool IsDataExist(string tableName, Dictionary<string, object> where)
        {
            string query = $"SELECT * FROM {tableName} WHERE {where.First().Key} = \'{where.First().Value}\'";
            var dTbl = dbConnection.ExecWithQuery(query);

            return dTbl.Rows.Count > 0;
        }

        public string GenerateId(string tableName, string id, string prefix)
        {
            var code = "";
            var idx = 0;
            var query = $"SELECT IFNULL(MAX(SUBSTRING({id}, 3, 4)), 0) as {id} from {tableName}";
            var dtTbl = dbConnection.ExecWithQuery(query);

            if (dtTbl.Rows.Count > 0)
                foreach (DataRow tmp in dtTbl.Rows)
                    idx = Convert.ToInt32(tmp[id].ToString());

            if (idx >= 0 && idx <= 8)
                code = prefix + "00" + Convert.ToInt32(idx + 1);
            else if (idx >= 9 && idx <= 98)
                code = prefix + "0" + Convert.ToInt32(idx + 1);
            else if (idx >= 99 && idx <= 998)
                code = prefix + Convert.ToInt32(idx + 1);

            return code
                ;
        }

        public DataTable Select(string tableName, string param)
        {
            var query1 = $"SELECT GROUP_CONCAT(column_name ORDER BY ordinal_position) as concat " +
                $"FROM information_schema.columns WHERE table_schema = DATABASE() and table_name = '{tableName}' " +
                $"GROUP BY table_name ORDER BY table_name";
            var dTbl1 = dbConnection.ExecWithQuery(query1);
            if (dTbl1.Rows.Count <= 0) return new DataTable(null);

            var concat = dTbl1.Rows[0];

            var query2 = $"SELECT * FROM {tableName} WHERE concat_ws({concat["concat"]}) like '%{param}%'";
            var dTbl2 = dbConnection.ExecWithQuery(query2);

            if (dTbl2.Rows.Count > 0)
                return dTbl2;
            return new DataTable(null);
        }

        public DataTable SelectAll(string tableName)
        {
            var query2 = "SELECT * FROM " + tableName;
            var dTbl2 = dbConnection.ExecWithQuery(query2);

            return dTbl2.Rows.Count > 0 ? dTbl2 : new DataTable(null);
        }

        public bool Insert(string tableName, Dictionary<string, string> data)
        {
            var insertOk = false;
            var column = "";
            var value = "";
            var count = 1;

            foreach (var val in data)
            {
                if (count != data.Count)
                {
                    column += val.Key + ",";
                    value += "'" + SqlEscape(val.Value.ToString()) + "',";
                }
                else
                {
                    column += val.Key;
                    value += "'" + SqlEscape(val.Value.ToString()) + "'";
                }

                count++;
            }

            var query = $"INSERT INTO {tableName} ({column}) VALUES ({value})";
            if (dbConnection.ExecNonQuery(query) > 0) insertOk = true;

            return insertOk;
        }

        public bool Update(string tableName, Dictionary<string, object> data, Dictionary<string, object> where)
        {
            var updateOk = false;
            var column = "";
            var count = 1;

            foreach (var val in data)
            {
                if (count != data.Count)
                    column += val.Key + " = '" + SqlEscape(val.Value.ToString()) + "', ";
                else
                    column += val.Key + " = '" + SqlEscape(val.Value.ToString()) + "' ";
                count++;
            }

            var query = $"UPDATE {tableName} SET {column} WHERE {where.First().Key} = \'{where.First().Value}\'";
            if (dbConnection.ExecNonQuery(query) > 0) updateOk = true;

            return updateOk;
        }

        public bool Delete(string tableName, Dictionary<string, object> where)
        {
            var deleteOk = false;

            var query = $"DELETE FROM {tableName} WHERE {where.First().Key} = \'{where.First().Value}\'";
            if (dbConnection.ExecNonQuery(query) > 0) deleteOk = true;

            return deleteOk;
        }

        public DataTable ExecWithQuery(string query)
        {
            var dTbl = dbConnection.ExecWithQuery(query);

            return dTbl.Rows.Count > 0 ? dTbl : new DataTable(null);
        }

        public bool ExecNonQuery(string query)
        {
            return dbConnection.ExecNonQuery(query) > 0;
        }
    }
}