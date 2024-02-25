# SearchKeysAsync Method

The `SearchKeysAsync` method is part of the `IRedisRepository<T>` interface in the `NetPlus.ServiceAbstractions.Cache.Redis` library. This method searches for keys in the Redis cache asynchronously based on a pattern.

## Syntax

```csharp
public Task<IEnumerable<string>> SearchKeysAsync(string pattern)
```

## Parameters

- `pattern`: The pattern to match keys against in the Redis cache. This is a string.

## Returns

A task representing the asynchronous operation and containing an enumerable of strings representing the keys that match the pattern.

## Example

```csharp
var repository = serviceProvider.GetService<IRedisRepository<MyClass>>();
IEnumerable<string> matchingKeys = await repository.SearchKeysAsync("myKey*");
```

In this example, `matchingKeys` will contain all keys in the Redis cache that start with "myKey".

## Remarks

> [!NOTE]
> The `SearchKeysAsync` method uses the `Keys` method from the `IServer` interface provided by the StackExchange.Redis library to search for keys in Redis.

> [!TIP]
> If the `pattern` parameter is not provided or is null, the `SearchKeysAsync` method will return all keys in the Redis cache.

> [!WARNING]
> Be aware that the `SearchKeysAsync` method will throw an exception if the Redis server is not available or if there is a network issue. Make sure to handle these exceptions in your code.
