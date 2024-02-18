namespace NetDevExtensions.Algorithms.Search;

/// <summary>
/// Provides an implementation of the Jump Search algorithm for searching in a sorted array.
/// </summary>
public static class JumpSearch
{
    /// <summary>
    /// Searches for the index of a specified value in a sorted array using the Jump Search algorithm.
    /// </summary>
    /// <typeparam name="T">The type of elements in the array, must implement IComparable interface.</typeparam>
    /// <param name="array">The sorted array to search.</param>
    /// <param name="value">The value to search for.</param>
    /// <returns>
    /// The index of the specified value in the array if found; otherwise, -1.
    /// </returns>
    public static int SearchJump<T>(this T[] array, T value) where T : IComparable<T>
    {
        var n = array.Length;
        var step = (int)Math.Floor(Math.Sqrt(n));
        var prev = 0;

        while (array[Math.Min(step, n) - 1].CompareTo(value) < 0)
        {
            prev = step;
            step += (int)Math.Floor(Math.Sqrt(n));
            if (prev >= n) return -1;
        }

        while (array[prev].CompareTo(value) < 0)
        {
            prev++;
            if (prev == Math.Min(step, n)) return -1;
        }

        if (array[prev].CompareTo(value) == 0) return prev;

        return -1;
    }
}