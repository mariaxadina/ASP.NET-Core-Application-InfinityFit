using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System;
using System.ComponentModel.DataAnnotations.Schema;



namespace InfinityFit.Models
{
    
    public class Appreciation
    {
        [Key]
        public int AppreciationId { get; set; }


        [Required]
        public required string UserId { get; set; } // FK către AppUser
        [Required]
        public required int PostId { get; set; } // FK către Post
        
        public DateTime Date { get; set; } = DateTime.UtcNow;

        // Proprietăți de Navigare
        public required User User { get; set; }
        public required Post Post { get; set; }
    }




}