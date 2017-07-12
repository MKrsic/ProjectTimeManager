using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjectTimeManager.Models
{
    public class ProjectTimeVM
    {
        public int Project_ID { get; set; }

        [Display(Name = "Ime projekta")]
        public string ProjectName { get; set; }

        [Display(Name = "Uloženo vremena")]
        public TimeSpan TimeSpent { get; set; }
    }
}