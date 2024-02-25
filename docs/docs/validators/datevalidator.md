# DateValidator Class

**A utility class for validating dates.**

## Class Members

```csharp
IsDate<T>(T input)
```

Checks if the input value is a valid date.

### Type Parameters

- `T`: The type of the input value.

### Returns

- Type: `bool`
- Description: Returns `true` if the input value can be converted to a `DateTime`, `false` otherwise.

### Example

```csharp
var isValidDate = DateValidator.IsDate<string>("2022-01-01");
Console.WriteLine(isValidDate); // Outputs: True
```

### Remarks

The `IsDate` method tries to convert the input value to a `DateTime`. If the conversion is successful, it returns `true`; otherwise, it returns `false`.

---

**Note:** The `DateValidator` class also contains several other methods for validating dates, such as `IsFutureDate`, `IsPastDate`, `IsSameDay`, `IsWeekend`, `IsWeekday`, `IsLeapYear`, and more. Each method receives a generic input value `T` (where `T` is a struct), tries to convert it to a `DateTime`, and performs a specific check. For checking that, see API Reference.
