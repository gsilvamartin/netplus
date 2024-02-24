# JaroWinklerSimilarity Class

**Static class providing extension methods for calculating the Jaro-Winkler similarity between two strings.**

## Class Members

```csharp
CalculateJaroWinklerSimilarity(
    string str1,
    string str2)
```

Calculates the Jaro-Winkler similarity between two strings.

### Parameters

- `str1` (Type: `string`): The first string for comparison.
- `str2` (Type: `string`): The second string for comparison.

### Returns

- Type: `double`
- Description: A double value representing the similarity between the two strings, ranging from 0.0 to 1.0.

### Example

```csharp
using NetPlus.Algorithms.Comparison;

// Example strings
string str1 = "Hello World";
string str2 = "Hello";

// Calculating Jaro-Winkler similarity
double similarity = str1.CalculateJaroWinklerSimilarity(str2);

// Displaying similarity
Console.WriteLine(similarity);
```

### Usage

To use the `JaroWinklerSimilarity` class, simply call the `CalculateJaroWinklerSimilarity` method with the appropriate parameters.

```csharp
// Example usage
double similarity = str1.CalculateJaroWinklerSimilarity(str2);
```

### Remarks

The `JaroWinklerSimilarity` class uses the Jaro-Winkler similarity algorithm to calculate the similarity between two strings. It returns a double value representing the similarity between the two strings, ranging from 0.0 to 1.0.
