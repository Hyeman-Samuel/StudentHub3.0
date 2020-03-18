using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentHubApi1.Models
{
    public class Image
    {
        public Guid Id { get; set; }
        public string ImageLatex { get; set; }
        public string ImageLink { get; set; }
        public Guid? QuestionId { get; set; }
        public Question Question { get; set; }
        public Guid? SolutionId { get; set; }
        public Solution Solution { get; set; }
    }
}
