using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NetDevExtensions.ServiceAbstractions.Cache.Redis.Interfaces
{
    public interface IRedisRepository<T>
    {
        Task<T> GetAsync(string key);
        Task<bool> SetAsync(string key, T value, TimeSpan? expiry = null);
        Task<bool> RemoveAsync(string key);
        Task<IEnumerable<T>> GetAllAsync(string pattern = "*");
        Task<bool> SetAllAsync(Dictionary<string, T> keyValues, TimeSpan? expiry = null);
        Task<bool> RemoveAllAsync(IEnumerable<string> keys);
        Task<bool> KeyExistsAsync(string key);
        Task<long> IncrementAsync(string key, long value = 1);
        Task<long> DecrementAsync(string key, long value = 1);
        Task<IEnumerable<string>> SearchKeysAsync(string pattern);
    }
}