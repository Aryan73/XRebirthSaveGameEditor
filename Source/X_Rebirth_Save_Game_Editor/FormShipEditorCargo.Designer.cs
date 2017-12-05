namespace X_Rebirth_Save_Game_Editor
{
    partial class FormShipEditorCargo
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBoxCargoType = new System.Windows.Forms.TextBox();
            this.buttonCargoDelete = new System.Windows.Forms.Button();
            this.buttonCargoAdd = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.comboBoxCargo = new System.Windows.Forms.ComboBox();
            this.textBoxCargo = new System.Windows.Forms.TextBox();
            this.dataGridViewCargo = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.FillCargoNeeded = new System.Windows.Forms.Button();
            this.dataGridNeeded = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCargo)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridNeeded)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBoxCargoType);
            this.groupBox1.Controls.Add(this.buttonCargoDelete);
            this.groupBox1.Controls.Add(this.buttonCargoAdd);
            this.groupBox1.Controls.Add(this.splitContainer1);
            this.groupBox1.Controls.Add(this.dataGridViewCargo);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(246, 575);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Cargo";
            // 
            // textBoxCargoType
            // 
            this.textBoxCargoType.Enabled = false;
            this.textBoxCargoType.Location = new System.Drawing.Point(3, 16);
            this.textBoxCargoType.Name = "textBoxCargoType";
            this.textBoxCargoType.Size = new System.Drawing.Size(240, 20);
            this.textBoxCargoType.TabIndex = 4;
            // 
            // buttonCargoDelete
            // 
            this.buttonCargoDelete.Location = new System.Drawing.Point(3, 541);
            this.buttonCargoDelete.Name = "buttonCargoDelete";
            this.buttonCargoDelete.Size = new System.Drawing.Size(51, 23);
            this.buttonCargoDelete.TabIndex = 3;
            this.buttonCargoDelete.Text = "Delete";
            this.buttonCargoDelete.UseVisualStyleBackColor = true;
            // 
            // buttonCargoAdd
            // 
            this.buttonCargoAdd.Location = new System.Drawing.Point(3, 509);
            this.buttonCargoAdd.Name = "buttonCargoAdd";
            this.buttonCargoAdd.Size = new System.Drawing.Size(51, 23);
            this.buttonCargoAdd.TabIndex = 2;
            this.buttonCargoAdd.Text = "Add";
            this.buttonCargoAdd.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Location = new System.Drawing.Point(60, 502);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.comboBoxCargo);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.textBoxCargo);
            this.splitContainer1.Size = new System.Drawing.Size(180, 67);
            this.splitContainer1.SplitterDistance = 33;
            this.splitContainer1.TabIndex = 1;
            // 
            // comboBoxCargo
            // 
            this.comboBoxCargo.FormattingEnabled = true;
            this.comboBoxCargo.Location = new System.Drawing.Point(0, 9);
            this.comboBoxCargo.Name = "comboBoxCargo";
            this.comboBoxCargo.Size = new System.Drawing.Size(180, 21);
            this.comboBoxCargo.TabIndex = 0;
            // 
            // textBoxCargo
            // 
            this.textBoxCargo.Location = new System.Drawing.Point(0, 4);
            this.textBoxCargo.Name = "textBoxCargo";
            this.textBoxCargo.Size = new System.Drawing.Size(180, 20);
            this.textBoxCargo.TabIndex = 0;
            // 
            // dataGridViewCargo
            // 
            this.dataGridViewCargo.AllowUserToAddRows = false;
            this.dataGridViewCargo.AllowUserToDeleteRows = false;
            this.dataGridViewCargo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCargo.Location = new System.Drawing.Point(3, 41);
            this.dataGridViewCargo.Name = "dataGridViewCargo";
            this.dataGridViewCargo.ReadOnly = true;
            this.dataGridViewCargo.Size = new System.Drawing.Size(240, 150);
            this.dataGridViewCargo.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox2.Location = new System.Drawing.Point(246, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(246, 575);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Fuel";
            // 
            // groupBox3
            // 
            this.groupBox3.AutoSize = true;
            this.groupBox3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox3.Controls.Add(this.FillCargoNeeded);
            this.groupBox3.Controls.Add(this.dataGridNeeded);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox3.Location = new System.Drawing.Point(492, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(246, 575);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Needed ressources (Construction Vessel)";
            // 
            // FillCargoNeeded
            // 
            this.FillCargoNeeded.Location = new System.Drawing.Point(7, 253);
            this.FillCargoNeeded.Name = "FillCargoNeeded";
            this.FillCargoNeeded.Size = new System.Drawing.Size(233, 23);
            this.FillCargoNeeded.TabIndex = 1;
            this.FillCargoNeeded.Text = "Add ressources to cargo";
            this.FillCargoNeeded.UseVisualStyleBackColor = true;
            this.FillCargoNeeded.Click += new System.EventHandler(this.FillCargoNeeded_Click);
            // 
            // dataGridNeeded
            // 
            this.dataGridNeeded.AllowUserToAddRows = false;
            this.dataGridNeeded.AllowUserToDeleteRows = false;
            this.dataGridNeeded.AllowUserToOrderColumns = true;
            this.dataGridNeeded.AllowUserToResizeColumns = false;
            this.dataGridNeeded.AllowUserToResizeRows = false;
            this.dataGridNeeded.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridNeeded.ColumnHeadersVisible = false;
            this.dataGridNeeded.Dock = System.Windows.Forms.DockStyle.Top;
            this.dataGridNeeded.Location = new System.Drawing.Point(3, 16);
            this.dataGridNeeded.MultiSelect = false;
            this.dataGridNeeded.Name = "dataGridNeeded";
            this.dataGridNeeded.RowHeadersVisible = false;
            this.dataGridNeeded.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridNeeded.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridNeeded.Size = new System.Drawing.Size(240, 226);
            this.dataGridNeeded.TabIndex = 0;
            // 
            // FormShipEditorCargo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(764, 575);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "FormShipEditorCargo";
            this.Text = "FormShipEditorCargo";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCargo)).EndInit();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridNeeded)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button FillCargoNeeded;
        private System.Windows.Forms.DataGridView dataGridNeeded;
        private System.Windows.Forms.DataGridView dataGridViewCargo;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ComboBox comboBoxCargo;
        private System.Windows.Forms.TextBox textBoxCargo;
        private System.Windows.Forms.Button buttonCargoDelete;
        private System.Windows.Forms.Button buttonCargoAdd;
        private System.Windows.Forms.TextBox textBoxCargoType;
    }
}