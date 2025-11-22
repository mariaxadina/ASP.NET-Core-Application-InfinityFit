using System;
using System.ComponentModel.DataAnnotations;

namespace InfinityFit.Models
{
    public class BaseObject
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
