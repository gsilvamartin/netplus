# JansenShannonSimilarity Class

**Implementation of the Jansen-Shannon Similarity algorithm for calculating the similarity between two strings.**

## JansenShannonSimilarity Class Members

```csharp
CalculateJansenShannonSimilarity(
    string text1,
    string text2)
```

Calculates the Jansen-Shannon similarity between two strings.

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

// Calculating Jansen-Shannon Similarity
double similarity = text1.CalculateJansenShannonSimilarity(text2);

// Displaying the similarity
Console.WriteLine(similarity);
```

## Usage

To use the `JansenShannonSimilarity` class, simply call the `CalculateJansenShannonSimilarity` method with the appropriate parameters.

```csharp
// Example usage
double similarity = text1.CalculateJansenShannonSimilarity(text2);
```

## Remarks

The `JansenShannonSimilarity` class uses the Jansen-Shannon Similarity algorithm to calculate the similarity between two strings. It returns a double value representing the similarity between the two strings, ranging from 0.00 to 1.00.

```csharp
// Example of different strings
string text1 = "Hello World";
string text2 = "Goodbye";

// Calculating Jansen-Shannon Similarity
double similarity = text1.CalculateJansenShannonSimilarity(text2);

// Displaying the similarity
Console.WriteLine(similarity); // Outputs: 0.0
```

In the above example, the strings are different, so the method returns 0.0.
