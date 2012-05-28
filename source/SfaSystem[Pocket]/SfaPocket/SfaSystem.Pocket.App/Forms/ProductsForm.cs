using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using SFASystem.Pocket.Core.BusinessLogic;
using SFASystem.Pocket.Core.Common;
using SFASystem.Pocket.App.Code;

namespace SFASystem.Pocket.App
{
    public partial class ProductsForm : Form
    {
        public ProductsForm()
        {
            InitializeComponent();
        }

        public void BindData(Guid productGroupID)
        {
            this.ctrlSelectPGroup.SelectedProductGroupId = productGroupID;
            this.ctrlSelectPGroup.BindData();

            BindList();
           // dataProdukty.DataSource = ProductManager.GetProducts(productGroupID);
        }

        private void BindList()
        {
            Guid productGID = ctrlSelectPGroup.SelectedProductGroupId;
            string name = txtName.Text;
            IList<Product> products = ProductManager.GetProducts(productGID, name);

            this.lstProducts.Items.Clear();
            foreach (Product p in products)
            {
                ListViewItem item = new ListViewItem(new string[] { p.Name, p.Price.ToString("0.00 zł") });
                item.Tag = p.ProductID;
                this.lstProducts.Items.Add(item);

            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            BindList();
        }

        private void menuItem1_Click(object sender, EventArgs e)
        {
            if (lstProducts.SelectedIndices.Count > 0)
            {
                int selectedIndex = lstProducts.SelectedIndices[0];
                ListViewItem item = lstProducts.Items[selectedIndex];
                if (item.ForeColor != Color.Red)
                    item.ForeColor = Color.Red;
                else
                    item.ForeColor = Color.Black;
            }
        }
        private void menuItem2_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in lstProducts.Items)
            {
                if (item.ForeColor == Color.Red)
                {
                    Guid productID = (Guid)item.Tag;
                    DataManager.Instance.InsertProductToOrder(productID);
                }
            }
            ApplicationManager.Instance.OrderForm.RefreshAll();
            ApplicationManager.Instance.OrderForm.Show();
        }
        private void menuItem3_Click(object sender, EventArgs e)
        {
            if (lstProducts.SelectedIndices.Count > 0)
            {
                int selectedIndex = lstProducts.SelectedIndices[0];
                //Guid productID = new Guid(lstProducts.Items[selectedIndex].SubItems[2].Text);
                Guid productID = (Guid) lstProducts.Items[selectedIndex].Tag;
                ProductDetailsForm form = new ProductDetailsForm();
                form.Show(productID);
            }
        }
    }
}