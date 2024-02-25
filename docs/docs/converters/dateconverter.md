# DateTimeConverter Class

**A static class providing extension methods for converting DateTime to string and vice versa.**

## Class Members

```csharp
ConvertDateTimeToString(this DateTime input)
```

Converts a DateTime object to a string using the current culture's formatting.

### Parameters

- `input` (Type: `DateTime`): The DateTime object to convert.

### Returns

- Type: `string`
- Description: A string representation of the DateTime.

### Example

```csharp
DateTime now = DateTime.Now;
string nowAsString = now.ConvertDateTimeToString();
Console.WriteLine(nowAsString);
```

### Remarks

The `ConvertDateTimeToString` method converts a DateTime object to a string using the current culture's formatting.

---

```csharp
ConvertStringToDateTime(this string input)
```

Converts a string to a DateTime object using the current culture's formatting.

### Parameters

- `input` (Type: `string`): The string to convert.

### Returns

- Type: `DateTime`
- Description: A DateTime representation of string.

### Example

```csharp
string dateAsString = "12/31/2020";
DateTime date = dateAsString.ConvertStringToDateTime();
Console.WriteLine(date);
```

### Remarks

The `ConvertStringToDateTime` method converts a string to a DateTime object using the current culture's formatting.

---

Note: There are multiple overloads for both `ConvertDateTimeToString` and `ConvertStringToDateTime` methods that allow you to specify a format, a CultureInfo, a DateTimeStyles, and/or an IFormatProvider. Please refer to the source code for more details.
