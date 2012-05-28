namespace SFASystem.Pocket.App
{
    partial class AccountForm
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
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.employeeInfo1 = new SFASystem.Pocket.App.Controls.EmployeeInfo();
            this.SuspendLayout();
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.Add(this.menuItem1);
            // 
            // menuItem1
            // 
            this.menuItem1.Text = "Menu";
            this.menuItem1.Click += new System.EventHandler(this.menuItem1_Click);
            // 
            // employeeInfo1
            // 
            this.employeeInfo1.BackColor = System.Drawing.Color.White;
            this.employeeInfo1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.employeeInfo1.Location = new System.Drawing.Point(0, 0);
            this.employeeInfo1.Name = "employeeInfo1";
            this.employeeInfo1.Size = new System.Drawing.Size(240, 268);
            this.employeeInfo1.TabIndex = 0;
            // 
            // AccountForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 268);
            this.Controls.Add(this.employeeInfo1);
            this.Menu = this.mainMenu1;
            this.Name = "AccountForm";
            this.Text = "Moje konto";
            this.Load += new System.EventHandler(this.AccountForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private SFASystem.Pocket.App.Controls.EmployeeInfo employeeInfo1;
        private System.Windows.Forms.MenuItem menuItem1;
    }
}