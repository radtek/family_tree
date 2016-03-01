using FamilyTree.DB.Models;
using FamilyTree.DB.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FamilyTree.Business
{
    class D3DendogramExporter
    {

        private List<Person> Persons { get; }
        private List<Marriage> Marriages { get; }
        private List<MarriageSon> MarriageSons { get; }
        
        public D3DendogramExporter()
        {
            this.Persons = new PersonRepository().FindAll();
            this.Marriages = new MarriageRepository().FindAll();
            this.MarriageSons = new MarriageSonRepository().FindAll();
        }

        public string GetAllItemsAsJson()
        {
            
            var fistPerson = this.Persons.
                Where(x => x.ToString().Equals("Joana Mª Forteza Fuster")).
                FirstOrDefault();

            var treeView = new TreeView();
            TreeNode topNode = null;
            topNode = GetAsNodes(fistPerson.id, ref topNode);
            treeView.Nodes.Add(topNode);

            var stringBuilder = new StringBuilder();
            int indentCount = 0;
            GetAsString(topNode, ref stringBuilder, indentCount);
            stringBuilder.Length -= 1; // remove last comma

            return stringBuilder.ToString();

        }

        private void GetAsString(TreeNode node, ref StringBuilder stringBuilder, int indentCount)
        {
            stringBuilder.AppendLine(GetStringWithIndentation("{", indentCount));
            stringBuilder.AppendLine(GetStringWithIndentation($"\"name\": \"{node.Text}\"", indentCount));
            if(node.Nodes.Count > 0)
            {
                stringBuilder.AppendLine(GetStringWithIndentation(",\"children\": [", indentCount));
                foreach (TreeNode child in node.Nodes)
                    GetAsString(child, ref stringBuilder, indentCount +1);
                stringBuilder.Length -= 1; // remove last comma
                stringBuilder.AppendLine();
                stringBuilder.AppendLine(GetStringWithIndentation("]", indentCount));
            }
            stringBuilder.Append(GetStringWithIndentation("},", indentCount));
        }

        private string GetStringWithIndentation(string text, int indentCount)
        {
            var finalString = "";
            for (int index = 0; index < indentCount; index++)
                finalString += "\t";
            return finalString + text;
        }

        private TreeNode GetAsNodes(long? personId, ref TreeNode parentNode)
        {

            if (personId == null)
                return null;

            var person = this.Persons.
                Where(x => x.id.Equals(personId)).
                FirstOrDefault();

            TreeNode sonNode = new TreeNode(person.ToString());
            if (parentNode != null)
                parentNode.Nodes.Add(sonNode);
            else
                parentNode = sonNode; // first node
             
            var parentsMarriageId = this.MarriageSons.
                Where(x => x.son_id.Equals(personId)).
                FirstOrDefault();

            if (parentsMarriageId != null)
            {
                var parentsMarriage = this.Marriages.
                    Where(x => x.id.Equals(parentsMarriageId.marriage_id)).
                    FirstOrDefault();

                var marriageNode = new TreeNode(""); // marriage: leave as empty
                sonNode.Nodes.Add(marriageNode);

                GetAsNodes(parentsMarriage.husband_id, ref marriageNode); 
                GetAsNodes(parentsMarriage.wife_id, ref marriageNode);                                
            }

            return sonNode;

        }

    }
}
