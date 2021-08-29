using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace TimeMachineLib
{
    public class TimeMachine
    {
        SqlConnection connection;
        SqlCommand command;
        SqlDataReader reader;

        public TimeMachine(string connStr)
        {
            connection = new SqlConnection(connStr);
        }

        public List<decimal> GetLateComers(DateTime date)
        {
            try
            {
                List<decimal> lateComers = new List<decimal>();

                string sql = "SELECT EMPID FROM EMPMASTER WHERE EMPID NOT IN " +
                    "(SELECT EMPID FROM TIMEMACHINE WHERE OPERATION = 'ENTRY' AND CAST(DATETRANS AS DATE) = @date AND CAST(DATETRANS AS TIME) < '09:30:00') " +
                    "AND EMPID NOT IN (SELECT EMPID FROM EMPMASTER WHERE EMPID NOT IN (SELECT DISTINCT (EMPID) FROM TIMEMACHINE WHERE CAST(DATETRANS AS DATE) = @date )) ";
                
                command = new SqlCommand(sql, connection);

                command.Parameters.AddWithValue("date", date.Date);

                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }

                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    lateComers.Add((decimal)reader["EMPID"]);
                }
                return lateComers;
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


        public List<decimal> GetLateDepartures(DateTime date)
        {
            try
            {
                List<decimal> lateDepartures = new List<decimal>();

                string sql = "SELECT EMPID FROM TIMEMACHINE WHERE OPERATION = 'EXIT' AND CAST(DATETRANS AS DATE) = @date AND CAST(DATETRANS AS TIME) > '19:30:00' ";
                command = new SqlCommand(sql, connection);

                command.Parameters.AddWithValue("date", date.Date);

                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }

                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    lateDepartures.Add((decimal)reader["EMPID"]);
                }
                return lateDepartures;
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


        public List<decimal> GetAbsentees(DateTime date)
        {
            try
            {
                List<decimal> absentees = new List<decimal>();

                string sql = "SELECT EMPID FROM EMPMASTER WHERE EMPID NOT IN (SELECT DISTINCT (EMPID) FROM TIMEMACHINE WHERE CAST(DATETRANS AS DATE) = @date ) ";
                command = new SqlCommand(sql, connection);

                command.Parameters.AddWithValue("date", date.Date);

                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }

                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    absentees.Add((decimal)reader["EMPID"]);
                }
                return absentees;
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


        public int InsertRecord(Transact transact)
        {
            try
            {
                string sql = "INSERT INTO TIMEMACHINE VALUES (@gateno, @transno, @empid, @datetrans, @op)";
                command = new SqlCommand(sql, connection);
              
                command.Parameters.AddWithValue("@gateno", transact.GateNo);
                command.Parameters.AddWithValue("@transno", transact.TransNo);
                command.Parameters.AddWithValue("@empid", transact.EmpId);
                command.Parameters.AddWithValue("@datetrans", transact.DT);
                command.Parameters.AddWithValue("@op", transact.Opertion);


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
