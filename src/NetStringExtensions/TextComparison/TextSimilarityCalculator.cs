using NetStringExtensions.TextComparison.Algorithms;

namespace NetStringExtensions.TextComparison;

public class TextSimilarityCalculator
{
    public static double CalculateSimilarity(
        string a,
        string b,
        TextSimilarityAlgorithm textSimilarityAlgorithm = TextSimilarityAlgorithm.JaccardSimilarity)
    {
        switch (textSimilarityAlgorithm)
        {
            case TextSimilarityAlgorithm.CosineSimilarity:
                return CosineSimilarity.Calculate(a, b);
            case TextSimilarityAlgorithm.JaccardSimilarity:
                return JaccardSimilarity.Calculate(a, b);
            case TextSimilarityAlgorithm.LevenshteinDistance:
                return LevenshteinSimilarity.Calculate(a, b);
            case TextSimilarityAlgorithm.JaroWinklerDistance:
                return JaroWinklerSimilarity.Calculate(a, b);
            case TextSimilarityAlgorithm.BM25:
                break;
            case TextSimilarityAlgorithm.JansenShannonDivergence:
                break;
            case TextSimilarityAlgorithm.SentenceEmbeddings:
                break;
            case TextSimilarityAlgorithm.NgramOverlap:
                break;
            default:
                throw new ArgumentOutOfRangeException(
                    nameof(textSimilarityAlgorithm),
                    textSimilarityAlgorithm,
                    "Invalid text similarity algorithm."
                );
        }
    }
}