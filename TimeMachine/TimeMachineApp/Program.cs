using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using TimeMachineLib;

namespace TimeMachineApp
{
    class Program
    {
        string connStr;

        public Program()
        {
            connStr = ConfigurationManager.ConnectionStrings["TrainingConnection"].ConnectionString;
        }
        static void Main(string[] args)
        {
            Program program = new Program();
            TimeMachine machine = new TimeMachine(program.connStr);
            LogTable log = new LogTable(program.connStr);
            List<Transact> listTransacts = new List<Transact>();

            

            string path1 = @"C:\Users\Madeeha.Shaikh\source\repos\Training (Bhavana maam)\TimeMachine\Gate1.txt";
            string path2 = @"C:\Users\Madeeha.Shaikh\source\repos\Training (Bhavana maam)\TimeMachine\Gate2.txt";


            string input;
            do
            {
                Console.WriteLine("1. List late comers for a particular date");
                Console.WriteLine("2. List late departures for a particular date");
                Console.WriteLine("3. List absentees for a particular date");
                Console.WriteLine("4. Execute data collector routine.");

                
                DateTime date;

                int n = Convert.ToInt32( Console.ReadLine());

                switch (n)
                {
                    case 1:
                        Console.WriteLine("Enter date");
                        date = Convert.ToDateTime(Console.ReadLine());
                        List<decimal> employees = machine.GetLateComers(date);
                        Console.WriteLine("List of late comers------");
                        foreach (decimal empId in employees)
                        {
                            Console.WriteLine(empId);
                        }

                        break;

                    case 2:
                        Console.WriteLine("Enter date");
                        date = Convert.ToDateTime(Console.ReadLine());
                        employees = machine.GetLateDepartures(date);
                        Console.WriteLine("List of late departures------");
                        foreach (decimal empId in employees)
                        {
                            Console.WriteLine(empId);
                        }

                        break;

                    case 3:
                        Console.WriteLine("Enter date");
                        date = Convert.ToDateTime(Console.ReadLine());
                        employees = machine.GetAbsentees(date);
                        Console.WriteLine("List of absentees------");
                        foreach (decimal empId in employees)
                        {
                            Console.WriteLine(empId);
                        }

                        break;

                    case 4:
                        DataCollector dataCollector1 = new DataCollector(listTransacts, "Gate1.txt", path1, log);
                        dataCollector1.ValidateRecords(program.connStr);

                        DataCollector dataCollector2 = new DataCollector(listTransacts, "Gate2.txt", path2, log);
                        dataCollector2.ValidateRecords(program.connStr);

                        Console.WriteLine("Valid entries -------");
                        foreach (var item in listTransacts)
                        {
                            Console.WriteLine(item.ToString());
                        }

                        break;
                }

                Console.WriteLine("Press y to continue");
                input = Console.ReadLine();
            }
            while (input=="y");


        }
    }
}
