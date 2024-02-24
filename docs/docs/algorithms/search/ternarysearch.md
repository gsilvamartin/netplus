# TernarySearch Class

**Implementation of the Ternary Search algorithm for finding the index of a specific value in a sorted array.**

## TernarySearch Class Members

```csharp
SearchTernary<T>(
    T[] array,
    T value)
```

Performs Ternary search on a sorted array to find the index of a specific value.

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
int[] sortedArray = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

// Value to search for
int value = 7;

// Performing Ternary search
int index = sortedArray.SearchTernary(value);

// Displaying the index
Console.WriteLine(index);
```

## Usage

To use the `TernarySearch` class, simply call the `SearchTernary` method with the appropriate parameters.

```csharp
// Example usage
int index = sortedArray.SearchTernary(value);
```

## Remarks

The `TernarySearch` class uses the Ternary Search algorithm to find the index of a specific value in a sorted array. It returns the index of the value if found, otherwise, it returns -1.

```csharp
// Example of a not found value
int value = 11;

// Performing Ternary search
int index = sortedArray.SearchTernary(value);

// Displaying the index
Console.WriteLine(index); // Outputs: -1
```

In the above example, the value 11 is not found in the array, so the method returns -1.
