using FamilyTree.DB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamilyTree.DB.Repositories
{
    class MarriageRepository
    {
        public List<Marriage> FindAll(bool fetchExtensions = false)
        {
            var db = DB.Database.GetDatabase();
            var marriages = db.Fetch<Marriage>();
            if(fetchExtensions)
            {
                var persons = db.Fetch<Person>().ToList();
                foreach (var marriage in marriages)
                {
                    marriage.Husband = persons.Where(x => x.id.Equals(marriage.husband_id)).FirstOrDefault();
                    marriage.Wife = persons.Where(x => x.id.Equals(marriage.wife_id)).FirstOrDefault();
                }
            }
            return marriages;
        }

        public Marriage FindByPerson(Person person)
        {
            var marriage = DB.Database.GetDatabase().FetchBy<Marriage>(sql => sql.Where(x => x.husband_id.Equals(person.id) || x.wife_id.Equals(person.id))).FirstOrDefault();     
            if (marriage != null)
                return FindMarriageData(marriage);
            else
                return null;
        }

        public Marriage FindBySon(Person son)
        {
            var marriageSon = new MarriageSonRepository().FindBySon(son);
            if (marriageSon != null)
            {
                var marriage = DB.Database.GetDatabase().FetchBy<Marriage>(sql => sql.Where(x => x.id.Equals(marriageSon.marriage_id))).FirstOrDefault();
                if (marriage != null)
                    return FindMarriageData(marriage);
                else
                    return null;
            }
            else
            {
                return null;
            }
        }

        private Marriage FindMarriageData(Marriage marriage)
        {
            var father = DB.Database.GetDatabase().FetchBy<Person>(sql => sql.Where(x => x.id.Equals(marriage.husband_id))).FirstOrDefault();
            var mother = DB.Database.GetDatabase().FetchBy<Person>(sql => sql.Where(x => x.id.Equals(marriage.wife_id))).FirstOrDefault();
            var sonIds = (DB.Database.GetDatabase().FetchBy<MarriageSon>(sql => sql.Where(x => x.marriage_id.Equals(marriage.id)))).Select(x => x.son_id).ToList();
            var sons = DB.Database.GetDatabase().FetchBy<Person>(sql => sql.Where(x => sonIds.Contains((long) x.id))).ToList();

            marriage.Husband = father;
            marriage.Wife = mother;
            marriage.Sons = sons;

            return marriage;
        }
    }
}
