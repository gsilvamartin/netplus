# PasswordGenerator Class

**A utility class for generating random passwords.**

## Class Members

```csharp
GeneratePassword(int length)
```

Generates an alphanumeric random password of the specified length.

### Parameters

- `length`: The length of the password.

### Returns

- Type: `string`
- Description: A random alphanumeric password.

### Example

```csharp
string password = PasswordGenerator.GeneratePassword(10);
Console.WriteLine(password);
```

### Remarks

The `GeneratePassword` method generates a random password of the specified length using alphanumeric characters and special characters. It throws an `ArgumentException` if the length is less than 6.

---

```csharp
GeneratePassword(int length, string allowedChars)
```

Generates a random password of the specified length using the specified allowed characters.

### Parameters

- `length`: The length of the password.
- `allowedChars`: The allowed characters for the password.

### Returns

- Type: `string`
- Description: A random password using the specified allowed characters.

### Example

```csharp
string password = PasswordGenerator.GeneratePassword(10, "abc123!@#");
Console.WriteLine(password);
```

### Remarks

The `GeneratePassword` method generates a random password of the specified length using the allowed characters provided. It throws an `ArgumentException` if the length is less than 6.

---

```csharp
GeneratePassword(int length, string allowedChars, int numberOfNonAlphanumericCharacters)
```

Generates a random password of the specified length using the specified allowed characters and a specific number of non-alphanumeric characters.

### Parameters

- `length`: The length of the password.
- `allowedChars`: The allowed characters for the password.
- `numberOfNonAlphanumericCharacters`: The number of non-alphanumeric characters in the password.

### Returns

- Type: `string`
- Description: A random password with a specified number of non-alphanumeric characters.

### Example

```csharp
string password = PasswordGenerator.GeneratePassword(10, "abc123", 2);
Console.WriteLine(password);
```

### Remarks

The `GeneratePassword` method generates a random password of the specified length using the allowed characters provided and a specific number of non-alphanumeric characters. It throws an `ArgumentException` if the length is less than 6.
