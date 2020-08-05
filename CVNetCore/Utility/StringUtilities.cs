using System;

namespace CVNetCore.Utility
{
    public static class StringUtilities
    {
        #region Methods

        public static int TryToExtractMonth(string coverDate)
        {
            string month = string.Empty;

            if (coverDate.IndexOf("-", StringComparison.Ordinal) <= 0)
            {
                return TryToParse(month);
            }

            month = coverDate.Substring(coverDate.IndexOf("-", StringComparison.Ordinal) + 1,
                coverDate.Length - coverDate.IndexOf("-", StringComparison.Ordinal) - 1);

            if (month.IndexOf("-", StringComparison.Ordinal) > 0)
            {
                month = month.Substring(0, month.IndexOf("-", StringComparison.Ordinal));
            }

            return TryToParse(month);
        }

        public static int TryToExtractYear(string coverDate)
        {
            string year = string.Empty;

            if (coverDate.IndexOf("-", StringComparison.Ordinal) > 0)
            {
                year = coverDate.Substring(0, coverDate.IndexOf("-", StringComparison.Ordinal));
            }

            return TryToParse(year);
        }

        public static int TryToParse(string value)
        {
            bool result = int.TryParse(value, out int number);

            if (result)
            {
                return number;
            }

            return -1;
        }

        public static float TryToParseFloat(string value)
        {
            bool result = float.TryParse(value.Replace(".", ","), out float number);
            if (result)
            {
                return number;
            }

            return -1;
        }

        #endregion
    }
}