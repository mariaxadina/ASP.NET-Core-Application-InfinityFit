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
        public DbSet<LeaderboardEntry> LeaderboardEntries { get; set; }

        public DbSet<DailyLocation> DailyLocations { get; set; }

        public DbSet<DailyQuizPlay> DailyQuizPlays { get; set; }
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

            builder.Entity<LeaderboardEntry>()
                 .HasOne(le => le.User)
                 .WithMany()
                 .HasForeignKey(le => le.UserId)
                 .OnDelete(DeleteBehavior.Cascade);


            // UserBadge → Badge
            builder.Entity<UserBadge>()
                .HasOne(ub => ub.Badge)
                .WithMany(b => b.UserBadges)
                .HasForeignKey(ub => ub.BadgeId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Badge>().HasData(

                // ---------BADGE-URI POSTARI------------
                new Badge
                {
                    Id = Guid.Parse("10000000-0000-0000-0000-000000000000"),
                    Name = "Welcome",
                    Description = "You have created your account!", // badge pentru toți userii
                    Icon = "/images/welcome.png"
                },
                new Badge
                {
                    Id = Guid.Parse("10000000-0000-0000-0000-000000000001"),
                    Name = "First Post",
                    Description = "You posted for the first time",
                    Icon = "/images/post1.png" // dacă vrei emoji
                },
                new Badge
                {
                    Id = Guid.Parse("10000000-0000-0000-0000-000000000005"),
                    Name = "Traveler",
                    Description = "You made 5 posts",
                    Icon = "/images/post5.png"
                },
                new Badge
                {
                    Id = Guid.Parse("10000000-0000-0000-0000-000000000020"),
                    Name = "Explorer",
                    Description = "You made 20 posts",
                    Icon = "/images/post20.png"
                },
                new Badge
                {
                    Id = Guid.Parse("10000000-0000-0000-0000-000000000050"),
                    Name = "Adventurer",
                    Description = "You made 50 posts",
                    Icon = "/images/post50.png"
                },
                new Badge
                {
                    Id = Guid.Parse("10000000-0000-0000-0000-000000000100"),
                    Name = "Storyteller",
                    Description = "You made 100 posts",
                    Icon = "/images/post100.png"
                },
                new Badge
                {
                    Id = Guid.Parse("10000000-0000-0000-0000-000000000250"),
                    Name = "Content Creator",
                    Description = "You made 250 posts",
                    Icon = "/images/post250.png"
                },
                new Badge
                {
                    Id = Guid.Parse("10000000-0000-0000-0000-000000000500"),
                    Name = "Master Explorer",
                    Description = "You made 500 posts",
                    Icon = "/images/post500.png"
                },
                new Badge
                {
                    Id = Guid.Parse("10000000-0000-0000-0000-000000001000"),
                    Name = "Legendary Poster",
                    Description = "You made 1,000 posts",
                    Icon = "/images/post1000.png"
                },



                // ---------BADGE-URI LEVEL------------
                new Badge
                {
                    Id = Guid.Parse("20000000-0000-0000-0000-000000000005"),
                    Name = "Getting Started",
                    Description = "Reached level 5",
                    Icon = "/images/level5.png"
                },
                new Badge
                {
                    Id = Guid.Parse("20000000-0000-0000-0000-000000000010"),
                    Name = "Rising Star",
                    Description = "Reached level 10",
                    Icon = "/images/level10.png"
                },
                new Badge
                {
                    Id = Guid.Parse("20000000-0000-0000-0000-000000000020"),
                    Name = "Challenger",
                    Description = "Reached level 20",
                    Icon = "/images/level20.png"
                },
                new Badge
                {
                    Id = Guid.Parse("20000000-0000-0000-0000-000000000050"),
                    Name = "Veteran Explorer",
                    Description = "Reached level 50",
                    Icon = "/images/level50.png"
                },
                new Badge
                {
                    Id = Guid.Parse("20000000-0000-0000-0000-000000000100"),
                    Name = "Legend of InfinityFit",
                    Description = "Reached level 100",
                    Icon = "/images/level100.png"
                },




                // ---------BADGE-URI LIKE-URI------------
                new Badge
                {
                    Id = Guid.Parse("30000000-0000-0000-0000-000000000001"),
                    Name = "First Love",
                    Description = "Gave your first like",
                    Icon = "/images/like1.png"
                },
                new Badge
                {
                    Id = Guid.Parse("30000000-0000-0000-0000-000000000010"),
                    Name = "Supporter",
                    Description = "Gave 10 likes",
                    Icon = "/images/like10.png"
                },
                new Badge
                {
                    Id = Guid.Parse("30000000-0000-0000-0000-000000000050"),
                    Name = "Positive Vibes",
                    Description = "Gave 50 likes",
                    Icon = "/images/like50.png"
                },
                new Badge
                {
                    Id = Guid.Parse("30000000-0000-0000-0000-000000000100"),
                    Name = "Community Booster",
                    Description = "Gave 100 likes",
                    Icon = "/images/like100.png"
                },
                new Badge
                {
                    Id = Guid.Parse("30000000-0000-0000-0000-000000000500"),
                    Name = "Influencer",
                    Description = "Gave 500 likes",
                    Icon = "/images/like500.png"
                },
                new Badge
                {
                    Id = Guid.Parse("30000000-0000-0000-0000-000000001000"),
                    Name = "Social Machine",
                    Description = "Gave 1,000 likes",
                    Icon = "/images/like1000.png"
                },
                new Badge
                {
                    Id = Guid.Parse("30000000-0000-0000-0000-000000005000"),
                    Name = "Infinity Reactor",
                    Description = "Gave 5,000 likes",
                    Icon = "/images/like5000.png"
                },


                // ---------BADGE-URI COMENTARII------------
                new Badge
                {
                    Id = Guid.Parse("40000000-0000-0000-0000-000000000001"),
                    Name = "First Words",
                    Description = "Posted your first comment",
                    Icon = "/images/comment1.png"
                },
                new Badge
                {
                    Id = Guid.Parse("40000000-0000-0000-0000-000000000005"),
                    Name = "Conversationalist",
                    Description = "Posted 5 comments",
                    Icon = "/images/comment5.png"
                },
                new Badge
                {
                    Id = Guid.Parse("40000000-0000-0000-0000-000000000015"),
                    Name = "Active Voice",
                    Description = "Posted 15 comments",
                    Icon = "/images/comment15.png"
                },
                new Badge
                {
                    Id = Guid.Parse("40000000-0000-0000-0000-000000000050"),
                    Name = "Discussion Leader",
                    Description = "Posted 50 comments",
                    Icon = "/images/comment50.png"
                },
                new Badge
                {
                    Id = Guid.Parse("40000000-0000-0000-0000-000000000100"),
                    Name = "Community Speaker",
                    Description = "Posted 100 comments",
                    Icon = "/images/comment100.png"
                },
                new Badge
                {
                    Id = Guid.Parse("40000000-0000-0000-0000-000000000250"),
                    Name = "Debater Pro",
                    Description = "Posted 250 comments",
                    Icon = "/images/comment250.png"
                },
                new Badge
                {
                    Id = Guid.Parse("40000000-0000-0000-0000-000000000500"),
                    Name = "Social Anchor",
                    Description = "Posted 500 comments",
                    Icon = "/images/comment500.png"
                },
                new Badge
                {
                    Id = Guid.Parse("40000000-0000-0000-0000-000000001000"),
                    Name = "Voice of Infinity",
                    Description = "Posted 1,000 comments",
                    Icon = "/images/comment1000.png"
                }

            );
        }
    }
}
