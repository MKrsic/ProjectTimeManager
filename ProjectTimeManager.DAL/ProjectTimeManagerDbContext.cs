using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using ProjectTimeManager.Model;

namespace ProjectTimeManager.DAL
{
    public class ProjectTimeManagerDbContext : DbContext
    {
        public DbSet<Person> Person { get; set; }
        public DbSet<Project> Project { get; set; }
        public DbSet<ProjectMember> ProjectMember { get; set; }
        public DbSet<TimeTrack> TimeTrack { get; set; }
    }
}
