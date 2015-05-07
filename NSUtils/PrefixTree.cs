using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSUtils
{
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
        public PrefixTree() : this(new string[0]) { }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="word">A word to put into the tree</param>
        public PrefixTree(string word) : this(new string[] { word }) { }


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
            addWord(0, word + '\0');
        }

        /// <summary>
        /// Prints the tree structure and content to the console
        /// </summary>
        public void Print()
        {
            for (int j = 0; j < tree.Count; j++)
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
            return contained(0, word + '\0', false) != -1;
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
            for (int i = 0; i < strings.Length; i++)
            {
                strings[i] = strings[i].Substring(0, strings[i].Length - 1);
            }

            return strings;
        }

    }
}
