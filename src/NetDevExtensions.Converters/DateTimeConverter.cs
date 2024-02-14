using System.Globalization;

namespace NetDevExtensions.Converters;

public static class DateTimeConverter
{
    public static string ConvertDateTimeToString(this DateTime input)
    {
        return input.ToString(CultureInfo.CurrentCulture);
    }

    public static string ConvertDateTimeToString(this DateTime input, string format)
    {
        return input.ToString(format, CultureInfo.CurrentCulture);
    }

    public static string ConvertDateTimeToString(this DateTime input, string format, CultureInfo cultureInfo)
    {
        return input.ToString(format, cultureInfo);
    }

    public static string ConvertDateTimeToString(this DateTime input, CultureInfo cultureInfo)
    {
        return input.ToString(cultureInfo);
    }

    public static string ConvertDateTimeToString(this DateTime input, IFormatProvider formatProvider)
    {
        return input.ToString(formatProvider);
    }

    public static string ConvertDateTimeToString(this DateTime input, string format, IFormatProvider formatProvider)
    {
        return input.ToString(format, formatProvider);
    }

    public static DateTime ConvertStringToDateTime(this string input)
    {
        return DateTime.Parse(input);
    }

    public static DateTime ConvertStringToDateTime(this string input, IFormatProvider formatProvider)
    {
        return DateTime.Parse(input, formatProvider);
    }

    public static DateTime ConvertStringToDateTime(this string input, IFormatProvider formatProvider,
        DateTimeStyles dateTimeStyles)
    {
        return DateTime.Parse(input, formatProvider, dateTimeStyles);
    }

    public static DateTime ConvertStringToDateTime(this string input, string format, IFormatProvider formatProvider,
        DateTimeStyles dateTimeStyles)
    {
        return DateTime.ParseExact(input, format, formatProvider, dateTimeStyles);
    }

    public static DateTime ConvertStringToDateTime(this string input, string format, IFormatProvider formatProvider)
    {
        return DateTime.ParseExact(input, format, formatProvider);
    }

    public static DateTime ConvertStringToDateTime(this string input, string format)
    {
        return DateTime.ParseExact(input, format, CultureInfo.CurrentCulture);
    }

    public static DateTime ConvertStringToDateTime(this string input, string format, CultureInfo cultureInfo)
    {
        return DateTime.ParseExact(input, format, cultureInfo);
    }

    public static DateTime ConvertStringToDateTime(this string input, string format, CultureInfo cultureInfo,
        DateTimeStyles dateTimeStyles)
    {
        return DateTime.ParseExact(input, format, cultureInfo, dateTimeStyles);
    }

    public static DateTime ConvertStringToDateTime(this string input, DateTimeStyles dateTimeStyles)
    {
        return DateTime.Parse(input, CultureInfo.CurrentCulture, dateTimeStyles);
    }

    public static DateTime ConvertStringToDateTime(this string input, string format, DateTimeStyles dateTimeStyles)
    {
        return DateTime.ParseExact(input, format, CultureInfo.CurrentCulture, dateTimeStyles);
    }

    public static DateTime ConvertStringToDateTime(this string input, string format, DateTimeStyles dateTimeStyles,
        IFormatProvider formatProvider)
    {
        return DateTime.ParseExact(input, format, formatProvider, dateTimeStyles);
    }
}