# DecrementAsync Method

The `DecrementAsync` method is part of the `IRedisRepository<T>` interface in the `NetPlus.ServiceAbstractions.Cache.Redis` library. This method decrements the value of a key in the Redis cache asynchronously.

## Syntax

```csharp
public async Task<long> DecrementAsync(string key, long value = 1)
```

## Parameters

- `key`: The key of the value to decrement in the Redis cache. This is a string.
- `value`: The amount by which to decrement the value. This is a long. The default value is 1.

## Returns

A task representing the asynchronous operation and containing the new value after the decrement.

## Example

```csharp
var repository = serviceProvider.GetService<IRedisRepository<long>>();
long newValue = await repository.DecrementAsync("myKey", 5);
```

In this example, the value of the key "myKey" in the Redis cache will be decremented by 5. `newValue` will contain the new value after the decrement.

## Remarks

> [!NOTE]
> The `DecrementAsync` method uses the `StringDecrementAsync` method from the `IDatabase` interface provided by the StackExchange.Redis library to decrement the value in Redis.

> [!TIP]
> If the key does not exist in the Redis cache, the `DecrementAsync` method will create it with a value of -1 (or the negative of the decrement value if it's not 1).

> [!WARNING]
> Be aware that the `DecrementAsync` method will throw an exception if the Redis server is not available or if there is a network issue. Make sure to handle these exceptions in your code.
