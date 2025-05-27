using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using WixToolset.Dtf.WindowsInstaller;
using System.Runtime.InteropServices;
using System.Threading;

namespace CASayHello
{
    public class CustomActions
    {
        [DllImport("user32.dll")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);

        [CustomAction]
        public static ActionResult SayHello(Session session)
        {
            session.Log("Begin Custom Action SayHello");

            Record r = new Record(2);
            r.SetString(0, "[1][2]");
            r.SetString(1, "This dialog displayed via session.Message()");
            r.SetString(2, "Next message via MessageBox.Show()\nwill hide behind the install dialog!");
            session.Message((InstallMessage)((int)(InstallMessage.User) +
                                             (int)(MessageBoxButtons.OK)),
                                             r);

            /* Lesson Learned: Can't see the messagebox if you do it like this,
               which is what was listed on p. 149 of the Nick Ramirez text! */
            Record invisible = new Record(0);
            invisible[0] = "You won't see me!  Must format as above!";
            session.Message(InstallMessage.Info, invisible);

            /* Lesson Learned: In earlier versions of WiX, there was a DisplayInternalUI property
                               that could set to "yes" in the Bundle's MsiPackage,
                               which permitted the user to see all of the message boxes
                               shown by the msi package.
                               That included both session.Message() and MessageBox.Show().
                               The MessageBox.Show() was hidden behind the top dialog, however.
                               BUT IN WIX 6.0 this property was removed!
                               So now, the only way to see the message boxes is to use MessageBox.Show().
                               The session.Message() won't be shown if you install via the Bootstrapper.
                               You will still see the message boxes if you install the MSI directly.
 *                             */

            /* Using Form to ensure MessageBox appears on top */
            Form messageForm = new Form();
            messageForm.TopMost = true;
            messageForm.Show();
            messageForm.Hide();
            
            var result = MessageBox.Show(messageForm, "This dialog displayed via MessageBox.Show()", 
                "Custom Action Message", 
                MessageBoxButtons.OK, 
                MessageBoxIcon.Information);
            
            SetForegroundWindow(messageForm.Handle);
            messageForm.Dispose();

            return ActionResult.Success;
        }
    }
}
