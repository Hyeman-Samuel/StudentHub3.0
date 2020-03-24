using StudentHubApi1.Models;
using StudentHubApi1.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentHubApi1.Repositories.Implementation
{
    public class ReactionRepository:Repository<Reaction>,IReactionRepository
    {
        private readonly DbContext _dbContext;
        public ReactionRepository(DbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }


    }
}
