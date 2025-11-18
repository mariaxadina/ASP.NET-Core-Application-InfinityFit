using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System;
using System.ComponentModel.DataAnnotations.Schema;


namespace InfinityFit.Models
{
    public class Location
    {
         [Key]
        public int Id { get; set; }
        
        [Required]
        [StringLength(100)]
        public required string Name { get; set; }

        //Câmp pentru ID-ul din API-ul extern (OpenStreetMap)
        // Acest ID va permite sincronizarea cu datele externe.
        [StringLength(50)]
        public string? ExternalApiId { get; set; } 

        //Prop de navigare
        public ICollection<Location> Locations { get; set; } = new List<Location>();
    }
    
}