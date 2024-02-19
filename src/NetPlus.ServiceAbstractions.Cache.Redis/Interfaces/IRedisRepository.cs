using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NetPlus.ServiceAbstractions.Cache.Redis.Interfaces;

/// <summary>
/// Interface for Redis Repository providing methods for storing and retrieving objects in Redis cache.
/// </summary>
/// <typeparam name="T">The type of objects to be stored and retrieved.</typeparam>
public interface IRedisRepository<T>
{
    /// <summary>
    /// Retrieves an object from the Redis cache asynchronously based on the specified key.
    /// </summary>
    /// <param name="key">The unique identifier for the object in the Redis cache.</param>
    /// <returns>A task representing the asynchronous operation and containing the retrieved object, or null if not found.</returns>
    Task<T> GetAsync(string key);

    /// <summary>
    /// Stores an object in the Redis cache asynchronously with the specified key.
    /// </summary>
    /// <param name="key">The unique identifier for the object in the Redis cache.</param>
    /// <param name="value">The object to be stored in the Redis cache.</param>
    /// <param name="expiry">The optional expiration time for the stored object in the Redis cache. If null, the object won't expire.</param>
    /// <returns>A task representing the asynchronous operation and containing a boolean indicating if the object was successfully stored.</returns>
    Task<bool> SetAsync(string key, T value, TimeSpan? expiry = null);

    /// <summary>
    /// Removes an object from the Redis cache asynchronously based on the specified key.
    /// </summary>
    /// <param name="key">The unique identifier for the object in the Redis cache.</param>
    /// <returns>A task representing the asynchronous operation and containing a boolean indicating if the object was successfully removed.</returns>
    Task<bool> RemoveAsync(string key);

    /// <summary>
    /// Retrieves all objects stored in the Redis cache asynchronously based on a pattern.
    /// </summary>
    /// <param name="pattern">The pattern to match keys in the Redis cache (default is "*").</param>
    /// <returns>A task representing the asynchronous operation and containing the collection of all objects stored in the Redis cache matching the specified pattern.</returns>
    Task<IEnumerable<T>> GetAllAsync(string pattern = "*");

    /// <summary>
    /// Stores multiple objects in the Redis cache asynchronously with specified keys.
    /// </summary>
    /// <param name="keyValues">A dictionary containing key-value pairs where each key is a unique identifier in the Redis cache and the corresponding value is the object to be stored.</param>
    /// <param name="expiry">The optional expiration time for the stored objects in the Redis cache. If null, the objects won't expire.</param>
    /// <returns>A task representing the asynchronous operation and containing a boolean indicating if the objects were successfully stored.</returns>
    Task<bool> SetAllAsync(Dictionary<string, T> keyValues, TimeSpan? expiry = null);

    /// <summary>
    /// Removes multiple objects from the Redis cache asynchronously based on specified keys.
    /// </summary>
    /// <param name="keys">A collection of unique identifiers for objects to be removed from the Redis cache.</param>
    /// <returns>A task representing the asynchronous operation and containing a boolean indicating if the objects were successfully removed.</returns>
    Task<bool> RemoveAllAsync(IEnumerable<string> keys);

    /// <summary>
    /// Checks if an object with the specified key exists in the Redis cache asynchronously.
    /// </summary>
    /// <param name="key">The unique identifier for the object in the Redis cache.</param>
    /// <returns>A task representing the asynchronous operation and containing a boolean indicating if the object with the specified key exists in the Redis cache.</returns>
    Task<bool> KeyExistsAsync(string key);

    /// <summary>
    /// Increments the value stored at the specified key in the Redis cache asynchronously.
    /// </summary>
    /// <param name="key">The unique identifier for the object in the Redis cache.</param>
    /// <param name="value">The value to increment the existing value by (default is 1).</param>
    /// <returns>A task representing the asynchronous operation and containing the incremented value.</returns>
    Task<long> IncrementAsync(string key, long value = 1);

    /// <summary>
    /// Decrements the value stored at the specified key in the Redis cache asynchronously.
    /// </summary>
    /// <param name="key">The unique identifier for the object in the Redis cache.</param>
    /// <param name="value">The value to decrement the existing value by (default is 1).</param>
    /// <returns>A task representing the asynchronous operation and containing the decremented value.</returns>
    Task<long> DecrementAsync(string key, long value = 1);

    /// <summary>
    /// Searches for keys in the Redis cache asynchronously based on a pattern.
    /// </summary>
    /// <param name="pattern">The pattern to match keys in the Redis cache.</param>
    /// <returns>A task representing the asynchronous operation and containing a collection of keys matching the specified pattern.</returns>
    Task<IEnumerable<string>> SearchKeysAsync(string pattern);
}