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

        [DllImport("user32.dll", SetLastError = true)]
        static extern void keybd_event(byte bVk, byte bScan, int dwFlags, int dwExtraInfo); 

        public const byte VK_LSHIFT = 0xA0; // left shift key
        public const byte VK_TAB = 0x09; //tab key
        public const int KEYEVENTF_EXTENDEDKEY = 0x01;
        public const int KEYEVENTF_KEYUP = 0x02;

        static void Main(string[] args)
        {
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
        }

    }
}
