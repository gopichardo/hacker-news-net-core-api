using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces.Clients;
using Domain.Interfaces.Services;

namespace Application.Services
{
    public class StoryService(IHackerNewsClient _HackerNewsClient) : IStoryService
    {
        private readonly IHackerNewsClient HackerNewsClient = _HackerNewsClient;

        public async Task<List<Story>> GetBestStoriesAsync(int n = 5)
        {
            var allStories = await HackerNewsClient.GetBestStoryIdsAsync();

            var asyncTasks = new List<Task<Story>>();

            allStories.ToList<int>().ForEach(id => asyncTasks.Add(HackerNewsClient.GetStoryDetailsAsync(id)));

            var tasksResult = await Task.WhenAll(asyncTasks);

            // Filter the retrieved IDs to only get the first n IDs.
            // Sort by Score
            var filteredStories = tasksResult.ToList().OrderByDescending(story => story.score)
                .Take(n);

            return [.. filteredStories];
        }
    }
}