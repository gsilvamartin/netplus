# BubbleSort Class

Provides methods for performing Bubble Sort on arrays.

## BubbleSort Class Members

```csharp
ExecuteBubbleSort<T>(this T[] array) where T : IComparable<T>
```

Sorts an array using the Bubble Sort algorithm in ascending order.

#### Parameters

- `array` (Type: `T[]`): The array to be sorted.

#### Returns

- Type: `T[]`
- Description: The sorted array in ascending order.

#### Example

```csharp
using NetPlus.Algorithms.Sorting;

// Example array
int[] myArray = { 4, 2, 7, 1, 9 };

// Sorting the array using Bubble Sort
var sortedArray = myArray.ExecuteBubbleSort();

// Displaying the sorted array
Console.WriteLine(string.Join(", ", sortedArray));
```

#### Usage

To use the BubbleSort class, simply call the ExecuteBubbleSort method on your array.

```csharp
int[] myArray = { 4, 2, 7, 1, 9 };
var sortedArray = BubbleSort.ExecuteBubbleSort(myArray);
```

#### Remarks

The BubbleSort class uses the Bubble Sort algorithm to sort arrays in ascending order.
It is an in-place sorting algorithm.
