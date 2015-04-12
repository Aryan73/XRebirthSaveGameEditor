namespace X_Rebirth_Save_Game_Editor
{
    partial class FormFactions
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
            this.components = new System.ComponentModel.Container();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxFaction = new System.Windows.Forms.ComboBox();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.groupBoxRelations = new System.Windows.Forms.GroupBox();
            this.splitContainerRelations = new System.Windows.Forms.SplitContainer();
            this.dataGridViewRelations = new System.Windows.Forms.DataGridView();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.splitContainer4 = new System.Windows.Forms.SplitContainer();
            this.buttonAddRelation = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.splitContainer5 = new System.Windows.Forms.SplitContainer();
            this.buttonRemoveRelation = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.groupBoxLicenses = new System.Windows.Forms.GroupBox();
            this.splitContainerLicenses = new System.Windows.Forms.SplitContainer();
            this.dataGridViewLicenses = new System.Windows.Forms.DataGridView();
            this.splitContainer6 = new System.Windows.Forms.SplitContainer();
            this.splitContainer7 = new System.Windows.Forms.SplitContainer();
            this.buttonAddLicense = new System.Windows.Forms.Button();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.splitContainer8 = new System.Windows.Forms.SplitContainer();
            this.buttonRemoveLicense = new System.Windows.Forms.Button();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.groupBoxRelations.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerRelations)).BeginInit();
            this.splitContainerRelations.Panel1.SuspendLayout();
            this.splitContainerRelations.Panel2.SuspendLayout();
            this.splitContainerRelations.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRelations)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).BeginInit();
            this.splitContainer4.Panel1.SuspendLayout();
            this.splitContainer4.Panel2.SuspendLayout();
            this.splitContainer4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer5)).BeginInit();
            this.splitContainer5.Panel1.SuspendLayout();
            this.splitContainer5.Panel2.SuspendLayout();
            this.splitContainer5.SuspendLayout();
            this.groupBoxLicenses.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerLicenses)).BeginInit();
            this.splitContainerLicenses.Panel1.SuspendLayout();
            this.splitContainerLicenses.Panel2.SuspendLayout();
            this.splitContainerLicenses.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLicenses)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer6)).BeginInit();
            this.splitContainer6.Panel1.SuspendLayout();
            this.splitContainer6.Panel2.SuspendLayout();
            this.splitContainer6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer7)).BeginInit();
            this.splitContainer7.Panel1.SuspendLayout();
            this.splitContainer7.Panel2.SuspendLayout();
            this.splitContainer7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer8)).BeginInit();
            this.splitContainer8.Panel1.SuspendLayout();
            this.splitContainer8.Panel2.SuspendLayout();
            this.splitContainer8.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.SystemColors.Window;
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.comboBoxFaction);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(751, 588);
            this.splitContainer1.SplitterDistance = 25;
            this.splitContainer1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(173, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Select a faction to edit it\'s relations:";
            // 
            // comboBoxFaction
            // 
            this.comboBoxFaction.FormattingEnabled = true;
            this.comboBoxFaction.Location = new System.Drawing.Point(182, 0);
            this.comboBoxFaction.Name = "comboBoxFaction";
            this.comboBoxFaction.Size = new System.Drawing.Size(184, 21);
            this.comboBoxFaction.TabIndex = 1;
            this.comboBoxFaction.DropDown += new System.EventHandler(this.comboBoxFaction_DropDown);
            this.comboBoxFaction.SelectedIndexChanged += new System.EventHandler(this.comboBoxFaction_SelectedIndexChanged);
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.groupBoxRelations);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.groupBoxLicenses);
            this.splitContainer2.Size = new System.Drawing.Size(751, 559);
            this.splitContainer2.SplitterDistance = 369;
            this.splitContainer2.TabIndex = 0;
            // 
            // groupBoxRelations
            // 
            this.groupBoxRelations.Controls.Add(this.splitContainerRelations);
            this.groupBoxRelations.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxRelations.Location = new System.Drawing.Point(0, 0);
            this.groupBoxRelations.Name = "groupBoxRelations";
            this.groupBoxRelations.Size = new System.Drawing.Size(369, 559);
            this.groupBoxRelations.TabIndex = 1;
            this.groupBoxRelations.TabStop = false;
            this.groupBoxRelations.Text = "Relations";
            // 
            // splitContainerRelations
            // 
            this.splitContainerRelations.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerRelations.Location = new System.Drawing.Point(3, 16);
            this.splitContainerRelations.Name = "splitContainerRelations";
            this.splitContainerRelations.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerRelations.Panel1
            // 
            this.splitContainerRelations.Panel1.Controls.Add(this.dataGridViewRelations);
            // 
            // splitContainerRelations.Panel2
            // 
            this.splitContainerRelations.Panel2.Controls.Add(this.splitContainer3);
            this.splitContainerRelations.Size = new System.Drawing.Size(363, 540);
            this.splitContainerRelations.SplitterDistance = 432;
            this.splitContainerRelations.TabIndex = 0;
            // 
            // dataGridViewRelations
            // 
            this.dataGridViewRelations.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridViewRelations.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewRelations.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewRelations.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewRelations.Name = "dataGridViewRelations";
            this.dataGridViewRelations.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewRelations.Size = new System.Drawing.Size(363, 432);
            this.dataGridViewRelations.TabIndex = 0;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.splitContainer4);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.splitContainer5);
            this.splitContainer3.Size = new System.Drawing.Size(363, 104);
            this.splitContainer3.SplitterDistance = 53;
            this.splitContainer3.TabIndex = 0;
            // 
            // splitContainer4
            // 
            this.splitContainer4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer4.Location = new System.Drawing.Point(0, 0);
            this.splitContainer4.Name = "splitContainer4";
            // 
            // splitContainer4.Panel1
            // 
            this.splitContainer4.Panel1.Controls.Add(this.buttonAddRelation);
            // 
            // splitContainer4.Panel2
            // 
            this.splitContainer4.Panel2.Controls.Add(this.comboBox1);
            this.splitContainer4.Size = new System.Drawing.Size(363, 53);
            this.splitContainer4.SplitterDistance = 121;
            this.splitContainer4.TabIndex = 0;
            // 
            // buttonAddRelation
            // 
            this.buttonAddRelation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonAddRelation.Location = new System.Drawing.Point(0, 0);
            this.buttonAddRelation.Name = "buttonAddRelation";
            this.buttonAddRelation.Size = new System.Drawing.Size(121, 53);
            this.buttonAddRelation.TabIndex = 0;
            this.buttonAddRelation.Text = "Add";
            this.buttonAddRelation.UseVisualStyleBackColor = true;
            this.buttonAddRelation.Click += new System.EventHandler(this.buttonAddRelation_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(0, 0);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(238, 21);
            this.comboBox1.TabIndex = 0;
            // 
            // splitContainer5
            // 
            this.splitContainer5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer5.Location = new System.Drawing.Point(0, 0);
            this.splitContainer5.Name = "splitContainer5";
            // 
            // splitContainer5.Panel1
            // 
            this.splitContainer5.Panel1.Controls.Add(this.buttonRemoveRelation);
            // 
            // splitContainer5.Panel2
            // 
            this.splitContainer5.Panel2.Controls.Add(this.textBox1);
            this.splitContainer5.Size = new System.Drawing.Size(363, 47);
            this.splitContainer5.SplitterDistance = 121;
            this.splitContainer5.TabIndex = 0;
            // 
            // buttonRemoveRelation
            // 
            this.buttonRemoveRelation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonRemoveRelation.Location = new System.Drawing.Point(0, 0);
            this.buttonRemoveRelation.Name = "buttonRemoveRelation";
            this.buttonRemoveRelation.Size = new System.Drawing.Size(121, 47);
            this.buttonRemoveRelation.TabIndex = 0;
            this.buttonRemoveRelation.Text = "Remove row";
            this.buttonRemoveRelation.UseVisualStyleBackColor = true;
            this.buttonRemoveRelation.Click += new System.EventHandler(this.buttonRemoveRelation_Click);
            // 
            // textBox1
            // 
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox1.Location = new System.Drawing.Point(0, 0);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(238, 20);
            this.textBox1.TabIndex = 0;
            // 
            // groupBoxLicenses
            // 
            this.groupBoxLicenses.Controls.Add(this.splitContainerLicenses);
            this.groupBoxLicenses.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxLicenses.Location = new System.Drawing.Point(0, 0);
            this.groupBoxLicenses.Name = "groupBoxLicenses";
            this.groupBoxLicenses.Size = new System.Drawing.Size(378, 559);
            this.groupBoxLicenses.TabIndex = 1;
            this.groupBoxLicenses.TabStop = false;
            this.groupBoxLicenses.Text = "Licenses";
            // 
            // splitContainerLicenses
            // 
            this.splitContainerLicenses.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerLicenses.Location = new System.Drawing.Point(3, 16);
            this.splitContainerLicenses.Name = "splitContainerLicenses";
            this.splitContainerLicenses.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerLicenses.Panel1
            // 
            this.splitContainerLicenses.Panel1.Controls.Add(this.dataGridViewLicenses);
            // 
            // splitContainerLicenses.Panel2
            // 
            this.splitContainerLicenses.Panel2.Controls.Add(this.splitContainer6);
            this.splitContainerLicenses.Size = new System.Drawing.Size(372, 540);
            this.splitContainerLicenses.SplitterDistance = 429;
            this.splitContainerLicenses.TabIndex = 0;
            // 
            // dataGridViewLicenses
            // 
            this.dataGridViewLicenses.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridViewLicenses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewLicenses.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewLicenses.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewLicenses.MultiSelect = false;
            this.dataGridViewLicenses.Name = "dataGridViewLicenses";
            this.dataGridViewLicenses.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewLicenses.Size = new System.Drawing.Size(372, 429);
            this.dataGridViewLicenses.TabIndex = 1;
            // 
            // splitContainer6
            // 
            this.splitContainer6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer6.Location = new System.Drawing.Point(0, 0);
            this.splitContainer6.Name = "splitContainer6";
            this.splitContainer6.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer6.Panel1
            // 
            this.splitContainer6.Panel1.Controls.Add(this.splitContainer7);
            // 
            // splitContainer6.Panel2
            // 
            this.splitContainer6.Panel2.Controls.Add(this.splitContainer8);
            this.splitContainer6.Size = new System.Drawing.Size(372, 107);
            this.splitContainer6.SplitterDistance = 52;
            this.splitContainer6.TabIndex = 0;
            // 
            // splitContainer7
            // 
            this.splitContainer7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer7.Location = new System.Drawing.Point(0, 0);
            this.splitContainer7.Name = "splitContainer7";
            // 
            // splitContainer7.Panel1
            // 
            this.splitContainer7.Panel1.Controls.Add(this.buttonAddLicense);
            // 
            // splitContainer7.Panel2
            // 
            this.splitContainer7.Panel2.Controls.Add(this.comboBox2);
            this.splitContainer7.Size = new System.Drawing.Size(372, 52);
            this.splitContainer7.SplitterDistance = 124;
            this.splitContainer7.TabIndex = 0;
            // 
            // buttonAddLicense
            // 
            this.buttonAddLicense.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonAddLicense.Location = new System.Drawing.Point(0, 0);
            this.buttonAddLicense.Name = "buttonAddLicense";
            this.buttonAddLicense.Size = new System.Drawing.Size(124, 52);
            this.buttonAddLicense.TabIndex = 0;
            this.buttonAddLicense.Text = "Add";
            this.buttonAddLicense.UseVisualStyleBackColor = true;
            this.buttonAddLicense.Click += new System.EventHandler(this.buttonAddLicense_Click);
            // 
            // comboBox2
            // 
            this.comboBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(0, 0);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(244, 21);
            this.comboBox2.TabIndex = 0;
            this.comboBox2.DropDown += new System.EventHandler(this.comboBox2_DropDown);
            // 
            // splitContainer8
            // 
            this.splitContainer8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer8.Location = new System.Drawing.Point(0, 0);
            this.splitContainer8.Name = "splitContainer8";
            // 
            // splitContainer8.Panel1
            // 
            this.splitContainer8.Panel1.Controls.Add(this.buttonRemoveLicense);
            // 
            // splitContainer8.Panel2
            // 
            this.splitContainer8.Panel2.Controls.Add(this.comboBox3);
            this.splitContainer8.Size = new System.Drawing.Size(372, 51);
            this.splitContainer8.SplitterDistance = 124;
            this.splitContainer8.TabIndex = 0;
            // 
            // buttonRemoveLicense
            // 
            this.buttonRemoveLicense.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonRemoveLicense.Location = new System.Drawing.Point(0, 0);
            this.buttonRemoveLicense.Name = "buttonRemoveLicense";
            this.buttonRemoveLicense.Size = new System.Drawing.Size(124, 51);
            this.buttonRemoveLicense.TabIndex = 0;
            this.buttonRemoveLicense.Text = "Remove row";
            this.buttonRemoveLicense.UseVisualStyleBackColor = true;
            this.buttonRemoveLicense.Click += new System.EventHandler(this.buttonRemoveLicense_Click);
            // 
            // comboBox3
            // 
            this.comboBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Location = new System.Drawing.Point(0, 0);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(244, 21);
            this.comboBox3.TabIndex = 1;
            this.comboBox3.DropDown += new System.EventHandler(this.comboBox3_DropDown);
            // 
            // FormFactions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(751, 588);
            this.Controls.Add(this.splitContainer1);
            this.Name = "FormFactions";
            this.Text = "FormFactions";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.groupBoxRelations.ResumeLayout(false);
            this.splitContainerRelations.Panel1.ResumeLayout(false);
            this.splitContainerRelations.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerRelations)).EndInit();
            this.splitContainerRelations.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRelations)).EndInit();
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.splitContainer4.Panel1.ResumeLayout(false);
            this.splitContainer4.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).EndInit();
            this.splitContainer4.ResumeLayout(false);
            this.splitContainer5.Panel1.ResumeLayout(false);
            this.splitContainer5.Panel2.ResumeLayout(false);
            this.splitContainer5.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer5)).EndInit();
            this.splitContainer5.ResumeLayout(false);
            this.groupBoxLicenses.ResumeLayout(false);
            this.splitContainerLicenses.Panel1.ResumeLayout(false);
            this.splitContainerLicenses.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerLicenses)).EndInit();
            this.splitContainerLicenses.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLicenses)).EndInit();
            this.splitContainer6.Panel1.ResumeLayout(false);
            this.splitContainer6.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer6)).EndInit();
            this.splitContainer6.ResumeLayout(false);
            this.splitContainer7.Panel1.ResumeLayout(false);
            this.splitContainer7.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer7)).EndInit();
            this.splitContainer7.ResumeLayout(false);
            this.splitContainer8.Panel1.ResumeLayout(false);
            this.splitContainer8.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer8)).EndInit();
            this.splitContainer8.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.GroupBox groupBoxRelations;
        private System.Windows.Forms.SplitContainer splitContainerRelations;
        private System.Windows.Forms.DataGridView dataGridViewRelations;
        private System.Windows.Forms.GroupBox groupBoxLicenses;
        private System.Windows.Forms.SplitContainer splitContainerLicenses;
        private System.Windows.Forms.DataGridView dataGridViewLicenses;
        private System.Windows.Forms.ComboBox comboBoxFaction;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.SplitContainer splitContainer4;
        private System.Windows.Forms.Button buttonAddRelation;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.SplitContainer splitContainer5;
        private System.Windows.Forms.Button buttonRemoveRelation;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.SplitContainer splitContainer6;
        private System.Windows.Forms.SplitContainer splitContainer7;
        private System.Windows.Forms.Button buttonAddLicense;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.SplitContainer splitContainer8;
        private System.Windows.Forms.Button buttonRemoveLicense;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}