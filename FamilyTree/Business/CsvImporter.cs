using FamilyTree.DB.Models;
using NPoco;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamilyTree.Business
{

    /// <summary>
    /// This CSV takes into account a very specific type of input CSV.
    /// This class is probably useless for any other kind of input (or at best just as an impoter example).
    /// 
    /// Csv header:
    /// GEN,Nº,NOM,LLINATGE 1r,LLINATGE 2n,NAIX,LLOC NAIX,MATR,EDAT ,LLOC,FILLS,MORT,EDAT,LLOC,INFO,IS_FEMALE
    /// 
    /// </summary>
    class CsvImporter
    {

        private NPoco.Database _db { get; set; }

        public CsvImporter()
        {
            _db = DB.Database.GetDatabase();
        }

        public void Import(string csvFilePath)
        {
            var lines = File.ReadAllLines(csvFilePath, Encoding.UTF7);
            for(int lineIndex = 2; lineIndex < lines.Length; lineIndex += 2)
            {
                ProcessMarriage(lines[lineIndex], lines[lineIndex + 1]);            
            }
        }

        private void ProcessMarriage(string husbandLine, string wifeLine)
        {            
            var husband = GetPersonFromLine(husbandLine);
            var wife = GetPersonFromLine(wifeLine);
            var marriage = GetMarriageFromHusbandLine(husbandLine, husband, wife);
        }

        private Marriage GetMarriageFromHusbandLine(string line, Person husband, Person wife)
        {
            var cells = line.Split(',');
            var marriage = new Marriage()
            {
                date = GetDate(cells[7]),
                place = cells[9],
                husband_id = husband.id,
                wife_id = wife.id
            };
            marriage.id = (long) _db.Insert(marriage);
            return marriage;
        }

        private Person GetPersonFromLine(string line)
        {
            var cells = line.Split(',');
            var name = cells[2];
            if (name != null)
            {
                var person = new Person()
                {
                    name = cells[2],
                    fathersSurname = cells[3],
                    mothersSurname = cells[4],
                    dateOfBirth = GetDate(cells[5]),
                    placeOfBirth = cells[6] == "" ? null : cells[6],
                    dateOfDeath = GetDate(cells[11]),
                    placeOfDeath = cells[13] == "" ? null : cells[13],
                    info = cells[14],
                    isFemale = int.Parse(cells[15]) == 1 ? true : false
                };
                person.id = (long)_db.Insert(person);
                return person;
            }
            else
            {
                return null;
            }
        }

        private DateTime? GetDate(string dateString)
        {
            dateString = dateString.Trim();
            if (dateString == null)
                return null;
            else if (dateString == "")
                return null;
            else if (dateString.Contains("-"))
                try
                {
                    return DateTime.ParseExact(dateString, "yyyy-MM-dd", null);
                }
                catch (Exception)
                {
                    return null;
                }
                
            else if (dateString.Length == 4)
                return DateTime.ParseExact(dateString, "yyyy", null);
            else if (dateString.Contains("/"))
                return null;
            else
                throw new InvalidDataException(string.Format("Unknown case for date cell '{0}'", dateString));
        }

    }
}
