using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;

namespace Infrastructure.Services
{
    public class CacheService(IMemoryCache _cache) : ICacheService
    {
        private readonly IMemoryCache cache = _cache;

        public bool TryGetValue<T>(string key, out T value)
        {
            return cache.TryGetValue(key, out value!);
        }

        public void SetCache<T>(string key, T value, int expirationMinutes)
        {
            var expirationTime = DateTimeOffset.Now.AddMinutes(expirationMinutes);
            cache.Set(key, value, expirationTime);
        }
    }
}