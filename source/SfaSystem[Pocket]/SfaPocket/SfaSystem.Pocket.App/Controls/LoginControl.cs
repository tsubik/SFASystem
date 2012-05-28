using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using SFASystem.Pocket.Core.BusinessLogic;
using SFASystem.Pocket.App.Code;
using SFASystem.Pocket.Core.Common;

namespace SFASystem.Pocket.App.Controls
{
    public partial class LoginControl : UserControl
    {
        public LoginControl()
        {
            InitializeComponent();
        }

        public event EventHandler<EventArgs> AuthorizationOK;
        public event EventHandler<EventArgs> AuthorizationCancel;
        public event EventHandler<EventArgs> WebAuthorizationOK;

        private void btnAutoryzacja_Click(object sender, EventArgs e)
        {
            string username = txtLogin.Text;
            string password = txtHaslo.Text;
            try
            {
                if (!SynchronizationManager.Instance.DatabaseExists)
                {
                    MessageBox.Show("Baza danych nie istnieje. Zostanie nawiązane połączenie z serwerem. ");
                    LoginService.LoginService service = new SFASystem.Pocket.App.LoginService.LoginService();
                    service.Url = "http://192.168.1.1:58098/Web/WebServices/LoginService.asmx";
                    Guid employeeID = service.LoginUser(username, password);
                    if (employeeID!=Guid.Empty)
                    {
                        DataManager.Instance.CurrentEmployeeID = employeeID;
                        UIHelper.ShowInfo("Pomyślna autoryzacja. Przeprowadź synchronizację!");
                        ApplicationManager.Instance.IsWebServiceAuth = true;
                        if (WebAuthorizationOK != null)
                            WebAuthorizationOK(null, null);
                    }
                    else
                        UIHelper.ShowError("Błędny login lub hasło");
                }
                else
                {
                    Employee user = EmployeeManager.GetEmployeeByLogin(username);
                    if (user != null &&
                        EmployeeManager.Login(username, password) &&
                        EmployeeManager.IsEmployeeInRole(user.EmployeeID, "SalesRep"))
                    {

                        UIHelper.ShowInfo("Pomyślna autoryzacja");
                        ApplicationManager.Instance.CurrentEmployee = user;
                        if (AuthorizationOK != null)
                            AuthorizationOK(null, null);
                    }
                    else
                    {
                        UIHelper.ShowError("Błędny login lub hasło");
                    }
                }
            }
            catch (Exception ex)
            {
                UIHelper.ShowError("Wystąpił błąd: " + ex.Message);
            }
        }

        private void btnAnuluj_Click(object sender, EventArgs e)
        {
            if (AuthorizationCancel != null)
                AuthorizationCancel(null, null);
        }
    }
}
