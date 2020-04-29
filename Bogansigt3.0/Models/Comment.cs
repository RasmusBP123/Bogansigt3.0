using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BogAnsigt.Models
{
    public class Comment
    {
        public string Id { get; set; }
        public string CommentText { get; set; }
        public User Author { get; set; }
        public DateTime Created { get; set; }
    }
}
