using NetDevExtensions.Algorithms.Sorting;

namespace NetStringExtensions.Tests.Algorithms.Sorting;

public class BubbleSortTests
{
    [Fact]
    public void Sort_ShouldReturnSortedArray_WhenArrayIsUnsorted()
    {
        int[] unsortedArray = [5, 3, 8, 6, 2, 7, 1, 4, 9];
        int[] expectedArray = [1, 2, 3, 4, 5, 6, 7, 8, 9];

        Assert.Equal(unsortedArray.ExecuteBubbleSort(), expectedArray);
    }

    [Fact]
    public void Sort_ShouldReturnSortedArray_WhenArrayIsSortedInDescendingOrder()
    {
        int[] unsortedArray = [9, 8, 7, 6, 5, 4, 3, 2, 1];
        int[] expectedArray = [1, 2, 3, 4, 5, 6, 7, 8, 9];

        Assert.Equal(unsortedArray.ExecuteBubbleSort(), expectedArray);
    }

    [Fact]
    public void Sort_ShouldReturnSortedArray_WhenArrayIsSortedInAscendingOrder()
    {
        int[] unsortedArray = [1, 2, 3, 4, 5, 6, 7, 8, 9];
        int[] expectedArray = [1, 2, 3, 4, 5, 6, 7, 8, 9];

        Assert.Equal(unsortedArray.ExecuteBubbleSort(), expectedArray);
    }

    [Fact]
    public void Sort_ShouldReturnEmptyArray_WhenArrayIsEmpty()
    {
        var unsortedArray = Array.Empty<int>();
        var expectedArray = Array.Empty<int>();

        Assert.Equal(unsortedArray.ExecuteBubbleSort(), expectedArray);
    }

    [Fact]
    public void Sort_ShouldReturnArrayWithSingleElement_WhenArrayHasSingleElement()
    {
        int[] unsortedArray = [1];
        int[] expectedArray = [1];

        Assert.Equal(unsortedArray.ExecuteBubbleSort(), expectedArray);
    }

    [Fact]
    public void Sort_ShouldReturnArrayWithTwoElementsInAscendingOrder_WhenArrayHasTwoElementsInDescendingOrder()
    {
        int[] unsortedArray = [2, 1];
        int[] expectedArray = [1, 2];

        Assert.Equal(unsortedArray.ExecuteBubbleSort(), expectedArray);
    }

    [Fact]
    public void Sort_ShouldReturnArrayWithTwoElementsInAscendingOrder_WhenArrayHasTwoElementsInAscendingOrder()
    {
        int[] unsortedArray = [1, 2];
        int[] expectedArray = [1, 2];

        Assert.Equal(unsortedArray.ExecuteBubbleSort(), expectedArray);
    }

    [Fact]
    public void Sort_ShouldReturnArrayWithTwoElementsInAscendingOrder_WhenArrayHasTwoEqualElements()
    {
        int[] unsortedArray = [1, 1];
        int[] expectedArray = [1, 1];

        Assert.Equal(unsortedArray.ExecuteBubbleSort(), expectedArray);
    }

    [Fact]
    public void Sort_ShouldReturnArrayWithThreeElementsInAscendingOrder_WhenArrayHasThreeElementsInDescendingOrder()
    {
        int[] unsortedArray = [3, 2, 1];
        int[] expectedArray = [1, 2, 3];

        Assert.Equal(unsortedArray.ExecuteBubbleSort(), expectedArray);
    }

    [Fact]
    public void Sort_ShouldReturnArrayWithThreeElementsInAscendingOrder_WhenArrayHasThreeElementsInAscendingOrder()
    {
        int[] unsortedArray = [1, 2, 3];
        int[] expectedArray = [1, 2, 3];

        Assert.Equal(unsortedArray.ExecuteBubbleSort(), expectedArray);
    }

    [Fact]
    public void Sort_ShouldReturnArrayWithThreeElementsInAscendingOrder_WhenArrayHasThreeEqualElements()
    {
        int[] unsortedArray = [1, 1, 1];
        int[] expectedArray = [1, 1, 1];

        Assert.Equal(unsortedArray.ExecuteBubbleSort(), expectedArray);
    }

    [Fact]
    public void Sort_ShouldReturnArrayWithFourElementsInAscendingOrder_WhenArrayHasFourElementsInDescendingOrder()
    {
        int[] unsortedArray = [4, 3, 2, 1];
        int[] expectedArray = [1, 2, 3, 4];

        Assert.Equal(unsortedArray.ExecuteBubbleSort(), expectedArray);
    }

    [Fact]
    public void Sort_ShouldReturnArrayWithFourElementsInAscendingOrder_WhenArrayHasFourElementsInAscendingOrder()
    {
        int[] unsortedArray = [1, 2, 3, 4];
        int[] expectedArray = [1, 2, 3, 4];

        Assert.Equal(unsortedArray.ExecuteBubbleSort(), expectedArray);
    }

    [Fact]
    public void Sort_ShouldReturnArrayWithFourElementsInAscendingOrder_WhenArrayHasFourEqualElements()
    {
        int[] unsortedArray = [1, 1, 1, 1];
        int[] expectedArray = [1, 1, 1, 1];

        Assert.Equal(unsortedArray.ExecuteBubbleSort(), expectedArray);
    }
}