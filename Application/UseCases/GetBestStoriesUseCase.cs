using Domain.Entities;
using Domain.Interfaces.UseCases;
using Infrastructure.Services;

namespace Application.UseCases
{
    public class GetBestStoriesUseCase(IHackerNewsService _hackerNewsService) : IGetBestStoriesUseCase
    {
        private readonly IHackerNewsService hackerNewsService = _hackerNewsService;

        public async Task<List<Story>> Execute(int n)
        {
            var bestStories = await hackerNewsService.GetBestStoriesAsync(n);

            return bestStories;
        }
    }
}