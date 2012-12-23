using System;
using System.Collections;
using System.Collections.Generic;

namespace SFASystem.Domain
{
    /// <summary>
    /// Order object for NHibernate mapped table 'Order'.
    /// </summary>
    [Serializable]
    public class Order : IEntity
    {
        public Order()
        {
            OrderLines = new List<OrderLine>();
        }

        public virtual Guid OrderID { get; set; }
        public virtual CustomerFacility CustomerFacility { get; set; }
        public virtual Territory Territory { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual Dictionary OrderStatus { get; set; }
        public virtual string Identifier { get; set; }
        public virtual DateTime OrderDate { get; set; }
        public virtual DateTime? DateModified { get; set; }
        public virtual decimal SubTotal { get; set; }
        public virtual decimal TaxAmount { get; set; }
        public virtual decimal Total { get; set; }
        public virtual string Comment { get; set; }
        public virtual IList<OrderLine> OrderLines { get; set; }
        public virtual bool IsDeleted { get; set; }

        #region Equals And HashCode Overrides
        /// <summary>
        /// local implementation of Equals based on unique value members
        /// </summary>
        public override bool Equals(object obj)
        {
            if (this == obj) return true;
            if ((obj == null) || (obj.GetType() != this.GetType())) return false;
            Order castObj = (Order)obj;
            return (castObj != null) &&
            this.OrderID == castObj.OrderID;
        }
        /// <summary>
        /// local implementation of GetHashCode based on unique value members
        /// </summary>
        public override int GetHashCode()
        {
            int hash = 57;
            hash = 27 * hash * OrderID.GetHashCode();
            return hash;
        }
        #endregion

    }
}
