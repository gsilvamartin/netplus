namespace NetPlus.Extensions.LINQ
{
    /// <summary>
    /// Provides extension methods for LINQ operations on numbers.
    /// </summary>
    public static class LinqNumberExtensions
    {
        /// <summary>
        /// Determines whether the number is between the specified values.
        /// </summary>
        /// <param name="source">The number to check.</param>
        /// <param name="lowerBound">The lower bound of the range.</param>
        /// <param name="upperBound">The upper bound of the range.</param>
        /// <returns><c>true</c> if the number is between the specified values; otherwise, <c>false</c>.</returns>
        public static bool IsBetween(this int source, int lowerBound, int upperBound)
        {
            return source >= lowerBound && source <= upperBound;
        }

        /// <summary>
        /// Determines whether the number is between the specified values.
        /// </summary>
        /// <param name="source">The number to check.</param>
        /// <param name="lowerBound">The lower bound of the range.</param>
        /// <param name="upperBound">The upper bound of the range.</param>
        /// <returns><c>true</c> if the number is between the specified values; otherwise, <c>false</c>.</returns>
        public static bool IsBetween(this double source, double lowerBound, double upperBound)
        {
            return source >= lowerBound && source <= upperBound;
        }

        /// <summary>
        /// Determines whether the number is odd.
        /// </summary>
        /// <param name="source">The number to check.</param>
        /// <returns><c>true</c> if the number is odd; otherwise, <c>false</c>.</returns>
        public static bool IsOdd(this int source)
        {
            return source % 2 != 0;
        }
    }
}