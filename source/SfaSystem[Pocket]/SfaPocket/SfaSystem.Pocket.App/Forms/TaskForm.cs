using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using SFASystem.Pocket.Core.Common;
using SFASystem.Pocket.Core.BusinessLogic;
using SFASystem.Pocket.App.Code;
using SFASystem.Pocket.App.Controls;

namespace SFASystem.Pocket.App
{
    public partial class TaskForm : Form
    {
        public TaskForm()
        {
            InitializeComponent();
        }

        public void BindData()
        {
            selectTaskStatus1.BindData();
            BindList();
            // dataProdukty.DataSource = ProductManager.GetProducts(productGroupID);
        }

        private void BindList()
        {
            Guid taskStatusID = selectTaskStatus1.SelectedTaskStatusID;
            IList<Task> tasks =  TaskManager.GetTasks(taskStatusID, ApplicationManager.Instance.CurrentEmployee.EmployeeID).OrderByDescending(t => t.DateCreated ).ToList();
            panelMain.Controls.Clear();
            int yPos = 5;
            foreach (Task t in tasks)
            {
                ctrlTaskLine taskLine = new ctrlTaskLine();
                taskLine.Size = new Size(230, 60);
                taskLine.Left = 5;
                taskLine.Top = yPos;
                taskLine.Anchor = AnchorStyles.Right;

                taskLine.BindData(t);
                taskLine.Click += new EventHandler(taskLine_Click);
                panelMain.Controls.Add(taskLine);
                yPos += 5 + taskLine.Height;
            }
        }

        private Guid selectedTaskID;

        void taskLine_Click(object sender, EventArgs e)
        {
            ctrlTaskLine ctrl = (ctrlTaskLine)sender;

            foreach (Control control in panelMain.Controls)
            {
                if (control is ctrlTaskLine)
                {
                    ctrlTaskLine ctrl1 = (ctrlTaskLine)control;
                    ctrl1.BackColor = Color.White;
                }
            }
            selectedTaskID = ctrl.TaskID;
            ctrl.BackColor = Color.LightBlue;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            BindList();
        }

        private void menuItem1_Click(object sender, EventArgs e)
        {
            //if (lstProducts.SelectedIndices.Count > 0)
            //{
            //    int selectedIndex = lstProducts.SelectedIndices[0];
            //    Guid productID = new Guid(lstProducts.Items[selectedIndex].SubItems[2].Text);
            //    ProductDetailsForm form = new ProductDetailsForm();
            //    form.ShowDialog(productID);
            //}
            
        }

        private void menuItem2_Click(object sender, EventArgs e)
        {
            if (selectedTaskID != Guid.Empty)
            {
                ApplicationManager.Instance.TaskDetailsForm.Show(selectedTaskID);
            }
        }

        private void menuItem1_Click_1(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void selectTaskStatus1_SelectedStatusChanged(object sender, EventArgs e)
        {
            BindList();
        }
    }
}