using System;
using System.Collections;
using System.Collections.Generic;

namespace SFASystem.Domain
{
    /// <summary>
    /// OrderLineId object for NHibernate mapped table 'OrderLine'.
    /// </summary>
    [Serializable]
    public class OrderLineId
    {
        public OrderLineId()
        {

        }
        public OrderLineId(Order order, Product prod)
        {
            this.Order = order;
            this.Product = prod;
        }

        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }
        #region Equals And HashCode Overrides
        /// <summary>
        /// local implementation of Equals based on unique value members
        /// </summary>
        public override bool Equals(object obj)
        {
            if (this == obj) return true;
            if ((obj == null) || (obj.GetType() != this.GetType())) return false;
            OrderLineId castObj = (OrderLineId)obj;
            return (castObj != null) &&
            this.Order.Equals(castObj.Order) &&
            this.Product.Equals(castObj.Product);
        }
        /// <summary>
        /// local implementation of GetHashCode based on unique value members
        /// </summary>
        public override int GetHashCode()
        {
            int hash = 57;
            hash = 27 * hash * Order.GetHashCode();
            hash = 27 * hash * Product.GetHashCode();
            return hash;
        }
        #endregion

    }
}
