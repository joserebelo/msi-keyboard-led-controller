using System;
using System.Windows.Forms;
using MSI_Keyboard_LED_Controller.Controller;
using MSI_Keyboard_LED_Controller.Forms;
using MSI_Keyboard_LED_Controller.Utilities;

namespace MSI_Keyboard_LED_Controller {
    public partial class FrmMain : Form {
        private Controller.Controller _controller;
        private bool _terminateApplication = false;
        private bool _showWindow;
        
        public FrmMain(bool showWindow) {
            InitializeComponent();

            // TODO window blinks on startup
            _showWindow = showWindow;
        }

        private void FrmMain_Load(object sender, EventArgs e) {
            _controller = Controller.Controller.GetInstance();

            TrayIcon.Icon = _controller.Configuration.Enabled
                ? Properties.Resources.TrayEnabled
                : Properties.Resources.TrayDisabled;

            if (!_showWindow) {
                this.Opacity = 0;
                this.ShowInTaskbar = false;
            }
        }

        private void FrmMain_Shown(object sender, EventArgs e) {
            if (!_showWindow) {
                this.Hide();
            } else {
                this.Opacity = 100;
                this.ShowInTaskbar = true;
                _showWindow = true;
            }
            ChkScreenLocked.Checked = _controller.Configuration.OnScreenLocked;
            ChkScreenOff.Checked = _controller.Configuration.OnScreenOff;
            ChkStartup.Checked = Startup.Check();
            BtnEdit.Enabled = ListBoxProfiles.SelectedIndex != -1;
            BtnDelete.Enabled = ListBoxProfiles.SelectedIndex != -1;
            ReloadProfilesList();
        }

        private void BtnNew_Click(object sender, EventArgs e) {
            var frmProfile = new FrmProfile();
            var res = frmProfile.ShowDialog();
            if (res != DialogResult.OK)
                return;

            _controller.Profiles.Add(frmProfile.Profile);
            Profile.Save(_controller.Profiles);
            _controller.Update();
            ReloadProfilesList();
            ListBoxProfiles.SelectedIndex = ListBoxProfiles.Items.Count - 1;
        }

        private void BtnEdit_Click(object sender, EventArgs e) {
            var idx = ListBoxProfiles.SelectedIndex;
            if (idx == -1)
                return;

            var frmProfile = new FrmProfile();
            frmProfile.Profile = _controller.Profiles[idx];
            var res = frmProfile.ShowDialog();

            if (res != DialogResult.OK)
                return;

            _controller.Profiles[idx] = frmProfile.Profile;
            Profile.Save(_controller.Profiles);
            _controller.Update();
            ReloadProfilesList();
            ListBoxProfiles.SelectedIndex = idx;
        }

        private void BtnDelete_Click(object sender, EventArgs e) {
            var idx = ListBoxProfiles.SelectedIndex;
            if (idx == -1)
                return;

            _controller.Profiles.RemoveAt(idx);
            Profile.Save(_controller.Profiles);

            if (idx == _controller.Configuration.SelectedProfile) {
                _controller.Configuration.SelectedProfile--;
                _controller.Configuration.Save();
                _controller.Update();
            }

            ReloadProfilesList();

            if (idx > 0)
                ListBoxProfiles.SelectedIndex = idx - 1;
            else if (ListBoxProfiles.Items.Count > 0)
                ListBoxProfiles.SelectedIndex = 0;
        }

        private void BtnAbout_Click(object sender, EventArgs e) {
            MessageBox.Show(
                "Created by José Rebelo\n\nUses HidLibrary.\nBased on MSI Keyboard LED Controller from stevelacy.",
                "About"
            );
        }

        private void ChkScreenOff_CheckedChanged(object sender, EventArgs e) {
            _controller.Configuration.OnScreenOff = ChkScreenOff.Checked;
            _controller.Configuration.Save();
        }

        private void ChkScreenLocked_CheckedChanged(object sender, EventArgs e) {
            _controller.Configuration.OnScreenLocked = ChkScreenLocked.Checked;
            _controller.Configuration.Save();
        }

        private void ChkStartup_CheckedChanged(object sender, EventArgs e) {
            if (ChkStartup.Checked)
                Startup.Add();
            else
                Startup.Remove();
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e) {
            if (_terminateApplication)
                return;

            e.Cancel = true;
            this.Hide();
        }

        private void TrayIcon_DoubleClick(object sender, EventArgs e) {
            _controller.Configuration.Enabled = !_controller.Configuration.Enabled;
            _controller.Configuration.Save();
            _controller.Update();

            TrayIcon.Icon = _controller.Configuration.Enabled
                ? Properties.Resources.TrayEnabled
                : Properties.Resources.TrayDisabled;
        }

        private void ReloadProfilesList() {
            ListBoxProfiles.Items.Clear();

            var selectedProfile = _controller.Configuration.SelectedProfile;

            for (int i = 0; i < _controller.Profiles.Count; i++) {
                var profile = _controller.Profiles[i];
                ListBoxProfiles.Items.Add(profile.Name + (i == selectedProfile ? " (selected)" : ""));
            }
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e) {
            this.Show();
        }

        private void enabledToolStripMenuItem_Click(object sender, EventArgs e) {
            _controller.Configuration.Enabled = !enabledToolStripMenuItem.Checked;
            _controller.Configuration.Save();
            _controller.Update();

            TrayIcon.Icon = _controller.Configuration.Enabled
                ? Properties.Resources.TrayEnabled
                : Properties.Resources.TrayDisabled;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e) {
            TrayIcon.Visible = false;
            _terminateApplication = true;
            Application.Exit();
        }

        private void TrayIcon_MouseClick(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Right) {
                enabledToolStripMenuItem.Checked = _controller.Configuration.Enabled;

                profilesToolStripMenuItem.DropDownItems.Clear();

                if (_controller.Profiles.Count != 0) {
                    for (int i = 0; i < _controller.Profiles.Count; i++) {
                        ToolStripMenuItem tempItem = new ToolStripMenuItem();
                        tempItem.Name = "profileMenuItem_" + i;
                        tempItem.Text = _controller.Profiles[i].Name;
                        tempItem.Click += new EventHandler((sndr, e1) => {
                            var idx = int.Parse(((ToolStripMenuItem) sndr).Name.Replace("profileMenuItem_", ""));
                            _controller.Configuration.SelectedProfile = idx;
                            _controller.Configuration.Save();
                            _controller.Update();

                            if (this.Visible) {
                                var bak = ListBoxProfiles.SelectedIndex;
                                ReloadProfilesList();
                                ListBoxProfiles.SelectedIndex = bak;
                            }
                        });

                        if (i == _controller.Configuration.SelectedProfile)
                            tempItem.Checked = true;

                        profilesToolStripMenuItem.DropDownItems.Add(tempItem);
                    }
                } else {
                    ToolStripMenuItem temp_item = new ToolStripMenuItem();
                    temp_item.Name = "no_profiles";
                    temp_item.Text = "No profiles";
                    temp_item.Enabled = false;
                    profilesToolStripMenuItem.DropDownItems.Add(temp_item);
                }
            }
        }

        private void ListBoxProfiles_SelectedIndexChanged(object sender, EventArgs e) {
            BtnEdit.Enabled = ListBoxProfiles.SelectedIndex != -1;
            BtnDelete.Enabled = ListBoxProfiles.SelectedIndex != -1;
        }

        private void ListBoxProfiles_DoubleClick(object sender, EventArgs e) {
            if (ListBoxProfiles.SelectedIndex >= 0) {
                _controller.Configuration.SelectedProfile = ListBoxProfiles.SelectedIndex;
                _controller.Configuration.Save();
                _controller.Update();

                ReloadProfilesList();
                ListBoxProfiles.SelectedIndex = _controller.Configuration.SelectedProfile;
            }
        }

        private void FrmMain_VisibleChanged(object sender, EventArgs e) {
            if (this.Visible) {
                ReloadProfilesList();
            }
        }
    }
}
