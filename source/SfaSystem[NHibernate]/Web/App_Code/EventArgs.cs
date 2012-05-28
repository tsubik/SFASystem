using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


    public class EventArgs<T> : EventArgs
    {
        
        public EventArgs(T val)
        {
            this._value = val;
        }
        private T _value;
        public T Value
        {
            get
            {
                return _value;
            }
        }
    }

