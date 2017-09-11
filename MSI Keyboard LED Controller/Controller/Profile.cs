using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using MSI_Keyboard_LED_Controller.Utilities;
using Newtonsoft.Json;

namespace MSI_Keyboard_LED_Controller.Controller {
    [Serializable]
    public class Profile : ICloneable {
        public static readonly string ProfilesLocation = Startup.ExeDirectoryPath() + @"\profiles.json";

        public enum ProfileMode {
            // Built-in modes
            Normal = 1,
            Gaming,
            Breath,
            Audio,
            Wave,

            // Custom
            Audio2,
            Screen,
            Rainbow
        }

        public string Name;
        public int Delay;
        public ProfileMode Mode;
        public ColorLevel[][] Colors;

        public Profile() {
            Name = "";
            Delay = 0;
            Mode = ProfileMode.Normal;
            Colors = new[] {
                new[] {
                    new ColorLevel(Keyboard.CmdColor.Black, Keyboard.CmdLevel.High),
                    new ColorLevel(Keyboard.CmdColor.Black, Keyboard.CmdLevel.High),
                    new ColorLevel(Keyboard.CmdColor.Black, Keyboard.CmdLevel.High)
                },
                new[] {
                    new ColorLevel(Keyboard.CmdColor.Black, Keyboard.CmdLevel.High),
                    new ColorLevel(Keyboard.CmdColor.Black, Keyboard.CmdLevel.High),
                    new ColorLevel(Keyboard.CmdColor.Black, Keyboard.CmdLevel.High)
                }
            };
        }

        public static List<Profile> Load() {
            if (!File.Exists(ProfilesLocation)) {
                return new List<Profile>();
            }

            string text;
            var fileStream = new FileStream(ProfilesLocation, FileMode.Open, FileAccess.Read);

            using (var streamReader = new StreamReader(fileStream, Encoding.UTF8)) {
                text = streamReader.ReadToEnd();
            }

            return JsonConvert.DeserializeObject<List<Profile>>(text);
        }

        public static void Save(List<Profile> list) {
            var json = JsonConvert.SerializeObject(list);

            File.WriteAllText(ProfilesLocation, json);
        }

        public object Clone() {
            using (MemoryStream memoryStream = new MemoryStream()) {
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                binaryFormatter.Serialize(memoryStream, this);
                memoryStream.Seek(0, SeekOrigin.Begin);
                return binaryFormatter.Deserialize(memoryStream);
            }
        }
    }
}
