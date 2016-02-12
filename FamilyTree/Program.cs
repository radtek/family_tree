using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FamilyTree
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            Application.ThreadException += new ThreadExceptionEventHandler(MyCommonExceptionHandlingMethod);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());

        }

        private static void MyCommonExceptionHandlingMethod(object sender, ThreadExceptionEventArgs t)
        {
            //Exception handling...
            MessageBox.Show(t.Exception.ToString());
        }
    }
}
