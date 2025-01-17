using System;
using System.Diagnostics; 
using System.Threading; 

namespace Atrributes
{
    internal class Program
    {
        static void Main(string[] args)
        {
           DebugClass.Testing(true); 

           Type type = typeof(MyClass); 
           var attributes = type.GetCustomAttributes(typeof(MyCustomAttribute), false); 

           if(attributes.Length > 0 ) { 
            MyCustomAttribute attr = (MyCustomAttribute)attributes[0]; 
            Console.WriteLine($"Attribute Info: {attr.Info}"); 

           }
           MyClass mm = new MyClass(); 
           mm.Mymethod(); 
           Console.ReadKey(); 
        }
    }

    public class DebugClass { 
        [Conditional("DEBUG")] 

        public static void Testing(bool error) { 
            if (error) Console.WriteLine("Error was occured"); 
        }
    }

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Interface)] 

    public class MyCustomAttribute : Attribute { 
        public string Info {get;}

        public MyCustomAttribute(string info) { 
            Info = info;
        }
    }

    [MyCustomAttribute("This is a custom attribute applied to a class")]

    public class MyClass { 
        public void Mymethod() { 
            Console.WriteLine("Method inside Myclass"); 
        }
    }

    [MyCustomAttribute("This is a custom attribute applied to a class")]

    public interface IMyinterface 
    { 
        void InterfaceMethod(); 
    }

}