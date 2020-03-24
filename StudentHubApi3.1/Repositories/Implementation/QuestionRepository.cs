using Microsoft.EntityFrameworkCore;
using StudentHubApi1.Models;
using StudentHubApi1.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentHubApi1.Repositories.Implementation
{
    public class QuestionRepository:Repository<Question>,IQuestionRepository
    {
        private readonly DbContext _dbContext;
        public QuestionRepository(DbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Question> GetAllQuestionsWithImages()
        {
            return _dbContext.Questions.Include(x => x.Image).ToList();

        }
    }
}
