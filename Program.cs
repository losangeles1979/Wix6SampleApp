using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Wix6SampleApp
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            /*
             To set the icon and title of the form that displays:
               1. Double-click Form1.cs to bring up the Design view
               2. Right-click on the form, select Properties
               3. Go to Icon, navigate to the *.ico file (32x32 size)
               4. Go to Text and set the form's title
            */
            Application.Run(new Form1());
        }
    }
}
