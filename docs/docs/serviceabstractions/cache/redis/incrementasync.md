# IncrementAsync Method

The `IncrementAsync` method is part of the `IRedisRepository<T>` interface in the `NetPlus.ServiceAbstractions.Cache.Redis` library. This method increments the value of a key in the Redis cache asynchronously.

## Syntax

```csharp
public async Task<long> IncrementAsync(string key, long value = 1)
```

## Parameters

- `key`: The key of the value to increment in the Redis cache. This is a string.
- `value`: The amount by which to increment the value. This is a long. The default value is 1.

## Returns

A task representing the asynchronous operation and containing the new value after the increment.

## Example

```csharp
var repository = serviceProvider.GetService<IRedisRepository<long>>();
long newValue = await repository.IncrementAsync("myKey", 5);
```

In this example, the value of the key "myKey" in the Redis cache will be incremented by 5. `newValue` will contain the new value after the increment.

## Remarks

> [!NOTE]
> The `IncrementAsync` method uses the `StringIncrementAsync` method from the `IDatabase` interface provided by the StackExchange.Redis library to increment the value in Redis.

> [!TIP]
> If the key does not exist in the Redis cache, the `IncrementAsync` method will create it with the increment value.

> [!WARNING]
> Be aware that the `IncrementAsync` method will throw an exception if the Redis server is not available or if there is a network issue. Make sure to handle these exceptions in your code.
