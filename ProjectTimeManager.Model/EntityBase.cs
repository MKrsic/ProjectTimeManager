using System;
using System.ComponentModel.DataAnnotations;

namespace ProjectTimeManager.Model
{
    public abstract class EntityBase
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        public Nullable<DateTime> UpdatedAt { get; set; }
    }
}
