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
    public partial class AccountForm : Form
    {
        public AccountForm()
        {
            InitializeComponent();
        }

        private void AccountForm_Load(object sender, EventArgs e)
        {
            BindData();
        }

        public void BindData()
        {
            employeeInfo1.Employee = ApplicationManager.Instance.CurrentEmployee;
            employeeInfo1.BindData();
        }

        private void menuItem1_Click(object sender, EventArgs e)
        {
            this.Hide();
            ApplicationManager.Instance.MainForm.Show();
        }
    }
}