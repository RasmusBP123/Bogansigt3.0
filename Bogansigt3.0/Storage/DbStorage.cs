using BogAnsigt.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BogAnsigt.Storage
{
    public class DbStorage : IdentityDbContext<User>
    {
        public DbStorage(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Picture> Picture { get; set; }
        public DbSet<Comment> Comment { get; set; }
        public DbSet<UserPicture> UserPictures { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
