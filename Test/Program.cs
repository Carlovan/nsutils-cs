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
            Bin n1 = new Bin(NSConsole.ReadLine("Inserisci un numero binario:\t"));
            Bin mult = new Bin(2);

            Console.WriteLine("Numero inserito(bin):\t{0}", n1);
            Console.WriteLine("Numero inserito(dec):\t{0}", Bin.ToInt(n1).ToDecimal());

            Bin p = n1 * mult;
            Console.WriteLine("n * 2 =\t\t{0}", p);

            p = n1 / mult;
            Console.WriteLine("n / 2 =\t\t{0}", p);

            Console.WriteLine((n1 > p) ? "Un numero è maggiore della sua metà..." : "");
            Console.WriteLine((n1 == n1) ? "Un numero è uguale a se stesso MA VA" : "");

            Console.WriteLine("\nMSB of 1010 = {0}", NSMath.MostSignificantBit(10));
            Console.WriteLine("\nLSB of 1010 = {0}", NSMath.LeastSignificantBit(10));

            Console.ReadKey();
        }
    }
}
