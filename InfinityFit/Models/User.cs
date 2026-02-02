using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace InfinityFit.Models
{
    public class User : IdentityUser
    {
        public int? Level { get; set; } = 1;
        public int? TotalPoints { get; set; } = 0;
        public float? Daily_Distance_Goal { get; set; }
        public string? ProfileImagePath { get; set; }
        public DateTime? LastLevelUp { get; set; }

        public ICollection<Post> Posts { get; set; } = new List<Post>();
        public ICollection<Comment> Comments { get; set; } = new List<Comment>();
        public ICollection<Like> Likes { get; set; } = new List<Like>();
        public ICollection<UserBadge> UserBadges { get; set; } = new List<UserBadge>();

      
    }
}
