using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NetPlus.ServiceAbstractions.Cache.Memory.Interfaces
{
    /// <summary>
    /// Memory Cache Repository Interface for storing and retrieving objects in-memory.
    /// </summary>
    /// <typeparam name="T">The type of objects to be stored and retrieved.</typeparam>
    public interface IMemoryCacheRepository<T>
    {
        /// <summary>
        /// Retrieves an object from the memory cache asynchronously based on the specified key.
        /// </summary>
        /// <param name="key">The unique identifier for the object in the memory cache.</param>
        /// <returns>A task representing the asynchronous operation and containing the retrieved object, or null if not found.</returns>
        Task<T> GetAsync(string key);

        /// <summary>
        /// Stores an object in the memory cache asynchronously with the specified key.
        /// </summary>
        /// <param name="key">The unique identifier for the object in the memory cache.</param>
        /// <param name="value">The object to be stored in the memory cache.</param>
        /// <param name="expiry">The optional expiration time for the stored object in the memory cache. If null, the object won't expire.</param>
        /// <returns>A task representing the asynchronous operation and containing a boolean indicating if the object was successfully stored.</returns>
        Task<bool> SetAsync(string key, T value, TimeSpan? expiry = null);

        /// <summary>
        /// Removes an object from the memory cache asynchronously based on the specified key.
        /// </summary>
        /// <param name="key">The unique identifier for the object in the memory cache.</param>
        /// <returns>A task representing the asynchronous operation and containing a boolean indicating if the object was successfully removed.</returns>
        Task<bool> RemoveAsync(string key);

        /// <summary>
        /// Retrieves all objects stored in the memory cache asynchronously.
        /// </summary>
        /// <returns>A task representing the asynchronous operation and containing the collection of all objects stored in the memory cache.</returns>
        Task<IEnumerable<T>> GetAllAsync();

        /// <summary>
        /// Checks if an object with the specified key exists in the memory cache asynchronously.
        /// </summary>
        /// <param name="key">The unique identifier for the object in the memory cache.</param>
        /// <returns>A task representing the asynchronous operation and containing a boolean indicating if the object with the specified key exists in the memory cache.</returns>
        Task<bool> KeyExistsAsync(string key);
    }
}