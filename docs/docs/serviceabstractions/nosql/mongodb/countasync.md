## CountAsync Method (No Parameters)

### Summary

This overload of the `CountAsync` method counts the total number of entities in the MongoDB collection asynchronously.

### Returns

This method returns a `Task<long>` representing the asynchronous operation. The result of the task is a `long` that represents the total number of entities in the MongoDB collection.

### Example

Here is an example of how to use this overload of the `CountAsync` method:

```csharp
var totalEntities = await _repository.CountAsync();
```

In this example, `totalEntities` will be a `long` that represents the total number of entities in the MongoDB collection.

### Remarks

This overload of the `CountAsync` method uses the MongoDB driver's `CountDocumentsAsync` method to count the total number of entities in the MongoDB collection.

> [!NOTE]
> If the MongoDB collection is empty, the result of the task is `0`.

> [!WARNING]
> If an error occurs during the operation, the method throws an exception. It's important to handle this exception in your code to prevent the application from crashing.

## CountAsync Method (Expression Filter)

### Summary

This overload of the `CountAsync` method counts the number of entities in the MongoDB collection that match a specified filter asynchronously.

### Parameters

- `filter`: An `Expression<Func<T, bool>>` that defines the conditions that the entities to count should meet.

### Returns

This method returns a `Task<long>` representing the asynchronous operation. The result of the task is a `long` that represents the number of entities in the MongoDB collection that match the specified filter.

### Example

Here is an example of how to use this overload of the `CountAsync` method:

```csharp
var totalEntities = await _repository.CountAsync(x => x.Property == "value");
```

In this example, `totalEntities` will be a `long` that represents the number of entities in the MongoDB collection where `Property` equals `"value"`.

### Remarks

This overload of the `CountAsync` method uses the MongoDB driver's `CountDocumentsAsync` method to count the number of entities in the MongoDB collection that match the specified filter.

> [!NOTE]
> If no entities match the specified filter, the result of the task is `0`.

> [!WARNING]
> If an error occurs during the operation, the method throws an exception. It's important to handle this exception in your code to prevent the application from crashing.

## CountAsync Method (FilterDefinition)

### Summary

This overload of the `CountAsync` method counts the number of entities in the MongoDB collection that match a specified filter asynchronously.

### Parameters

- `filter`: A `FilterDefinition<T>` that defines the conditions that the entities to count should meet.

### Returns

This method returns a `Task<long>` representing the asynchronous operation. The result of the task is a `long` that represents the number of entities in the MongoDB collection that match the specified filter.

### Example

Here is an example of how to use this overload of the `CountAsync` method:

```csharp
var filterDefinition = Builders<MyEntity>.Filter.Eq(x => x.Property, "value");
var totalEntities = await _repository.CountAsync(filterDefinition);
```

In this example, `totalEntities` will be a `long` that represents the number of entities in the MongoDB collection where `Property` equals `"value"`.

### Remarks

This overload of the `CountAsync` method uses the MongoDB driver's `CountDocumentsAsync` method to count the number of entities in the MongoDB collection that match the specified filter.

> [!NOTE]
> If no entities match the specified filter, the result of the task is `0`.

> [!WARNING]
> If an error occurs during the operation, the method throws an exception. It's important to handle this exception in your code to prevent the application from crashing.

## CountAsync Method (JSON Filter)

### Summary

This overload of the `CountAsync` method counts the number of entities in the MongoDB collection that match a specified filter asynchronously. The filter is provided as a JSON string.

### Parameters

- `filterJson`: A `string` that represents a JSON filter.

### Returns

This method returns a `Task<long>` representing the asynchronous operation. The result of the task is a `long` that represents the number of entities in the MongoDB collection that match the specified filter.

### Example

Here is an example of how to use this overload of the `CountAsync` method:

```csharp
var filterJson = "{ \"Property\": \"value\" }";
var totalEntities = await _repository.CountAsync(filterJson);
```

In this example, `totalEntities` will be a `long` that represents the number of entities in the MongoDB collection where `Property` equals `"value"`.

### Remarks

This overload of the `CountAsync` method uses the MongoDB driver's `CountDocumentsAsync` method to count the number of entities in the MongoDB collection that match the specified filter.

> [!NOTE]
> If no entities match the specified filter, the result of the task is `0`.

> [!WARNING]
> If an error occurs during the operation, the method throws an exception. It's important to handle this exception in your code to prevent the application from crashing.

## CountAsync Method (FilterDefinitionBuilder)

### Summary

This overload of the `CountAsync` method counts the total number of entities in the MongoDB collection asynchronously. The filter is provided as a `FilterDefinitionBuilder<T>`.

### Parameters

- `filterBuilder`: A `FilterDefinitionBuilder<T>` that defines the conditions that the entities to count should meet.

### Returns

This method returns a `Task<long>` representing the asynchronous operation. The result of the task is a `long` that represents the total number of entities in the MongoDB collection.

### Example

Here is an example of how to use this overload of the `CountAsync` method:

```csharp
var filterBuilder = Builders<MyEntity>.Filter;
var totalEntities = await _repository.CountAsync(filterBuilder);
```

In this example, `totalEntities` will be a `long` that represents the total number of entities in the MongoDB collection.

### Remarks

This overload of the `CountAsync` method uses the MongoDB driver's `CountDocumentsAsync` method to count the total number of entities in the MongoDB collection.

> [!NOTE]
> If the MongoDB collection is empty, the result of the task is `0`.

> [!WARNING]
> If an error occurs during the operation, the method throws an exception. It's important to handle this exception in your code to prevent the application from crashing.

## CountAsync Method (Property Name and Value)

### Summary

This overload of the `CountAsync` method counts the number of entities in the MongoDB collection that match a specified property and value asynchronously.

### Parameters

- `propertyName`: A `string` that represents the name of the property.
- `value`: An `object` that represents the value of the property.

### Returns

This method returns a `Task<long>` representing the asynchronous operation. The result of the task is a `long` that represents the number of entities in the MongoDB collection where the specified property equals the specified value.

### Example

Here is an example of how to use this overload of the `CountAsync` method:

```csharp
var totalEntities = await _repository.CountAsync("Property", "value");
```

In this example, `totalEntities` will be a `long` that represents the number of entities in the MongoDB collection where `Property` equals `"value"`.

### Remarks

This overload of the `CountAsync` method uses the MongoDB driver's `CountDocumentsAsync` method to count the number of entities in the MongoDB collection where the specified property equals the specified value.

> [!NOTE]
> If no entities match the specified property and value, the result of the task is `0`.

> [!WARNING]
> If an error occurs during the operation, the method throws an exception. It's important to handle this exception in your code to prevent the application from crashing.

## CountAsync Method (Dictionary Filters)

### Summary

This overload of the `CountAsync` method counts the number of entities in the MongoDB collection that match a specified set of filters asynchronously.

### Parameters

- `filters`: A `Dictionary<string, object>` that defines the conditions that the entities to count should meet.

### Returns

This method returns a `Task<long>` representing the asynchronous operation. The result of the task is a `long` that represents the number of entities in the MongoDB collection that match the specified filters.

### Example

Here is an example of how to use this overload of the `CountAsync` method:

```csharp
var filters = new Dictionary<string, object> { { "Property", "value" } };
var totalEntities = await _repository.CountAsync(filters);
```

In this example, `totalEntities` will be a `long` that represents the number of entities in the MongoDB collection where `Property` equals `"value"`.

### Remarks

This overload of the `CountAsync` method uses the MongoDB driver's `CountDocumentsAsync` method to count the number of entities in the MongoDB collection that match the specified filters.

> [!NOTE]
> If no entities match the specified filters, the result of the task is `0`.

> [!WARNING]
> If an error occurs during the operation, the method throws an exception. It's important to handle this exception in your code to prevent the application from crashing.