using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentHubApi1.Models
{
    public class Solution:Reaction
    {      
        public bool IsCorrect { get; set; }
        public List<Image> Images { get; set; }
        public List<Comment> Comments { get; set; }
        public Guid QuestionId { get; set; }
        public Question Question { get; set; }
    }
}
