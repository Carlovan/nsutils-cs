using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NSUtils;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            


            string[] l = { "ciao", "cacca", "cielo", "minestra", "ciaone"};
            PrefixTree t = new PrefixTree(l);

			t.Print();

            foreach (string x in t.GetAllWithPrefix("ci"))
            {
                Console.WriteLine(x);
            }

            Console.ReadKey();
        }
    }
}
