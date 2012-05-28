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
using SFASystem.Pocket.App.Code;

namespace SFASystem.Pocket.App
{
    public partial class ProductDetailsForm : Form
    {
        private Product product;

        public ProductDetailsForm()
        {
            InitializeComponent();
        }

        public void Show(Guid productID)
        {
            BindData(productID);
            Show();
        }
        public void ShowDialog(Guid productID)
        {
            BindData(productID);
            ShowDialog();
        }

        public void BindData(Guid ProductID)
        {
            Product product = ProductManager.GetProductByID(ProductID);
            this.product = product;
            if (product != null)
            {
                this.Text = product.Name;
                this.txtName.Text = product.Name;
                this.txtCode.Text = product.Code;
                this.txtShortDesc.Text = product.ShortDescription;
                this.txtDesc.Text = product.FullDescription;
                this.txtGroup.Text = product.ProductGroup.Name;
                this.txtPrice.Text = product.Price.ToString("0.00 zł");
            }
        }

        private void btnAddToOrder_Click(object sender, EventArgs e)
        {
            if (this.product != null)
                DataManager.Instance.InsertProductToOrder(this.product.ProductID);
            MessageBox.Show("Dodano do zamówienia");
        }

        private void menuItem1_Click(object sender, EventArgs e)
        {
            //this.Hide();
            ApplicationManager.Instance.ProductsForm.Show();
        }

        private void menuItem2_Click(object sender, EventArgs e)
        {
            ApplicationManager.Instance.OrderForm.RefreshOrderLines();
            ApplicationManager.Instance.OrderForm.UpdateSummary();
            ApplicationManager.Instance.OrderForm.Show();
            //this.Hide();
        }
    }
}