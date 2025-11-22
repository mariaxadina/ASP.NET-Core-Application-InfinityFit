using System;
using System.ComponentModel.DataAnnotations;

namespace InfinityFit.Models
{
    public class UserBadge : BaseObject
    {
        public required string UserId { get; set; }  // FK → User
        public required Guid BadgeId { get; set; }   // FK → Badge

        public required User User { get; set; }
        public required Badge Badge { get; set; }

        public DateTime DateAwarded { get; set; } = DateTime.UtcNow;
    }
}
