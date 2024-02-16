namespace NetDevExtensions.Algorithms.Search;

public static class TernarySearch
{
    public static int SearchTernary<T>(this T[] array, T value) where T : IComparable<T>
    {
        return Execute(array, value, 0, array.Length - 1);
    }

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