namespace X_Rebirth_Save_Game_Editor
{
    partial class FormStationEditorQueued
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
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.labelStationOwner = new System.Windows.Forms.Label();
            this.comboBoxShipOwner = new System.Windows.Forms.ComboBox();
            this.textBoxStationName = new System.Windows.Forms.TextBox();
            this.labelStationName = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(13, 13);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(178, 391);
            this.treeView1.TabIndex = 0;
            // 
            // labelStationOwner
            // 
            this.labelStationOwner.AutoSize = true;
            this.labelStationOwner.Location = new System.Drawing.Point(197, 66);
            this.labelStationOwner.Name = "labelStationOwner";
            this.labelStationOwner.Size = new System.Drawing.Size(65, 13);
            this.labelStationOwner.TabIndex = 11;
            this.labelStationOwner.Text = "Ship Owner:";
            // 
            // comboBoxShipOwner
            // 
            this.comboBoxShipOwner.FormattingEnabled = true;
            this.comboBoxShipOwner.Location = new System.Drawing.Point(200, 82);
            this.comboBoxShipOwner.Name = "comboBoxShipOwner";
            this.comboBoxShipOwner.Size = new System.Drawing.Size(331, 21);
            this.comboBoxShipOwner.TabIndex = 10;
            // 
            // textBoxStationName
            // 
            this.textBoxStationName.Location = new System.Drawing.Point(200, 29);
            this.textBoxStationName.Name = "textBoxStationName";
            this.textBoxStationName.Size = new System.Drawing.Size(331, 20);
            this.textBoxStationName.TabIndex = 9;
            // 
            // labelStationName
            // 
            this.labelStationName.AutoSize = true;
            this.labelStationName.Location = new System.Drawing.Point(197, 13);
            this.labelStationName.Name = "labelStationName";
            this.labelStationName.Size = new System.Drawing.Size(62, 13);
            this.labelStationName.TabIndex = 8;
            this.labelStationName.Text = "Ship Name:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(197, 120);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "Ship Status:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(200, 136);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(331, 20);
            this.textBox1.TabIndex = 16;
            // 
            // FormStationEditorQueued
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(543, 416);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelStationOwner);
            this.Controls.Add(this.comboBoxShipOwner);
            this.Controls.Add(this.textBoxStationName);
            this.Controls.Add(this.labelStationName);
            this.Controls.Add(this.treeView1);
            this.Name = "FormStationEditorQueued";
            this.Text = "Ships queued";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Label labelStationOwner;
        private System.Windows.Forms.ComboBox comboBoxShipOwner;
        private System.Windows.Forms.TextBox textBoxStationName;
        private System.Windows.Forms.Label labelStationName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
    }
}