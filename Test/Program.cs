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
            Bin a = new Bin(NSConsole.ReadLine("Inserisci un numero binario:\t"));
            Console.WriteLine(a);
            Console.WriteLine("Numero bit:\t\t"+a.Length);
            Console.WriteLine("Conversione decimale:\t" + Bin.ToInt(a));
            
            Console.ReadKey();
        }
    }
}
