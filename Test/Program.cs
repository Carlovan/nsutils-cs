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
		static bool comp(int a, int b)
		{
			return a % 2 == 0 ^ b % 2 == 0;
		}
        static void Main(string[] args)
        {
            BinaryHeap<string> b = new BinaryHeap<string>(new string[]{"d", "e", "a", "z"}, BinaryHeap<string>.Max);

			b.Print();
			Console.WriteLine();
			while (!b.IsEmpty())
			{
				Console.WriteLine(b.Top());
				b.Pop();
			}

            Console.ReadKey();
        }
    }
}
