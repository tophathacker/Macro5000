//Created by Ryan Hatfield
// TopHatHacker
// Free to use, just don't tell me about it. I really don't care.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;
namespace Macro5000
{
    class Program
    {
        //requred import for bringing window to the front
        [DllImport("user32.dll")]
        static extern bool SetForegroundWindow(IntPtr hWnd);

        static void Main(string[] args)
        {
            //this is to start the process from scratch, I'll add the ability to find process by name later
            Process process = new Process();
            process.StartInfo.FileName = "cmd";
            process.Start();

            //make sure the window has focus
            SetForegroundWindow(process.MainWindowHandle);

            //wait 1 second (1000 milliseconds)
            System.Threading.Thread.Sleep(1000);

            SendKeys.SendWait("test");
            //shift tab would be something like
            SendKeys.SendWait("+{TAB}");

            //check out other SendKeys syntax at http://msdn.microsoft.com/en-us/library/system.windows.forms.sendkeys.aspx
        }

    }
}
