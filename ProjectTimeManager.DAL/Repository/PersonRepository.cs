using ProjectTimeManager.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTimeManager.DAL.Repository
{
    public class PersonRepository : RepositoryBase<Person>
    {
        public List<Person> GetList()
        {
            return this.DbContext.Person
                .OrderBy(i => i.ID)
                .ToList();
        }

        public override Person Find(int id)
        {
            return this.DbContext.Person
                .Where(i => i.ID == id)
                .FirstOrDefault();
        }
    }
}
