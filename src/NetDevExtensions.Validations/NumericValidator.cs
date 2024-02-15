namespace NetDevExtensions.String;

public static class NumericValidator
{
    public static bool IsPositive<T>(this T input) where T : struct, IComparable<T>
    {
        return input.CompareTo(default(T)) > 0;
    }

    public static bool IsNegative<T>(this T input) where T : struct, IComparable<T>
    {
        return input.CompareTo(default(T)) < 0;
    }

    public static bool IsZero<T>(this T input) where T : struct, IComparable<T>
    {
        return input.CompareTo(default(T)) == 0;
    }

    public static bool IsEven<T>(this T input) where T : struct
    {
        dynamic value = input;
        return value % 2 == 0;
    }

    public static bool IsOdd<T>(this T input) where T : struct
    {
        dynamic value = input;
        return value % 2 != 0;
    }

    public static bool IsBetween<T>(this T input, T lower, T upper) where T : struct, IComparable<T>
    {
        return input.CompareTo(lower) >= 0 && input.CompareTo(upper) <= 0;
    }

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

    public static bool IsDivisibleBy<T>(this T input, T divisor) where T : struct
    {
        dynamic value = input;
        dynamic div = divisor;
        return value % div == 0;
    }

    public static bool IsPositiveOrZero<T>(this T input) where T : struct, IComparable<T>
    {
        return input.CompareTo(default(T)) >= 0;
    }

    public static bool IsNegativeOrZero<T>(this T input) where T : struct, IComparable<T>
    {
        return input.CompareTo(default(T)) <= 0;
    }

    public static bool IsBetweenOrEqual<T>(this T input, T lower, T upper) where T : struct, IComparable<T>
    {
        return input.CompareTo(lower) >= 0 && input.CompareTo(upper) <= 0;
    }

    public static bool IsPerfectSquare<T>(this T input) where T : struct
    {
        dynamic value = input;
        var sqrt = (int)Math.Sqrt((double)value);
        return sqrt * sqrt == value;
    }

    public static bool IsPalindrome<T>(this T input) where T : struct
    {
        var str = input.ToString();
        return str != null && str == new string(str.Reverse().ToArray());
    }

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

    public static bool IsAutomorphicNumber<T>(this T input) where T : struct, IComparable<T>
    {
        dynamic value = input;
        dynamic square = value * value;
        return square.ToString().EndsWith(value.ToString());
    }

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