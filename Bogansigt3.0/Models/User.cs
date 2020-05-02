using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BogAnsigt.Models
{
    public class User : IdentityUser
    {
        public User()
        {
            Friends = new List<UserFriend>();
            Friends2 = new List<UserFriend>();
        }
        public List<UserFriend> Friends { get; set; }
        public List<UserFriend> Friends2 { get; set; }
        public List<UserPicture> Pictures { get; set; }
    }
}
