using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTimeManager.Model
{
    public class Project : EntityBase
    {
        [Required]
        [Display(Name = "Ime projekta")]
        public string Name { get; set; }
    }
}
