using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Microsoft.Win32;
using Microsoft.WindowsAPICodePack.ApplicationServices;

namespace MSI_Keyboard_LED_Controller.Controller {
    class Controller {
        private static Controller _instance;

        public Configuration Configuration;
        public List<Profile> Profiles;
        private readonly Keyboard _keyboard;
        private readonly Timer _timer = new Timer();
        public Profile TempProfile = null;

        private Controller() {
            Configuration = Configuration.Load();
            Profiles = Profile.Load();
            _keyboard = new Keyboard();
            _keyboard.Open();

            // Event handlers
            AppDomain.CurrentDomain.ProcessExit += new EventHandler(OnProcessExit);
            SystemEvents.PowerModeChanged += OnPowerChange;
            PowerManager.IsMonitorOnChanged += new EventHandler(OnMonitorChange);
            SystemEvents.SessionSwitch += new SessionSwitchEventHandler(OnSessionSwitch);
            _timer.Tick += new EventHandler(OnTimerTick);
        }

        // Update the leds
        public void Update() {
            if (Configuration.SelectedProfile == -1 && Profiles.Count > 0) {
                Configuration.SelectedProfile = 0;
                Configuration.Save();
            }

            if ((Configuration.SelectedProfile == -1 || !Configuration.Enabled) && TempProfile == null) {
                _keyboard.TurnOff();
                _timer.Stop();
                _timer.Enabled = false;
            } else if (TempProfile != null || (Configuration.SelectedProfile != -1 && Configuration.Enabled)) {
                var p = TempProfile != null ? TempProfile : Profiles[Configuration.SelectedProfile];

                switch (p.Mode) {
                    case Profile.ProfileMode.Normal:
                    case Profile.ProfileMode.Breath:
                    case Profile.ProfileMode.Gaming:
                    case Profile.ProfileMode.Wave:
                    case Profile.ProfileMode.Audio:
                        // _keyboard.TurnOff();
                        _timer.Stop();
                        _timer.Enabled = false;

                        _keyboard.Set((Keyboard.CmdMode)p.Mode, p.Colors);
                        break;
                    case Profile.ProfileMode.Audio2:
                    case Profile.ProfileMode.Rainbow:
                    case Profile.ProfileMode.Screen:
                        //_timer.Enabled = true;
                        //_timer.Interval = p.Delay;
                        //_timer.Start();
                        break;
                }
            }
        }

        // Controller Instance
        public static Controller GetInstance() {
            if (_instance == null)
                _instance = new Controller();

            return _instance;
        }

        // Timer tick
        private void OnTimerTick(object sender, EventArgs e) {
        }

        // Process exit
        private void OnProcessExit(object sender, EventArgs e) {
            _keyboard.TurnOff();
            _keyboard.Close();
        }

        // Session Switch
        private void OnSessionSwitch(object sender, SessionSwitchEventArgs e) {
            if (!Configuration.Enabled || !Configuration.OnScreenLocked)
                return;

            switch (e.Reason) {
                case SessionSwitchReason.SessionLock:
                    if (Configuration.Enabled) {
                        _keyboard.TurnOff();
                        _timer.Stop();
                        _timer.Enabled = false;
                    }
                    break;
                case SessionSwitchReason.SessionUnlock:
                    Update();
                    break;
            }
        }

        // Power change
        private void OnPowerChange(object sender, PowerModeChangedEventArgs e) {
            if (!Configuration.Enabled)
                return;

            switch (e.Mode) {
                case PowerModes.Resume:
                    Update();
                    break;
                case PowerModes.Suspend:
                    _keyboard.TurnOff();
                    _timer.Stop();
                    _timer.Enabled = false;
                    break;
            }
        }

        // Monitor change
        private void OnMonitorChange(object sender, EventArgs e) {
            if (!Configuration.Enabled || !Configuration.OnScreenOff)
                return;

            if (PowerManager.IsMonitorOn) {
                Update();
            } else {
                _keyboard.TurnOff();
                _timer.Stop();
                _timer.Enabled = false;
            }
        }
    }
}
