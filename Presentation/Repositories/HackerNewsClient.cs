using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces.Clients;
using Newtonsoft.Json;

namespace Repositories
{
    public class HackerNewsClient(HttpClient _httpClient) : IHackerNewsClient
    {
        private readonly HttpClient httpClient = _httpClient;

        public async Task<int[]> GetBestStoryIdsAsync()
        {
            var response = await httpClient.GetAsync("https://hacker-news.firebaseio.com/v0/beststories.json");
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var storiesId = JsonConvert.DeserializeObject<int[]>(content);

            return storiesId!;
        }

        public async Task<Story> GetStoryDetailsAsync(int storyId)
        {
            var response = await httpClient.GetAsync($"https://hacker-news.firebaseio.com/v0/item/{storyId}.json");
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var story = JsonConvert.DeserializeObject<Story>(content);

            return story!;
        }
    }
}