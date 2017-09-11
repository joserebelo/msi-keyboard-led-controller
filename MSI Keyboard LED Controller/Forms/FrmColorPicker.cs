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
    public partial class FrmColorPicker : Form {
        private const int ButonsPerRow = 6;
        private const int ButtonSize = 30;
        private const int ButtonSpacing = 10;

        public Color SelectedColor { get; set; }

        public FrmColorPicker() {
            InitializeComponent();
        }

        private void FrmColorPicker_Load(object sender, EventArgs e) {
            var x = 0;
            var y = 0;

            foreach (KeyValuePair<Keyboard.CmdColor, Dictionary<Keyboard.CmdLevel, uint>> entry1 in ColorLevel.ColorMap
            ) {
                foreach (KeyValuePair<Keyboard.CmdLevel, uint> entry2 in entry1.Value) {
                    Button btn = new Button();
                    var color = Color.FromArgb(unchecked((int) entry2.Value));
                    btn.Name = "btn_color_" + ColorToHex(color);
                    btn.BackColor = color;
                    btn.Text = "";
                    var btnX = ButtonSpacing + x * (ButtonSize + ButtonSpacing);
                    var btnY = ButtonSpacing + y * (ButtonSize + ButtonSpacing);
                    btn.Location = new Point(btnX, btnY);
                    btn.Size = new Size(ButtonSize, ButtonSize);

                    x++;

                    if (x >= ButonsPerRow) {
                        x = 0;
                        y++;
                    }

                    btn.Click += new EventHandler(OnColorSelection);

                    this.Controls.Add(btn);
                }
            }
        }

        private static String ColorToHex(System.Drawing.Color c) {
            return "#" + c.R.ToString("X2") + c.G.ToString("X2") + c.B.ToString("X2");
        }

        void OnColorSelection(object sender, EventArgs e) {
            var btn = (Button) sender;
            var btnColor = btn.Name.Replace("btn_color_", "");
            SelectedColor = ColorTranslator.FromHtml(btnColor);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void BtnCancel_Click(object sender, EventArgs e) {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
