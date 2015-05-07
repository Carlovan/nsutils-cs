using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSUtils
{
    public static class Convert
    {
        /// <summary>
        /// Converts an long Decimal number to a Binary decimal one
        /// </summary>
        /// <param name="dec">The Decimal number to convert</param>
        /// <returns>Returns the long Binary number(the converted Decimal one)</returns>
        public static long ToBinary(this long dec)
        {
            string s = "";
            while (dec != 0)
            {
                s += (dec % 2).ToString();
                dec /= 2;
            }
            return long.Parse(s.Reverse());
        }

        /// <summary>
        /// Converts an long Binary number to a Decimal decimal one
        /// </summary>
        /// <param name="bin">The Binary number to convert</param>
        /// <returns>Returns the long Decimal number(the converted Decimal one)</returns>
        public static long ToDecimal(this long bin)
        {
            long summ = 0;
            for (int i = bin.ToString().Length - 1; i >= 0; i--)
                summ += (bin.ToString()[i] == '1') ? (long)Math.Pow(2, bin.ToString().Length - 1 - i) : 0;
            return summ;
        }
    }
}
