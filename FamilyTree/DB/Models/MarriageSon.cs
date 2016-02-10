using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamilyTree.DB.Models
{
    [NPoco.TableName("marriage_sons")]
    public class MarriageSon
    {        
        public int marriage_id { get; set; }
        public int son_id { get; set; }
    }
}
