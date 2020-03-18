using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentHubApi1.Models
{
    public class Reaction
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public DateTime DateAdded { get; set; }
        public int Upvotes { get; set; }
        public int Flags { get; set; }
    }
}
