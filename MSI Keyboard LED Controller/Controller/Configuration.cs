using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace MSI_Keyboard_LED_Controller.Controller {
    class Configuration {
        public bool OnScreenOff = true;
        public bool OnScreenLocked = false;
        public bool Enabled = true;
        public int SelectedProfile = -1;

        private Configuration() {
        }

        public static Configuration Load() {
            if (!File.Exists(@"config.json")) {
                return new Configuration();
            }

            string text;
            var fileStream = new FileStream(@"config.json", FileMode.Open, FileAccess.Read);

            using (var streamReader = new StreamReader(fileStream, Encoding.UTF8)) {
                text = streamReader.ReadToEnd();
            }

            return JsonConvert.DeserializeObject<Configuration>(text);
        }

        public void Save() {
            var json = JsonConvert.SerializeObject(this);

            File.WriteAllText(@"config.json", json);
        }
    }
}
