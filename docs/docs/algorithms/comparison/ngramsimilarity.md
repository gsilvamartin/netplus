# NgramSimilarity Class

**Static class providing extension methods for calculating the N-gram similarity between two strings.**

## Class Members

```csharp
CalculateNgramSimilarity(
    string text1,
    string text2,
    int n = 2)
```

Calculates the N-gram similarity between two strings.

### Parameters

- `text1` (Type: `string`): The first string for comparison.
- `text2` (Type: `string`): The second string for comparison.
- `n` (Type: `int`): The size of N-grams to be used (default is 2).

### Returns

- Type: `double`
- Description: A double value representing the N-gram similarity between the two strings, ranging from 0.0 to 1.0.

### Example

```csharp
using NetPlus.Algorithms.Comparison;

// Example strings
string text1 = "Hello World";
string text2 = "Hello";

// Calculating N-gram similarity
double similarity = text1.CalculateNgramSimilarity(text2);

// Displaying similarity
Console.WriteLine(similarity);
```

### Usage

To use the `NgramSimilarity` class, simply call the `CalculateNgramSimilarity` method with the appropriate parameters.

```csharp
// Example usage
double similarity = text1.CalculateNgramSimilarity(text2);
```

### Remarks

The `NgramSimilarity` class uses the N-gram similarity algorithm to calculate the similarity between two strings. It returns a double value representing the similarity between the two strings, ranging from 0.0 to 1.0.
