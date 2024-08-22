using System.Net.Http.Json;
using Domain.Entities;
using Domain.Interfaces.Clients;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace Infrastructure.Repositories
{
    public class HackerNewsClient(HttpClient _httpClient, IOptions<AppSettings> _options) : IHackerNewsClient
    {
        private readonly HttpClient httpClient = _httpClient;
        private readonly AppSettings appSettings = _options.Value;

        public async Task<List<int>> GetBestStoryIdsAsync()
        {
            var url = appSettings.HackerNewsApiUrl + appSettings.GetBestStoryIdsAsyncPath;
            var response = await httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();

            var storyIds = await response.Content.ReadFromJsonAsync<List<int>>();

            return storyIds!;
        }

        public async Task<StoryRepositoryDto> GetStoryDetailsAsync(int storyId)
        {
            var url = appSettings.HackerNewsApiUrl + appSettings.GetStoryDetailsAsyncPath;
            var response = await httpClient.GetAsync(url.Replace("id", storyId.ToString()));
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var story = JsonConvert.DeserializeObject<StoryRepositoryDto>(content);

            return story!;
        }
    }
}