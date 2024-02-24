using System.Collections.Generic;
using System.Linq;

namespace NetPlus.Extensions.LINQ
{
    /// <summary>
    /// Provides extension methods for LINQ operations on IEnumerable{T}.
    /// </summary>
    public static class LinqIEnumerableExtensions
    {
        /// <summary>
        /// Determines whether the sequence contains any of the specified elements.
        /// </summary>
        /// <typeparam name="T">The type of elements in the sequence.</typeparam>
        /// <param name="source">The sequence to search.</param>
        /// <param name="elements">The elements to search for.</param>
        /// <returns><c>true</c> if the sequence contains any of the specified elements; otherwise, <c>false</c>.</returns>
        public static bool ContainsAny<T>(this IEnumerable<T> source, params T[] elements)
        {
            return elements.Any(source.Contains);
        }

        /// <summary>
        /// Determines whether the sequence contains all of the specified elements.
        /// </summary>
        /// <typeparam name="T">The type of elements in the sequence.</typeparam>
        /// <param name="source">The sequence to search.</param>
        /// <param name="elements">The elements to search for.</param>
        /// <returns><c>true</c> if the sequence contains all of the specified elements; otherwise, <c>false</c>.</returns>
        public static bool ContainsAll<T>(this IEnumerable<T> source, params T[] elements)
        {
            return elements.All(source.Contains);
        }
    }
}