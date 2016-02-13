using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamilyTree.DB.Models
{
    public class MarriageSon : Base.BaseMarriageSon
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
        public Person Son { get; set; }

        public override string ToString()
        {
            if (this.Son != null)
                return string.Format("{0}", this.Son.ToString());
            else
                return "(null)";
        }

    }
}
