namespace NetDevExtensions.Algorithms.Search;

/// <summary>
/// Provides an implementation of the Ternary Search algorithm for searching in a sorted array.
/// </summary>
public static class TernarySearch
{
    /// <summary>
    /// Searches for the index of a specified value in a sorted array using the Ternary Search algorithm.
    /// </summary>
    /// <typeparam name="T">The type of elements in the array, must implement IComparable interface.</typeparam>
    /// <param name="array">The sorted array to search.</param>
    /// <param name="value">The value to search for.</param>
    /// <returns>
    /// The index of the specified value in the array if found; otherwise, -1.
    /// </returns>
    public static int SearchTernary<T>(this T[] array, T value) where T : IComparable<T>
    {
        return Execute(array, value, 0, array.Length - 1);
    }

    /// <summary>
    /// Executes the Ternary Search algorithm recursively.
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

        var partitionSize = (right - left) / 3;
        var middle1 = left + partitionSize;
        var middle2 = right - partitionSize;

        return array[middle1].CompareTo(value) switch
        {
            0 => middle1,
            > 0 => Execute(array, value, left, middle1 - 1),
            _ => array[middle2].CompareTo(value) switch
            {
                0 => middle2,
                > 0 => Execute(array, value, middle1 + 1, middle2 - 1),
                _ => Execute(array, value, middle2 + 1, right)
            }
        };
    }
}