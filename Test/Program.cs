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
            int n = 238;
            Console.WriteLine(Math.PI.FirstDigit());
            Console.WriteLine(((double)n).LastDigit());
            /*
            string[] l = { "ciao", "cacca", "cielo", "minestra", "ciaone"};
            PrefixTree t = new PrefixTree(l);

			t.Print();


            foreach (string x in t.GetAllWithPrefix("ci"))
            {
                Console.WriteLine(x);
            }
            */
            Console.ReadKey();
             
        }
    }
}
