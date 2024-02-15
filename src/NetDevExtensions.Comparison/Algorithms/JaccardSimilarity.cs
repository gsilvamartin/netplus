namespace NetDevExtensions.Comparison.Algorithms;

/// <summary>
/// A static class providing extension methods for calculating the Jaccard similarity between two strings.
/// </summary>
public static class JaccardSimilarity
{
    /// <summary>
    /// Calculates the Jaccard similarity between two strings.
    /// </summary>
    /// <param name="text1"></param>
    /// <param name="text2"></param>
    /// <returns>A double value representing the similarity between the two strings, ranging from 0.00 to 1.00.</returns>
    public static double Calculate(string text1, string text2)
    {
        var set1 = GetWordSet(text1);
        var set2 = GetWordSet(text2);

        double intersectionSize = GetIntersectionSize(set1, set2);
        double unionSize = GetUnionSize(set1, set2);

        if (text1 == text2)
            return 1.0;

        if (unionSize == 0)
            return 0.0;

        return intersectionSize / unionSize;
    }

    /// <summary>
    /// Tokenizes the input text into a set of words.
    /// </summary>
    /// <param name="text"></param>
    /// <returns>A representation of a string based on a HashSet of strings</returns>
    private static HashSet<string> GetWordSet(string text)
    {
        var words = text.Split(' ', StringSplitOptions.RemoveEmptyEntries);

        return new HashSet<string>(words, StringComparer.OrdinalIgnoreCase);
    }

    /// <summary>
    /// Calculates the size of the intersection between two sets of words.
    /// </summary>
    /// <param name="set1"></param>
    /// <param name="set2"></param>
    /// <returns>The intersection size of two sets of words.</returns>
    private static int GetIntersectionSize(HashSet<string> set1, HashSet<string> set2)
    {
        set1.IntersectWith(set2);

        return set1.Count;
    }

    /// <summary>
    /// Calculates the size of the union between two sets of words.
    /// </summary>
    /// <param name="set1"></param>
    /// <param name="set2"></param>
    /// <returns>The union size of two sets of words.</returns>
    private static int GetUnionSize(HashSet<string> set1, HashSet<string> set2)
    {
        set1.UnionWith(set2);

        return set1.Count;
    }
}