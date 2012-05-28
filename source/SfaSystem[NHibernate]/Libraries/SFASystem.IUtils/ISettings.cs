using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SFASystem.IUtils
{
    public interface ISettings
    {
        string GetConnectionString(string connectionStringName);
    }
}
