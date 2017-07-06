using ProjectTimeManager.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTimeManager.DAL.Repository
{
    public class ProjectRepository : RepositoryBase<Project>
    {
        public List<Project> GetList()
        {
            return this.DbContext.Project
                .OrderBy(i => i.ID)
                .ToList();
        }

        public override Project Find(int id)
        {
            return this.DbContext.Project
                .Where(i => i.ID == id)
                .FirstOrDefault();
        }
    }
}
