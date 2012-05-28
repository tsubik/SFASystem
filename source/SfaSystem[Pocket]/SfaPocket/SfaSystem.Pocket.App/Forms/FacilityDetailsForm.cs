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

namespace SFASystem.Pocket.App.Forms
{
    public partial class FacilityDetailsForm : Form
    {
        public FacilityDetailsForm()
        {
            InitializeComponent();
        }

       
        bool needBindContactList = true;
        bool needBindOrderList = true;
        bool needBindInvoiceList = true;

        private CustomerFacility facility;

        public void BindData(Guid facilityID)
        {
            BindData(CustomerManager.GetCustomerFacilityByID(facilityID));
        }

        public void BindData(CustomerFacility facility)
        {
            this.facility = facility;
            if (facility != null)
            {
                this.ctrlCustomerFacility.BindData(facility);
                this.ctrlCustomerFacility.ShowDetailsButton = false;
                this.txtEmail.Text = facility.Email;
                this.txtPhone.Text = facility.Phone;
            }
        }

        private void BindContactList()
        {
            if (needBindContactList)
            {
                Cursor.Current = Cursors.WaitCursor;
                int yPos = 5;
                pageContacts.Controls.Clear();
                foreach (Contact contact in CustomerManager.GetCustomerFacContacts(facility.CustomerFacilityID))
                {
                    ctrlCustomerContact control = new ctrlCustomerContact();
                    control.BindData(contact);
                    control.Top = yPos;
                    control.Left = 5;
                    control.Width = 220;
                    control.Height = 60;

                    pageContacts.Controls.Add(control);
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
                lstFacilityOrders.Items.Clear();
                foreach (Order order in OrderManager.GetOrders(facility).OrderByDescending(o => o.OrderDate))
                {
                    ListViewItem item = new ListViewItem(new string[] {
                    order.Identifier, string.Format("{0:0.00 zł}",order.Total),
                    order.OrderStatus.Value });
                    item.Tag = order.OrderID;
                    lstFacilityOrders.Items.Add(item);
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
                if (facility != null)
                {
                    lstInvoices.Items.Clear();
                    foreach (Invoice invoice in OrderManager.GetInvoices(facility).OrderByDescending(i => i.Date))
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

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (tabControl1.SelectedIndex)
            {
                case 1:
                    BindContactList();
                    break;
                case 2:
                    BindOrderList();
                    break;
                case 3:
                    BindInvoiceList();
                    break;
            }
        }

        private void menuItem3_Click(object sender, EventArgs e)
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

        private void menuItem1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void menuItem2_Click(object sender, EventArgs e)
        {
            ApplicationManager.Instance.OrderForm.Show();
            this.Close();
        }
    }
}