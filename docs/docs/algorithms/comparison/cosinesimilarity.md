# CosineSimilarity Class

**Implementation of the Cosine Similarity algorithm for calculating the similarity between two strings.**

## CosineSimilarity Class Members

```csharp
CalculateCosineSimilarity(
    string text1,
    string text2)
```

Calculates the cosine similarity between two strings.

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

// Calculating Cosine Similarity
double similarity = text1.CalculateCosineSimilarity(text2);

// Displaying the similarity
Console.WriteLine(similarity);
```

## Usage

To use the `CosineSimilarity` class, simply call the `CalculateCosineSimilarity` method with the appropriate parameters.

```csharp
// Example usage
double similarity = text1.CalculateCosineSimilarity(text2);
```

## Remarks

The `CosineSimilarity` class uses the Cosine Similarity algorithm to calculate the similarity between two strings. It returns a double value representing the similarity between the two strings, ranging from 0.00 to 1.00.

```csharp
// Example of different strings
string text1 = "Hello World";
string text2 = "Goodbye";

// Calculating Cosine Similarity
double similarity = text1.CalculateCosineSimilarity(text2);

// Displaying the similarity
Console.WriteLine(similarity); // Outputs: 0.0
```

In the above example, the strings are different, so the method returns 0.0.
