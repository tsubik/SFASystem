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
    public partial class SelectTerritory : UserControl
    {
        public SelectTerritory()
        {
            InitializeComponent();
        }

        private Guid selectedTerritoryID;

        public void BindData()
        {
            cbxTerritories.Items.Clear();
            cbxTerritories.Items.Add(new ComboBoxItem(this.EmptyItemText, Guid.Empty));
            BindData(Guid.Empty, "--");
        }

        public void BindData(Guid ForParentEntityID, string prefix)
        {
            IList<Territory> territories = TerritoryManager.GetSubTerritories(ForParentEntityID);
            if (territories != null)
            {
                foreach (Territory territory in territories)
                {
                    ComboBoxItem item = new ComboBoxItem(prefix + territory.Name, territory.TerritoryID);
                    this.cbxTerritories.Items.Add(item);
                    if (territory.TerritoryID == this.selectedTerritoryID)
                        cbxTerritories.SelectedItem = item;
                    if (TerritoryManager.GetSubTerritories(territory.TerritoryID).Count > 0)
                        BindData(territory.TerritoryID, prefix + "--");
                }
            }
        }

        public Guid SelectedTerritoryId
        {
            get
            {
                Guid result = Guid.Empty;
                try
                {
                    ComboBoxItem item = (ComboBoxItem)this.cbxTerritories.SelectedItem;
                    result = (Guid) item.Value;
                }
                catch { }

                return result;
            }
            set
            {
                this.selectedTerritoryID = value;
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
