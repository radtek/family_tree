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
        public Person Husband { get; set; }
        [NPoco.Ignore]
        public Person Wife { get; set; }
        [NPoco.Ignore]
        public List<Person> Sons { get; set; }
    }
}
