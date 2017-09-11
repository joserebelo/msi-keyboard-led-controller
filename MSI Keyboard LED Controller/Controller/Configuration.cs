using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MSI_Keyboard_LED_Controller.Utilities;
using Newtonsoft.Json;

namespace MSI_Keyboard_LED_Controller.Controller {
    class Configuration {
        public static readonly string ConfigLocation = Startup.ExeDirectoryPath() + @"\config.json";

        public bool OnScreenOff = true;
        public bool OnScreenLocked = false;
        public bool Enabled = true;
        public int SelectedProfile = -1;

        private Configuration() {
        }

        public static Configuration Load() {
            if (!File.Exists(ConfigLocation)) {
                return new Configuration();
            }

            string text;
            var fileStream = new FileStream(ConfigLocation, FileMode.Open, FileAccess.Read);

            using (var streamReader = new StreamReader(fileStream, Encoding.UTF8)) {
                text = streamReader.ReadToEnd();
            }

            return JsonConvert.DeserializeObject<Configuration>(text);
        }

        public void Save() {
            var json = JsonConvert.SerializeObject(this);

            File.WriteAllText(ConfigLocation, json);
        }
    }
}
