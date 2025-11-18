using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System;
using System.ComponentModel.DataAnnotations.Schema;




namespace InfinityFit.Models
{
    public class Badge
    {
            [Key]
            public int Id { get; set; }
            
            [Required]
            [StringLength(100)]
            public required string Name { get; set; } 
            
            [StringLength(500)]
            public string? Description { get; set; }

            
            // Proprietate de Navigare
            public ICollection<UserBadge> UserBadges { get; set; } = new List<UserBadge>();
    }
}