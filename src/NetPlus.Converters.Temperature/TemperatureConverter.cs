using System.Globalization;

namespace NetPlus.Converters.Temperature;

/// <summary>
/// Provides methods for converting temperatures between Celsius, Fahrenheit, and Kelvin.
/// </summary>
public static class TemperatureConverter
{
    /// <summary>
    /// Converts temperature from Celsius to Fahrenheit.
    /// </summary>
    /// <typeparam name="T">The type of temperature value.</typeparam>
    /// <param name="temperature">The temperature value to convert.</param>
    /// <returns>The converted temperature value in Fahrenheit.</returns>
    public static double ConvertCelsiusToFahrenheit<T>(this T temperature)
    {
        if (temperature is IConvertible convertible)
        {
            var celsius = convertible.ToDouble(CultureInfo.CurrentCulture);
            return celsius * 9 / 5 + 32;
        }

        throw new ArgumentException($"Type {typeof(T)} does not implement IConvertible");
    }

    /// <summary>
    /// Converts temperature from Fahrenheit to Celsius.
    /// </summary>
    /// <typeparam name="T">The type of temperature value.</typeparam>
    /// <param name="temperature">The temperature value to convert.</param>
    /// <returns>The converted temperature value in Celsius.</returns>
    public static double ConvertFahrenheitToCelsius<T>(this T temperature)
    {
        if (temperature is IConvertible convertible)
        {
            var fahrenheit = convertible.ToDouble(CultureInfo.CurrentCulture);
            return (fahrenheit - 32) * 5 / 9;
        }

        throw new ArgumentException($"Type {typeof(T)} does not implement IConvertible");
    }

    /// <summary>
    /// Converts temperature from Kelvin to Celsius.
    /// </summary>
    /// <typeparam name="T">The type of temperature value.</typeparam>
    /// <param name="temperature">The temperature value to convert.</param>
    /// <returns>The converted temperature value in Celsius.</returns>
    public static double ConvertKelvinToCelsius<T>(this T temperature)
    {
        if (temperature is IConvertible convertible)
        {
            var kelvin = convertible.ToDouble(CultureInfo.CurrentCulture);
            return kelvin - 273.15;
        }

        throw new ArgumentException($"Type {typeof(T)} does not implement IConvertible");
    }

    /// <summary>
    /// Converts temperature from Celsius to Kelvin.
    /// </summary>
    /// <typeparam name="T">The type of temperature value.</typeparam>
    /// <param name="temperature">The temperature value to convert.</param>
    /// <returns>The converted temperature value in Kelvin.</returns>
    public static double ConvertCelsiusToKelvin<T>(this T temperature)
    {
        if (temperature is IConvertible convertible)
        {
            var celsius = convertible.ToDouble(CultureInfo.CurrentCulture);
            return celsius + 273.15;
        }

        throw new ArgumentException($"Type {typeof(T)} does not implement IConvertible");
    }

    /// <summary>
    /// Converts temperature from Fahrenheit to Kelvin.
    /// </summary>
    /// <typeparam name="T">The type of temperature value.</typeparam>
    /// <param name="temperature">The temperature value to convert.</param>
    /// <returns>The converted temperature value in Kelvin.</returns>
    public static double ConvertFahrenheitToKelvin<T>(this T temperature)
    {
        if (temperature is IConvertible convertible)
        {
            var fahrenheit = convertible.ToDouble(CultureInfo.CurrentCulture);
            return (fahrenheit - 32) * 5 / 9 + 273.15;
        }

        throw new ArgumentException($"Type {typeof(T)} does not implement IConvertible");
    }

    /// <summary>
    /// Converts temperature from Kelvin to Fahrenheit.
    /// </summary>
    /// <typeparam name="T">The type of temperature value.</typeparam>
    /// <param name="temperature">The temperature value to convert.</param>
    /// <returns>The converted temperature value in Fahrenheit.</returns>
    public static double ConvertKelvinToFahrenheit<T>(this T temperature)
    {
        if (temperature is IConvertible convertible)
        {
            var kelvin = convertible.ToDouble(CultureInfo.CurrentCulture);
            return (kelvin - 273.15) * 9 / 5 + 32;
        }

        throw new ArgumentException($"Type {typeof(T)} does not implement IConvertible");
    }

    /// <summary>
    /// Converts temperature from Celsius to Fahrenheit with a specified culture.
    /// </summary>
    /// <typeparam name="T">The type of temperature value.</typeparam>
    /// <param name="temperature">The temperature value to convert.</param>
    /// <param name="cultureInfo">The culture-specific information for formatting.</param>
    /// <returns>The converted temperature value in Fahrenheit.</returns>
    public static double ConvertCelsiusToFahrenheit<T>(this T temperature, CultureInfo cultureInfo)
    {
        if (temperature is IConvertible convertible)
        {
            var celsius = convertible.ToDouble(cultureInfo);
            return celsius * 9 / 5 + 32;
        }

        throw new ArgumentException($"Type {typeof(T)} does not implement IConvertible");
    }

    /// <summary>
    /// Converts temperature from Fahrenheit to Celsius with a specified culture.
    /// </summary>
    /// <typeparam name="T">The type of temperature value.</typeparam>
    /// <param name="temperature">The temperature value to convert.</param>
    /// <param name="cultureInfo">The culture-specific information for formatting.</param>
    /// <returns>The converted temperature value in Celsius.</returns>
    public static double ConvertFahrenheitToCelsius<T>(this T temperature, CultureInfo cultureInfo)
    {
        if (temperature is IConvertible convertible)
        {
            var fahrenheit = convertible.ToDouble(cultureInfo);
            return (fahrenheit - 32) * 5 / 9;
        }

        throw new ArgumentException($"Type {typeof(T)} does not implement IConvertible");
    }

    /// <summary>
    /// Converts temperature from Kelvin to Celsius with a specified culture.
    /// </summary>
    /// <typeparam name="T">The type of temperature value.</typeparam>
    /// <param name="temperature">The temperature value to convert.</param>
    /// <param name="cultureInfo">The culture-specific information for formatting.</param>
    /// <returns>The converted temperature value in Celsius.</returns>
    public static double ConvertKelvinToCelsius<T>(this T temperature, CultureInfo cultureInfo)
    {
        if (temperature is IConvertible convertible)
        {
            var kelvin = convertible.ToDouble(cultureInfo);
            return kelvin - 273.15;
        }

        throw new ArgumentException($"Type {typeof(T)} does not implement IConvertible");
    }

    /// <summary>
    /// Converts temperature from Celsius to Kelvin with a specified culture.
    /// </summary>
    /// <typeparam name="T">The type of temperature value.</typeparam>
    /// <param name="temperature">The temperature value to convert.</param>
    /// <param name="cultureInfo">The culture-specific information for formatting.</param>
    /// <returns>The converted temperature value in Kelvin.</returns>
    public static double ConvertCelsiusToKelvin<T>(this T temperature, CultureInfo cultureInfo)
    {
        if (temperature is IConvertible convertible)
        {
            var celsius = convertible.ToDouble(cultureInfo);
            return celsius + 273.15;
        }

        throw new ArgumentException($"Type {typeof(T)} does not implement IConvertible");
    }

    /// <summary>
    /// Converts temperature from Fahrenheit to Kelvin with a specified culture.
    /// </summary>
    /// <typeparam name="T">The type of temperature value.</typeparam>
    /// <param name="temperature">The temperature value to convert.</param>
    /// <param name="cultureInfo">The culture-specific information for formatting.</param>
    /// <returns>The converted temperature value in Kelvin.</returns>
    public static double ConvertFahrenheitToKelvin<T>(this T temperature, CultureInfo cultureInfo)
    {
        if (temperature is IConvertible convertible)
        {
            var fahrenheit = convertible.ToDouble(cultureInfo);
            return (fahrenheit - 32) * 5 / 9 + 273.15;
        }

        throw new ArgumentException($"Type {typeof(T)} does not implement IConvertible");
    }

    /// <summary>
    /// Converts temperature from Kelvin to Fahrenheit with a specified culture.
    /// </summary>
    /// <typeparam name="T">The type of temperature value.</typeparam>
    /// <param name="temperature">The temperature value to convert.</param>
    /// <param name="cultureInfo">The culture-specific information for formatting.</param>
    /// <returns>The converted temperature value in Fahrenheit.</returns>
    public static double ConvertKelvinToFahrenheit<T>(this T temperature, CultureInfo cultureInfo)
    {
        if (temperature is IConvertible convertible)
        {
            var kelvin = convertible.ToDouble(cultureInfo);
            return (kelvin - 273.15) * 9 / 5 + 32;
        }

        throw new ArgumentException($"Type {typeof(T)} does not implement IConvertible");
    }

    /// <summary>
    /// Converts temperature from Celsius to Fahrenheit with a specified format provider.
    /// </summary>
    /// <typeparam name="T">The type of temperature value.</typeparam>
    /// <param name="temperature">The temperature value to convert.</param>
    /// <param name="formatProvider">An object that supplies format information.</param>
    /// <returns>The converted temperature value in Fahrenheit.</returns>
    public static double ConvertCelsiusToFahrenheit<T>(this T temperature, IFormatProvider formatProvider)
    {
        if (temperature is IConvertible convertible)
        {
            var celsius = convertible.ToDouble(formatProvider);
            return celsius * 9 / 5 + 32;
        }

        throw new ArgumentException($"Type {typeof(T)} does not implement IConvertible");
    }

    /// <summary>
    /// Converts temperature from Fahrenheit to Celsius with a specified format provider.
    /// </summary>
    /// <typeparam name="T">The type of temperature value.</typeparam>
    /// <param name="temperature">The temperature value to convert.</param>
    /// <param name="formatProvider">An object that supplies format information.</param>
    /// <returns>The converted temperature value in Celsius.</returns>
    public static double ConvertFahrenheitToCelsius<T>(this T temperature, IFormatProvider formatProvider)
    {
        if (temperature is IConvertible convertible)
        {
            var fahrenheit = convertible.ToDouble(formatProvider);
            return (fahrenheit - 32) * 5 / 9;
        }

        throw new ArgumentException($"Type {typeof(T)} does not implement IConvertible");
    }

    /// <summary>
    /// Converts temperature from Kelvin to Celsius with a specified format provider.
    /// </summary>
    /// <typeparam name="T">The type of temperature value.</typeparam>
    /// <param name="temperature">The temperature value to convert.</param>
    /// <param name="formatProvider">An object that supplies format information.</param>
    /// <returns>The converted temperature value in Celsius.</returns>
    public static double ConvertKelvinToCelsius<T>(this T temperature, IFormatProvider formatProvider)
    {
        if (temperature is IConvertible convertible)
        {
            var kelvin = convertible.ToDouble(formatProvider);
            return kelvin - 273.15;
        }

        throw new ArgumentException($"Type {typeof(T)} does not implement IConvertible");
    }

    /// <summary>
    /// Converts temperature from Celsius to Kelvin with a specified format provider.
    /// </summary>
    /// <typeparam name="T">The type of temperature value.</typeparam>
    /// <param name="temperature">The temperature value to convert.</param>
    /// <param name="formatProvider">An object that supplies format information.</param>
    /// <returns>The converted temperature value in Kelvin.</returns>
    public static double ConvertCelsiusToKelvin<T>(this T temperature, IFormatProvider formatProvider)
    {
        if (temperature is IConvertible convertible)
        {
            var celsius = convertible.ToDouble(formatProvider);
            return celsius + 273.15;
        }

        throw new ArgumentException($"Type {typeof(T)} does not implement IConvertible");
    }

    /// <summary>
    /// Converts temperature from Fahrenheit to Kelvin with a specified format provider.
    /// </summary>
    /// <typeparam name="T">The type of temperature value.</typeparam>
    /// <param name="temperature">The temperature value to convert.</param>
    /// <param name="formatProvider">An object that supplies format information.</param>
    /// <returns>The converted temperature value in Kelvin.</returns>
    public static double ConvertFahrenheitToKelvin<T>(this T temperature, IFormatProvider formatProvider)
    {
        if (temperature is IConvertible convertible)
        {
            var fahrenheit = convertible.ToDouble(formatProvider);
            return (fahrenheit - 32) * 5 / 9 + 273.15;
        }

        throw new ArgumentException($"Type {typeof(T)} does not implement IConvertible");
    }

    /// <summary>
    /// Converts temperature from Kelvin to Fahrenheit with a specified format provider.
    /// </summary>
    /// <typeparam name="T">The type of temperature value.</typeparam>
    /// <param name="temperature">The temperature value to convert.</param>
    /// <param name="formatProvider">An object that supplies format information.</param>
    /// <returns>The converted temperature value in Fahrenheit.</returns>
    public static double ConvertKelvinToFahrenheit<T>(this T temperature, IFormatProvider formatProvider)
    {
        if (temperature is IConvertible convertible)
        {
            var kelvin = convertible.ToDouble(formatProvider);
            return (kelvin - 273.15) * 9 / 5 + 32;
        }

        throw new ArgumentException($"Type {typeof(T)} does not implement IConvertible");
    }
}