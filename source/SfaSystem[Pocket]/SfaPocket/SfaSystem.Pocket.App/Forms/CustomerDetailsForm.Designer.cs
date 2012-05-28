namespace SFASystem.Pocket.App
{
    partial class CustomerDetailsForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.txtNIP = new System.Windows.Forms.TextBox();
            this.txtREGON = new System.Windows.Forms.TextBox();
            this.txtKRS = new System.Windows.Forms.TextBox();
            this.txtDesc = new System.Windows.Forms.TextBox();
            this.tabCustomer = new System.Windows.Forms.TabControl();
            this.tabInfo = new System.Windows.Forms.TabPage();
            this.tabFacilities = new System.Windows.Forms.TabPage();
            this.tabContacts = new System.Windows.Forms.TabPage();
            this.tabZamowienia = new System.Windows.Forms.TabPage();
            this.lstCustomerOrders = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.tabPlatnosci = new System.Windows.Forms.TabPage();
            this.lstInvoices = new System.Windows.Forms.ListView();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader7 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
            this.contextMenuInvoice = new System.Windows.Forms.ContextMenu();
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.tabCustomer.SuspendLayout();
            this.tabInfo.SuspendLayout();
            this.tabZamowienia.SuspendLayout();
            this.tabPlatnosci.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.Add(this.menuItem1);
            // 
            // menuItem1
            // 
            this.menuItem1.Text = "Lista klientów";
            this.menuItem1.Click += new System.EventHandler(this.menuItem1_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label1.Location = new System.Drawing.Point(3, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 15);
            this.label1.Text = "Nazwa:";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label2.Location = new System.Drawing.Point(3, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 15);
            this.label2.Text = "Kod: ";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label3.Location = new System.Drawing.Point(3, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 15);
            this.label3.Text = "NIP:";
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label4.Location = new System.Drawing.Point(3, 122);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 15);
            this.label4.Text = "KRS:";
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label5.Location = new System.Drawing.Point(3, 95);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 15);
            this.label5.Text = "REGON:";
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label6.Location = new System.Drawing.Point(3, 143);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 15);
            this.label6.Text = "Opis:";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(70, 8);
            this.txtName.Name = "txtName";
            this.txtName.ReadOnly = true;
            this.txtName.Size = new System.Drawing.Size(167, 21);
            this.txtName.TabIndex = 11;
            // 
            // txtCode
            // 
            this.txtCode.Location = new System.Drawing.Point(70, 35);
            this.txtCode.Name = "txtCode";
            this.txtCode.ReadOnly = true;
            this.txtCode.Size = new System.Drawing.Size(167, 21);
            this.txtCode.TabIndex = 12;
            // 
            // txtNIP
            // 
            this.txtNIP.Location = new System.Drawing.Point(70, 62);
            this.txtNIP.Name = "txtNIP";
            this.txtNIP.ReadOnly = true;
            this.txtNIP.Size = new System.Drawing.Size(167, 21);
            this.txtNIP.TabIndex = 13;
            // 
            // txtREGON
            // 
            this.txtREGON.Location = new System.Drawing.Point(70, 89);
            this.txtREGON.Name = "txtREGON";
            this.txtREGON.ReadOnly = true;
            this.txtREGON.Size = new System.Drawing.Size(167, 21);
            this.txtREGON.TabIndex = 14;
            // 
            // txtKRS
            // 
            this.txtKRS.Location = new System.Drawing.Point(70, 116);
            this.txtKRS.Name = "txtKRS";
            this.txtKRS.ReadOnly = true;
            this.txtKRS.Size = new System.Drawing.Size(167, 21);
            this.txtKRS.TabIndex = 15;
            // 
            // txtDesc
            // 
            this.txtDesc.Location = new System.Drawing.Point(70, 143);
            this.txtDesc.Multiline = true;
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.ReadOnly = true;
            this.txtDesc.Size = new System.Drawing.Size(167, 46);
            this.txtDesc.TabIndex = 16;
            // 
            // tabCustomer
            // 
            this.tabCustomer.Controls.Add(this.tabInfo);
            this.tabCustomer.Controls.Add(this.tabFacilities);
            this.tabCustomer.Controls.Add(this.tabContacts);
            this.tabCustomer.Controls.Add(this.tabZamowienia);
            this.tabCustomer.Controls.Add(this.tabPlatnosci);
            this.tabCustomer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabCustomer.Location = new System.Drawing.Point(0, 0);
            this.tabCustomer.Name = "tabCustomer";
            this.tabCustomer.SelectedIndex = 0;
            this.tabCustomer.Size = new System.Drawing.Size(240, 268);
            this.tabCustomer.TabIndex = 23;
            this.tabCustomer.SelectedIndexChanged += new System.EventHandler(this.tabCustomer_SelectedIndexChanged);
            // 
            // tabInfo
            // 
            this.tabInfo.Controls.Add(this.txtPhone);
            this.tabInfo.Controls.Add(this.txtEmail);
            this.tabInfo.Controls.Add(this.label8);
            this.tabInfo.Controls.Add(this.label7);
            this.tabInfo.Controls.Add(this.label1);
            this.tabInfo.Controls.Add(this.label2);
            this.tabInfo.Controls.Add(this.label3);
            this.tabInfo.Controls.Add(this.label4);
            this.tabInfo.Controls.Add(this.label5);
            this.tabInfo.Controls.Add(this.label6);
            this.tabInfo.Controls.Add(this.txtName);
            this.tabInfo.Controls.Add(this.txtCode);
            this.tabInfo.Controls.Add(this.txtNIP);
            this.tabInfo.Controls.Add(this.txtREGON);
            this.tabInfo.Controls.Add(this.txtKRS);
            this.tabInfo.Controls.Add(this.txtDesc);
            this.tabInfo.Location = new System.Drawing.Point(0, 0);
            this.tabInfo.Name = "tabInfo";
            this.tabInfo.Size = new System.Drawing.Size(240, 245);
            this.tabInfo.Text = "Info";
            // 
            // tabFacilities
            // 
            this.tabFacilities.AutoScroll = true;
            this.tabFacilities.Location = new System.Drawing.Point(0, 0);
            this.tabFacilities.Name = "tabFacilities";
            this.tabFacilities.Size = new System.Drawing.Size(232, 242);
            this.tabFacilities.Text = "Placówki";
            // 
            // tabContacts
            // 
            this.tabContacts.AutoScroll = true;
            this.tabContacts.Location = new System.Drawing.Point(0, 0);
            this.tabContacts.Name = "tabContacts";
            this.tabContacts.Size = new System.Drawing.Size(232, 242);
            this.tabContacts.Text = "Kontakty";
            // 
            // tabZamowienia
            // 
            this.tabZamowienia.Controls.Add(this.lstCustomerOrders);
            this.tabZamowienia.Location = new System.Drawing.Point(0, 0);
            this.tabZamowienia.Name = "tabZamowienia";
            this.tabZamowienia.Size = new System.Drawing.Size(232, 242);
            this.tabZamowienia.Text = "Zamówienia";
            // 
            // lstCustomerOrders
            // 
            this.lstCustomerOrders.Columns.Add(this.columnHeader1);
            this.lstCustomerOrders.Columns.Add(this.columnHeader2);
            this.lstCustomerOrders.Columns.Add(this.columnHeader3);
            this.lstCustomerOrders.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstCustomerOrders.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Regular);
            this.lstCustomerOrders.FullRowSelect = true;
            this.lstCustomerOrders.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lstCustomerOrders.Location = new System.Drawing.Point(0, 0);
            this.lstCustomerOrders.Name = "lstCustomerOrders";
            this.lstCustomerOrders.Size = new System.Drawing.Size(232, 242);
            this.lstCustomerOrders.TabIndex = 0;
            this.lstCustomerOrders.View = System.Windows.Forms.View.Details;
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
            // tabPlatnosci
            // 
            this.tabPlatnosci.Controls.Add(this.lstInvoices);
            this.tabPlatnosci.Location = new System.Drawing.Point(0, 0);
            this.tabPlatnosci.Name = "tabPlatnosci";
            this.tabPlatnosci.Size = new System.Drawing.Size(232, 242);
            this.tabPlatnosci.Text = "Płatności";
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
            this.lstInvoices.TabIndex = 0;
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
            this.contextMenuInvoice.MenuItems.Add(this.menuItem2);
            // 
            // menuItem2
            // 
            this.menuItem2.Text = "Płatność";
            this.menuItem2.Click += new System.EventHandler(this.menuItem2_Click);
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label7.Location = new System.Drawing.Point(3, 201);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(61, 15);
            this.label7.Text = "Email:";
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label8.Location = new System.Drawing.Point(3, 228);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(61, 15);
            this.label8.Text = "Telefon:";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(70, 195);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.ReadOnly = true;
            this.txtEmail.Size = new System.Drawing.Size(167, 21);
            this.txtEmail.TabIndex = 21;
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(70, 222);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.ReadOnly = true;
            this.txtPhone.Size = new System.Drawing.Size(167, 21);
            this.txtPhone.TabIndex = 22;
            // 
            // CustomerDetailsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 268);
            this.Controls.Add(this.tabCustomer);
            this.Menu = this.mainMenu1;
            this.Name = "CustomerDetailsForm";
            this.Text = "CustomerDetailsForm";
            this.tabCustomer.ResumeLayout(false);
            this.tabInfo.ResumeLayout(false);
            this.tabZamowienia.ResumeLayout(false);
            this.tabPlatnosci.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.TextBox txtNIP;
        private System.Windows.Forms.TextBox txtREGON;
        private System.Windows.Forms.TextBox txtKRS;
        private System.Windows.Forms.TextBox txtDesc;
        private System.Windows.Forms.MenuItem menuItem1;
        private System.Windows.Forms.TabControl tabCustomer;
        private System.Windows.Forms.TabPage tabInfo;
        private System.Windows.Forms.TabPage tabFacilities;
        private System.Windows.Forms.TabPage tabContacts;
        private System.Windows.Forms.TabPage tabZamowienia;
        private System.Windows.Forms.TabPage tabPlatnosci;
        private System.Windows.Forms.ListView lstCustomerOrders;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ListView lstInvoices;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ContextMenu contextMenuInvoice;
        private System.Windows.Forms.MenuItem menuItem2;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
    }
}