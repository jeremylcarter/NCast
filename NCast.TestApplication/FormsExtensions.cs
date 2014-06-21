using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NCast.TestApplication
{
    public static class FormsExtensions
    {
        public static void InvokeIfRequired(this Control control, Action action)
        {
            if (control != null && control.InvokeRequired)
            {
                control.Invoke(action);
            }
            else
            {
                action();
            }
        }
        public static T InvokeIfRequired<T>(this Control control, Func<T> func)
        {
            if (control != null && control.InvokeRequired)
            {
                return (T)(control.Invoke(func));
            }
            else
            {
                return func();
            }
        }
    }
}
