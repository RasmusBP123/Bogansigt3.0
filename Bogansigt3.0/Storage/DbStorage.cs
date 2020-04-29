using BogAnsigt.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

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

            var hasher = new PasswordHasher<User>();

            builder.Entity<User>().Ignore(user => user.TwoFactorEnabled)
                                   .Ignore(user => user.LockoutEnabled)
                                   .Ignore(user => user.LockoutEnd)
                                   .Ignore(user => user.PhoneNumberConfirmed)
                                   .Ignore(user => user.AccessFailedCount);


            builder.Entity<User>().HasData(new
            {
                Id = "a14280f8-d2b9-4598-8c89-c699cd1ab278",
                UserName = "admin@hotmail.com",
                NormalizedUserName = "ADMIN@HOTMAIL.COM",
                Email = "admin@hotmail.com",
                NormalizedEmail = "ADMIN@HOTMAIL.COM",
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "Admin123!"),
                SecurityStamp = "f4572cb1-6f71-46fd-8260-0baea7287367",
                ConcurrencyStamp = "bd5b9857-9d78-4f9d-81e3-28569973e0a2",
                PhoneNumber = "28929173",
                CreatedDate = new DateTime(2019, 08, 12)
            });

            base.OnModelCreating(builder);
        }
    }
}
