using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using SFASystem.Pocket.App.Controls;
using SFASystem.Pocket.App.Code;

namespace SFASystem.Pocket.App
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        //Klikniecie na opcje z menu
        private void mainMenu_ItemActivate(object sender, EventArgs e)
        {
            int index = mainMenu.SelectedIndices[0];
            switch (index)
            {
                //klienci
                case 0:
                    ApplicationManager.Instance.CustomerForm.Show();
                    break;
                //produkty
                case 1:
                    ApplicationManager.Instance.ProductGroupForm.Show();
                    break;
                //zamowienia
                case 2:
                    ApplicationManager.Instance.OrderForm.Show();
                    break;
                //taski
                case 3:
                    ApplicationManager.Instance.TaskForm.BindData();
                    ApplicationManager.Instance.TaskForm.Show();
                    break;
                //moje konto
                case 4:
                    ApplicationManager.Instance.AccountForm.BindData();
                    ApplicationManager.Instance.AccountForm.Show();
                    break;
                //koniec
                case 5:
                    Application.Exit();
                    break;
            }
        }

        /// <summary>
        /// Synchronizacja
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuItem2_Click(object sender, EventArgs e)
        {
            SynchroDialog dialog = new SynchroDialog();
            dialog.ShowDialog();
        }

        private void MainForm_Closing(object sender, CancelEventArgs e)
        {
            Application.Exit();
        }
    }
}