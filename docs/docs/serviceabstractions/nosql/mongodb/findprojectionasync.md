## FindProjectionAsync Method (LINQ Expression)

### Summary

This overload of the `FindProjectionAsync` method retrieves a projection of entities from the MongoDB collection asynchronously that match a specified filter.

### Parameters

- `filter`: An expression that defines the conditions that the entities to retrieve should meet. This should be an `Expression<Func<T, bool>>`.
- `projection`: An expression that defines the projection to apply to the entities.

### Returns

This method returns a `Task<IEnumerable<TProjection>>` representing the asynchronous operation. The result of the task is an `IEnumerable<TProjection>` that contains the projected entities that match the specified filter.

### Example

Here is an example of how to use this overload of the `FindProjectionAsync` method:

```csharp
var projectedEntities = await _repository.FindProjectionAsync(x => x.Property == "value", x => new { x.Property });
```

In this example, `projectedEntities` will be an `IEnumerable<TProjection>` that contains all projected entities in the MongoDB collection where `Property` equals `"value"`.

### Remarks

This overload of the `FindProjectionAsync` method uses the MongoDB driver's `Find`, `Project` and `ToListAsync` methods to retrieve the projected entities from the MongoDB collection. The method uses the provided `filter` and `projection` to construct a filter and a projection that match the specified conditions.

> [!NOTE]
> If no entities match the specified filter, the result of the task is an empty `IEnumerable<TProjection>`.

> [!WARNING]
> If an error occurs during the retrieval, the method throws an exception. It's important to handle this exception in your code to prevent the application from crashing.

## FindProjectionAsync Method (FilterDefinition)

### Summary

This overload of the `FindProjectionAsync` method retrieves a projection of entities from the MongoDB collection asynchronously that match a specified filter.

### Parameters

- `filter`: A `FilterDefinition<T>` that defines the conditions that the entities to retrieve should meet.
- `projection`: A `ProjectionDefinition<T, TProjection>` that defines the projection to apply to the entities.

### Returns

This method returns a `Task<IEnumerable<TProjection>>` representing the asynchronous operation. The result of the task is an `IEnumerable<TProjection>` that contains the projected entities that match the specified filter.

### Example

Here is an example of how to use this overload of the `FindProjectionAsync` method:

```csharp
var filterDefinition = Builders<MyEntity>.Filter.Eq(x => x.Property, "value");
var projectionDefinition = Builders<MyEntity>.Projection.Expression(x => new { x.Property });
var projectedEntities = await _repository.FindProjectionAsync(filterDefinition, projectionDefinition);
```

In this example, `projectedEntities` will be an `IEnumerable<TProjection>` that contains all projected entities in the MongoDB collection where `Property` equals `"value"`.

### Remarks

This overload of the `FindProjectionAsync` method uses the MongoDB driver's `Find`, `Project` and `ToListAsync` methods to retrieve the projected entities from the MongoDB collection. The method uses the provided `filter` and `projection` to construct a filter and a projection that match the specified conditions.

> [!NOTE]
> If no entities match the specified filter, the result of the task is an empty `IEnumerable<TProjection>`.

> [!WARNING]
> If an error occurs during the retrieval, the method throws an exception. It's important to handle this exception in your code to prevent the application from crashing.

## FindProjectionAsync Method (JSON Filter)

### Summary

This overload of the `FindProjectionAsync` method retrieves a projection of entities from the MongoDB collection asynchronously that match a specified JSON filter.

### Parameters

- `filterJson`: A JSON string that defines the conditions that the entities to retrieve should meet.
- `projection`: A `ProjectionDefinition<T, TProjection>` that defines the projection to apply to the entities.

### Returns

This method returns a `Task<IEnumerable<TProjection>>` representing the asynchronous operation. The result of the task is an `IEnumerable<TProjection>` that contains the projected entities that match the specified filter.

### Example

Here is an example of how to use this overload of the `FindProjectionAsync` method:

```csharp
var projectionDefinition = Builders<MyEntity>.Projection.Expression(x => new { x.Property });
var projectedEntities = await _repository.FindProjectionAsync("{ 'Property': 'value' }", projectionDefinition);
```

In this example, `projectedEntities` will be an `IEnumerable<TProjection>` that contains all projected entities in the MongoDB collection where `Property` equals `"value"`.

### Remarks

This overload of the `FindProjectionAsync` method uses the MongoDB driver's `Find`, `Project` and `ToListAsync` methods to retrieve the projected entities from the MongoDB collection. The method uses the provided JSON filter and `projection` to construct a filter and a projection that match the specified conditions.

> [!NOTE]
> If no entities match the specified filter, the result of the task is an empty `IEnumerable<TProjection>`.

> [!WARNING]
> If an error occurs during the retrieval, the method throws an exception. It's important to handle this exception in your code to prevent the application from crashing.

## FindProjectionAsync Method (FilterDefinitionBuilder)

### Summary

This overload of the `FindProjectionAsync` method retrieves a projection of entities from the MongoDB collection asynchronously using a `FilterDefinitionBuilder`.

### Parameters

- `filterBuilder`: A `FilterDefinitionBuilder<T>` that defines the conditions that the entities to retrieve should meet.
- `projection`: A `ProjectionDefinition<T, TProjection>` that defines the projection to apply to the entities.

### Returns

This method returns a `Task<IEnumerable<TProjection>>` representing the asynchronous operation. The result of the task is an `IEnumerable<TProjection>` that contains the projected entities that match the specified filter.

### Example

Here is an example of how to use this overload of the `FindProjectionAsync` method:

```csharp
var filterBuilder = Builders<MyEntity>.Filter;
var projectionDefinition = Builders<MyEntity>.Projection.Expression(x => new { x.Property });
var projectedEntities = await _repository.FindProjectionAsync(filterBuilder, projectionDefinition);
```

In this example, `projectedEntities` will be an `IEnumerable<TProjection>` that contains all projected entities in the MongoDB collection.

### Remarks

This overload of the `FindProjectionAsync` method uses the MongoDB driver's `Find`, `Project` and `ToListAsync` methods to retrieve the projected entities from the MongoDB collection. The method uses the provided `filterBuilder` and `projection` to construct a filter and a projection that match the specified conditions.

> [!NOTE]
> If no entities match the specified filter, the result of the task is an empty `IEnumerable<TProjection>`.

> [!WARNING]
> If an error occurs during the retrieval, the method throws an exception. It's important to handle this exception in your code to prevent the application from crashing.

## FindProjectionAsync Method (Property Name and Value)

### Summary

This overload of the `FindProjectionAsync` method retrieves a projection of entities from the MongoDB collection asynchronously that match a specified property name and value.

### Parameters

- `propertyName`: The name of the property to filter the entities by.
- `value`: The value that the property should have.
- `projection`: A `ProjectionDefinition<T, TProjection>` that defines the projection to apply to the entities.

### Returns

This method returns a `Task<IEnumerable<TProjection>>` representing the asynchronous operation. The result of the task is an `IEnumerable<TProjection>` that contains the projected entities that match the specified filter.

### Example

Here is an example of how to use this overload of the `FindProjectionAsync` method:

```csharp
var projectionDefinition = Builders<MyEntity>.Projection.Expression(x => new { x.Property });
var projectedEntities = await _repository.FindProjectionAsync("Property", "value", projectionDefinition);
```

In this example, `projectedEntities` will be an `IEnumerable<TProjection>` that contains all projected entities in the MongoDB collection where `Property` equals `"value"`.

### Remarks

This overload of the `FindProjectionAsync` method uses the MongoDB driver's `Find`, `Project` and `ToListAsync` methods to retrieve the projected entities from the MongoDB collection. The method uses the provided `propertyName`, `value`, and `projection` to construct a filter and a projection that match the specified conditions.

> [!NOTE]
> If no entities match the specified filter, the result of the task is an empty `IEnumerable<TProjection>`.

> [!WARNING]
> If an error occurs during the retrieval, the method throws an exception. It's important to handle this exception in your code to prevent the application from crashing.

## FindProjectionAsync Method (Dictionary Filters)

### Summary

This overload of the `FindProjectionAsync` method retrieves a projection of entities from the MongoDB collection asynchronously that match a specified set of filters.

### Parameters

- `filters`: A `Dictionary<string, object>` that defines the conditions that the entities to retrieve should meet.
- `projection`: A `ProjectionDefinition<T, TProjection>` that defines the projection to apply to the entities.

### Returns

This method returns a `Task<IEnumerable<TProjection>>` representing the asynchronous operation. The result of the task is an `IEnumerable<TProjection>` that contains the projected entities that match the specified filter.

### Example

Here is an example of how to use this overload of the `FindProjectionAsync` method:

```csharp
var filters = new Dictionary<string, object> { { "Property", "value" } };
var projectionDefinition = Builders<MyEntity>.Projection.Expression(x => new { x.Property });
var projectedEntities = await _repository.FindProjectionAsync(filters, projectionDefinition);
```

In this example, `projectedEntities` will be an `IEnumerable<TProjection>` that contains all projected entities in the MongoDB collection where `Property` equals `"value"`.

### Remarks

This overload of the `FindProjectionAsync` method uses the MongoDB driver's `Find`, `Project` and `ToListAsync` methods to retrieve the projected entities from the MongoDB collection. The method uses the provided `filters` and `projection` to construct a filter and a projection that match the specified conditions.

> [!NOTE]
> If no entities match the specified filter, the result of the task is an empty `IEnumerable<TProjection>`.

> [!WARNING]
> If an error occurs during the retrieval, the method throws an exception. It's important to handle this exception in your code to prevent the application from crashing.