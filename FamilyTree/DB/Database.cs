using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamilyTree.DB
{
    /// <summary>
    /// For the workbench:
    /// Using standalone SQLiteStudio @ http://sqlitestudio.pl/
    /// 
    /// How to reset primary key:
    /// UPDATE SQLITE_SEQUENCE SET SEQ=0 WHERE NAME='persons'; (where 'persons' is the tablename)    
    /// </summary>
    class Database
    {

        public static NPoco.Database GetDatabase()
        {
            return new NPoco.Database(@"Data Source=.\DB\family_tree.db;Version=3;", NPoco.DatabaseType.SQLite);
        }

        public static void ClearTables(NPoco.Database db)
        {

            db.Execute("DELETE FROM persons");
            db.Execute("UPDATE SQLITE_SEQUENCE SET SEQ=0 WHERE NAME='persons'");

            db.Execute("DELETE FROM marriages");
            db.Execute("UPDATE SQLITE_SEQUENCE SET SEQ=0 WHERE NAME='marriages'");

            db.Execute("DELETE FROM marriage_sons");
            db.Execute("UPDATE SQLITE_SEQUENCE SET SEQ=0 WHERE NAME='marriage_sons'");

        }

    }
}
