using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using SFASystem.Pocket.Core.BusinessLogic;
using SFASystem.Pocket.Core.Common;
using SFASystem.Pocket.App.Code;

namespace SFASystem.Pocket.App.Controls
{
    public partial class ctrlCustomerFacility : UserControl
    {
        private CustomerFacility facility;


        public bool ShowDetailsButton
        {
            get { return btnDetails.Visible; }
            set { btnDetails.Visible = value; }
        }

        public ctrlCustomerFacility()
        {
            InitializeComponent();
        }

        public void BindData(Guid CustomerFacilityID)
        {
            BindData(CustomerManager.GetCustomerFacilityByID(CustomerFacilityID));
        }

        public void BindData(CustomerFacility fac)
        {
            facility = fac;
            this.lblName.Text = facility.Name;
            this.lblRegion.Text = "Region: " + facility.Territory.Name;
            this.lblUlica.Text = "Ulica: " + facility.Address.Street + " " + facility.Address.HouseNr + "/" + facility.Address.ApartmentNr;
            this.lblKod.Text = "Kod: " + facility.Address.ZipCode;
            this.lblKraj.Text = "Kraj: " + facility.Address.Country.Name;
            this.lblMiasto.Text = "Miasto: " + facility.Address.City.Name;
        }


        private void btnDetails_Click(object sender, EventArgs e)
        {
            ApplicationManager.Instance.FacilityDetailsForm.BindData(facility);
            ApplicationManager.Instance.FacilityDetailsForm.Show();
        }

        private void btnZamów_Click(object sender, EventArgs e)
        {
            
            if(MessageBox.Show("Czy tworzyć zamówienie dla tej placówki?", "Pytanie",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                DataManager.Instance.CurrentOrder.CustomerFacilityID = facility.CustomerFacilityID;
                ApplicationManager.Instance.OrderForm.RefreshCustomer();
                ApplicationManager.Instance.OrderForm.Show();
            }
        }
    }
}
