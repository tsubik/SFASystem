namespace SFASystem.Pocket.App
{
    partial class TaskForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.MainMenu mainMenu1;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TaskForm));
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.imageList1 = new System.Windows.Forms.ImageList();
            this.panelFilters = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.selectTaskStatus1 = new SFASystem.Pocket.App.Controls.SelectTaskStatus();
            this.panelMain = new System.Windows.Forms.Panel();
            this.panelFilters.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.Add(this.menuItem1);
            this.mainMenu1.MenuItems.Add(this.menuItem2);
            // 
            // menuItem1
            // 
            this.menuItem1.Text = "Menu";
            this.menuItem1.Click += new System.EventHandler(this.menuItem1_Click_1);
            // 
            // menuItem2
            // 
            this.menuItem2.Text = "Detale";
            this.menuItem2.Click += new System.EventHandler(this.menuItem2_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageSize = new System.Drawing.Size(24, 24);
            this.imageList1.Images.Clear();
            this.imageList1.Images.Add(((System.Drawing.Image)(resources.GetObject("resource"))));
            this.imageList1.Images.Add(((System.Drawing.Image)(resources.GetObject("resource1"))));
            this.imageList1.Images.Add(((System.Drawing.Image)(resources.GetObject("resource2"))));
            // 
            // panelFilters
            // 
            this.panelFilters.Controls.Add(this.label1);
            this.panelFilters.Controls.Add(this.selectTaskStatus1);
            this.panelFilters.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelFilters.Location = new System.Drawing.Point(0, 0);
            this.panelFilters.Name = "panelFilters";
            this.panelFilters.Size = new System.Drawing.Size(240, 41);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Regular);
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 10);
            this.label1.Text = "Status";
            // 
            // selectTaskStatus1
            // 
            this.selectTaskStatus1.EmptyItemText = "Wszystkie...";
            this.selectTaskStatus1.Location = new System.Drawing.Point(3, 13);
            this.selectTaskStatus1.Name = "selectTaskStatus1";
            this.selectTaskStatus1.Size = new System.Drawing.Size(90, 22);
            this.selectTaskStatus1.TabIndex = 0;
            this.selectTaskStatus1.SelectedStatusChanged += new System.EventHandler(this.selectTaskStatus1_SelectedStatusChanged);
            // 
            // panelMain
            // 
            this.panelMain.AutoScroll = true;
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 41);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(240, 227);
            // 
            // TaskForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 268);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.panelFilters);
            this.Menu = this.mainMenu1;
            this.Name = "TaskForm";
            this.Text = "Zadania";
            this.panelFilters.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.MenuItem menuItem1;
        private System.Windows.Forms.MenuItem menuItem2;
        private System.Windows.Forms.Panel panelFilters;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Label label1;
        private SFASystem.Pocket.App.Controls.SelectTaskStatus selectTaskStatus1;
    }
}