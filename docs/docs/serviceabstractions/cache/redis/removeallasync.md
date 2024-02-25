# RemoveAllAsync Method

The `RemoveAllAsync` method is part of the `IRedisRepository<T>` interface in the `NetPlus.ServiceAbstractions.Cache.Redis` library. This method removes multiple objects from the Redis cache asynchronously based on the specified keys.

## Syntax

```csharp
public async Task<bool> RemoveAllAsync(IEnumerable<string> keys)
```

## Parameters

- `keys`: A collection containing the keys of the objects to be removed from the Redis cache. The keys are strings.

## Returns

A task representing the asynchronous operation and containing a boolean indicating if all objects were successfully removed.

## Example

```csharp
var repository = serviceProvider.GetService<IRedisRepository<MyClass>>();
var keys = new List<string> { "myKey1", "myKey2" };
bool success = await repository.RemoveAllAsync(keys);
```

In this example, the objects with the keys "myKey1" and "myKey2" will be removed from the Redis cache. The `success` variable will be `true` if all objects were successfully removed, and `false` otherwise.

## Remarks

> [!NOTE]
> The `RemoveAllAsync` method uses the `RemoveAsync` method to remove each key-value pair from the Redis cache. It waits for all `RemoveAsync` tasks to complete using the `Task.WhenAll` method.

> [!TIP]
> If a key does not exist in the Redis cache, the `RemoveAsync` method will return `false` for that key.

> [!WARNING]
> Be aware that the `RemoveAllAsync` method will throw an exception if the Redis server is not available or if there is a network issue. Make sure to handle these exceptions in your code.
