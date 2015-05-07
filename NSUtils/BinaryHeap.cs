using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSUtils
{
    /// <summary>
    /// Implementation of a binary heap, a.k.a. priority queue.
    /// </summary>
    /// <typeparam name="T"></typeparam>
	public class BinaryHeap<T> where T: IComparable<T>
	{
        // The tree container: N sons are N*2+1 and N*2+2
		private List<T> tree;
        //Method used to compare when swapping elements
		private Func<T, T, bool> comparator;
        //Number of elements
		private int count;

        public int Count { get { return count; } }
        public int Capacity { get { return tree.Count; } }
        public bool IsEmpty { get { return count == 0; } }

        /// <summary>
        /// Heap contructor.
        /// </summary>
        /// <param name="elements">Elements to use to build the heap.</param>
        /// <param name="comparison">Comparison function. This method must return true if the second elements is higher (closer to the root). Default: Max (max-heap)</param>
		public BinaryHeap(T[] elements = null, Func<T, T, bool> comparison = null)
		{
			if (elements == null)
				elements = new T[0];
			if (comparison == null)
				comparison = Max;

			tree = new List<T>(elements);
			count = tree.Count;
			comparator = comparison;
			balance();
		}

        /// <summary>
        /// Returns the top (root) of the heap.
        /// </summary>
        /// <returns></returns>
		public T Top()
		{
			return tree[0];
		}

        /// <summary>
        /// Removes the top of the heap.
        /// </summary>
		public void Pop()
		{
			tree[0] = tree[count - 1];
			count--;
			heapify(0);
		}

        /// <summary>
        /// Adds a value into the heap.
        /// </summary>
        /// <param name="n">Value to add.</param>
		public void Push(T n)
		{
            //Check if the List is full, if it isn't does't resize it
			if (count == tree.Count)
				tree.Add(n);
			else
				tree[count] = n;
            //Increment the elements count.
			count++;

            //Swaps the new element toward to balance the heap.
            for (int i = count - 1; i > 0; i = (i - 1) / 2)
            {
                if (!comparator(tree[(i - 1) / 2], tree[i]))
                {
                    break;
                }
                T temp = tree[i];
                tree[i] = tree[(i - 1) / 2];
                tree[(i - 1) / 2] = temp;
            }
		}

        /// <summary>
        /// Comparison method to get a max-heap.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
		static public bool Max(T a, T b)
		{
			return a.CompareTo(b) < 0;
		}

        /// <summary>
        /// Comparison method to get a min-heap.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
		static public bool Min(T a, T b)
		{
			return a.CompareTo(b) > 0;
		}

        /// <summary>
        /// Function to balance the heap.
        /// </summary>
		private void balance()
		{
            //Heapify every node in the tree excluding the leaves.
			for (int i = count / 2 - 1; i >= 0; i--)
			{
				heapify(i);
			}
		}

        /// <summary>
        /// Heapifies a node.
        /// </summary>
        /// <param name="n">Node to heapify.</param>
		private void heapify(int n)
		{
            //Used for swapping
			T temp;

            //The higher value, initially the current node value.
			T max = tree[n];
            //Check the first son (if it exists)
			if (2 * n + 1 < count)
			{
				if (comparator(max, tree[2 * n + 1]))
					max = tree[2 * n + 1];
			}
            //Check the second son (if it exists)
			if (2 * n + 2 < count)
			{
				if (comparator(max, tree[2 * n + 2]))
					max = tree[2 * n + 2];
			}

            //If the higher is the current node terminate
			if (max.CompareTo(tree[n]) == 0)
				return;

            //If the higher is the first son, swap and heapify the new position
			if (max.CompareTo(tree[2 * n + 1]) == 0)
			{
				temp = tree[n];
				tree[n] = tree[2 * n + 1];
				tree[2 * n + 1] = temp;

				heapify(2 * n + 1);
				return;
			}

            //Samething if the higher is the second son
			temp = tree[n];
			tree[n] = tree[2 * n + 2];
			tree[2 * n + 2] = temp;
			heapify(2 * n + 2);
		}

        /// <summary>
        /// Prints on the console the heap structure (useful for debug).
        /// </summary>
		public void Print()
		{
			for (int i = 0, m = 1; i < count; m *= 2)
			{
				int t = i;
				for (; i < t + m && i < count; i++)
				{
					Console.Write("{0} ", tree[i]);
				}
				Console.WriteLine();
			}
		}
	}
}
