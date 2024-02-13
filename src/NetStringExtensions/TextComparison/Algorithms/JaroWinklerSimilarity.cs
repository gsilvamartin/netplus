namespace NetStringExtensions.TextComparison.Algorithms;

public class JaroWinklerSimilarity
{
    public static double Calculate(string str1, string str2)
    {
        const double scalingFactor = 0.1;

        var jaroSimilarity = CalculateJaroSimilarity(str1, str2);
        var commonPrefixLength = GetCommonPrefixLength(str1, str2);

        var winklerDistance = jaroSimilarity +
                              (commonPrefixLength * scalingFactor * (1 - jaroSimilarity));

        return winklerDistance;
    }

    private static double CalculateJaroSimilarity(string str1, string str2)
    {
        var matchingCharacters = CountMatchingCharacters(str1, str2);
        var transpositions = CountTranspositions(str1, str2);

        if (matchingCharacters == 0)
        {
            return 0.0;
        }

        double m = matchingCharacters;
        double t = transpositions;

        return (m / str1.Length + m / str2.Length + (m - t) / m) / 3.0;
    }

    private static int CountMatchingCharacters(string str1, string str2)
    {
        var matchingCharacters = 0;
        var matchDistance = Math.Max(str1.Length, str2.Length) / 2 - 1;

        var str2Matches = new bool[str2.Length];

        for (var i = 0; i < str1.Length; i++)
        {
            var start = Math.Max(0, i - matchDistance);
            var end = Math.Min(i + matchDistance + 1, str2.Length);

            for (var j = start; j < end; j++)
            {
                if (str2Matches[j] || str1[i] != str2[j]) continue;

                matchingCharacters++;
                str2Matches[j] = true;
                break;
            }
        }

        return matchingCharacters;
    }

    private static int CountTranspositions(string str1, string str2)
    {
        var transpositions = 0;
        var index = 0;

        for (var i = 0; i < str1.Length; i++)
        {
            if (GetCommonPrefixLength(str1, str2, i) != i) continue;

            while (index < str2.Length && GetCommonPrefixLength(str1, str2, i, index) == i) index++;

            if (index < str2.Length && str1[i] != str2[index]) transpositions++;
        }

        return transpositions / 2;
    }

    private static int GetCommonPrefixLength(string str1, string str2)
    {
        var commonPrefix = 0;
        var minLength = Math.Min(str1.Length, str2.Length);

        while (commonPrefix < minLength && str1[commonPrefix] == str2[commonPrefix]) commonPrefix++;

        return commonPrefix;
    }

    private static int GetCommonPrefixLength(string str1, string str2, int start)
    {
        var commonPrefix = 0;
        var minLength = Math.Min(str1.Length - start, str2.Length);

        while (commonPrefix < minLength && str1[start + commonPrefix] == str2[commonPrefix]) commonPrefix++;

        return commonPrefix;
    }

    private static int GetCommonPrefixLength(string str1, string str2, int start1, int start2)
    {
        var commonPrefix = 0;
        var minLength = Math.Min(str1.Length - start1, str2.Length - start2);

        while (commonPrefix < minLength && str1[start1 + commonPrefix] == str2[start2 + commonPrefix]) commonPrefix++;

        return commonPrefix;
    }
}