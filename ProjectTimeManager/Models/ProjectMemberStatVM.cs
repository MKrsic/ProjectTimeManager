using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectTimeManager.Models
{
    public class ProjectMemberStatVM
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ProjectName { get; set; }
        public TimeSpan MemberUsedTime { get; set; }
    }
}