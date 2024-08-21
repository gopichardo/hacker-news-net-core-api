using System.Collections;
using Domain.Entities;
using Domain.Interfaces.UseCases;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/besthistories")]
    public class BestStoriesController : ControllerBase
    {
        private readonly IGetBestStoriesUseCase getBestStoriesUseCase;
        public BestStoriesController(IGetBestStoriesUseCase _getBestStoriesUseCase)
        {
            getBestStoriesUseCase = _getBestStoriesUseCase;
        }

        /// <summary>
        /// Get the best stories
        /// </summary>
        /// <param name="n">Number of stories to get</param>
        /// <returns>Stories list</returns>
        [HttpGet("{n}")]
        public async Task<ActionResult<List<Story>>> Get(int n = 5)
        {

            var result = await getBestStoriesUseCase.Execute(n);

            return result;
        }
    }
}