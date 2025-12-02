using System;
using System.ComponentModel.DataAnnotations;

namespace InfinityFit.Models
{
    public class Comment : BaseObject
    {
        [Required]
        public required string Content { get; set; }

        public required string UserId { get; set; } // FK → User
        public required Guid PostId { get; set; }   // FK → Post

        public required User User { get; set; }
        public required Post Post { get; set; }

        public DateTime Date { get; set; } = DateTime.UtcNow;
    }
}
