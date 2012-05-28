namespace SFASystem.Pocket.App.Controls
{
    partial class SelectProductGroup
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
            this.cbxPGroups = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // cbxPGroups
            // 
            this.cbxPGroups.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbxPGroups.Location = new System.Drawing.Point(0, 0);
            this.cbxPGroups.Name = "cbxPGroups";
            this.cbxPGroups.Size = new System.Drawing.Size(101, 22);
            this.cbxPGroups.TabIndex = 0;
            // 
            // SelectProductGroup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.cbxPGroups);
            this.Name = "SelectProductGroup";
            this.Size = new System.Drawing.Size(101, 23);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cbxPGroups;
    }
}
