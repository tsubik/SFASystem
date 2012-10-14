/*
using MyGeneration/Template/NHibernate (c) by lujan99@usa.net
*/
using System;
using System.Collections;
using System.Collections.Generic;
using SFASystem.Pocket.Core.BusinessLogic;

namespace SFASystem.Pocket.Core.Common
{
    /// <summary>
    /// Invoice object for NHibernate mapped table 'Invoice'.
    /// </summary>
    [Serializable]
    public class Invoice
    {
        #region Member Variables
        protected Guid invoiceid;
        protected Guid orderID;
        protected Order order;
        protected Guid invoiceStatusID;
        protected Dictionary invoicestatus;
        protected string number;
        protected DateTime date;
        protected DateTime? datepayment;
        protected bool ispaid;
        #endregion
        #region Constructors

        public Invoice()
        {
            //this.invoiceid = Guid.NewGuid();
            //this.order = null;
            //this.invoicestatus = null;
            //this.number = string.Empty;
            //this.ispaid = false;
            //this.date = DateTime.MinValue;
            //this.datepayment = DateTime.MinValue;
        }

        public Invoice(Guid invoiceid, Order order, Dictionary invoicestatus, string number, DateTime date, DateTime? datepayment, bool ispaid)
        {
            this.invoiceid = invoiceid;
            this.order = order;
            this.invoicestatus = invoicestatus;
            this.number = number;
            this.date = date;
            this.datepayment = datepayment;
            this.ispaid = ispaid;
        }

        public Invoice(Guid invoiceid, Order order, Dictionary invoicestatus, string number, DateTime date, bool ispaid)
        {
            this.invoiceid = invoiceid;
            this.order = order;
            this.invoicestatus = invoicestatus;
            this.number = number;
            this.date = date;
            this.ispaid = ispaid;
        }

        #endregion
        #region Public Properties
        public virtual Guid Invoiceid
        {
            get { return invoiceid; }
            set { invoiceid = value; }
        }

        public virtual Guid OrderID
        {
            get { return orderID; }
            set { orderID = value; }
        }

        public virtual Guid InvoiceStatusID
        {
            get { return invoiceStatusID; }
            set { invoiceStatusID = value; }
        }

        public virtual Order Order
        {
            get
            {
                if (order == null)
                    order = OrderManager.GetOrderByID(this.orderID);
                return order;
            }
            set { order = value; }
        }
        public virtual Dictionary InvoiceStatus
        {
            get
            {
                if (invoicestatus == null)
                    invoicestatus = DictionaryManager.GetDictionaryByID(this.invoiceStatusID);

                return invoicestatus;
            }
            set {
                if (value != null)
                {
                    invoiceStatusID = value.DictionaryID;
                }
                invoicestatus = value; }
        }
        public virtual string Number
        {
            get { return number; }
            set { number = value; }
        }
        public virtual DateTime Date
        {
            get { return date; }
            set { date = value; }
        }
        public virtual DateTime? DatePayment
        {
            get { return datepayment; }
            set { datepayment = value; }
        }
        public virtual bool IsPaid
        {
            get { return ispaid; }
            set { ispaid = value; }
        }
        #endregion

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
            this.invoiceid == castObj.Invoiceid;
        }
        /// <summary>
        /// local implementation of GetHashCode based on unique value members
        /// </summary>
        public override int GetHashCode()
        {
            int hash = 57;
            hash = 27 * hash * invoiceid.GetHashCode();
            return hash;
        }
        #endregion

    }
}
