using Microsoft.EntityFrameworkCore;
using StudentHubApi1.Models;
using StudentHubApi1.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentHubApi1.Repositories.Implementation
{
    public class SolutionRepository:Repository<Solution>,ISolutionRepository
    {
        private readonly DbContext _dbContext;
        public SolutionRepository(DbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Solution> GetSolutionsWithImages()
        {
            return _dbContext.Solutions.Include(x => x.Images).ToList();
        }
    }
}
