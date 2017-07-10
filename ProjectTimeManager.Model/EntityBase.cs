using System;
using System.ComponentModel.DataAnnotations;

namespace ProjectTimeManager.Model
{
    public abstract class EntityBase
    {
        [Key]
        public int ID { get; set; }

        [Display(Name = "Vrijeme kreiranja")]
        [Required]
        public DateTime CreatedAt { get; set; }

        [Display(Name = "Vrijeme izmjene")]
        public Nullable<DateTime> UpdatedAt { get; set; }
    }
}
