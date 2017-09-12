using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;
using Microsoft.WindowsAPICodePack.ApplicationServices;
using MSI_Keyboard_LED_Controller.Utilities;

namespace MSI_Keyboard_LED_Controller {
    static class Program {
        static Mutex instanceMutex = new Mutex(true, "{e1f89366-6164-4a28-bb10-6fefc8316a23}");

        [STAThread]
        static void Main(String[] args) {
            if (instanceMutex.WaitOne(TimeSpan.Zero, true)) {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                var startup = false;
                foreach (String arg in args) {
                    if (arg.Equals("-startup"))
                        startup = true;
                }

                Controller.Controller controller;
                try {
                    controller = Controller.Controller.GetInstance();
                } catch (Exception e) {
                    MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                controller.Update();

                Application.Run(new FrmMain(!startup));

                instanceMutex.ReleaseMutex();
            } else {
                // Single instance, send message to other instance
                NativeMethods.PostMessage((IntPtr) NativeMethods.HwndBroadcast, NativeMethods.WmShowMe, 
                    IntPtr.Zero, IntPtr.Zero);
            }
        }
    }
}
