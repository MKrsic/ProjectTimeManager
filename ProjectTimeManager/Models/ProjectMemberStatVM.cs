using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjectTimeManager.Models
{
    public class ProjectMemberStatVM
    {
        [Display(Name = "Ime")]
        public string FirstName { get; set; }

        [Display(Name = "Prezime")]
        public string LastName { get; set; }

        [Display(Name = "Ime projekta")]
        public string ProjectName { get; set; }

        [Display(Name = "Vrijeme na projektu")]
        public TimeSpan MemberUsedTime { get; set; }
    }
}