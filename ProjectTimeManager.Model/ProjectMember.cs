using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectTimeManager.Model
{
    public class ProjectMember : EntityBase
    {
        [Required]
        [ForeignKey("Project")]
        public int Project_ID { get; set; }

        [Required]
        [ForeignKey("Person")]
        public int Person_ID { get; set; }

        public virtual Project Project { get; set; }
        public virtual Person Person { get; set; }
    }
}
