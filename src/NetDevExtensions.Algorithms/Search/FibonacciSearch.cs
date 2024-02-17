namespace NetDevExtensions.Algorithms.Search;

public static class FibonacciSearch
{
    public static int SearchFibonacci<T>(this T[] array, T value) where T : IComparable<T>
    {
        return Execute(array, value, 0, array.Length - 1);
    }

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