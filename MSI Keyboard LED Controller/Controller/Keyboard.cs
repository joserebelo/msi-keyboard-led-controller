using System;
using System.Linq;
using HidLibrary;

namespace MSI_Keyboard_LED_Controller.Controller {
    public class Keyboard {
        private HidDevice _hidDevice;

        // --------------------------------------------

        private const int Vid = 0x1770;
        private const int Pid = 0xff00;

        // --------------------------------------------

        private const int CmdSetMode = 65;
        private const int CmdSetRegionColor = 66;
        private const int CmdSendData = 67;
        private const int CmdEnd = 236;

        public enum CmdMode {
            Normal = 1,
            Gaming,
            Breath,
            Audio,
            Wave
        }

        public enum CmdRegion {
            Left = 1,
            Center,
            Right
        }

        public enum CmdColor {
            Black = 0,
            Red,
            Orange,
            Yellow,
            Green,
            Cyan,
            Blue,
            Purple,
            White
        }

        public enum CmdLevel {
            High = 0,
            Medium,
            Low,
            Light
        }


        // --------------------------------------------

        public void Open() {
            var hidDeviceList = HidDevices.Enumerate(Vid, Pid).ToArray();

            if (hidDeviceList.Length == 0)
                throw new Exception("MSI Keyboard not found");

            _hidDevice = hidDeviceList[0];

            if (!_hidDevice.IsConnected)
                throw new Exception("MSI Keyboard not connected");

            _hidDevice.OpenDevice();

            if (!_hidDevice.IsOpen)
                throw new Exception("Failed to open MSI Keyboard");
        }

        public void Close() {
            if (!_hidDevice.IsOpen)
                return;

            _hidDevice.CloseDevice();
        }

        public void Set(CmdMode mode, ColorLevel[][] colors) {
            if (mode == CmdMode.Breath || mode == CmdMode.Wave) {
                int period = 2; // TODO https://github.com/stevelacy/msi-keyboard/blob/master/lib/setMode.js#L19
                for (int k = 0; k < 3; k++) {
                    int _k = k * 3;
                    SendCommand(CmdSendData, _k + 1, (int) colors[0][k].Color, (int) colors[0][k].Level, 0);
                    SendCommand(CmdSendData, _k + 2, (int) colors[1][k].Color, (int) colors[1][k].Level, 0);
                    SendCommand(CmdSendData, _k + 3, period, period, period);
                }
            } else {
                SetColor(Keyboard.CmdRegion.Left, colors[0][0].Color, colors[0][0].Level);
                SetColor(Keyboard.CmdRegion.Center, colors[0][1].Color, colors[0][1].Level);
                SetColor(Keyboard.CmdRegion.Right, colors[0][2].Color, colors[0][2].Level);
            }

            SetMode(mode);
        }

        bool SendCommand(int type, int val1, int val2, int val3, int val4) {
            if (!_hidDevice.IsOpen)
                throw new Exception("Device not open");

            var data = new byte[8];

            data[0] = 1;
            data[1] = 2;
            data[2] = (byte) type;
            data[3] = (byte) val1;
            data[4] = (byte) val2;
            data[5] = (byte) val3;
            data[6] = (byte) val4;
            data[7] = CmdEnd;

            return _hidDevice.WriteFeatureData(data);
        }

        public bool SetMode(CmdMode mode) {
            return SendCommand(CmdSetMode, (int) mode, 0, 0, 0);
        }

        public bool SetColor(CmdRegion region, CmdColor color, CmdLevel level) {
            return SendCommand(CmdSetRegionColor, (int) region, (int) color, (int) level, 0);
        }

        public void TurnOff() {
            SetColor(CmdRegion.Left, CmdColor.Black, CmdLevel.High);
            SetColor(CmdRegion.Center, CmdColor.Black, CmdLevel.High);
            SetColor(CmdRegion.Right, CmdColor.Black, CmdLevel.High);
            SetMode(CmdMode.Normal);
        }
    }
}
