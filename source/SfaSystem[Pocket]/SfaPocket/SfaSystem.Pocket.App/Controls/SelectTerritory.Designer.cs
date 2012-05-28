namespace SFASystem.Pocket.App.Controls
{
    partial class SelectTerritory
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cbxTerritories = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // cbxTerritories
            // 
            this.cbxTerritories.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbxTerritories.Location = new System.Drawing.Point(0, 0);
            this.cbxTerritories.Name = "cbxTerritories";
            this.cbxTerritories.Size = new System.Drawing.Size(100, 22);
            this.cbxTerritories.TabIndex = 0;
            // 
            // SelectTerritory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.cbxTerritories);
            this.Name = "SelectTerritory";
            this.Size = new System.Drawing.Size(100, 22);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cbxTerritories;
    }
}
