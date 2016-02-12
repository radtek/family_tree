using FamilyTree.DB;
using FamilyTree.DB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamilyTree.Business
{
    class MockupInsertions
    {
        public static void InsertMockupPersons()
        {

            var db = Database.GetDatabase();

            var persons = new List<Person>()
            {
                new Person { name = "man1" },
                new Person { name = "woman1" },
                new Person { name = "son1" },
                new Person { name = "sonsPartner" }
            };
            db.InsertBulk<Person>(persons);

        }
    }
}
