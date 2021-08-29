using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using DataBaseLibrary;

namespace DisconnectedArchitecture_DML_App
{
    class Program
    {
        EmpDataStore dataStore;

        public Program()
        {
            dataStore = new EmpDataStore(ConfigurationManager.ConnectionStrings["TrainingConnection"].ConnectionString);
        }

        static void Main(string[] args)
        {

            string input;
            do
            {
                Console.WriteLine("\nChoose operation to be performed");
                Console.WriteLine("1. Display all employees");
                Console.WriteLine("2. Display employee details");
                Console.WriteLine("3. Insert new employee record");
                Console.WriteLine("4. Update existing employee record");
                Console.WriteLine("5. Delete employee record");
                int i = Convert.ToInt32( Console.ReadLine() );

                Program program = new Program();

                switch(i)
                {
                    case 1:
                        program.DisplayAllEmps();
                        break;
                    case 2:
                        program.DisplayEmpByNo();
                        break;
                    case 3:
                        program.AddEmp();
                        break;
                    case 4:
                        program.UpdateEmp();
                        break;
                    case 5:
                        program.DeleteEmp();
                        break;
                }

                Console.WriteLine("\nPress y to continue");
                input = Console.ReadLine();
            }
            while (input == "y");
;        }

        public void DisplayAllEmps()
        {
            try
            {
                IEnumerable<Employee> enumerable = dataStore.GetAllEmployees();

                foreach (Employee e in enumerable)
                {
                    Console.WriteLine(e.ToString());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void DisplayEmpByNo()
        {
            try
            {
                Console.WriteLine("Enter employee number");
                int eno = Convert.ToInt32(Console.ReadLine());
                Employee emp = dataStore.GetEmployeeByNo(eno);
                if (emp != null)
                {
                    Console.WriteLine(emp.ToString());
                }
                else
                {
                    Console.WriteLine("No such employee exists");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void AddEmp()
        {
            try
            {
                string input;
                Employee employee = new Employee();

                Console.WriteLine("Enter employee number");
                input = Console.ReadLine();
                if (!string.IsNullOrEmpty(input))
                {
                    employee.EmpNo = Convert.ToInt32(input);
                }
                else
                {
                    throw new Exception("Employee number cannot be null");
                }

                Console.WriteLine("Enter employee name");
                employee.EmpName = string.IsNullOrEmpty((input = Console.ReadLine())) ? null : input;
                Console.WriteLine("Enter employee hiredate");
                employee.HireDate = string.IsNullOrEmpty(input = Console.ReadLine()) ? (DateTime?)null : Convert.ToDateTime(input);
                Console.WriteLine("Enter employee salary");
                employee.Salary = string.IsNullOrEmpty(input = Console.ReadLine()) ? (decimal?)null : Convert.ToDecimal(input);

                Console.WriteLine(dataStore.InsertEmployee(employee) + " rows affected");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void DeleteEmp()
        {
            try
            {
                Console.WriteLine("Enter employee number");
                int eno = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine(dataStore.DeleteEmployee(eno) + "rows affected");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void UpdateEmp()
        {
            try
            {
                string input;
                Employee employee = new Employee();

                Console.WriteLine("Enter employee number of the employee whose record needs to be updated");
                input = Console.ReadLine();
                employee.EmpNo = Convert.ToInt32(input);
                Console.WriteLine("Enter updated employee name");
                employee.EmpName = string.IsNullOrEmpty((input = Console.ReadLine())) ? null : input;
                Console.WriteLine("Enter updated employee hiredate");
                employee.HireDate = string.IsNullOrEmpty(input = Console.ReadLine()) ? (DateTime?)null : Convert.ToDateTime(input);
                Console.WriteLine("Enter updated employee salary");
                employee.Salary = string.IsNullOrEmpty(input = Console.ReadLine()) ? (decimal?)null : Convert.ToDecimal(input);

                Console.WriteLine(dataStore.UpdateEmployee(employee) + " rows affected");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

    }
}
