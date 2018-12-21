using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace StartMenu
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            ShowStartMenu();
            Application.Exit();
        }
        [DllImport("user32.dll")]
        static extern void keybd_event(byte bVk, byte bScan, uint dwFlags,UIntPtr dwExtraInfo);
        private static void ShowStartMenu()
        {
            // key down event: --> Winsows + Shift +S
            //const byte keyControl = 0x11;
            //const byte keyEscape = 0x1B;
            const byte keyShift = 0x10;
            const byte keyS = 0x53;
            const byte keyLeftWindows = 0x5B;

            keybd_event(keyLeftWindows, 0, 0,UIntPtr.Zero);
            keybd_event(keyShift, 0, 0, UIntPtr.Zero);
            keybd_event(keyS, 0, 0, UIntPtr.Zero);

            // key up event:
            const uint KEYEVENTF_KEYUP = 0x02;
            keybd_event(keyLeftWindows, 0, KEYEVENTF_KEYUP,UIntPtr.Zero);
            keybd_event(keyShift, 0, KEYEVENTF_KEYUP,UIntPtr.Zero);
            keybd_event(keyS, 0, KEYEVENTF_KEYUP,UIntPtr.Zero);
        }
    }
}
