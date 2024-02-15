namespace NetDevExtensions.Comparison.Algorithms.Enum;

/// <summary>
/// An enumeration of text similarity algorithms.
/// </summary>
public enum TextSimilarityAlgorithm
{
    CosineSimilarity,
    JaccardSimilarity,
    LevenshteinDistance,
    JaroWinklerDistance,
    JansenShannonDivergence,
    NgramOverlap
}