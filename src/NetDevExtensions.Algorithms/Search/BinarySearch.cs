namespace NetDevExtensions.Algorithms.Search;

public static class BinarySearch
{
    public static int SearchBinary<T>(this T[] array, T value) where T : IComparable<T>
    {
        return Execute(array, value, 0, array.Length - 1);
    }

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