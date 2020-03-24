using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentHubApi1.Models.ViewModel
{
    public class QuestionData
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DateAdded { get; set; }
        public Guid CategoryId { get; set; }
        public List<ImageData> Images { get; set; }
    }
}
