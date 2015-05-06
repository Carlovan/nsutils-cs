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
            BinaryHeap b = new BinaryHeap(new int[]{2, 8, 6, 15, 7, 5, 4, 3, 1});
            b.Print();

            b.Push(20);
            Console.WriteLine();

            b.Print();


            Console.ReadKey();
        }
    }
}
