using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ThreadDemoApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Demo demo1 = new Demo(); 
            Thread thread1 = new Thread(demo1.Print);
            Thread thread2 = new Thread(demo1.Work);
            thread1.Start();
            thread2.Start();
            thread1.Join();
            thread2.Join();
            Console.ReadLine();
        }
    }

    class Demo
    {
        public void Print()
        {
            Console.WriteLine("Printing starts.. ");
            for(int i = 0; i<10; i++)
            {
                Console.WriteLine(i );
                Thread.Sleep(500);
            }
            Console.WriteLine("Printing ends.... ");
        }

        public void Work()
        {
            Console.WriteLine("Do some work...."); 
            for (int i = 0; i < 1000; i++) ;

            Console.WriteLine("Take a break...");
            Thread.Sleep(2000);

            Console.WriteLine("Resume work....");
            for (int i = 0; i < 1000; i++) ;
            
            Console.WriteLine("Work completed !!!!");
        }
    }
}
