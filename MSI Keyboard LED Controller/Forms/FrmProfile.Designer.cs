namespace MSI_Keyboard_LED_Controller.Forms {
    partial class FrmProfile {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.DropdownMode = new System.Windows.Forms.ComboBox();
            this.LblName = new System.Windows.Forms.Label();
            this.TxtName = new System.Windows.Forms.TextBox();
            this.BtnSave = new System.Windows.Forms.Button();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.GrpColor1 = new System.Windows.Forms.GroupBox();
            this.BtnColor1Right = new System.Windows.Forms.Button();
            this.BtnColor1Center = new System.Windows.Forms.Button();
            this.BtnColor1Left = new System.Windows.Forms.Button();
            this.GrpColors2 = new System.Windows.Forms.GroupBox();
            this.BtnColor2Right = new System.Windows.Forms.Button();
            this.BtnColor2Center = new System.Windows.Forms.Button();
            this.BtnColor2Left = new System.Windows.Forms.Button();
            this.LblMode = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.NumDelay = new System.Windows.Forms.NumericUpDown();
            this.GrpColor1.SuspendLayout();
            this.GrpColors2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumDelay)).BeginInit();
            this.SuspendLayout();
            // 
            // DropdownMode
            // 
            this.DropdownMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.DropdownMode.FormattingEnabled = true;
            this.DropdownMode.Items.AddRange(new object[] {
            "Normal",
            "Gaming",
            "Breath",
            "Audio",
            "Wave"});
            this.DropdownMode.Location = new System.Drawing.Point(53, 34);
            this.DropdownMode.Name = "DropdownMode";
            this.DropdownMode.Size = new System.Drawing.Size(100, 21);
            this.DropdownMode.TabIndex = 0;
            this.DropdownMode.SelectedIndexChanged += new System.EventHandler(this.DropdownMode_SelectedIndexChanged);
            // 
            // LblName
            // 
            this.LblName.AutoSize = true;
            this.LblName.Location = new System.Drawing.Point(12, 9);
            this.LblName.Name = "LblName";
            this.LblName.Size = new System.Drawing.Size(35, 13);
            this.LblName.TabIndex = 1;
            this.LblName.Text = "Name";
            // 
            // TxtName
            // 
            this.TxtName.Location = new System.Drawing.Point(53, 6);
            this.TxtName.Name = "TxtName";
            this.TxtName.Size = new System.Drawing.Size(256, 20);
            this.TxtName.TabIndex = 2;
            this.TxtName.TextChanged += new System.EventHandler(this.TxtName_TextChanged);
            // 
            // BtnSave
            // 
            this.BtnSave.Location = new System.Drawing.Point(84, 140);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(75, 23);
            this.BtnSave.TabIndex = 3;
            this.BtnSave.Text = "Save";
            this.BtnSave.UseVisualStyleBackColor = true;
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // BtnCancel
            // 
            this.BtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnCancel.Location = new System.Drawing.Point(165, 140);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(75, 23);
            this.BtnCancel.TabIndex = 4;
            this.BtnCancel.Text = "Cancel";
            this.BtnCancel.UseVisualStyleBackColor = true;
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // GrpColor1
            // 
            this.GrpColor1.Controls.Add(this.BtnColor1Right);
            this.GrpColor1.Controls.Add(this.BtnColor1Center);
            this.GrpColor1.Controls.Add(this.BtnColor1Left);
            this.GrpColor1.Location = new System.Drawing.Point(15, 69);
            this.GrpColor1.Name = "GrpColor1";
            this.GrpColor1.Size = new System.Drawing.Size(144, 65);
            this.GrpColor1.TabIndex = 5;
            this.GrpColor1.TabStop = false;
            this.GrpColor1.Text = "Colors 1";
            // 
            // BtnColor1Right
            // 
            this.BtnColor1Right.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.BtnColor1Right.Location = new System.Drawing.Point(98, 19);
            this.BtnColor1Right.Name = "BtnColor1Right";
            this.BtnColor1Right.Size = new System.Drawing.Size(40, 40);
            this.BtnColor1Right.TabIndex = 8;
            this.BtnColor1Right.UseVisualStyleBackColor = false;
            this.BtnColor1Right.Click += new System.EventHandler(this.BtnColorClick);
            // 
            // BtnColor1Center
            // 
            this.BtnColor1Center.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.BtnColor1Center.Location = new System.Drawing.Point(52, 19);
            this.BtnColor1Center.Name = "BtnColor1Center";
            this.BtnColor1Center.Size = new System.Drawing.Size(40, 40);
            this.BtnColor1Center.TabIndex = 7;
            this.BtnColor1Center.UseVisualStyleBackColor = false;
            this.BtnColor1Center.Click += new System.EventHandler(this.BtnColorClick);
            // 
            // BtnColor1Left
            // 
            this.BtnColor1Left.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.BtnColor1Left.Location = new System.Drawing.Point(6, 19);
            this.BtnColor1Left.Name = "BtnColor1Left";
            this.BtnColor1Left.Size = new System.Drawing.Size(40, 40);
            this.BtnColor1Left.TabIndex = 6;
            this.BtnColor1Left.UseVisualStyleBackColor = false;
            this.BtnColor1Left.Click += new System.EventHandler(this.BtnColorClick);
            // 
            // GrpColors2
            // 
            this.GrpColors2.Controls.Add(this.BtnColor2Right);
            this.GrpColors2.Controls.Add(this.BtnColor2Center);
            this.GrpColors2.Controls.Add(this.BtnColor2Left);
            this.GrpColors2.Location = new System.Drawing.Point(165, 69);
            this.GrpColors2.Name = "GrpColors2";
            this.GrpColors2.Size = new System.Drawing.Size(144, 65);
            this.GrpColors2.TabIndex = 9;
            this.GrpColors2.TabStop = false;
            this.GrpColors2.Text = "Colors 2";
            // 
            // BtnColor2Right
            // 
            this.BtnColor2Right.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.BtnColor2Right.Location = new System.Drawing.Point(98, 19);
            this.BtnColor2Right.Name = "BtnColor2Right";
            this.BtnColor2Right.Size = new System.Drawing.Size(40, 40);
            this.BtnColor2Right.TabIndex = 8;
            this.BtnColor2Right.UseVisualStyleBackColor = false;
            this.BtnColor2Right.Click += new System.EventHandler(this.BtnColorClick);
            // 
            // BtnColor2Center
            // 
            this.BtnColor2Center.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.BtnColor2Center.Location = new System.Drawing.Point(52, 19);
            this.BtnColor2Center.Name = "BtnColor2Center";
            this.BtnColor2Center.Size = new System.Drawing.Size(40, 40);
            this.BtnColor2Center.TabIndex = 7;
            this.BtnColor2Center.UseVisualStyleBackColor = false;
            this.BtnColor2Center.Click += new System.EventHandler(this.BtnColorClick);
            // 
            // BtnColor2Left
            // 
            this.BtnColor2Left.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.BtnColor2Left.Location = new System.Drawing.Point(6, 19);
            this.BtnColor2Left.Name = "BtnColor2Left";
            this.BtnColor2Left.Size = new System.Drawing.Size(40, 40);
            this.BtnColor2Left.TabIndex = 6;
            this.BtnColor2Left.UseVisualStyleBackColor = false;
            this.BtnColor2Left.Click += new System.EventHandler(this.BtnColorClick);
            // 
            // LblMode
            // 
            this.LblMode.AutoSize = true;
            this.LblMode.Location = new System.Drawing.Point(12, 37);
            this.LblMode.Name = "LblMode";
            this.LblMode.Size = new System.Drawing.Size(34, 13);
            this.LblMode.TabIndex = 10;
            this.LblMode.Text = "Mode";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(159, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Update interval (ms)";
            // 
            // NumDelay
            // 
            this.NumDelay.Location = new System.Drawing.Point(266, 35);
            this.NumDelay.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.NumDelay.Name = "NumDelay";
            this.NumDelay.Size = new System.Drawing.Size(43, 20);
            this.NumDelay.TabIndex = 12;
            this.NumDelay.ValueChanged += new System.EventHandler(this.NumDelay_ValueChanged);
            // 
            // FrmProfile
            // 
            this.AcceptButton = this.BtnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.BtnCancel;
            this.ClientSize = new System.Drawing.Size(321, 170);
            this.Controls.Add(this.NumDelay);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LblMode);
            this.Controls.Add(this.GrpColors2);
            this.Controls.Add(this.GrpColor1);
            this.Controls.Add(this.BtnCancel);
            this.Controls.Add(this.BtnSave);
            this.Controls.Add(this.TxtName);
            this.Controls.Add(this.LblName);
            this.Controls.Add(this.DropdownMode);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = global::MSI_Keyboard_LED_Controller.Properties.Resources.Application;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmProfile";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FrmProfile";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmProfile_FormClosing);
            this.Load += new System.EventHandler(this.FrmProfile_Load);
            this.GrpColor1.ResumeLayout(false);
            this.GrpColors2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.NumDelay)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox DropdownMode;
        private System.Windows.Forms.Label LblName;
        private System.Windows.Forms.TextBox TxtName;
        private System.Windows.Forms.Button BtnSave;
        private System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.GroupBox GrpColor1;
        private System.Windows.Forms.Button BtnColor1Right;
        private System.Windows.Forms.Button BtnColor1Center;
        private System.Windows.Forms.Button BtnColor1Left;
        private System.Windows.Forms.GroupBox GrpColors2;
        private System.Windows.Forms.Button BtnColor2Right;
        private System.Windows.Forms.Button BtnColor2Center;
        private System.Windows.Forms.Button BtnColor2Left;
        private System.Windows.Forms.Label LblMode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown NumDelay;
    }
}