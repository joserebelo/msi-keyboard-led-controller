using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;
using Microsoft.WindowsAPICodePack.ApplicationServices;

namespace MSI_Keyboard_LED_Controller {
    static class Program {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(String[] args) {
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
        }
    }
}
