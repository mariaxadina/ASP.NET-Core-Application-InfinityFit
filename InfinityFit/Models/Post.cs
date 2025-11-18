
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace InfinityFit.Models
{
public class Post
    {
        [Key]
        public int Id { get; set; }



        
        public required string UserId { get; set; } // FK către AppUser (Autorul)
        public int LocationId { get; set; } // FK către Location


        [Required]
        [StringLength(200)]
        public string? Title { get; set; }

        [StringLength(2000)]
        public string? Description { get; set; }

        [Required]
        public required string ImageUrl { get; set; } 
        
        public DateTime DatePosted { get; set; } = DateTime.UtcNow;

        [Required]
        // Status pentru moderare (Pending, Approved, Rejected)
        public string Status { get; set; } = "Pending";

        

        // Proprietăți de Navigare
        public required User User { get; set; }
        public required Location Location { get; set; }

        
        public ICollection<Comment> Comments { get; set; } = new List<Comment>();
        public ICollection<Appreciation> Apreciations { get; set; } = new List<Appreciation>();
    }

}