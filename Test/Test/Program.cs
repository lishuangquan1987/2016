using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Person p = new Person() { Name = "li", Age = 50 };
            Person1 p1 = (Person1)p;
        }
    }
    public class Person
    {
        public int Age;
        public string Name;
    }
    public class Person1 : Person
    { }
    public class Person2 : Person
    { }
}
