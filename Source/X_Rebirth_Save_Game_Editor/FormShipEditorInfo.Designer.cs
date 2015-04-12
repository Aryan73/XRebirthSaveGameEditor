namespace X_Rebirth_Save_Game_Editor
{
    partial class FormShipEditorInfo
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
            this.labelShipName = new System.Windows.Forms.Label();
            this.textBoxShipName = new System.Windows.Forms.TextBox();
            this.labelShipMacro = new System.Windows.Forms.Label();
            this.textBoxShipMacro = new System.Windows.Forms.TextBox();
            this.labelClass = new System.Windows.Forms.Label();
            this.textBoxShipClass = new System.Windows.Forms.TextBox();
            this.comboBoxShipOwner = new System.Windows.Forms.ComboBox();
            this.labelShipOwner = new System.Windows.Forms.Label();
            this.textBoxShipId = new System.Windows.Forms.TextBox();
            this.labelShipId = new System.Windows.Forms.Label();
            this.labelShipKnownTo = new System.Windows.Forms.Label();
            this.textBoxShipKnownTo = new System.Windows.Forms.TextBox();
            this.labelShipConnection = new System.Windows.Forms.Label();
            this.textBoxShipConnection = new System.Windows.Forms.TextBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // labelShipName
            // 
            this.labelShipName.AutoSize = true;
            this.labelShipName.Location = new System.Drawing.Point(14, 16);
            this.labelShipName.Name = "labelShipName";
            this.labelShipName.Size = new System.Drawing.Size(59, 13);
            this.labelShipName.TabIndex = 0;
            this.labelShipName.Text = "Ship Name";
            // 
            // textBoxShipName
            // 
            this.textBoxShipName.Location = new System.Drawing.Point(99, 13);
            this.textBoxShipName.Name = "textBoxShipName";
            this.textBoxShipName.Size = new System.Drawing.Size(427, 20);
            this.textBoxShipName.TabIndex = 1;
            this.textBoxShipName.TextChanged += new System.EventHandler(this.textBoxShipName_TextChanged);
            // 
            // labelShipMacro
            // 
            this.labelShipMacro.AutoSize = true;
            this.labelShipMacro.Location = new System.Drawing.Point(14, 43);
            this.labelShipMacro.Name = "labelShipMacro";
            this.labelShipMacro.Size = new System.Drawing.Size(61, 13);
            this.labelShipMacro.TabIndex = 2;
            this.labelShipMacro.Text = "Ship Macro";
            // 
            // textBoxShipMacro
            // 
            this.textBoxShipMacro.Enabled = false;
            this.textBoxShipMacro.Location = new System.Drawing.Point(99, 40);
            this.textBoxShipMacro.Name = "textBoxShipMacro";
            this.textBoxShipMacro.Size = new System.Drawing.Size(427, 20);
            this.textBoxShipMacro.TabIndex = 3;
            // 
            // labelClass
            // 
            this.labelClass.AutoSize = true;
            this.labelClass.Location = new System.Drawing.Point(14, 69);
            this.labelClass.Name = "labelClass";
            this.labelClass.Size = new System.Drawing.Size(56, 13);
            this.labelClass.TabIndex = 4;
            this.labelClass.Text = "Ship Class";
            // 
            // textBoxShipClass
            // 
            this.textBoxShipClass.Enabled = false;
            this.textBoxShipClass.Location = new System.Drawing.Point(99, 66);
            this.textBoxShipClass.Name = "textBoxShipClass";
            this.textBoxShipClass.Size = new System.Drawing.Size(427, 20);
            this.textBoxShipClass.TabIndex = 5;
            // 
            // comboBoxShipOwner
            // 
            this.comboBoxShipOwner.FormattingEnabled = true;
            this.comboBoxShipOwner.Location = new System.Drawing.Point(99, 93);
            this.comboBoxShipOwner.Name = "comboBoxShipOwner";
            this.comboBoxShipOwner.Size = new System.Drawing.Size(427, 21);
            this.comboBoxShipOwner.TabIndex = 6;
            this.toolTip1.SetToolTip(this.comboBoxShipOwner, "The owner for the ship and it\'s crew is set.\r\nPlease let me know if there are sit" +
        "uations that do not work when changing ownership.");
            this.comboBoxShipOwner.SelectedIndexChanged += new System.EventHandler(this.comboBoxShipOwner_SelectedIndexChanged);
            // 
            // labelShipOwner
            // 
            this.labelShipOwner.AutoSize = true;
            this.labelShipOwner.Location = new System.Drawing.Point(14, 96);
            this.labelShipOwner.Name = "labelShipOwner";
            this.labelShipOwner.Size = new System.Drawing.Size(62, 13);
            this.labelShipOwner.TabIndex = 7;
            this.labelShipOwner.Text = "Ship Owner";
            // 
            // textBoxShipId
            // 
            this.textBoxShipId.Enabled = false;
            this.textBoxShipId.Location = new System.Drawing.Point(99, 120);
            this.textBoxShipId.Name = "textBoxShipId";
            this.textBoxShipId.Size = new System.Drawing.Size(427, 20);
            this.textBoxShipId.TabIndex = 8;
            // 
            // labelShipId
            // 
            this.labelShipId.AutoSize = true;
            this.labelShipId.Location = new System.Drawing.Point(14, 123);
            this.labelShipId.Name = "labelShipId";
            this.labelShipId.Size = new System.Drawing.Size(40, 13);
            this.labelShipId.TabIndex = 9;
            this.labelShipId.Text = "Ship Id";
            // 
            // labelShipKnownTo
            // 
            this.labelShipKnownTo.AutoSize = true;
            this.labelShipKnownTo.Location = new System.Drawing.Point(14, 149);
            this.labelShipKnownTo.Name = "labelShipKnownTo";
            this.labelShipKnownTo.Size = new System.Drawing.Size(80, 13);
            this.labelShipKnownTo.TabIndex = 11;
            this.labelShipKnownTo.Text = "Ship Known To";
            // 
            // textBoxShipKnownTo
            // 
            this.textBoxShipKnownTo.Enabled = false;
            this.textBoxShipKnownTo.Location = new System.Drawing.Point(99, 146);
            this.textBoxShipKnownTo.Name = "textBoxShipKnownTo";
            this.textBoxShipKnownTo.Size = new System.Drawing.Size(427, 20);
            this.textBoxShipKnownTo.TabIndex = 10;
            // 
            // labelShipConnection
            // 
            this.labelShipConnection.AutoSize = true;
            this.labelShipConnection.Location = new System.Drawing.Point(14, 175);
            this.labelShipConnection.Name = "labelShipConnection";
            this.labelShipConnection.Size = new System.Drawing.Size(85, 13);
            this.labelShipConnection.TabIndex = 13;
            this.labelShipConnection.Text = "Ship Connection";
            // 
            // textBoxShipConnection
            // 
            this.textBoxShipConnection.Enabled = false;
            this.textBoxShipConnection.Location = new System.Drawing.Point(99, 172);
            this.textBoxShipConnection.Name = "textBoxShipConnection";
            this.textBoxShipConnection.Size = new System.Drawing.Size(427, 20);
            this.textBoxShipConnection.TabIndex = 12;
            // 
            // FormShipEditorInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(543, 416);
            this.Controls.Add(this.labelShipConnection);
            this.Controls.Add(this.textBoxShipConnection);
            this.Controls.Add(this.labelShipKnownTo);
            this.Controls.Add(this.textBoxShipKnownTo);
            this.Controls.Add(this.labelShipId);
            this.Controls.Add(this.textBoxShipId);
            this.Controls.Add(this.labelShipOwner);
            this.Controls.Add(this.comboBoxShipOwner);
            this.Controls.Add(this.textBoxShipClass);
            this.Controls.Add(this.labelClass);
            this.Controls.Add(this.textBoxShipMacro);
            this.Controls.Add(this.labelShipMacro);
            this.Controls.Add(this.textBoxShipName);
            this.Controls.Add(this.labelShipName);
            this.Name = "FormShipEditorInfo";
            this.Text = "FormShipEditorInfo";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelShipName;
        private System.Windows.Forms.TextBox textBoxShipName;
        private System.Windows.Forms.Label labelShipMacro;
        private System.Windows.Forms.TextBox textBoxShipMacro;
        private System.Windows.Forms.Label labelClass;
        private System.Windows.Forms.TextBox textBoxShipClass;
        private System.Windows.Forms.ComboBox comboBoxShipOwner;
        private System.Windows.Forms.Label labelShipOwner;
        private System.Windows.Forms.TextBox textBoxShipId;
        private System.Windows.Forms.Label labelShipId;
        private System.Windows.Forms.Label labelShipKnownTo;
        private System.Windows.Forms.TextBox textBoxShipKnownTo;
        private System.Windows.Forms.Label labelShipConnection;
        private System.Windows.Forms.TextBox textBoxShipConnection;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}