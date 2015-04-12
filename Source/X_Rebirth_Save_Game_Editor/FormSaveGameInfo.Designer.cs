namespace X_Rebirth_Save_Game_Editor
{
    partial class FormSaveGameInfo
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBoxMods = new System.Windows.Forms.GroupBox();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.dataGridViewMods = new System.Windows.Forms.DataGridView();
            this.buttonRemMod = new System.Windows.Forms.Button();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.labelGameTime = new System.Windows.Forms.Label();
            this.labelGameStart = new System.Windows.Forms.Label();
            this.labelGameCreationVersion = new System.Windows.Forms.Label();
            this.labelGameCurrentVersion = new System.Windows.Forms.Label();
            this.labelSaveGameDate = new System.Windows.Forms.Label();
            this.labelSaveGameName = new System.Windows.Forms.Label();
            this.groupBoxPlayer = new System.Windows.Forms.GroupBox();
            this.textBoxPlayerMoney = new System.Windows.Forms.TextBox();
            this.labelPlayerMoney = new System.Windows.Forms.Label();
            this.textBoxPlayerName = new System.Windows.Forms.TextBox();
            this.labelPlayerName = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBoxMods.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMods)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.groupBoxPlayer.SuspendLayout();
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
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer3);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.groupBoxMods);
            this.splitContainer1.Size = new System.Drawing.Size(1408, 614);
            this.splitContainer1.SplitterDistance = 99;
            this.splitContainer1.TabIndex = 0;
            // 
            // groupBoxMods
            // 
            this.groupBoxMods.Controls.Add(this.splitContainer2);
            this.groupBoxMods.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxMods.Location = new System.Drawing.Point(0, 0);
            this.groupBoxMods.Name = "groupBoxMods";
            this.groupBoxMods.Size = new System.Drawing.Size(1408, 511);
            this.groupBoxMods.TabIndex = 12;
            this.groupBoxMods.TabStop = false;
            this.groupBoxMods.Text = "Mods";
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(3, 16);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.dataGridViewMods);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.buttonRemMod);
            this.splitContainer2.Size = new System.Drawing.Size(1402, 492);
            this.splitContainer2.SplitterDistance = 463;
            this.splitContainer2.TabIndex = 0;
            // 
            // dataGridViewMods
            // 
            this.dataGridViewMods.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridViewMods.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewMods.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewMods.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewMods.Name = "dataGridViewMods";
            this.dataGridViewMods.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewMods.Size = new System.Drawing.Size(1402, 463);
            this.dataGridViewMods.TabIndex = 0;
            // 
            // buttonRemMod
            // 
            this.buttonRemMod.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.buttonRemMod.Location = new System.Drawing.Point(0, 2);
            this.buttonRemMod.Name = "buttonRemMod";
            this.buttonRemMod.Size = new System.Drawing.Size(1402, 23);
            this.buttonRemMod.TabIndex = 1;
            this.buttonRemMod.Text = "Remove selected mods";
            this.buttonRemMod.UseVisualStyleBackColor = true;
            this.buttonRemMod.Click += new System.EventHandler(this.buttonRemMod_Click);
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.labelGameTime);
            this.splitContainer3.Panel1.Controls.Add(this.labelGameStart);
            this.splitContainer3.Panel1.Controls.Add(this.labelGameCreationVersion);
            this.splitContainer3.Panel1.Controls.Add(this.labelGameCurrentVersion);
            this.splitContainer3.Panel1.Controls.Add(this.labelSaveGameDate);
            this.splitContainer3.Panel1.Controls.Add(this.labelSaveGameName);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.groupBoxPlayer);
            this.splitContainer3.Size = new System.Drawing.Size(1408, 99);
            this.splitContainer3.SplitterDistance = 673;
            this.splitContainer3.TabIndex = 0;
            // 
            // labelGameTime
            // 
            this.labelGameTime.AutoSize = true;
            this.labelGameTime.Location = new System.Drawing.Point(3, 65);
            this.labelGameTime.Name = "labelGameTime";
            this.labelGameTime.Size = new System.Drawing.Size(60, 13);
            this.labelGameTime.TabIndex = 22;
            this.labelGameTime.Text = "Game time:";
            // 
            // labelGameStart
            // 
            this.labelGameStart.AutoSize = true;
            this.labelGameStart.Location = new System.Drawing.Point(3, 52);
            this.labelGameStart.Name = "labelGameStart";
            this.labelGameStart.Size = new System.Drawing.Size(61, 13);
            this.labelGameStart.TabIndex = 21;
            this.labelGameStart.Text = "Game start:";
            // 
            // labelGameCreationVersion
            // 
            this.labelGameCreationVersion.AutoSize = true;
            this.labelGameCreationVersion.Location = new System.Drawing.Point(3, 39);
            this.labelGameCreationVersion.Name = "labelGameCreationVersion";
            this.labelGameCreationVersion.Size = new System.Drawing.Size(116, 13);
            this.labelGameCreationVersion.TabIndex = 20;
            this.labelGameCreationVersion.Text = "Game creation version:";
            // 
            // labelGameCurrentVersion
            // 
            this.labelGameCurrentVersion.AutoSize = true;
            this.labelGameCurrentVersion.Location = new System.Drawing.Point(3, 26);
            this.labelGameCurrentVersion.Name = "labelGameCurrentVersion";
            this.labelGameCurrentVersion.Size = new System.Drawing.Size(111, 13);
            this.labelGameCurrentVersion.TabIndex = 19;
            this.labelGameCurrentVersion.Text = "Game current version:";
            // 
            // labelSaveGameDate
            // 
            this.labelSaveGameDate.AutoSize = true;
            this.labelSaveGameDate.Location = new System.Drawing.Point(3, 13);
            this.labelSaveGameDate.Name = "labelSaveGameDate";
            this.labelSaveGameDate.Size = new System.Drawing.Size(88, 13);
            this.labelSaveGameDate.TabIndex = 18;
            this.labelSaveGameDate.Text = "Save game date:";
            // 
            // labelSaveGameName
            // 
            this.labelSaveGameName.AutoSize = true;
            this.labelSaveGameName.Location = new System.Drawing.Point(3, 0);
            this.labelSaveGameName.Name = "labelSaveGameName";
            this.labelSaveGameName.Size = new System.Drawing.Size(93, 13);
            this.labelSaveGameName.TabIndex = 17;
            this.labelSaveGameName.Text = "Save game name:";
            // 
            // groupBoxPlayer
            // 
            this.groupBoxPlayer.Controls.Add(this.textBoxPlayerMoney);
            this.groupBoxPlayer.Controls.Add(this.labelPlayerMoney);
            this.groupBoxPlayer.Controls.Add(this.textBoxPlayerName);
            this.groupBoxPlayer.Controls.Add(this.labelPlayerName);
            this.groupBoxPlayer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxPlayer.Location = new System.Drawing.Point(0, 0);
            this.groupBoxPlayer.Name = "groupBoxPlayer";
            this.groupBoxPlayer.Size = new System.Drawing.Size(731, 99);
            this.groupBoxPlayer.TabIndex = 5;
            this.groupBoxPlayer.TabStop = false;
            this.groupBoxPlayer.Text = "Player";
            // 
            // textBoxPlayerMoney
            // 
            this.textBoxPlayerMoney.Location = new System.Drawing.Point(120, 43);
            this.textBoxPlayerMoney.Name = "textBoxPlayerMoney";
            this.textBoxPlayerMoney.Size = new System.Drawing.Size(194, 20);
            this.textBoxPlayerMoney.TabIndex = 7;
            this.textBoxPlayerMoney.Leave += new System.EventHandler(this.textBoxPlayerMoney_Leave);
            // 
            // labelPlayerMoney
            // 
            this.labelPlayerMoney.AutoSize = true;
            this.labelPlayerMoney.Location = new System.Drawing.Point(7, 46);
            this.labelPlayerMoney.Name = "labelPlayerMoney";
            this.labelPlayerMoney.Size = new System.Drawing.Size(42, 13);
            this.labelPlayerMoney.TabIndex = 6;
            this.labelPlayerMoney.Text = "Money:";
            // 
            // textBoxPlayerName
            // 
            this.textBoxPlayerName.Enabled = false;
            this.textBoxPlayerName.Location = new System.Drawing.Point(120, 17);
            this.textBoxPlayerName.Name = "textBoxPlayerName";
            this.textBoxPlayerName.Size = new System.Drawing.Size(194, 20);
            this.textBoxPlayerName.TabIndex = 5;
            // 
            // labelPlayerName
            // 
            this.labelPlayerName.AutoSize = true;
            this.labelPlayerName.Location = new System.Drawing.Point(6, 20);
            this.labelPlayerName.Name = "labelPlayerName";
            this.labelPlayerName.Size = new System.Drawing.Size(38, 13);
            this.labelPlayerName.TabIndex = 4;
            this.labelPlayerName.Text = "Name:";
            // 
            // FormSaveGameInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1408, 614);
            this.Controls.Add(this.splitContainer1);
            this.Name = "FormSaveGameInfo";
            this.Text = "FormSaveGameInfo";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBoxMods.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMods)).EndInit();
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel1.PerformLayout();
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.groupBoxPlayer.ResumeLayout(false);
            this.groupBoxPlayer.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox groupBoxMods;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.DataGridView dataGridViewMods;
        private System.Windows.Forms.Button buttonRemMod;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.Label labelGameTime;
        private System.Windows.Forms.Label labelGameStart;
        private System.Windows.Forms.Label labelGameCreationVersion;
        private System.Windows.Forms.Label labelGameCurrentVersion;
        private System.Windows.Forms.Label labelSaveGameDate;
        private System.Windows.Forms.Label labelSaveGameName;
        private System.Windows.Forms.GroupBox groupBoxPlayer;
        private System.Windows.Forms.TextBox textBoxPlayerMoney;
        private System.Windows.Forms.Label labelPlayerMoney;
        private System.Windows.Forms.TextBox textBoxPlayerName;
        private System.Windows.Forms.Label labelPlayerName;
    }
}