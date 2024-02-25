# SetAllAsync Method

The `SetAllAsync` method is part of the `IRedisRepository<T>` interface in the `NetPlus.ServiceAbstractions.Cache.Redis` library. This method stores multiple objects in the Redis cache asynchronously with their respective keys.

## Syntax

```csharp
public async Task<bool> SetAllAsync(Dictionary<string, T> keyValues, TimeSpan? expiry = null)
```

## Parameters

- `keyValues`: A dictionary containing the keys and values to be stored in the Redis cache. The keys are strings and the values are of type `T`.
- `expiry`: The optional expiration time for the stored objects in the Redis cache. If null, the objects won't expire. This is of type `TimeSpan?`.

## Returns

A task representing the asynchronous operation and containing a boolean indicating if all objects were successfully stored.

## Example

```csharp
var repository = serviceProvider.GetService<IRedisRepository<MyClass>>();
var myObjects = new Dictionary<string, MyClass>
{
    { "myKey1", new MyClass { Property1 = "Value1", Property2 = "Value2" } },
    { "myKey2", new MyClass { Property1 = "Value3", Property2 = "Value4" } }
};
bool success = await repository.SetAllAsync(myObjects, TimeSpan.FromHours(1));
```

In this example, `myObjects` will be stored in the Redis cache with their respective keys and an expiration time of 1 hour. The `success` variable will be `true` if all objects were successfully stored, and `false` otherwise.

## Remarks

> [!NOTE]
> The `SetAllAsync` method uses the `SetAsync` method to store each key-value pair in the Redis cache. It waits for all `SetAsync` tasks to complete using the `Task.WhenAll` method.

> [!TIP]
> If the `expiry` parameter is not provided or is null, the objects will be stored in the Redis cache indefinitely, until they are manually removed or the Redis server evicts them due to memory pressure.

> [!WARNING]
> Be aware that the `SetAllAsync` method will throw an exception if the Redis server is not available or if there is a network issue. Make sure to handle these exceptions in your code.
