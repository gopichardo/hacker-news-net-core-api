using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class AppSettings
    {
        public required string BestStoryIdsCacheName { get; set; }
        public required int CacheExpirationTimeMinutes { get; set; }
        public required string DateFormat { get; set; }
    }
}