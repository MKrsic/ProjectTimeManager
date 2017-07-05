using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTimeManager.Model
{
    public class Person : EntityBase
    {
        [Required]
        [Display(Name = "Ime")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Prezime")]
        public string LastName { get; set; }
    }
}
