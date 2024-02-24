# MergeSort Class

**Provides methods for performing Merge Sort on arrays.**

## MergeSort Class Members

```csharp
ExecuteMergeSort<T>(
    this T[] array,
    SortOrder sortOrder = SortOrder.Ascending,
    IComparer<T>? comparer = null)
```

Sorts an array using the Merge Sort algorithm.

## Parameters

- `array` (Type: `T[]`): The array to be sorted.
- `sortOrder` (Type: `SortOrder`, Default: `Ascending`): The order in which to sort the array (ascending or descending).
- `comparer` (Type: `IComparer<T>?`, Default: `null`): The comparer to use for custom element comparisons.

## Returns

- Type: `T[]`
- Description: The sorted array.

## Example

```csharp
using NetPlus.Algorithms.Sorting;

// Example array of custom objects
Person[] peopleArray = 
{
    new Person("John", 30),
    new Person("Alice", 25),
    new Person("Bob", 35),
    new Person("Eve", 28)
};

// Custom comparer for sorting Person objects by age
IComparer<Person> customComparer = new PersonAgeComparer();

// Sorting the array of Person objects using Merge Sort with custom comparer
var sortedPeopleArray = peopleArray.ExecuteMergeSort(SortOrder.Ascending, customComparer);

// Displaying the sorted array of Person objects
foreach (var person in sortedPeopleArray)
{
    Console.WriteLine($"Name: {person.Name}, Age: {person.Age}");
}
```

## Usage

To use the MergeSort class, simply call the `ExecuteMergeSort` method on your array.

```csharp
int[] myArray = { 4, 2, 7, 1, 9 };
var sortedArray = MergeSort.ExecuteMergeSort(myArray);
```

## Remarks

The `MergeSort` class uses the Merge Sort algorithm to sort arrays. It supports both ascending and descending order sorting, along with custom comparers.

```csharp
IComparer<T> customComparer = /* your custom comparer */;
var sortedArray = myArray.ExecuteMergeSort(SortOrder.Descending, customComparer);
```

## IComparer<T> Usage in MergeSort

The `MergeSort` class utilizes the `IComparer<T>` interface to provide flexibility in customizing the sorting logic. The `ExecuteMergeSort` method allows you to pass an optional `IComparer<T>` implementation for comparing elements during the sorting process.

### Using IComparer<T> with MergeSort

```csharp
using NetPlus.Algorithms.Sorting;

// Example array of custom objects
Person[] peopleArray = 
{
    new Person("John", 30),
    new Person("Alice", 25),
    new Person("Bob", 35),
    new Person("Eve", 28)
};

// Custom comparer for sorting Person objects by age
IComparer<Person> customComparer = new PersonAgeComparer();

// Sorting the array of Person objects using Merge Sort with custom comparer
var sortedPeopleArray = peopleArray.ExecuteMergeSort(SortOrder.Ascending, customComparer);

// Displaying the sorted array of Person objects
foreach (var person in sortedPeopleArray)
{
    Console.WriteLine($"Name: {person.Name}, Age: {person.Age}");
}
```

### Custom IComparer<T> Implementation

```csharp
public class PersonAgeComparer : IComparer<Person>
{
    public int Compare(Person x, Person y)
    {
        return x.Age.CompareTo(y.Age);
    }
}
```

The `PersonAgeComparer` class compares `Person` objects based on their age property. You can create similar custom comparers to tailor the sorting logic according to your specific requirements.

By leveraging the `IComparer<T>` interface, the `MergeSort` class provides a way to incorporate custom comparisons while maintaining the efficiency of the Merge Sort algorithm. This enables you to apply different sorting criteria to various types of objects within the same sorting algorithm.
