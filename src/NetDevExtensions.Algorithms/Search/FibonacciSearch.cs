namespace NetDevExtensions.Algorithms.Search;

/// <summary>
/// A static class containing the implementation of Fibonacci Search algorithm.
/// </summary>
public static class FibonacciSearch
{
    /// <summary>
    /// Performs Fibonacci search on a sorted array to find the index of a specific value.
    /// </summary>
    /// <typeparam name="T">Type of elements in the array. Must implement <see cref="IComparable{T}"/>.</typeparam>
    /// <param name="array">The sorted array to search.</param>
    /// <param name="value">The value to search for.</param>
    /// <returns>The index of the value in the array, or -1 if not found.</returns>
    public static int SearchFibonacci<T>(this T[] array, T value) where T : IComparable<T>
    {
        return Execute(array, value, 0, array.Length - 1);
    }

    /// <summary>
    /// Perform the Fibonacci Search algorithm to find the index of a specified value in a sorted array.
    /// </summary>
    /// <typeparam name="T">Type of elements in the array, must implement IComparable interface.</typeparam>
    /// <param name="array">The sorted array to search.</param>
    /// <param name="value">The value to search for.</param>
    /// <param name="left">The left boundary of the search range.</param>
    /// <param name="right">The right boundary of the search range.</param>
    /// <returns>
    /// The index of the specified value in the array if found; otherwise, -1.
    /// </returns>
    private static int Execute<T>(IReadOnlyList<T> array, T value, int left, int right) where T : IComparable<T>
    {
        var fibMMm2 = 0;
        var fibMMm1 = 1;
        var fibM = fibMMm2 + fibMMm1;

        while (fibM < right - left)
        {
            fibMMm2 = fibMMm1;
            fibMMm1 = fibM;
            fibM = fibMMm2 + fibMMm1;
        }

        var offset = -1;

        while (fibM > 1)
        {
            var i = Math.Min(left + fibMMm2, right - 1);

            if (array[i].CompareTo(value) < 0)
            {
                fibM = fibMMm1;
                fibMMm1 = fibMMm2;
                fibMMm2 = fibM - fibMMm1;
                offset = i;
            }
            else if (array[i].CompareTo(value) > 0)
            {
                fibM = fibMMm2;
                fibMMm1 = fibMMm1 - fibMMm2;
                fibMMm2 = fibM - fibMMm1;
            }
            else
            {
                return i;
            }
        }

        return array[offset + 1].CompareTo(value) == 0 ? offset + 1 : -1;
    }
}