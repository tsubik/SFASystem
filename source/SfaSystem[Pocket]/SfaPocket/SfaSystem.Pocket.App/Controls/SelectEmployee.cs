using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using SFASystem.Pocket.Core.Common;
using SFASystem.Pocket.Core.BusinessLogic;

namespace SFASystem.Pocket.App.Controls
{
    public partial class SelectEmployee : UserControl
    {
        public SelectEmployee()
        {
            InitializeComponent();
        }

        private Guid selectedEmployeeID;

        public void BindData(IList<Employee> employees)
        {
            cbxEmployees.Items.Clear();
            if(this.emptyTextVisible)
                cbxEmployees.Items.Add(new ComboBoxItem(this.EmptyItemText, Guid.Empty));
            
            if (employees != null)
            {
                foreach (Employee emp in employees)
                {
                    ComboBoxItem item = new ComboBoxItem(emp.ToString(), emp.EmployeeID);
                    this.cbxEmployees.Items.Add(item);
                    if (emp.EmployeeID == this.selectedEmployeeID)
                        cbxEmployees.SelectedItem = item;
                }
            }
        }

        public Guid SelectedEmployeeId
        {
            get
            {
                Guid result = Guid.Empty;
                try
                {
                    ComboBoxItem item = (ComboBoxItem)this.cbxEmployees.SelectedItem;
                    result = (Guid)item.Value;
                }
                catch { }

                return result;
            }
            set
            {
                this.selectedEmployeeID = value;
            }
        }
        private string emptyItemText = "[ --- ]";
        public string EmptyItemText
        {
            get
            {
                return emptyItemText;
            }
            set { emptyItemText = value; }
        }

        private bool emptyTextVisible = true;
        public bool EmptyTextVisible
        {
            get
            {
                return emptyTextVisible;
            }
            set
            {
                emptyTextVisible = value;
            }
        }
       

    }
}
