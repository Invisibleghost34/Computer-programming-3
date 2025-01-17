using System;
using System.Threading; 

namespace MyApp
{
    internal class Program
    {
        static void Main(string[] args)
        {

           
           Thread mainThread = Thread.CurrentThread; 
           mainThread.Name = "Main Thread"; 
           Console.WriteLine(mainThread.Name); 

            Thread thread1 = new Thread(() => CountDown("Timer #1")); 
            Thread thread2 = new Thread(() => CountUp("Timer #2")); 
            Thread thread3 = new Thread(()=> Add(5, 5)); 
            thread1.Start(); 
            thread2.Start(); 
            thread3.Start(); 

           //CountDown(); 
           //CountUp(); 

           Console.WriteLine(mainThread.Name + "Task is complete"); 

           Console.ReadKey(); 
        }

        public static void CountDown(String name) { 
            for(int i = 10; i >= 0; i--) { 
                Console.WriteLine("System time:" + i + "seconds");
                Thread.Sleep(100);  
            }
            Console.WriteLine("Timer is complete"); 
        }

        public static void CountUp(String name) { 
            for(int i = 0; i <= 10; i++) { 
                Console.WriteLine("System time#2:" + i + "seconds");
                Thread.Sleep(100);  
            }
            Console.WriteLine("Timer is complete"); 
        }

        public static void Add(int a, int b) { 
            for(int i = 0; i <10; i++) { 
                Console.WriteLine(a + b); 
                Thread.Sleep(100); 
            }
            Console.WriteLine("Thread completed"); 
        }
    }
}