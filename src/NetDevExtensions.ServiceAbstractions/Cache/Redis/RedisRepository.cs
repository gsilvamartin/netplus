using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NetDevExtensions.ServiceAbstractions.Cache.Redis.Interfaces;
using Newtonsoft.Json;
using StackExchange.Redis;

namespace NetDevExtensions.ServiceAbstractions.Cache.Redis
{
    /// <summary>
    /// Repository for storing and retrieving objects in Redis cache.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <inheritdoc/>
    public class RedisRepository<T> : IRedisRepository<T> where T : class
    {
        private readonly IDatabase _database;

        public RedisRepository(IDatabase database)
        {
            _database = database ?? throw new ArgumentNullException(nameof(database));
        }

        public async Task<T> GetAsync(string key)
        {
            var value = await _database.StringGetAsync(key);
            return value.HasValue ? JsonConvert.DeserializeObject<T>(value) : null;
        }

        public async Task<bool> SetAsync(string key, T value, TimeSpan? expiry = null)
        {
            var serializedValue = JsonConvert.SerializeObject(value);
            return await _database.StringSetAsync(key, serializedValue, expiry);
        }

        public async Task<bool> RemoveAsync(string key)
        {
            return await _database.KeyDeleteAsync(key);
        }

        public async Task<IEnumerable<T>> GetAllAsync(string pattern = "*")
        {
            var keys = await SearchKeysAsync(pattern);
            var values = await _database.StringGetAsync(keys.Select(k => (RedisKey)k).ToArray());
            return values.Select(value => JsonConvert.DeserializeObject<T>(value)).ToList();
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

        public async Task<bool> KeyExistsAsync(string key)
        {
            return await _database.KeyExistsAsync(key);
        }

        public async Task<long> IncrementAsync(string key, long value = 1)
        {
            return await _database.StringIncrementAsync(key, value);
        }

        public async Task<long> DecrementAsync(string key, long value = 1)
        {
            return await _database.StringDecrementAsync(key, value);
        }

        public Task<IEnumerable<string>> SearchKeysAsync(string pattern)
        {
            var endpoints = _database.Multiplexer.GetEndPoints();
            var server = _database.Multiplexer.GetServer(endpoints.First());

            var keys = server.Keys(_database.Database, pattern ?? "*", 1000);
            return Task.FromResult<IEnumerable<string>>(keys.Select(key => (string)key!).ToList());
        }
    }
}