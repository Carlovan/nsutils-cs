using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSUtils
{
    public class Bin
    {
        protected long bits;

        /// <summary>
        /// The number of bits of the binary number
        /// </summary>
        public long Length { get { return Bin.ConvertToBinary(this.bits).Length; } }

        /// <summary>
        /// Constructor for the Bin class
        /// </summary>
        /// <param name="decimalNumber">The decimal number inserted that will be converted automatically Int32o a binary one</param>
        public Bin(long decimalNumber)
        {
            this.bits = decimalNumber;
        }

        /// <summary>
        /// Constructor for the Bin class
        /// </summary>
        /// <param name="binaryCode">The binary code (1s and 0s) that will be Int32erpreted</param>
        public Bin(string binaryCode)
        {
            if (binaryCode.Length > 63)
                throw new OverflowException("The binary code is too big");
          
            if (Bin.IsBinary(binaryCode))
                this.bits = Bin.ParseToDecimal(binaryCode);
            else
                throw new ArgumentException("The Bin class constructor requires a string of 1s and 0s or an long");
        }

        /// <summary>
        /// Constructor for the Bin class
        /// </summary>
        public Bin()
        {
            this.bits = 0;
        }
        
        /// <summary>
        /// Check if a string format is correct for binaries
        /// </summary>
        /// <param name="binaryCode">The string to be checked</param>
        /// <returns>Returns true if it's a binary string</returns>
        private static bool IsBinary(string binaryCode)
        {
            bool ok = true;
            for (int i = 0; i < binaryCode.Length && ok; i++)
            {
                ok = false;
                if (binaryCode[i] == '0' || binaryCode[i] == '1')
                    ok = true;
            }
            return ok;
        }

        /// <summary>
        /// Converts an string Binary number to a long decimal one
        /// </summary>
        /// <param name="bin">The Binary number to convert</param>
        /// <returns>Returns the long Decimal number(the converted Decimal one)</returns>
        private static long ParseToDecimal(string bin)
        {
            long summ = 0;
            for (int i = bin.Length - 1; i >= 0; i--)
                summ += (bin[i] == '1') ? (long)Math.Pow(2, bin.ToString().Length - 1 - i) : 0;
            return summ;
        }

        /// <summary>
        /// Converts an long Decimal number to a string Binary one
        /// </summary>
        /// <param name="dec">The Decimal number to convert</param>
        /// <returns>Returns the long Binary number(the converted Decimal one)</returns>
        private static string ConvertToBinary(long dec)
        {
            string s = "";
            while (dec != 0)
            {
                s += (dec % 2).ToString();
                dec /= 2;
            }
            return s.Reverse();
        }

        /// <summary>
        /// Allows the cast binary-string
        /// </summary>
        /// <returns>Returns the string of the binary code</returns>
        public override string ToString()
        {
            return Bin.ConvertToBinary(this.bits);
        }

        /// <summary>
        /// Allows the cast binary-long
        /// </summary>
        /// <param name="bin">The Bin instance to be converted</param>
        /// <returns>Returns an long containing the binary code</returns>
        public static long ToInt(Bin bin)
        {
            return bin.bits;
        }

        /// <summary>
        /// Allows the summ of 2 or more Bin objects
        /// </summary>
        static public Bin operator +(Bin bin1, Bin bin2)
        {
            return new Bin(Bin.ToInt(bin1) + Bin.ToInt(bin2));
        }

        /// <summary>
        /// Allows the summ of one Bin and one Int object
        /// </summary>
        static public Bin operator +(Bin bin, long dec)
        {
            return new Bin(Bin.ToInt(bin) + dec);
        }

        /// <summary>
        /// Allows the summ of one Bin and one Int object
        /// </summary>
        static public Bin operator +(long dec, Bin bin)
        {
            return new Bin(Bin.ToInt(bin)+ dec);
        }

        /// <summary>
        /// Allows the summ of one Bin and one String object
        /// </summary>
        static public Bin operator +(Bin bin1, string bin2)
        {
            if (!Bin.IsBinary(bin2))
                throw new ArgumentException("The + operator can't add a non-binary string to Bin. Have you tried to concatenate them? If so, you should use .ToString");
             return new Bin(Bin.ToInt(bin1) + Bin.ToInt(new Bin(bin2)));
        }

        /// <summary>
        /// Allows the summ of one Bin and one String object
        /// </summary>
        static public Bin operator +(string bin2, Bin bin1)
        {
            if (!Bin.IsBinary(bin2))
                throw new ArgumentException("The + operator can't add a non-binary string to Bin. Have you tried to concatenate them? If so, you should use .ToString");
            return new Bin(Bin.ToInt(bin1) + Bin.ToInt(new Bin(bin2)));
        }

        /// <summary>
        /// Allows the subtraction of 2 or more Bin objects
        /// </summary>
        static public Bin operator *(Bin bin1, Bin bin2)
        {
            return new Bin(Bin.ToInt(bin1) * Bin.ToInt(bin2));
        }
        /// <summary>
        /// Allows the summ of one Bin and one Int object
        /// </summary>
        static public Bin operator *(Bin bin, long dec)
        {
            return new Bin(Bin.ToInt(bin) * dec);
        }

        /// <summary>
        /// Allows the summ of one Bin and one Int object
        /// </summary>
        static public Bin operator *(long dec, Bin bin)
        {
            return new Bin(Bin.ToInt(bin) * dec);
        }

        /// <summary>
        /// Allows the summ of one Bin and one String object
        /// </summary>
        static public Bin operator *(Bin bin1, string bin2)
        {
            if (!Bin.IsBinary(bin2))
                throw new ArgumentException("The * operator can't multiply a non-binary string and a Bin. Have you tried to concatenate them? If so, you should use .ToString");
            return new Bin(Bin.ToInt(bin1) * Bin.ToInt(new Bin(bin2)));
        }

        /// <summary>
        /// Allows the summ of one Bin and one String object
        /// </summary>
        static public Bin operator *(string bin2, Bin bin1)
        {
            if (!Bin.IsBinary(bin2))
                throw new ArgumentException("The * operator can't add a non-binary string and a Bin. Have you tried to concatenate them? If so, you should use .ToString");
            return new Bin(Bin.ToInt(bin1) * Bin.ToInt(new Bin(bin2)));
        }

        /// <summary>
        /// Allows the division of 2 or more Bin objects(No floating poInt32)
        /// </summary>
        static public Bin operator /(Bin bin1, Bin bin2)
        {
            return new Bin(Bin.ToInt(bin1) / Bin.ToInt(bin2));
        }

        /// <summary>
        /// Allows the division of one Bin object and one decimal(No floating point) 
        /// </summary>
        static public Bin operator /(long dec, Bin bin)
        {
            return new Bin(dec / Bin.ToInt(bin));
        }

        /// <summary>
        /// Allows the division of one Bin object and one decimal(No floating point)
        /// </summary>
        static public Bin operator /(Bin bin, long dec)
        {
            return new Bin(Bin.ToInt(bin) / dec);
        }

        /// <summary>
        /// Allows the division of one Bin and one String object
        /// </summary>
        static public Bin operator /(string bin2, Bin bin1)
        {
            if (!Bin.IsBinary(bin2))
                throw new ArgumentException("The / operator can't divide a non-binary string with a Bin. Have you tried to concatenate them? If so, you should use .ToString");
            return new Bin(Bin.ToInt(bin1) / Bin.ToInt(new Bin(bin2)));
        }

        /// <summary>
        /// Allows the division of one Bin and one String object
        /// </summary>
        static public Bin operator /(Bin bin1, string bin2)
        {
            if (!Bin.IsBinary(bin2))
                throw new ArgumentException("The / operator can't divide a non-binary a Bin with a non-binary string. Have you tried to concatenate them? If so, you should use .ToString");
            return new Bin(Bin.ToInt(bin1) / Bin.ToInt(new Bin(bin2)));
        }

        /// <summary>
        /// Allows the subtraction between one Bin object and one decimal
        /// </summary>
        static public Bin operator -(long dec, Bin bin)
        {
            return new Bin(dec - Bin.ToInt(bin));
        }

        /// <summary>
        /// Allows the subtraction between one Bin object and one decimal
        /// </summary>
        static public Bin operator -(Bin bin1, long dec)
        {
            return new Bin(Bin.ToInt(bin1) - dec);
        }

        /// <summary>
        /// Allows the subtraction between one Bin and one String object
        /// </summary>
        static public Bin operator -(string bin2, Bin bin1)
        {
            if (!Bin.IsBinary(bin2))
                throw new ArgumentException("The - operator can't subtract a non-binary string from a Bin. Have you tried to concatenate them? If so, you should use .ToString");
            return new Bin(Bin.ToInt(bin1) - Bin.ToInt(new Bin(bin2)));
        }

        /// <summary>
        /// Allows the subtraction between one Bin and one String object
        /// </summary>
        static public Bin operator -(Bin bin1, string bin2)
        {
            if (!Bin.IsBinary(bin2))
                throw new ArgumentException("The - operator can't divide a non-binary a Bin with a non-binary string. Have you tried to concatenate them? If so, you should use .ToString");
            return new Bin(Bin.ToInt(bin1) - Bin.ToInt(new Bin(bin2)));
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
}
