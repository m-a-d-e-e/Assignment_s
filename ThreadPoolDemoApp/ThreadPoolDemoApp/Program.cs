using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ThreadPoolDemoApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Demo demo1 = new Demo();
            ThreadPool.QueueUserWorkItem( new WaitCallback( demo1.Work));
            ThreadPool.QueueUserWorkItem( new WaitCallback( demo1.Print));
            Console.ReadLine();
        }
    }

    class Demo
    {
        public void Print(Object obj)
        {
            Console.WriteLine("Printing starts.. ");
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(i );
                Thread.Sleep(500);
            }
            Console.WriteLine("Printing ends.... ");
        }

        public void Work(Object obj)
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
