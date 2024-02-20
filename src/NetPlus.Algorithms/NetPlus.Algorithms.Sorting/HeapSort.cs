using System;
using System.Collections.Generic;

namespace NetPlus.Algorithms.Sorting
{
    /// <summary>
    /// Provides methods for performing Heap Sort on arrays.
    /// </summary>
    public static class HeapSort
    {
        /// <summary>
        /// Sorts an array using the Heap Sort algorithm.
        /// </summary>
        /// <typeparam name="T">The type of elements in the array, must implement IComparable{T}.</typeparam>
        /// <param name="array">The array to be sorted.</param>
        /// <returns>The sorted array.</returns>
        public static T[] Sort<T>(T[] array) where T : IComparable<T>
        {
            var n = array.Length;

            for (var i = n / 2 - 1; i >= 0; i--) Heapify(array, n, i);

            for (var i = n - 1; i > 0; i--)
            {
                (array[0], array[i]) = (array[i], array[0]);
                Heapify(array, i, 0);
            }

            return array;
        }

        /// <summary>
        /// Maintains the heap property of the array.
        /// </summary>
        /// <typeparam name="T">The type of elements in the array, must implement IComparable{T}.</typeparam>
        /// <param name="array">The array to be heapified.</param>
        /// <param name="n">The size of the heap.</param>
        /// <param name="i">The index of the root of the heap.</param>
        private static void Heapify<T>(IList<T> array, int n, int i) where T : IComparable<T>
        {
            var largest = i;
            var left = 2 * i + 1;
            var right = 2 * i + 2;

            if (left < n && array[left].CompareTo(array[largest]) > 0)
                largest = left;

            if (right < n && array[right].CompareTo(array[largest]) > 0)
                largest = right;

            if (largest == i) return;

            (array[i], array[largest]) = (array[largest], array[i]);

            Heapify(array, n, largest);
        }
    }
}