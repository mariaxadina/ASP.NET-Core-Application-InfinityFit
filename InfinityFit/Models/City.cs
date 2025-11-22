using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace InfinityFit.Models
{
    public class City : BaseObject
    {
        [Required]
        [StringLength(100)]
        public required string Name { get; set; }

        [StringLength(50)]
        public string? ExternalApiId { get; set; }

        public ICollection<Location> Locations { get; set; } = new List<Location>();
    }
}
