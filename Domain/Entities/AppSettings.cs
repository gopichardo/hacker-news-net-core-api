using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class AppSettings
    {
        public string? BestStoryIdsCacheName { get; set; }
        public double CacheExpirationTimeMinutes { get; set; }
    }
}