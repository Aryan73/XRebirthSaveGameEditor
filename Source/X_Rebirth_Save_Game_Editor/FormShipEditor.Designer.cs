namespace X_Rebirth_Save_Game_Editor
{
    partial class FormShipEditor
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageShipInfo = new System.Windows.Forms.TabPage();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageShipInfo);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(788, 639);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPageShipInfo
            // 
            this.tabPageShipInfo.Location = new System.Drawing.Point(4, 22);
            this.tabPageShipInfo.Name = "tabPageShipInfo";
            this.tabPageShipInfo.Size = new System.Drawing.Size(780, 613);
            this.tabPageShipInfo.TabIndex = 0;
            this.tabPageShipInfo.Text = "Info";
            this.tabPageShipInfo.UseVisualStyleBackColor = true;
            // 
            // FormShipEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(788, 639);
            this.Controls.Add(this.tabControl1);
            this.Name = "FormShipEditor";
            this.Text = "FormShipEditor";
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageShipInfo;

    }
}