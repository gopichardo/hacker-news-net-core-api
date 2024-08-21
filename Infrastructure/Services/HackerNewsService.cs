using Domain.Entities;
using Domain.Interfaces.Clients;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;

namespace Infrastructure.Services
{
    public class HackerNewsService(
        IHackerNewsClient _hackerNewsClient,
        ICacheService _cacheService,
        IOptions<AppSettings> _options,
        ITimeConverter _timeConverter
        ) : IHackerNewsService
    {
        private readonly IHackerNewsClient hackerNewsClient = _hackerNewsClient;
        private readonly ICacheService cacheService = _cacheService;
        private readonly AppSettings appSettings = _options.Value;
        private readonly ITimeConverter timeConverter = _timeConverter;

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

        private async Task<List<int>> GetBestStoryIdsAsync()
        {
            if (cacheService.TryGetValue<List<int>>(appSettings.BestStoryIdsCacheName!, out var storyIds))
            {
                return storyIds!;
            }

            storyIds = await hackerNewsClient.GetBestStoryIdsAsync();

            cacheService.SetCache<List<int>>(appSettings.BestStoryIdsCacheName!, storyIds, appSettings.CacheExpirationTimeMinutes);

            return storyIds!;
        }

        private async Task<Story> GetCacheStoryDetailsAsync(int storyId)
        {
            var storyCacheName = $"story_{storyId}";

            if (cacheService.TryGetValue<Story>(storyCacheName, out var story))
            {
                return story!;
            }

            var storyRepositoryDto = await hackerNewsClient.GetStoryDetailsAsync(storyId);

            story = new Story
            {
                title = storyRepositoryDto.title,
                uri = storyRepositoryDto.uri,
                postedBy = storyRepositoryDto.postedBy,
                time = timeConverter.DateTimeToString(storyRepositoryDto.timeUnix),
                score = storyRepositoryDto.score,
                commentCount = storyRepositoryDto.kids?.Count ?? 0
            };

            cacheService.SetCache<Story>(storyCacheName, story, appSettings.CacheExpirationTimeMinutes);

            return story!;
        }
    }
}