using ProjectTimeManager.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace ProjectTimeManager.DAL.Repository
{
    public class TimeTrackRepository : RepositoryBase<TimeTrack>
    {
        public List<TimeTrack> GetList()
        {
            return this.DbContext.TimeTrack
                .Include(per => per.Person)
                .Include(pro => pro.Project)
                .OrderBy(i => i.ID)
                .ToList();
        }

        public List<TimeTrack> GetTimeTrackForProject(int id)
        {
            return this.DbContext.TimeTrack
                .Include(per => per.Person)
                .Include(pro => pro.Project)
                .Where(p => p.Project_ID == id)
                .ToList();
        }

        public override TimeTrack Find(int id)
        {
            return this.DbContext.TimeTrack
                .Where(i => i.ID == id)
                .FirstOrDefault();
        }
    }
}
