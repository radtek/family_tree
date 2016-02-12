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

namespace FamilyTree.GUI
{
    public partial class PersonUI : Form
    {

        private Person Person { get; set; }
        private MarriageSon MarriageSon  { get; set; }
        private Marriage PersonMarriage { get; set; }
        private Marriage ParentsMarriage { get; set; }

        public PersonUI(Person person = null)
        {

            InitializeComponent();

            // custom:
            this.Person = person;
            if(this.Person != null)
            {
                this.MarriageSon = new MarriageSonRepository().FindBySon(this.Person);
                this.PersonMarriage = new MarriageRepository().FindByPerson(this.Person);
                this.ParentsMarriage = new MarriageRepository().FindParentsMarriage(this.Person);
            }
            
            SetPersonDataBindings();

        }

        private void SetPersonDataBindings()
        {

            this.txtName.DataBindings.Add("Text",
                    this.Person,
                    nameof(this.Person.name),
                    false,
                    DataSourceUpdateMode.OnPropertyChanged);
            this.txtFatherSurname.DataBindings.Add("Text",
                    this.Person,
                    nameof(this.Person.fathersSurname),
                    false,
                    DataSourceUpdateMode.OnPropertyChanged);
            this.txtMotherSurname.DataBindings.Add("Text",
                    this.Person,
                    nameof(this.Person.mothersSurname),
                    false,
                    DataSourceUpdateMode.OnPropertyChanged);

            this.chkIsFemale.DataBindings.Add("Checked",
                    this.Person,
                    nameof(this.Person.isFemale),
                    false,
                    DataSourceUpdateMode.OnPropertyChanged);

            this.txtPlaceOfBirth.DataBindings.Add("Text",
                    this.Person,
                    nameof(this.Person.placeOfBirth),
                    false,
                    DataSourceUpdateMode.OnPropertyChanged);
            this.txtPlaceOfDeath.DataBindings.Add("Text",
                    this.Person,
                    nameof(this.Person.placeOfDeath),
                    false,
                    DataSourceUpdateMode.OnPropertyChanged);

            this.dtpDateOfBirth.DataBindings.Add("Value",
                    this.Person,
                    nameof(this.Person.dateOfBirth),
                    false,
                    DataSourceUpdateMode.OnPropertyChanged);
            this.dtpDateOfDeath.DataBindings.Add("Value",
                    this.Person,
                    nameof(this.Person.dateOfDeath),
                    false,
                    DataSourceUpdateMode.OnPropertyChanged);

            this.rtbInfo.DataBindings.Add("Text",
                    this.Person,
                    nameof(this.Person.info),
                    false,
                    DataSourceUpdateMode.OnPropertyChanged);

        }

        private void btnSelectPartner_Click(object sender, EventArgs e)
        {
            var list = new PersonRepository().FindAll();
            var form = new SelectorUI<Person>(list);
            form.Show();
            var selectedItem = form.SelectedItem;
        }

        private void chkUnknownDateOfBirth_CheckedChanged(object sender, EventArgs e)
        {
            this.dtpDateOfBirth.Enabled = this.chkUnknownDateOfBirth.Checked;
        }

        private void chkUnknownDateOfDeath_CheckedChanged(object sender, EventArgs e)
        {
            this.dtpDateOfDeath.Enabled = this.chkUnknownDateOfDeath.Checked;
        }

        private void chkUnknownDateOfMarriage_CheckedChanged(object sender, EventArgs e)
        {
            this.dtpDateOfMarriage.Enabled = this.chkUnknownDateOfMarriage.Checked;
        }

        private void btnSaveToDb_Click(object sender, EventArgs e)
        {

        }


    }
}
