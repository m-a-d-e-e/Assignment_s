using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ThreadSynchronization_usingManualResetEvent
{
    class Program
    {
        static ManualResetEvent manualReset = new ManualResetEvent(false);

        static void Main(string[] args)
        {
            Thread writerThread = new Thread(Write);
            Thread readerThread1 = new Thread(Read);
            Thread readerThread2 = new Thread(Read);
            Thread readerThread3 = new Thread(Read);

            //reader threads should only read when the writer thread has finished writing

            writerThread.Start();
            readerThread1.Start();
            readerThread2.Start();
            readerThread3.Start();

            Console.ReadLine();
        }


        static void Write()
        {
            Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} start writing...");
            manualReset.Reset();   //  Sets the state of the event to nonsignaled, causing threads to block.
            Thread.Sleep(5000);
            Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} writing completed...");
            manualReset.Set();     //  Sets the state of the event to signaled, allowing one or more waiting threads to proceed
        }

        static void Read()
        {
            Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} waiting to read...");
            manualReset.WaitOne();   // Blocks the current thread until the current System.Threading.WaitHandle receives a signal.
            Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} reading...");
        }
    }
}
