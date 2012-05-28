using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SFASystem.WebUtils;
using SFASystem.Services;
using SFASystem.Domain;

public partial class Administration_Controls_Employee_EmployeeTaskInfo : System.Web.UI.UserControl
{
    private void BindData()
    {
        Task task = BasicService<Task, Guid>.GetByID(this.TaskID);

        if (task != null)
        {
            Employee loggedEmp = SFAContext.Current.Employee;
            if (task.GivenBy == loggedEmp || task.CreatedBy == loggedEmp)
            {
                trIsApproved.Visible = true;
            }
            if (task.IsApproved)
            {
                chxApprove.Checked = true;
                chxApprove.Enabled = false;
                trApprovedBy.Visible = true;
                lblApprovedBy.Text = task.ApprovedBy.FriendlyName;
            }
            txtName.Text = task.Name;
            txtName.Enabled = false;
            txtDescription.Text = task.FullDescription;
            ctrlSelectAssignedTo.SelectedEmployeeID = task.AssignedTo.Employeeid;
            lblCreatedBy.Text = task.CreatedBy.FriendlyName;
            lblCreatedDate.Text = task.DateCreated.ToString();
            lblGivenBy.Text = task.GivenBy.FriendlyName;

            if (!task.IsApproved)
                trApprovedBy.Visible = false;
            ctrlSelectStatus.SelectedStatusID = task.TaskStatus.Dictionaryid;
            if (task.TaskStatus.Value == "Zakończone" || task.TaskStatus.Value == "Anulowane")
            {
                ctrlSelectStatus.Enabled = false;
                ctrlSelectAssignedTo.Enabled = false;
                txtDescription.Enabled = false;
            }
            panelAddEndDate.Visible = false;
            panelViewEndDate.Visible = true;
            lblEndDate.Text = task.DateToEndTask.HasValue ? task.DateToEndTask.Value.ToString() : "";

        }
        else
        {
            trApprovedBy.Visible = false;
            trCreatedBy.Visible = false;
            trDateExecuted.Visible = false;
            trCreatedDate.Visible = false;
            trGivenBy.Visible = false;
            trIsApproved.Visible = false;
            trStatus.Visible = false;

            panelAddEndDate.Visible = true;
            panelViewEndDate.Visible = false;
        }
        ctrlSelectAssignedTo.BindData();
        ctrlSelectStatus.BindData();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            this.BindData();
        }
    }

    public Task SaveInfo()
    {
        if (!Page.IsValid)
            return null;

        Task task = BasicService<Task, Guid>.GetByID(this.TaskID);
        if (task != null)
        {
            if (task.TaskStatus.Value == "Zakończone")
                return null;
            if (task.TaskStatus.Value == "Anulowane")
                return null;
        }
        if (task == null)
        {
            task = new Task();
            task.DateCreated = DateTime.Now;
            task.CreatedBy = SFAContext.Current.Employee;
            DateTime dateToEnd = DateTime.MinValue;
            DateTime.TryParse(txtEndDate.Text, out dateToEnd);

            if (dateToEnd != DateTime.MinValue)
                task.DateToEndTask = dateToEnd;
            task.Name = txtName.Text;
        }
        task.FullDescription = txtDescription.Text;
        task.AssignedTo = BasicService<Employee, Guid>.GetByID(ctrlSelectAssignedTo.SelectedEmployeeID);
        task.DateModified = DateTime.Now;
        if(task.AssignedTo.Employeeid != ctrlSelectAssignedTo.SelectedEmployeeID)    
            task.GivenBy = SFAContext.Current.Employee;
        task.TaskStatus = BasicService<Dictionary, Guid>.GetByID(ctrlSelectStatus.SelectedStatusID);
        if (task.TaskStatus == null)
            task.TaskStatus = EmployeeService.GetTaskStatusByName("Nowe");
        //jezeli zakonczono zadanie
        if (task.TaskStatus.DictionaryNumber == (byte) TaskStatusEnum.Zakonczone)
        {
            task.DateExecuted = DateTime.Now;
        }
        if (trIsApproved.Visible == true)
        {
            //potwierdzenie zadania
            if (chxApprove.Enabled == true && chxApprove.Checked)
            {
                task.TaskStatus = EmployeeService.GetTaskStatusByName("Zakończone");
                task.DateModified = DateTime.Now;
            }
        }

        BasicService<Task, Guid>.SaveOrUpdate(task);
        return task;
    }

    public Guid TaskID
    {
        get
        {
            return CommonHelper.QueryStringGUID("TaskID");
        }
    }
}
