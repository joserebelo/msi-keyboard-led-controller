using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;

namespace MSI_Keyboard_LED_Controller.Utilities {
    class Startup {
        public static string Name = "MSI Keyboard LED Controller";
        public static string Location = System.Reflection.Assembly.GetEntryAssembly().Location;
        private const string SubKeyPath = "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run";
        
        public static void Add() {
            Startup.Remove();

            var key = Registry.CurrentUser.OpenSubKey(Startup.SubKeyPath, true);
            if (key == null) return;

            key.SetValue(Startup.Name, "\"" + Startup.Location + "\" -startup");
            key.Close();
        }

        public static void Remove() {
            var key = Registry.CurrentUser.OpenSubKey(Startup.SubKeyPath, true);

            if (key?.GetValue(Startup.Name) != null)
                key.DeleteValue(Startup.Name);

            key?.Close();
        }

        public static bool Check() {
            var key = Registry.CurrentUser.OpenSubKey(Startup.SubKeyPath, false);

            if (key?.GetValue(Startup.Name) == null)
                return false;
            
            return key.GetValue(Startup.Name).Equals("\"" + Startup.Location + "\" -startup");
        }
    }
}
