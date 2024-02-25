# StringValidator Class

**A static class containing string validation methods.**

## Class Members

```csharp
IsDate(this string input)
```

Determines whether the specified string is a valid date.

### Parameters

- `input`: The input string.

### Returns

- Type: `bool`
- Description: `true` if the specified string is a valid date; otherwise, `false`.

### Example

```csharp
string dateString = "2022-01-01";
bool isValidDate = dateString.IsDate(); // Returns true
```

---

```csharp
IsDateTime(this string input)
```

Determines whether the specified string is a valid date and time.

### Parameters

- `input`: The input string.

### Returns

- Type: `bool`
- Description: `true` if the specified string is a valid date and time; otherwise, `false`.

### Example

```csharp
string dateTimeString = "2022-01-01 12:00:00";
bool isValidDateTime = dateTimeString.IsDateTime(); // Returns true
```

---

```csharp
IsUnicode(this string input)
```

Determines whether the specified string contains Unicode characters.

### Parameters

- `input`: The input string.

### Returns

- Type: `bool`
- Description: `true` if the specified string contains Unicode characters; otherwise, `false`.

### Example

```csharp
string unicodeString = "こんにちは";
bool isUnicode = unicodeString.IsUnicode(); // Returns true
```

### Remarks

The `StringValidator` class also contains several other methods for string validation, such as `IsEmail`, `IsUrl`, `IsPhoneNumber`, and `IsPostalCode`. These methods provide additional ways to validate string values. For more information and examples of how to use these methods, please refer to the API reference documentation.
