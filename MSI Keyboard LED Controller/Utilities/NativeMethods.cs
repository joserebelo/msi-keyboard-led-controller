using System;
using System.Runtime.InteropServices;

namespace MSI_Keyboard_LED_Controller.Utilities {
    class NativeMethods {
        public const int HwndBroadcast = 0xffff;
        public static readonly int WmShowMe = RegisterWindowMessage("WmShowMe");

        [DllImport("user32")]
        public static extern bool PostMessage(IntPtr hwnd, int msg, IntPtr wparam, IntPtr lparam);

        [DllImport("user32")]
        public static extern int RegisterWindowMessage(string message);
    }
}
