using FamilyTree.DB.Models;
using FamilyTree.DB.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamilyTree.Business
{
    class D3ForceDirectedExporter
    {

        public string GetAllItemsAsJson()
        {

            var persons = new PersonRepository().FindAll();
            var marriages = new MarriageRepository().FindAll();
            var marriageSons = new MarriageSonRepository().FindAll();

            int counter = 0;
            var personsAsJs = GetPersonsAsJsNodes( persons, ref counter);
            var marriagesAsJs = GetMarriagesAsJsNodes(marriages, ref counter);

            var nodesAsJs = new List<string>();
            nodesAsJs.AddRange(personsAsJs.Select(x => x.Value.Item2));
            nodesAsJs.AddRange(marriagesAsJs.Select(x => x.Value.Item2));

            var linksAsJs = GetLinksAsJs(marriageSons, marriages, personsAsJs, marriagesAsJs);

            var fullJs = String.Format(@"{{""directed"": true, ""graph"": [], ""nodes"": [{0}] , ""links"": [{1}] , ""multigraph"": false}}",
                           String.Join(",\r\n", nodesAsJs),
                           String.Join(",\r\n", linksAsJs));
            return fullJs;
        }

        private Dictionary<long, Tuple<int, string>> GetPersonsAsJsNodes(List<Person> persons, ref int counter)
        {
            var jsNodes = new Dictionary<long, Tuple<int, string>>();

            foreach (var person in persons)
            {
                var jsNode = string.Format("{{\"id\":\"{0}\", \"type\":\"{1}\", \"color\": \"{2}\"}}",
                    person.ToString(),
                    person.isFemale ? "female" : "male",
                    person.isFemale ? "red" : "blue");
                jsNodes.Add(person.id, new Tuple<int, string>(counter, jsNode));
                counter++;
            }

            return jsNodes;
        }

     
        private Dictionary<long, Tuple<int, string>> GetMarriagesAsJsNodes(List<Marriage> marriages, ref int counter)
        {
            var jsNodes = new Dictionary<long, Tuple<int, string>>();

            foreach (var marriage in marriages)
            {
                var jsNode = string.Format("{{\"id\":\"{0}\", \"type\":\"{1}\", \"color\": \"{2}\"}}",
                    "",
                    "marriage",
                    "#000");
                jsNodes.Add(marriage.id, new Tuple<int, string>(counter, jsNode));
                counter++;
            }

            return jsNodes;
        }

        private List<string> GetLinksAsJs(
            List<MarriageSon> marriageSons, 
            List<Marriage> marriages,
            Dictionary<long, Tuple<int, string>> personsJsNodes,
            Dictionary<long, Tuple<int, string>> marriageJsNodes)
        {
            var linksAsJs = new List<string>();
            foreach(var marriageSon in marriageSons)
            {
                var marriage = marriages.Where(x => x.id.Equals(marriageSon.marriage_id)).FirstOrDefault();

                var marriageJsId = marriageJsNodes.Where(x => x.Key.Equals(marriage.id)).Select(x => x.Value.Item1).FirstOrDefault();
                var sonJsId = personsJsNodes.Where(x => x.Key.Equals(marriageSon.son_id)).Select(x => x.Value.Item1).FirstOrDefault();
                var husbandJsId = personsJsNodes.Where(x => x.Key.Equals(marriage.husband_id)).Select(x => x.Value.Item1).FirstOrDefault();
                var wifeJsId = personsJsNodes.Where(x => x.Key.Equals(marriage.wife_id)).Select(x => x.Value.Item1).FirstOrDefault();

                var jsText2 = string.Format("{{\"source\": {0}, \"target\": {1}}}",
                    husbandJsId,
                    marriageJsId);
                var jsText3 = string.Format("{{\"source\": {0}, \"target\": {1}}}",
                    wifeJsId,
                    marriageJsId);
                var jsText1 = string.Format("{{\"source\": {0}, \"target\": {1}}}",
                    marriageJsId,
                    sonJsId);

                linksAsJs.AddRange(new string[] { jsText1, jsText2, jsText3 });
            }                       
            return linksAsJs;
        }

    }
}
