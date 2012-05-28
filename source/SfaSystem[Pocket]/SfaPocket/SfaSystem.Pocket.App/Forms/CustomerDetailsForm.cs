using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using SFASystem.Pocket.Core.Common;
using SFASystem.Pocket.Core.BusinessLogic;
using SFASystem.Pocket.App.Controls;
using SFASystem.Pocket.App.Code;

namespace SFASystem.Pocket.App
{
    public partial class CustomerDetailsForm : Form
    {
        public CustomerDetailsForm()
        {
            InitializeComponent();
        }

        public void Show(Guid customerID)
        {
            BindData(customerID);
            Show();
        }
        public void ShowDialog(Guid customerID)
        {
            BindData(customerID);
            ShowDialog();
        }

        Customer customer = null;
        bool needBindFacilityList = true;
        bool needBindContactList = true;
        bool needBindOrderList = true;
        bool needBindInvoiceList = true;

        public void BindData(Guid customerID)
        {
            customer = CustomerManager.GetCustomerByID(customerID);
            if (customer != null)
            {
                this.Text = customer.Name + " - Szczegóły";
                this.txtName.Text = customer.Name;
                this.txtCode.Text = customer.Code;
                this.txtNIP.Text = customer.NIP;
                this.txtREGON.Text = customer.REGON;
                this.txtKRS.Text = customer.KRS;
                this.txtDesc.Text = customer.FullDescription;
                this.txtEmail.Text = customer.Email;
                this.txtPhone.Text = customer.Phone;
            }
        }
        private void BindFacilityList()
        {
            if (needBindFacilityList)
            {
                Cursor.Current = Cursors.WaitCursor;
                tabFacilities.Controls.Clear();
                int yPos = 5;
                foreach (CustomerFacility fac in customer.CustomerFacility)
                {
                    ctrlCustomerFacility control = new ctrlCustomerFacility();
                    control.BindData(fac);
                    control.Top = yPos;
                    control.Left = 5;
                    control.Width = 230;
                    control.Height = 90;
                    control.Anchor = AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Left;

                    tabFacilities.Controls.Add(control);
                    yPos += control.Height + 5;
                }
                Cursor.Current = Cursors.Default;
                needBindFacilityList = false;
            }
        }

        private void BindContactList()
        {
            if (needBindContactList)
            {
                Cursor.Current = Cursors.WaitCursor;
                int yPos = 5;
                tabContacts.Controls.Clear();
                foreach (Contact contact in CustomerManager.GetCustomerContacts(customer.CustomerID))
                {
                    ctrlCustomerContact control = new ctrlCustomerContact();
                    control.BindData(contact);
                    control.Top = yPos;
                    control.Left = 5;
                    control.Width = 220;
                    control.Height = 60;
                    tabContacts.Controls.Add(control);
                    yPos += control.Height + 5;
                }
                Cursor.Current = Cursors.Default;
                needBindContactList = false;
            }
        }

        private void BindOrderList()
        {
            if (needBindOrderList)
            {
                Cursor.Current = Cursors.WaitCursor;
                lstCustomerOrders.Items.Clear();
                foreach (Order order in OrderManager.GetOrders(customer).OrderByDescending(o => o.OrderDate))
                {
                    ListViewItem item = new ListViewItem(new string[] {
                    order.Identifier, string.Format("{0:0.00 zł}",order.Total),
                    order.OrderStatus.Value });
                    item.Tag = order.OrderID;
                    lstCustomerOrders.Items.Add(item);
                }
                Cursor.Current = Cursors.Default;
                needBindOrderList = false;
            }
        }

        private void BindInvoiceList()
        {
            if (needBindInvoiceList)
            {
                Cursor.Current = Cursors.WaitCursor;
                if (customer != null)
                {
                    lstInvoices.Items.Clear();
                    foreach (Invoice invoice in OrderManager.GetInvoices(customer).OrderByDescending(i => i.Date))
                    {
                        ListViewItem item = new ListViewItem(new string[] {
                    invoice.Number, invoice.Order.Identifier, string.Format("{0:0.00 zł}",invoice.Order.Total),
                    invoice.InvoiceStatus.Value });
                        if (!invoice.IsPaid)
                        {
                            if (invoice.Date.AddDays(14) < DateTime.Now)
                            {
                                item.ForeColor = Color.Red;
                            }
                        }
                        item.Tag = invoice.Invoiceid;
                        lstInvoices.Items.Add(item);
                    }
                }
                Cursor.Current = Cursors.Default;
                needBindInvoiceList = false;
            }
        }

        private void menuItem1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void menuItem2_Click(object sender, EventArgs e)
        {
            if (lstInvoices.SelectedIndices.Count > 0)
            {
                if (MessageBox.Show("Czy klient uregulował należność?", "Pytanie", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                    == DialogResult.Yes)
                {
                    ListViewItem item = lstInvoices.Items[lstInvoices.SelectedIndices[0]];
                    Invoice invoice = OrderManager.GetInvoiceByID((Guid)item.Tag);
                    if (!invoice.IsPaid)
                    {
                        OrderManager.MarkInvoiceAsPaid(invoice);
                        UIHelper.ShowInfo("Faktura zapłacona");
                        needBindInvoiceList = true;
                        BindInvoiceList();
                    }
                }
            }
        }

        private void tabCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (tabCustomer.SelectedIndex)
            {
                case 0:
                    break;
                case 1:
                    BindFacilityList();
                    break;
                case 2:
                    BindContactList();
                    break;
                case 3:
                    BindOrderList();
                    break;
                case 4:
                    BindInvoiceList();
                    break;
            }
        }
    }
}