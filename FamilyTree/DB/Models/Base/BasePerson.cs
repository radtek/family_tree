using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamilyTree.DB.Models.Base
{
    [NPoco.TableName("persons")]
    [NPoco.PrimaryKey("id", AutoIncrement = true)]
    public class BasePerson
    {
        public long id { get; set; }
        public string name { get; set; }
        public string fathersSurname { get; set; }
        public string mothersSurname { get; set; }
        public bool isFemale { get; set; }
        public DateTime? dateOfBirth { get; set; }
        public DateTime? dateOfDeath { get; set; }
        public string placeOfBirth { get; set; }
        public string placeOfDeath { get; set; }
        public string info { get; set; }
    }
}
