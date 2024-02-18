namespace NetDevExtensions.Algorithms.Sorting;  

/// <summary>
/// Provides methods for performing Bubble Sort on arrays.
/// </summary>
public static class BubbleSort
{
    /// <summary>
    /// Sorts an array using the Bubble Sort algorithm in ascending order.
    /// </summary>
    /// <typeparam name="T">The type of elements in the array, must implement IComparable{T}.</typeparam>
    /// <param name="array">The array to be sorted.</param>
    /// <returns>The sorted array in ascending order.</returns>
    public static T[] ExecuteBubbleSort<T>(this T[] array) where T : IComparable<T>
    {
        for (var i = 0; i < array.Length - 1; i++)
        {
            for (var j = 0; j < array.Length - 1 - i; j++)
            {
                if (array[j].CompareTo(array[j + 1]) > 0)
                {
                    (array[j + 1], array[j]) = (array[j], array[j + 1]);
                }
            }
        }

        return array;
    }
}