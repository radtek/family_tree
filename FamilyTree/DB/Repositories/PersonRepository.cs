using FamilyTree.DB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamilyTree.DB.Repositories
{
    class PersonRepository
    {

        public List<Person> FindAll()
        {
            return DB.Database.GetDatabase().Fetch<Person>();
        }

        public Person FindPartner(Person person)
        {
            var marriage = new MarriageRepository().FindByPerson(person);            
            if(marriage != null)
            {
                var partnerId = marriage.husband_id;
                if (partnerId == person.id)
                    partnerId = marriage.wife_id;
                var partner = DB.Database.GetDatabase().FetchBy<Person>(sql => sql.Where(x => x.id.Equals(partnerId))).FirstOrDefault();
                return partner;
            }
            else
            {
                return null;
            }
        }

    }
}
