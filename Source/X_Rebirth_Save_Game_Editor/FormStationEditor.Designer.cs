namespace X_Rebirth_Save_Game_Editor
{
    partial class FormStationEditor
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
            this.tabPageStationInfo = new System.Windows.Forms.TabPage();
            this.tabPageQueudShips = new System.Windows.Forms.TabPage();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageStationInfo);
            this.tabControl1.Controls.Add(this.tabPageQueudShips);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(788, 639);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPageStationInfo
            // 
            this.tabPageStationInfo.Location = new System.Drawing.Point(4, 22);
            this.tabPageStationInfo.Name = "tabPageStationInfo";
            this.tabPageStationInfo.Size = new System.Drawing.Size(780, 613);
            this.tabPageStationInfo.TabIndex = 0;
            this.tabPageStationInfo.Text = "Info";
            this.tabPageStationInfo.UseVisualStyleBackColor = true;
            // 
            // tabPageQueudShips
            // 
            this.tabPageQueudShips.Location = new System.Drawing.Point(4, 22);
            this.tabPageQueudShips.Name = "tabPageQueudShips";
            this.tabPageQueudShips.Size = new System.Drawing.Size(780, 613);
            this.tabPageQueudShips.TabIndex = 1;
            this.tabPageQueudShips.Text = "Queued Ships";
            this.tabPageQueudShips.UseVisualStyleBackColor = true;
            // 
            // FormStationEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(788, 639);
            this.Controls.Add(this.tabControl1);
            this.Name = "FormStationEditor";
            this.Text = "FormStationEditor";
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageStationInfo;
        private System.Windows.Forms.TabPage tabPageQueudShips;
    }
}