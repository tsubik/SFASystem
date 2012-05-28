using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using SFASystem.Pocket.Core.BusinessLogic;
using SFASystem.Pocket.Core.Common;
using SFASystem.Pocket.App.Code;

namespace SFASystem.Pocket.App.Controls
{
    public partial class ctrlTaskLine : UserControl
    {
        private Task task;
        public Guid TaskID
        {
            get
            {
                if (task != null)
                    return task.TaskID;
                return Guid.Empty;
            }
        }

        public ctrlTaskLine()
        {
            InitializeComponent();
        }
        public void BindData(Guid TaskID)
        {
            BindData(TaskManager.GetTaskByID(TaskID));
        }

        public void BindData(Task t)
        {
            task = t;
            this.lblName.Text = t.Name;
            this.lblDate.Text = t.DateCreated.Day + "/" + t.DateCreated.Month + "/" + t.DateCreated.Year;
            int cutTo = t.FullDescription.Length;
            if (cutTo > 100)
                cutTo = 100;
            this.lblText.Text = t.FullDescription.Substring(0, cutTo);
            if (t.FullDescription.Length > cutTo)
                this.lblText.Text += "...";
            if (t.IsApproved)
            {
                this.lblText.Font = new Font("Tahoma", 8, FontStyle.Strikeout);
            }
            if (t.TaskStatus.DictionaryNumber == (int)TaskStatusEnum.Nowe)
            {
                lblStatus.Text = "Status: Nowe";
                lblStatus.ForeColor = Color.Green;
            }
            if (t.TaskStatus.DictionaryNumber == (int)TaskStatusEnum.Rozpoczete)
            {
                lblStatus.Text = "Status: Rozpoczęte";
                lblStatus.ForeColor = Color.Red;
            }
            if (t.TaskStatus.DictionaryNumber == (int)TaskStatusEnum.Zakonczone)
            {
                lblStatus.Text = "Status: Zakończone";
                lblStatus.ForeColor = Color.Black;
            }
            if (t.TaskStatus.DictionaryNumber == (int)TaskStatusEnum.Anulowane)
            {
                lblStatus.Text = "Status: Anulowane";
                lblStatus.ForeColor = Color.Black;
            }
        }

        private void lblName_Click(object sender, EventArgs e)
        {
            //ApplicationManager.Instance.TaskDetailsForm.Show(task);
        }
    }
}
