namespace X_Rebirth_Save_Game_Editor
{
    partial class FormStationEditorInfo
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
            this.labelStationName = new System.Windows.Forms.Label();
            this.textBoxStationName = new System.Windows.Forms.TextBox();
            this.labelStationMacro = new System.Windows.Forms.Label();
            this.textBoxStationMacro = new System.Windows.Forms.TextBox();
            this.comboBoxStationOwner = new System.Windows.Forms.ComboBox();
            this.labelStationOwner = new System.Windows.Forms.Label();
            this.textBoxStationId = new System.Windows.Forms.TextBox();
            this.labelStationId = new System.Windows.Forms.Label();
            this.labelStationKnownTo = new System.Windows.Forms.Label();
            this.textBoxStationKnownTo = new System.Windows.Forms.TextBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // labelStationName
            // 
            this.labelStationName.AutoSize = true;
            this.labelStationName.Location = new System.Drawing.Point(14, 16);
            this.labelStationName.Name = "labelStationName";
            this.labelStationName.Size = new System.Drawing.Size(71, 13);
            this.labelStationName.TabIndex = 0;
            this.labelStationName.Text = "Station Name";
            // 
            // textBoxStationName
            // 
            this.textBoxStationName.Location = new System.Drawing.Point(99, 13);
            this.textBoxStationName.Name = "textBoxStationName";
            this.textBoxStationName.Size = new System.Drawing.Size(427, 20);
            this.textBoxStationName.TabIndex = 1;
            this.textBoxStationName.TextChanged += new System.EventHandler(this.textBoxStationName_TextChanged);
            // 
            // labelStationMacro
            // 
            this.labelStationMacro.AutoSize = true;
            this.labelStationMacro.Location = new System.Drawing.Point(14, 43);
            this.labelStationMacro.Name = "labelStationMacro";
            this.labelStationMacro.Size = new System.Drawing.Size(73, 13);
            this.labelStationMacro.TabIndex = 2;
            this.labelStationMacro.Text = "Station Macro";
            // 
            // textBoxStationMacro
            // 
            this.textBoxStationMacro.Enabled = false;
            this.textBoxStationMacro.Location = new System.Drawing.Point(99, 40);
            this.textBoxStationMacro.Name = "textBoxStationMacro";
            this.textBoxStationMacro.Size = new System.Drawing.Size(427, 20);
            this.textBoxStationMacro.TabIndex = 3;
            // 
            // comboBoxStationOwner
            // 
            this.comboBoxStationOwner.FormattingEnabled = true;
            this.comboBoxStationOwner.Location = new System.Drawing.Point(99, 66);
            this.comboBoxStationOwner.Name = "comboBoxStationOwner";
            this.comboBoxStationOwner.Size = new System.Drawing.Size(427, 21);
            this.comboBoxStationOwner.TabIndex = 6;
            this.toolTip1.SetToolTip(this.comboBoxStationOwner, "The owner for the station and it\'s crew is set.\r\nPlease let me know if there are " +
        "situations that do not work when changing ownerstation.");
            this.comboBoxStationOwner.SelectedIndexChanged += new System.EventHandler(this.comboBoxStationOwner_SelectedIndexChanged);
            // 
            // labelStationOwner
            // 
            this.labelStationOwner.AutoSize = true;
            this.labelStationOwner.Location = new System.Drawing.Point(14, 69);
            this.labelStationOwner.Name = "labelStationOwner";
            this.labelStationOwner.Size = new System.Drawing.Size(74, 13);
            this.labelStationOwner.TabIndex = 7;
            this.labelStationOwner.Text = "Station Owner";
            // 
            // textBoxStationId
            // 
            this.textBoxStationId.Enabled = false;
            this.textBoxStationId.Location = new System.Drawing.Point(99, 93);
            this.textBoxStationId.Name = "textBoxStationId";
            this.textBoxStationId.Size = new System.Drawing.Size(427, 20);
            this.textBoxStationId.TabIndex = 8;
            // 
            // labelStationId
            // 
            this.labelStationId.AutoSize = true;
            this.labelStationId.Location = new System.Drawing.Point(14, 96);
            this.labelStationId.Name = "labelStationId";
            this.labelStationId.Size = new System.Drawing.Size(52, 13);
            this.labelStationId.TabIndex = 9;
            this.labelStationId.Text = "Station Id";
            // 
            // labelStationKnownTo
            // 
            this.labelStationKnownTo.AutoSize = true;
            this.labelStationKnownTo.Location = new System.Drawing.Point(14, 122);
            this.labelStationKnownTo.Name = "labelStationKnownTo";
            this.labelStationKnownTo.Size = new System.Drawing.Size(92, 13);
            this.labelStationKnownTo.TabIndex = 11;
            this.labelStationKnownTo.Text = "Station Known To";
            // 
            // textBoxStationKnownTo
            // 
            this.textBoxStationKnownTo.Enabled = false;
            this.textBoxStationKnownTo.Location = new System.Drawing.Point(99, 119);
            this.textBoxStationKnownTo.Name = "textBoxStationKnownTo";
            this.textBoxStationKnownTo.Size = new System.Drawing.Size(427, 20);
            this.textBoxStationKnownTo.TabIndex = 10;
            // 
            // FormStationEditorInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(543, 416);
            this.Controls.Add(this.labelStationKnownTo);
            this.Controls.Add(this.textBoxStationKnownTo);
            this.Controls.Add(this.labelStationId);
            this.Controls.Add(this.textBoxStationId);
            this.Controls.Add(this.labelStationOwner);
            this.Controls.Add(this.comboBoxStationOwner);
            this.Controls.Add(this.textBoxStationMacro);
            this.Controls.Add(this.labelStationMacro);
            this.Controls.Add(this.textBoxStationName);
            this.Controls.Add(this.labelStationName);
            this.Name = "FormStationEditorInfo";
            this.Text = "FormStationEditorInfo";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelStationName;
        private System.Windows.Forms.TextBox textBoxStationName;
        private System.Windows.Forms.Label labelStationMacro;
        private System.Windows.Forms.TextBox textBoxStationMacro;
        private System.Windows.Forms.ComboBox comboBoxStationOwner;
        private System.Windows.Forms.Label labelStationOwner;
        private System.Windows.Forms.TextBox textBoxStationId;
        private System.Windows.Forms.Label labelStationId;
        private System.Windows.Forms.Label labelStationKnownTo;
        private System.Windows.Forms.TextBox textBoxStationKnownTo;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}