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
        public long Length { get { return bits.ToBinary().ToString().Length; } }

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
            bool ok = true;

            if (binaryCode.Length > 20)
                throw new OverflowException("The binary code is too big");
            for (int i = 0; i < binaryCode.Length && ok; i++)
            {
                ok = false;
                if (binaryCode[i] == '0' || binaryCode[i] == '1')
                    ok = true;
            }
            if (ok)
                this.bits = long.Parse(binaryCode).ToDecimal();
            else
                throw new ArgumentException("The Bin class constructor requires a string of 1s and 0s or an long");
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
        /// Allows the cast binary-long
        /// </summary>
        /// <param name="bin">The Bin instance to be converted</param>
        /// <returns>Returns an long containing the binary code</returns>
        public static long ToInt(Bin bin)
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
        /// Allows the summ of one Bin and one Int object
        /// </summary>
        static public Bin operator +(Bin bin, long dec)
        {
            return new Bin(Bin.ToInt(bin).ToDecimal() + dec);
        }

        /// <summary>
        /// Allows the summ of one Bin and one Int object
        /// </summary>
        static public Bin operator +(long dec, Bin bin)
        {
            return new Bin(Bin.ToInt(bin).ToDecimal() + dec);
        }

        /// <summary>
        /// Allows the summ of one Bin and one String object
        /// </summary>
        static public Bin operator +(Bin bin1, string bin2)
        {
            return new Bin(Bin.ToInt(bin1).ToDecimal() + Bin.ToInt(new Bin(bin2)).ToDecimal());
        }

        /// <summary>
        /// Allows the summ of one Bin and one String object
        /// </summary>
        static public Bin operator +(string bin2, Bin bin1)
        {
            return new Bin(Bin.ToInt(bin1).ToDecimal() + Bin.ToInt(new Bin(bin2)).ToDecimal());
        }

        /// <summary>
        /// Allows the subtraction of 2 or more Bin objects
        /// </summary>
        static public Bin operator *(Bin bin1, Bin bin2)
        {
            return new Bin(Bin.ToInt(bin1).ToDecimal() * Bin.ToInt(bin2).ToDecimal());
        }
        /// <summary>
        /// Allows the summ of one Bin and one Int object
        /// </summary>
        static public Bin operator *(Bin bin, long dec)
        {
            return new Bin(Bin.ToInt(bin).ToDecimal() * dec);
        }

        /// <summary>
        /// Allows the summ of one Bin and one Int object
        /// </summary>
        static public Bin operator *(long dec, Bin bin)
        {
            return new Bin(Bin.ToInt(bin).ToDecimal() * dec);
        }

        /// <summary>
        /// Allows the summ of one Bin and one String object
        /// </summary>
        static public Bin operator *(Bin bin1, string bin2)
        {
            return new Bin(Bin.ToInt(bin1).ToDecimal() * Bin.ToInt(new Bin(bin2)).ToDecimal());
        }

        /// <summary>
        /// Allows the summ of one Bin and one String object
        /// </summary>
        static public Bin operator *(string bin2, Bin bin1)
        {
            return new Bin(Bin.ToInt(bin1).ToDecimal() * Bin.ToInt(new Bin(bin2)).ToDecimal());
        }

        /// <summary>
        /// Allows the division of 2 or more Bin objects(No floating poInt32)
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
}
