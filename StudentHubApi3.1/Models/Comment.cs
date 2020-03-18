using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentHubApi1.Models
{
    public class Comment:Reaction
    {       
        public Guid? SolutionId { get; set; }
        public Solution Solution { get; set; }
        public Guid? QuestionId { get; set; }
        public Question Question { get; set; }
    }
}
