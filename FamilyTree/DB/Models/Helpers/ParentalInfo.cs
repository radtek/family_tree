using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamilyTree.DB.Models.Helpers
{
    class ParentalInfo
    {
        public Person Son { get; set; }
        public Marriage Marriage { get; set; }
        public Person Father { get; set; }
        public Person Mother { get; set; }
        public List<Person> Siblings { get; set; }
    }
}
