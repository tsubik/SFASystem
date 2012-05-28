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
    public partial class LogonForm : Form
    {
        public LogonForm()
        {
            InitializeComponent();
            //RDAManager.Instance.SynchronizationCompleted += new EventHandler<SyncComplEventArgs>(Instance_SynchronizationCompleted);
            //RDAManager.Instance.SynchronizationError += new EventHandler<SyncErrorEventArgs>(Instance_SynchronizationError);
            loginControl1.AuthorizationCancel += new EventHandler<EventArgs>(loginControl1_AuthorizationCancel);
            loginControl1.AuthorizationOK += new EventHandler<EventArgs>(loginControl1_AuthorizationOK);
            loginControl1.WebAuthorizationOK += new EventHandler<EventArgs>(loginControl1_WebAuthorizationOK);
            if (ApplicationManager.Instance.IsWebServiceAuth == false && !SynchronizationManager.Instance.DatabaseExists)
                btnSynchronizacja.Visible = false;
        }

        void loginControl1_WebAuthorizationOK(object sender, EventArgs e)
        {
            btnSynchronizacja.Visible = true;
        }

        void loginControl1_AuthorizationOK(object sender, EventArgs e)
        {
            //UIHelper.ShowInfo("Zalogowano");
            ApplicationManager.Instance.MainForm.Show();
        }

        void loginControl1_AuthorizationCancel(object sender, EventArgs e)
        {
            Application.Exit();
        }

        void Instance_SynchronizationError(object sender, SyncErrorEventArgs e)
        {
            if (InvokeRequired)
                this.Invoke(new EventHandler<SyncErrorEventArgs>(this.Instance_SynchronizationError), new object[] { sender, e });
            else
            {
                //synchroControl1.Visible = false;
                btnSynchronizacja.Enabled = true;
                loginControl1.Enabled = true;
            }
        }

        void Instance_SynchronizationCompleted(object sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                this.Invoke(new EventHandler<EventArgs>(this.Instance_SynchronizationCompleted), new object[] { sender, e });
            }
            else
            {
                UIHelper.ShowInfo("Zaloguj się do aplikacji.");
                //btnSynchronizacja.Enabled = true;
                //loginControl1.Enabled = true;
            }
        }

        private void btnSynchronizacja_Click(object sender, EventArgs e)
        {
            SynchroDialog dialog = new SynchroDialog();
            dialog.ShowDialog();
        }
    }
}