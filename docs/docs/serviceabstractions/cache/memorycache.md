# MemoryCacheRepository<T> Class

**Memory Cache Repository for storing and retrieving objects in-memory.**

## Type Parameters

- `T`: The type of objects to be stored and retrieved.

## Methods

```csharp
GetAsync(string key)
```

Retrieves an object from the memory cache asynchronously based on the specified key.

### Parameters

- `key`: The unique identifier for the object in the memory cache.

### Returns

- Type: `Task<T>`
- Description: A task representing the asynchronous operation and containing the retrieved object, or null if not found.

### Example

```csharp
var value = await cache.GetAsync("key1");
Console.WriteLine(value);  // Output: "value1"
```

---

```csharp
SetAsync(string key, T value, TimeSpan? expiry = null)
```

Stores an object in the memory cache asynchronously with the specified key.

### Parameters

- `key`: The unique identifier for the object in the memory cache.
- `value`: The object to be stored in the memory cache.
- `expiry`: The optional expiration time for the stored object in the memory cache. If null, the object won't expire.

### Returns

- Type: `Task<bool>`
- Description: A task representing the asynchronous operation and containing a boolean indicating if the object was successfully stored.

### Example

```csharp
await cache.SetAsync("key1", "value1");
```

---

```csharp
RemoveAsync(string key)
```

Removes an object from the memory cache asynchronously based on the specified key.

### Parameters

- `key`: The unique identifier for the object in the memory cache.

### Returns

- Type: `Task<bool>`
- Description: A task representing the asynchronous operation and containing a boolean indicating if the object was successfully removed.

### Example

```csharp
await cache.RemoveAsync("key1");
```

---

```csharp
GetAllAsync()
```

Retrieves all objects stored in the memory cache asynchronously.

### Returns

- Type: `Task<IEnumerable<T>>`
- Description: A task representing the asynchronous operation and containing the collection of all objects stored in the memory cache.

### Example

```csharp
var allObjects = await cache.GetAllAsync();
foreach (var obj in allObjects)
{
    Console.WriteLine(obj);  // Output: "value2", "value3"
}
```

---

```csharp
SetAllAsync(Dictionary<string, T> keyValues, TimeSpan? expiry = null)
```

Stores multiple objects in the memory cache asynchronously with the specified keys and values.

### Parameters

- `keyValues`: The dictionary containing the keys and values to be stored in the memory cache.
- `expiry`: The optional expiration time for the stored objects in the memory cache. If null, the objects won't expire.

### Returns

- Type: `Task<bool>`
- Description: A task representing the asynchronous operation and containing a boolean indicating if the objects were successfully stored.

### Example

```csharp
var objects = new Dictionary<string, string> { { "key2", "value2" }, { "key3", "value3" } };
await cache.SetAllAsync(objects);
```

---

```csharp
RemoveAllAsync(IEnumerable<string> keys)
```

Removes multiple objects from the memory cache asynchronously based on the specified keys.

### Parameters

- `keys`: The unique identifiers for the objects in the memory cache.

### Returns

- Type: `Task<bool>`
- Description: A task representing the asynchronous operation and containing a boolean indicating if the objects were successfully removed.

### Example

```csharp
await cache.RemoveAllAsync(new List<string> { "key2", "key3" });
```

---

```csharp
KeyExistsAsync(string key)
```

Checks if an object with the specified key exists in the memory cache asynchronously.

### Parameters

- `key`: The unique identifier for the object in the memory cache.

### Returns

- Type: `Task<bool>`
- Description: A task representing the asynchronous operation and containing a boolean indicating if the object with the specified key exists in the memory cache.

### Example

```csharp
var exists = await cache.KeyExistsAsync("key1");
Console.WriteLine(exists);  // Output: true
```

### Remarks

The `MemoryCacheRepository<T>` class is a simple implementation of an in-memory cache. It uses a `ConcurrentDictionary<string, CacheItem<T>>` to store the objects, where `CacheItem<T>` is a private class used to store the object and its expiration time. The `IsValid()` method of `CacheItem<T>` is used to check if the object is still valid based on its expiration time.
