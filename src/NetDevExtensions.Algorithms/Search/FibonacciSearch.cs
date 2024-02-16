namespace NetDevExtensions.Algorithms.Search;

public static class FibonacciSearch
{
    public static int SearchFibonacci<T>(this T[] array, T value) where T : IComparable<T>
    {
        return Execute(array, value, 0, array.Length - 1);
    }

    private static int Execute<T>(IReadOnlyList<T> array, T value, int left, int right) where T : IComparable<T>
    {
        var fibM2 = 0;
        var fibM1 = 1;
        var fibM = fibM1;

        while (fibM < right - left)
        {
            var temp = fibM;
            fibM = fibM1;
            fibM1 = temp + fibM1;
        }

        var offset = -1;

        while (fibM > 1)
        {
            var i = Math.Min(left + fibM2, right);

            switch (array[i].CompareTo(value))
            {
                case < 0:
                    fibM = fibM1;
                    fibM1 -= fibM2;
                    fibM2 = fibM - fibM1;
                    offset = i;
                    break;
                case > 0:
                    fibM = fibM2;
                    fibM1 -= fibM2;
                    fibM2 = fibM - fibM1;
                    break;
                default:
                    return i;
            }
        }

        return array[offset + 1].CompareTo(value) == 0 ? offset + 1 : -1;
    }
}