namespace NetDevExtensions.Comparison.Algorithms;

/// <summary>
/// A static class providing extension methods for calculating the Jansen-Shannon similarity between two strings.
/// </summary>
public static class JansenShannonSimilarity
{
    /// <summary>
    /// Calculates the Jansen-Shannon similarity between two strings.
    /// </summary>
    /// <param name="text1">The first string for comparison.</param>
    /// <param name="text2">The second string for comparison.</param>
    /// <returns>A double value representing the similarity between the two strings, ranging from 0.00 to 1.00.</returns>
    public static double CalculateJansenShannonSimilarity(this string text1, string text2)
    {
        var words1 = Tokenize(text1);
        var words2 = Tokenize(text2);

        var uniqueWords = words1.Union(words2).Distinct().ToList();
        var distribution1 = CalculateWordDistribution(words1, uniqueWords);
        var distribution2 = CalculateWordDistribution(words2, uniqueWords);

        var klDivergence1 =
            CalculateKullbackLeiblerDivergence(distribution1, MergeDistributions(distribution1, distribution2));
        var klDivergence2 =
            CalculateKullbackLeiblerDivergence(distribution2, MergeDistributions(distribution1, distribution2));

        return (klDivergence1 + klDivergence2) / 2.0;
    }

    /// <summary>
    /// Tokenizes the input text into a list of words.
    /// </summary>
    /// <param name="text">The text to be tokenized.</param>
    /// <returns>A list of strings representing the text as tokens.</returns>
    private static List<string> Tokenize(string text)
    {
        return text.Split(new[] { ' ', '.', ',', ';', '!', '?' }, StringSplitOptions.RemoveEmptyEntries).ToList();
    }

    /// <summary>
    /// Calculates the word distribution for a given list of words and unique words.
    /// </summary>
    /// <param name="words">The list of words.</param>
    /// <param name="uniqueWords">The unique words in the text.</param>
    /// <returns>A dictionary representing the word distribution.</returns>
    private static Dictionary<string, double> CalculateWordDistribution(List<string> words, List<string> uniqueWords)
    {
        var distribution = new Dictionary<string, double>();

        foreach (var word in uniqueWords)
        {
            var probability = (double)words.Count(w => w == word) / words.Count;
            distribution[word] = probability;
        }

        return distribution;
    }

    /// <summary>
    /// Calculates the Kullback-Leibler Divergence between two distributions.
    /// </summary>
    /// <param name="p">The first distribution.</param>
    /// <param name="q">The second distribution.</param>
    /// <returns>The Kullback-Leibler Divergence value.</returns>
    private static double CalculateKullbackLeiblerDivergence(Dictionary<string, double> p, Dictionary<string, double> q)
    {
        return (from word in p.Keys
                let pValue = p[word]
                let qValue = q.ContainsKey(word) ? q[word] : 0.0
                select pValue * Math.Log(pValue / qValue)).Sum();
    }

    /// <summary>
    /// Merges two distributions.
    /// </summary>
    /// <param name="p">The first distribution.</param>
    /// <param name="q">The second distribution.</param>
    /// <returns>A merged distribution.</returns>
    private static Dictionary<string, double> MergeDistributions(Dictionary<string, double> p,
        Dictionary<string, double> q)
    {
        var mergedDistribution = new Dictionary<string, double>();

        foreach (var key in p.Keys.Union(q.Keys))
        {
            var pValue = p.ContainsKey(key) ? p[key] : 0.0;
            var qValue = q.ContainsKey(key) ? q[key] : 0.0;

            mergedDistribution[key] = pValue + qValue;
        }

        return mergedDistribution;
    }
}
