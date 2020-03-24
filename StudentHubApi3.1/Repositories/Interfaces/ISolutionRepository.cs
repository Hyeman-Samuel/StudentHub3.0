using StudentHubApi1.Models;
using StudentHubApi1.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentHubApi1.Repositories.Interfaces
{
    public interface ISolutionRepository:IRepository<Solution>
    {
        IEnumerable<Solution> GetSolutionsWithImages();
    }
}
