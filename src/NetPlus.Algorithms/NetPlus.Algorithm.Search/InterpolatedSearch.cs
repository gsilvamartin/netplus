using System;
using System.Collections.Generic;

namespace NetPlus.Algorithms.Search
{
    /// <summary>
    /// Provides an implementation of the Interpolated Search algorithm for searching in a sorted array.
    /// </summary>
    public static class InterpolatedSearch
    {
        /// <summary>
        /// Searches for the index of a specified value in a sorted array using the Interpolated Search algorithm.
        /// </summary>
        /// <typeparam name="T">The type of elements in the array, must implement IComparable interface.</typeparam>
        /// <param name="array">The sorted array to search.</param>
        /// <param name="value">The value to search for.</param>
        /// <returns>
        /// The index of the specified value in the array if found; otherwise, -1.
        /// </returns>
        public static int SearchInterpolated<T>(this T[] array, T value) where T : IComparable<T>
        {
            return Execute(array, value, 0, array.Length - 1);
        }

        /// <summary>
        /// Executes the Interpolated Search algorithm recursively.
        /// </summary>
        /// <typeparam name="T">The type of elements in the array, must implement IComparable interface.</typeparam>
        /// <param name="array">The sorted array to search.</param>
        /// <param name="value">The value to search for.</param>
        /// <param name="left">The left index of the current search range.</param>
        /// <param name="right">The right index of the current search range.</param>
        /// <returns>
        /// The index of the specified value in the array if found; otherwise, -1.
        /// </returns>
        private static int Execute<T>(IReadOnlyList<T> array, T value, int left, int right) where T : IComparable<T>
        {
            if (left > right) return -1;

            var middle = left + (right - left) /
                (array[right].CompareTo(array[left]) == 0 ? 1 : array[right].CompareTo(array[left])) *
                (value.CompareTo(array[left]) - array[left].CompareTo(array[right]));

            return array[middle].CompareTo(value) == 0
                ? middle
                : array[middle].CompareTo(value) > 0
                    ? Execute(array, value, left, middle - 1)
                    : Execute(array, value, middle + 1, right);
        }
    }
}