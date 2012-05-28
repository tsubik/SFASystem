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
using SFASystem.Pocket.App.Code;

namespace SFASystem.Pocket.App.Controls
{
    public partial class SelectProductGroup : UserControl
    {
        public SelectProductGroup()
        {
            InitializeComponent();
        }
        
        //Wypełnij danymi
        public void BindData()
        {
            cbxPGroups.Items.Clear();
            cbxPGroups.Items.Add(new ComboBoxItem(this.EmptyItemText, Guid.Empty));
            BindData(Guid.Empty, "--");
        }
        //Wypełnij danymi rekurencyjnie
        private void BindData(Guid ForParentEntityID, string prefix)
        {
            //pobierz liste podgrup dla danej grupy
            IList<ProductGroup> productGroupList = ProductManager.GetSubProductGroups(ForParentEntityID);
            if (productGroupList != null && productGroupList.Count > 0)
            {
                //kazda podgrupe oraz jej podgrupy dodaj do listy
                for(int i=0; i<productGroupList.Count; i++)
                {
                    ProductGroup productGroup = productGroupList[i];
                    ComboBoxItem item = new ComboBoxItem(prefix + productGroup.Name, productGroup.ProductGroupID);
                    this.cbxPGroups.Items.Add(item);
                    if (productGroup.ProductGroupID == this.selectedProductGroupID)
                        cbxPGroups.SelectedItem = item;
                    //dodaj podgrupy grupy zwiekszajac jednoczesnie wciecie
                    BindData(productGroup.ProductGroupID, prefix + "--");
                }
            }
        }
        //ID wybranej grupy produktów
        private Guid selectedProductGroupID;
        public Guid SelectedProductGroupId
        {
            get
            {
                Guid result = Guid.Empty;
                try
                {
                    ComboBoxItem item = (ComboBoxItem)this.cbxPGroups.SelectedItem;
                    result = (Guid) item.Value;
                }
                catch { }

                return result;
            }
            set
            {
                this.selectedProductGroupID = value;
            }
        }
        //Tekst, jaki przyjmuje kontrolka jeśli nie wybrano, żadnej z wartości
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

    public class ComboBoxItem
    {
        public object Value { get; set; }
        public string Text { get; set; }

        public ComboBoxItem(string text, object value)
        {
            this.Text = text;
            this.Value = value;
        }

        public override string ToString()
        {
            return this.Text;
        }
    }
}
