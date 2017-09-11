using System;
using System.Collections.Generic;
using System.Drawing;

namespace MSI_Keyboard_LED_Controller.Controller {
    [Serializable]
    public class ColorLevel {
        public static Dictionary<Keyboard.CmdColor, Dictionary<Keyboard.CmdLevel, uint>> ColorMap;
        public Keyboard.CmdColor Color { get; set; }
        public Keyboard.CmdLevel Level { get; set; }

        public ColorLevel(Keyboard.CmdColor color, Keyboard.CmdLevel level) {
            Color = color;
            Level = level;
        }

        public static Color ConvertColor(Keyboard.CmdColor color, Keyboard.CmdLevel level) {
            return System.Drawing.Color.FromArgb(unchecked((int) ColorMap[color][level]));
        }

        public static Color ConvertColor(ColorLevel colorLevel) {
            return System.Drawing.Color.FromArgb(unchecked((int) ColorMap[colorLevel.Color][colorLevel.Level]));
        }

        // Finds the closest ColorLevel to a color
        public static ColorLevel ClosestColorLevel(System.Drawing.Color color) {
            ColorLevel ret = null;
            var hue = color.GetHue();
            float dist = 9999;

            foreach (KeyValuePair<Keyboard.CmdColor, Dictionary<Keyboard.CmdLevel, uint>> entry1 in ColorLevel.ColorMap
            ) {
                foreach (KeyValuePair<Keyboard.CmdLevel, uint> entry2 in entry1.Value) {
                    float diff = Math.Abs(hue - System.Drawing.Color.FromArgb(unchecked((int) entry2.Value)).GetHue());
                    diff = diff > 180 ? 360 - diff : diff;
                    if (diff < dist) {
                        dist = diff;
                        ret = new ColorLevel(entry1.Key, entry2.Key);
                    }
                }
            }

            return ret;
        }

        // Finds the ColorLevel that matches color
        public static ColorLevel GetColor(System.Drawing.Color color) {
            foreach (KeyValuePair<Keyboard.CmdColor, Dictionary<Keyboard.CmdLevel, uint>> entry1 in ColorLevel.ColorMap
            ) {
                foreach (KeyValuePair<Keyboard.CmdLevel, uint> entry2 in entry1.Value) {
                    if (color.Equals(System.Drawing.Color.FromArgb(unchecked((int) entry2.Value))))
                        return new ColorLevel(entry1.Key, entry2.Key);
                }
            }

            return null;
        }

        public override int GetHashCode() {
            return (int) Color + (int) Level;
        }

        public override bool Equals(object obj) {
            return Equals(obj as ColorLevel);
        }

        public bool Equals(ColorLevel obj) {
            return obj != null && obj.Color == this.Color && obj.Level == this.Level;
        }

        static ColorLevel() {
            ColorMap = new Dictionary<Keyboard.CmdColor, Dictionary<Keyboard.CmdLevel, uint>>();

            ColorMap[Keyboard.CmdColor.Red] = new Dictionary<Keyboard.CmdLevel, uint>();
            ColorMap[Keyboard.CmdColor.Orange] = new Dictionary<Keyboard.CmdLevel, uint>();
            ColorMap[Keyboard.CmdColor.Yellow] = new Dictionary<Keyboard.CmdLevel, uint>();
            ColorMap[Keyboard.CmdColor.Green] = new Dictionary<Keyboard.CmdLevel, uint>();
            ColorMap[Keyboard.CmdColor.Cyan] = new Dictionary<Keyboard.CmdLevel, uint>();
            ColorMap[Keyboard.CmdColor.Blue] = new Dictionary<Keyboard.CmdLevel, uint>();
            ColorMap[Keyboard.CmdColor.Purple] = new Dictionary<Keyboard.CmdLevel, uint>();
            ColorMap[Keyboard.CmdColor.White] = new Dictionary<Keyboard.CmdLevel, uint>();
            ColorMap[Keyboard.CmdColor.Black] = new Dictionary<Keyboard.CmdLevel, uint>();

            ColorMap[Keyboard.CmdColor.Red][Keyboard.CmdLevel.High] = 0xffe60118;
            ColorMap[Keyboard.CmdColor.Red][Keyboard.CmdLevel.Medium] = 0xffe6401d;
            ColorMap[Keyboard.CmdColor.Red][Keyboard.CmdLevel.Low] = 0xffe55435;
            ColorMap[Keyboard.CmdColor.Red][Keyboard.CmdLevel.Light] = 0xffee845c;

            ColorMap[Keyboard.CmdColor.Orange][Keyboard.CmdLevel.High] = 0xffef8d00;
            ColorMap[Keyboard.CmdColor.Orange][Keyboard.CmdLevel.Medium] = 0xfff2a420;
            ColorMap[Keyboard.CmdColor.Orange][Keyboard.CmdLevel.Low] = 0xfff3a93e;
            ColorMap[Keyboard.CmdColor.Orange][Keyboard.CmdLevel.Light] = 0xfff5be6e;

            ColorMap[Keyboard.CmdColor.Yellow][Keyboard.CmdLevel.High] = 0xfff8e60a;
            ColorMap[Keyboard.CmdColor.Yellow][Keyboard.CmdLevel.Medium] = 0xfffef542;
            ColorMap[Keyboard.CmdColor.Yellow][Keyboard.CmdLevel.Low] = 0xfff9ef7c;
            ColorMap[Keyboard.CmdColor.Yellow][Keyboard.CmdLevel.Light] = 0xfffdf6b0;

            ColorMap[Keyboard.CmdColor.Green][Keyboard.CmdLevel.High] = 0xff9be11d;
            ColorMap[Keyboard.CmdColor.Green][Keyboard.CmdLevel.Medium] = 0xffa4da3a;
            ColorMap[Keyboard.CmdColor.Green][Keyboard.CmdLevel.Low] = 0xffa2c956;
            ColorMap[Keyboard.CmdColor.Green][Keyboard.CmdLevel.Light] = 0xffbad77d;

            ColorMap[Keyboard.CmdColor.Cyan][Keyboard.CmdLevel.High] = 0xff35baf5;
            ColorMap[Keyboard.CmdColor.Cyan][Keyboard.CmdLevel.Medium] = 0xff38b2eb;
            ColorMap[Keyboard.CmdColor.Cyan][Keyboard.CmdLevel.Low] = 0xff74c9f2;
            ColorMap[Keyboard.CmdColor.Cyan][Keyboard.CmdLevel.Light] = 0xffa2d9f8;

            ColorMap[Keyboard.CmdColor.Blue][Keyboard.CmdLevel.High] = 0xff0355a1;
            ColorMap[Keyboard.CmdColor.Blue][Keyboard.CmdLevel.Medium] = 0xff1c5fac;
            ColorMap[Keyboard.CmdColor.Blue][Keyboard.CmdLevel.Low] = 0xff316cb0;
            ColorMap[Keyboard.CmdColor.Blue][Keyboard.CmdLevel.Light] = 0xff718fc5;

            ColorMap[Keyboard.CmdColor.Purple][Keyboard.CmdLevel.High] = 0xff5d197e;
            ColorMap[Keyboard.CmdColor.Purple][Keyboard.CmdLevel.Medium] = 0xff743293;
            ColorMap[Keyboard.CmdColor.Purple][Keyboard.CmdLevel.Low] = 0xff804796;
            ColorMap[Keyboard.CmdColor.Purple][Keyboard.CmdLevel.Light] = 0xff9c70ad;

            ColorMap[Keyboard.CmdColor.White][Keyboard.CmdLevel.High] = 0xFFFFFFFF;
            ColorMap[Keyboard.CmdColor.Black][Keyboard.CmdLevel.High] = 0xff000000;
        }
    }
}
