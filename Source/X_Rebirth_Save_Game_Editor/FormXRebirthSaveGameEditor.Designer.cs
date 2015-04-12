namespace X_Rebirth_Save_Game_Editor
{
    partial class FormXRebirthSaveGameEditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormXRebirthSaveGameEditor));
            this.splitContainerMain = new System.Windows.Forms.SplitContainer();
            this.splitContainerTop = new System.Windows.Forms.SplitContainer();
            this.checkBoxFormatted = new System.Windows.Forms.CheckBox();
            this.buttonUnload = new System.Windows.Forms.Button();
            this.buttonBrowse = new System.Windows.Forms.Button();
            this.labelSaveLocation = new System.Windows.Forms.Label();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonBrowseXR = new System.Windows.Forms.Button();
            this.labelBrowseXR = new System.Windows.Forms.Label();
            this.tabControlMain = new System.Windows.Forms.TabControl();
            this.tabPageGameInfo = new System.Windows.Forms.TabPage();
            this.tabPageKnownTypes = new System.Windows.Forms.TabPage();
            this.tabPageSkunk = new System.Windows.Forms.TabPage();
            this.tabPageNPCs = new System.Windows.Forms.TabPage();
            this.tabPageFactions = new System.Windows.Forms.TabPage();
            this.tabPageUniverseEditor = new System.Windows.Forms.TabPage();
            this.tabPageCatDatExtractor = new System.Windows.Forms.TabPage();
            this.tabPageLog = new System.Windows.Forms.TabPage();
            this.richTextBoxLog = new System.Windows.Forms.RichTextBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).BeginInit();
            this.splitContainerMain.Panel1.SuspendLayout();
            this.splitContainerMain.Panel2.SuspendLayout();
            this.splitContainerMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerTop)).BeginInit();
            this.splitContainerTop.Panel1.SuspendLayout();
            this.splitContainerTop.Panel2.SuspendLayout();
            this.splitContainerTop.SuspendLayout();
            this.tabControlMain.SuspendLayout();
            this.tabPageLog.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainerMain
            // 
            this.splitContainerMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerMain.Location = new System.Drawing.Point(0, 0);
            this.splitContainerMain.Name = "splitContainerMain";
            this.splitContainerMain.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerMain.Panel1
            // 
            this.splitContainerMain.Panel1.Controls.Add(this.splitContainerTop);
            // 
            // splitContainerMain.Panel2
            // 
            this.splitContainerMain.Panel2.Controls.Add(this.tabControlMain);
            this.splitContainerMain.Size = new System.Drawing.Size(1799, 722);
            this.splitContainerMain.SplitterDistance = 37;
            this.splitContainerMain.TabIndex = 0;
            // 
            // splitContainerTop
            // 
            this.splitContainerTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerTop.Location = new System.Drawing.Point(0, 0);
            this.splitContainerTop.Name = "splitContainerTop";
            // 
            // splitContainerTop.Panel1
            // 
            this.splitContainerTop.Panel1.Controls.Add(this.checkBoxFormatted);
            this.splitContainerTop.Panel1.Controls.Add(this.buttonUnload);
            this.splitContainerTop.Panel1.Controls.Add(this.buttonBrowse);
            this.splitContainerTop.Panel1.Controls.Add(this.labelSaveLocation);
            this.splitContainerTop.Panel1.Controls.Add(this.buttonSave);
            // 
            // splitContainerTop.Panel2
            // 
            this.splitContainerTop.Panel2.Controls.Add(this.buttonBrowseXR);
            this.splitContainerTop.Panel2.Controls.Add(this.labelBrowseXR);
            this.splitContainerTop.Size = new System.Drawing.Size(1799, 37);
            this.splitContainerTop.SplitterDistance = 859;
            this.splitContainerTop.TabIndex = 0;
            // 
            // checkBoxFormatted
            // 
            this.checkBoxFormatted.AutoSize = true;
            this.checkBoxFormatted.Location = new System.Drawing.Point(554, 6);
            this.checkBoxFormatted.Name = "checkBoxFormatted";
            this.checkBoxFormatted.Size = new System.Drawing.Size(104, 17);
            this.checkBoxFormatted.TabIndex = 11;
            this.checkBoxFormatted.Text = "Human readable";
            this.checkBoxFormatted.UseVisualStyleBackColor = true;
            this.checkBoxFormatted.Visible = false;
            // 
            // buttonUnload
            // 
            this.buttonUnload.Location = new System.Drawing.Point(84, 3);
            this.buttonUnload.Name = "buttonUnload";
            this.buttonUnload.Size = new System.Drawing.Size(75, 23);
            this.buttonUnload.TabIndex = 10;
            this.buttonUnload.Text = "Unload";
            this.buttonUnload.UseVisualStyleBackColor = true;
            this.buttonUnload.Click += new System.EventHandler(this.buttonUnload_Click);
            // 
            // buttonBrowse
            // 
            this.buttonBrowse.Location = new System.Drawing.Point(165, 3);
            this.buttonBrowse.Name = "buttonBrowse";
            this.buttonBrowse.Size = new System.Drawing.Size(75, 23);
            this.buttonBrowse.TabIndex = 9;
            this.buttonBrowse.Text = "Browse";
            this.buttonBrowse.UseVisualStyleBackColor = true;
            this.buttonBrowse.Click += new System.EventHandler(this.buttonBrowse_Click);
            // 
            // labelSaveLocation
            // 
            this.labelSaveLocation.AutoSize = true;
            this.labelSaveLocation.Location = new System.Drawing.Point(246, 8);
            this.labelSaveLocation.Name = "labelSaveLocation";
            this.labelSaveLocation.Size = new System.Drawing.Size(111, 13);
            this.labelSaveLocation.TabIndex = 8;
            this.labelSaveLocation.Text = "No save game loaded";
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(3, 3);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 4;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonBrowseXR
            // 
            this.buttonBrowseXR.Location = new System.Drawing.Point(3, 3);
            this.buttonBrowseXR.Name = "buttonBrowseXR";
            this.buttonBrowseXR.Size = new System.Drawing.Size(105, 23);
            this.buttonBrowseXR.TabIndex = 10;
            this.buttonBrowseXR.Text = "Browse XR Path";
            this.buttonBrowseXR.UseVisualStyleBackColor = true;
            this.buttonBrowseXR.Click += new System.EventHandler(this.buttonBrowseXR_Click);
            // 
            // labelBrowseXR
            // 
            this.labelBrowseXR.AutoSize = true;
            this.labelBrowseXR.Location = new System.Drawing.Point(114, 7);
            this.labelBrowseXR.Name = "labelBrowseXR";
            this.labelBrowseXR.Size = new System.Drawing.Size(282, 13);
            this.labelBrowseXR.TabIndex = 9;
            this.labelBrowseXR.Text = "No X-Rebirth location loaded. Not all functionality enabled.";
            // 
            // tabControlMain
            // 
            this.tabControlMain.Controls.Add(this.tabPageGameInfo);
            this.tabControlMain.Controls.Add(this.tabPageKnownTypes);
            this.tabControlMain.Controls.Add(this.tabPageSkunk);
            this.tabControlMain.Controls.Add(this.tabPageNPCs);
            this.tabControlMain.Controls.Add(this.tabPageFactions);
            this.tabControlMain.Controls.Add(this.tabPageUniverseEditor);
            this.tabControlMain.Controls.Add(this.tabPageCatDatExtractor);
            this.tabControlMain.Controls.Add(this.tabPageLog);
            this.tabControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlMain.Location = new System.Drawing.Point(0, 0);
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.SelectedIndex = 0;
            this.tabControlMain.ShowToolTips = true;
            this.tabControlMain.Size = new System.Drawing.Size(1799, 681);
            this.tabControlMain.TabIndex = 0;
            this.tabControlMain.SelectedIndexChanged += new System.EventHandler(this.tabControlMain_SelectedIndexChanged);
            // 
            // tabPageGameInfo
            // 
            this.tabPageGameInfo.Location = new System.Drawing.Point(4, 22);
            this.tabPageGameInfo.Name = "tabPageGameInfo";
            this.tabPageGameInfo.Size = new System.Drawing.Size(1791, 655);
            this.tabPageGameInfo.TabIndex = 2;
            this.tabPageGameInfo.Text = "Game & player info";
            this.tabPageGameInfo.ToolTipText = "View game, save game and player info.\r\nEdit player money.";
            this.tabPageGameInfo.UseVisualStyleBackColor = true;
            // 
            // tabPageKnownTypes
            // 
            this.tabPageKnownTypes.Location = new System.Drawing.Point(4, 22);
            this.tabPageKnownTypes.Name = "tabPageKnownTypes";
            this.tabPageKnownTypes.Size = new System.Drawing.Size(1791, 655);
            this.tabPageKnownTypes.TabIndex = 5;
            this.tabPageKnownTypes.Text = "Known types";
            this.tabPageKnownTypes.ToolTipText = "Here you can add known types so you can view them in the ingame encyclopedia.\r\nTh" +
    "e known items are shown on the left.\r\nThe unknown items are shown on the right.";
            this.tabPageKnownTypes.UseVisualStyleBackColor = true;
            // 
            // tabPageSkunk
            // 
            this.tabPageSkunk.Location = new System.Drawing.Point(4, 22);
            this.tabPageSkunk.Name = "tabPageSkunk";
            this.tabPageSkunk.Size = new System.Drawing.Size(1791, 655);
            this.tabPageSkunk.TabIndex = 3;
            this.tabPageSkunk.Text = "Skunk";
            this.tabPageSkunk.ToolTipText = "Here you change the Skunks: Equipment, Ammo, Marines and (Player) Inventory. Keep" +
    " in mind that there still is an issue when adding new weapon slots.";
            this.tabPageSkunk.UseVisualStyleBackColor = true;
            // 
            // tabPageNPCs
            // 
            this.tabPageNPCs.Location = new System.Drawing.Point(4, 22);
            this.tabPageNPCs.Name = "tabPageNPCs";
            this.tabPageNPCs.Size = new System.Drawing.Size(1791, 655);
            this.tabPageNPCs.TabIndex = 6;
            this.tabPageNPCs.Text = "NPCs";
            this.tabPageNPCs.ToolTipText = resources.GetString("tabPageNPCs.ToolTipText");
            this.tabPageNPCs.UseVisualStyleBackColor = true;
            // 
            // tabPageFactions
            // 
            this.tabPageFactions.BackColor = System.Drawing.Color.Transparent;
            this.tabPageFactions.Location = new System.Drawing.Point(4, 22);
            this.tabPageFactions.Name = "tabPageFactions";
            this.tabPageFactions.Size = new System.Drawing.Size(1791, 655);
            this.tabPageFactions.TabIndex = 4;
            this.tabPageFactions.Text = "Factions";
            this.tabPageFactions.ToolTipText = "This functionality does not work yet. Please be patient ;)";
            // 
            // tabPageUniverseEditor
            // 
            this.tabPageUniverseEditor.Location = new System.Drawing.Point(4, 22);
            this.tabPageUniverseEditor.Name = "tabPageUniverseEditor";
            this.tabPageUniverseEditor.Size = new System.Drawing.Size(1791, 655);
            this.tabPageUniverseEditor.TabIndex = 7;
            this.tabPageUniverseEditor.Text = "Universe editor";
            this.tabPageUniverseEditor.ToolTipText = "(comming soon) In the Universe editor you can browse to your universe. For now on" +
    "ly building CVs can be managed.";
            this.tabPageUniverseEditor.UseVisualStyleBackColor = true;
            // 
            // tabPageCatDatExtractor
            // 
            this.tabPageCatDatExtractor.Location = new System.Drawing.Point(4, 22);
            this.tabPageCatDatExtractor.Name = "tabPageCatDatExtractor";
            this.tabPageCatDatExtractor.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageCatDatExtractor.Size = new System.Drawing.Size(1791, 655);
            this.tabPageCatDatExtractor.TabIndex = 1;
            this.tabPageCatDatExtractor.Text = "Cat\\Dat Extractor\\Browser";
            this.tabPageCatDatExtractor.ToolTipText = "Here you can view, export and search files located in the cat/dat files.";
            this.tabPageCatDatExtractor.UseVisualStyleBackColor = true;
            // 
            // tabPageLog
            // 
            this.tabPageLog.Controls.Add(this.richTextBoxLog);
            this.tabPageLog.Location = new System.Drawing.Point(4, 22);
            this.tabPageLog.Name = "tabPageLog";
            this.tabPageLog.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageLog.Size = new System.Drawing.Size(1791, 655);
            this.tabPageLog.TabIndex = 0;
            this.tabPageLog.Text = "Log";
            this.tabPageLog.ToolTipText = "Here you can view the applications log file. After altering something always chec" +
    "k the log for errors.";
            this.tabPageLog.UseVisualStyleBackColor = true;
            // 
            // richTextBoxLog
            // 
            this.richTextBoxLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBoxLog.Location = new System.Drawing.Point(3, 3);
            this.richTextBoxLog.Name = "richTextBoxLog";
            this.richTextBoxLog.Size = new System.Drawing.Size(1785, 649);
            this.richTextBoxLog.TabIndex = 1;
            this.richTextBoxLog.Text = "";
            // 
            // FormXRebirthSaveGameEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1799, 722);
            this.Controls.Add(this.splitContainerMain);
            this.Name = "FormXRebirthSaveGameEditor";
            this.Text = "X-Rebirth Save game editor & Cat/Dat extractor/Browser";
            this.ResizeEnd += new System.EventHandler(this.FormXRebirthSaveGameEditor_Resize);
            this.splitContainerMain.Panel1.ResumeLayout(false);
            this.splitContainerMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).EndInit();
            this.splitContainerMain.ResumeLayout(false);
            this.splitContainerTop.Panel1.ResumeLayout(false);
            this.splitContainerTop.Panel1.PerformLayout();
            this.splitContainerTop.Panel2.ResumeLayout(false);
            this.splitContainerTop.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerTop)).EndInit();
            this.splitContainerTop.ResumeLayout(false);
            this.tabControlMain.ResumeLayout(false);
            this.tabPageLog.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainerMain;
        private System.Windows.Forms.SplitContainer splitContainerTop;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.CheckBox checkBoxFormatted;
        private System.Windows.Forms.Button buttonUnload;
        private System.Windows.Forms.Button buttonBrowse;
        private System.Windows.Forms.Label labelSaveLocation;
        private System.Windows.Forms.Button buttonBrowseXR;
        private System.Windows.Forms.Label labelBrowseXR;
        private System.Windows.Forms.TabControl tabControlMain;
        private System.Windows.Forms.TabPage tabPageLog;
        private System.Windows.Forms.TabPage tabPageCatDatExtractor;
        private System.Windows.Forms.RichTextBox richTextBoxLog;
        private System.Windows.Forms.TabPage tabPageGameInfo;
        private System.Windows.Forms.TabPage tabPageSkunk;
        private System.Windows.Forms.TabPage tabPageFactions;
        private System.Windows.Forms.TabPage tabPageKnownTypes;
        private System.Windows.Forms.TabPage tabPageNPCs;
        private System.Windows.Forms.TabPage tabPageUniverseEditor;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}