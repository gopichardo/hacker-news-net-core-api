using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace Infrastructure.Services
{
    public interface IHackerNewsService
    {
        /// <summary>
        /// Get the list of best stories
        /// </summary>
        /// <param name="n">Number of stories to return</param>
        /// <returns>List of Stories</returns>
        Task<List<Story>> GetBestStoriesAsync(int n = 5);

        /// <summary>
        /// Get the details of a story
        /// </summary>
        /// <returns>List of Stories Ids </returns>
        Task<List<int>> GetBestStoryIdsAsync();
    }
}