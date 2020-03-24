using StudentHubApi1.Models;
using StudentHubApi1.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentHubApi1.Repositories.Interfaces
{
    public interface IImageRepository:IRepository<Image>
    {
        Task<bool> AddImageToSolution(List<ImageData> imageData,Guid QuestionId);
        Task<bool> AddImageToQuestion(List<ImageData> imageData,Guid SolutionId);
        
    }
}
