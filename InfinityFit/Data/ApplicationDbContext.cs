using InfinityFit.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace InfinityFit.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Badge> Badges { get; set; }
        public DbSet<UserBadge> UserBadges { get; set; }

        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Like> Likes { get; set; }

    

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Appreciation → Post
            builder.Entity<Like>()
                .HasOne(a => a.Post)
                .WithMany(p => p.Likes)
                .HasForeignKey(a => a.PostId)
                .OnDelete(DeleteBehavior.Restrict);

            // Comment → Post
            builder.Entity<Comment>()
                .HasOne(c => c.Post)
                .WithMany(p => p.Comments)
                .HasForeignKey(c => c.PostId)
                .OnDelete(DeleteBehavior.Restrict);

             builder.Entity<Like>()
                .HasIndex(l => new { l.UserId, l.PostId })
                .IsUnique();

            // UserBadge → Badge
            builder.Entity<UserBadge>()
                .HasOne(ub => ub.Badge)
                .WithMany(b => b.UserBadges)
                .HasForeignKey(ub => ub.BadgeId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Badge>().HasData(
                new Badge
                {
                    Id = Guid.Parse("11111111-1111-1111-1111-111111111111"),
                    Name = "Welcome",
                    Description = "Ți-ai creat contul", // badge pentru toți userii
                    Icon = "/images/1.png"
                },
                new Badge
                {
                    Id = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                    Name = "First Post",
                    Description = "Ai făcut prima ta postare",
                    Icon = "/images/2.png" // dacă vrei emoji
                },
                new Badge
                {
                    Id = Guid.Parse("33333333-3333-3333-3333-333333333333"),
                    Name = "Traveler",
                    Description = "Ai făcut 5 postări",
                    Icon = "/images/3.png"
                },
                new Badge
                {
                    Id = Guid.Parse("44444444-4444-4444-4444-444444444444"),
                    Name = "Explorer",
                    Description = "Ai făcut 20 de postări",
                    Icon = "/images/4.png"
                }
            );

           
        }
    }
}
