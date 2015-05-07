using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSUtils
{
	public class BinaryHeap<T> where T: IComparable<T>
	{
		private List<T> tree;
		private Func<T, T, bool> comparator;
		public int Count;

		public BinaryHeap(T[] elements = null, Func<T, T, bool> comparison = null)
		{
			if (elements == null)
				elements = new T[0];
			if (comparison == null)
				comparison = Max;

			tree = new List<T>(elements);
			Count = tree.Count;
			comparator = comparison;
			balance();
		}

		public T Top()
		{
			return tree[0];
		}

		public void Pop()
		{
			tree[0] = tree[Count - 1];
			Count--;
			heapify(0);
		}

		public void Push(T n)
		{
			if (Count == tree.Count)
				tree.Add(n);
			else
				tree[Count] = n;
			Count++;

			balance();
		}

		public bool IsEmpty()
		{
			return Count == 0;
		}

		static public bool Max(T a, T b)
		{
			return a.CompareTo(b) < 0;
		}

		static public bool Min(T a, T b)
		{
			return a.CompareTo(b) > 0;
		}

		private void balance()
		{
			for (int i = Count - 1; i >= 0; i--)
			{
				heapify(i);
			}
		}

		private void heapify(int n)
		{
			T temp;

			T max = tree[n];
			if (2 * n + 1 < Count)
			{
				if (comparator(max, tree[2 * n + 1]))
					max = tree[2 * n + 1];
			}
			if (2 * n + 2 < Count)
			{
				if (comparator(max, tree[2 * n + 2]))
					max = tree[2 * n + 2];
			}

			if (max.CompareTo(tree[n]) == 0)
				return;

			if (max.CompareTo(tree[2 * n + 1]) == 0)
			{
				temp = tree[n];
				tree[n] = tree[2 * n + 1];
				tree[2 * n + 1] = temp;

				heapify(2 * n + 1);
				return;
			}

			temp = tree[n];
			tree[n] = tree[2 * n + 2];
			tree[2 * n + 2] = temp;
			heapify(2 * n + 2);
		}

		public void Print()
		{
			for (int i = 0, m = 1; i < Count; m *= 2)
			{
				int t = i;
				for (; i < t + m && i < Count; i++)
				{
					Console.Write("{0} ", tree[i]);
				}
				Console.WriteLine();
			}
		}
	}
}
