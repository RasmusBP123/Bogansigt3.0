using System.Collections.Generic;

namespace BogAnsigt.Models
{
    public class Picture
    {
        public string Id { get; set; }
        public List<Comment> Comments { get; set; }
        public List<UserPicture> AllowedFriends { get; set; }
        public byte[] PictureBytes { get; set; }
    }
}
