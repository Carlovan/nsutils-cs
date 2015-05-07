using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using NSUtils;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Bin a = new Bin(Console.ReadLine());
            Console.Write(a);
            Console.ReadKey();
        }
    }
}
