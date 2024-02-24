# HeapSort Class

**Provides methods for performing Heap Sort on arrays.**

## HeapSort Class Members

```csharp
Sort<T>(this T[] array) where T : IComparable<T>
```

Sorts an array using the Heap Sort algorithm.

## Parameters

- `array` (Type: `T[]`): The array to be sorted.

## Returns

- Type: `T[]`
- Description: The sorted array.

## Example

```csharp
using NetPlus.Algorithms.Sorting;

// Example array
int[] myArray = { 4, 2, 7, 1, 9 };

// Sorting the array using Heap Sort
var sortedArray = myArray.ExecuteHeapSort();

// Displaying the sorted array
Console.WriteLine(string.Join(", ", sortedArray));
```

## Usage

To use the HeapSort class, simply call the `ExecuteHeapSort` method on your array.

```csharp
int[] myArray = { 4, 2, 7, 1, 9 };
var sortedArray = HeapSort.ExecuteHeapSort(myArray);
```

## Remarks

The `HeapSort` class uses the Heap Sort algorithm to sort arrays. It is an in-place sorting algorithm.
