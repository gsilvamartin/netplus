# BinarySearch Class

**A static class containing the implementation of Binary Search algorithm.**

## BinarySearch Class Members

```csharp
SearchBinary<T>(this T[] array, T value) where T : IComparable<T>
```

Performs binary search on a sorted array to find the index of a specific value.

## Parameters

- `array` (Type: `T[]`): The sorted array to search.
- `value` (Type: `T`): The value to search for.

## Returns

- Type: `int`
- Description: The index of the value in the array, or -1 if not found.

## Example

```csharp
using NetPlus.Algorithms.Search;

// Example sorted array
var sortedArray = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

// Using BinarySearch to find the index of a value
var index = sortedArray.SearchBinary(5);

// Displaying the result
Console.WriteLine("Index of 5: " + index);
```

## Usage

To use the BinarySearch class, call the `SearchBinary` method on your sorted array.

```csharp
// Example usage
var index = sortedArray.SearchBinary(targetValue);
```

## Remarks

The BinarySearch class provides a static method for performing binary search on a sorted array to find the index of a specific value. It utilizes a recursive approach to divide the search range until the value is found or the range becomes empty.

```csharp
// Example of usage with a custom array type
var customArray = new CustomType[] { /* initialize your custom array */ };
var customIndex = customArray.SearchBinary(customValue);
```
