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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.FillCargoNeeded = new System.Windows.Forms.Button();
            this.dataGridNeeded = new System.Windows.Forms.DataGridView();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridNeeded)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(246, 575);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Cargo";
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
    }
}