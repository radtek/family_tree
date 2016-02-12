using FamilyTree.DB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamilyTree.DB.Repositories
{
    class MarriageSonRepository
    {

        public List<MarriageSon> FindAll()
        {
            return DB.Database.GetDatabase().Fetch<MarriageSon>();
        }

        public MarriageSon FindBySon(Person person)
        {
            var marriageSon = DB.Database.GetDatabase().FetchBy<MarriageSon>(sql => sql.Where(x => x.son_id.Equals(person.id))).FirstOrDefault();
            if(marriageSon != null)
            {
                marriageSon.Son = person;
                return marriageSon;
            }
            else
            {
                return null;
            }

        }

    }
}
