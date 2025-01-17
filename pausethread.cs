using System;
using System.Threading; 

namespace MyApp
{
    public class pausingThreads
    {
        public static void Main(string[] args)
        {
           var sleepingThread = new Thread(pausingThreads.SleepInd); 
           sleepingThread.Name = "Sleeper"; 
           sleepingThread.Start(); 
           Thread.Sleep(1000);
           sleepingThread.Interrupt();

           Thread.Sleep(1000); 

         sleepingThread = new Thread(pausingThreads.SleepInd); 
           sleepingThread.Name = "Sleeper2"; 
           sleepingThread.Start(); 
           Thread.Sleep(1000);
           sleepingThread.Abort();

        }

        private static void SleepInd()
        { 
            Console.WriteLine("Thread is about to sleep", Thread.CurrentThread.Name);

            try { 
                Thread.Sleep(Timeout.Infinite); 
            } 
            catch (ThreadInterruptedException) { 
                Console.WriteLine("Current Thread has been awoken", Thread.CurrentThread.Name);
            }

            finally 
            {
                Console.WriteLine("Current thread executing block", Thread.CurrentThread.Name); 

            }
            Console.WriteLine("Current thread has finished normal execution", Thread.CurrentThread.Name); 
            Console.WriteLine();
        }
    }
}
