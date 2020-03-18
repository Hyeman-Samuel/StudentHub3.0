using System;

namespace StudentHubApi1.Models
{
    public class QuestionTag
    {
        public Guid Id { get; set; }
        public Guid QuestionId { get; set; }
        public Question Question { get; set; }
        public Guid TagId { get; set; }
        public Tag Tag { get; set; }
    }
}