using FamilyTree.DB.Models;
using FamilyTree.DB.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FamilyTree
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void lnkAddNewPerson_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var form = new GUI.PersonUI();
            form.Show();
        }

        private void lnkAddNewMarriage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var form = new GUI.MarriageUI();
            form.Show();
        }

        private void lnkInsertMockupPersons_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Business.MockupInsertions.InsertMockupPersons();
            MessageBox.Show("Done.");
        }

        private void lnkSelectAndEditPerson_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // first select the person:
            var persons = new PersonRepository().FindAll();
            var form = new GUI.SelectorUI<Person>(persons);
            form.ShowDialog();
            var selectedPerson = form.SelectedItem;

            // then edit this person:
            var personUI = new GUI.PersonUI(selectedPerson);
            personUI.Show();
        }

        private void lnkInsertFromCsv_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            var csvImporter = new Business.CsvImporter();

            // !!! Clear tables
            var db = DB.Database.GetDatabase();
            DB.Database.ClearTables(db);

            csvImporter.Import(@"C:\Users\xavier.pena\Documents\e-dric\Projects\git-xavierpenya\data\data1.csv");
            csvImporter.Import(@"C:\Users\xavier.pena\Documents\e-dric\Projects\git-xavierpenya\data\data2.csv");

            MessageBox.Show("Done.");

        }

        private void lnkConvertToJson_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //var jsonExporter = new Business.D3ForceDirectedExporter();
            //var jsonText = jsonExporter.GetAllItemsAsJson();
            //System.IO.File.WriteAllText(@".\d3-force-directed\graph.js", "var jsonVar = " + jsonText + ";", Encoding.UTF8);
            //MessageBox.Show("Done.");

            var jsonExporter = new Business.D3DendogramExporter();
            var jsonText = jsonExporter.GetAllItemsAsJson();
            System.IO.File.WriteAllText(@".\d3-dendogram\flare.json", "var root = " + jsonText + ";", Encoding.UTF8);
            MessageBox.Show("Done.");
        
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var frm = new ForceDirected.Demo();
            frm.ShowDialog();
        }
    }
}
