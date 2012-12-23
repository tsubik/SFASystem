using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SFASystem.Domain
{
    /// <summary>
    /// Quote object for NHibernate mapped table 'Quote'.
    /// </summary>
    [Serializable]
    public class Quote : IEntity
    {
        public Quote()
        {

        }
        public virtual Guid QuoteID { get; set; }
        public virtual string Text { get; set; }
        public virtual string Author { get; set; }
        public virtual bool Active { get; set; }

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
            this.QuoteID == castObj.QuoteID;
        }
        /// <summary>
        /// local implementation of GetHashCode based on unique value members
        /// </summary>
        public override int GetHashCode()
        {
            int hash = 57;
            hash = 27 * hash * QuoteID.GetHashCode();
            return hash;
        }
        #endregion

    }
}
