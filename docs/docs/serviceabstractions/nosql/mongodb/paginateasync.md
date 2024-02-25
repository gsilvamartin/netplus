## PaginateAsync Method (Page and Page Size)

### Summary

This method paginates the entities in the MongoDB collection based on the specified page and page size.

### Parameters

- `page`: An `int` that represents the page number.
- `pageSize`: An `int` that represents the number of entities per page.

### Returns

This method returns a `Task<IEnumerable<T>>` representing the asynchronous operation. The result of the task is an `IEnumerable<T>` of the paginated entities.

### Example

Here is an example of how to use this method:

```csharp
var paginatedEntities = await _repository.PaginateAsync(2, 10);
```

In this example, `paginatedEntities` will be an `IEnumerable<T>` of the entities in the MongoDB collection for the second page, with 10 entities per page.

### Remarks

This method uses the MongoDB driver's `Skip` and `Limit` methods to paginate the entities in the MongoDB collection based on the specified page and page size.

> [!INFO]
> If the `page` or `pageSize` parameters are less than 1, the MongoDB driver will throw an `ArgumentException`.

> [!WARNING]
> If the MongoDB collection does not contain enough entities to fill the requested page, the returned `IEnumerable<T>` will contain fewer entities than `pageSize`.

## PaginateAsync Method (Expression Filter, Page, and Page Size)

### Summary

This method paginates the entities in the MongoDB collection that match a specified filter based on the specified page and page size.

### Parameters

- `filter`: An `Expression<Func<T, bool>>` that defines the conditions that the entities should meet.
- `page`: An `int` that represents the page number.
- `pageSize`: An `int` that represents the number of entities per page.

### Returns

This method returns a `Task<IEnumerable<T>>` representing the asynchronous operation. The result of the task is an `IEnumerable<T>` of the paginated entities that match the specified filter.

### Example

Here is an example of how to use this method:

```csharp
var paginatedEntities = await _repository.PaginateAsync(x => x.Property == "value", 2, 10);
```

In this example, `paginatedEntities` will be an `IEnumerable<T>` of the entities in the MongoDB collection where `Property` equals `"value"` for the second page, with 10 entities per page.

### Remarks

This method uses the MongoDB driver's `Find`, `Skip`, and `Limit` methods to paginate the entities in the MongoDB collection that match the specified filter based on the specified page and page size.

> [!INFO]
> If the `page` or `pageSize` parameters are less than 1, the MongoDB driver will throw an `ArgumentException`.

> [!WARNING]
> If the MongoDB collection does not contain enough entities to fill the requested page, the returned `IEnumerable<T>` will contain fewer entities than `pageSize`.

## PaginateAsync Method (SortDefinition, Page, and Page Size)

### Summary

This method paginates and sorts the entities in the MongoDB collection based on a specified `SortDefinition<T>`, page, and page size.

### Parameters

- `sortDefinition`: A `SortDefinition<T>` that defines how the entities should be sorted.
- `page`: An `int` that represents the page number.
- `pageSize`: An `int` that represents the number of entities per page.

### Returns

This method returns a `Task<IEnumerable<T>>` representing the asynchronous operation. The result of the task is an `IEnumerable<T>` of the paginated and sorted entities.

### Example

Here is an example of how to use this method:

```csharp
var sortDefinition = Builders<MyEntity>.Sort.Descending(x => x.Property);
var paginatedEntities = await _repository.PaginateAsync(sortDefinition, 2, 10);
```

In this example, `paginatedEntities` will be an `IEnumerable<T>` of the entities in the MongoDB collection sorted by `Property` in descending order for the second page, with 10 entities per page.

### Remarks

This method uses the MongoDB driver's `Find`, `Sort`, `Skip`, and `Limit` methods to paginate and sort the entities in the MongoDB collection based on the specified `SortDefinition<T>`, page, and page size.

> [!INFO]
> If the `page` or `pageSize` parameters are less than 1, the MongoDB driver will throw an `ArgumentException`.

> [!WARNING]
> If the MongoDB collection does not contain enough entities to fill the requested page, the returned `IEnumerable<T>` will contain fewer entities than `pageSize`.

## PaginateAsync Method (Expression Filter, SortDefinition, Page, and Page Size)

### Summary

This method paginates and sorts the entities in the MongoDB collection that match a specified filter based on a specified `SortDefinition<T>`, page, and page size.

### Parameters

- `filter`: An `Expression<Func<T, bool>>` that defines the conditions that the entities should meet.
- `sortDefinition`: A `SortDefinition<T>` that defines how the entities should be sorted.
- `page`: An `int` that represents the page number.
- `pageSize`: An `int` that represents the number of entities per page.

### Returns

This method returns a `Task<IEnumerable<T>>` representing the asynchronous operation. The result of the task is an `IEnumerable<T>` of the paginated and sorted entities that match the specified filter.

### Example

Here is an example of how to use this method:

```csharp
var filter = Builders<MyEntity>.Filter.Eq(x => x.Property, "value");
var sortDefinition = Builders<MyEntity>.Sort.Descending(x => x.Property);
var paginatedEntities = await _repository.PaginateAsync(filter, sortDefinition, 2, 10);
```

In this example, `paginatedEntities` will be an `IEnumerable<T>` of the entities in the MongoDB collection where `Property` equals `"value"`, sorted by `Property` in descending order for the second page, with 10 entities per page.

### Remarks

This method uses the MongoDB driver's `Find`, `Sort`, `Skip`, and `Limit` methods to paginate and sort the entities in the MongoDB collection that match the specified filter based on the specified `SortDefinition<T>`, page, and page size.

> [!INFO]
> If the `page` or `pageSize` parameters are less than 1, the MongoDB driver will throw an `ArgumentException`.

> [!WARNING]
> If the MongoDB collection does not contain enough entities to fill the requested page, the returned `IEnumerable<T>` will contain fewer entities than `pageSize`.