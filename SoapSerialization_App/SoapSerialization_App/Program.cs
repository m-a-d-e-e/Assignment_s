using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Soap;

// when working with soap formatter we need to add reference of the System.Runtime.Serialization.Formatters.Soap.dll assembly in our project

namespace SoapSerialization_App
{
    class Program
    {
        static void Main(string[] args)
        {
            Employee employee1 = new Employee
            {
                EmployeeId = 1,
                EmployeeName = "David",
                Department = "IT",
                Salary = 20000
            };

            Employee employee2 = new Employee
            {
                EmployeeId = 2,
                EmployeeName = "Amanda",
                Department = "IT",
                Salary = 25000
            };

            Employee employee3 = new Employee
            {
                EmployeeId = 3,
                EmployeeName = "Nick",
                Department = "IT",
                Salary = 30000
            };

            FileStream stream = new FileStream(@"C:\Users\Madeeha.Shaikh\source\repos\Training (Bhavana maam)\File IO\Employees.xml", FileMode.Create, FileAccess.Write);
            SoapFormatter formatter = new SoapFormatter();
            formatter.Serialize(stream, new Employee[] { employee1, employee2, employee3 });
            stream.Close();


            stream = new FileStream(@"C:\Users\Madeeha.Shaikh\source\repos\Training (Bhavana maam)\File IO\Employees.xml", FileMode.Open, FileAccess.Read);
            Employee[] allEmps = (Employee[])formatter.Deserialize(stream);
            foreach (Employee emp in allEmps)
            {
                Console.WriteLine(emp.EmployeeId + "\t" + emp.EmployeeName + "\t" + emp.Department /*+ "\t" + emp.Salary*/);
            }
            stream.Close();

            Console.ReadLine();
        }
    }

    [Serializable]
    class Employee
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string Department { get; set; }
        public double Salary { get; set; }

        //public string newProp { get; set; }

    }
}
