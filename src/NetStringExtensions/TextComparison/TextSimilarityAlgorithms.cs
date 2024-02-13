namespace NetStringExtensions.TextComparison;

public enum TextSimilarityAlgorithm
{
    CosineSimilarity,
    JaccardSimilarity,
    LevenshteinDistance,
    JaroWinklerDistance,
    BM25,
    JansenShannonDivergence,
    SentenceEmbeddings,
    NgramOverlap
}