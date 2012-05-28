using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using SFASystem.Pocket.Core.Common;
using SFASystem.Pocket.Core.BusinessLogic;

namespace SFASystem.Pocket.App.Controls
{
    public partial class ctrlCustomerContact : UserControl
    {
        public ctrlCustomerContact()
        {
            InitializeComponent();
        }
        private Contact contact;

        public void BindData(Contact contact)
        {
            this.contact = contact;
            this.lblImieNazwisko.Text = contact.FirstName + " " + contact.LastName;
            this.lblPhone.Text = "Tel: "+contact.Phone;
            this.lblEmail.Text = "Email: "+contact.Email;
           
        }
    }
}
