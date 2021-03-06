#nullable enable
using System;

namespace CVNetCore.Utility
{
    public static class StringUtilities
    {
        #region Methods

        /// <summary>
        ///     Extract the Month information from a ComicVine Date field
        /// </summary>
        /// <param name="date">Date field to parse</param>
        /// <returns>The Month extracted from the Date field if parsed successfully, -1 if parsing failed,</returns>
        public static int ExtractMonth(string? date)
        {
            if (date == null || date.IndexOf("-", StringComparison.Ordinal) <= 0)
            {
                return -1;
            }

            string month = date.Substring(date.IndexOf("-", StringComparison.Ordinal) + 1,
                date.Length - date.IndexOf("-", StringComparison.Ordinal) - 1);

            if (month.IndexOf("-", StringComparison.Ordinal) > 0)
            {
                month = month.Substring(0, month.IndexOf("-", StringComparison.Ordinal));
            }
            else
            {
                return -1;
            }

            int result = TryToParse(month);

            // Sanity Check
            if (result < 1 || result > 12)
            {
                return -1;
            }

            return result;
        }

        /// <summary>
        ///     Extract the Year information from a ComicVine Date field
        /// </summary>
        /// <param name="date">Date field to parse</param>
        /// <returns>The Year extracted from the Date field</returns>
        public static int ExtractYear(string? date)
        {
            if (date == null)
            {
                return -1;
            }

            string year = string.Empty;

            if (date.IndexOf("-", StringComparison.Ordinal) > 0)
            {
                year = date.Substring(0, date.IndexOf("-", StringComparison.Ordinal));
            }

            return TryToParse(year);
        }

        /// <summary>
        ///     Attempt to parse a ComicVine string field to an integer
        /// </summary>
        /// <param name="value">String to parse</param>
        /// <returns>Value of the field if parsing successful, -1 if it failed</returns>
        public static int TryToParse(string value)
        {
            bool result = int.TryParse(value, out int number);

            if (result)
            {
                return number;
            }

            return -1;
        }

        /// <summary>
        ///     Attempt to parse a ComicVine field into a float value
        /// </summary>
        /// <param name="value">String to parse</param>
        /// <returns>Value of the field if parsing successful, -1 if it failed</returns>
        public static float TryToParseFloat(string? value)
        {
            // bool result = float.TryParse(value.Replace(".", ","), out float number);
            bool result = float.TryParse(value, out float number);
            if (result)
            {
                return number;
            }

            return -1;
        }

        #endregion
    }
}