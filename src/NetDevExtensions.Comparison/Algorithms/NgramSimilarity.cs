namespace NetDevExtensions.Comparison.Algorithms;

public static class NgramSimilarity
{
    public static double Calculate(string text1, string text2, int n = 2)
    {
        var ngrams1 = GenerateNgrams(text1, n);
        var ngrams2 = GenerateNgrams(text2, n);

        var intersection = ngrams1.Intersect(ngrams2).Count();
        var union = ngrams1.Union(ngrams2).Count();

        return (double)intersection / union;
    }

    private static List<string> GenerateNgrams(string text, int n)
    {
        var ngrams = new List<string>();

        for (var i = 0; i < text.Length - n + 1; i++)
            ngrams.Add(text.Substring(i, n));

        return ngrams;
    }
}