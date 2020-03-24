using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentHubApi1.Models
{
    public class Question
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DateAdded { get; set; }
        public Guid CategoryId { get; set; }
        public Category Category { get; set; }

        public int UpVotes { get; set; }
        public int DownVotes { get; set; }
        public int Saves { get; set; }
        public int Flags { get; set; }
        public List<Solution> Solutions { get; set; }
        public List<Comment> Comments { get; set; }
        public List<QuestionTag> Tags { get; set; }
        public List<Image> Image { get; set; }
    }
}
