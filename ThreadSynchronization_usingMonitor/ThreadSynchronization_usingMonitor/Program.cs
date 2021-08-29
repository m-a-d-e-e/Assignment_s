using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ThreadSynchronization_usingMonitor
{
    class Program
    {
        static void Main(string[] args)
        {
            Program program = new Program();

            Thread t1 = new Thread(program.PrintNumbers);
            Thread t2 = new Thread(program.PrintNumbers);
            t1.Start();
            t2.Start();

            t1.Join();
            t2.Join();

            Console.ReadLine();
        }

        public void PrintNumbers()
        {
            try
            {
                Monitor.Enter(this);

                Console.WriteLine("Printing numbers from 1 to 10...");
                for (int i = 1; i <= 10; i++)
                {
                    Thread.Sleep(300);
                    Console.Write(i + "\t");
                }
                Console.WriteLine();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Monitor.Exit(this);
            }
        }
        
    }
}
