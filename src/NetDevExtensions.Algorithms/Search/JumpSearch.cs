namespace NetDevExtensions.Algorithms.Search;

public static class JumpSearch
{
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