namespace ProjectTimeManager.DAL.Migrations
{
    using ProjectTimeManager.Model;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ProjectTimeManager.DAL.ProjectTimeManagerDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ProjectTimeManager.DAL.ProjectTimeManagerDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.

            context.Person.AddOrUpdate(p => p.ID,
              new Person { ID = 1, Name = "Pero", LastName = "Periæ", CreatedAt = DateTime.Now },
              new Person { ID = 2, Name = "Mato", LastName = "Matiæ", CreatedAt = DateTime.Now },
              new Person { ID = 3, Name = "Luka", LastName = "Lukiæ", CreatedAt = DateTime.Now }
            );

            context.Project.AddOrUpdate(p => p.ID,
                new Project { ID = 1, Name = "Facebook", CreatedAt = DateTime.Now },
                new Project { ID = 2, Name = "Google_Maps", CreatedAt = DateTime.Now },
                new Project { ID = 3, Name = "Youtube", CreatedAt = DateTime.Now }
             );

            context.ProjectMember.AddOrUpdate(
                new ProjectMember { Person_ID = 1, Project_ID = 1, CreatedAt = DateTime.Now },
                new ProjectMember { Person_ID = 1, Project_ID = 2, CreatedAt = DateTime.Now },
                new ProjectMember { Person_ID = 1, Project_ID = 3, CreatedAt = DateTime.Now },
                new ProjectMember { Person_ID = 2, Project_ID = 1, CreatedAt = DateTime.Now },
                new ProjectMember { Person_ID = 2, Project_ID = 2, CreatedAt = DateTime.Now },
                new ProjectMember { Person_ID = 3, Project_ID = 3, CreatedAt = DateTime.Now }
            );

            context.TimeTrack.AddOrUpdate(
                new TimeTrack { Person_ID = 1, Project_ID = 1, StartTime = DateTime.Now, EndTime = DateTime.Now.AddHours(2), CreatedAt = DateTime.Now },
                new TimeTrack { Person_ID = 1, Project_ID = 2, StartTime = DateTime.Now, EndTime = DateTime.Now.AddHours(2), CreatedAt = DateTime.Now },
                new TimeTrack { Person_ID = 1, Project_ID = 3, StartTime = DateTime.Now, EndTime = DateTime.Now.AddHours(2), CreatedAt = DateTime.Now },
                new TimeTrack { Person_ID = 2, Project_ID = 1, StartTime = DateTime.Now, EndTime = DateTime.Now.AddHours(2), CreatedAt = DateTime.Now },
                new TimeTrack { Person_ID = 2, Project_ID = 2, StartTime = DateTime.Now, EndTime = DateTime.Now.AddHours(2), CreatedAt = DateTime.Now },
                new TimeTrack { Person_ID = 3, Project_ID = 3, StartTime = DateTime.Now, EndTime = DateTime.Now.AddHours(2), CreatedAt = DateTime.Now }
            );

        }
    }
}
