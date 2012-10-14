using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace SFASystem.Core
{
    /// <summary>
    /// Provides thread safe Singleton (almost) functionality. Creates the class instance ASAP (between the program start and first use of class).
    /// </summary>
    /// <typeparam name="T">The Child class type.</typeparam>
    public class Singleton<T>
        where T : class, new()
    {
        /// <summary>
        /// Stores the class instance for a whole time of program run.
        /// </summary>
        protected static T _instance = null;
        protected static readonly object _instanceLock = new object();

        /// <summary>
        /// Gets the class instance.
        /// </summary>
        /// <value>The class instance.</value>
        public static T Instance
        {
            get
            {
                lock (_instanceLock)
                {
                    if (_instance == null)
                        _instance = new T();
                    return _instance;
                }
            }
        }
    }
}
