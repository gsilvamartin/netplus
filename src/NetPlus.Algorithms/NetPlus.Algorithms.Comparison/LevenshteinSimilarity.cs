using System;

namespace NetPlus.Algorithms.Comparison
{
    /// <summary>
    /// A static class providing extension methods for calculating the Levenshtein similarity between two strings.
    /// </summary>
    public static class LevenshteinSimilarity
    {
        /// <summary>
        /// Calculates the Levenshtein similarity between two strings.
        /// </summary>
        /// <param name="source">The source string for comparison.</param>
        /// <param name="target">The target string for comparison.</param>
        /// <returns>An integer representing the Levenshtein similarity between the two strings.</returns>
        public static int CalculateLevenshteinSimilarity(this string source, string target)
        {
            var distanceMatrix = InitializeDistanceMatrix(source.Length, target.Length);

            FillDistanceMatrix(source, target, ref distanceMatrix);

            return distanceMatrix[source.Length, target.Length];
        }

        /// <summary>
        /// Initializes the distance matrix for the Levenshtein algorithm.
        /// </summary>
        /// <param name="rows">The number of rows in the matrix.</param>
        /// <param name="cols">The number of columns in the matrix.</param>
        /// <returns>A 2D array representing the initialized distance matrix.</returns>
        private static int[,] InitializeDistanceMatrix(int rows, int cols)
        {
            var distanceMatrix = new int[rows + 1, cols + 1];

            for (var i = 0; i <= rows; i++) distanceMatrix[i, 0] = i;
            for (var j = 0; j <= cols; j++) distanceMatrix[0, j] = j;

            return distanceMatrix;
        }

        /// <summary>
        /// Fills the distance matrix using the Levenshtein algorithm.
        /// </summary>
        /// <param name="source">The source string for comparison.</param>
        /// <param name="target">The target string for comparison.</param>
        /// <param name="distanceMatrix">The distance matrix to be filled.</param>
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
}