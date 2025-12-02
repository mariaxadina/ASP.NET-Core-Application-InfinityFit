using System;

namespace InfinityFit.Models
{
    public class Like : BaseObject
    {
        public required string UserId { get; set; } // FK → User
        public required Guid PostId { get; set; }   // FK → Post

        public required User User { get; set; }
        public required Post Post { get; set; }

        public DateTime Date { get; set; } = DateTime.UtcNow;
    }
}
