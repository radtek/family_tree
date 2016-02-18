using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamilyTree.DB.Models.Base
{

    [NPoco.TableName("marriage_sons")]
    [NPoco.PrimaryKey("id", AutoIncrement = true)]
    public class BaseMarriageSon
    {
        public long id { get; set; }
        public long marriage_id { get; set; }
        public long son_id { get; set; }
    }
}
