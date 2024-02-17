using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NetDevExtensions.ServiceAbstractions.Cache.Memory.Interfaces
{
    public interface IMemoryCacheRepository<T>
    {
        Task<T> GetAsync(string key);
        Task<bool> SetAsync(string key, T value, TimeSpan? expiry = null);
        Task<bool> RemoveAsync(string key);
        Task<IEnumerable<T>> GetAllAsync();
        Task<bool> KeyExistsAsync(string key);
    }
}