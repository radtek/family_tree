using FamilyTree.DB.Models;
using FamilyTree.DB.Models.Helpers;
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
            var marriage = DB.Database.GetDatabase().FetchBy<Marriage>(sql => sql.Where(x => x.husband_id.Equals(person.id) || x.wife_id.Equals(person.id))).FirstOrDefault();            
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

        public ParentalInfo FindParents(Person person)
        {
            var marriageSon = DB.Database.GetDatabase().FetchBy<MarriageSon>(sql => sql.Where(x => x.son_id.Equals(person.id))).FirstOrDefault();
            if (marriageSon != null)
            {
                var marriage = DB.Database.GetDatabase().FetchBy<Marriage>(sql => sql.Where(x => x.id.Equals(marriageSon.marriage_id))).FirstOrDefault();
                var father = DB.Database.GetDatabase().FetchBy<Person>(sql => sql.Where(x => x.id.Equals(marriage.husband_id))).FirstOrDefault();
                var mother = DB.Database.GetDatabase().FetchBy<Person>(sql => sql.Where(x => x.id.Equals(marriage.wife_id))).FirstOrDefault();
                var siblings = DB.Database.GetDatabase().FetchBy<MarriageSon>(sql => sql.Where(x => x.marriage_id.Equals(marriage.id) && !x.son_id.Equals(person.id))).ToList();

                var parentalInfo = new ParentalInfo() { Son = person, Marriage = marriage, Father = father, Mother = mother, Siblings = siblings };
                return parentalInfo;
            }
            else
            {
                return null;
            }
        }
    }
}
