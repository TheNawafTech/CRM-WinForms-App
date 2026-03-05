using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Settings
{
    public class Settings
    {
        public static class UIHelper
        {
            public static void CenterControl(Control control, Form parentForm)
            {
                {
                    if (control == null || parentForm == null) return;

                    control.Left = (parentForm.ClientSize.Width - control.Width) / 2;
                    control.Top = (parentForm.ClientSize.Height - control.Height) / 2;
                }
            }
        }
    }
}
