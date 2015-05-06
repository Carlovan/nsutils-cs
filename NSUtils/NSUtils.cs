﻿using System;
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

        public static string Reverse(this String s)
        {
            char[] c = s.ToCharArray(0, s.Length);

            for(int i=0;i<s.Length/2;i++)
            {
                char tmp = c[i];
                c[i] = c[s.Length - 1 - i];
                c[s.Length - 1 - i] = tmp;
            }

            s = "";
            for (int i = 0; i < c.Length; i++)
                s += c[i];

            return s;
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

        /// <summary>
        /// Finds the logarith (base 2) of the given number
        /// </summary>
        /// <param name="n">Number used as log argument</param>
        /// <returns>Returns the logarithm(base 2) of the given number</returns>
        public static double Log2(double n)
        {
            return (Math.Log(n) / Math.Log(2));
        }
    }

    public class Bin
    {
        private int bits;

        /// <summary>
        /// The number of bits of the binary number
        /// </summary>
        public int Length { get { return bits.ToString().Length; } } 

        /// <summary>
        /// Constructor for the Bin class
        /// </summary>
        /// <param name="decimalNumber">The decimal number inserted that will be converted automatically into a binary one</param>
        public Bin(int decimalNumber)
        {
            this.bits = decimalNumber;
        }

        /// <summary>
        /// Constructor for the Bin class
        /// </summary>
        /// <param name="binaryCode">The binary code (1s and 0s) that will be interpreted</param>
        public Bin(string binaryCode)
        {
            bool ok = true;
            for (int i = 0; i < binaryCode.Length&&ok;i++ )
            {
                ok = false;
                if (binaryCode[i] == '0' || binaryCode[i] == '1')
                    ok = true;
            }
            if (ok)
                this.bits = int.Parse(binaryCode).ToDecimal();
            else
                throw new ArgumentException("The Bin class constructor requires a string of 1s and 0s or an int");
        }

        /// <summary>
        /// Allows the cast binary-string
        /// </summary>
        /// <returns>Returns the string of the binary code</returns>
        public override string ToString()
        {
            return this.bits.ToBinary().ToString();
        }

        /// <summary>
        /// Allows the cast binary-int
        /// </summary>
        /// <param name="bin">The Bin instance to be converted</param>
        /// <returns>Returns an int containing the binary code</returns>
        public static int ToInt(Bin bin)
        {
            return bin.bits.ToBinary();
        }

        /// <summary>
        /// Allows the summ of 2 or more Bin objects
        /// </summary>
        static public Bin operator +(Bin bin1, Bin bin2)
        {
            return new Bin(Bin.ToInt(bin1).ToDecimal() + Bin.ToInt(bin2).ToDecimal());
        }

        /// <summary>
        /// Allows the subtraction of 2 or more Bin objects
        /// </summary>
        static public Bin operator *(Bin bin1, Bin bin2)
        {
            return new Bin(Bin.ToInt(bin1).ToDecimal() * Bin.ToInt(bin2).ToDecimal());
        }

        /// <summary>
        /// Allows the division of 2 or more Bin objects(No floating point)
        /// </summary>
        static public Bin operator /(Bin bin1, Bin bin2)
        {
            return new Bin(Bin.ToInt(bin1).ToDecimal() / Bin.ToInt(bin2).ToDecimal());
        }

        /// <summary>
        /// Allows the product of 2 or more Bin objects
        /// </summary>
        static public Bin operator -(Bin bin1, Bin bin2)
        {
            return new Bin(Bin.ToInt(bin1).ToDecimal() - Bin.ToInt(bin2).ToDecimal());
        }

        /// <summary>
        /// Standard Equals method
        /// </summary>
        public override bool Equals(object obj)
        {
            var bin = obj as Bin;
            if (bin == null)
                return false;

            return this.bits.Equals(bin.bits);
        }

        /// <summary>
        /// standard HashCode method
        /// </summary>
        public override int GetHashCode()
        {
            return this.bits.GetHashCode();
        }

        /// <summary>
        /// Checks if two Bin objects are equals
        /// </summary>
        static public bool operator ==(Bin bin1, Bin bin2)
        {
            return Bin.ToInt(bin1) == Bin.ToInt(bin2);
        }

        /// <summary>
        /// Checks if two Bin objects aren't equals
        /// </summary>
        static public bool operator !=(Bin bin1, Bin bin2)
        {
            return Bin.ToInt(bin1) != Bin.ToInt(bin2);
        }

        /// <summary>
        /// Checks if one Bin is greater than a second one
        /// </summary>
        static public bool operator >(Bin bin1, Bin bin2)
        {
            return Bin.ToInt(bin1) > Bin.ToInt(bin2);
        }

        /// <summary>
        /// Checks if one Bin is greater or equal to a second one
        /// </summary>
        static public bool operator >=(Bin bin1, Bin bin2)
        {
            return Bin.ToInt(bin1) >= Bin.ToInt(bin2);
        }

        /// <summary>
        /// Checks if one Bin is greater than a second one
        /// </summary>
        static public bool operator <(Bin bin1, Bin bin2)
        {
            return Bin.ToInt(bin1) < Bin.ToInt(bin2);
        }

        /// <summary>
        /// Checks if one Bin is lower or equal to a second one
        /// </summary>
        static public bool operator <=(Bin bin1, Bin bin2)
        {
            return Bin.ToInt(bin1) <= Bin.ToInt(bin2);
        }
    }

    public static class Convert
    {
        /// <summary>
        /// Converts an int Decimal number to a Binary decimal one
        /// </summary>
        /// <param name="dec">The Decimal number to convert</param>
        /// <returns>Returns the int Binary number(the converted Decimal one)</returns>
        public static int ToBinary(this int dec)
        {
            string s = "";
            while(dec != 0)
            {
                s += (dec % 2).ToString();
                dec/=2;
            }
            return int.Parse(s.Reverse());
        }

        /// <summary>
        /// Converts an int Binary number to a Decimal decimal one
        /// </summary>
        /// <param name="bin">The Binary number to convert</param>
        /// <returns>Returns the int Decimal number(the converted Decimal one)</returns>
        public static int ToDecimal(this int bin)
        {
            int summ = 0;
            for (int i = bin.ToString().Length - 1; i >= 0; i--)
                summ += (bin.ToString()[i] == '1') ? (int)Math.Pow(2, bin.ToString().Length - 1 - i) : 0;
            return summ;
        }
    }
}
