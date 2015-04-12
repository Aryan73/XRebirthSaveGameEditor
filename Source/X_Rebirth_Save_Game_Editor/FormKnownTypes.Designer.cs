namespace X_Rebirth_Save_Game_Editor
{
    partial class FormKnownTypes
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
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.splitContainer4 = new System.Windows.Forms.SplitContainer();
            this.comboBoxKnownTypes = new System.Windows.Forms.ComboBox();
            this.buttonAddKnownTypeList = new System.Windows.Forms.Button();
            this.comboBoxUnknownTypesList = new System.Windows.Forms.ComboBox();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.splitContainer5 = new System.Windows.Forms.SplitContainer();
            this.listBoxKnownTypes = new System.Windows.Forms.ListBox();
            this.buttonAddKnownTypes = new System.Windows.Forms.Button();
            this.listBoxUnknownTypes = new System.Windows.Forms.ListBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).BeginInit();
            this.splitContainer4.Panel1.SuspendLayout();
            this.splitContainer4.Panel2.SuspendLayout();
            this.splitContainer4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer5)).BeginInit();
            this.splitContainer5.Panel1.SuspendLayout();
            this.splitContainer5.Panel2.SuspendLayout();
            this.splitContainer5.SuspendLayout();
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
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer3);
            this.splitContainer1.Size = new System.Drawing.Size(624, 437);
            this.splitContainer1.SplitterDistance = 25;
            this.splitContainer1.TabIndex = 0;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.splitContainer4);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.comboBoxUnknownTypesList);
            this.splitContainer2.Size = new System.Drawing.Size(624, 25);
            this.splitContainer2.SplitterDistance = 391;
            this.splitContainer2.TabIndex = 0;
            // 
            // splitContainer4
            // 
            this.splitContainer4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer4.Location = new System.Drawing.Point(0, 0);
            this.splitContainer4.Name = "splitContainer4";
            // 
            // splitContainer4.Panel1
            // 
            this.splitContainer4.Panel1.Controls.Add(this.comboBoxKnownTypes);
            // 
            // splitContainer4.Panel2
            // 
            this.splitContainer4.Panel2.Controls.Add(this.buttonAddKnownTypeList);
            this.splitContainer4.Size = new System.Drawing.Size(391, 25);
            this.splitContainer4.SplitterDistance = 360;
            this.splitContainer4.TabIndex = 0;
            // 
            // comboBoxKnownTypes
            // 
            this.comboBoxKnownTypes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBoxKnownTypes.FormattingEnabled = true;
            this.comboBoxKnownTypes.Location = new System.Drawing.Point(0, 0);
            this.comboBoxKnownTypes.Name = "comboBoxKnownTypes";
            this.comboBoxKnownTypes.Size = new System.Drawing.Size(360, 21);
            this.comboBoxKnownTypes.TabIndex = 24;
            this.toolTip1.SetToolTip(this.comboBoxKnownTypes, "Select a known type category");
            this.comboBoxKnownTypes.DropDown += new System.EventHandler(this.comboBoxKnownTypes_DropDown);
            this.comboBoxKnownTypes.TextChanged += new System.EventHandler(this.comboBoxKnownTypes_TextChanged);
            // 
            // buttonAddKnownTypeList
            // 
            this.buttonAddKnownTypeList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonAddKnownTypeList.Location = new System.Drawing.Point(0, 0);
            this.buttonAddKnownTypeList.Name = "buttonAddKnownTypeList";
            this.buttonAddKnownTypeList.Size = new System.Drawing.Size(27, 25);
            this.buttonAddKnownTypeList.TabIndex = 28;
            this.buttonAddKnownTypeList.Text = "<";
            this.toolTip1.SetToolTip(this.buttonAddKnownTypeList, "Add the selected unknown type category on the right to the known type categories " +
        "on the left.");
            this.buttonAddKnownTypeList.UseVisualStyleBackColor = true;
            this.buttonAddKnownTypeList.Click += new System.EventHandler(this.buttonAddKnownTypeList_Click);
            // 
            // comboBoxUnknownTypesList
            // 
            this.comboBoxUnknownTypesList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBoxUnknownTypesList.FormattingEnabled = true;
            this.comboBoxUnknownTypesList.Location = new System.Drawing.Point(0, 0);
            this.comboBoxUnknownTypesList.Name = "comboBoxUnknownTypesList";
            this.comboBoxUnknownTypesList.Size = new System.Drawing.Size(229, 21);
            this.comboBoxUnknownTypesList.TabIndex = 26;
            this.toolTip1.SetToolTip(this.comboBoxUnknownTypesList, "Select an unkown type category");
            this.comboBoxUnknownTypesList.DropDown += new System.EventHandler(this.comboBoxUnknownTypesList_DropDown);
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.splitContainer5);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.listBoxUnknownTypes);
            this.splitContainer3.Size = new System.Drawing.Size(624, 408);
            this.splitContainer3.SplitterDistance = 390;
            this.splitContainer3.TabIndex = 0;
            // 
            // splitContainer5
            // 
            this.splitContainer5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer5.Location = new System.Drawing.Point(0, 0);
            this.splitContainer5.Name = "splitContainer5";
            // 
            // splitContainer5.Panel1
            // 
            this.splitContainer5.Panel1.Controls.Add(this.listBoxKnownTypes);
            // 
            // splitContainer5.Panel2
            // 
            this.splitContainer5.Panel2.Controls.Add(this.buttonAddKnownTypes);
            this.splitContainer5.Size = new System.Drawing.Size(390, 408);
            this.splitContainer5.SplitterDistance = 358;
            this.splitContainer5.TabIndex = 0;
            // 
            // listBoxKnownTypes
            // 
            this.listBoxKnownTypes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxKnownTypes.FormattingEnabled = true;
            this.listBoxKnownTypes.Location = new System.Drawing.Point(0, 0);
            this.listBoxKnownTypes.Name = "listBoxKnownTypes";
            this.listBoxKnownTypes.Size = new System.Drawing.Size(358, 408);
            this.listBoxKnownTypes.TabIndex = 25;
            // 
            // buttonAddKnownTypes
            // 
            this.buttonAddKnownTypes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonAddKnownTypes.Location = new System.Drawing.Point(0, 0);
            this.buttonAddKnownTypes.Name = "buttonAddKnownTypes";
            this.buttonAddKnownTypes.Size = new System.Drawing.Size(28, 408);
            this.buttonAddKnownTypes.TabIndex = 29;
            this.buttonAddKnownTypes.Text = "<";
            this.toolTip1.SetToolTip(this.buttonAddKnownTypes, "Moves items selcted  on the left (Unknown types) to the right (Known Types)");
            this.buttonAddKnownTypes.UseVisualStyleBackColor = true;
            this.buttonAddKnownTypes.Click += new System.EventHandler(this.buttonAddKnownTypes_Click);
            // 
            // listBoxUnknownTypes
            // 
            this.listBoxUnknownTypes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxUnknownTypes.FormattingEnabled = true;
            this.listBoxUnknownTypes.Location = new System.Drawing.Point(0, 0);
            this.listBoxUnknownTypes.Name = "listBoxUnknownTypes";
            this.listBoxUnknownTypes.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.listBoxUnknownTypes.Size = new System.Drawing.Size(230, 408);
            this.listBoxUnknownTypes.TabIndex = 27;
            // 
            // FormKnownTypes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 437);
            this.Controls.Add(this.splitContainer1);
            this.Name = "FormKnownTypes";
            this.Text = "FormKnownTypes";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.splitContainer4.Panel1.ResumeLayout(false);
            this.splitContainer4.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).EndInit();
            this.splitContainer4.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.splitContainer5.Panel1.ResumeLayout(false);
            this.splitContainer5.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer5)).EndInit();
            this.splitContainer5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.SplitContainer splitContainer4;
        private System.Windows.Forms.SplitContainer splitContainer5;
        private System.Windows.Forms.ComboBox comboBoxKnownTypes;
        private System.Windows.Forms.Button buttonAddKnownTypeList;
        private System.Windows.Forms.ComboBox comboBoxUnknownTypesList;
        private System.Windows.Forms.ListBox listBoxKnownTypes;
        private System.Windows.Forms.ListBox listBoxUnknownTypes;
        private System.Windows.Forms.Button buttonAddKnownTypes;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}