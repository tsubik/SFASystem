using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using SFASystem.Domain;

namespace SFASystem.WebUtils
{
    public class StateItems
    {
        public static Message Message
        {
            get { return (Message)HttpContext.Current.Session["message"]; }
            set { HttpContext.Current.Session["message"] = value; }
        }

        public static Order CurrentOrder
        {
            get {
                Order order = (Order)HttpContext.Current.Session["order"];
                if(order == null)
                    order = new Order();
                return order;
            }
            set { HttpContext.Current.Session["order"] = value; }
        }

        public static bool IsInOrderMode
        {
            get
            {
                bool? isInOM = (bool?)HttpContext.Current.Session["orderMode"];
                if(isInOM.HasValue)
                    return isInOM.Value;
                else
                    return false;
            }
            set
            {
                HttpContext.Current.Session["orderMode"] = (bool?) value;
            }
        }
    }
}
