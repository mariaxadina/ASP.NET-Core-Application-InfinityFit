using System;
using System.ComponentModel.DataAnnotations;

namespace InfinityFit.Models
{
    public class LeaderboardEntry
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        public string UserId { get; set; } = null!;

        public int Engagement { get; set; }

        public DateTime Month { get; set; }

        public User User { get; set; } = null!;
    }
}
