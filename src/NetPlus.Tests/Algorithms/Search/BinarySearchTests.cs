using NetPlus.Algorithms.Search;

namespace NetStringExtensions.Tests.Algorithms.Search;

public class BinarySearchTests
{
    [Fact]
    public void SearchBinary_ShouldReturnIndex_WhenElementExists()
    {
        int[] sortedArray = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10];
        const int targetValue = 7;

        var result = sortedArray.SearchBinary(targetValue);

        Assert.Equal(6, result);
    }

    [Fact]
    public void SearchBinary_ShouldReturnNegativeOne_WhenElementDoesNotExist()
    {
        int[] sortedArray = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        const int targetValue = 11;

        var result = sortedArray.SearchBinary(targetValue);

        Assert.Equal(-1, result);
    }

    [Fact]
    public void SearchBinary_ShouldReturnNegativeOne_WhenArrayIsEmpty()
    {
        var emptyArray = Array.Empty<int>();
        var targetValue = 5;

        var result = emptyArray.SearchBinary(targetValue);

        Assert.Equal(-1, result);
    }

    [Fact]
    public void SearchBinary_ShouldReturnIndex_WhenElementExistsInOddLengthArray()
    {
        int[] sortedArray = [1, 2, 3, 4, 5, 6, 7, 8, 9];
        const int targetValue = 5;

        var result = sortedArray.SearchBinary(targetValue);

        Assert.Equal(4, result);
    }

    [Fact]
    public void SearchBinary_ShouldReturnIndex_WhenElementExistsInEvenLengthArray()
    {
        int[] sortedArray = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        const int targetValue = 8;

        var result = sortedArray.SearchBinary(targetValue);

        Assert.Equal(7, result);
    }

    [Fact]
    public void SearchBinary_ShouldReturnIndex_WhenElementExistsInArrayWithOneElement()
    {
        int[] sortedArray = { 1 };
        const int targetValue = 1;

        var result = sortedArray.SearchBinary(targetValue);

        Assert.Equal(0, result);
    }

    [Fact]
    public void SearchBinary_ShouldReturnNegativeOne_WhenElementDoesNotExistInArrayWithOneElement()
    {
        int[] sortedArray = { 1 };
        const int targetValue = 2;

        var result = sortedArray.SearchBinary(targetValue);

        Assert.Equal(-1, result);
    }

    [Fact]
    public void SearchBinary_ShouldReturnIndex_WhenElementExistsInArrayWithTwoElements()
    {
        int[] sortedArray = [1, 2];
        const int targetValue = 2;

        var result = sortedArray.SearchBinary(targetValue);

        Assert.Equal(1, result);
    }

    [Fact]
    public void SearchBinary_ShouldReturnNegativeOne_WhenElementDoesNotExistInArrayWithTwoElements()
    {
        int[] sortedArray = [1, 2];
        const int targetValue = 3;

        var result = sortedArray.SearchBinary(targetValue);

        Assert.Equal(-1, result);
    }

    [Fact]
    public void SearchBinary_ShouldReturnIndex_WhenElementExistsInArrayWithThreeElements()
    {
        int[] sortedArray = [1, 2, 3];
        const int targetValue = 3;

        var result = sortedArray.SearchBinary(targetValue);

        Assert.Equal(2, result);
    }

    [Fact]
    public void SearchBinary_ShouldReturnNegativeOne_WhenElementDoesNotExistInArrayWithThreeElements()
    {
        int[] sortedArray = [1, 2, 3];
        const int targetValue = 4;

        var result = sortedArray.SearchBinary(targetValue);

        Assert.Equal(-1, result);
    }

    [Fact]
    public void SearchBinary_ShouldReturnIndex_WhenElementExistsInArrayWithFourElements()
    {
        int[] sortedArray = [1, 2, 3, 4];
        const int targetValue = 4;

        var result = sortedArray.SearchBinary(targetValue);

        Assert.Equal(3, result);
    }

    [Fact]
    public void SearchBinary_ShouldReturnNegativeOne_WhenElementDoesNotExistInArrayWithFourElements()
    {
        int[] sortedArray = [1, 2, 3, 4];
        const int targetValue = 5;

        var result = sortedArray.SearchBinary(targetValue);

        Assert.Equal(-1, result);
    }

    [Fact]
    public void SearchBinary_ShouldReturnIndex_WhenElementExistsInArrayWithFiveElements()
    {
        int[] sortedArray = [1, 2, 3, 4, 5];
        const int targetValue = 5;

        var result = sortedArray.SearchBinary(targetValue);

        Assert.Equal(4, result);
    }
}