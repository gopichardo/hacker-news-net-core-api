using System.Net.Http.Json;
using Domain.Entities;
using Domain.Interfaces.Clients;
using Newtonsoft.Json;

namespace Infrastructure.Repositories
{
    public class HackerNewsClient(HttpClient _httpClient) : IHackerNewsClient
    {
        private readonly HttpClient httpClient = _httpClient;



        public async Task<List<int>> GetBestStoryIdsAsync()
        {
            var response = await httpClient.GetAsync("https://hacker-news.firebaseio.com/v0/beststories.json");
            response.EnsureSuccessStatusCode();

            var storyIds = await response.Content.ReadFromJsonAsync<List<int>>();

            return storyIds!;
        }

        public async Task<StoryRepositoryDto> GetStoryDetailsAsync(int storyId)
        {
            var response = await httpClient.GetAsync($"https://hacker-news.firebaseio.com/v0/item/{storyId}.json");
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var story = JsonConvert.DeserializeObject<StoryRepositoryDto>(content);

            return story!;
        }
    }
}