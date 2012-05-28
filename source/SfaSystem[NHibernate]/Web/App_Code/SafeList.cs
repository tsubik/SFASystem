using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for SafeList
/// </summary>
public class SafeList
{
    public static IList<T> Create<T>(IList<T> input) where T : class, ICloneable
    {
        //Symply check the type of the first element.
        if (input.Count > 0) input[0] = (T)input[0].Clone();
        return input;
    }
}
