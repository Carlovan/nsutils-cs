using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSUtils
{
    public static class NSMath
    {
        /// <summary>
        /// Calculates the factorial of a number
        /// </summary>
        /// <param name="n">The number considered</param>
        /// <returns>Returns the int factorial</returns>
        public static int Fact(int n)
        {
            int fact = 1;
            for (int i = 1; i <= n; i++)
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
            if (number.ToString().IndexOf(",") >= 0)
                return int.Parse(number.ToString().Replace(",", "")[digit - 1].ToString());
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
            return int.Parse(n.ToString()[n.ToString().Length - 1].ToString());
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
}
