using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace BogAnsigt.Models
{
    public class User : IdentityUser
    {
        public List<User> Friends { get; set; }
        public List<UserPicture> Pictures { get; set; }
    }
}
