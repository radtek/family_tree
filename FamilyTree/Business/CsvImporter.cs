using FamilyTree.DB.Models;
using NPoco;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

        private NPoco.Database _db;

        /// <summary>
        /// Tuple:
        /// item1 = generation number
        /// item2 = inner index
        /// </summary>
        private Dictionary<Person, Tuple<int, int>> _personsDict;

        public CsvImporter()
        {
            _db = DB.Database.GetDatabase();
        }

        public void Import(string csvFilePath)
        {
            var lines = File.ReadAllLines(csvFilePath, Encoding.UTF7);
            for(int lineIndex = 2; lineIndex < lines.Length-1; lineIndex += 2)
            {
                try
                {
                    ProcessMarriage(lines[lineIndex], lines[lineIndex + 1]);
                }
                catch (Exception ex)
                {
                    var _stop = -1;
                }
                
            }

        }

        private void ProcessMarriage(string husbandLine, string wifeLine)
        {            
            var husband = GetPersonFromLine(husbandLine);
            var wife = GetPersonFromLine(wifeLine);
            var marriage = GetMarriageFromHusbandLine(husbandLine, husband, wife);

            if(husband != null)
            {
                var husbandIndexing = _personsDict[husband];
                var sonId = (int) Math.Truncate((double)husbandIndexing.Item2 / 2);
                var son = _personsDict.Where(x => x.Value.Item2.Equals(sonId)).Select(x => x.Key).FirstOrDefault();
                if(son != null)
                {
                    var marriageSon = new MarriageSon()
                    {
                        marriage_id = marriage.id,
                        son_id = son.id
                    };
                    var id = _db.Insert(marriageSon);
                    marriageSon.id = (long) id;
                }
            }

        }

        private Marriage GetMarriageFromHusbandLine(string line, Person husband, Person wife)
        {
            var cells = line.Split(',');
            var marriage = new Marriage()
            {
                date = GetDate(cells[7]),
                place = cells[9],
                husband_id = husband?.id,
                wife_id = wife?.id
            };
            marriage.id = (long) _db.Insert(marriage);
            return marriage;
        }

        private Person GetPersonFromLine(string line)
        {
            var cells = line.Split(',');

            var name = GetString( cells[2]);
            if (name == null)
                return null;

            string numberOfSons = GetString(cells[10]);
            if (numberOfSons == null)
                numberOfSons = "(?)";

            var person = new Person()
            {
                name = GetString(cells[2]),
                fathersSurname = GetString(cells[3]),
                mothersSurname = GetString(cells[4]),
                dateOfBirth = GetDate(cells[5]),
                placeOfBirth = GetString(cells[6]),
                dateOfDeath = GetDate(cells[11]),
                placeOfDeath = GetString(cells[13]),
                info = string.Format("{0} fills. {1}.", numberOfSons, GetString(cells[14])),
                isFemale = int.Parse(cells[15]) == 1 ? true : false
            };
            person.id = (long)_db.Insert(person);

            // !!!
            int generationNumber = int.Parse(cells[0]);
            int customId = int.Parse(Regex.Match(cells[1], @"\d+").Value);
            if (_personsDict == null)
                _personsDict = new Dictionary< Person, Tuple < int, int>>();
            _personsDict.Add( person, new Tuple<int, int>(generationNumber, customId));

            return person;

        }

        private string GetString(string input)
        {
            if (input == null)
                return null;
            else
            {
                var output = input.Trim();
                if (output == string.Empty)
                    return null;
                else
                    return output;
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
