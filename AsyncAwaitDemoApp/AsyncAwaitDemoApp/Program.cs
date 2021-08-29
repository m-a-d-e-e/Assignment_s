using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncAwaitDemoApp
{
    class Program
    {
        static void Main(string[] args)
        {
            DoSynchronousWork();
            var someTask = DoSomethingAsync();
            DoSynchronousWorkAfterAwait();
            someTask.Wait();
            Console.ReadLine();
        }

        public static void DoSynchronousWork()
        { 
            Console.WriteLine("1. Doing some work synchronously");
        }

        static async Task DoSomethingAsync()
        {
            Console.WriteLine("2. Inside DoSomethingAsync method");         
            Task<int> task = LongRunningOperation();
            Console.WriteLine("3. In the DoSomethingAsync method - Do something else while LongRunningOperation completes");
            Console.WriteLine("4. Until here the code executes synchronously... After that wait for LongRunningOperation to complete ");
            int x = await task;
            Console.WriteLine("5. LongRunningOperation completed and returned --> " + x);
            Console.WriteLine("6. Reached the last line of DoSomethingAsync method... its execution has been completed");
        }


        static async Task<int> LongRunningOperation()
        {
            await Task.Delay(2000);
            return 1;
        }

        static void DoSynchronousWorkAfterAwait()
        {
            Console.WriteLine("7. Inside  DoSynchronousWorkAfterAwait method ");
            Console.WriteLine("8. While waiting for the async task to finish, we can do some unrelated work...");
            for (var i = 0; i <= 5; i++)
            {
                for (var j = i; j <= 5; j++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }

        }
    }
}
