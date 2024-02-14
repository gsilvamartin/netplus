using System.Text.RegularExpressions;

namespace NetDevExtensions.String.Validation;

public static class StringExtensions
{
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

    public static bool IsValidDate(this string input)
    {
        return !string.IsNullOrWhiteSpace(input) && DateTime.TryParse(input, out _);
    }

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
}