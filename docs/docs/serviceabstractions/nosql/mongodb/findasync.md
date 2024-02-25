## FindAsync Method (LINQ Expression)

### Summary

This overload of the `FindAsync` method retrieves entities from the MongoDB collection asynchronously that match a specified filter.

### Parameters

- `filter`: An expression that defines the conditions that the entities to retrieve should meet. This should be an `Expression<Func<T, bool>>`.

### Returns

This method returns a `Task<IEnumerable<T>>` representing the asynchronous operation. The result of the task is an `IEnumerable<T>` that contains the entities that match the specified filter.

### Example

Here is an example of how to use this overload of the `FindAsync` method:

```csharp
var filteredEntities = await _repository.FindAsync(x => x.Property == "value");
```

In this example, `filteredEntities` will be an `IEnumerable<MyEntity>` that contains all entities in the MongoDB collection where `Property` equals `"value"`. The `_repository` is an instance of `IMongoRepository<MyEntity>`.

### Remarks

This overload of the `FindAsync` method uses the MongoDB driver's `Find` and `ToListAsync` methods to retrieve the entities from the MongoDB collection. The method uses the provided `filter` to construct a filter that matches the specified conditions.

> [!INFO]
> If no entities match the specified filter, the result of the task is an empty `IEnumerable<T>`.

> [!WARNING]
> If an error occurs during the retrieval, the method throws an exception. It's important to handle this exception in your code to prevent the application from crashing.

## FindAsync Method (FilterDefinition)

### Summary

This overload of the `FindAsync` method retrieves entities from the MongoDB collection asynchronously that match a specified filter.

### Parameters

- `filter`: A `FilterDefinition<T>` that defines the conditions that the entities to retrieve should meet.

### Returns

This method returns a `Task<IEnumerable<T>>` representing the asynchronous operation. The result of the task is an `IEnumerable<T>` that contains the entities that match the specified filter.

### Example

Here is an example of how to use this overload of the `FindAsync` method:

```csharp
var filterDefinition = Builders<MyEntity>.Filter.Eq(x => x.Property, "value");
var filteredEntities = await _repository.FindAsync(filterDefinition);
```

In this example, `filteredEntities` will be an `IEnumerable<MyEntity>` that contains all entities in the MongoDB collection where `Property` equals `"value"`. The `_repository` is an instance of `IMongoRepository<MyEntity>`.

### Remarks

This overload of the `FindAsync` method uses the MongoDB driver's `Find` and `ToListAsync` methods to retrieve the entities from the MongoDB collection. The method uses the provided `filter` to construct a filter that matches the specified conditions.

> [!INFO]
> If no entities match the specified filter, the result of the task is an empty `IEnumerable<T>`.

> [!WARNING]
> If an error occurs during the retrieval, the method throws an exception. It's important to handle this exception in your code to prevent the application from crashing.

## FindAsync Method (JSON Filter)

### Summary

This overload of the `FindAsync` method retrieves entities from the MongoDB collection asynchronously that match a specified JSON filter.

### Parameters

- `filterJson`: A JSON string that defines the conditions that the entities to retrieve should meet.

### Returns

This method returns a `Task<IEnumerable<T>>` representing the asynchronous operation. The result of the task is an `IEnumerable<T>` that contains the entities that match the specified filter.

### Example

Here is an example of how to use this overload of the `FindAsync` method:

```csharp
var filteredEntities = await _repository.FindAsync("{ 'Property': 'value' }");
```

In this example, `filteredEntities` will be an `IEnumerable<MyEntity>` that contains all entities in the MongoDB collection where `Property` equals `"value"`. The `_repository` is an instance of `IMongoRepository<MyEntity>`.

### Remarks

This overload of the `FindAsync` method uses the MongoDB driver's `Find` and `ToListAsync` methods to retrieve the entities from the MongoDB collection. The method uses the provided JSON filter to construct a filter that matches the specified conditions.

> [!INFO]
> If no entities match the specified filter, the result of the task is an empty `IEnumerable<T>`.

> [!WARNING]
> If an error occurs during the retrieval, the method throws an exception. It's important to handle this exception in your code to prevent the application from crashing.

## FindAsync Method (FilterDefinitionBuilder)

### Summary

This overload of the `FindAsync` method retrieves entities from the MongoDB collection asynchronously using a `FilterDefinitionBuilder<T>`.

### Parameters

- `filterBuilder`: A `FilterDefinitionBuilder<T>` that defines the conditions that the entities to retrieve should meet.

### Returns

This method returns a `Task<IEnumerable<T>>` representing the asynchronous operation. The result of the task is an `IEnumerable<T>` that contains the entities that match the specified filter.

### Example

Here is an example of how to use this overload of the `FindAsync` method:

```csharp
var filterBuilder = Builders<MyEntity>.Filter;
var filteredEntities = await _repository.FindAsync(filterBuilder);
```

In this example, `filteredEntities` will be an `IEnumerable<MyEntity>` that contains all entities in the MongoDB collection. The `_repository` is an instance of `IMongoRepository<MyEntity>`.

### Remarks

This overload of the `FindAsync` method uses the MongoDB driver's `Find` and `ToListAsync` methods to retrieve the entities from the MongoDB collection. The method uses the provided `filterBuilder` to construct a filter that matches the specified conditions.

> [!INFO]
> If no entities match the specified filter, the result of the task is an empty `IEnumerable<T>`.

> [!WARNING]
> If an error occurs during the retrieval, the method throws an exception. It's important to handle this exception in your code to prevent the application from crashing.

## FindAsync Method (Property and Value)

### Summary

This overload of the `FindAsync` method retrieves entities from the MongoDB collection asynchronously that match a specified property and value.

### Parameters

- `propertyName`: The name of the property that the entities to retrieve should match.
- `value`: The value that the specified property should have.

### Returns

This method returns a `Task<IEnumerable<T>>` representing the asynchronous operation. The result of the task is an `IEnumerable<T>` that contains the entities that match the specified property and value.

### Example

Here is an example of how to use this overload of the `FindAsync` method:

```csharp
var filteredEntities = await _repository.FindAsync("Property", "value");
```

In this example, `filteredEntities` will be an `IEnumerable<MyEntity>` that contains all entities in the MongoDB collection where `Property` equals `"value"`. The `_repository` is an instance of `IMongoRepository<MyEntity>`.

### Remarks

This overload of the `FindAsync` method uses the MongoDB driver's `Find` and `ToListAsync` methods to retrieve the entities from the MongoDB collection. The method uses the provided property name and value to construct a filter that matches the specified conditions.

> [!INFO]
> If no entities match the specified property and value, the result of the task is an empty `IEnumerable<T>`.

> [!WARNING]
> If an error occurs during the retrieval, the method throws an exception. It's important to handle this exception in your code to prevent the application from crashing.

## FindAsync Method (Dictionary of Filters)

### Summary

This overload of the `FindAsync` method retrieves entities from the MongoDB collection asynchronously that match a specified dictionary of filters.

### Parameters

- `filters`: A dictionary where the keys are the names of the properties that the entities to retrieve should match, and the values are the values that the specified properties should have.

### Returns

This method returns a `Task<IEnumerable<T>>` representing the asynchronous operation. The result of the task is an `IEnumerable<T>` that contains the entities that match the specified filters.

### Example

Here is an example of how to use this overload of the `FindAsync` method:

```csharp
var filters = new Dictionary<string, object> { { "Property", "value" } };
var filteredEntities = await _repository.FindAsync(filters);
```

In this example, `filteredEntities` will be an `IEnumerable<MyEntity>` that contains all entities in the MongoDB collection where `Property` equals `"value"`. The `_repository` is an instance of `IMongoRepository<MyEntity>`.

### Remarks

This overload of the `FindAsync` method uses the MongoDB driver's `Find` and `ToListAsync` methods to retrieve the entities from the MongoDB collection. The method uses the provided dictionary of filters to construct a filter that matches the specified conditions.

> [!INFO]
> If no entities match the specified filters, the result of the task is an empty `IEnumerable<T>`.

> [!WARNING]
> If an error occurs during the retrieval, the method throws an exception. It's important to handle this exception in your code to prevent the application from crashing.