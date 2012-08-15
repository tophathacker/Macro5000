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

        [DllImport("user32.dll", SetLastError = true)]
        static extern void keybd_event(byte bVk, byte bScan, int dwFlags, int dwExtraInfo);

        public const byte VK_LSHIFT = 0xA0; // left shift key
        public const byte VK_TAB = 0x09; //tab key
        public const int KEYEVENTF_EXTENDEDKEY = 0x01;
        public const int KEYEVENTF_KEYUP = 0x02;

        static void Main(string[] args)
        {
            {
                foreach (Process proc in Process.GetProcessesByName("camerastatusreport"))
                {
                    proc.Kill();
                }
            }
            Process process = new Process();
            process.StartInfo.FileName = "C:\\Program Files\\Luxriot Digital Video Recorder\\CameraStatusReport.exe";
            process.StartInfo.Arguments = "\"C:\\Users\\Jon\\Desktop\\CameraStatus.lxd\" -check";
            process.Start();

            //make sure the window has focus
            SetForegroundWindow(process.MainWindowHandle);

            //wait 1 second (1000 milliseconds)
            System.Threading.Thread.Sleep(3000);

            SendKeys.SendWait("%c");
            SendKeys.SendWait("s");
            //shift tab would be something like
            System.Threading.Thread.Sleep(2000);
            SendKeys.SendWait("+{TAB}");
            SendKeys.SendWait("{ENTER}");
        }

    }
}