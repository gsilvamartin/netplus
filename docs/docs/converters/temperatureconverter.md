# TemperatureConverter Class

**A static class providing methods for converting temperatures between Celsius, Fahrenheit, and Kelvin.**

## Class Members

```csharp
CelsiusToFahrenheit<T>(T temperature)
```

Converts a temperature from Celsius to Fahrenheit.

### Parameters

- `temperature` (Type: `T`): The temperature in Celsius to convert. `T` should implement the `IConvertible` interface.

### Returns

- Type: `double`
- Description: The converted temperature in Fahrenheit.

### Example

```csharp
double celsius = 25;
double fahrenheit = TemperatureConverter.CelsiusToFahrenheit(celsius);
Console.WriteLine(fahrenheit);
```

### Remarks

The `CelsiusToFahrenheit` method converts a temperature from Celsius to Fahrenheit.

---

```csharp
CelsiusToKelvin<T>(T temperature)
```

Converts a temperature from Celsius to Kelvin.

### Parameters

- `temperature` (Type: `T`): The temperature in Celsius to convert. `T` should implement the `IConvertible` interface.

### Returns

- Type: `double`
- Description: The converted temperature in Kelvin.

### Example

```csharp
double celsius = 25;
double kelvin = TemperatureConverter.CelsiusToKelvin(celsius);
Console.WriteLine(kelvin);
```

### Remarks

The `CelsiusToKelvin` method converts a temperature from Celsius to Kelvin.

---

**Note:** There are many more methods available in the `TemperatureConverter` class. Please refer to the reference API documentation for more details.
