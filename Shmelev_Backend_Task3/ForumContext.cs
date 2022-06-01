using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Shmelev_Backend_Task3
{
    public class ForumContext : IdentityDbContext
    {
        public ForumContext(DbContextOptions options) : base(options)
        {
        }


        public DbSet<Board> Boards { get; set; }
        public DbSet<Thread> Threads { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Attachment> Attachments { get; set; }
        public DbSet<ModeratedBoard> ModeratedBoards { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Board>()
                .HasMany(x => x.Threads)
                .WithOne(x => x.Board)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Thread>()
                .HasMany(x => x.Posts)
                .WithOne(x => x.Thread)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Post>()
                .HasMany(x => x.Attachments)
                .WithOne(x => x.Post)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ModeratedBoard>()
                .HasOne(x => x.Board)
                .WithOne(x => x.ModeratedBoard)
                .HasForeignKey<ModeratedBoard>(x=>x.BoardId);


            modelBuilder.Entity<ForumUser>()
                .HasMany(x => x.AuthoredThreads)
                .WithOne(x => x.Author);

            modelBuilder.Entity<ForumUser>()
                .HasMany(x => x.AuthoredPosts)
                .WithOne(x => x.Author);

            modelBuilder.Entity<ForumUser>()
                .HasMany(x => x.ModeratedBoards)
                .WithMany(x => x.Moderators);



            // seed roles

            string admID = null;

            foreach (var role in Shmelev_Backend_Task3.Roles.RolesList)
            {
                var gid = Guid.NewGuid().ToString();
                modelBuilder.Entity<IdentityRole>()
                    .HasData(new IdentityRole()
                    {
                        Id = gid,
                        Name = role,
                        NormalizedName = role.ToUpper()

                    });

                if (role == "Admin")
                    admID = gid;
            }

            // seed admin

            var adm = new ForumUser()
            {
                Id="1",
                UserName = "admin@admin.ru",
                NormalizedUserName = "ADMIN@ADMIN.RU",
                NormalizedEmail = "ADMIN@ADMIN.RU",
                Email = "admin@admin.ru",
                EmailConfirmed = true,

            };

            // password hashing :)
            PasswordHasher<ForumUser> hasher = new PasswordHasher<ForumUser>();

            adm.PasswordHash = hasher.HashPassword(adm, "Admin123!");




            modelBuilder.Entity<ForumUser>()
                .HasData(adm);


            // assign the role

            modelBuilder.Entity<IdentityUserRole<string>>()
                .HasData(new IdentityUserRole<string>()
                {
                    RoleId = admID,
                    UserId = "1"// TODO: linking between roles for admin
                });
        }
    }
}
