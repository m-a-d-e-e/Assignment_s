using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace TimeMachineLib
{
    public class EmpMasterTable
    {
        SqlConnection connection;
        SqlCommand command;
        SqlDataReader reader;

        public EmpMasterTable(string connStr)
        {
            connection = new SqlConnection(connStr);
        }

        public bool IsEmployeeExist(decimal empNo)
        {
            try
            {
                string sql = "SELECT * FROM EMPMASTER WHERE EMPID = @eno";
                command = new SqlCommand(sql, connection);

                command.Parameters.AddWithValue("eno", empNo);

                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }

                reader = command.ExecuteReader();
                reader.Read();
                if (reader.HasRows)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch(Exception)
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
