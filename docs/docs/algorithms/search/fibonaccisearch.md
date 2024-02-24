# FibonacciSearch Class

**Implementation of the Fibonacci Search algorithm for finding the index of a specific value in a sorted array.**

## FibonacciSearch Class Members

```csharp
SearchFibonacci<T>(
    T[] array,
    T value)
```

Performs Fibonacci search on a sorted array to find the index of a specific value.

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

// Performing Fibonacci search
int index = sortedArray.SearchFibonacci(value);

// Displaying the index
Console.WriteLine(index);
```

## Usage

To use the `FibonacciSearch` class, simply call the `SearchFibonacci` method with the appropriate parameters.

```csharp
// Example usage
int index = sortedArray.SearchFibonacci(value);
```

## Remarks

The `FibonacciSearch` class uses the Fibonacci Search algorithm to find the index of a specific value in a sorted array. It returns the index of the value if found, otherwise, it returns -1.

```csharp
// Example of a not found value
int value = 11;

// Performing Fibonacci search
int index = sortedArray.SearchFibonacci(value);

// Displaying the index
Console.WriteLine(index); // Outputs: -1
```

In the above example, the value 11 is not found in the array, so the method returns -1.
