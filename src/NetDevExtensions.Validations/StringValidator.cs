using System.Text.RegularExpressions;

namespace NetDevExtensions.Validators;

/// <summary>
/// Static class containing string validation methods.
/// </summary>
public static class StringValidator
{
    /// <summary>
    /// Determines whether the specified string is a valid date.
    /// </summary>
    /// <param name="input">The input string.</param>
    /// <returns><c>true</c> if the specified string is a valid date; otherwise, <c>false</c>.</returns>
    public static bool IsDate(this string input)
    {
        return !string.IsNullOrWhiteSpace(input) && DateTime.TryParse(input, out _);
    }

    /// <summary>
    /// Determines whether the specified string is a valid date and time.
    /// </summary>
    /// <param name="input">The input string.</param>
    /// <returns><c>true</c> if the specified string is a valid date and time; otherwise, <c>false</c>.</returns>
    public static bool IsDateTime(this string input)
    {
        return !string.IsNullOrWhiteSpace(input) && DateTime.TryParse(input, out _);
    }

    /// <summary>
    /// Determines whether the specified string contains Unicode characters.
    /// </summary>
    /// <param name="input">The input string.</param>
    /// <returns><c>true</c> if the specified string contains Unicode characters; otherwise, <c>false</c>.</returns>
    public static bool IsUnicode(this string input)
    {
        return !string.IsNullOrWhiteSpace(input) && input.Any(c => c > 127);
    }

    /// <summary>
    /// Determines whether the specified string is a valid file extension.
    /// </summary>
    /// <param name="input">The input string.</param>
    /// <returns><c>true</c> if the specified string is a valid file extension; otherwise, <c>false</c>.</returns>
    public static bool IsFileExtension(this string input)
    {
        if (string.IsNullOrWhiteSpace(input))
            return false;

        try
        {
            var fileExtensionRegex = new Regex(@"^\.[a-zA-Z0-9]+$");
            return fileExtensionRegex.IsMatch(input);
        }
        catch (RegexMatchTimeoutException)
        {
            return false;
        }
    }

    /// <summary>
    /// Determines whether the specified string is alphanumeric.
    /// </summary>
    /// <param name="input">The input string.</param>
    /// <returns><c>true</c> if the specified string is alphanumeric; otherwise, <c>false</c>.</returns>
    public static bool IsAlphaNumeric(this string input)
    {
        if (string.IsNullOrWhiteSpace(input))
            return false;

        try
        {
            var alphaNumericRegex = new Regex(@"^[a-zA-Z0-9]+$");
            return alphaNumericRegex.IsMatch(input);
        }
        catch (RegexMatchTimeoutException)
        {
            return false;
        }
    }

    /// <summary>
    /// Determines whether the specified string is alphabetic.
    /// </summary>
    /// <param name="input">The input string.</param>
    /// <returns><c>true</c> if the specified string is alphabetic; otherwise, <c>false</c>.</returns>
    public static bool IsAlphabetic(this string input)
    {
        if (string.IsNullOrWhiteSpace(input))
            return false;

        try
        {
            var alphabeticRegex = new Regex(@"^[a-zA-Z]+$");
            return alphabeticRegex.IsMatch(input);
        }
        catch (RegexMatchTimeoutException)
        {
            return false;
        }
    }

    /// <summary>
    /// Determines whether the specified string is numeric.
    /// </summary>
    /// <param name="input">The input string.</param>
    /// <returns><c>true</c> if the specified string is numeric; otherwise, <c>false</c>.</returns>
    public static bool IsNumeric(this string input)
    {
        if (string.IsNullOrWhiteSpace(input))
            return false;

        try
        {
            var numericRegex = new Regex(@"^[0-9]+$");
            return numericRegex.IsMatch(input);
        }
        catch (RegexMatchTimeoutException)
        {
            return false;
        }
    }

    /// <summary>
    /// Determines whether the specified string is a hexadecimal number.
    /// </summary>
    /// <param name="input">The input string.</param>
    /// <returns><c>true</c> if the specified string is a hexadecimal number; otherwise, <c>false</c>.</returns>
    public static bool IsHexadecimal(this string input)
    {
        if (string.IsNullOrWhiteSpace(input))
            return false;

        try
        {
            var hexadecimalRegex = new Regex(@"^(0x)?[0-9a-fA-F]+$");
            return hexadecimalRegex.IsMatch(input);
        }
        catch (RegexMatchTimeoutException)
        {
            return false;
        }
    }

    /// <summary>
    /// Determines whether the specified string is a valid email address.
    /// </summary>
    /// <param name="input">The input string.</param>
    /// <returns><c>true</c> if the specified string is a valid email address; otherwise, <c>false</c>.</returns>
    public static bool IsValidEmail(this string input)
    {
        if (string.IsNullOrWhiteSpace(input))
            return false;

        try
        {
            var emailRegex = new Regex(@"^[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,6}$");
            return emailRegex.IsMatch(input);
        }
        catch (RegexMatchTimeoutException)
        {
            return false;
        }
    }

    /// <summary>
    /// Determines whether the specified string is a valid URL.
    /// </summary>
    /// <param name="input">The input string.</param>
    /// <returns><c>true</c> if the specified string is a valid URL; otherwise, <c>false</c>.</returns>
    public static bool IsValidUrl(this string input)
    {
        if (string.IsNullOrWhiteSpace(input))
            return false;

        try
        {
            var urlRegex = new Regex(@"^(http|https)://[a-zA-Z0-9.-]+\.[a-zA-Z]{2,6}(/\S*)?$");
            return urlRegex.IsMatch(input);
        }
        catch (RegexMatchTimeoutException)
        {
            return false;
        }
    }

    /// <summary>
    /// Determines whether the specified string is a valid phone number.
    /// </summary>
    /// <param name="input">The input string.</param>
    /// <returns><c>true</c> if the specified string is a valid phone number; otherwise, <c>false</c>.</returns>
    public static bool IsValidPhoneNumber(this string input)
    {
        if (string.IsNullOrWhiteSpace(input))
            return false;

        try
        {
            var phoneNumberRegex = new Regex(@"^\+?(\d[\d-. ]+)?(\([\d-. ]+\))?[\d-. ]+\d$");
            return phoneNumberRegex.IsMatch(input);
        }
        catch (RegexMatchTimeoutException)
        {
            return false;
        }
    }

    /// <summary>
    /// Determines whether the specified string is a valid US ZIP code.
    /// </summary>
    /// <param name="input">The input string.</param>
    /// <returns><c>true</c> if the specified string is a valid US ZIP code; otherwise, <c>false</c>.</returns>
    public static bool IsValidUsZipCode(this string input)
    {
        if (string.IsNullOrWhiteSpace(input))
            return false;

        try
        {
            var zipCodeRegex = new Regex(@"^\d{5}(?:[-\s]\d{4})?$");
            return zipCodeRegex.IsMatch(input);
        }
        catch (RegexMatchTimeoutException)
        {
            return false;
        }
    }

    /// <summary>
    /// Determines whether the specified string is a valid IP address.
    /// </summary>
    /// <param name="input">The input string.</param>
    /// <returns><c>true</c> if the specified string is a valid IP address; otherwise, <c>false</c>.</returns>
    public static bool IsValidIpAddress(this string input)
    {
        if (string.IsNullOrWhiteSpace(input))
            return false;

        try
        {
            var ipAddressRegex = new Regex(@"\b\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}\b");
            return ipAddressRegex.IsMatch(input);
        }
        catch (RegexMatchTimeoutException)
        {
            return false;
        }
    }

    /// <summary>
    /// Determines whether the specified string is a valid IPv6 address.
    /// </summary>
    /// <param name="input">The input string.</param>
    /// <returns><c>true</c> if the specified string is a valid IPv6 address; otherwise, <c>false</c>.</returns>
    public static bool ValidateIpv6Address(this string input)
    {
        if (string.IsNullOrWhiteSpace(input))
            return false;

        try
        {
            var ipv6Regex = new Regex(@"^(?:[0-9a-fA-F]{1,4}:){7}[0-9a-fA-F]{1,4}$");
            return ipv6Regex.IsMatch(input);
        }
        catch (RegexMatchTimeoutException)
        {
            return false;
        }
    }

    /// <summary>
    /// Determines whether the specified string is a valid GUID.
    /// </summary>
    /// <param name="input">The input string.</param>
    /// <returns><c>true</c> if the specified string is a valid GUID; otherwise, <c>false</c>.</returns>
    public static bool IsValidGuid(this string input)
    {
        if (string.IsNullOrWhiteSpace(input))
            return false;

        try
        {
            var guidRegex =
                new Regex(@"\b[A-Fa-f0-9]{8}-[A-Fa-f0-9]{4}-[A-Fa-f0-9]{4}-[A-Fa-f0-9]{4}-[A-Fa-f0-9]{12}\b");
            return guidRegex.IsMatch(input);
        }
        catch (RegexMatchTimeoutException)
        {
            return false;
        }
    }

    /// <summary>
    /// Determines whether the specified string is a valid base64-encoded string.
    /// </summary>
    /// <param name="input">The input string.</param>
    /// <returns><c>true</c> if the specified string is a valid base64-encoded string; otherwise, <c>false</c>.</returns>
    public static bool IsValidBase64(this string input)
    {
        if (string.IsNullOrWhiteSpace(input))
            return false;

        try
        {
            var base64Regex = new Regex(@"^data:(?<mime>[\w/\-\.]+);base64,(?<data>[a-zA-Z0-9\+/]+={0,2})$");
            return base64Regex.IsMatch(input);
        }
        catch (RegexMatchTimeoutException)
        {
            return false;
        }
    }

    /// <summary>
    /// Determines whether the specified string is a valid JSON string.
    /// </summary>
    /// <param name="input">The input string.</param>
    /// <returns><c>true</c> if the specified string is a valid JSON string; otherwise, <c>false</c>.</returns>
    public static bool IsValidJson(this string input)
    {
        if (string.IsNullOrWhiteSpace(input))
            return false;

        try
        {
            var jsonRegex = new Regex(@"^[\],:{}\s]*$");
            return jsonRegex.IsMatch(input);
        }
        catch (RegexMatchTimeoutException)
        {
            return false;
        }
    }

    /// <summary>
    /// Determines whether the specified string is a valid date.
    /// </summary>
    /// <param name="input">The input string.</param>
    /// <returns><c>true</c> if the specified string is a valid date; otherwise, <c>false</c>.</returns>
    public static bool IsValidDate(this string input)
    {
        return !string.IsNullOrWhiteSpace(input) && DateTime.TryParse(input, out _);
    }

    /// <summary>
    /// Determines whether the specified string is a valid DNS name.
    /// </summary>
    /// <param name="input">The input string.</param>
    /// <returns><c>true</c> if the specified string is a valid DNS name; otherwise, <c>false</c>.</returns>
    public static bool IsValidDns(this string input)
    {
        if (string.IsNullOrWhiteSpace(input))
            return false;

        try
        {
            var dnsNameRegex = new Regex(@"^([a-zA-Z0-9]+(-[a-zA-Z0-9]+)*\.)+[a-zA-Z]{2,}$");
            return dnsNameRegex.IsMatch(input);
        }
        catch (RegexMatchTimeoutException)
        {
            return false;
        }
    }

    /// <summary>
    /// Determines whether the specified string contains uppercase letters only.
    /// </summary>
    /// <param name="input">The input string.</param>
    /// <returns><c>true</c> if the specified string contains uppercase letters only; otherwise, <c>false</c>.</returns>
    public static bool IsUpperCase(this string input)
    {
        if (string.IsNullOrWhiteSpace(input))
            return false;

        try
        {
            var upperCaseRegex = new Regex(@"^[A-Z]+$");
            return upperCaseRegex.IsMatch(input);
        }
        catch (RegexMatchTimeoutException)
        {
            return false;
        }
    }

    /// <summary>
    /// Determines whether the specified string contains lowercase letters only.
    /// </summary>
    /// <param name="input">The input string.</param>
    /// <returns><c>true</c> if the specified string contains lowercase letters only; otherwise, <c>false</c>.</returns>
    public static bool IsLowerCase(this string input)
    {
        if (string.IsNullOrWhiteSpace(input))
            return false;

        try
        {
            var lowerCaseRegex = new Regex(@"^[a-z]+$");
            return lowerCaseRegex.IsMatch(input);
        }
        catch (RegexMatchTimeoutException)
        {
            return false;
        }
    }

    /// <summary>
    /// Determines whether the specified string is a strong password.
    /// </summary>
    /// <param name="input">The input string.</param>
    /// <returns><c>true</c> if the specified string is a strong password; otherwise, <c>false</c>.</returns>
    public static bool IsStrongPassword(this string input)
    {
        if (string.IsNullOrWhiteSpace(input))
            return false;

        try
        {
            var strongPasswordRegex = new Regex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^a-zA-Z\d]).{8,15}$");
            return strongPasswordRegex.IsMatch(input);
        }
        catch (RegexMatchTimeoutException)
        {
            return false;
        }
    }

    /// <summary>
    /// Determines whether the specified string is a palindrome.
    /// </summary>
    /// <param name="input">The input string.</param>
    /// <returns><c>true</c> if the specified string is a palindrome; otherwise, <c>false</c>.</returns>
    public static bool IsPalindrome(this string input)
    {
        if (string.IsNullOrWhiteSpace(input))
            return false;

        var cleanString = Regex.Replace(input, "[^A-Za-z0-9]", "").ToLower();
        return cleanString.SequenceEqual(cleanString.Reverse());
    }
}