using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

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
	}
}
