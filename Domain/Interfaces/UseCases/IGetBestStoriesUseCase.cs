using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Interfaces.UseCases
{
    public interface IGetBestStoriesUseCase
    {
        /// <summary>
        /// Execute Use Case to return the best stories
        /// </summary>
        /// <param name="n"> Number of stories to return</param>
        /// <returns>List of stories</returns>
        Task<List<Story>> Execute(int n);
    }
}