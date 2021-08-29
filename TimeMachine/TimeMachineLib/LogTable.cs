using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace TimeMachineLib
{
    public class LogTable
    {
        SqlConnection connection;
        SqlCommand command;
        
        public LogTable(string connStr)
        {
            connection = new SqlConnection(connStr);
        }

        public int InsertLog(string str)
        {
            try
            {
                string sql = "INSERT INTO LOG VALUES (@str)";
                command = new SqlCommand(sql, connection);

                command.Parameters.AddWithValue("@str", str);
               

                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }

                int count = command.ExecuteNonQuery();

                return count;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }
    }
}
