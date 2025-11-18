using InfinityFit.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace InfinityFit.Data;

public class ApplicationDbContext : IdentityDbContext<IdentityUser>
{

    private readonly DbContextOptions <ApplicationDbContext> _options;

    //Seturile pentru db ie tabelele
    public DbSet<Badge> Badges { get; set; }
    public DbSet<UserBadge> UserBadges { get; set; }

    public DbSet<Post> Posts { get; set; }
    public DbSet<Comment> Comments { get; set; }
    public DbSet<Appreciation> Apreciations { get; set; }

        // Harta și Localizarea
        public DbSet<Location> Locations { get; set; }
        public DbSet<City> Cities { get; set; }

    
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        _options = options;
    }

    //Rezolvare multiple paths
    protected override void OnModelCreating(ModelBuilder builder)
    {
    base.OnModelCreating(builder);

    // Relația Appreciation → Post fără cascade delete
    builder.Entity<Appreciation>()
        .HasOne(a => a.Post)
        .WithMany(p => p.Apreciations)
        .HasForeignKey(a => a.PostId)
        .OnDelete(DeleteBehavior.Restrict); // sau NoAction


    // Comment → Post
    builder.Entity<Comment>()
        .HasOne(c => c.Post)
        .WithMany(p => p.Comments)
        .HasForeignKey(c => c.PostId)
        .OnDelete(DeleteBehavior.Restrict); // sau NoAction
  
    }
}
