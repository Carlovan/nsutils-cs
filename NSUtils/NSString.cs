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
}