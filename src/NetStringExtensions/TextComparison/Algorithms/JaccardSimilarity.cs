namespace NetStringExtensions.TextComparison.Algorithms;

public class JaccardSimilarity
{
    public static double Calculate(string text1, string text2)
    {
        var set1 = GetWordSet(text1);
        var set2 = GetWordSet(text2);

        double intersectionSize = GetIntersectionSize(set1, set2);
        double unionSize = GetUnionSize(set1, set2);

        if (unionSize == 0)
            return 0.0;

        return intersectionSize / unionSize;
    }

    private static HashSet<string> GetWordSet(string text)
    {
        var words = text.Split(' ', StringSplitOptions.RemoveEmptyEntries);

        return new HashSet<string>(words, StringComparer.OrdinalIgnoreCase);
    }

    private static int GetIntersectionSize(HashSet<string> set1, HashSet<string> set2)
    {
        set1.IntersectWith(set2);

        return set1.Count;
    }

    private static int GetUnionSize(HashSet<string> set1, HashSet<string> set2)
    {
        set1.UnionWith(set2);

        return set1.Count;
    }
}