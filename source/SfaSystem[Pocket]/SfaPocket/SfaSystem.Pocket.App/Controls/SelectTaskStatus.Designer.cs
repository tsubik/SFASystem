namespace SFASystem.Pocket.App.Controls
{
    partial class SelectTaskStatus
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
            this.cbxTaskStatus = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // cbxTaskStatus
            // 
            this.cbxTaskStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbxTaskStatus.Location = new System.Drawing.Point(0, 0);
            this.cbxTaskStatus.Name = "cbxTaskStatus";
            this.cbxTaskStatus.Size = new System.Drawing.Size(92, 22);
            this.cbxTaskStatus.TabIndex = 0;
            // 
            // SelectTaskStatus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.cbxTaskStatus);
            this.Name = "SelectTaskStatus";
            this.Size = new System.Drawing.Size(92, 22);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cbxTaskStatus;
    }
}
