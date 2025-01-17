#undef DEBUG
using System;
using System.Diagnostics;
using System.Threading; 
using System.Threading.Tasks; 

namespace Direct
{
    internal class Program
    {
        static void Main(string[] args)
        {
           DebugClass.Testing(true); 
           Console.ReadKey(); 
        }
    }

    public class DebugClass { 
        [Conditional("DEBUG")] 

        public static void Testing(bool error) { 
            if (error) Console.WriteLine("Error was occured"); 
        }
    }
}
