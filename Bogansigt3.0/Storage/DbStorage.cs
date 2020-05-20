using BogAnsigt.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace BogAnsigt.Storage
{
    public class DbStorage : IdentityDbContext<User>
    {
        public DbStorage(DbContextOptions<DbStorage> options) : base(options)
        {
            //Database.Migrate();
        }

        public DbSet<Picture> Picture { get; set; }
        public DbSet<Comment> Comment { get; set; }
        public DbSet<UserPicture> UserPictures { get; set; }
        public DbSet<UserFriend> UserFriends { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            base.OnModelCreating(builder);

            var hasher = new PasswordHasher<User>();

            builder.Entity<User>().Ignore(user => user.TwoFactorEnabled)
                                   .Ignore(user => user.LockoutEnabled)
                                   .Ignore(user => user.LockoutEnd)
                                   .Ignore(user => user.PhoneNumberConfirmed)
                                   .Ignore(user => user.AccessFailedCount);

            const string ADMIN_ID = "a14280f8-d2b9-4598-8c89-c699cd1ab278";
            const string ADMIN_ROLE_ID = "FA02B864-ECE7-45E4-9A03-6023AF206756";
            const string USER_ROLE_ID = "0BFBD470-5DC8-4CD2-93FE-88049B3D9E99";

            builder.Entity<User>().HasData(new
            {
                Id = ADMIN_ID,
                UserName = "admin@hotmail.com",
                NormalizedUserName = "ADMIN@HOTMAIL.COM",
                Email = "admin@hotmail.com",
                NormalizedEmail = "ADMIN@HOTMAIL.COM",
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "admin!"),
                SecurityStamp = "f4572cb1-6f71-46fd-8260-0baea7287367",
                ConcurrencyStamp = "bd5b9857-9d78-4f9d-81e3-28569973e0a2",
                PhoneNumber = "28929173",
                CreatedDate = new DateTime(2019, 08, 12)
            });

            builder.Entity<IdentityRole>().HasData(
                new IdentityRole { Id = ADMIN_ROLE_ID, Name = "User", NormalizedName = "USER" },
                new IdentityRole { Id = USER_ROLE_ID, Name = "Admin", NormalizedName = "ADMIN" }
            );

            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string> { RoleId = ADMIN_ROLE_ID, UserId = ADMIN_ID },
                new IdentityUserRole<string> { RoleId = USER_ROLE_ID, UserId = ADMIN_ID }
            );
            base.OnModelCreating(builder);
            builder.Entity<UserFriend>().HasKey(aue => new { aue.UserId, aue.FriendId });
            builder.Entity<UserFriend>().HasOne(aue => aue.User).WithMany(e => e.Friends).HasForeignKey(aue => aue.UserId).OnDelete(DeleteBehavior.ClientSetNull);
            builder.Entity<UserFriend>().HasOne(aue => aue.Friend).WithMany(e => e.Friends2).HasForeignKey(aue => aue.FriendId);


        }
    }
}
