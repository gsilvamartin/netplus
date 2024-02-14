using NetDevExtensions.Comparison.Algorithms;

namespace NetStringExtensions.Tests.TextComparison;

public class JaccardSimilarityTests
{
    [Fact]
    public void JaccardSimilarity_SameStrings()
    {
        var a = "This is a sample text.";
        var b = "This is a sample text.";

        var similarity = JaccardSimilarity.Calculate(a, b);

        Assert.Equal(1.0, similarity, precision: 5);
    }

    [Fact]
    public void JaccardSimilarity_OneEmptyString()
    {
        var a = "This is a sample text.";
        var b = "";

        var similarity = JaccardSimilarity.Calculate(a, b);

        Assert.Equal(0.0, similarity, precision: 5);
    }

    [Fact]
    public void JaccardSimilarity_CaseInsensitive()
    {
        var a = "This is a sample text.";
        var b = "tHIS IS A sAMPLE tEXT.";

        var similarity = JaccardSimilarity.Calculate(a, b);

        Assert.Equal(1.0, similarity, precision: 5);
    }

    [Fact]
    public void JaccardSimilarity_DifferentStrings()
    {
        var a = "This is a sample text.";
        var b = "This is another sample text.";

        var similarity = JaccardSimilarity.Calculate(a, b);

        Assert.Equal(0.8, similarity, precision: 5);
    }

    [Fact]
    public void JaccardSimilarity_EmptyStrings()
    {
        var a = "";
        var b = "";

        var similarity = JaccardSimilarity.Calculate(a, b);

        Assert.Equal(1.0, similarity, precision: 5);
    }

    [Fact]
    public void JaccardSimilarity_OneEmptyStringAndOneNotEmptyString()
    {
        var a = "";
        var b = "This is a sample text.";

        var similarity = JaccardSimilarity.Calculate(a, b);

        Assert.Equal(0.0, similarity, precision: 5);
    }

    [Fact]
    public void JaccardSimilarity_BothEmptyStrings()
    {
        var a = "";
        var b = "";

        var similarity = JaccardSimilarity.Calculate(a, b);

        Assert.Equal(1.0, similarity, precision: 5);
    }

    [Fact]
    public void JaccardSimilarity_SingleCharacterStrings()
    {
        var a = "a";
        var b = "a";

        var similarity = JaccardSimilarity.Calculate(a, b);

        Assert.Equal(1.0, similarity, precision: 5);
    }

    [Fact]
    public void JaccardSimilarity_SingleCharacterStrings_Different()
    {
        var a = "a";
        var b = "b";

        var similarity = JaccardSimilarity.Calculate(a, b);

        Assert.Equal(0.0, similarity, precision: 5);
    }

    [Fact]
    public void JaccardSimilarity_LongestCommonSubstring()
    {
        var a = "The quick brown fox jumps over the lazy dog.";
        var b = "The quick brown fox jumps over the lazy cat.";

        var similarity = JaccardSimilarity.Calculate(a, b);

        Assert.Equal(0.875, similarity, precision: 4);
    }

    [Fact]
    public void JaccardSimilarity_PunctuationAndWhitespace()
    {
        var similarity = JaccardSimilarity.Calculate(
            "This is a sentence with punctuation! And spaces.",
            "This is another sentence with punctuation, and it has spaces."
        );

        Assert.Equal(0.6, similarity, precision: 5);
    }

    [Fact]
    public void JaccardSimilarity_MixedCaseStrings()
    {
        var similarity = JaccardSimilarity.Calculate(
            "MixedCase",
            "mixedcase"
        );

        Assert.Equal(1.0, similarity, precision: 5);
    }

    [Fact]
    public void JaccardSimilarity_SubsetStrings()
    {
        var similarity = JaccardSimilarity.Calculate(
            "This is the main text.",
            "This is a subset of the main text."
        );

        Assert.Equal(0.625, similarity, precision: 5);
    }

    [Fact]
    public void JaccardSimilarity_CommonPrefixStrings()
    {
        var similarity = JaccardSimilarity.Calculate(
            "Common Prefix: This is a text.",
            "Common Prefix: This is another text."
        );

        Assert.Equal(0.83333, similarity, precision: 5);
    }

    [Fact]
    public void JaccardSimilarity_DistinctCharacters()
    {
        var similarity = JaccardSimilarity.Calculate(
            "Distinct Characters: ABC",
            "Distinct Characters: XYZ"
        );

        Assert.Equal(0.66667, similarity, precision: 5);
    }
}