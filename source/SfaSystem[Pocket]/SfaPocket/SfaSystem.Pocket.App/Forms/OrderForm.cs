using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using SFASystem.Pocket.App.Code;
using SFASystem.Pocket.Core.Common;
using SFASystem.Pocket.Core.BusinessLogic;

namespace SFASystem.Pocket.App.Forms
{
    public partial class OrderForm : Form
    {
        public OrderForm()
        {
            InitializeComponent();
        }

        public void RefreshCustomer()
        {
            Order order = DataManager.Instance.CurrentOrder;
            if (order.CustomerFacilityID != Guid.Empty)
            {
                lblCustomerFacility.Text = order.CustomerFacility.Name + " " + order.CustomerFacility.Customer.Name;
            }
        }
        public void RefreshOrderLines()
        {
            lstOrderLines.Items.Clear();
            int idx = 1;
            Order order = DataManager.Instance.CurrentOrder;
            if (order.OrderLines != null)
            {
                foreach (OrderLine line in order.OrderLines)
                {
                    ListViewItem item = new ListViewItem(new string[] { idx.ToString(),
                    line.Product.Name, line.Quantity.ToString(), line.Total.ToString("0.00 zł") });
                    item.Tag = line.ProductID;
                    lstOrderLines.Items.Add(item);
                }
            }
        }

        public void UpdateSummary()
        {
            Order order = DataManager.Instance.CurrentOrder;
            decimal nettoPrice = 0;
            decimal bruttoPrice = 0;
            decimal tax = 0;
            foreach (OrderLine line in order.OrderLines)
            {
                bruttoPrice += line.Total;
                tax += line.Tax;
            }
            lblBruttoPrice.Text = "Wartość Brutto: " + bruttoPrice.ToString("0.00 zł");
            lblVAT.Text = "Wartość VAT   : "+tax.ToString("0.00 zł");
            nettoPrice = bruttoPrice - tax;
            lblNettoPrice.Text = "Wartość netto : " + nettoPrice.ToString("0.00 zł");
            order.SubTotal = nettoPrice;
            order.TaxAmount = tax;
            order.Total = bruttoPrice;
        }

        public void RefreshAll()
        {
            RefreshCustomer();
            RefreshOrderLines();
            txtComment.Text = DataManager.Instance.CurrentOrder.Comment;
            UpdateSummary();
        }

        private void btnPlus_Click(object sender, EventArgs e)
        {
            try
            {
                int quantity = Int32.Parse(txtQuantity.Text);
                quantity++;
                txtQuantity.Text = quantity.ToString();
            }
            catch
            {
            }
        }

        private void btnMinus_Click(object sender, EventArgs e)
        {
            try
            {
                int quantity = Int32.Parse(txtQuantity.Text);
                quantity--;
                txtQuantity.Text = quantity.ToString();
            }
            catch
            {
            }
        }

        private void btnSetCustomer_Click(object sender, EventArgs e)
        {
            ApplicationManager.Instance.CustomerForm.BindData();
            ApplicationManager.Instance.CustomerForm.Show();
            this.Hide();
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            ApplicationManager.Instance.ProductGroupForm.Show();
            this.Hide();
        }

        private void lstOrderLines_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstOrderLines.SelectedIndices.Count > 0)
            {
                int index = lstOrderLines.SelectedIndices[0];
                ListViewItem item = lstOrderLines.Items[index];

                int quantity = Int32.Parse(item.SubItems[2].Text);
                txtQuantity.Text = quantity.ToString();
            }
            else
            {
                txtQuantity.Text = string.Empty;
            }
        }

        public void ClearForm()
        {
            this.lstOrderLines.Items.Clear();
            this.lblBruttoPrice.Text = "Wartość Brutto: ";
            this.lblNettoPrice.Text = "Wartość netto : ";
            this.lblVAT.Text = "Wartość VAT   : ";
            this.lblCustomerFacility.Text = "Nie wybrano";
            this.txtQuantity.Text = String.Empty;
            this.txtComment.Text = String.Empty;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            if (lstOrderLines.SelectedIndices.Count > 0 && txtQuantity.Text!=string.Empty)
            {
                try
                {
                    int quantity = Int32.Parse(txtQuantity.Text);
                    int index = lstOrderLines.SelectedIndices[0];
                    ListViewItem item = lstOrderLines.Items[index];
                    item.SubItems[2].Text = quantity.ToString();
                    
                    Guid prodID = (Guid) item.Tag;
                    OrderLine line = DataManager.Instance.CurrentOrder.OrderLines.Where(l => l.ProductID == prodID).Single();
                    line.Quantity = quantity;
                    line.Total = line.Quantity * line.ItemPrice;
                    int taxValue = Int32.Parse(line.Product.Tax.Value);
                    line.Tax = (decimal)((float)line.ItemPrice / (1 + 100.0f / taxValue))* quantity;
                    item.SubItems[3].Text = line.Total.ToString()+" zł";
                    
                    UpdateSummary();
                }
                catch
                {
                }
            }
        }

        private void btnAddOrder_Click(object sender, EventArgs e)
        {
            Order order = DataManager.Instance.CurrentOrder;
            order.Comment = txtComment.Text;
            if(order.CustomerFacilityID == Guid.Empty)
            {
                MessageBox.Show("Wybierz placówkę dla której tworzone zamówienie.");
                return;
            }
            if(order.OrderLines.Count == 0)
            {
                MessageBox.Show("Dodaj produkty do zamówienia.");
                return;
            }
            order.EmployeeID = ApplicationManager.Instance.CurrentEmployee.EmployeeID;
            order.TerritoryID = CustomerManager.GetCustomerFacilityByID(order.CustomerFacilityID).TerritoryID;
            order.OrderStatusID = DictionaryManager.GetDictionaryByEnumAndType((int)OrderStatusEnum.Nowe, "Status zamówienia").DictionaryID;
            
            if (MessageBox.Show("Czy zatwierdzić zamówienie?", "Zatwierdzenie", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                OrderManager.InsertOrder(order);
                DataManager.Instance.CurrentOrder = null;
                UIHelper.ShowInfo("Zamówienie poprawnie złożone. Pamiętaj o synchronizacji.");
                ClearForm();
                this.Hide();
                ApplicationManager.Instance.MainForm.Show();
            }
        }

        private void menuItem1_Click(object sender, EventArgs e)
        {
            this.Hide();
            ApplicationManager.Instance.MainForm.Show();
        }

        private void btnRemoveProduct_Click(object sender, EventArgs e)
        {
            if (lstOrderLines.SelectedIndices.Count > 0)
            {
                ListViewItem item = lstOrderLines.Items[lstOrderLines.SelectedIndices[0]];
                Guid productID = (Guid) item.Tag;
                DataManager.Instance.RemoveProductFromOrder(productID);
                lstOrderLines.Items.Remove(item);
                UpdateSummary();
            }
        }
    }
}