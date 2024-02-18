namespace NetDevExtensions.Algorithms.Sorting
{
    /// <summary>
    /// Provides methods for performing Selection Sort on arrays.
    /// </summary>
    public static class SelectionSort
    {
        /// <summary>
        /// Sorts an array using the Selection Sort algorithm.
        /// </summary>
        /// <typeparam name="T">The type of elements in the array, must implement IComparable{T}.</typeparam>
        /// <param name="array">The array to be sorted.</param>
        /// <returns>The sorted array.</returns>
        public static T[] ExecuteSelectionSort<T>(this T[] array) where T : IComparable<T>
        {
            ArgumentNullException.ThrowIfNull(array);

            for (var i = 0; i < array.Length - 1; i++)
            {
                var minIndex = i;

                for (var j = i + 1; j < array.Length; j++)
                    if (array[j].CompareTo(array[minIndex]) < 0)
                        minIndex = j;

                if (minIndex != i) (array[minIndex], array[i]) = (array[i], array[minIndex]);
            }

            return array;
        }
    }
}