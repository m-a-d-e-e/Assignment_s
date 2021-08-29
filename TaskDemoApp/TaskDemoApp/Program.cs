using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace TaskDemoApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Action<object> action = (object obj) =>
            {
                Console.WriteLine("Task={0}, obj={1}, Thread={2}",
                Task.CurrentId, obj,
                Thread.CurrentThread.ManagedThreadId);
            };


            Task t1 = new Task(action, "alpha");
            t1.Start();

           
            Task t2 = Task.Factory.StartNew(action, "beta");


            string taskData = "delta";
            Task t3 = Task.Run(() => {
                Console.WriteLine("Task={0}, obj={1}, Thread={2}",
                                  Task.CurrentId, taskData,
                                   Thread.CurrentThread.ManagedThreadId);
            });

            Console.WriteLine("Main thread---> " + Thread.CurrentThread.ManagedThreadId);

            t1.Wait();
            t2.Wait();
            t3.Wait();

            Console.ReadLine();
        }
    }
}
