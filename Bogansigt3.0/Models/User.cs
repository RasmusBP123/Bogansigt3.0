using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

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
