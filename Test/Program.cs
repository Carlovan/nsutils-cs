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
            Bin n1 = new Bin(100);
            Bin n2 = new Bin(1);
            Bin n3 = new Bin(10);
            int n = 5;

            Console.WriteLine(n3+n2*n1);
            

            Console.ReadKey();
        }
    }
}
