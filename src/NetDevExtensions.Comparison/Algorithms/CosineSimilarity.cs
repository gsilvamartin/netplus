namespace NetDevExtensions.Comparison.Algorithms;

/// <summary>
/// A static class providing extension methods for calculating the cosine similarity between two strings.
/// </summary>
public static class CosineSimilarity
{
    /// <summary>
    /// Calculates the cosine similarity between two strings.
    /// </summary>
    /// <param name="text1"></param>
    /// <param name="text2"></param>
    /// <returns>A double value representing the similarity between the two strings, ranging from 0.00 to 1.00.</returns>
    public static double CalculateCosineSimilarity(this string text1, string text2)
    {
        var vectorA = VectorizeText(text1);
        var vectorB = VectorizeText(text2);

        return CalculateCosineSimilarity(vectorA, vectorB);
    }

    /// <summary>
    /// Calculates the cosine similarity between two lists of strings.
    /// </summary>
    /// <param name="words1"></param>
    /// <param name="words2"></param>
    /// <returns>A double value representing the similarity between the two strings, ranging from 0.00 to 1.00.</returns>
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

    /// <summary>
    /// Tokenizes the input text into a list of words.
    /// </summary>
    /// <param name="text"></param>
    /// <returns>A list of string representing the text as tokens.</returns>
    private static List<string> TokenizeText(string text)
    {
        return text.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList();
    }

    /// <summary>
    /// Vectorizes the input text into a list of words.
    /// </summary>
    /// <param name="text"></param>
    /// <returns>A list of string representing the text as tokens.</returns>
    private static List<string> VectorizeText(string text)
    {
        return TokenizeText(text);
    }
}