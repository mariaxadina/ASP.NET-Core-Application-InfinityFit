using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace InfinityFit.Models
{
    public class Post : BaseObject
    {
        public required string UserId { get; set; }   // FK → User
        public required Guid LocationId { get; set; } // FK → Location

        [StringLength(200)]
        public string? Title { get; set; }

        [StringLength(2000)]
        public string? Description { get; set; }

        [Required]
        public required string ImagePath { get; set; }

        public DateTime DatePosted { get; set; } = DateTime.UtcNow;

        public required User User { get; set; }
        
        public double Latitude { get; set; } // locatia
        public double Longitude { get; set; }

        public ICollection<Comment> Comments { get; set; } = new List<Comment>();
        public ICollection<Like> Likes { get; set; } = new List<Like>();
    }
}
