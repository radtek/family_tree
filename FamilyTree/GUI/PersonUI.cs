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
        private Marriage PersonMarriage { get; set; }
        private Marriage ParentsMarriage { get; set; }

        private MarriageSon MarriageSon { get; set; }

        public PersonUI(Person person = null)
        {

            InitializeComponent();

            // custom:
            this.Person = person;
            CustomitzedInitialization();

        }

        private void CustomitzedInitialization()
        {
            if (this.Person != null)
            {
                this.PersonMarriage = new MarriageRepository().FindByPerson(this.Person);
                this.ParentsMarriage = new MarriageRepository().FindBySon(this.Person);
                UpdateRelationshipsView();

                this.MarriageSon = new MarriageSonRepository().FindBySon(this.Person);
            }

            SetPersonDataBindings();
        }

        private void UpdateRelationshipsView()
        {

            if (this.PersonMarriage != null)
            {
                if(this.Person.id == this.PersonMarriage.husband_id)
                    this.txtPartner.Text = this.PersonMarriage?.Wife.ToString();
                else
                    this.txtPartner.Text = this.PersonMarriage?.Husband.ToString();

                if(this.PersonMarriage.date != null)
                {
                    this.chkUnknownDateOfMarriage.Checked = false;
                    this.dtpDateOfMarriage.Enabled = true;
                    this.dtpDateOfMarriage.Value = (DateTime)this.PersonMarriage.date;
                }
  
                this.txtPlaceOfMarriage.Text = this.PersonMarriage.place;
            }

            if (this.ParentsMarriage != null)
                this.txtParents.Text = this.ParentsMarriage.ToString();
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
            form.ShowDialog();
            var selectedItem = form.SelectedItem;
            if (selectedItem != null)
                this.PersonMarriage = new Marriage(this.Person, selectedItem);
            UpdateRelationshipsView();
        }

        private void btnSelectParents_Click(object sender, EventArgs e)
        {
            var list = new MarriageRepository().FindAll(fetchExtensions: true);
            var form = new SelectorUI<Marriage>(list);
            form.ShowDialog();
            var selectedItem = form.SelectedItem;
            if (selectedItem != null)
                this.ParentsMarriage = selectedItem;
            UpdateRelationshipsView();
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

        private void dtpDateOfBirth_ValueChanged(object sender, EventArgs e)
        {
            if (this.chkUnknownDateOfBirth.Checked)
                this.Person.dateOfBirth = this.dtpDateOfBirth.Value;
        }

        private void dtpDateOfDeath_ValueChanged(object sender, EventArgs e)
        {
            if (this.chkUnknownDateOfDeath.Checked)
                this.Person.dateOfDeath = this.dtpDateOfDeath.Value;
        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {
            var db = DB.Database.GetDatabase();

            // Person:
            if (this.Person.id == 0)
                this.Person.id = (long)db.Insert(this.Person);
            else
                db.Update(this.Person);

            // Person's marriage:
            if (this.PersonMarriage != null)
            {
                if (!chkUnknownDateOfMarriage.Checked)
                    this.PersonMarriage.date = dtpDateOfMarriage.Value;
                this.PersonMarriage.place = txtPlaceOfMarriage.Text;

                if (this.PersonMarriage?.id == 0)
                    this.PersonMarriage.id = (long)db.Insert(this.PersonMarriage);
                else
                    db.Update(this.PersonMarriage);
            }

            // Link to parent's marriage:
            if (this.ParentsMarriage != null)
            {
                var marriageSon = new MarriageSon()
                {
                    marriage_id = this.ParentsMarriage.id,
                    son_id = this.Person.id
                };
                if (this.MarriageSon == null)
                    marriageSon.id = (long)db.Insert(marriageSon);
                else
                {
                    marriageSon.id = this.MarriageSon.id;
                    db.Update(marriageSon);
                }
            }
        }
    }
}
