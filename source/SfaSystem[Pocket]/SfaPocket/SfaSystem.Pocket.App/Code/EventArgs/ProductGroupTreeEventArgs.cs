using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace SFASystem.Pocket.App.Code
{
    public class ProductGroupTreeEventArgs : EventArgs
    {
        public Guid ProductGroupID { get; set; }

        public ProductGroupTreeEventArgs(Guid id)
        {
            this.ProductGroupID = id;
        }
    }
}
