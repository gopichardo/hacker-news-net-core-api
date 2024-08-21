using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Interfaces.Clients
{
    public interface IHackerNewsClient
    {

        Task<List<int>> GetBestStoryIdsAsync();
        Task<StoryRepositoryDto> GetStoryDetailsAsync(int storyId);
    }
}