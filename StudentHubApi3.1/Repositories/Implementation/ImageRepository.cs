using Microsoft.EntityFrameworkCore;
using StudentHubApi1.Models;
using StudentHubApi1.Models.ViewModel;
using StudentHubApi1.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentHubApi1.Repositories.Implementation
{
    public class ImageRepository :Repository<Image>,IImageRepository
    {
        private readonly DbContext _dbContext;
        public ImageRepository(DbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
        public async  Task<bool> AddImageToQuestion(List<ImageData> imageData,Guid QuestionId)
        {
            if (QuestionId == null ) {
                return false;
            }
            foreach (var item in imageData)
            {
                Image NewImage = new Image
                {
                    ImageLatex = item.ImageLatex,
                    ImageLink = item.ImageLink,
                    QuestionId = QuestionId
                };
                await _dbContext.Images.AddAsync(NewImage);
            }
           
            return true;
        }

        public async Task<bool> AddImageToSolution(List<ImageData> imageData,Guid SolutionId)
        {
            if (SolutionId == null)
            {
                return false;
            }
            foreach (var item in imageData)
            {
                Image NewImage = new Image
                {
                    ImageLatex = item.ImageLatex,
                    ImageLink = item.ImageLink,
                    SolutionId = SolutionId
                };
                await _dbContext.Images.AddAsync(NewImage);
            }
            return true;
        }

      
    }
}
