namespace X_Rebirth_Save_Game_Editor
{
    partial class FormCatDatExport
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.splitContainerMain = new System.Windows.Forms.SplitContainer();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.splitContainerRight = new System.Windows.Forms.SplitContainer();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageFileList = new System.Windows.Forms.TabPage();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.tabPagePreview = new System.Windows.Forms.TabPage();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBoxFilters = new System.Windows.Forms.GroupBox();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.labelCatFilter = new System.Windows.Forms.Label();
            this.comboBoxCatFilter = new System.Windows.Forms.ComboBox();
            this.splitContainer4 = new System.Windows.Forms.SplitContainer();
            this.labelEndsWith = new System.Windows.Forms.Label();
            this.textBoxEndswith = new System.Windows.Forms.TextBox();
            this.textBoxContains = new System.Windows.Forms.TextBox();
            this.labelContains = new System.Windows.Forms.Label();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.groupBoxExport = new System.Windows.Forms.GroupBox();
            this.splitContainer5 = new System.Windows.Forms.SplitContainer();
            this.splitContainer6 = new System.Windows.Forms.SplitContainer();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonExport = new System.Windows.Forms.Button();
            this.splitContainer7 = new System.Windows.Forms.SplitContainer();
            this.textBoxExportLocation = new System.Windows.Forms.TextBox();
            this.buttonBrowse = new System.Windows.Forms.Button();
            this.groupBoxSearchInPreview = new System.Windows.Forms.GroupBox();
            this.buttonSearchInPreview = new System.Windows.Forms.Button();
            this.textBoxSearchInPreview = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).BeginInit();
            this.splitContainerMain.Panel1.SuspendLayout();
            this.splitContainerMain.Panel2.SuspendLayout();
            this.splitContainerMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerRight)).BeginInit();
            this.splitContainerRight.Panel1.SuspendLayout();
            this.splitContainerRight.Panel2.SuspendLayout();
            this.splitContainerRight.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPageFileList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tabPagePreview.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBoxFilters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).BeginInit();
            this.splitContainer4.Panel1.SuspendLayout();
            this.splitContainer4.Panel2.SuspendLayout();
            this.splitContainer4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.groupBoxExport.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer5)).BeginInit();
            this.splitContainer5.Panel1.SuspendLayout();
            this.splitContainer5.Panel2.SuspendLayout();
            this.splitContainer5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer6)).BeginInit();
            this.splitContainer6.Panel1.SuspendLayout();
            this.splitContainer6.Panel2.SuspendLayout();
            this.splitContainer6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer7)).BeginInit();
            this.splitContainer7.Panel1.SuspendLayout();
            this.splitContainer7.Panel2.SuspendLayout();
            this.splitContainer7.SuspendLayout();
            this.groupBoxSearchInPreview.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainerMain
            // 
            this.splitContainerMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerMain.Location = new System.Drawing.Point(0, 0);
            this.splitContainerMain.Name = "splitContainerMain";
            // 
            // splitContainerMain.Panel1
            // 
            this.splitContainerMain.Panel1.Controls.Add(this.treeView1);
            // 
            // splitContainerMain.Panel2
            // 
            this.splitContainerMain.Panel2.Controls.Add(this.splitContainerRight);
            this.splitContainerMain.Size = new System.Drawing.Size(1765, 878);
            this.splitContainerMain.SplitterDistance = 309;
            this.splitContainerMain.TabIndex = 0;
            // 
            // treeView1
            // 
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.Location = new System.Drawing.Point(0, 0);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(309, 878);
            this.treeView1.TabIndex = 0;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // splitContainerRight
            // 
            this.splitContainerRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerRight.Location = new System.Drawing.Point(0, 0);
            this.splitContainerRight.Name = "splitContainerRight";
            this.splitContainerRight.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerRight.Panel1
            // 
            this.splitContainerRight.Panel1.Controls.Add(this.tabControl1);
            // 
            // splitContainerRight.Panel2
            // 
            this.splitContainerRight.Panel2.Controls.Add(this.splitContainer1);
            this.splitContainerRight.Size = new System.Drawing.Size(1452, 878);
            this.splitContainerRight.SplitterDistance = 798;
            this.splitContainerRight.TabIndex = 0;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageFileList);
            this.tabControl1.Controls.Add(this.tabPagePreview);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1452, 798);
            this.tabControl1.TabIndex = 1;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            this.tabControl1.TabIndexChanged += new System.EventHandler(this.tabControl1_TabIndexChanged);
            // 
            // tabPageFileList
            // 
            this.tabPageFileList.Controls.Add(this.dataGridView1);
            this.tabPageFileList.Location = new System.Drawing.Point(4, 22);
            this.tabPageFileList.Name = "tabPageFileList";
            this.tabPageFileList.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageFileList.Size = new System.Drawing.Size(1444, 772);
            this.tabPageFileList.TabIndex = 0;
            this.tabPageFileList.Text = "File list";
            this.tabPageFileList.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 3);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1438, 766);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            this.dataGridView1.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseClick);
            // 
            // tabPagePreview
            // 
            this.tabPagePreview.Controls.Add(this.richTextBox1);
            this.tabPagePreview.Location = new System.Drawing.Point(4, 22);
            this.tabPagePreview.Name = "tabPagePreview";
            this.tabPagePreview.Padding = new System.Windows.Forms.Padding(3);
            this.tabPagePreview.Size = new System.Drawing.Size(1444, 772);
            this.tabPagePreview.TabIndex = 1;
            this.tabPagePreview.Text = "Preview (Textual files only, xml, xsd, etc.)";
            this.tabPagePreview.UseVisualStyleBackColor = true;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox1.Location = new System.Drawing.Point(3, 3);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(1438, 766);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBoxFilters);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(1452, 76);
            this.splitContainer1.SplitterDistance = 259;
            this.splitContainer1.TabIndex = 0;
            // 
            // groupBoxFilters
            // 
            this.groupBoxFilters.Controls.Add(this.splitContainer3);
            this.groupBoxFilters.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxFilters.Location = new System.Drawing.Point(0, 0);
            this.groupBoxFilters.Name = "groupBoxFilters";
            this.groupBoxFilters.Size = new System.Drawing.Size(259, 76);
            this.groupBoxFilters.TabIndex = 0;
            this.groupBoxFilters.TabStop = false;
            this.groupBoxFilters.Text = "Filters";
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(3, 16);
            this.splitContainer3.Name = "splitContainer3";
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.labelCatFilter);
            this.splitContainer3.Panel1.Controls.Add(this.comboBoxCatFilter);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.splitContainer4);
            this.splitContainer3.Size = new System.Drawing.Size(253, 57);
            this.splitContainer3.SplitterDistance = 52;
            this.splitContainer3.TabIndex = 0;
            // 
            // labelCatFilter
            // 
            this.labelCatFilter.AutoSize = true;
            this.labelCatFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelCatFilter.Location = new System.Drawing.Point(0, 0);
            this.labelCatFilter.Name = "labelCatFilter";
            this.labelCatFilter.Size = new System.Drawing.Size(48, 13);
            this.labelCatFilter.TabIndex = 0;
            this.labelCatFilter.Text = "Cat Filter";
            // 
            // comboBoxCatFilter
            // 
            this.comboBoxCatFilter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.comboBoxCatFilter.FormattingEnabled = true;
            this.comboBoxCatFilter.Location = new System.Drawing.Point(0, 36);
            this.comboBoxCatFilter.Name = "comboBoxCatFilter";
            this.comboBoxCatFilter.Size = new System.Drawing.Size(52, 21);
            this.comboBoxCatFilter.TabIndex = 1;
            this.comboBoxCatFilter.TextChanged += new System.EventHandler(this.textBox_TextChanged);
            // 
            // splitContainer4
            // 
            this.splitContainer4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer4.Location = new System.Drawing.Point(0, 0);
            this.splitContainer4.Name = "splitContainer4";
            // 
            // splitContainer4.Panel1
            // 
            this.splitContainer4.Panel1.Controls.Add(this.labelEndsWith);
            this.splitContainer4.Panel1.Controls.Add(this.textBoxEndswith);
            // 
            // splitContainer4.Panel2
            // 
            this.splitContainer4.Panel2.Controls.Add(this.textBoxContains);
            this.splitContainer4.Panel2.Controls.Add(this.labelContains);
            this.splitContainer4.Size = new System.Drawing.Size(197, 57);
            this.splitContainer4.SplitterDistance = 98;
            this.splitContainer4.TabIndex = 0;
            // 
            // labelEndsWith
            // 
            this.labelEndsWith.AutoSize = true;
            this.labelEndsWith.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelEndsWith.Location = new System.Drawing.Point(0, 0);
            this.labelEndsWith.Name = "labelEndsWith";
            this.labelEndsWith.Size = new System.Drawing.Size(77, 13);
            this.labelEndsWith.TabIndex = 2;
            this.labelEndsWith.Text = "Path ends with";
            // 
            // textBoxEndswith
            // 
            this.textBoxEndswith.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.textBoxEndswith.Location = new System.Drawing.Point(0, 37);
            this.textBoxEndswith.Name = "textBoxEndswith";
            this.textBoxEndswith.Size = new System.Drawing.Size(98, 20);
            this.textBoxEndswith.TabIndex = 3;
            this.textBoxEndswith.TextChanged += new System.EventHandler(this.textBox_TextChanged);
            // 
            // textBoxContains
            // 
            this.textBoxContains.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.textBoxContains.Location = new System.Drawing.Point(0, 37);
            this.textBoxContains.Name = "textBoxContains";
            this.textBoxContains.Size = new System.Drawing.Size(95, 20);
            this.textBoxContains.TabIndex = 5;
            this.textBoxContains.TextChanged += new System.EventHandler(this.textBox_TextChanged);
            // 
            // labelContains
            // 
            this.labelContains.AutoSize = true;
            this.labelContains.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelContains.Location = new System.Drawing.Point(0, 0);
            this.labelContains.Name = "labelContains";
            this.labelContains.Size = new System.Drawing.Size(72, 13);
            this.labelContains.TabIndex = 4;
            this.labelContains.Text = "Path contains";
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.groupBoxExport);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.groupBoxSearchInPreview);
            this.splitContainer2.Size = new System.Drawing.Size(1189, 76);
            this.splitContainer2.SplitterDistance = 721;
            this.splitContainer2.TabIndex = 0;
            // 
            // groupBoxExport
            // 
            this.groupBoxExport.Controls.Add(this.splitContainer5);
            this.groupBoxExport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxExport.Location = new System.Drawing.Point(0, 0);
            this.groupBoxExport.Name = "groupBoxExport";
            this.groupBoxExport.Size = new System.Drawing.Size(721, 76);
            this.groupBoxExport.TabIndex = 1;
            this.groupBoxExport.TabStop = false;
            this.groupBoxExport.Text = "Export, To be processed: 0, Currently exporting:";
            // 
            // splitContainer5
            // 
            this.splitContainer5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer5.Location = new System.Drawing.Point(3, 16);
            this.splitContainer5.Name = "splitContainer5";
            this.splitContainer5.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer5.Panel1
            // 
            this.splitContainer5.Panel1.Controls.Add(this.splitContainer6);
            // 
            // splitContainer5.Panel2
            // 
            this.splitContainer5.Panel2.Controls.Add(this.splitContainer7);
            this.splitContainer5.Size = new System.Drawing.Size(715, 57);
            this.splitContainer5.SplitterDistance = 25;
            this.splitContainer5.TabIndex = 0;
            // 
            // splitContainer6
            // 
            this.splitContainer6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer6.Location = new System.Drawing.Point(0, 0);
            this.splitContainer6.Name = "splitContainer6";
            // 
            // splitContainer6.Panel1
            // 
            this.splitContainer6.Panel1.Controls.Add(this.label1);
            // 
            // splitContainer6.Panel2
            // 
            this.splitContainer6.Panel2.Controls.Add(this.buttonExport);
            this.splitContainer6.Size = new System.Drawing.Size(715, 25);
            this.splitContainer6.SplitterDistance = 81;
            this.splitContainer6.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Export location:";
            // 
            // buttonExport
            // 
            this.buttonExport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonExport.Location = new System.Drawing.Point(0, 0);
            this.buttonExport.Name = "buttonExport";
            this.buttonExport.Size = new System.Drawing.Size(630, 25);
            this.buttonExport.TabIndex = 3;
            this.buttonExport.Text = "Add Selected to async export";
            this.buttonExport.UseVisualStyleBackColor = true;
            this.buttonExport.Click += new System.EventHandler(this.buttonExport_Click);
            // 
            // splitContainer7
            // 
            this.splitContainer7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer7.Location = new System.Drawing.Point(0, 0);
            this.splitContainer7.Name = "splitContainer7";
            // 
            // splitContainer7.Panel1
            // 
            this.splitContainer7.Panel1.Controls.Add(this.textBoxExportLocation);
            // 
            // splitContainer7.Panel2
            // 
            this.splitContainer7.Panel2.Controls.Add(this.buttonBrowse);
            this.splitContainer7.Size = new System.Drawing.Size(715, 28);
            this.splitContainer7.SplitterDistance = 654;
            this.splitContainer7.TabIndex = 0;
            // 
            // textBoxExportLocation
            // 
            this.textBoxExportLocation.Dock = System.Windows.Forms.DockStyle.Top;
            this.textBoxExportLocation.Location = new System.Drawing.Point(0, 0);
            this.textBoxExportLocation.Name = "textBoxExportLocation";
            this.textBoxExportLocation.Size = new System.Drawing.Size(654, 20);
            this.textBoxExportLocation.TabIndex = 0;
            // 
            // buttonBrowse
            // 
            this.buttonBrowse.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonBrowse.Location = new System.Drawing.Point(0, 0);
            this.buttonBrowse.Name = "buttonBrowse";
            this.buttonBrowse.Size = new System.Drawing.Size(57, 28);
            this.buttonBrowse.TabIndex = 2;
            this.buttonBrowse.Text = "Browse";
            this.buttonBrowse.UseVisualStyleBackColor = true;
            this.buttonBrowse.Click += new System.EventHandler(this.buttonBrowse_Click);
            // 
            // groupBoxSearchInPreview
            // 
            this.groupBoxSearchInPreview.Controls.Add(this.buttonSearchInPreview);
            this.groupBoxSearchInPreview.Controls.Add(this.textBoxSearchInPreview);
            this.groupBoxSearchInPreview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxSearchInPreview.Location = new System.Drawing.Point(0, 0);
            this.groupBoxSearchInPreview.Name = "groupBoxSearchInPreview";
            this.groupBoxSearchInPreview.Size = new System.Drawing.Size(464, 76);
            this.groupBoxSearchInPreview.TabIndex = 2;
            this.groupBoxSearchInPreview.TabStop = false;
            this.groupBoxSearchInPreview.Text = "Search in preview";
            // 
            // buttonSearchInPreview
            // 
            this.buttonSearchInPreview.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.buttonSearchInPreview.Location = new System.Drawing.Point(3, 50);
            this.buttonSearchInPreview.Name = "buttonSearchInPreview";
            this.buttonSearchInPreview.Size = new System.Drawing.Size(458, 23);
            this.buttonSearchInPreview.TabIndex = 1;
            this.buttonSearchInPreview.Text = "Search in preview";
            this.buttonSearchInPreview.UseVisualStyleBackColor = true;
            this.buttonSearchInPreview.Click += new System.EventHandler(this.buttonSearchInPreview_Click);
            // 
            // textBoxSearchInPreview
            // 
            this.textBoxSearchInPreview.Dock = System.Windows.Forms.DockStyle.Top;
            this.textBoxSearchInPreview.Location = new System.Drawing.Point(3, 16);
            this.textBoxSearchInPreview.Name = "textBoxSearchInPreview";
            this.textBoxSearchInPreview.Size = new System.Drawing.Size(458, 20);
            this.textBoxSearchInPreview.TabIndex = 0;
            this.textBoxSearchInPreview.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxSearchInPreview_KeyPress);
            // 
            // FormCatDatExport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1765, 878);
            this.Controls.Add(this.splitContainerMain);
            this.Name = "FormCatDatExport";
            this.Text = "FormCatDatExport";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormCatDatExport_FormClosing);
            this.Load += new System.EventHandler(this.FormCatDatExport_Load);
            this.splitContainerMain.Panel1.ResumeLayout(false);
            this.splitContainerMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).EndInit();
            this.splitContainerMain.ResumeLayout(false);
            this.splitContainerRight.Panel1.ResumeLayout(false);
            this.splitContainerRight.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerRight)).EndInit();
            this.splitContainerRight.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPageFileList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tabPagePreview.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBoxFilters.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel1.PerformLayout();
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.splitContainer4.Panel1.ResumeLayout(false);
            this.splitContainer4.Panel1.PerformLayout();
            this.splitContainer4.Panel2.ResumeLayout(false);
            this.splitContainer4.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).EndInit();
            this.splitContainer4.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.groupBoxExport.ResumeLayout(false);
            this.splitContainer5.Panel1.ResumeLayout(false);
            this.splitContainer5.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer5)).EndInit();
            this.splitContainer5.ResumeLayout(false);
            this.splitContainer6.Panel1.ResumeLayout(false);
            this.splitContainer6.Panel1.PerformLayout();
            this.splitContainer6.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer6)).EndInit();
            this.splitContainer6.ResumeLayout(false);
            this.splitContainer7.Panel1.ResumeLayout(false);
            this.splitContainer7.Panel1.PerformLayout();
            this.splitContainer7.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer7)).EndInit();
            this.splitContainer7.ResumeLayout(false);
            this.groupBoxSearchInPreview.ResumeLayout(false);
            this.groupBoxSearchInPreview.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainerMain;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.SplitContainer splitContainerRight;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox groupBoxFilters;
        private System.Windows.Forms.Label labelCatFilter;
        private System.Windows.Forms.ComboBox comboBoxCatFilter;
        private System.Windows.Forms.TextBox textBoxEndswith;
        private System.Windows.Forms.Label labelEndsWith;
        private System.Windows.Forms.TextBox textBoxContains;
        private System.Windows.Forms.Label labelContains;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageFileList;
        private System.Windows.Forms.TabPage tabPagePreview;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.GroupBox groupBoxExport;
        private System.Windows.Forms.Button buttonExport;
        private System.Windows.Forms.Button buttonBrowse;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxExportLocation;
        private System.Windows.Forms.GroupBox groupBoxSearchInPreview;
        private System.Windows.Forms.Button buttonSearchInPreview;
        private System.Windows.Forms.TextBox textBoxSearchInPreview;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.SplitContainer splitContainer4;
        private System.Windows.Forms.SplitContainer splitContainer5;
        private System.Windows.Forms.SplitContainer splitContainer6;
        private System.Windows.Forms.SplitContainer splitContainer7;

    }
}