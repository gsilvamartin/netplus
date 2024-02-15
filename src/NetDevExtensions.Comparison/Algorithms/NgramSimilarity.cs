namespace NetDevExtensions.Comparison.Algorithms;

/// <summary>
/// A static class providing extension methods for calculating the N-gram similarity between two strings.
/// </summary>
public static class NgramSimilarity
{
    /// <summary>
    /// Calculates the N-gram similarity between two strings.
    /// </summary>
    /// <param name="text1">The first string for comparison.</param>
    /// <param name="text2">The second string for comparison.</param>
    /// <param name="n">The size of N-grams to be used (default is 2).</param>
    /// <returns>A double value representing the N-gram similarity between the two strings, ranging from 0.0 to 1.0.</returns>
    public static double CalculateNgramSimilarity(this string text1, string text2, int n = 2)
    {
        var ngrams1 = GenerateNgrams(text1, n);
        var ngrams2 = GenerateNgrams(text2, n);

        var intersection = ngrams1.Intersect(ngrams2).Count();
        var union = ngrams1.Union(ngrams2).Count();

        return (double)intersection / union;
    }

    /// <summary>
    /// Generates N-grams from the input text.
    /// </summary>
    /// <param name="text">The text from which N-grams will be generated.</param>
    /// <param name="n">The size of N-grams to be generated.</param>
    /// <returns>A list of strings representing the N-grams.</returns>
    private static List<string> GenerateNgrams(string text, int n)
    {
        var ngrams = new List<string>();

        for (var i = 0; i < text.Length - n + 1; i++)
            ngrams.Add(text.Substring(i, n));

        return ngrams;
    }
}
