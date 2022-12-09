using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTaskManager
{
    internal class GlobalCode
    {
        public static string GetApplicationName()
        {
            return "MyTaskManager";
        }

        public static DialogResult ShowMSGBox(string strText,
    MessageBoxIcon Icon = MessageBoxIcon.Information,
    MessageBoxButtons Buttons = MessageBoxButtons.OK,
    MessageBoxDefaultButton DefaulButton = MessageBoxDefaultButton.Button1)
        {
            DialogResult diaResult;
            diaResult = MessageBox.Show(strText, Application.ProductName, Buttons, Icon, DefaulButton);
            return diaResult;
        }

        public static DialogResult ExceptionMessageBox()
        {
            DialogResult diaResult;
            diaResult = MessageBox.Show("An unexpected error has occurred. Please contact the developer.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            return diaResult;
        }



    }
}
