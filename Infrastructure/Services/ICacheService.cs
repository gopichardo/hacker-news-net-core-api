using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public interface ICacheService
    {
        /// <summary>
        /// Get the value from the cache
        /// </summary>
        /// <typeparam name="T">Type of the value</typeparam>
        /// <param name="key">Key of the value</param>
        /// <param name="value">Value of the cache key</param>
        /// <returns>Cached value</returns>
        bool TryGetValue<T>(string key, out T value);

        /// <summary>
        /// Set the value in the cache
        /// </summary>
        /// <typeparam name="T">Type of the value</typeparam>
        /// <param name="key">Key of the value</param>
        /// <param name="value">Value to set</param>
        /// <param name="expirationMinutes">Expiration time in minutes</param>
        void SetCache<T>(string key, T value, int expirationMinutes);
    }
}