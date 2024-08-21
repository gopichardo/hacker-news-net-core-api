using Domain.Entities;
using Domain.Interfaces.Services;
using Domain.Interfaces.UseCases;

namespace Application.UseCases
{
    public class GetBestStoriesUseCase(IStoryService _storyService) : IGetBestStoriesUseCase
    {
        private readonly IStoryService storyService = _storyService;

        public Task<List<Story>> Execute(int n)
        {
            var stories = storyService.GetBestStoriesAsync(n);
            return stories;
        }
    }
}