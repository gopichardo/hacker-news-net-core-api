using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Interfaces.Services
{
    public interface IStoryService
    {
        /// <summary>
        /// Get the list of best stories
        /// </summary>
        /// <param name="n">Number of stories to return</param>
        /// <returns>List ob Stories</returns>
        Task<List<Story>> GetBestStoriesAsync(int n = 5);
    }
}