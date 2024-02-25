# NumericValidator Class

**A static class containing numeric validation methods.**

## Class Members

```csharp
IsPositive<T>(this T input)
```

Determines whether the specified value is positive.

### Type Parameters

- `T`: The type of the input value.

### Returns

- Type: `bool`
- Description: `true` if the specified value is positive; otherwise, `false`.

### Example

```csharp
int positiveNumber = 5;
bool isPositive = positiveNumber.IsPositive(); // Returns true
```

---

```csharp
IsNegative<T>(this T input)
```

Determines whether the specified value is negative.

### Type Parameters

- `T`: The type of the input value.

### Returns

- Type: `bool`
- Description: `true` if the specified value is negative; otherwise, `false`.

### Example

```csharp
int negativeNumber = -3;
bool isNegative = negativeNumber.IsNegative(); // Returns true
```

---

```csharp
IsZero<T>(this T input)
```

Determines whether the specified value is zero.

### Type Parameters

- `T`: The type of the input value.

### Returns

- Type: `bool`
- Description: `true` if the specified value is zero; otherwise, `false`.

### Example

```csharp
int zeroNumber = 0;
bool isZero = zeroNumber.IsZero(); // Returns true
```

---

### Remarks

The `NumericValidator` class also contains several other methods for numeric validation, such as `IsEven`, `IsOdd`, `IsBetween`, and `IsPrime`. These methods provide additional ways to validate numeric values. For more information and examples of how to use these methods, please refer to the API reference documentation.
