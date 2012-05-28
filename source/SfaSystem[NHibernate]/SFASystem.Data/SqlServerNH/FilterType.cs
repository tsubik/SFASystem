using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SFASystem.DataAccess.SqlServerNH
{
    public class Filter
    {
        public string ColumnName { get; set; }
        public object Value { get; set; }
        public FilterType FilterType { get; set; }

        public Filter(string colName, object val, FilterType type)
        {
            this.ColumnName = colName;
            this.Value = val;
            this.FilterType = type;
        }
    }

    public enum FilterType
    {
        Like,
        Eq
    }
}
