using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace InfinityFit.Models
{
    public class Location : BaseObject
    {
        [Required]
        [StringLength(100)]
        public required string Name { get; set; }

        [StringLength(50)]
        public string? ExternalApiId { get; set; }

        public ICollection<Post> Posts { get; set; } = new List<Post>();
    }
}
