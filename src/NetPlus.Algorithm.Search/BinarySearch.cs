namespace NetPlus.Algorithms.Search;

/// <summary>
/// A static class containing the implementation of Binary Search algorithm.
/// </summary>
public static class BinarySearch
{
    /// <summary>
    /// Performs binary search on a sorted array to find the index of a specific value.
    /// </summary>
    /// <typeparam name="T">Type of elements in the array. Must implement <see cref="IComparable{T}"/>.</typeparam>
    /// <param name="array">The sorted array to search.</param>
    /// <param name="value">The value to search for.</param>
    /// <returns>The index of the value in the array, or -1 if not found.</returns>
    public static int SearchBinary<T>(this T[] array, T value) where T : IComparable<T>
    {
        return Execute(array, value, 0, array.Length - 1);
    }

    /// <summary>
    /// Recursive method to execute the binary search.
    /// </summary>
    /// <typeparam name="T">Type of elements in the array. Must implement <see cref="IComparable{T}"/>.</typeparam>
    /// <param name="array">The sorted array to search.</param>
    /// <param name="value">The value to search for.</param>
    /// <param name="left">The left index of the current search range.</param>
    /// <param name="right">The right index of the current search range.</param>
    /// <returns>The index of the value in the array, or -1 if not found.</returns>
    private static int Execute<T>(IReadOnlyList<T> array, T value, int left, int right) where T : IComparable<T>
    {
        if (left > right) return -1;

        var middle = (left + right) / 2;

        return array[middle].CompareTo(value) switch
        {
            0 => middle,
            > 0 => Execute(array, value, left, middle - 1),
            _ => Execute(array, value, middle + 1, right)
        };
    }
}