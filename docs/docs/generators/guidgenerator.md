# GuidGenerator Class

**A static class providing methods for generating GUIDs.**

## Class Members

```csharp
GenerateGuid()
```

Generates a new GUID.

### Returns

- Type: `Guid`
- Description: A new GUID.

### Example

```csharp
Guid newGuid = GuidGenerator.GenerateGuid();
Console.WriteLine(newGuid);
```

---

```csharp
GenerateGuidString()
```

Generates a new GUID as a string.

### Returns

- Type: `string`
- Description: A new GUID as a string.

### Example

```csharp
string newGuidString = GuidGenerator.GenerateGuidString();
Console.WriteLine(newGuidString);
```

---

```csharp
GenerateGuidBytes()
```

Generates a new GUID as a byte array.

### Returns

- Type: `byte[]`
- Description: A new GUID as a byte array.

### Example

```csharp
byte[] newGuidBytes = GuidGenerator.GenerateGuidBytes();
Console.WriteLine(BitConverter.ToString(newGuidBytes));
```

---

```csharp
GenerateGuidBase64()
```

Generates a new GUID as a Base64 string.

### Returns

- Type: `string`
- Description: A new GUID as a Base64 string.

### Example

```csharp
string newGuidBase64 = GuidGenerator.GenerateGuidBase64();
Console.WriteLine(newGuidBase64);
```

---

### Remarks

The `GenerateGuidBase64` method generates a new GUID, converts it to a byte array using the `Guid.ToByteArray()` method, and then converts the byte array to a Base64 string using the `Convert.ToBase64String()` method.
