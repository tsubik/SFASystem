using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Windows.Forms;

namespace SFASystem.Pocket.App.Code
{
    public class FormManager
    {
        static internal ArrayList arrForms = new ArrayList();

        static internal Form OpenForm(Type typeForm)
        {
            foreach (Form frm in arrForms)
            {
                if (frm.GetType() == typeForm)
                    return frm;
            }

            return null;
        }
    }
}
