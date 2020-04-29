using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BogAnsigt.Models
{
    public class UserPicture
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
        public string PictureId { get; set; }
        public Picture Picture { get; set; }
    }
}
