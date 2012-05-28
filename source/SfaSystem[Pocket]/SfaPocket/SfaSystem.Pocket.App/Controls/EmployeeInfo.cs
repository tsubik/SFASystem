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
using SFASystem.Pocket.App.Code;

namespace SFASystem.Pocket.App.Controls
{
    public partial class EmployeeInfo : UserControl
    {
        private Employee employee;
        public Employee Employee
        {
            get { return employee; }
            set { employee = value; }
        }

        public EmployeeInfo()
        {
            InitializeComponent();
        }

        public void BindData()
        {
            if(employee!=null)
            {
                if(employee.Contact!=null)
                {
                    txtImie.Text = employee.Contact.FirstName;
                    txtNazwisko.Text = employee.Contact.LastName;
                    txtEmail.Text = employee.Contact.Email;
                    txtNrTelefonu.Text = employee.Contact.Phone;
                }
                lblLogin.Text = employee.Login;
            }
        }

        private void btnZapisz_Click(object sender, EventArgs e)
        {
            if (employee != null)
            {
                try
                {
                    Contact contact = null;

                    if (employee.Contact == null)
                        contact = new Contact();
                    else
                        contact = employee.Contact;

                    contact.Email = txtEmail.Text;
                    contact.FirstName = txtImie.Text;
                    contact.LastName = txtNazwisko.Text;
                    contact.Phone = txtNrTelefonu.Text;

                    if (employee.Contact == null)
                    {
                        contact = ContactManager.InsertContact(contact);
                        employee.ContactID = contact.ContactID;
                    }
                    else
                        ContactManager.UpdateContact(contact);

                    if (employee.CreationDate == DateTime.MinValue)
                        employee.CreationDate = DateTime.Now;
                    if (employee.LastActivityDate == DateTime.MinValue)
                        employee.LastActivityDate = DateTime.Now;
                    if (employee.LastLoginDate == DateTime.MinValue)
                        employee.LastLoginDate = DateTime.Now;

                    EmployeeManager.UpdateEmployee(employee);
                    UIHelper.ShowInfo("Zmiany wprowadzone");
                }
                catch (Exception ex)
                {
                    UIHelper.ShowError("Błąd : " + ex.Message);
                }
                
            }
        }
    }
}
