using Microsoft.Extensions.Caching.Memory;
using Seller.DailyReport.Domain.Interfaces.Services;

namespace Seller.DailyReport.Application.Services
{
    public class CacheService : ICacheService
    {
        private readonly IMemoryCache _memoryCache;

        public CacheService(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }
        public T? GetByKey<T>(string key)
        {
            if (_memoryCache.TryGetValue(key, out T? value))
                return value;

            return default;
        }

        public void Save(string key, object value)
        {
            var cacheEntryOptions = new MemoryCacheEntryOptions()
                .SetAbsoluteExpiration(TimeSpan.FromSeconds(30));

            _memoryCache.Set(key, value, cacheEntryOptions);
        }
    }
}
