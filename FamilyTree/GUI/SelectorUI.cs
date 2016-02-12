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
    public partial class SelectorUI<ModelType> : Form
    {

        public ModelType SelectedItem { get; set; }

        public SelectorUI(List<ModelType> list)
        {
            InitializeComponent();

            //custom:
            this.dataGridView.DataSource = list;
        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {
            var selectedRows = this.dataGridView.SelectedRows;
            if (selectedRows.Count != 1)
                MessageBox.Show("Please select one and only one row");
            else
            {
                foreach (DataGridViewRow selectedRow in selectedRows)
                {
                    this.SelectedItem = (ModelType)selectedRow.DataBoundItem;
                    this.Close();
                    return;
                }                    
            }
        }
    }
}
