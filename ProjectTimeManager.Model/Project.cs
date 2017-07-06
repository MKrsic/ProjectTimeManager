using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProjectTimeManager.Model
{
    public class Project : EntityBase
    {
        [Required]
        [Display(Name = "Ime projekta")]
        public string Name { get; set; }

        public virtual ICollection<ProjectMember> ProjectMembers { get; set; }
        public virtual ICollection<TimeTrack> TimeTracks { get; set; }
    }
}
