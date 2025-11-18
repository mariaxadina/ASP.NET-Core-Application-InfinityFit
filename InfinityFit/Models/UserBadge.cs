using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System;
using System.ComponentModel.DataAnnotations.Schema;



namespace InfinityFit.Models
{
    public class UserBadge
    {

        [Key]
        public int Id { get; set; }
        [Required]
        public required string UserId { get; set; } // FK către AppUser
        [Required]
        public int BadgeId { get; set; } // FK către Badge

        public DateTime DateAwarded { get; set; } = DateTime.UtcNow;

        // Proprietăți de Navigare
        public required User User { get; set; }
        public required Badge Badge { get; set; }
    }


}
    
