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
    public partial class ProductGroupTree : UserControl
    {

        public event EventHandler<ProductGroupTreeEventArgs> SelectedProductGroup;
        private void OnSelectProductGroup(object sender, ProductGroupTreeEventArgs args)
        {
            if (SelectedProductGroup != null)
                SelectedProductGroup(sender, args);
        }

        public Guid SelectedProductGroupID
        {
            get
            {
                if (treeProductGroups.SelectedNode != null)
                {
                    return (Guid)treeProductGroups.SelectedNode.Tag;
                }
                return Guid.Empty;
            }
        }


        public ProductGroupTree()
        {
            InitializeComponent();
        }

        public void BindTree()
        {
            CreateTree(treeProductGroups.Nodes, Guid.Empty);   
        }

        public void DeSelectTree()
        {
            this.treeProductGroups.SelectedNode = null;
        }

        private void CreateTree(TreeNodeCollection whereToAdd, Guid masterProductGroupID)
        {
            IList<ProductGroup> productGroups = ProductManager.GetSubProductGroups(masterProductGroupID);
            //IList<ProductGroup> productGroups = DataManager.Instance.ProductGroups.Where(pg => pg.ParentProductGroupID == masterProductGroupID).ToList();
            foreach (ProductGroup prodGroup in productGroups)
            {
                TreeNode node = whereToAdd.Add(prodGroup.Name);
                node.Tag = prodGroup.ProductGroupID;
                CreateTree(node.Nodes, prodGroup.ProductGroupID);
            }
        }

        private void treeProductGroups_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Action == TreeViewAction.ByMouse)
            {
                Guid guid = (Guid)e.Node.Tag;
                if (guid != Guid.Empty)
                {
                    OnSelectProductGroup(sender, new ProductGroupTreeEventArgs(guid));
                }
            }
        }
    }

    
}
