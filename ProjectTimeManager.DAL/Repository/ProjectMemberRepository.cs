using ProjectTimeManager.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace ProjectTimeManager.DAL.Repository
{
    public class ProjectMemberRepository : RepositoryBase<ProjectMember>
    {
        public List<ProjectMember> GetList()
        {
            return this.DbContext.ProjectMember
                .Include(per => per.Person)
                .Include(pro => pro.Project)
                .OrderBy(i => i.Project_ID)
                .ToList();
        }

        public override ProjectMember Find(int id)
        {
            return this.DbContext.ProjectMember
                .Where(i => i.ID == id)
                .FirstOrDefault();
        }
    }
}
