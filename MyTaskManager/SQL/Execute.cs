using Microsoft.Data.SqlClient;
using MyTaskManager;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace MyTaskManager
{
    public class Execute
    {

        public static bool ExecuteStatementReturnBool(SqlConnection connection, string sqlStatement)
        {
            int count;
            bool success = false;
            using (var cnn = connection)
            {
                using (var command = new SqlCommand(sqlStatement, cnn))
                {
                    cnn.Open();
                    count = command.ExecuteNonQuery();
                }
            }
            if (count > 0)
            {
                success = true;
            }
            return success;
        }
        public static bool ExecuteStatementReturnBool(SqlConnection connection, string sqlStatement, Dictionary<string, string> sqlDictionary = null)
        {
            int count;
            bool success = false;
            using (var cnn = connection)
            {
                using (var command = new SqlCommand(sqlStatement, cnn))
                {
                    foreach (KeyValuePair<string, string> column in sqlDictionary)
                    {
                        if (string.IsNullOrEmpty(column.Value))
                        {
                            command.Parameters.Add(new SqlParameter(column.Key, ""));
                        }
                        else
                        {
                            command.Parameters.Add(new SqlParameter(column.Key, column.Value));
                        }
                    }
                    cnn.Open();
                    count = command.ExecuteNonQuery();
                }
            }
            if (count > 0)
            {
                success = true;
            }
            return success;
        }
        public static bool ExecuteStatementReturnBool(SqlConnection connection, string sqlStatement, List<KeyValuePair<string, string>> sqlDictionary = null)
        {
            int count;
            bool success = false;
            using (var cnn = connection)
            {
                using (var command = new SqlCommand(sqlStatement, cnn))
                {
                    foreach (KeyValuePair<string, string> column in sqlDictionary)
                    {
                        if (string.IsNullOrEmpty(column.Value))
                        {
                            command.Parameters.Add(new SqlParameter(column.Key, ""));
                        }
                        else
                        {
                            command.Parameters.Add(new SqlParameter(column.Key, column.Value));
                        }
                    }
                    cnn.Open();
                    count = command.ExecuteNonQuery();
                }
            }
            if (count > 0)
            {
                success = true;
            }
            return success;
        }
        public static DataTable ExecuteSelectReturnDT(SqlConnection connection, string sqlStatement)
        {
            DataTable dt = new DataTable();
            using (var cnn = connection)
            {
                using (var command = new SqlCommand(sqlStatement, cnn))
                {
                    cnn.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    dt.Load(reader);
                }
            }
            return dt;
        }


    }
}
