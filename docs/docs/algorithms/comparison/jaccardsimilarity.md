# JaccardSimilarity Class

**Implementation of the Jaccard Similarity algorithm for calculating the similarity between two strings.**

## JaccardSimilarity Class Members

```csharp
CalculateJaccardSimilarity(
    string text1,
    string text2)
```

Calculates the Jaccard similarity between two strings.

## Parameters

- `text1` (Type: `string`): The first string to compare.
- `text2` (Type: `string`): The second string to compare.

## Returns

- Type: `double`
- Description: A double value representing the similarity between the two strings, ranging from 0.00 to 1.00.

## Example

```csharp
using NetPlus.Algorithms.Comparison;

// Example strings
string text1 = "Hello World";
string text2 = "Hello";

// Calculating Jaccard Similarity
double similarity = text1.CalculateJaccardSimilarity(text2);

// Displaying the similarity
Console.WriteLine(similarity);
```

## Usage

To use the `JaccardSimilarity` class, simply call the `CalculateJaccardSimilarity` method with the appropriate parameters.

```csharp
// Example usage
double similarity = text1.CalculateJaccardSimilarity(text2);
```

## Remarks

The `JaccardSimilarity` class uses the Jaccard Similarity algorithm to calculate the similarity between two strings. It returns a double value representing the similarity between the two strings, ranging from 0.00 to 1.00.

```csharp
// Example of different strings
string text1 = "Hello World";
string text2 = "Goodbye";

// Calculating Jaccard Similarity
double similarity = text1.CalculateJaccardSimilarity(text2);

// Displaying the similarity
Console.WriteLine(similarity); // Outputs: 0.0
```

In the above example, the strings are different, so the method returns 0.0.
