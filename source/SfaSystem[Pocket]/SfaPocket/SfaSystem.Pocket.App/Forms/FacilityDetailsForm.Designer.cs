namespace SFASystem.Pocket.App.Forms
{
    partial class FacilityDetailsForm
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
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.pageInfo = new System.Windows.Forms.TabPage();
            this.ctrlCustomerFacility = new SFASystem.Pocket.App.Controls.ctrlCustomerFacility();
            this.pageContacts = new System.Windows.Forms.TabPage();
            this.pageOrders = new System.Windows.Forms.TabPage();
            this.lstFacilityOrders = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.pageInvoices = new System.Windows.Forms.TabPage();
            this.lstInvoices = new System.Windows.Forms.ListView();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader7 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
            this.contextMenuInvoice = new System.Windows.Forms.ContextMenu();
            this.menuItem3 = new System.Windows.Forms.MenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.tabControl1.SuspendLayout();
            this.pageInfo.SuspendLayout();
            this.pageOrders.SuspendLayout();
            this.pageInvoices.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.Add(this.menuItem1);
            this.mainMenu1.MenuItems.Add(this.menuItem2);
            // 
            // menuItem1
            // 
            this.menuItem1.Text = "Klient";
            this.menuItem1.Click += new System.EventHandler(this.menuItem1_Click);
            // 
            // menuItem2
            // 
            this.menuItem2.Text = "Zamówienie";
            this.menuItem2.Click += new System.EventHandler(this.menuItem2_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.pageInfo);
            this.tabControl1.Controls.Add(this.pageContacts);
            this.tabControl1.Controls.Add(this.pageOrders);
            this.tabControl1.Controls.Add(this.pageInvoices);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(240, 268);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // pageInfo
            // 
            this.pageInfo.Controls.Add(this.txtPhone);
            this.pageInfo.Controls.Add(this.txtEmail);
            this.pageInfo.Controls.Add(this.label2);
            this.pageInfo.Controls.Add(this.label1);
            this.pageInfo.Controls.Add(this.ctrlCustomerFacility);
            this.pageInfo.Location = new System.Drawing.Point(0, 0);
            this.pageInfo.Name = "pageInfo";
            this.pageInfo.Size = new System.Drawing.Size(240, 245);
            this.pageInfo.Text = "Info";
            // 
            // ctrlCustomerFacility
            // 
            this.ctrlCustomerFacility.Location = new System.Drawing.Point(7, 7);
            this.ctrlCustomerFacility.Name = "ctrlCustomerFacility";
            this.ctrlCustomerFacility.Size = new System.Drawing.Size(230, 100);
            this.ctrlCustomerFacility.TabIndex = 0;
            // 
            // pageContacts
            // 
            this.pageContacts.AutoScroll = true;
            this.pageContacts.Location = new System.Drawing.Point(0, 0);
            this.pageContacts.Name = "pageContacts";
            this.pageContacts.Size = new System.Drawing.Size(232, 242);
            this.pageContacts.Text = "Kontakty";
            // 
            // pageOrders
            // 
            this.pageOrders.Controls.Add(this.lstFacilityOrders);
            this.pageOrders.Location = new System.Drawing.Point(0, 0);
            this.pageOrders.Name = "pageOrders";
            this.pageOrders.Size = new System.Drawing.Size(232, 242);
            this.pageOrders.Text = "Zamówienia";
            // 
            // lstFacilityOrders
            // 
            this.lstFacilityOrders.Columns.Add(this.columnHeader1);
            this.lstFacilityOrders.Columns.Add(this.columnHeader2);
            this.lstFacilityOrders.Columns.Add(this.columnHeader3);
            this.lstFacilityOrders.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstFacilityOrders.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Regular);
            this.lstFacilityOrders.FullRowSelect = true;
            this.lstFacilityOrders.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lstFacilityOrders.Location = new System.Drawing.Point(0, 0);
            this.lstFacilityOrders.Name = "lstFacilityOrders";
            this.lstFacilityOrders.Size = new System.Drawing.Size(232, 242);
            this.lstFacilityOrders.TabIndex = 1;
            this.lstFacilityOrders.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Identyfikator";
            this.columnHeader1.Width = 101;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Wart. brutto";
            this.columnHeader2.Width = 75;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Status";
            this.columnHeader3.Width = 60;
            // 
            // pageInvoices
            // 
            this.pageInvoices.Controls.Add(this.lstInvoices);
            this.pageInvoices.Location = new System.Drawing.Point(0, 0);
            this.pageInvoices.Name = "pageInvoices";
            this.pageInvoices.Size = new System.Drawing.Size(232, 242);
            this.pageInvoices.Text = "Płatności";
            // 
            // lstInvoices
            // 
            this.lstInvoices.Columns.Add(this.columnHeader4);
            this.lstInvoices.Columns.Add(this.columnHeader7);
            this.lstInvoices.Columns.Add(this.columnHeader5);
            this.lstInvoices.Columns.Add(this.columnHeader6);
            this.lstInvoices.ContextMenu = this.contextMenuInvoice;
            this.lstInvoices.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstInvoices.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Regular);
            this.lstInvoices.FullRowSelect = true;
            this.lstInvoices.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lstInvoices.Location = new System.Drawing.Point(0, 0);
            this.lstInvoices.Name = "lstInvoices";
            this.lstInvoices.Size = new System.Drawing.Size(232, 242);
            this.lstInvoices.TabIndex = 1;
            this.lstInvoices.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "FV Nr.";
            this.columnHeader4.Width = 50;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Zamówienie";
            this.columnHeader7.Width = 60;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Należność";
            this.columnHeader5.Width = 59;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Opłacona";
            this.columnHeader6.Width = 71;
            // 
            // contextMenuInvoice
            // 
            this.contextMenuInvoice.MenuItems.Add(this.menuItem3);
            // 
            // menuItem3
            // 
            this.menuItem3.Text = "Płatność";
            this.menuItem3.Click += new System.EventHandler(this.menuItem3_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(7, 114);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 20);
            this.label1.Text = "Email: ";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(7, 141);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 20);
            this.label2.Text = "Telefon: ";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(72, 113);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.ReadOnly = true;
            this.txtEmail.Size = new System.Drawing.Size(165, 21);
            this.txtEmail.TabIndex = 4;
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(72, 140);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.ReadOnly = true;
            this.txtPhone.Size = new System.Drawing.Size(165, 21);
            this.txtPhone.TabIndex = 5;
            // 
            // FacilityDetailsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 268);
            this.Controls.Add(this.tabControl1);
            this.Menu = this.mainMenu1;
            this.Name = "FacilityDetailsForm";
            this.Text = "Detale placówki";
            this.tabControl1.ResumeLayout(false);
            this.pageInfo.ResumeLayout(false);
            this.pageOrders.ResumeLayout(false);
            this.pageInvoices.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MenuItem menuItem1;
        private System.Windows.Forms.MenuItem menuItem2;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage pageInfo;
        private System.Windows.Forms.TabPage pageContacts;
        private System.Windows.Forms.TabPage pageOrders;
        private SFASystem.Pocket.App.Controls.ctrlCustomerFacility ctrlCustomerFacility;
        private System.Windows.Forms.TabPage pageInvoices;
        private System.Windows.Forms.ListView lstFacilityOrders;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ListView lstInvoices;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ContextMenu contextMenuInvoice;
        private System.Windows.Forms.MenuItem menuItem3;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}