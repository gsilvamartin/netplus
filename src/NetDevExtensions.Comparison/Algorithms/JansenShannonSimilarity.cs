namespace NetDevExtensions.Comparison.Algorithms;

public static class JansenShannonSimilarity
{
    public static double Calculate(string text1, string text2)
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

    private static List<string> Tokenize(string text)
    {
        return text.Split(new[] { ' ', '.', ',', ';', '!', '?' }, StringSplitOptions.RemoveEmptyEntries).ToList();
    }

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

    private static double CalculateKullbackLeiblerDivergence(Dictionary<string, double> p, Dictionary<string, double> q)
    {
        return (from word in p.Keys
            let pValue = p[word]
            let qValue = q.ContainsKey(word) ? q[word] : 0.0
            select pValue * Math.Log(pValue / qValue)).Sum();
    }

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