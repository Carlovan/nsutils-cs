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
            Bin arg = new Bin(8);
            Bin arg2 = new Bin(16);

            Console.WriteLine(arg + arg2);
        }
    }
}
