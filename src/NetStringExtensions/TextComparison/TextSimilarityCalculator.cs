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
                break;
            case TextSimilarityAlgorithm.JaccardSimilarity:
                break;
            case TextSimilarityAlgorithm.LevenshteinDistance:
                break;
            case TextSimilarityAlgorithm.JaroWinklerDistance:
                break;
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