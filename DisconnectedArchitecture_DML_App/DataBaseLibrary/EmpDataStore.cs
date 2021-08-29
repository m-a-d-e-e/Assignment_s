using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DataBaseLibrary
{
    public class EmpDataStore
    {
        SqlConnection connection ;
        SqlDataAdapter adapter;
        DataSet dataSet;
        SqlCommandBuilder builder;

        public EmpDataStore(string connStr)
        {
            connection = new SqlConnection(connStr);
            string sql = "select * from emp";
            adapter = new SqlDataAdapter(sql, connection);
            dataSet = new DataSet();
            adapter.Fill(dataSet, "emp");
            builder = new SqlCommandBuilder(adapter);
        }

        public List<Employee> GetAllEmployees()
        {
            try
            {
                List<Employee> employees = new List<Employee>();
                foreach (DataRow row in dataSet.Tables["emp"].Rows)
                {
                    Employee emp = new Employee();
                    emp.EmpNo = (int)row["EMPNO"];
                    emp.EmpName = (string)row["ENAME"];
                    emp.HireDate = row["HIREDATE"] as DateTime?;
                    emp.Salary = row["SAL"] as decimal?;
                    employees.Add(emp);
                }
                return employees;
            }
            catch(Exception)
            {
                throw;
            }
            
        }

        public Employee GetEmployeeByNo(int eno)
        {
            try
            {
                DataRow row = dataSet.Tables["emp"].Select($"EMPNO = {eno}").First();

                Employee emp = new Employee();
                emp.EmpNo = (int)row["EMPNO"];
                emp.EmpName = (string)row["ENAME"];
                emp.HireDate = row["HIREDATE"] as DateTime?;
                emp.Salary = row["SAL"] as decimal?;

                return emp;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int InsertEmployee(Employee emp )
        {
            try
            {
                DataRow row = dataSet.Tables["emp"].NewRow();
                row["EMPNO"] = emp.EmpNo;
                row["ENAME"] = emp.EmpName;
                row["HIREDATE"] = emp.HireDate;
                row["SAL"] = emp.Salary;
                dataSet.Tables["emp"].Rows.Add(row);
                int i = adapter.Update(dataSet.Tables["emp"]);
                return i;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int UpdateEmployee(Employee emp)
        {
            try
            {
                DataRow updateRow = dataSet.Tables["emp"].Select($"EMPNO = {emp.EmpNo}").First();
                updateRow["ENAME"] = emp.EmpName;
                updateRow["HIREDATE"] = emp.HireDate;
                updateRow["SAL"] = emp.Salary;
                int i = adapter.Update(dataSet.Tables["emp"]);
                return i;
            }
            catch (Exception)
            {
                throw;
            }
        }
        
        public int DeleteEmployee(int eno)
        {
            try
            {
                DataRow deleteRow = dataSet.Tables["emp"].Select($"EMPNO = {eno}").First();
                deleteRow.Delete();
                int i = adapter.Update(dataSet.Tables["emp"]);
                return i;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
