using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using SFASystem.Domain;

namespace SFASystem.WebUtils
{
    public class SFAContext
    {
        private Employee _currentEmployee;
        private Message _message;
        private HttpContext _context = HttpContext.Current;

        public static SFAContext Current
        {
            get
            {
                if (HttpContext.Current == null)
                    return null;
                if (HttpContext.Current.Items["SFAContext"] == null)
                {
                    SFAContext context = new SFAContext();
                    HttpContext.Current.Items.Add("SFAContext", context);
                    return context;
                }
                return (SFAContext)HttpContext.Current.Items["SFAContext"];
            }
        }

        public Message Message
        {
            get { return _message; }
            set { _message = value; }
        }

        public Employee Employee
        {
            get
            {
                return this._currentEmployee;
            }
            set
            {
                this._currentEmployee = value;
            }
        }
    }
}
