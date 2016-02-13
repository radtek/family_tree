using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamilyTree.DB.Models
{
    public class Marriage : Base.BaseMarriage
    {

        [NPoco.Ignore]
        public string Description
        {
            get
            {
                return this.ToString();
            }
        }

        [NPoco.Ignore]
        public Person Husband { get; set; }
        [NPoco.Ignore]
        public Person Wife { get; set; }
        [NPoco.Ignore]
        public List<Person> Sons { get; set; }

        public Marriage()
        {
            // do nothing
        }

        public Marriage(Person person1, Person person2)
        {
            if(person1.isFemale)
            {
                this.Husband = person2;
                this.Wife = person1;
            }
            else
            {
                this.Husband = person1;
                this.Wife = person2;
            }

            this.husband_id = (long) this.Husband.id;
            this.wife_id = (long) this.Wife.id;
        }

        public override string ToString()
        {
            if (this.Husband != null && this.Wife != null)
                return string.Format("{0} + {1}", this.Husband.ToString(), this.Wife.ToString());
            else
                return "(null)";
        }
    }
}
