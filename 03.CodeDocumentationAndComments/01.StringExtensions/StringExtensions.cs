//-----------------------------------------------------------------------
// <copyright file="StringExtensions.cs" company="Telerik Academy Homework">
//     Copyright (c) Telerik Academy Enterprise. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Telerik.ILS.Common
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Security.Cryptography;
    using System.Text;
    using System.Text.RegularExpressions;

    /// <summary>
    /// Class with variable methods for string extension.
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Converts input string to hexadecimal format.
        /// </summary>
        /// <param name="input">The string that is passed to the method.</param>
        /// <returns>Returns the formatted hexadecimal string.</returns>
        public static string ToMd5Hash(this string input)
        {
            var md5Hash = MD5.Create();

            // Convert the input string to a byte array and compute the hash.
            var data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            var builder = new StringBuilder();

            // Format each looped element as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                builder.Append(data[i].ToString("x2"));
            }

            return builder.ToString();
        }

        /// <summary>
        /// Compares string input with array of strings and return the matched ones.
        /// </summary>
        /// <param name="input">The string that is passed to the method.</param>
        /// <returns>Returns an array of all strings that were contained in the stringTrueValues array.</returns>
        public static bool ToBoolean(this string input)
        {
            var stringTrueValues = new[] { "true", "ok", "yes", "1", "да" };
            return stringTrueValues.Contains(input.ToLower());
        }

        /// <summary>
        /// Converts input string to short number if possible.
        /// </summary>
        /// <param name="input">The string that is passed to the method.</param>
        /// <returns>Returns the converted short number or 0 if it failed the convert.</returns>
        public static short ToShort(this string input)
        {
            short shortValue;
            short.TryParse(input, out shortValue);
            return shortValue;
        }

        /// <summary>
        /// Converts input string to integer number if possible.
        /// </summary>
        /// <param name="input">The string that is passed to the method.</param>
        /// <returns>Returns the converted integer number or 0 if it failed the convert.</returns>
        public static int ToInteger(this string input)
        {
            int integerValue;
            int.TryParse(input, out integerValue);
            return integerValue;
        }

        /// <summary>
        /// Converts input string to long number if possible.
        /// </summary>
        /// <param name="input">The string that is passed to the method.</param>
        /// <returns>Returns the converted long number or 0 if it failed the convert.</returns>
        public static long ToLong(this string input)
        {
            long longValue;
            long.TryParse(input, out longValue);
            return longValue;
        }

        /// <summary>
        /// Converts input string to DateTime format if possible.
        /// </summary>
        /// <param name="input">The string that is passed to the method.</param>
        /// <returns>Returns the converted date or 0 if it failed the convert.</returns>
        public static DateTime ToDateTime(this string input)
        {
            DateTime dateTimeValue;
            DateTime.TryParse(input, out dateTimeValue);
            return dateTimeValue;
        }

        /// <summary>
        /// Capitalize the first letter of the string and leaves the rest of the string with the same case.
        /// </summary>
        /// <param name="input">The string that is passed to the method.</param>
        /// <returns>Returns the same string with capital first letter.</returns>
        public static string CapitalizeFirstLetter(this string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return input;
            }

            return input.Substring(0, 1).ToUpper(CultureInfo.CurrentCulture) + input.Substring(1, input.Length - 1);
        }

        /// <summary>
        /// Method that gets a substring from given string.
        /// </summary>
        /// <param name="input">The string that will be processed.</param>
        /// <param name="startString">The string that marks the beginning of the wanted substring.</param>
        /// <param name="endString">The string that marks the ending of the wanted substring.</param>
        /// <param name="startFrom">
        /// Optional parameter that stands for the index from where the wanted substring starts.Default value is 0.
        /// </param>
        /// <returns>Returns the expected substring or returns empty string if the parameters are not valid.</returns>
        public static string GetStringBetween(this string input, string startString, string endString, int startFrom = 0)
        {
            input = input.Substring(startFrom);
            startFrom = 0;
            if (!input.Contains(startString) || !input.Contains(endString))
            {
                return string.Empty;
            }

            var startPosition = input.IndexOf(startString, startFrom, StringComparison.Ordinal) + startString.Length;
            if (startPosition == -1)
            {
                return string.Empty;
            }

            var endPosition = input.IndexOf(endString, startPosition, StringComparison.Ordinal);
            if (endPosition == -1)
            {
                return string.Empty;
            }

            return input.Substring(startPosition, endPosition - startPosition);
        }

        /// <summary>
        /// Method that converts string written with cyrillic alphabetic to string written with latin alphabetic.
        /// </summary>
        /// <param name="input">The input string that is passed to the method.</param>
        /// <returns>Returns the latin written string.</returns>
        public static string ConvertCyrillicToLatinLetters(this string input)
        {
            var bulgarianLetters = new[]
                                       {
                                           "а", "б", "в", "г", "д", "е", "ж", "з", "и", "й", "к", "л", "м", "н", "о", "п",
                                           "р", "с", "т", "у", "ф", "х", "ц", "ч", "ш", "щ", "ъ", "ь", "ю", "я"
                                       };
            var latinRepresentationsOfBulgarianLetters = new[]
                                                             {
                                                                 "a", "b", "v", "g", "d", "e", "j", "z", "i", "y", "k",
                                                                 "l", "m", "n", "o", "p", "r", "s", "t", "u", "f", "h",
                                                                 "c", "ch", "sh", "sht", "u", "i", "yu", "ya"
                                                             };
            for (var i = 0; i < bulgarianLetters.Length; i++)
            {
                input = input.Replace(bulgarianLetters[i], latinRepresentationsOfBulgarianLetters[i]);
                input = input.Replace(bulgarianLetters[i].ToUpper(), latinRepresentationsOfBulgarianLetters[i].CapitalizeFirstLetter());
            }

            return input;
        }

        /// <summary>
        /// Method that converts string written with latin alphabetic to string written with cyrillic alphabetic.
        /// </summary>
        /// <param name="input">The input string that is passed to the method.</param>
        /// <returns>Returns the cyrillic written string.</returns>
        public static string ConvertLatinToCyrillicKeyboard(this string input)
        {
            var latinLetters = new[]
                                   {
                                       "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p",
                                       "q", "r", "s", "t", "u", "v", "w", "x", "y", "z"
                                   };

            var bulgarianRepresentationOfLatinKeyboard = new[]
                                                             {
                                                                 "а", "б", "ц", "д", "е", "ф", "г", "х", "и", "й", "к",
                                                                 "л", "м", "н", "о", "п", "я", "р", "с", "т", "у", "ж",
                                                                 "в", "ь", "ъ", "з"
                                                             };

            for (int i = 0; i < latinLetters.Length; i++)
            {
                input = input.Replace(latinLetters[i], bulgarianRepresentationOfLatinKeyboard[i]);
                input = input.Replace(latinLetters[i].ToUpper(), bulgarianRepresentationOfLatinKeyboard[i].ToUpper());
            }

            return input;
        }

        /// <summary>
        /// Converts user input to latin alphabetic string and validate it with regular expression.
        /// </summary>
        /// <param name="input">The input string that is passed to the method.</param>
        /// <returns>Returns the validated string.</returns>
        public static string ToValidUsername(this string input)
        {
            input = input.ConvertCyrillicToLatinLetters();
            return Regex.Replace(input, @"[^a-zA-z0-9_\.]+", string.Empty);
        }

        /// <summary>
        /// Converts user input to cyrillic alphabetic string and validate it with regular expression.
        /// </summary>
        /// <param name="input">The input string that is passed to the method.</param>
        /// <returns>Returns the validated string.</returns>
        public static string ToValidLatinFileName(this string input)
        {
            input = input.Replace(" ", "-").ConvertCyrillicToLatinLetters();
            return Regex.Replace(input, @"[^a-zA-z0-9_\.\-]+", string.Empty);
        }

        /// <summary>
        /// Gets the first characters of the input string.
        /// </summary>
        /// <param name="input">The input string that is passed to the method.</param>
        /// <param name="charsCount">The number of characters to get after the start of the string.</param>
        /// <returns>Returns string cut from 0 to charsCount.</returns>
        public static string GetFirstCharacters(this string input, int charsCount)
        {
            return input.Substring(0, Math.Min(input.Length, charsCount));
        }

        /// <summary>
        /// This method gets the file extension of given directory passed as string.
        /// </summary>
        /// <param name="fileName">The input string that is passed to the method.</param>
        /// <returns>Returns string with the given file extension or returns empty string if there is not such extension.</returns>
        public static string GetFileExtension(this string fileName)
        {
            if (string.IsNullOrWhiteSpace(fileName))
            {
                return string.Empty;
            }

            string[] fileParts = fileName.Split(new[] { "." }, StringSplitOptions.None);
            if (fileParts.Count() == 1 || string.IsNullOrEmpty(fileParts.Last()))
            {
                return string.Empty;
            }

            return fileParts.Last().Trim().ToLower();
        }

        /// <summary>
        /// Method that anchors the input file extension string to the content with the same format.
        /// </summary>
        /// <param name="fileExtension">The input is file extension that is passed as string.</param>
        /// <returns>Returns the content with the given file extension or returns a default content if input is not valid.</returns>
        public static string ToContentType(this string fileExtension)
        {
            var fileExtensionToContentType = new Dictionary<string, string>
                                                 {
                                                     { "jpg", "image/jpeg" },
                                                     { "jpeg", "image/jpeg" },
                                                     { "png", "image/x-png" },
                                                     {
                                                         "docx",
                                                         "application/vnd.openxmlformats-officedocument.wordprocessingml.document"
                                                     },
                                                     { "doc", "application/msword" },
                                                     { "pdf", "application/pdf" },
                                                     { "txt", "text/plain" },
                                                     { "rtf", "application/rtf" }
                                                 };
            if (fileExtensionToContentType.ContainsKey(fileExtension.Trim()))
            {
                return fileExtensionToContentType[fileExtension.Trim()];
            }

            return "application/octet-stream";
        }

        /// <summary>
        /// Converts input string to byte array.
        /// </summary>
        /// <param name="input">The input string that is passed to the method.</param>
        /// <returns>Returns a byte array.</returns>
        public static byte[] ToByteArray(this string input)
        {
            var bytesArray = new byte[input.Length * sizeof(char)];
            Buffer.BlockCopy(input.ToCharArray(), 0, bytesArray, 0, bytesArray.Length);
            return bytesArray;
        }
    }
}
