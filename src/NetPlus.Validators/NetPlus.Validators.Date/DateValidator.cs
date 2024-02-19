namespace NetPlus.Validators.Date;

/// <summary>
/// Static class containing date validation methods.
/// </summary>
public static class DateValidator
{
    /// <summary>
    /// Determines whether the specified value is a valid date.
    /// </summary>
    /// <typeparam name="T">The type of the input value.</typeparam>
    /// <param name="input">The input value.</param>
    /// <returns><c>true</c> if the specified value is a valid date; otherwise, <c>false</c>.</returns>
    public static bool IsDate<T>(this T input) where T : struct
    {
        return DateTime.TryParse(input.ToString(), out _);
    }

    /// <summary>
    /// Determines whether the specified date is in the future.
    /// </summary>
    /// <typeparam name="T">The type of the input date.</typeparam>
    /// <param name="input">The input date.</param>
    /// <returns><c>true</c> if the specified date is in the future; otherwise, <c>false</c>.</returns>
    public static bool IsFutureDate<T>(this T input) where T : struct
    {
        return DateTime.TryParse(input.ToString(), out var date) && date > DateTime.Now;
    }

    /// <summary>
    /// Determines whether the specified date is in the past.
    /// </summary>
    /// <typeparam name="T">The type of the input date.</typeparam>
    /// <param name="input">The input date.</param>
    /// <returns><c>true</c> if the specified date is in the past; otherwise, <c>false</c>.</returns>
    public static bool IsPastDate<T>(this T input) where T : struct
    {
        return DateTime.TryParse(input.ToString(), out var date) && date < DateTime.Now;
    }

    /// <summary>
    /// Determines whether two dates represent the same day.
    /// </summary>
    /// <typeparam name="T">The type of the input dates.</typeparam>
    /// <param name="date1">The first date.</param>
    /// <param name="date2">The second date.</param>
    /// <returns><c>true</c> if the two dates represent the same day; otherwise, <c>false</c>.</returns>
    public static bool IsSameDay<T>(this T date1, T date2) where T : struct
    {
        return DateTime.TryParse(date1.ToString(), out var dt1) &&
               DateTime.TryParse(date2.ToString(), out var dt2) && dt1.Date == dt2.Date;
    }

    /// <summary>
    /// Determines whether the specified date is on a weekend (Saturday or Sunday).
    /// </summary>
    /// <typeparam name="T">The type of the input date.</typeparam>
    /// <param name="input">The input date.</param>
    /// <returns><c>true</c> if the specified date is on a weekend; otherwise, <c>false</c>.</returns>
    public static bool IsWeekend<T>(this T input) where T : struct
    {
        return DateTime.TryParse(input.ToString(), out var date) &&
               date.DayOfWeek is DayOfWeek.Saturday or DayOfWeek.Sunday;
    }

    /// <summary>
    /// Determines whether the specified date is on a weekday (Monday to Friday).
    /// </summary>
    /// <typeparam name="T">The type of the input date.</typeparam>
    /// <param name="input">The input date.</param>
    /// <returns><c>true</c> if the specified date is on a weekday; otherwise, <c>false</c>.</returns>
    public static bool IsWeekday<T>(this T input) where T : struct
    {
        return DateTime.TryParse(input.ToString(), out var date) && date.DayOfWeek != DayOfWeek.Saturday &&
               date.DayOfWeek != DayOfWeek.Sunday;
    }

    /// <summary>
    /// Determines whether the specified year is a leap year.
    /// </summary>
    /// <typeparam name="T">The type of the input year.</typeparam>
    /// <param name="input">The input year.</param>
    /// <returns><c>true</c> if the specified year is a leap year; otherwise, <c>false</c>.</returns>
    public static bool IsLeapYear<T>(this T input) where T : struct
    {
        return DateTime.TryParse(input.ToString(), out var date) && DateTime.IsLeapYear(date.Year);
    }

    /// <summary>
    /// Determines whether the specified date is today.
    /// </summary>
    /// <typeparam name="T">The type of the input date.</typeparam>
    /// <param name="input">The input date.</param>
    /// <returns><c>true</c> if the specified date is today; otherwise, <c>false</c>.</returns>
    public static bool IsToday<T>(this T input) where T : struct
    {
        return DateTime.TryParse(input.ToString(), out var date) && date.Date == DateTime.Today;
    }

    /// <summary>
    /// Determines whether the specified date is tomorrow.
    /// </summary>
    /// <typeparam name="T">The type of the input date.</typeparam>
    /// <param name="input">The input date.</param>
    /// <returns><c>true</c> if the specified date is tomorrow; otherwise, <c>false</c>.</returns>
    public static bool IsTomorrow<T>(this T input) where T : struct
    {
        return DateTime.TryParse(input.ToString(), out var date) && date.Date == DateTime.Today.AddDays(1);
    }

    /// <summary>
    /// Determines whether the specified date is yesterday.
    /// </summary>
    /// <typeparam name="T">The type of the input date.</typeparam>
    /// <param name="input">The input date.</param>
    /// <returns><c>true</c> if the specified date is yesterday; otherwise, <c>false</c>.</returns>
    public static bool IsYesterday<T>(this T input) where T : struct
    {
        return DateTime.TryParse(input.ToString(), out var date) && date.Date == DateTime.Today.AddDays(-1);
    }

    /// <summary>
    /// Determines whether the specified date is the last day of the month.
    /// </summary>
    /// <typeparam name="T">The type of the input date.</typeparam>
    /// <param name="input">The input date.</param>
    /// <returns><c>true</c> if the specified date is the last day of the month; otherwise, <c>false</c>.</returns>
    public static bool IsLastDayOfMonth<T>(this T input) where T : struct
    {
        return DateTime.TryParse(input.ToString(), out var date) &&
               date.Day == DateTime.DaysInMonth(date.Year, date.Month);
    }

    /// <summary>
    /// Determines whether the specified date is the first day of the month.
    /// </summary>
    /// <typeparam name="T">The type of the input date.</typeparam>
    /// <param name="input">The input date.</param>
    /// <returns><c>true</c> if the specified date is the first day of the month; otherwise, <c>false</c>.</returns>
    public static bool IsFirstDayOfMonth<T>(this T input) where T : struct
    {
        return DateTime.TryParse(input.ToString(), out var date) && date.Day == 1;
    }

    /// <summary>
    /// Determines whether the specified date is in the specified quarter of the year.
    /// </summary>
    /// <typeparam name="T">The type of the input date.</typeparam>
    /// <param name="input">The input date.</param>
    /// <param name="quarter">The quarter of the year (1 to 4).</param>
    /// <returns><c>true</c> if the specified date is in the specified quarter; otherwise, <c>false</c>.</returns>
    public static bool IsQuarter<T>(this T input, int quarter) where T : struct
    {
        return DateTime.TryParse(input.ToString(), out var date) &&
               (date.Month - 1) / 3 == quarter - 1;
    }

    /// <summary>
    /// Determines whether the specified date is in the same month and year as another date.
    /// </summary>
    /// <typeparam name="T">The type of the input dates.</typeparam>
    /// <param name="input">The input date.</param>
    /// <param name="otherDate">The other date to compare.</param>
    /// <returns><c>true</c> if the specified date is in the same month and year as the other date; otherwise, <c>false</c>.</returns>
    public static bool IsSameMonth<T>(this T input, T otherDate) where T : struct
    {
        return DateTime.TryParse(input.ToString(), out var date) &&
               DateTime.TryParse(otherDate.ToString(), out var other) &&
               date.Month == other.Month && date.Year == other.Year;
    }

    /// <summary>
    /// Determines whether the specified date is in the same year as another date.
    /// </summary>
    /// <typeparam name="T">The type of the input dates.</typeparam>
    /// <param name="input">The input date.</param>
    /// <param name="otherDate">The other date to compare.</param>
    /// <returns><c>true</c> if the specified date is in the same year as the other date; otherwise, <c>false</c>.</returns>
    public static bool IsSameYear<T>(this T input, T otherDate) where T : struct
    {
        return DateTime.TryParse(input.ToString(), out var date) &&
               DateTime.TryParse(otherDate.ToString(), out var other) && date.Year == other.Year;
    }

    /// <summary>
    /// Determines whether the specified date has the same hour and minute as another date.
    /// </summary>
    /// <typeparam name="T">The type of the input dates.</typeparam>
    /// <param name="input">The input date.</param>
    /// <param name="otherDate">The other date to compare.</param>
    /// <returns><c>true</c> if the specified date has the same hour and minute as the other date; otherwise, <c>false</c>.</returns>
    public static bool IsSameHour<T>(this T input, T otherDate) where T : struct
    {
        return DateTime.TryParse(input.ToString(), out var date) &&
               DateTime.TryParse(otherDate.ToString(), out var other) &&
               date.Hour == other.Hour && date.Minute == other.Minute;
    }

    /// <summary>
    /// Determines whether the specified date has the same minute as another date.
    /// </summary>
    /// <typeparam name="T">The type of the input dates.</typeparam>
    /// <param name="input">The input date.</param>
    /// <param name="otherDate">The other date to compare.</param>
    /// <returns><c>true</c> if the specified date has the same minute as the other date; otherwise, <c>false</c>.</returns>
    public static bool IsSameMinute<T>(this T input, T otherDate) where T : struct
    {
        return DateTime.TryParse(input.ToString(), out var date) &&
               DateTime.TryParse(otherDate.ToString(), out var other) &&
               date.Minute == other.Minute;
    }

    /// <summary>
    /// Determines whether the specified date has the same second as another date.
    /// </summary>
    /// <typeparam name="T">The type of the input dates.</typeparam>
    /// <param name="input">The input date.</param>
    /// <param name="otherDate">The other date to compare.</param>
    /// <returns><c>true</c> if the specified date has the same second as the other date; otherwise, <c>false</c>.</returns>
    public static bool IsSameSecond<T>(this T input, T otherDate) where T : struct
    {
        return DateTime.TryParse(input.ToString(), out var date) &&
               DateTime.TryParse(otherDate.ToString(), out var other) &&
               date.Second == other.Second;
    }

    /// <summary>
    /// Determines whether the specified date has the same millisecond as another date.
    /// </summary>
    /// <typeparam name="T">The type of the input dates.</typeparam>
    /// <param name="input">The input date.</param>
    /// <param name="otherDate">The other date to compare.</param>
    /// <returns><c>true</c> if the specified date has the same millisecond as the other date; otherwise, <c>false</c>.</returns>
    public static bool IsSameMillisecond<T>(this T input, T otherDate) where T : struct
    {
        return DateTime.TryParse(input.ToString(), out var date) &&
               DateTime.TryParse(otherDate.ToString(), out var other) &&
               date.Millisecond == other.Millisecond;
    }
}