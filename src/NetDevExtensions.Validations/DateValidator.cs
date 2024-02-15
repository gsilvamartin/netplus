namespace NetDevExtensions.String;

public static class DateValidator
{
    public static bool IsDate<T>(this T input) where T : struct
    {
        return DateTime.TryParse(input.ToString(), out _);
    }

    public static bool IsFutureDate<T>(this T input) where T : struct
    {
        return DateTime.TryParse(input.ToString(), out var date) && date > DateTime.Now;
    }

    public static bool IsPastDate<T>(this T input) where T : struct
    {
        return DateTime.TryParse(input.ToString(), out var date) && date < DateTime.Now;
    }

    public static bool IsSameDay<T>(this T date1, T date2) where T : struct
    {
        return DateTime.TryParse(date1.ToString(), out var dt1) &&
               DateTime.TryParse(date2.ToString(), out var dt2) && dt1.Date == dt2.Date;
    }

    public static bool IsWeekend<T>(this T input) where T : struct
    {
        return DateTime.TryParse(input.ToString(), out var date) &&
               date.DayOfWeek is DayOfWeek.Saturday or DayOfWeek.Sunday;
    }

    public static bool IsWeekday<T>(this T input) where T : struct
    {
        return DateTime.TryParse(input.ToString(), out var date) && date.DayOfWeek != DayOfWeek.Saturday &&
               date.DayOfWeek != DayOfWeek.Sunday;
    }

    public static bool IsLeapYear<T>(this T input) where T : struct
    {
        return DateTime.TryParse(input.ToString(), out var date) && DateTime.IsLeapYear(date.Year);
    }

    public static bool IsToday<T>(this T input) where T : struct
    {
        return DateTime.TryParse(input.ToString(), out var date) && date.Date == DateTime.Today;
    }

    public static bool IsTomorrow<T>(this T input) where T : struct
    {
        return DateTime.TryParse(input.ToString(), out var date) && date.Date == DateTime.Today.AddDays(1);
    }

    public static bool IsYesterday<T>(this T input) where T : struct
    {
        return DateTime.TryParse(input.ToString(), out var date) && date.Date == DateTime.Today.AddDays(-1);
    }

    public static bool IsLastDayOfMonth<T>(this T input) where T : struct
    {
        return DateTime.TryParse(input.ToString(), out var date) &&
               date.Day == DateTime.DaysInMonth(date.Year, date.Month);
    }

    public static bool IsFirstDayOfMonth<T>(this T input) where T : struct
    {
        return DateTime.TryParse(input.ToString(), out var date) && date.Day == 1;
    }

    public static bool IsQuarter<T>(this T input, int quarter) where T : struct
    {
        return DateTime.TryParse(input.ToString(), out var date) &&
               (date.Month - 1) / 3 == quarter - 1;
    }

    public static bool IsSameMonth<T>(this T input, T otherDate) where T : struct
    {
        return DateTime.TryParse(input.ToString(), out var date) &&
               DateTime.TryParse(otherDate.ToString(), out var other) &&
               date.Month == other.Month && date.Year == other.Year;
    }

    public static bool IsSameYear<T>(this T input, T otherDate) where T : struct
    {
        return DateTime.TryParse(input.ToString(), out var date) &&
               DateTime.TryParse(otherDate.ToString(), out var other) && date.Year == other.Year;
    }

    public static bool IsSameHour<T>(this T input, T otherDate) where T : struct
    {
        return DateTime.TryParse(input.ToString(), out var date) &&
               DateTime.TryParse(otherDate.ToString(), out var other) &&
               date.Hour == other.Hour && date.Minute == other.Minute;
    }

    public static bool IsSameMinute<T>(this T input, T otherDate) where T : struct
    {
        return DateTime.TryParse(input.ToString(), out var date) &&
               DateTime.TryParse(otherDate.ToString(), out var other) &&
               date.Minute == other.Minute;
    }

    public static bool IsSameSecond<T>(this T input, T otherDate) where T : struct
    {
        return DateTime.TryParse(input.ToString(), out var date) &&
               DateTime.TryParse(otherDate.ToString(), out var other) &&
               date.Second == other.Second;
    }

    public static bool IsSameMillisecond<T>(this T input, T otherDate) where T : struct
    {
        return DateTime.TryParse(input.ToString(), out var date) &&
               DateTime.TryParse(otherDate.ToString(), out var other) &&
               date.Millisecond == other.Millisecond;
    }
}