using Domain.Entities;
using Domain.Interfaces.Clients;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;

namespace Infrastructure.Services
{
    public class HackerNewsService(IHackerNewsClient _hackerNewsClient, IMemoryCache _cache, IOptions<AppSettings> _options) : IHackerNewsService
    {
        private readonly IHackerNewsClient hackerNewsClient = _hackerNewsClient;
        private readonly IMemoryCache cache = _cache;
        private readonly AppSettings appSettings = _options.Value;

        public async Task<List<Story>> GetBestStoriesAsync(int n = 5)
        {
            var storyIds = await GetBestStoryIdsAsync();

            var asyncTasks = new List<Task<Story>>();

            storyIds.ForEach(id => asyncTasks.Add(GetCacheStoryDetailsAsync(id)));

            var tasksResult = await Task.WhenAll(asyncTasks);

            var stories = tasksResult.ToList()
                .OrderByDescending(story => story.score)
                .Take(n).ToList();

            return stories;
        }

        public async Task<List<int>> GetBestStoryIdsAsync()
        {
            if (cache.TryGetValue<List<int>>(appSettings.BestStoryIdsCacheName!, out var storyIds))
            {
                return storyIds!;
            }

            storyIds = await hackerNewsClient.GetBestStoryIdsAsync();

            SetCache<List<int>>(appSettings.BestStoryIdsCacheName!, storyIds);

            return storyIds!;
        }

        private async Task<Story> GetCacheStoryDetailsAsync(int storyId)
        {
            var storyCacheName = $"story_{storyId}";

            if (cache.TryGetValue<Story>(storyCacheName, out var story))
            {
                return story!;
            }
            story = await hackerNewsClient.GetStoryDetailsAsync(storyId);

            SetCache<Story>(storyCacheName, story);

            return story!;
        }

        private void SetCache<T>(string key, T items)
        {
            var expirationTime = DateTimeOffset.Now.AddMinutes(appSettings.CacheExpirationTimeMinutes);
            cache.Set(key, items, expirationTime);
        }
    }
}