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
        public List<Marriage> FindAll()
        {
            return DB.Database.GetDatabase().Fetch<Marriage>();
        }

        public Marriage FindByPerson(Person person)
        {
            return DB.Database.GetDatabase().FetchBy<Marriage>(sql => sql.Where(x => x.husband_id.Equals(person.id) || x.wife_id.Equals(person.id))).FirstOrDefault();
        }

        public Marriage FindByPk(int id)
        {
            return DB.Database.GetDatabase().FetchBy<Marriage>(sql => sql.Where(x => x.id.Equals(id))).FirstOrDefault();
        }

        public Marriage FindParentsMarriage(Person person)
        {
            var marriageSon = new MarriageSonRepository().FindBySon(person);
            if (marriageSon != null)
            {
                var marriage = DB.Database.GetDatabase().FetchBy<Marriage>(sql => sql.Where(x => x.id.Equals(marriageSon.marriage_id))).FirstOrDefault();
                var father = DB.Database.GetDatabase().FetchBy<Person>(sql => sql.Where(x => x.id.Equals(marriage.husband_id))).FirstOrDefault();
                var mother = DB.Database.GetDatabase().FetchBy<Person>(sql => sql.Where(x => x.id.Equals(marriage.wife_id))).FirstOrDefault();
                var sonIds = (DB.Database.GetDatabase().FetchBy<MarriageSon>(sql => sql.Where(x => x.marriage_id.Equals(marriage.id)))).Select(x => x.son_id).ToList();
                var sons = DB.Database.GetDatabase().FetchBy<Person>(sql => sql.Where(x => sonIds.Contains(x.id))).ToList();

                marriage.Husband = father;
                marriage.Wife = mother;
                marriage.Sons = sons;

                return marriage;

            }
            else
            {
                return null;
            }
        }
    }
}
