using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\Users\Administrator\Desktop\sql";
            string _path = Path.GetFileNameWithoutExtension(path);
            Console.WriteLine(_path);
            Console.Read();
        }
    }
}
