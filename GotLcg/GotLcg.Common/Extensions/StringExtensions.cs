using System;

namespace GotLcg.Common.Extensions
{
    public static class StringExtensions
    {
        public static string RemoveSuffix(this string source, string suffix)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            if (suffix == null)
            {
                throw new ArgumentNullException(nameof(suffix));
            }

            if (source.EndsWith(suffix))
            {
                return source.Substring(0, source.Length - suffix.Length);
            }

            return source;
        }
    }
}