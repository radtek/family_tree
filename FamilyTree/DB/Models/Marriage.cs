using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamilyTree.DB.Models
{

    [NPoco.TableName("marriages")]
    [NPoco.PrimaryKey("id")]
    class Marriage
    {
        public int id { get; set; }
        public int husband_id { get; set; }
        public int wife_id { get; set; }
    }

}
