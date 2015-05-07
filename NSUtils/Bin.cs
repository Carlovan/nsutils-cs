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
