namespace FamilyTree
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lnkAddNewPerson = new System.Windows.Forms.LinkLabel();
            this.lnkAddNewMarriage = new System.Windows.Forms.LinkLabel();
            this.lnkInsertMockupPersons = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // lnkAddNewPerson
            // 
            this.lnkAddNewPerson.AutoSize = true;
            this.lnkAddNewPerson.Location = new System.Drawing.Point(47, 46);
            this.lnkAddNewPerson.Name = "lnkAddNewPerson";
            this.lnkAddNewPerson.Size = new System.Drawing.Size(110, 17);
            this.lnkAddNewPerson.TabIndex = 0;
            this.lnkAddNewPerson.TabStop = true;
            this.lnkAddNewPerson.Text = "Add new person";
            this.lnkAddNewPerson.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkAddNewPerson_LinkClicked);
            // 
            // lnkAddNewMarriage
            // 
            this.lnkAddNewMarriage.AutoSize = true;
            this.lnkAddNewMarriage.Location = new System.Drawing.Point(47, 101);
            this.lnkAddNewMarriage.Name = "lnkAddNewMarriage";
            this.lnkAddNewMarriage.Size = new System.Drawing.Size(122, 17);
            this.lnkAddNewMarriage.TabIndex = 1;
            this.lnkAddNewMarriage.TabStop = true;
            this.lnkAddNewMarriage.Text = "Add new marriage";
            this.lnkAddNewMarriage.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkAddNewMarriage_LinkClicked);
            // 
            // lnkInsertMockupPersons
            // 
            this.lnkInsertMockupPersons.AutoSize = true;
            this.lnkInsertMockupPersons.Location = new System.Drawing.Point(47, 155);
            this.lnkInsertMockupPersons.Name = "lnkInsertMockupPersons";
            this.lnkInsertMockupPersons.Size = new System.Drawing.Size(151, 17);
            this.lnkInsertMockupPersons.TabIndex = 2;
            this.lnkInsertMockupPersons.TabStop = true;
            this.lnkInsertMockupPersons.Text = "Insert mockup persons";
            this.lnkInsertMockupPersons.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkInsertMockupPersons_LinkClicked);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(521, 230);
            this.Controls.Add(this.lnkInsertMockupPersons);
            this.Controls.Add(this.lnkAddNewMarriage);
            this.Controls.Add(this.lnkAddNewPerson);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel lnkAddNewPerson;
        private System.Windows.Forms.LinkLabel lnkAddNewMarriage;
        private System.Windows.Forms.LinkLabel lnkInsertMockupPersons;
    }
}

