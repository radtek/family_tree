using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamilyTree.DB.Models
{
    public class Person : Base.BasePerson
    {

        [NPoco.Ignore]
        public string Description
        {
            get
            {
                return this.ToString();
            }
        }

        public override string ToString()
        {
            return string.Format("{0} {1} {2}", this.name, this.fathersSurname, this.mothersSurname);
        }

    }
}
