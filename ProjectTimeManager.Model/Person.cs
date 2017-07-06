using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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

        //public virtual ProjectMember ProjectMembers { get; set; }
        //public virtual TimeTrack TimeTracks { get; set; }

        public virtual ICollection<ProjectMember> ProjectMembers { get; set; }
        public virtual ICollection<TimeTrack> TimeTracks { get; set; }
    }
}
