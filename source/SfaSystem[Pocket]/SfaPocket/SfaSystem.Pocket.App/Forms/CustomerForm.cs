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
    public partial class CustomerForm : Form
    {
        public CustomerForm()
        {
            InitializeComponent();
        }

        public void BindData()
        {
            this.ctrlSelectTerritory.EmptyItemText = "Wszystkie";
            this.ctrlSelectTerritory.BindData();

            BindList();
            // dataProdukty.DataSource = ProductManager.GetProducts(productGroupID);
        }

        private void BindList()
        {
            Guid territoryID = ctrlSelectTerritory.SelectedTerritoryId;
            string name = txtName.Text;
            IList<Customer> customers = CustomerManager.GetCustomers(territoryID, name);

            this.lstCustomers.Items.Clear();
            foreach (Customer c in customers)
            {
                this.lstCustomers.Items.Add(
                    new ListViewItem(new string[] { c.CustomerID.ToString(),c.Name, c.NIP  }));

            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            BindList();
        }

        private void menuItem1_Click(object sender, EventArgs e)
        {
            if (lstCustomers.SelectedIndices.Count > 0)
            {
                int selectedIndex = lstCustomers.SelectedIndices[0];
                Guid customerID = new Guid(lstCustomers.Items[selectedIndex].SubItems[0].Text);
                CustomerDetailsForm form = new CustomerDetailsForm();
                form.Show(customerID);
            }

        }

        private void CustomerForm_Load(object sender, EventArgs e)
        {
            BindData();
        }

        private void menuItem2_Click(object sender, EventArgs e)
        {
            ApplicationManager.Instance.MainForm.Show();
        }
    }
}