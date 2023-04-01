using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string s = "";
            int a = 0;
            int b = 0;
            Console.WriteLine("Please input an integer number: ");
            s = Console.ReadLine();
            a = Int32.Parse(s);
            Console.WriteLine("Please input another integer number: ");
            s = Console.ReadLine();
            b = Int32.Parse(s);
            Console.WriteLine("a = {0}, b = {1}, a + b = {2}", a, b, a + b);
            Console.ReadKey();
        }
    }
}
