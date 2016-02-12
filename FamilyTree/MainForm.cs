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
        }
    }
}
