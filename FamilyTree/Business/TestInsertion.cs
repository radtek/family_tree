using FamilyTree.DB;
using FamilyTree.DB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamilyTree.Business
{
    class TestInsertion
    {
        public static void Test()
        {

            var person1 = new Person { name = "does it work?" };
            var person2 = new Person { name = "Estic flipant..." };
            var list = new List<Person>() { person1, person2 };

            var db = Database.GetDatabase();
            db.InsertBulk<Person>(list);

        }
    }
}
