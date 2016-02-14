using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamilyTree.DB.Models.Base
{

    [NPoco.TableName("marriages")]
    [NPoco.PrimaryKey("id", AutoIncrement = true)]
    public class BaseMarriage
    {
        public long id { get; set; }
        public long? husband_id { get; set; }
        public long? wife_id { get; set; }
        public DateTime? date { get; set; }
        public string place { get; set; }
    }

}
