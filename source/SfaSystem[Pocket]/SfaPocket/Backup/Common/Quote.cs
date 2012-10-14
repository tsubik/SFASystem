using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SFASystem.Pocket.Core.Common
{
    /// <summary>
    /// Quote object for NHibernate mapped table 'Quote'.
    /// </summary>
    [Serializable]
    public class Quote
    {
        #region Member Variables
        protected Guid quoteid;
        protected string text;
        protected string author;
        protected bool active;
        #endregion
        #region Constructors

        public Quote()
        {
            //this.roleid = Guid.NewGuid();
            //this.name = string.Empty;
        }

        public Quote(Guid quoteid, string text, string author)
        {
            this.quoteid = quoteid;
            this.text = text;
            this.author = author;
        }

        #endregion
        #region Public Properties
        public virtual Guid Quoteid
        {
            get { return quoteid; }
            set { quoteid = value; }
        }
        public virtual string Text
        {
            get { return text; }
            set { text = value; }
        }
        public virtual string Author
        {
            get { return author; }
            set { author = value; }
        }
        public virtual bool Active
        {
            get { return active; }
            set { active = value; }
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
            Quote castObj = (Quote)obj;
            return (castObj != null) &&
            this.quoteid == castObj.Quoteid;
        }
        /// <summary>
        /// local implementation of GetHashCode based on unique value members
        /// </summary>
        public override int GetHashCode()
        {
            int hash = 57;
            hash = 27 * hash * quoteid.GetHashCode();
            return hash;
        }
        #endregion

    }
}
