using NetDevExtensions.Algorithms.Sorting;
using NetDevExtensions.Algorithms.Sorting.Util;

namespace NetStringExtensions.Tests.Algorithms.Sorting;

public class MergeSortTests
{
    [Fact]
    public void Sort_ShouldReturnSortedArray_WhenArrayIsUnsorted()
    {
        int[] unsortedArray = [5, 3, 8, 6, 2, 7, 1, 4, 9];
        int[] expectedArray = [1, 2, 3, 4, 5, 6, 7, 8, 9];

        Assert.Equal(unsortedArray.ExecuteMergeSort(), expectedArray);
    }

    [Fact]
    public void Sort_ShouldReturnSortedArray_WhenArrayIsSortedInDescendingOrder()
    {
        int[] unsortedArray = [9, 8, 7, 6, 5, 4, 3, 2, 1];
        int[] expectedArray = [1, 2, 3, 4, 5, 6, 7, 8, 9];

        Assert.Equal(unsortedArray.ExecuteMergeSort(), expectedArray);
    }

    [Fact]
    public void Sort_ShouldReturnSortedArray_WhenArrayIsSortedInAscendingOrder()
    {
        int[] unsortedArray = [1, 2, 3, 4, 5, 6, 7, 8, 9];
        int[] expectedArray = [1, 2, 3, 4, 5, 6, 7, 8, 9];

        Assert.Equal(unsortedArray.ExecuteMergeSort(), expectedArray);
    }

    [Fact]
    public void Sort_ShouldReturnEmptyArray_WhenArrayIsEmpty()
    {
        var unsortedArray = Array.Empty<int>();
        var expectedArray = Array.Empty<int>();

        Assert.Equal(unsortedArray.ExecuteMergeSort(), expectedArray);
    }

    [Fact]
    public void Sort_ShouldReturnArrayWithSingleElement_WhenArrayHasSingleElement()
    {
        int[] unsortedArray = [1];
        int[] expectedArray = [1];

        Assert.Equal(unsortedArray.ExecuteMergeSort(), expectedArray);
    }

    [Fact]
    public void Sort_ShouldReturnArrayWithTwoElementsInAscendingOrder_WhenArrayHasTwoElementsInDescendingOrder()
    {
        int[] unsortedArray = [2, 1];
        int[] expectedArray = [1, 2];

        Assert.Equal(unsortedArray.ExecuteMergeSort(), expectedArray);
    }

    [Fact]
    public void Sort_ShouldReturnArrayWithTwoElementsInAscendingOrder_WhenArrayHasTwoElementsInRandomOrder()
    {
        int[] unsortedArray = [3, 1];
        int[] expectedArray = [1, 3];

        Assert.Equal(unsortedArray.ExecuteMergeSort(), expectedArray);
    }

    [Fact]
    public void Sort_ShouldReturnArrayWithTwoElementsInAscendingOrder_WhenArrayHasTwoElementsInAscendingOrder()
    {
        int[] unsortedArray = [1, 2];
        int[] expectedArray = [1, 2];

        Assert.Equal(unsortedArray.ExecuteMergeSort(), expectedArray);
    }

    [Fact]
    public void Sort_ShouldReturnArrayWithThreeElementsInAscendingOrder_WhenArrayHasThreeElementsInDescendingOrder()
    {
        int[] unsortedArray = [3, 2, 1];
        int[] expectedArray = [1, 2, 3];

        Assert.Equal(unsortedArray.ExecuteMergeSort(), expectedArray);
    }

    [Fact]
    public void Sort_ShouldReturnArrayWithThreeElementsInAscendingOrder_WhenArrayHasThreeElementsInRandomOrder()
    {
        int[] unsortedArray = [3, 1, 2];
        int[] expectedArray = [1, 2, 3];

        Assert.Equal(unsortedArray.ExecuteMergeSort(), expectedArray);
    }

    [Fact]
    public void Sort_ShouldReturnArrayWithThreeElementsInAscendingOrder_WhenArrayHasThreeElementsInAscendingOrder()
    {
        int[] unsortedArray = [1, 2, 3];
        int[] expectedArray = [1, 2, 3];

        Assert.Equal(unsortedArray.ExecuteMergeSort(), expectedArray);
    }

    [Fact]
    public void Sort_ShouldReturnArrayWithThreeElementsInAscendingOrder_WhenArrayHasThreeEqualElements()
    {
        int[] unsortedArray = [1, 1, 1];
        int[] expectedArray = [1, 1, 1];

        Assert.Equal(unsortedArray.ExecuteMergeSort(), expectedArray);
    }

    [Fact]
    public void Sort_ShouldReturnArrayWithFourElementsInAscendingOrder_WhenArrayHasFourElementsInDescendingOrder()
    {
        int[] unsortedArray = [4, 3, 2, 1];
        int[] expectedArray = [1, 2, 3, 4];

        Assert.Equal(unsortedArray.ExecuteMergeSort(), expectedArray);
    }

    [Fact]
    public void Sort_ShouldReturnArrayWithFourElementsInAscendingOrder_WhenArrayHasFourElementsInRandomOrder()
    {
        int[] unsortedArray = [4, 2, 3, 1];
        int[] expectedArray = [1, 2, 3, 4];

        Assert.Equal(unsortedArray.ExecuteMergeSort(), expectedArray);
    }

    [Fact]
    public void Sort_ShouldReturnArrayWithFourElementsInAscendingOrder_WhenArrayHasFourElementsInAscendingOrder()
    {
        int[] unsortedArray = [1, 2, 3, 4];
        int[] expectedArray = [1, 2, 3, 4];

        Assert.Equal(unsortedArray.ExecuteMergeSort(), expectedArray);
    }

    [Fact]
    public void Sort_ShouldReturnArrayWithFourElementsInAscendingOrder_WhenArrayHasFourEqualElements()
    {
        int[] unsortedArray = [1, 1, 1, 1];
        int[] expectedArray = [1, 1, 1, 1];

        Assert.Equal(unsortedArray.ExecuteMergeSort(), expectedArray);
    }

    [Fact]
    public void Sort_ShouldReturnArrayWithFiveElementsInAscendingOrder_WhenArrayHasFiveElementsInDescendingOrder()
    {
        int[] unsortedArray = [5, 4, 3, 2, 1];
        int[] expectedArray = [1, 2, 3, 4, 5];

        Assert.Equal(unsortedArray.ExecuteMergeSort(), expectedArray);
    }

    [Fact]
    public void
        SortGeneric_ShouldReturnArrayWithFiveElementsInAscendingOrder_WhenArrayHasFiveElementsInDescendingOrder()
    {
        var unsortedArray = new[] { "banana", "apple", "orange", "grape", "cherry" };
        var expectedArray = new[] { "apple", "banana", "cherry", "grape", "orange" };

        var sortedArray = unsortedArray.ExecuteMergeSort();

        Assert.Equal(expectedArray, sortedArray);
    }

    [Fact]
    public void SortGeneric_ShouldReturnArrayInAscendingOrder_WhenArrayHasAnonymousObjects()
    {
        object[] unsortedArray =
        [
            new { Name = "banana", Value = 5 },
            new { Name = "apple", Value = 3 },
            new { Name = "orange", Value = 7 },
            new { Name = "grape", Value = 2 },
            new { Name = "cherry", Value = 4 }
        ];

        object[] expectedArray =
        [
            new { Name = "grape", Value = 2 },
            new { Name = "apple", Value = 3 },
            new { Name = "cherry", Value = 4 },
            new { Name = "banana", Value = 5 },
            new { Name = "orange", Value = 7 }
        ];

        var sortedArray = unsortedArray.ExecuteMergeSort(SortOrder.Ascending, Comparer<object>.Create((x, y) =>
        {
            var valueX = (IComparable)x.GetType().GetProperty("Value")?.GetValue(x)!;
            var valueY = (IComparable)y.GetType().GetProperty("Value")?.GetValue(y)!;

            var valueComparison = Comparer<object>.Default.Compare(valueX, valueY);

            return valueComparison;
        }));

        Assert.Equal(expectedArray, sortedArray);
    }

    [Fact]
    public void SortGeneric_ShouldReturnArrayInAscendingOrder_WhenArrayHasAnonymousObjectsWithCustomComparer()
    {
        object[] unsortedArray =
        [
            new { Name = "banana", Value = 5 },
            new { Name = "apple", Value = 3 },
            new { Name = "orange", Value = 7 },
            new { Name = "grape", Value = 2 },
            new { Name = "cherry", Value = 4 }
        ];

        object[] expectedArray =
        [
            new { Name = "grape", Value = 2 },
            new { Name = "apple", Value = 3 },
            new { Name = "cherry", Value = 4 },
            new { Name = "banana", Value = 5 },
            new { Name = "orange", Value = 7 }
        ];

        var sortedArray = unsortedArray.ExecuteMergeSort(SortOrder.Ascending, Comparer<object>.Create((x, y) =>
        {
            var valueX = (IComparable)x.GetType().GetProperty("Value")?.GetValue(x)!;
            var valueY = (IComparable)y.GetType().GetProperty("Value")?.GetValue(y)!;

            var valueComparison = Comparer<object>.Default.Compare(valueX, valueY);

            if (valueComparison != 0)
                return valueComparison;

            var nameX = (string)x.GetType().GetProperty("Name")?.GetValue(x)!;
            var nameY = (string)y.GetType().GetProperty("Name")?.GetValue(y)!;

            return String.Compare(nameX, nameY, StringComparison.Ordinal);
        }));

        Assert.Equal(expectedArray, sortedArray);
    }

    [Fact]
    public void SortGeneric_ShouldReturnArrayInAscendingOrder_WhenArrayHasAnonymousObjectsWithAgeComparer()
    {
        object[] unsortedArray1 =
        [
            new { Name = "Alice", Age = 30 },
            new { Name = "Bob", Age = 25 },
            new { Name = "Charlie", Age = 40 },
            new { Name = "David", Age = 35 },
            new { Name = "Eva", Age = 28 }
        ];

        object[] expectedArray1 =
        [
            new { Name = "Bob", Age = 25 },
            new { Name = "Eva", Age = 28 },
            new { Name = "Alice", Age = 30 },
            new { Name = "David", Age = 35 },
            new { Name = "Charlie", Age = 40 }
        ];

        var sortedArray1 = unsortedArray1.ExecuteMergeSort(SortOrder.Ascending, Comparer<object>.Create((x, y) =>
        {
            var ageX = (int)x.GetType().GetProperty("Age")?.GetValue(x)!;
            var ageY = (int)y.GetType().GetProperty("Age")?.GetValue(y)!;

            if (ageX < ageY)
                return -1;

            return ageX > ageY ? 1 : 0;
        }));

        Assert.Equal(expectedArray1, sortedArray1);
    }

    [Fact]
    public void SortGeneric_ShouldReturnArrayInDescendingOrder_WhenArrayHasAnonymousObjectsWithWageComparer()
    {
        object[] unsortedArray1 =
        [
            new { Name = "Alice", Wage = 1200 },
            new { Name = "Bob", Wage = 6000 },
            new { Name = "Charlie", Wage = 1000 },
            new { Name = "David", Wage = 3000 },
            new { Name = "Eva", Wage = 2000 }
        ];

        object[] expectedArray1 =
        [
            new { Name = "Bob", Wage = 6000 },
            new { Name = "David", Wage = 3000 },
            new { Name = "Eva", Wage = 2000 },
            new { Name = "Alice", Wage = 1200 },
            new { Name = "Charlie", Wage = 1000 }
        ];

        var sortedArray1 = unsortedArray1.ExecuteMergeSort(SortOrder.Descending, Comparer<object>.Create((x, y) =>
        {
            var wageX = (IComparable)x.GetType().GetProperty("Wage")?.GetValue(x)!;
            var wageY = (IComparable)y.GetType().GetProperty("Wage")?.GetValue(y)!;

            var wageComparison = Comparer<object>.Default.Compare(wageX, wageY);

            return wageComparison;
        }));

        Assert.Equal(expectedArray1, sortedArray1);
    }

    [Fact]
    public void Sort_ShouldReturnArrayInDescendingOrder_WhenArrayHasAnonymousObjectsWithWageComparer()
    {
        object[] unsortedArray1 =
        [
            new { Name = "Alice", Wage = 1200 },
            new { Name = "Bob", Wage = 6000 },
            new { Name = "Charlie", Wage = 1000 },
            new { Name = "David", Wage = 3000 },
            new { Name = "Eva", Wage = 2000 }
        ];

        object[] expectedArray1 =
        [
            new { Name = "Bob", Wage = 6000 },
            new { Name = "David", Wage = 3000 },
            new { Name = "Eva", Wage = 2000 },
            new { Name = "Alice", Wage = 1200 },
            new { Name = "Charlie", Wage = 1000 }
        ];

        var sortedArray1 = unsortedArray1.ExecuteMergeSort(SortOrder.Descending, Comparer<object>.Create((x, y) =>
        {
            var wageX = (IComparable)x.GetType().GetProperty("Wage")?.GetValue(x)!;
            var wageY = (IComparable)y.GetType().GetProperty("Wage")?.GetValue(y)!;

            var wageComparison = Comparer<object>.Default.Compare(wageX, wageY);

            return wageComparison;
        }));

        Assert.Equal(expectedArray1, sortedArray1);
    }
}