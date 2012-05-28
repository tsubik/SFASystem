namespace SFASystem.Pocket.App.Controls
{
    partial class SelectEmployee
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
            this.cbxEmployees = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // cbxEmployees
            // 
            this.cbxEmployees.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbxEmployees.Location = new System.Drawing.Point(0, 0);
            this.cbxEmployees.Name = "cbxEmployees";
            this.cbxEmployees.Size = new System.Drawing.Size(121, 22);
            this.cbxEmployees.TabIndex = 0;
            // 
            // SelectEmployee
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.cbxEmployees);
            this.Name = "SelectEmployee";
            this.Size = new System.Drawing.Size(121, 22);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cbxEmployees;
    }
}
