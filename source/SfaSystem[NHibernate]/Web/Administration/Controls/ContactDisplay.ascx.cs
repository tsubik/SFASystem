using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SFASystem.Domain;
using SFASystem.Services;


namespace SFASystem.Web.Administration.Controls
{

    public partial class ContactDisplayControl : System.Web.UI.UserControl
    {
        public ControlMode Mode
        {
            get
            {
                object obj = ViewState["ControlMode"];
                if (obj == null)
                    return ControlMode.ShowMode;
                return (ControlMode)obj;
            }
            set
            {
                ViewState["ControlMode"] = value;
                SetControlMode();
            }
        }

        public bool ShowEditButton
        {
            set
            {
                btnEdit.Visible = value;
            }
        }

        private void SetControlMode()
        {
            if (this.Mode == ControlMode.EditMode)
            {
                pnlEdit.Visible = true;
                pnlShow.Visible = false;
            }
            else
            {
                pnlEdit.Visible = false;
                pnlShow.Visible = true;
            }
            BindData(BasicService<Contact, Guid>.GetByID(this.ContactID));
        }

        public Guid ContactID
        {
            get
            {
                Object obj = ViewState["ContactID"];
                Guid result;
                if (obj == null)
                    return Guid.Empty;
                result = (Guid)obj;
                return result;
            }
            set
            {
                ViewState["ContactID"] = value;
            }
        }

        public void BindData(Contact contact)
        {
            this.ContactID = contact.ContactID;
            txtImie.Text = contact.FirstName;
            txtNazwisko.Text = contact.LastName;
            txtEmail.Text = contact.Email;
            txtTelefon.Text = contact.Phone;

            lblEmail.Text = contact.Email;
            lblFullName.Text = contact.FirstName + " " + contact.LastName;
            lblPhone.Text = contact.Phone;
        }

        public Contact Contact
        {
            get
            {
                return BasicService<Contact, Guid>.GetByID(this.ContactID);
            }
        }
        protected void btnContactSave_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                Contact contact = this.Contact;
                contact.FirstName = txtImie.Text;
                contact.LastName = txtNazwisko.Text;
                contact.Email = txtEmail.Text;
                contact.Phone = txtTelefon.Text;

                BasicService<Contact, Guid>.SaveOrUpdate(contact);
                MessageBoxControl msgBox = (MessageBoxControl)Page.Master.FindControl("messageBox");
                msgBox.ShowSuccess("Zmiany kontaktu wprowadzono.");
                this.Mode = ControlMode.ShowMode;
            }
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            this.Mode = ControlMode.ShowMode;
        }
        protected void btnEdit_Click(object sender, EventArgs e)
        {
            this.Mode = ControlMode.EditMode;
        }
    }
}