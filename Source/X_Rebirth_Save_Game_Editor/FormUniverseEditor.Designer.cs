namespace X_Rebirth_Save_Game_Editor
{
    partial class FormUniverseEditor
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
            this.splitContainerMain = new System.Windows.Forms.SplitContainer();
            this.splitContainerTreeView = new System.Windows.Forms.SplitContainer();
            this.splitContainerCheckBox = new System.Windows.Forms.SplitContainer();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.checkedListBox2 = new System.Windows.Forms.CheckedListBox();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxFaction = new System.Windows.Forms.ComboBox();
            this.treeViewNavigation = new System.Windows.Forms.TreeView();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).BeginInit();
            this.splitContainerMain.Panel1.SuspendLayout();
            this.splitContainerMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerTreeView)).BeginInit();
            this.splitContainerTreeView.Panel1.SuspendLayout();
            this.splitContainerTreeView.Panel2.SuspendLayout();
            this.splitContainerTreeView.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerCheckBox)).BeginInit();
            this.splitContainerCheckBox.Panel1.SuspendLayout();
            this.splitContainerCheckBox.Panel2.SuspendLayout();
            this.splitContainerCheckBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
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
            this.splitContainerMain.Panel1.Controls.Add(this.splitContainerTreeView);
            this.splitContainerMain.Size = new System.Drawing.Size(1151, 632);
            this.splitContainerMain.SplitterDistance = 276;
            this.splitContainerMain.TabIndex = 0;
            // 
            // splitContainerTreeView
            // 
            this.splitContainerTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerTreeView.Location = new System.Drawing.Point(0, 0);
            this.splitContainerTreeView.Name = "splitContainerTreeView";
            this.splitContainerTreeView.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerTreeView.Panel1
            // 
            this.splitContainerTreeView.Panel1.Controls.Add(this.splitContainerCheckBox);
            // 
            // splitContainerTreeView.Panel2
            // 
            this.splitContainerTreeView.Panel2.Controls.Add(this.treeViewNavigation);
            this.splitContainerTreeView.Size = new System.Drawing.Size(276, 632);
            this.splitContainerTreeView.SplitterDistance = 183;
            this.splitContainerTreeView.TabIndex = 0;
            // 
            // splitContainerCheckBox
            // 
            this.splitContainerCheckBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerCheckBox.Location = new System.Drawing.Point(0, 0);
            this.splitContainerCheckBox.Name = "splitContainerCheckBox";
            this.splitContainerCheckBox.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerCheckBox.Panel1
            // 
            this.splitContainerCheckBox.Panel1.Controls.Add(this.splitContainer1);
            // 
            // splitContainerCheckBox.Panel2
            // 
            this.splitContainerCheckBox.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainerCheckBox.Size = new System.Drawing.Size(276, 183);
            this.splitContainerCheckBox.SplitterDistance = 92;
            this.splitContainerCheckBox.TabIndex = 0;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.checkedListBox1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.checkedListBox2);
            this.splitContainer1.Size = new System.Drawing.Size(276, 92);
            this.splitContainer1.SplitterDistance = 124;
            this.splitContainer1.TabIndex = 0;
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Items.AddRange(new object[] {
            "Clusters",
            "Regions",
            "Sectors",
            "Zones",
            "Highways",
            "Celestial bodies"});
            this.checkedListBox1.Location = new System.Drawing.Point(0, 0);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(124, 92);
            this.checkedListBox1.TabIndex = 0;
            this.toolTip1.SetToolTip(this.checkedListBox1, "Select how you would like to group the selected objects.");
            this.checkedListBox1.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.checkedListBox1_ItemCheck);
            // 
            // checkedListBox2
            // 
            this.checkedListBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkedListBox2.FormattingEnabled = true;
            this.checkedListBox2.Items.AddRange(new object[] {
            "Building CVs",
            "Other ships",
            "Stations",
            "NPCs (Not yet)"});
            this.checkedListBox2.Location = new System.Drawing.Point(0, 0);
            this.checkedListBox2.Name = "checkedListBox2";
            this.checkedListBox2.Size = new System.Drawing.Size(148, 92);
            this.checkedListBox2.TabIndex = 1;
            this.toolTip1.SetToolTip(this.checkedListBox2, "Select the type objects you would like to view.");
            this.checkedListBox2.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.checkedListBox1_ItemCheck);
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.splitContainer3);
            this.splitContainer2.Size = new System.Drawing.Size(276, 87);
            this.splitContainer2.SplitterDistance = 44;
            this.splitContainer2.TabIndex = 0;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.label1);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.comboBoxFaction);
            this.splitContainer3.Size = new System.Drawing.Size(276, 44);
            this.splitContainer3.SplitterDistance = 122;
            this.splitContainer3.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Faction";
            // 
            // comboBoxFaction
            // 
            this.comboBoxFaction.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBoxFaction.FormattingEnabled = true;
            this.comboBoxFaction.Location = new System.Drawing.Point(0, 0);
            this.comboBoxFaction.Name = "comboBoxFaction";
            this.comboBoxFaction.Size = new System.Drawing.Size(150, 21);
            this.comboBoxFaction.TabIndex = 0;
            this.toolTip1.SetToolTip(this.comboBoxFaction, "Select the faction for which you would like to view the objects.\r\nThe selection \"" +
        "All\" shows objects from all factions.");
            this.comboBoxFaction.DropDown += new System.EventHandler(this.comboBoxFaction_DropDown);
            this.comboBoxFaction.SelectedIndexChanged += new System.EventHandler(this.comboBoxFaction_SelectedIndexChanged);
            // 
            // treeViewNavigation
            // 
            this.treeViewNavigation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeViewNavigation.Location = new System.Drawing.Point(0, 0);
            this.treeViewNavigation.Name = "treeViewNavigation";
            this.treeViewNavigation.Size = new System.Drawing.Size(276, 445);
            this.treeViewNavigation.TabIndex = 0;
            this.treeViewNavigation.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeViewNavigation_NodeMouseClick);
            // 
            // FormUniverseEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1151, 632);
            this.Controls.Add(this.splitContainerMain);
            this.Name = "FormUniverseEditor";
            this.Text = "FormUniverseEditor";
            this.splitContainerMain.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).EndInit();
            this.splitContainerMain.ResumeLayout(false);
            this.splitContainerTreeView.Panel1.ResumeLayout(false);
            this.splitContainerTreeView.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerTreeView)).EndInit();
            this.splitContainerTreeView.ResumeLayout(false);
            this.splitContainerCheckBox.Panel1.ResumeLayout(false);
            this.splitContainerCheckBox.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerCheckBox)).EndInit();
            this.splitContainerCheckBox.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel1.PerformLayout();
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainerMain;
        private System.Windows.Forms.SplitContainer splitContainerTreeView;
        private System.Windows.Forms.TreeView treeViewNavigation;
        private System.Windows.Forms.SplitContainer splitContainerCheckBox;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.CheckedListBox checkedListBox2;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxFaction;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}