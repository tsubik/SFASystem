using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using SFASystem.WebUtils;
using System.Web.Security;

namespace SFASystem.Web.Administration.Controls
{

    public partial class EmployeeChangePasswordControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            pnlChangePasswordError.Visible = false;
        }

        protected void btnChangePassword_Click(object sender, EventArgs e)
        {
            MessageBoxControl messageBox = Page.Master.FindControl("messageBox") as MessageBoxControl;
            try
            {
                if (Page.IsValid)
                {
                    string oldPassword = txtOldPassword.Text;
                    string password = txtNewPassword.Text;
                    string confirmPassword = txtConfirmPassword.Text;

                    if (password != confirmPassword)
                    {
                        messageBox.ShowError("Wprowadzone hasło nie pasuje do potwierdzenia");
                    }
                    else
                    {
                        MembershipUser user = Membership.GetUser(SFAContext.Current.Employee.Login);
                        if (user.ChangePassword(oldPassword, password))
                        {
                            messageBox.ShowSuccess("Hasło zostało zmienione");
                        }
                        else
                        {
                            messageBox.ShowError("Wystąpił błąd przy zmianie hasła");
                        }
                    }
                    txtOldPassword.Text = string.Empty;
                    txtNewPassword.Text = string.Empty;
                    txtConfirmPassword.Text = string.Empty;
                }
            }
            catch (Exception exc)
            {
                messageBox.ShowError("Wystąpił błąd przy zmianie hasła");
                //pnlChangePasswordError.Visible = true;
                //lChangePasswordErrorMessage.Text = Server.HtmlEncode(exc.Message);
            }
        }
    }
}