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
    public partial class SelectTaskStatus : UserControl
    {
        public SelectTaskStatus()
        {
            InitializeComponent();
            cbxTaskStatus.SelectedIndexChanged += new EventHandler(cbxTaskStatus_SelectedIndexChanged);
        }

        void cbxTaskStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (SelectedStatusChanged != null)
                SelectedStatusChanged(sender, e);
        }

        public event EventHandler SelectedStatusChanged;

        private Guid selectedTaskStatusID;

        public void BindData()
        {

            IList<Dictionary> taskStatuses = DictionaryManager.GetDictionariesByType("Status zadania");
            cbxTaskStatus.Items.Clear();
            if (this.emptyTextVisible)
                cbxTaskStatus.Items.Add(new ComboBoxItem(this.EmptyItemText, Guid.Empty));

            if (taskStatuses != null)
            {
                foreach (Dictionary dict in taskStatuses)
                {
                    ComboBoxItem item = new ComboBoxItem(dict.Value, dict.DictionaryID);
                    this.cbxTaskStatus.Items.Add(item);
                    if (dict.DictionaryID == this.selectedTaskStatusID)
                        cbxTaskStatus.SelectedItem = item;
                }
            }
        }

        public Guid SelectedTaskStatusID
        {
            get
            {
                Guid result = Guid.Empty;
                try
                {
                    ComboBoxItem item = (ComboBoxItem)this.cbxTaskStatus.SelectedItem;
                    result = (Guid)item.Value;
                }
                catch { }

                return result;
            }
            set
            {
                this.selectedTaskStatusID = value;
            }
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

        private string emptyItemText = "[ --- ]";
        public string EmptyItemText
        {
            get
            {
                return emptyItemText;
            }
            set { emptyItemText = value; }
        }
    }
}
