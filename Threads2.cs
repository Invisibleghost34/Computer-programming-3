using System;
using System.Threading; 

namespace MyApp
{

    public delegate void Callback(int count); 
    public class Threads2
    {
        static void Main(string[] args)
        {
            // Passing data to threads 
            // ParametirezedThreadStart delegate provides and easy way to pass an object containing data
            // you can do it by calling Thread.Start(object)

            //This shall provide the thread with data 
            ThreadWithState tws = new ThreadWithState("Okabe Rintarou", 42, new Callback(ResultCallback)); 

            Thread t = new Thread(new ThreadStart(tws.ThreadProc));
            t.Start(); 
            Console.WriteLine("Main thread does work then waits"); 
            t.Join(); 
            Console.WriteLine("Independent task has been complete and the main thread ends ");

            //You can also retreive data by using certain callback methods 

            
        }

        public static void ResultCallback(int count) 
        {  
            Console.WriteLine("Independent task printed", count );
        }

        
    }

    public class ThreadWithState 
    { 
        private string name; 
        private int idNumber; 

        private Callback callback;

        //This constructor obtains the state information
        public ThreadWithState(string text, int number, Callback callbackDelegate) 
        { 
            name = text; 
            idNumber = number; 
            callback = callbackDelegate; 
            
        }
        //This method performs the task
        public void ThreadProc() 
        { 
            Console.WriteLine(name, idNumber); 
        
            if(callback != null) { 
                callback(1); 
            }
        }
    }
}
