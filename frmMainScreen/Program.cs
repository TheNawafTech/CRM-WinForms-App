using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClsUser_Person;

namespace nfrmMainScreen
{
    internal static class Program
    {
        static ClsUser_Person.ClsUser User = new ClsUser_Person.ClsUser();

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new nfrmMainScreen.frmMainScreen(ref User));
        }
    }
}
