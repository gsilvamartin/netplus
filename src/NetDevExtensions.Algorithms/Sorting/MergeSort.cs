using NetDevExtensions.Algorithms.Sorting.Util;

namespace NetDevExtensions.Algorithms.Sorting;

public static class MergeSort
{
    public static T[] ExecuteMergeSort<T>(
        this T[] array,
        SortOrder sortOrder = SortOrder.Ascending,
        IComparer<T>? comparer = null
    )
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

    private static T[] Merge<T>(T[] left, T[] right, T[] array, SortOrder sortOrder, IComparer<T>? comparer)
    {
        int leftIndex = 0, rightIndex = 0, outputIndex = 0;

        while (leftIndex < left.Length && rightIndex < right.Length)
        {
            var comparisonResult = comparer?.Compare(left[leftIndex], right[rightIndex]) ??
                                   Comparer<T>.Default.Compare(left[leftIndex], right[rightIndex]);

            if (sortOrder == SortOrder.Ascending ? comparisonResult < 0 : comparisonResult > 0)
            {
                array[outputIndex++] = left[leftIndex++];
            }
            else
            {
                array[outputIndex++] = right[rightIndex++];
            }
        }

        while (leftIndex < left.Length)
        {
            array[outputIndex++] = left[leftIndex++];
        }

        while (rightIndex < right.Length)
        {
            array[outputIndex++] = right[rightIndex++];
        }

        return array;
    }
}