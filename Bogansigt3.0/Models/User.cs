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
            Friends = new List<User>();
        }
        public List<User> Friends { get; set; }
        public List<UserPicture> Pictures { get; set; }
    }
}
