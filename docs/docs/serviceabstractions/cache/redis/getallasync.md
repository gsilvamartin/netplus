# GetAllAsync Method

The `GetAllAsync` method is part of the `IRedisRepository<T>` interface in the `NetPlus.ServiceAbstractions.Cache.Redis` library. This method retrieves all objects stored in the Redis cache asynchronously based on a pattern.

## Syntax

```csharp
public async Task<IEnumerable<T>> GetAllAsync(string pattern = "*")
```

## Parameters

- `pattern`: The pattern to match keys in the Redis cache. This is a string. The default value is "*".

## Returns

A task representing the asynchronous operation and containing the collection of all objects stored in the Redis cache matching the specified pattern.

## Example

```csharp
var repository = serviceProvider.GetService<IRedisRepository<MyClass>>();
IEnumerable<MyClass> myObjects = await repository.GetAllAsync("myKeyPrefix*");
```

In this example, `myObjects` will contain all objects in the Redis cache whose keys match the pattern "myKeyPrefix*".

## Remarks

> [!NOTE]
> The `GetAllAsync` method uses the `SearchKeysAsync` method to find all keys in the Redis cache that match the specified pattern. It then uses the `StringGetAsync` method from the `IDatabase` interface provided by the StackExchange.Redis library to retrieve the values from Redis. These values are deserialized into objects of type `T` using the `JsonConvert.DeserializeObject<T>` method from the Newtonsoft.Json library.

> [!TIP]
> The pattern parameter supports wildcard characters. For example, "*" matches all keys, "myKeyPrefix*" matches all keys that start with "myKeyPrefix", and "*myKeySuffix" matches all keys that end with "myKeySuffix".

> [!WARNING]
> Be aware that the `GetAllAsync` method will throw an exception if the Redis server is not available or if there is a network issue. Make sure to handle these exceptions in your code.
