namespace NetStringExtensions.TextComparison.Algorithms;

public static class LevenshteinSimilarity
{
    public static int Calculate(string source, string target)
    {
        var distanceMatrix = InitializeDistanceMatrix(source.Length, target.Length);

        FillDistanceMatrix(source, target, ref distanceMatrix);

        return distanceMatrix[source.Length, target.Length];
    }

    private static int[,] InitializeDistanceMatrix(int rows, int cols)
    {
        var distanceMatrix = new int[rows + 1, cols + 1];

        for (var i = 0; i <= rows; i++) distanceMatrix[i, 0] = i;
        for (var j = 0; j <= cols; j++) distanceMatrix[0, j] = j;

        return distanceMatrix;
    }

    private static void FillDistanceMatrix(string source, string target, ref int[,] distanceMatrix)
    {
        for (var i = 1; i <= source.Length; i++)
        {
            for (var j = 1; j <= target.Length; j++)
            {
                var cost = source[i - 1] == target[j - 1] ? 0 : 1;
                var insert = distanceMatrix[i, j - 1] + 1;
                var remove = distanceMatrix[i - 1, j] + 1;
                var replace = distanceMatrix[i - 1, j - 1] + cost;

                distanceMatrix[i, j] = Math.Min(Math.Min(insert, remove), replace);
            }
        }
    }
}