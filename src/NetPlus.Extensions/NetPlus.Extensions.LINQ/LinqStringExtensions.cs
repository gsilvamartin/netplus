using System.Linq;

namespace NetPlus.Extensions.LINQ
{
    /// <summary>
    /// Provides extension methods for LINQ operations on strings.
    /// </summary>
    public static class LinqStringExtensions
    {
        /// <summary>
        /// Determines whether the string contains any of the specified characters.
        /// </summary>
        /// <param name="source">The string to search.</param>
        /// <param name="chars">The characters to search for.</param>
        /// <returns><c>true</c> if the string contains any of the specified characters; otherwise, <c>false</c>.</returns>
        public static bool ContainsAny(this string source, params char[] chars)
        {
            return source.IndexOfAny(chars) != -1;
        }

        /// <summary>
        /// Determines whether the string contains all of the specified characters.
        /// </summary>
        /// <param name="source">The string to search.</param>
        /// <param name="chars">The characters to search for.</param>
        /// <returns><c>true</c> if the string contains all of the specified characters; otherwise, <c>false</c>.</returns>
        public static bool ContainsAll(this string source, params char[] chars)
        {
            return chars.All(source.Contains);
        }

        /// <summary>
        /// Determines whether the string contains any of the specified substrings.
        /// </summary>
        /// <param name="source">The string to search.</param>
        /// <param name="substrings">The substrings to search for.</param>
        /// <returns><c>true</c> if the string contains any of the specified substrings; otherwise, <c>false</c>.</returns>
        public static bool ContainsAny(this string source, params string[] substrings)
        {
            return substrings.Any(source.Contains);
        }

        /// <summary>
        /// Determines whether the string contains all of the specified substrings.
        /// </summary>
        /// <param name="source">The string to search.</param>
        /// <param name="substrings">The substrings to search for.</param>
        /// <returns><c>true</c> if the string contains all of the specified substrings; otherwise, <c>false</c>.</returns>
        public static bool ContainsAll(this string source, params string[] substrings)
        {
            return substrings.All(source.Contains);
        }
    }
}