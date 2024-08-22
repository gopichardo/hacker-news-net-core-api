using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class AppSettings
    {
        public required string BestStoryIdsCacheName { get; set; }
        public required double CacheExpirationTimeMinutes { get; set; }
        public required string DateFormat { get; set; }
        public required string HackerNewsApiUrl { get; set; }
        public required string GetBestStoryIdsAsyncPath { get; set; }
        public required string GetStoryDetailsAsyncPath { get; set; }
    }
}