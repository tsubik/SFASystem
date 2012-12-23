using System;
using System.Collections;
using System.Collections.Generic;

namespace SFASystem.Domain
{
    /// <summary>
    /// Invoice object for NHibernate mapped table 'Invoice'.
    /// </summary>
    [Serializable]
    public class Invoice : IEntity
    {
        public virtual Guid InvoiceID { get; set; }
        public virtual Order Order { get; set; }
        public virtual Dictionary InvoiceStatus { get; set; }
        public virtual string Number { get; set; }
        public virtual DateTime Date { get; set; }
        public virtual DateTime? DatePayment { get; set; }
        public virtual bool IsPaid { get; set; }

        #region Equals And HashCode Overrides
        /// <summary>
        /// local implementation of Equals based on unique value members
        /// </summary>
        public override bool Equals(object obj)
        {
            if (this == obj) return true;
            if ((obj == null) || (obj.GetType() != this.GetType())) return false;
            Invoice castObj = (Invoice)obj;
            return (castObj != null) &&
            this.InvoiceID == castObj.InvoiceID;
        }
        /// <summary>
        /// local implementation of GetHashCode based on unique value members
        /// </summary>
        public override int GetHashCode()
        {
            int hash = 57;
            hash = 27 * hash * InvoiceID.GetHashCode();
            return hash;
        }
        #endregion

    }
}
