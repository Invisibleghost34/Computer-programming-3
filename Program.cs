using System;
using System.Diagnostics;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using System.Threading; 
using System.Dynamic; 

namespace MyApp
{
    internal class Serialization
    {
        static void Main(string[] args)
        {
            Person person = new Person("John", 30, "password123");

#pragma warning disable SYSLIB0011 // Type or member is obsolete
            IFormatter formatter = new BinaryFormatter();
#pragma warning restore SYSLIB0011 // Type or member is obsolete
            Stream stream = new FileStream("person.bin", FileMode.Create, FileAccess.Write); 
            formatter.Serialize(stream, person); 
            stream.Close(); 

            stream = new FileStream("person.bin", FileMode.Open, FileAccess.Read); 
            Person deserializedPerson = (Person)formatter.Deserialize(stream); 
            Console.WriteLine(deserializedPerson.Name); 
            stream.Close(); 

            dynamic x = 10; 
            Console.WriteLine(x); 
            x = "apple"; 
            Console.WriteLine(x); 
            

            Console.ReadKey(); 
        }
    }
    [Serializable]
    public class Person 
    { 
        public string Name; 
        public int Age; 

        [NonSerialized]
        private string password; 

        public Person(string name, int age, string password) { 
            Name = name; 
            Age = age; 
            this.password = password; 
        }
    }
}