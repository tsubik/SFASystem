using System;
using System.Collections;
using System.Collections.Generic;

namespace SFASystem.Domain
{
    /// <summary>
    /// OrderLine object for NHibernate mapped table 'OrderLine'.
    /// </summary>
    [Serializable]
    public class OrderLine : IEntity
    {
        public OrderLine()
        {

        }
        public virtual OrderLineId ID { get; set; }
        public virtual int Quantity { get; set; }
        public virtual decimal ItemPrice { get; set; }
        public virtual decimal ItemPriceDiscount { get; set; }
        public virtual decimal Tax { get; set; }
        public virtual decimal Total { get; set; }
        public virtual Order Order
        {
            get { return ID.Order; }
        }
        public virtual Product Product
        {
            get { return ID.Product; }
            //set {product= value; }
        }

        #region Equals And HashCode Overrides
        /// <summary>
        /// local implementation of Equals based on unique value members
        /// </summary>
        public override bool Equals(object obj)
        {
            if (this == obj) return true;
            if ((obj == null) || (obj.GetType() != this.GetType())) return false;
            OrderLine castObj = (OrderLine)obj;
            return (castObj != null) &&
            this.ID.Equals(castObj.ID);
        }
        /// <summary>
        /// local implementation of GetHashCode based on unique value members
        /// </summary>
        public override int GetHashCode()
        {
            int hash = 57;
            hash = 27 * hash * ID.GetHashCode();
            return hash;
        }
        #endregion

    }
}
