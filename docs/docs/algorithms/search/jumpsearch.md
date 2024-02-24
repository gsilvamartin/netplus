# JumpSearch Class

**Implementation of the Jump Search algorithm for finding the index of a specific value in a sorted array.**

## JumpSearch Class Members

```csharp
SearchJump<T>(
    T[] array,
    T value)
```

Performs Jump search on a sorted array to find the index of a specific value.

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

// Performing Jump search
int index = sortedArray.SearchJump(value);

// Displaying the index
Console.WriteLine(index);
```

## Usage

To use the `JumpSearch` class, simply call the `SearchJump` method with the appropriate parameters.

```csharp
// Example usage
int index = sortedArray.SearchJump(value);
```

## Remarks

The `JumpSearch` class uses the Jump Search algorithm to find the index of a specific value in a sorted array. It returns the index of the value if found, otherwise, it returns -1.

```csharp
// Example of a not found value
int value = 11;

// Performing Jump search
int index = sortedArray.SearchJump(value);

// Displaying the index
Console.WriteLine(index); // Outputs: -1
```

In the above example, the value 11 is not found in the array, so the method returns -1.
