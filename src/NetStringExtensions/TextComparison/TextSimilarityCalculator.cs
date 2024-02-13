using NetStringExtensions.TextComparison.Algorithms;
using NetStringExtensions.TextComparison.Algorithms.Enum;

namespace NetStringExtensions.TextComparison;

public static class TextSimilarityCalculator
{
    public static double CalculateSimilarity(
        string a,
        string b,
        TextSimilarityAlgorithm? textSimilarityAlgorithm = TextSimilarityAlgorithm.JaccardSimilarity)
    {
        return textSimilarityAlgorithm switch
        {
            TextSimilarityAlgorithm.CosineSimilarity => CosineSimilarity.Calculate(a, b),
            TextSimilarityAlgorithm.JaccardSimilarity => JaccardSimilarity.Calculate(a, b),
            TextSimilarityAlgorithm.LevenshteinDistance => LevenshteinSimilarity.Calculate(a, b),
            TextSimilarityAlgorithm.JaroWinklerDistance => JaroWinklerSimilarity.Calculate(a, b),
            TextSimilarityAlgorithm.JansenShannonDivergence => JansenShannonSimilarity.Calculate(a, b),
            TextSimilarityAlgorithm.NgramOverlap => NgramSimilarity.Calculate(a, b),
            _ => throw new ArgumentOutOfRangeException(nameof(textSimilarityAlgorithm), textSimilarityAlgorithm,
                "Invalid text similarity algorithm.")
        };
    }
}