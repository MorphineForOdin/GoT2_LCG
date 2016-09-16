using System;

namespace GotLcg.Common.Extensions
{
    public static class StringExtensions
    {
        public static string RemoveSuffix(this string str, string suffix)
        {
            if (str == null)
            {
                throw new ArgumentNullException(nameof(str));
            }

            if (str.EndsWith(suffix))
            {
                return str.Substring(0, str.Length - suffix.Length);
            }

            return str;
        }
    }
}