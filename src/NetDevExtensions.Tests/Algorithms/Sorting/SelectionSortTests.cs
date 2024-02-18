using NetDevExtensions.Algorithms.Sorting;

namespace NetStringExtensions.Tests.Algorithms.Sorting;

public class SelectionSortTests
{
    [Fact]
    public void Sort_IntArray_SortedArray()
    {
        int[] array = [5, 3, 8, 1, 2, 4];
        int[] expected = [1, 2, 3, 4, 5, 8];

        var result = array.ExecuteSelectionSort();

        Assert.Equal(expected, result);
    }

    [Fact]
    public void Sort_DoubleArray_SortedArray()
    {
        double[] array = [5.4, 3.1, 8.9, 1.2, 2.7, 4.6];
        double[] expected = [1.2, 2.7, 3.1, 4.6, 5.4, 8.9];

        var result = array.ExecuteSelectionSort();

        Assert.Equal(expected, result);
    }

    [Fact]
    public void Sort_StringArray_SortedArray()
    {
        string[] array = ["apple", "orange", "banana", "grape"];
        string[] expected = ["apple", "banana", "grape", "orange"];

        var result = array.ExecuteSelectionSort();

        Assert.Equal(expected, result);
    }

    [Fact]
    public void Sort_EmptyArray_ReturnsEmptyArray()
    {
        var array = Array.Empty<int>();
        var expected = Array.Empty<int>();

        var result = array.ExecuteSelectionSort();

        Assert.Equal(expected, result);
    }

    [Fact]
    public void Sort_SingleElementArray_ReturnsSameArray()
    {
        int[] array = [42];
        int[] expected = [42];

        var result = array.ExecuteSelectionSort();

        Assert.Equal(expected, result);
    }

    [Fact]
    public void Sort_NullArray_ThrowsArgumentNullException()
    {
        int[]? array = null;

        Assert.Throws<ArgumentNullException>(() => array.ExecuteSelectionSort());
    }

    [Fact]
    public void Sort_CharArray_SortedArray()
    {
        char[] array = { 'z', 'a', 'c', 'b' };
        char[] expected = { 'a', 'b', 'c', 'z' };

        var result = array.ExecuteSelectionSort();

        Assert.Equal(expected, result);
    }

    [Fact]
    public void Sort_ReverseSortedIntArray_SortedArray()
    {
        int[] array = { 5, 4, 3, 2, 1 };
        int[] expected = { 1, 2, 3, 4, 5 };

        var result = array.ExecuteSelectionSort();

        Assert.Equal(expected, result);
    }

    [Fact]
    public void Sort_LongArray_SortedArray()
    {
        long[] array = [100, 42, 75, 32, 89];
        long[] expected = [32, 42, 75, 89, 100];

        var result = array.ExecuteSelectionSort();

        Assert.Equal(expected, result);
    }

    [Fact]
    public void Sort_DateTimeArray_SortedArray()
    {
        DateTime[] array = [new DateTime(2022, 1, 15), new DateTime(2022, 5, 2), new DateTime(2021, 12, 1)];
        DateTime[] expected = [new DateTime(2021, 12, 1), new DateTime(2022, 1, 15), new DateTime(2022, 5, 2)];

        var result = array.ExecuteSelectionSort();

        Assert.Equal(expected, result);
    }
}