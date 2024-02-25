## SortByAsync Method (Expression Key Selector)

### Summary

This method sorts the entities in the MongoDB collection based on a specified key selector and order.

### Parameters

- `keySelector`: An `Expression<Func<T, object>>` that defines the key to sort the entities by.
- `ascending`: A `bool` that indicates whether the entities should be sorted in ascending order. The default value is `true`.

### Returns

This method returns a `Task<IEnumerable<T>>` representing the asynchronous operation. The result of the task is an `IEnumerable<T>` of the sorted entities.

### Example

Here is an example of how to use this method:

```csharp
var sortedEntities = await _repository.SortByAsync(x => x.Property, false);
```

In this example, `sortedEntities` will be an `IEnumerable<T>` of the entities in the MongoDB collection sorted by `Property` in descending order.

### Remarks

This method uses the MongoDB driver's `Sort` method to sort the entities in the MongoDB collection based on the specified key selector and order.

> [!NOTE]
> This method will return an empty `IEnumerable<T>` if the MongoDB collection is empty.

> [!WARNING]
> This method will throw an `Exception` if there is a problem connecting to the MongoDB server or if the key selector is invalid.

## SortByAsync Method (SortDefinition)

### Summary

This method sorts the entities in the MongoDB collection based on a specified `SortDefinition<T>`.

### Parameters

- `sortDefinition`: A `SortDefinition<T>` that defines how the entities should be sorted.

### Returns

This method returns a `Task<IEnumerable<T>>` representing the asynchronous operation. The result of the task is an `IEnumerable<T>` of the sorted entities.

### Example

Here is an example of how to use this method:

```csharp
var sortDefinition = Builders<MyEntity>.Sort.Descending(x => x.Property);
var sortedEntities = await _repository.SortByAsync(sortDefinition);
```

In this example, `sortedEntities` will be an `IEnumerable<T>` of the entities in the MongoDB collection sorted by `Property` in descending order.

### Remarks

This method uses the MongoDB driver's `Sort` method to sort the entities in the MongoDB collection based on the specified `SortDefinition<T>`.

> [!NOTE]
> This method will return an empty `IEnumerable<T>` if the MongoDB collection is empty.

> [!WARNING]
> This method will throw an `Exception` if there is a problem connecting to the MongoDB server or if the `SortDefinition<T>` is invalid.