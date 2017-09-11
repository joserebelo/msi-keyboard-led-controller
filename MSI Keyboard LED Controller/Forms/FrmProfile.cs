using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MSI_Keyboard_LED_Controller.Controller;

namespace MSI_Keyboard_LED_Controller.Forms {
    public partial class FrmProfile : Form {
        public Profile Profile = null;
        private Controller.Controller _controller;
        private bool _loaded = false;
        
        public FrmProfile() {
            InitializeComponent();
        }

        private void FrmProfile_Load(object sender, EventArgs e) {
            _controller = Controller.Controller.GetInstance();
            if (this.Profile == null) {
                this.Text = "Create a profile";
                this.Profile = new Profile();
            } else {
                this.Text = "Edit profile - " + this.Profile.Name;
                this.Profile = (Profile) this.Profile.Clone();
            }

            SetControlsFromProfile();
            _loaded = true;
            ControlChanged();
        }

        private void SetControlsFromProfile() {
            DropdownMode.SelectedIndex = (int) Profile.Mode - 1;
            NumDelay.Value = Profile.Delay;
            BtnColor1Left.BackColor = ColorLevel.ConvertColor(Profile.Colors[0][0]);
            BtnColor1Center.BackColor = ColorLevel.ConvertColor(Profile.Colors[0][1]);
            BtnColor1Right.BackColor = ColorLevel.ConvertColor(Profile.Colors[0][2]);
            BtnColor2Left.BackColor = ColorLevel.ConvertColor(Profile.Colors[1][0]);
            BtnColor2Center.BackColor = ColorLevel.ConvertColor(Profile.Colors[1][1]);
            BtnColor2Right.BackColor = ColorLevel.ConvertColor(Profile.Colors[1][2]);
            TxtName.Text = Profile.Name;
        }

        private void BtnSave_Click(object sender, EventArgs e) {
            if (Profile.Name == "") {
                MessageBox.Show("Please enter a Profile name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void BtnCancel_Click(object sender, EventArgs e) {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void ControlChanged() {
            if (!_loaded)
                return;

            Profile.Mode = (Profile.ProfileMode) DropdownMode.SelectedIndex + 1;
            Profile.Delay = (int) NumDelay.Value;
            Profile.Colors[0][0] = ColorLevel.GetColor(BtnColor1Left.BackColor);
            Profile.Colors[0][1] = ColorLevel.GetColor(BtnColor1Center.BackColor);
            Profile.Colors[0][2] = ColorLevel.GetColor(BtnColor1Right.BackColor);
            Profile.Colors[1][0] = ColorLevel.GetColor(BtnColor2Left.BackColor);
            Profile.Colors[1][1] = ColorLevel.GetColor(BtnColor2Center.BackColor);
            Profile.Colors[1][2] = ColorLevel.GetColor(BtnColor2Right.BackColor);

            var color2Enabled = Profile.Mode == Profile.ProfileMode.Breath || Profile.Mode == Profile.ProfileMode.Wave;
            BtnColor2Left.Enabled = color2Enabled;
            BtnColor2Center.Enabled = color2Enabled;
            BtnColor2Right.Enabled = color2Enabled;

            if (Profile.Mode == Profile.ProfileMode.Gaming) {
                BtnColor1Center.Enabled = false;
                BtnColor1Right.Enabled = false;
            } else {
                BtnColor1Center.Enabled = true;
                BtnColor1Right.Enabled = true;
            }
            
            NumDelay.Enabled = false;
            
            _controller.TempProfile = Profile;
            _controller.Update();
        }

        private void DropdownMode_SelectedIndexChanged(object sender, EventArgs e) {
            ControlChanged();
        }

        private void BtnColorClick(object sender, EventArgs e) {
            FrmColorPicker frmColorPicker = new FrmColorPicker();
            var res = frmColorPicker.ShowDialog();

            if (res == DialogResult.OK) {
                ((Button) sender).BackColor = frmColorPicker.SelectedColor;
                ControlChanged();
            }
        }

        private void NumDelay_ValueChanged(object sender, EventArgs e) {
            ControlChanged();
        }

        private void TxtName_TextChanged(object sender, EventArgs e) {
            Profile.Name = TxtName.Text;
        }

        private void FrmProfile_FormClosing(object sender, FormClosingEventArgs e) {
            _controller.TempProfile = null;
            _controller.Update();
        }
    }
}
