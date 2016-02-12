namespace FamilyTree.GUI
{
    partial class MarriageUI
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
            this.label9 = new System.Windows.Forms.Label();
            this.txtHusband = new System.Windows.Forms.TextBox();
            this.btnSelectHusband = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtWife = new System.Windows.Forms.TextBox();
            this.btnSelectWife = new System.Windows.Forms.Button();
            this.chkUnknownDate = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.btnSaveToDb = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(13, 8);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(69, 17);
            this.label9.TabIndex = 23;
            this.label9.Text = "Husband:";
            // 
            // txtHusband
            // 
            this.txtHusband.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtHusband.Enabled = false;
            this.txtHusband.Location = new System.Drawing.Point(12, 31);
            this.txtHusband.Name = "txtHusband";
            this.txtHusband.Size = new System.Drawing.Size(473, 22);
            this.txtHusband.TabIndex = 22;
            // 
            // btnSelectHusband
            // 
            this.btnSelectHusband.Location = new System.Drawing.Point(13, 59);
            this.btnSelectHusband.Name = "btnSelectHusband";
            this.btnSelectHusband.Size = new System.Drawing.Size(126, 32);
            this.btnSelectHusband.TabIndex = 21;
            this.btnSelectHusband.Text = "Select partner";
            this.btnSelectHusband.UseVisualStyleBackColor = true;
            this.btnSelectHusband.Click += new System.EventHandler(this.btnSelectHusband_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 126);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 17);
            this.label1.TabIndex = 26;
            this.label1.Text = "Wife:";
            // 
            // txtWife
            // 
            this.txtWife.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtWife.Enabled = false;
            this.txtWife.Location = new System.Drawing.Point(12, 149);
            this.txtWife.Name = "txtWife";
            this.txtWife.Size = new System.Drawing.Size(473, 22);
            this.txtWife.TabIndex = 25;
            // 
            // btnSelectWife
            // 
            this.btnSelectWife.Location = new System.Drawing.Point(13, 177);
            this.btnSelectWife.Name = "btnSelectWife";
            this.btnSelectWife.Size = new System.Drawing.Size(126, 32);
            this.btnSelectWife.TabIndex = 24;
            this.btnSelectWife.Text = "Select partner";
            this.btnSelectWife.UseVisualStyleBackColor = true;
            this.btnSelectWife.Click += new System.EventHandler(this.btnSelectWife_Click);
            // 
            // chkUnknownDate
            // 
            this.chkUnknownDate.AutoSize = true;
            this.chkUnknownDate.Checked = true;
            this.chkUnknownDate.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkUnknownDate.Location = new System.Drawing.Point(110, 251);
            this.chkUnknownDate.Name = "chkUnknownDate";
            this.chkUnknownDate.Size = new System.Drawing.Size(88, 21);
            this.chkUnknownDate.TabIndex = 29;
            this.chkUnknownDate.Text = "Unknown";
            this.chkUnknownDate.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(14, 252);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(42, 17);
            this.label8.TabIndex = 28;
            this.label8.Text = "Date:";
            // 
            // dtpDate
            // 
            this.dtpDate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpDate.Enabled = false;
            this.dtpDate.Location = new System.Drawing.Point(13, 272);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(473, 22);
            this.dtpDate.TabIndex = 27;
            // 
            // btnSaveToDb
            // 
            this.btnSaveToDb.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveToDb.Location = new System.Drawing.Point(360, 493);
            this.btnSaveToDb.Name = "btnSaveToDb";
            this.btnSaveToDb.Size = new System.Drawing.Size(126, 32);
            this.btnSaveToDb.TabIndex = 30;
            this.btnSaveToDb.Text = "Save";
            this.btnSaveToDb.UseVisualStyleBackColor = true;
            // 
            // MarriageUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(498, 537);
            this.Controls.Add(this.btnSaveToDb);
            this.Controls.Add(this.chkUnknownDate);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.dtpDate);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtWife);
            this.Controls.Add(this.btnSelectWife);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtHusband);
            this.Controls.Add(this.btnSelectHusband);
            this.Name = "MarriageUI";
            this.Text = "MarriageUI";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtHusband;
        private System.Windows.Forms.Button btnSelectHusband;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtWife;
        private System.Windows.Forms.Button btnSelectWife;
        private System.Windows.Forms.CheckBox chkUnknownDate;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.Button btnSaveToDb;
    }
}