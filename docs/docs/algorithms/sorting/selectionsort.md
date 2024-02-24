# SelectionSort Class

**Provides methods for performing Selection Sort on arrays.**

## SelectionSort Class Members

```csharp
ExecuteSelectionSort<T>(this T[] array) where T : IComparable<T>
```

Sorts an array using the Selection Sort algorithm.

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

// Sorting the array using Selection Sort
var sortedArray = myArray.ExecuteSelectionSort();

// Displaying the sorted array
Console.WriteLine(string.Join(", ", sortedArray));
```

## Usage

To use the SelectionSort class, simply call the `ExecuteSelectionSort` method on your array.

```csharp
int[] myArray = { 4, 2, 7, 1, 9 };
var sortedArray = SelectionSort.ExecuteSelectionSort(myArray);
```

## Remarks

The `SelectionSort` class uses the Selection Sort algorithm to sort arrays in ascending order. It is an in-place sorting algorithm.

```csharp
// Example of sorting custom objects
Person[] peopleArray = 
{
    new Person("John", 30),
    new Person("Alice", 25),
    new Person("Bob", 35),
    new Person("Eve", 28)
};

// Sorting the array of Person objects using Selection Sort
var sortedPeopleArray = peopleArray.ExecuteSelectionSort();
```

In the above example, the `ExecuteSelectionSort` method is used to sort an array of custom objects (`Person`) based on their natural order.

Note: The type `T` must implement the `IComparable<T>` interface for the sorting to work.
