# DataGenerator Class

**A utility class for generating random data of specified types.**

## Class Members

```csharp
GenerateRandomData<T>()
```

Generates an instance of the specified type with random data.

### Type Parameters

- `T`: The type of the instance to generate.

### Returns

- Type: `T`
- Description: An instance of the specified type with random data.

### Example

```csharp
var randomPerson = DataGenerator.GenerateRandomData<Person>();
Console.WriteLine(randomPerson);
```

### Remarks

The `GenerateRandomData` method generates an instance of the specified type with random data. It uses reflection to get the properties of the type and assigns them random values using the `GenerateRandomValue` method.

---

**Note:** The `DataGenerator` class also contains several private methods for generating random values of specific types, such as `int`, `double`, `string`, `DateTime`, `byte`, `short`, and `bool`. If the type is a class, it recursively calls `GenerateRandomData<object>()`. If the type is not recognized, it tries to create an instance using `Activator.CreateInstance(type)`.
