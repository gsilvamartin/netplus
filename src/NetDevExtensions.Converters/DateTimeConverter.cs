using System.Globalization;

namespace NetDevExtensions.Converters;

/// <summary>
/// A static class providing extension methods for converting DateTime to string and vice versa.
/// </summary>
public static class DateTimeConverter
{
    /// <summary>
    /// Converts a DateTime object to a string using the current culture's formatting.
    /// </summary>
    /// <param name="input">The DateTime object to convert.</param>
    /// <returns>A string representation of the DateTime.</returns>
    public static string ConvertDateTimeToString(this DateTime input)
    {
        return input.ToString(CultureInfo.CurrentCulture);
    }

    /// <summary>
    /// Converts a DateTime object to a string using the specified format and the current culture's formatting.
    /// </summary>
    /// <param name="input"></param>
    /// <param name="format"></param>
    /// <returns>A string representation of The DateTime.</returns>
    public static string ConvertDateTimeToString(this DateTime input, string format)
    {
        return input.ToString(format, CultureInfo.CurrentCulture);
    }

    /// <summary>
    /// Converts a DateTime object to a string using the specified format and culture.
    /// </summary>
    /// <param name="input"></param>
    /// <param name="format"></param>
    /// <param name="cultureInfo"></param>
    /// <returns>A string representation of the DateTime.</returns>
    public static string ConvertDateTimeToString(this DateTime input, string format, CultureInfo cultureInfo)
    {
        return input.ToString(format, cultureInfo);
    }

    /// <summary>
    /// Converts a DateTime object to a string using the specified culture.
    /// </summary>
    /// <param name="input"></param>
    /// <param name="cultureInfo"></param>
    /// <returns>A string representation of the DateTime.</returns>
    public static string ConvertDateTimeToString(this DateTime input, CultureInfo cultureInfo)
    {
        return input.ToString(cultureInfo);
    }

    /// <summary>
    /// Converts a DateTime object to a string using the specified format provider.
    /// </summary>
    /// <param name="input"></param>
    /// <param name="formatProvider"></param>
    /// <returns>A string representation of the DateTime.</returns>
    public static string ConvertDateTimeToString(this DateTime input, IFormatProvider formatProvider)
    {
        return input.ToString(formatProvider);
    }

    /// <summary>
    /// Converts a DateTime object to a string using the specified format and format provider.
    /// </summary>
    /// <param name="input"></param>
    /// <param name="format"></param>
    /// <param name="formatProvider"></param>
    /// <returns>A string representation of the DateTime.</returns>
    public static string ConvertDateTimeToString(this DateTime input, string format, IFormatProvider formatProvider)
    {
        return input.ToString(format, formatProvider);
    }

    /// <summary>
    /// Converts a string to a DateTime object using the current culture's formatting.
    /// </summary>
    /// <param name="input"></param>
    /// <returns>A DateTime representation of string</returns>
    public static DateTime ConvertStringToDateTime(this string input)
    {
        return DateTime.Parse(input);
    }

    /// <summary>
    /// Converts a string to a DateTime object using the specified format provider.
    /// </summary>
    /// <param name="input"></param>
    /// <param name="formatProvider"></param>
    /// <returns>A DateTime representation of string</returns>
    public static DateTime ConvertStringToDateTime(this string input, IFormatProvider formatProvider)
    {
        return DateTime.Parse(input, formatProvider);
    }

    /// <summary>
    /// Converts a string to a DateTime object using the specified format provider and DateTimeStyles.
    /// </summary>
    /// <param name="input"></param>
    /// <param name="formatProvider"></param>
    /// <param name="dateTimeStyles"></param>
    /// <returns>A DateTime representation of string</returns>
    public static DateTime ConvertStringToDateTime(
        this string input,
        IFormatProvider formatProvider,
        DateTimeStyles dateTimeStyles)
    {
        return DateTime.Parse(input, formatProvider, dateTimeStyles);
    }

    /// <summary>
    /// Converts a string to a DateTime object using the specified format provider, format and dateTimeStyle.
    /// </summary>
    /// <param name="input"></param>
    /// <param name="format"></param>
    /// <param name="formatProvider"></param>
    /// <param name="dateTimeStyles"></param>
    /// <returns>A DateTime representation of string</returns>
    public static DateTime ConvertStringToDateTime(
        this string input,
        string format,
        IFormatProvider formatProvider,
        DateTimeStyles dateTimeStyles)
    {
        return DateTime.ParseExact(input, format, formatProvider, dateTimeStyles);
    }

    /// <summary>
    /// Converts a string to a DateTime object using the specified format and format provider.
    /// </summary>
    /// <param name="input"></param>
    /// <param name="format"></param>
    /// <param name="formatProvider"></param>
    /// <returns>A DateTime representation of string</returns>
    public static DateTime ConvertStringToDateTime(this string input, string format, IFormatProvider formatProvider)
    {
        return DateTime.ParseExact(input, format, formatProvider);
    }

    /// <summary>
    /// Converts a string to a DateTime object using the specified format.
    /// </summary>
    /// <param name="input"></param>
    /// <param name="format"></param>
    /// <returns>A DateTime representation of string</returns>
    public static DateTime ConvertStringToDateTime(this string input, string format)
    {
        return DateTime.ParseExact(input, format, CultureInfo.CurrentCulture);
    }

    /// <summary>
    /// Converts a string to a DateTime object using the specified format and culture.
    /// </summary>
    /// <param name="input"></param>
    /// <param name="format"></param>
    /// <param name="cultureInfo"></param>
    /// <returns>A DateTime representation of string</returns>
    public static DateTime ConvertStringToDateTime(this string input, string format, CultureInfo cultureInfo)
    {
        return DateTime.ParseExact(input, format, cultureInfo);
    }

    /// <summary>
    /// Converts a string to a DateTime object using the specified format, culture and DateTimeStyles.
    /// </summary>
    /// <param name="input"></param>
    /// <param name="format"></param>
    /// <param name="cultureInfo"></param>
    /// <param name="dateTimeStyles"></param>
    /// <returns>A DateTime representation of string</returns>
    public static DateTime ConvertStringToDateTime(this string input, string format, CultureInfo cultureInfo,
        DateTimeStyles dateTimeStyles)
    {
        return DateTime.ParseExact(input, format, cultureInfo, dateTimeStyles);
    }

    /// <summary>
    /// Converts a string to a DateTime object using the specified format and DateTimeStyles.
    /// </summary>
    /// <param name="input"></param>
    /// <param name="dateTimeStyles"></param>
    /// <returns>A DateTime representation of string</returns>
    public static DateTime ConvertStringToDateTime(this string input, DateTimeStyles dateTimeStyles)
    {
        return DateTime.Parse(input, CultureInfo.CurrentCulture, dateTimeStyles);
    }

    /// <summary>
    /// Converts a string to a DateTime object using the specified format and DateTimeStyles.
    /// </summary>
    /// <param name="input"></param>
    /// <param name="format"></param>
    /// <param name="dateTimeStyles"></param>
    /// <returns>A DateTime representation of string</returns>
    public static DateTime ConvertStringToDateTime(this string input, string format, DateTimeStyles dateTimeStyles)
    {
        return DateTime.ParseExact(input, format, CultureInfo.CurrentCulture, dateTimeStyles);
    }

    /// <summary>
    /// Converts a string to a DateTime object using the specified format, DateTimeStyles and format provider.
    /// </summary>
    /// <param name="input"></param>
    /// <param name="format"></param>
    /// <param name="dateTimeStyles"></param>
    /// <param name="formatProvider"></param>
    /// <returns>A DateTime representation of string</returns>
    public static DateTime ConvertStringToDateTime(
        this string input,
        string format,
        DateTimeStyles dateTimeStyles,
        IFormatProvider formatProvider)
    {
        return DateTime.ParseExact(input, format, formatProvider, dateTimeStyles);
    }
}