# LevenshteinSimilarity Class

**Static class providing extension methods for calculating the Levenshtein similarity between two strings.**

## Class Members

```csharp
CalculateLevenshteinSimilarity(
    string source,
    string target)
```

Calculates the Levenshtein similarity between two strings.

### Parameters

- `source` (Type: `string`): The source string for comparison.
- `target` (Type: `string`): The target string for comparison.

### Returns

- Type: `int`
- Description: An integer representing the Levenshtein similarity between the two strings.

### Example

```csharp
using NetPlus.Algorithms.Comparison;

// Example strings
string source = "Hello World";
string target = "Hello";

// Calculating Levenshtein similarity
int similarity = source.CalculateLevenshteinSimilarity(target);

// Displaying similarity
Console.WriteLine(similarity);
```

### Usage

To use the `LevenshteinSimilarity` class, simply call the `CalculateLevenshteinSimilarity` method with the appropriate parameters.

```csharp
// Example usage
int similarity = source.CalculateLevenshteinSimilarity(target);
```

### Remarks

The `LevenshteinSimilarity` class uses the Levenshtein algorithm to calculate the similarity between two strings. It returns an integer value representing the similarity between the two strings.
