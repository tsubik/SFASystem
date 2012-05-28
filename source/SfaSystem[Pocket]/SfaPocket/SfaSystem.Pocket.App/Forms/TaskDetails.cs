using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using SFASystem.Pocket.App.Code;
using SFASystem.Pocket.Core.Common;
using SFASystem.Pocket.Core.BusinessLogic;

namespace SFASystem.Pocket.App
{
    public partial class TaskDetails : Form
    {
        private Task task;

        public TaskDetails()
        {
            InitializeComponent();
        }

        public void Show(Guid taskID)
        {
            BindData(taskID);
            Show();
        }

        private void BindData(Guid taskID)
        {
            BindData(TaskManager.GetTaskByID(taskID));
        }
        public void Show(Task task)
        {
            BindData(task);
            Show();
        }

        private void BindData(Task t)
        {
            task = t;
            lblName.Text = t.Name;
            lblDescription.Text = t.FullDescription;
            lblDateCreated.Text = t.DateCreated.ToString("dd/mm/yyyy hh:mm");
            lblCreatedBy.Text = t.CreatedBy.ToString();
            lblAssignedBy.Text = t.AssignedTo.ToString();
            IList<Employee> employees = EmployeeManager.GetEmployees(true);
            if (t.GivenByID == ApplicationManager.Instance.CurrentEmployee.EmployeeID
                && (t.TaskStatus.DictionaryNumber == (int)TaskStatusEnum.Zakonczone
                || t.TaskStatus.DictionaryNumber == (int)TaskStatusEnum.Anulowane))
            {
                chxApproved.Enabled = true;
            }
            else
                chxApproved.Enabled = false;

            selectEmployee.SelectedEmployeeId = t.AssignedToID;
            selectEmployee.EmptyTextVisible = false;
            selectEmployee.BindData(employees);
            selectTaskStatus.EmptyTextVisible = false;
            selectTaskStatus.SelectedTaskStatusID = t.TaskStatusID;
            selectTaskStatus.BindData();
            chxApproved.Checked = t.IsApproved;
        }


        private void btnZamknijDeleguj_Click(object sender, EventArgs e)
        {
            panelDeleguj.Visible = false;
        }

        private void btnDeleguj_Click(object sender, EventArgs e)
        {
            panelDeleguj.Visible = !panelDeleguj.Visible;

        }

        private void btnDelegujZapisz_Click(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (selectEmployee.SelectedEmployeeId == Guid.Empty)
                UIHelper.ShowError("Wybierz pracownika dla którego jest zadanie");
            //jezeli dajemy komu innemu
            if (task.AssignedToID != selectEmployee.SelectedEmployeeId)
            {
                task.GivenByID = ApplicationManager.Instance.CurrentEmployee.EmployeeID;
            }
            task.AssignedToID = selectEmployee.SelectedEmployeeId;
            task.TaskStatusID = selectTaskStatus.SelectedTaskStatusID;
            if (task.TaskStatus.DictionaryNumber == (int)TaskStatusEnum.Zakonczone && chxApproved.Enabled
                && chxApproved.Checked)
            {
                task.IsApproved = true;
                task.ApprovedByID = ApplicationManager.Instance.CurrentEmployee.EmployeeID;
            }

            TaskManager.UpdateTask(task);
        }
    }
}