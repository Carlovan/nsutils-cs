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
            int n = 64;
            Console.WriteLine(Math.PI.FirstDigit());
            Console.WriteLine(((double)n).LastDigit());
            Console.WriteLine(NSMath.Log2(2));
            
            Console.ReadKey();
             
        }
    }
}
