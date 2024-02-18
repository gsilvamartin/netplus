namespace NetDevExtensions.Validators;

/// <summary>
/// Static class containing numeric validation methods.
/// </summary>
public static class NumericValidator
{
    /// <summary>
    /// Determines whether the specified value is positive.
    /// </summary>
    /// <typeparam name="T">The type of the input value.</typeparam>
    /// <param name="input">The input value.</param>
    /// <returns><c>true</c> if the specified value is positive; otherwise, <c>false</c>.</returns>
    public static bool IsPositive<T>(this T input) where T : struct, IComparable<T>
    {
        return input.CompareTo(default) > 0;
    }

    /// <summary>
    /// Determines whether the specified value is negative.
    /// </summary>
    /// <typeparam name="T">The type of the input value.</typeparam>
    /// <param name="input">The input value.</param>
    /// <returns><c>true</c> if the specified value is negative; otherwise, <c>false</c>.</returns>
    public static bool IsNegative<T>(this T input) where T : struct, IComparable<T>
    {
        return input.CompareTo(default(T)) < 0;
    }

    /// <summary>
    /// Determines whether the specified value is zero.
    /// </summary>
    /// <typeparam name="T">The type of the input value.</typeparam>
    /// <param name="input">The input value.</param>
    /// <returns><c>true</c> if the specified value is zero; otherwise, <c>false</c>.</returns>
    public static bool IsZero<T>(this T input) where T : struct, IComparable<T>
    {
        return input.CompareTo(default(T)) == 0;
    }

    /// <summary>
    /// Determines whether the specified value is even.
    /// </summary>
    /// <typeparam name="T">The type of the input value.</typeparam>
    /// <param name="input">The input value.</param>
    /// <returns><c>true</c> if the specified value is even; otherwise, <c>false</c>.</returns>
    public static bool IsEven<T>(this T input) where T : struct
    {
        dynamic value = input;
        return value % 2 == 0;
    }

    /// <summary>
    /// Determines whether the specified value is odd.
    /// </summary>
    /// <typeparam name="T">The type of the input value.</typeparam>
    /// <param name="input">The input value.</param>
    /// <returns><c>true</c> if the specified value is odd; otherwise, <c>false</c>.</returns>
    public static bool IsOdd<T>(this T input) where T : struct
    {
        dynamic value = input;
        return value % 2 != 0;
    }

    /// <summary>
    /// Determines whether the specified value is between the specified lower and upper bounds.
    /// </summary>
    /// <typeparam name="T">The type of the input value.</typeparam>
    /// <param name="input">The input value.</param>
    /// <param name="lower">The lower bound.</param>
    /// <param name="upper">The upper bound.</param>
    /// <returns><c>true</c> if the specified value is between the lower and upper bounds (inclusive); otherwise, <c>false</c>.</returns>
    public static bool IsBetween<T>(this T input, T lower, T upper) where T : struct, IComparable<T>
    {
        return input.CompareTo(lower) >= 0 && input.CompareTo(upper) <= 0;
    }

    /// <summary>
    /// Determines whether the specified value is a prime number.
    /// </summary>
    /// <typeparam name="T">The type of the input value.</typeparam>
    /// <param name="input">The input value.</param>
    /// <returns><c>true</c> if the specified value is a prime number; otherwise, <c>false</c>.</returns>
    public static bool IsPrime<T>(this T input) where T : struct, IComparable<T>
    {
        dynamic value = input;
        if (value <= 1)
            return false;
        if (value <= 3)
            return true;
        if (value % 2 == 0 || value % 3 == 0)
            return false;
        for (int i = 5; i * i <= value; i += 6)
        {
            if (value % i == 0 || value % (i + 2) == 0)
                return false;
        }

        return true;
    }

    /// <summary>
    /// Determines whether the specified value is divisible by the given divisor.
    /// </summary>
    /// <typeparam name="T">The type of the input value.</typeparam>
    /// <param name="input">The input value.</param>
    /// <param name="divisor">The divisor.</param>
    /// <returns><c>true</c> if the specified value is divisible by the divisor; otherwise, <c>false</c>.</returns>
    public static bool IsDivisibleBy<T>(this T input, T divisor) where T : struct
    {
        dynamic value = input;
        dynamic div = divisor;
        return value % div == 0;
    }

    /// <summary>
    /// Determines whether the specified value is positive or zero.
    /// </summary>
    /// <typeparam name="T">The type of the input value.</typeparam>
    /// <param name="input">The input value.</param>
    /// <returns><c>true</c> if the specified value is positive or zero; otherwise, <c>false</c>.</returns>
    public static bool IsPositiveOrZero<T>(this T input) where T : struct, IComparable<T>
    {
        return input.CompareTo(default(T)) >= 0;
    }

    /// <summary>
    /// Determines whether the specified value is negative or zero.
    /// </summary>
    /// <typeparam name="T">The type of the input value.</typeparam>
    /// <param name="input">The input value.</param>
    /// <returns><c>true</c> if the specified value is negative or zero; otherwise, <c>false</c>.</returns>
    public static bool IsNegativeOrZero<T>(this T input) where T : struct, IComparable<T>
    {
        return input.CompareTo(default(T)) <= 0;
    }

    /// <summary>
    /// Determines whether the specified value is between the specified lower and upper bounds or equal to them.
    /// </summary>
    /// <typeparam name="T">The type of the input value.</typeparam>
    /// <param name="input">The input value.</param>
    /// <param name="lower">The lower bound.</param>
    /// <param name="upper">The upper bound.</param>
    /// <returns><c>true</c> if the specified value is between or equal to the lower and upper bounds; otherwise, <c>false</c>.</returns>
    public static bool IsBetweenOrEqual<T>(this T input, T lower, T upper) where T : struct, IComparable<T>
    {
        return input.CompareTo(lower) >= 0 && input.CompareTo(upper) <= 0;
    }

    /// <summary>
    /// Determines whether the specified value is a perfect square.
    /// </summary>
    /// <typeparam name="T">The type of the input value.</typeparam>
    /// <param name="input">The input value.</param>
    /// <returns><c>true</c> if the specified value is a perfect square; otherwise, <c>false</c>.</returns>
    public static bool IsPerfectSquare<T>(this T input) where T : struct
    {
        dynamic value = input;
        var sqrt = (int)Math.Sqrt((double)value);
        return sqrt * sqrt == value;
    }

    /// <summary>
    /// Determines whether the specified value is a palindrome.
    /// </summary>
    /// <typeparam name="T">The type of the input value.</typeparam>
    /// <param name="input">The input value.</param>
    /// <returns><c>true</c> if the specified value is a palindrome; otherwise, <c>false</c>.</returns>
    public static bool IsPalindrome<T>(this T input) where T : struct
    {
        var str = input.ToString();
        return str != null && str == new string(str.Reverse().ToArray());
    }

    /// <summary>
    /// Determines whether the specified value is an Armstrong number.
    /// </summary>
    /// <typeparam name="T">The type of the input value.</typeparam>
    /// <param name="input">The input value.</param>
    /// <returns><c>true</c> if the specified value is an Armstrong number; otherwise, <c>false</c>.</returns>
    public static bool IsArmstrongNumber<T>(this T input) where T : struct, IComparable<T>
    {
        dynamic value = input;
        var str = value.ToString();
        var n = str.Length;
        dynamic sum = 0;
        for (dynamic i = 0; i < n; i++)
        {
            dynamic digit = str[i] - '0';
            sum += Power(digit, n);
        }

        return sum == value;
    }

    /// <summary>
    /// Determines whether the specified value is a perfect number.
    /// </summary>
    /// <typeparam name="T">The type of the input value.</typeparam>
    /// <param name="input">The input value.</param>
    /// <returns><c>true</c> if the specified value is a perfect number; otherwise, <c>false</c>.</returns>
    public static bool IsPerfectNumber<T>(this T input) where T : struct, IComparable<T>
    {
        dynamic value = input;
        dynamic sum = 1;
        for (dynamic i = 2; i * i <= value; i++)
        {
            if (value % i != 0) continue;

            if (i * i != value)
                sum += i + value / i;
            else
                sum += i;
        }

        return sum == value && value != 1;
    }

    /// <summary>
    /// Determines whether the specified value is a Harshad number.
    /// </summary>
    /// <typeparam name="T">The type of the input value.</typeparam>
    /// <param name="input">The input value.</param>
    /// <returns><c>true</c> if the specified value is a Harshad number; otherwise, <c>false</c>.</returns>
    public static bool IsHarshadNumber<T>(this T input) where T : struct, IComparable<T>
    {
        dynamic value = input;
        dynamic sum = 0;
        dynamic temp = value;
        while (temp > 0)
        {
            sum += temp % 10;
            temp /= 10;
        }

        return value % sum == 0;
    }

    /// <summary>
    /// Determines whether the specified value is an abundant number.
    /// </summary>
    /// <typeparam name="T">The type of the input value.</typeparam>
    /// <param name="input">The input value.</param>
    /// <returns><c>true</c> if the specified value is an abundant number; otherwise, <c>false</c>.</returns>
    public static bool IsAbundantNumber<T>(this T input) where T : struct, IComparable<T>
    {
        dynamic value = input;
        dynamic sum = 1;
        for (dynamic i = 2; i * i <= value; i++)
        {
            if (value % i != 0) continue;

            if (i * i != value)
                sum += i + value / i;
            else
                sum += i;
        }

        return sum > value;
    }

    /// <summary>
    /// Determines whether the specified value is a deficient number.
    /// </summary>
    /// <typeparam name="T">The type of the input value.</typeparam>
    /// <param name="input">The input value.</param>
    /// <returns><c>true</c> if the specified value is a deficient number; otherwise, <c>false</c>.</returns>
    public static bool IsDeficientNumber<T>(this T input) where T : struct, IComparable<T>
    {
        dynamic value = input;
        dynamic sum = 1;
        for (dynamic i = 2; i * i <= value; i++)
        {
            if (value % i != 0) continue;

            if (i * i != value)
                sum += i + value / i;
            else
                sum += i;
        }

        return sum < value;
    }

    /// <summary>
    /// Determines whether the specified value is a Pronic number.
    /// </summary>
    /// <typeparam name="T">The type of the input value.</typeparam>
    /// <param name="input">The input value.</param>
    /// <returns><c>true</c> if the specified value is a Pronic number; otherwise, <c>false</c>.</returns>
    public static bool IsPronicNumber<T>(this T input) where T : struct, IComparable<T>
    {
        dynamic value = input;
        dynamic n = 0;
        while (n * (n + 1) < value)
        {
            if (n * (n + 1) == value)
                return true;
            n++;
        }

        return false;
    }

    /// <summary>
    /// Determines whether the specified value is an Automorphic number.
    /// </summary>
    /// <typeparam name="T">The type of the input value.</typeparam>
    /// <param name="input">The input value.</param>
    /// <returns><c>true</c> if the specified value is an Automorphic number; otherwise, <c>false</c>.</returns>
    public static bool IsAutomorphicNumber<T>(this T input) where T : struct, IComparable<T>
    {
        dynamic value = input;
        dynamic square = value * value;
        return square.ToString().EndsWith(value.ToString());
    }

    /// <summary>
    /// Determines whether the specified value is a Happy number.
    /// </summary>
    /// <typeparam name="T">The type of the input value.</typeparam>
    /// <param name="input">The input value.</param>
    /// <returns><c>true</c> if the specified value is a Happy number; otherwise, <c>false</c>.</returns>
    public static bool IsHappyNumber<T>(this T input) where T : struct, IComparable<T>
    {
        dynamic value = input;
        var hashSet = new HashSet<dynamic>();
        while (value != 1 && !hashSet.Contains(value))
        {
            hashSet.Add(value);
            dynamic sum = 0;
            while (value > 0)
            {
                dynamic digit = value % 10;
                sum += digit * digit;
                value /= 10;
            }

            value = sum;
        }

        return value == 1;
    }

    /// <summary>
    /// Raises a value to the power of another value.
    /// </summary>
    /// <typeparam name="T">The type of the input value.</typeparam>
    /// <param name="x">The base value.</param>
    /// <param name="y">The exponent value.</param>
    /// <returns>The result of raising <paramref name="x"/> to the power of <paramref name="y"/>.</returns>
    private static T Power<T>(this T x, T y) where T : struct, IComparable<T>
    {
        dynamic value = x;
        dynamic power = y;
        dynamic result = 1;
        for (dynamic i = 0; i < power; i++)
        {
            result *= value;
        }

        return result;
    }
}