namespace NetStringExtensions.TextComparison.Algorithms;

public static class CosineSimilarity
{
    public static double Calculate(string text1, string text2)
    {
        var vectorA = VectorizeText(text1);
        var vectorB = VectorizeText(text2);

        return CalculateCosineSimilarity(vectorA, vectorB);
    }

    private static double CalculateCosineSimilarity(List<string> words1, List<string> words2)
    {
        var wordSet = new HashSet<string>(words1.Concat(words2), StringComparer.OrdinalIgnoreCase);
        var vectorA = words1.Select(word => wordSet.Contains(word) ? 1 : 0).ToList();
        var vectorB = words2.Select(word => wordSet.Contains(word) ? 1 : 0).ToList();

        var dotProduct = vectorA.Zip(vectorB, (a, b) => a * b).Sum();
        var magnitudeA = Math.Sqrt(vectorA.Sum(x => x * x));
        var magnitudeB = Math.Sqrt(vectorB.Sum(y => y * y));

        if (magnitudeA == 0 || magnitudeB == 0)
            return 0.0;

        return dotProduct / (magnitudeA * magnitudeB);
    }

    private static List<string> TokenizeText(string text)
    {
        return text.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList();
    }

    private static List<string> VectorizeText(string text)
    {
        return TokenizeText(text);
    }
}