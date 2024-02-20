using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NetPlus.ServiceAbstractions.Cache.Memory.Interfaces;

namespace NetPlus.ServiceAbstractions.Cache.Memory
{
    /// <summary>
    /// Memory Cache Repository for storing and retrieving objects in-memory.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <inheritdoc/>
    public class MemoryCacheRepository<T> : IMemoryCacheRepository<T> where T : class
    {
        private readonly ConcurrentDictionary<string, CacheItem<T>> _cache =
            new ConcurrentDictionary<string, CacheItem<T>>();

        public async Task<T> GetAsync(string key)
        {
            if (_cache.TryGetValue(key, out var cacheItem) && cacheItem.IsValid())
                return await Task.FromResult(cacheItem.Value);

            return default!;
        }

        public async Task<bool> SetAsync(string key, T value, TimeSpan? expiry = null)
        {
            var expiryDateTime = expiry.HasValue ? DateTime.UtcNow.Add(expiry.Value) : DateTime.MaxValue;
            var cacheItem = new CacheItem<T>(value, expiryDateTime);
            _cache[key] = cacheItem;

            return await Task.FromResult(true);
        }

        public async Task<bool> RemoveAsync(string key)
        {
            _cache.TryRemove(key, out _);
            return await Task.FromResult(true);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            var values = _cache.Values
                .Where(cacheItem => cacheItem.IsValid())
                .Select(cacheItem => cacheItem.Value)
                .ToList();

            return await Task.FromResult(values);
        }

        public async Task<bool> SetAllAsync(Dictionary<string, T> keyValues, TimeSpan? expiry = null)
        {
            var tasks = keyValues.Select(kv => SetAsync(kv.Key, kv.Value, expiry));
            return (await Task.WhenAll(tasks)).All(result => result);
        }

        public async Task<bool> RemoveAllAsync(IEnumerable<string> keys)
        {
            var tasks = keys.Select(RemoveAsync);
            return (await Task.WhenAll(tasks)).All(result => result);
        }

        public Task<bool> KeyExistsAsync(string key)
        {
            return Task.FromResult(_cache.TryGetValue(key, out var cacheItem) && cacheItem.IsValid());
        }

        private class CacheItem<TValue>
        {
            public TValue Value { get; }
            private DateTime Expiry { get; }

            public CacheItem(TValue value, DateTime expiry)
            {
                Value = value;
                Expiry = expiry;
            }

            public bool IsValid()
            {
                return DateTime.UtcNow < Expiry;
            }
        }
    }
}