using System;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace NSUtils
{
    /// <summary>
    /// Some useful console methods
    /// </summary>
    public static class NSConsole
    {
        /// <summary>
        /// Read an integer number from the console
        /// </summary>
        /// <param name="msg_prompt">
        /// Text to be prompted before reading.
        /// </param>
        /// <param name="msg_error">Error message</param>
        /// <returns>Return the number read.</returns>
        public static int ReadInteger(string msg_prompt, string msg_error)
        {
            bool ok = false;
            int n;
            do
            {
                Console.Write(msg_prompt);
                ok = int.TryParse(Console.ReadLine(), out n);

                if (!ok)
                    Console.WriteLine(msg_error);
            } while (!ok);
            return n;
        }

        /// <summary>
        /// Reads a line from the console
        /// </summary>
        /// <returns></returns>
        public static string ReadLine()
        {
            return ReadLine("");
        }

        /// <summary>
        /// Read a line from the console
        /// </summary>
        /// <param name="prompt">Text to be prompted before reading</param>
        /// <returns></returns>
        public static string ReadLine(string prompt)
        {
            Console.Write(prompt);
            return Console.ReadLine();
        }
    }

    /// <summary>
    /// Represents a Prefix Tree
    /// </summary>
    public class PrefixTree
    {
        private List<SortedDictionary<char, int>> tree;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="words">List of words to save into the tree</param>
        public PrefixTree(string[] words)
        {
            tree = new List<SortedDictionary<char, int>>();
            tree.Add(new SortedDictionary<char, int>());

            foreach (string s in words)
            {
                Add(s);
            }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        public PrefixTree() : this(new string[0]) {}

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="word">A word to put into the tree</param>
        public PrefixTree(string word) : this(new string[] {word}) {}


        private int contained(int node, string word, bool prefix)
        {
            if (prefix)
            {
                if (word.Length == 0)
                    return node;
            }
            else
            {
                if (word.Length == 0)
                {
                    if (tree[node].Count == 0)
                        return node;
                    else
                        return -1;
                }
            }


            if (!tree[node].ContainsKey(word[0]))
                return -1;

            return contained(tree[node][word[0]], word.Substring(1), prefix);
        }

        private void addWord(int node, string word)
        {
            if (word.Length == 0)
                return;

            if (!tree[node].ContainsKey(word[0]))
            {
                tree[node][word[0]] = tree.Count;
                tree.Add(new SortedDictionary<char, int>());
            }

            addWord(tree[node][word[0]], word.Substring(1));
        }

        private List<string> getAll(int node)
        {
            List<string> words = new List<string>();

            for (int i = 0; i < tree[node].Count; i++)
            {
                List<string> temp;
                temp = getAll(tree[node].Values.ToArray<int>()[i]);
                foreach (string x in temp)
                {
                    words.Add(tree[node].Keys.ToArray<char>()[i] + x);
                }
            }

            if (words.Count == 0)
                words.Add("");

            return words;
        }

        /// <summary>
        /// Adds a word to the tree
        /// </summary>
        /// <param name="word">Word to add</param>
        public void Add(string word)
        {
            addWord(0, word+'\0');
        }

        /// <summary>
        /// Prints the tree structure and content to the console
        /// </summary>
        public void Print()
        {
            for(int j = 0; j < tree.Count; j++)
            {
                SortedDictionary<char, int> d = tree[j];
                Console.Write("{0}-> ", j);
                for (int i = 0; i < d.Count; i++)
                {
                    Console.Write("{0}: {1}\t", d.Keys.ToArray<char>()[i], d.Values.ToArray<int>()[i]);
                }
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Check if the tree contains the specified words
        /// </summary>
        /// <param name="word">Word to check for</param>
        /// <returns></returns>
        public bool Contains(string word)
        {
            return contained(0, word+'\0', false) != -1;
        }

        /// <summary>
        /// Check if the tree contains at least a word that starts with the specified prefix
        /// </summary>
        /// <param name="prefix">Prefix to check for</param>
        /// <returns></returns>
        public bool ContainsPrefix(string prefix)
        {
            return contained(0, prefix, true) != -1;
        }

        /// <summary>
        /// Get all the words stored in the tree
        /// </summary>
        /// <returns></returns>
        public string[] GetAll()
        {
			var strings = getAll(0).Skip(1).ToArray();
			for (int i = 0; i < strings.Length; i++)
			{
				strings[i] = strings[i].Substring(0, strings[i].Length - 1);
			}
			return strings;
        }


        /// <summary>
        /// Get all the words stored in the tree starting with the specified prefix
        /// </summary>
        /// <param name="prefix">Required prefix</param>
        /// <returns></returns>
        public string[] GetAllWithPrefix(string prefix)
        {
			if (prefix == "")
				return GetAll();

            List<string> wordsFound = new List<string>();

            int nodeEnd = contained(0, prefix, true);
            if (nodeEnd != -1)
            {
                foreach (string x in getAll(nodeEnd))
                {
                    wordsFound.Add(prefix + x);
                }
            }

			var strings = wordsFound.ToArray();
			for(int i  = 0; i < strings.Length; i++)
			{
				strings[i] = strings[i].Substring(0, strings[i].Length-1);
			}

			return strings;
        }

    }

    public static class NSString
    {
        public static string Capitalize(this string s)
        {
            s = s.ToLower();
            s = s.Substring(0, 1).ToUpper() + s.Substring(1);
            return s;
        }

        public static string CapitalizeWords(this string s, string separators = " \t\n")
        {
            bool inWord = false;
            string temp = "";
            for (int i = 0; i < s.Length; i++)
            {
                if (!separators.Contains(s[i]) && !inWord)
                {
                    inWord = true;
                    temp += s[i].ToString().ToUpper();
                }
                else
                {
                    temp += s[i];
                }

                if (separators.Contains(s[i]))
                {
                    inWord = false;
                }
            }

            return temp;
        }

        public static string TrimAndReduce(this string s)
        {
            return Regex.Replace(s, @"\s+", " ").Trim();
        }
    }

    public static class NSMath
    {
        /// <summary>
        /// Calculates the factorial of a number
        /// </summary>
        /// <param name="n">The number considered</param>
        /// <returns>Returns the int factorial</returns>
        public static int Fact(int n)
        {
            int fact=1;
            for(int i=1;i<=n;i++)
            {
                fact *= i;
            }
            return fact;
        }

        /// <summary>
        /// Calculates the (double) number converted from radians to degrees
        /// </summary>
        /// <param name="rad">The radians you want to convert</param>
        /// <returns>Returns the converted (double) number</returns>
        public static double Deg(double rad)
        {
            return rad * 180 / Math.PI;
        }

        /// <summary>
        /// Calculates the (double) number converted from degrees to radians
        /// </summary>
        /// <param name="deg">The degrees you want to convert</param>
        /// <returns>Returns the converted (double) number</returns>
        public static double Rad(double deg)
        {
            return deg * Math.PI / 180;
        }

        /// <summary>
        /// Finds a specific digit of a given number
        /// </summary>
        /// <param name="number">The given number</param>
        /// <param name="digit">The one-based wanted digit position</param>
        /// <returns>Returns the wanted digit</returns>
        public static int Digit(this Double number, int digit)
        {
            if(number.ToString().IndexOf(",") >=0 )
                return int.Parse(number.ToString().Replace(",", "")[digit-1].ToString());
            return int.Parse(number.ToString().Replace(".", "")[digit - 1].ToString());
        }

        /// <summary>
        /// Finds the first digit of a given number
        /// </summary>
        /// <param name="n">The given number</param>
        /// <returns>Returns the first digit</returns>
        public static int FirstDigit(this Double n)
        {
            return int.Parse(n.ToString()[0].ToString());
        }

        /// <summary>
        /// Finds the last digit of a given number
        /// </summary>
        /// <param name="n">The given number</param>
        /// <returns>Returns the last digit</returns>
        public static int LastDigit(this Double n)
        {
            return int.Parse(n.ToString()[n.ToString().Length-1].ToString());
        }
    }
}
