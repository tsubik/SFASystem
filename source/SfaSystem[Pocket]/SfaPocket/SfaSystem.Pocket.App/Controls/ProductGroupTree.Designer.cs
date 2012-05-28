namespace SFASystem.Pocket.App.Controls
{
    partial class ProductGroupTree
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
            this.treeProductGroups = new System.Windows.Forms.TreeView();
            this.SuspendLayout();
            // 
            // treeProductGroups
            // 
            this.treeProductGroups.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeProductGroups.Location = new System.Drawing.Point(0, 0);
            this.treeProductGroups.Name = "treeProductGroups";
            this.treeProductGroups.Size = new System.Drawing.Size(221, 247);
            this.treeProductGroups.TabIndex = 0;
            this.treeProductGroups.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeProductGroups_AfterSelect);
            // 
            // ProductGroupTree
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.treeProductGroups);
            this.Name = "ProductGroupTree";
            this.Size = new System.Drawing.Size(221, 247);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView treeProductGroups;
    }
}
