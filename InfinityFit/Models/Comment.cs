using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace InfinityFit.Models
{

 public class Comment
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public required string Content { get; set;}
        
        public DateTime Date { get; set; } = DateTime.UtcNow;

    
        public  required string UserId { get; set; } // FK către AppUser
        public required int PostId { get; set; } // FK către Post

        // Proprietăți de Navigare
        public required User User { get; set; }
        public  required Post Post { get; set; }
    }
}


