using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTimeManager.Model
{
    public class TimeTrack
    {
        [Key]
        public int ID { get; set; }

        [ForeignKey("Project")]
        public int Project_ID { get; set; }

        [ForeignKey("Person")]
        public int Person_ID { get; set; }

        [Display(Name = "Početak rada")]
        public DateTime StartTime { get; set; }

        [Display(Name = "Kraj rada")]
        public DateTime EndTime { get; set; }

        public virtual Project Project { get; set; }
        public virtual Person Person { get; set; }
    }
}
