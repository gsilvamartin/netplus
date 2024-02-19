using NetPlus.Algorithms.Sorting.Util;

namespace NetPlus.Algorithms.Sorting;

/// <summary>
/// Provides methods for performing Merge Sort on arrays.
/// </summary>
public static class MergeSort
{
    /// <summary>
    /// Sorts an array using the Merge Sort algorithm.
    /// </summary>
    /// <typeparam name="T">The type of elements in the array, must implement IComparable{T}.</typeparam>
    /// <param name="array">The array to be sorted.</param>
    /// <param name="sortOrder">The order in which to sort the array (ascending or descending).</param>
    /// <param name="comparer">The comparer to use for custom element comparisons.</param>
    /// <returns>The sorted array.</returns>
    public static T[] ExecuteMergeSort<T>(
        this T[] array,
        SortOrder sortOrder = SortOrder.Ascending,
        IComparer<T>? comparer = null)
    {
        if (array.Length <= 1) return array;

        var middle = array.Length / 2;
        var left = new T[middle];
        var right = new T[array.Length - middle];

        Array.Copy(array, 0, left, 0, middle);
        Array.Copy(array, middle, right, 0, right.Length);

        ExecuteMergeSort(left, sortOrder, comparer);
        ExecuteMergeSort(right, sortOrder, comparer);

        return Merge(left, right, array, sortOrder, comparer ?? Comparer<T>.Default);
    }

    /// <summary>
    /// Merges two sorted arrays into a single sorted array.
    /// </summary>
    /// <typeparam name="T">The type of elements in the arrays, must implement IComparable{T}.</typeparam>
    /// <param name="left">The left array to merge.</param>
    /// <param name="right">The right array to merge.</param>
    /// <param name="array">The array to merge into.</param>
    /// <param name="sortOrder">The order in which to merge the arrays (ascending or descending).</param>
    /// <param name="comparer">The comparer to use for custom element comparisons.</param>
    /// <returns>The merged and sorted array.</returns>
    private static T[] Merge<T>(
        IReadOnlyList<T> left,
        IReadOnlyList<T> right,
        T[] array,
        SortOrder sortOrder,
        IComparer<T>? comparer)
    {
        int leftIndex = 0, rightIndex = 0, outputIndex = 0;

        while (leftIndex < left.Count && rightIndex < right.Count)
        {
            var comparisonResult = comparer?.Compare(left[leftIndex], right[rightIndex]) ??
                                   Comparer<T>.Default.Compare(left[leftIndex], right[rightIndex]);

            if (sortOrder == SortOrder.Ascending ? comparisonResult < 0 : comparisonResult > 0)
                array[outputIndex++] = left[leftIndex++];
            else
                array[outputIndex++] = right[rightIndex++];
        }

        while (leftIndex < left.Count)
            array[outputIndex++] = left[leftIndex++];

        while (rightIndex < right.Count)
            array[outputIndex++] = right[rightIndex++];

        return array;
    }
}