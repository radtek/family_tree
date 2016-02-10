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

            var person = new DB.Models.Person() { name ="1", fathersSurname="2", mothersSurname = "3", dateOfBirth = DateTime.Now, dateOfDeath = DateTime.Now.AddDays(1), isFemale = true, placeOfBirth = "4", placeOfDeath = "5", info = "6"};

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new GUI.PersonUI(person));

        }

        private static void MyCommonExceptionHandlingMethod(object sender, ThreadExceptionEventArgs t)
        {
            //Exception handling...
            MessageBox.Show(t.Exception.ToString());
        }
    }
}
