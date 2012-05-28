using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using SFASystem.Pocket.App.Code;

namespace SFASystem.Pocket.App
{
    public partial class ProductGroupForm : Form
    {
        public ProductGroupForm()
        {
            InitializeComponent();
            //productGroupTree.SelectedProductGroup += new EventHandler<ProductGroupTreeEventArgs>(productGroupTree_SelectedProductGroup);
        }

        void productGroupTree_SelectedProductGroup(object sender, ProductGroupTreeEventArgs e)
        {
            if (e.ProductGroupID != Guid.Empty)
            {
                
                //ApplicationManager.Instance.ShowForm(this, ApplicationManager.Instance.ProductsForm);
                //ApplicationManager.Instance.ProductsForm.BindData(e.ProductGroupID);
                
                ApplicationManager.Instance.ProductsForm.BindData(e.ProductGroupID);
                ApplicationManager.Instance.ProductsForm.Show();
                this.Hide();
                //ApplicationManager.Instance.ProductsForm.BringToFront();
                
                
            }
        }

        private void ProductGroupForm_Load(object sender, EventArgs e)
        {
            productGroupTree.BindTree();
        }

        private void ProductGroupForm_Activated(object sender, EventArgs e)
        {
            productGroupTree.DeSelectTree();
        }

        private void menuItem2_Click(object sender, EventArgs e)
        {
            if (productGroupTree.SelectedProductGroupID != Guid.Empty)
            {
                ApplicationManager.Instance.ProductsForm.BindData(productGroupTree.SelectedProductGroupID);
                ApplicationManager.Instance.ProductsForm.Show();
                this.Hide();
            }
        }

        private void menuItem1_Click(object sender, EventArgs e)
        {
            ApplicationManager.Instance.MainForm.Show();
        }
    }
}