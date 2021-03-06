﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.IO;

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
            Stream input = Console.OpenStandardInput(16383);
            byte[] bytes = new byte[16383];
            int length = input.Read(bytes, 0, 16383);
            char[] c = Encoding.UTF8.GetChars(bytes, 0, length);
            Array.Resize(ref c, c.Length - 2);
            return new String(c);
        }

        /// <summary>
        /// Read a line from the console
        /// </summary>
        /// <param name="prompt">Text to be prompted before reading</param>
        /// <returns></returns>
        public static string ReadLine(string prompt)
        {
            Console.Write(prompt);
            return NSConsole.ReadLine();
        }
    }
}
