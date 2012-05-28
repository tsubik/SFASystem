namespace SFASystem.Pocket.App.Forms
{
    partial class OrderForm
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
            this.btnAddProduct = new System.Windows.Forms.MenuItem();
            this.btnRemoveProduct = new System.Windows.Forms.MenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblCustomerFacility = new System.Windows.Forms.Label();
            this.btnSetCustomer = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lstOrderLines = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.btnMinus = new System.Windows.Forms.Button();
            this.btnPlus = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnAddOrder = new System.Windows.Forms.Button();
            this.txtComment = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lblBruttoPrice = new System.Windows.Forms.Label();
            this.lblVAT = new System.Windows.Forms.Label();
            this.lblNettoPrice = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.Add(this.menuItem1);
            this.mainMenu1.MenuItems.Add(this.btnAddProduct);
            this.mainMenu1.MenuItems.Add(this.btnRemoveProduct);
            // 
            // menuItem1
            // 
            this.menuItem1.Text = "Menu";
            this.menuItem1.Click += new System.EventHandler(this.menuItem1_Click);
            // 
            // btnAddProduct
            // 
            this.btnAddProduct.Text = "Dodaj prod.";
            this.btnAddProduct.Click += new System.EventHandler(this.btnAddProduct_Click);
            // 
            // btnRemoveProduct
            // 
            this.btnRemoveProduct.Text = "Usuń wyb.";
            this.btnRemoveProduct.Click += new System.EventHandler(this.btnRemoveProduct_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblCustomerFacility);
            this.panel1.Controls.Add(this.btnSetCustomer);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(240, 36);
            // 
            // lblCustomerFacility
            // 
            this.lblCustomerFacility.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Regular);
            this.lblCustomerFacility.Location = new System.Drawing.Point(0, 13);
            this.lblCustomerFacility.Name = "lblCustomerFacility";
            this.lblCustomerFacility.Size = new System.Drawing.Size(169, 20);
            this.lblCustomerFacility.Text = "Nie wybrano";
            // 
            // btnSetCustomer
            // 
            this.btnSetCustomer.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Bold);
            this.btnSetCustomer.Location = new System.Drawing.Point(175, 4);
            this.btnSetCustomer.Name = "btnSetCustomer";
            this.btnSetCustomer.Size = new System.Drawing.Size(62, 26);
            this.btnSetCustomer.TabIndex = 1;
            this.btnSetCustomer.Text = "Wybierz";
            this.btnSetCustomer.Click += new System.EventHandler(this.btnSetCustomer_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Regular);
            this.label1.Location = new System.Drawing.Point(0, 1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 14);
            this.label1.Text = "Placówka/klient";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lstOrderLines);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 36);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(240, 120);
            // 
            // lstOrderLines
            // 
            this.lstOrderLines.Columns.Add(this.columnHeader1);
            this.lstOrderLines.Columns.Add(this.columnHeader2);
            this.lstOrderLines.Columns.Add(this.columnHeader3);
            this.lstOrderLines.Columns.Add(this.columnHeader4);
            this.lstOrderLines.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstOrderLines.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Regular);
            this.lstOrderLines.FullRowSelect = true;
            this.lstOrderLines.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lstOrderLines.Location = new System.Drawing.Point(0, 0);
            this.lstOrderLines.Name = "lstOrderLines";
            this.lstOrderLines.Size = new System.Drawing.Size(240, 120);
            this.lstOrderLines.TabIndex = 0;
            this.lstOrderLines.View = System.Windows.Forms.View.Details;
            this.lstOrderLines.SelectedIndexChanged += new System.EventHandler(this.lstOrderLines_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Lp.";
            this.columnHeader1.Width = 20;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Produkt";
            this.columnHeader2.Width = 128;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Ilość";
            this.columnHeader3.Width = 36;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Cena";
            this.columnHeader4.Width = 53;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnRefresh);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.txtQuantity);
            this.panel3.Controls.Add(this.btnMinus);
            this.panel3.Controls.Add(this.btnPlus);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 156);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(240, 29);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Bold);
            this.btnRefresh.Location = new System.Drawing.Point(3, 3);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(66, 21);
            this.btnRefresh.TabIndex = 4;
            this.btnRefresh.Text = "Aktualizuj";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label2.Location = new System.Drawing.Point(72, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 19);
            this.label2.Text = "Zmień ilość:";
            // 
            // txtQuantity
            // 
            this.txtQuantity.Location = new System.Drawing.Point(145, 3);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(34, 21);
            this.txtQuantity.TabIndex = 2;
            // 
            // btnMinus
            // 
            this.btnMinus.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.btnMinus.Location = new System.Drawing.Point(214, 3);
            this.btnMinus.Name = "btnMinus";
            this.btnMinus.Size = new System.Drawing.Size(23, 21);
            this.btnMinus.TabIndex = 1;
            this.btnMinus.Text = "-";
            this.btnMinus.Click += new System.EventHandler(this.btnMinus_Click);
            // 
            // btnPlus
            // 
            this.btnPlus.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.btnPlus.Location = new System.Drawing.Point(185, 3);
            this.btnPlus.Name = "btnPlus";
            this.btnPlus.Size = new System.Drawing.Size(23, 21);
            this.btnPlus.TabIndex = 0;
            this.btnPlus.Text = "+";
            this.btnPlus.Click += new System.EventHandler(this.btnPlus_Click);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.btnAddOrder);
            this.panel4.Controls.Add(this.txtComment);
            this.panel4.Controls.Add(this.label5);
            this.panel4.Controls.Add(this.lblBruttoPrice);
            this.panel4.Controls.Add(this.lblVAT);
            this.panel4.Controls.Add(this.lblNettoPrice);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 185);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(240, 83);
            // 
            // btnAddOrder
            // 
            this.btnAddOrder.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Bold);
            this.btnAddOrder.Location = new System.Drawing.Point(109, 57);
            this.btnAddOrder.Name = "btnAddOrder";
            this.btnAddOrder.Size = new System.Drawing.Size(128, 20);
            this.btnAddOrder.TabIndex = 7;
            this.btnAddOrder.Text = "Zatwierdź zamówienie";
            this.btnAddOrder.Click += new System.EventHandler(this.btnAddOrder_Click);
            // 
            // txtComment
            // 
            this.txtComment.Location = new System.Drawing.Point(3, 16);
            this.txtComment.Multiline = true;
            this.txtComment.Name = "txtComment";
            this.txtComment.Size = new System.Drawing.Size(100, 64);
            this.txtComment.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Regular);
            this.label5.Location = new System.Drawing.Point(0, 3);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 13);
            this.label5.Text = "Komentarz:";
            // 
            // lblBruttoPrice
            // 
            this.lblBruttoPrice.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Regular);
            this.lblBruttoPrice.Location = new System.Drawing.Point(109, 37);
            this.lblBruttoPrice.Name = "lblBruttoPrice";
            this.lblBruttoPrice.Size = new System.Drawing.Size(128, 17);
            this.lblBruttoPrice.Text = "Wartość Brutto: ";
            // 
            // lblVAT
            // 
            this.lblVAT.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Regular);
            this.lblVAT.Location = new System.Drawing.Point(109, 20);
            this.lblVAT.Name = "lblVAT";
            this.lblVAT.Size = new System.Drawing.Size(128, 17);
            this.lblVAT.Text = "Wartość VAT   : ";
            // 
            // lblNettoPrice
            // 
            this.lblNettoPrice.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Regular);
            this.lblNettoPrice.Location = new System.Drawing.Point(109, 3);
            this.lblNettoPrice.Name = "lblNettoPrice";
            this.lblNettoPrice.Size = new System.Drawing.Size(128, 17);
            this.lblNettoPrice.Text = "Wartość netto : ";
            // 
            // OrderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 268);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Menu = this.mainMenu1;
            this.Name = "OrderForm";
            this.Text = "Zamówienie";
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lblCustomerFacility;
        private System.Windows.Forms.Button btnSetCustomer;
        private System.Windows.Forms.ListView lstOrderLines;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtQuantity;
        private System.Windows.Forms.Button btnMinus;
        private System.Windows.Forms.Button btnPlus;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.MenuItem btnAddProduct;
        private System.Windows.Forms.MenuItem btnRemoveProduct;
        private System.Windows.Forms.Label lblBruttoPrice;
        private System.Windows.Forms.Label lblVAT;
        private System.Windows.Forms.Label lblNettoPrice;
        private System.Windows.Forms.Button btnAddOrder;
        private System.Windows.Forms.TextBox txtComment;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.MenuItem menuItem1;
    }
}