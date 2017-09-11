using MSI_Keyboard_LED_Controller.Properties;

namespace MSI_Keyboard_LED_Controller {
    partial class FrmMain {
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
            this.components = new System.ComponentModel.Container();
            this.TrayIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.TrayMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.profilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.enabledToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.GroupBoxProfiles = new System.Windows.Forms.GroupBox();
            this.ListBoxProfiles = new System.Windows.Forms.ListBox();
            this.BtnDelete = new System.Windows.Forms.Button();
            this.BtnEdit = new System.Windows.Forms.Button();
            this.BtnNew = new System.Windows.Forms.Button();
            this.ChkStartup = new System.Windows.Forms.CheckBox();
            this.ChkScreenOff = new System.Windows.Forms.CheckBox();
            this.BtnAbout = new System.Windows.Forms.Button();
            this.ChkScreenLocked = new System.Windows.Forms.CheckBox();
            this.TrayMenu.SuspendLayout();
            this.GroupBoxProfiles.SuspendLayout();
            this.SuspendLayout();
            // 
            // TrayIcon
            // 
            this.TrayIcon.ContextMenuStrip = this.TrayMenu;
            this.TrayIcon.Icon = global::MSI_Keyboard_LED_Controller.Properties.Resources.TrayEnabled;
            this.TrayIcon.Text = "MSI Keyboard LED Manager";
            this.TrayIcon.Visible = true;
            this.TrayIcon.DoubleClick += new System.EventHandler(this.TrayIcon_DoubleClick);
            this.TrayIcon.MouseClick += new System.Windows.Forms.MouseEventHandler(this.TrayIcon_MouseClick);
            // 
            // TrayMenu
            // 
            this.TrayMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.profilesToolStripMenuItem,
            this.settingsToolStripMenuItem,
            this.enabledToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.TrayMenu.Name = "trayMenu";
            this.TrayMenu.Size = new System.Drawing.Size(117, 92);
            // 
            // profilesToolStripMenuItem
            // 
            this.profilesToolStripMenuItem.Name = "profilesToolStripMenuItem";
            this.profilesToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.profilesToolStripMenuItem.Text = "Profiles";
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.settingsToolStripMenuItem.Text = "Settings";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // enabledToolStripMenuItem
            // 
            this.enabledToolStripMenuItem.Checked = true;
            this.enabledToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.enabledToolStripMenuItem.Name = "enabledToolStripMenuItem";
            this.enabledToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.enabledToolStripMenuItem.Text = "Enabled";
            this.enabledToolStripMenuItem.Click += new System.EventHandler(this.enabledToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // GroupBoxProfiles
            // 
            this.GroupBoxProfiles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GroupBoxProfiles.Controls.Add(this.ListBoxProfiles);
            this.GroupBoxProfiles.Controls.Add(this.BtnDelete);
            this.GroupBoxProfiles.Controls.Add(this.BtnEdit);
            this.GroupBoxProfiles.Controls.Add(this.BtnNew);
            this.GroupBoxProfiles.Location = new System.Drawing.Point(12, 12);
            this.GroupBoxProfiles.Name = "GroupBoxProfiles";
            this.GroupBoxProfiles.Size = new System.Drawing.Size(324, 191);
            this.GroupBoxProfiles.TabIndex = 1;
            this.GroupBoxProfiles.TabStop = false;
            this.GroupBoxProfiles.Text = "Profiles";
            // 
            // ListBoxProfiles
            // 
            this.ListBoxProfiles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ListBoxProfiles.FormattingEnabled = true;
            this.ListBoxProfiles.Location = new System.Drawing.Point(6, 50);
            this.ListBoxProfiles.Name = "ListBoxProfiles";
            this.ListBoxProfiles.Size = new System.Drawing.Size(312, 134);
            this.ListBoxProfiles.TabIndex = 3;
            this.ListBoxProfiles.SelectedIndexChanged += new System.EventHandler(this.ListBoxProfiles_SelectedIndexChanged);
            this.ListBoxProfiles.DoubleClick += new System.EventHandler(this.ListBoxProfiles_DoubleClick);
            // 
            // BtnDelete
            // 
            this.BtnDelete.Image = global::MSI_Keyboard_LED_Controller.Properties.Resources.BtnDelete;
            this.BtnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnDelete.Location = new System.Drawing.Point(218, 19);
            this.BtnDelete.Name = "BtnDelete";
            this.BtnDelete.Size = new System.Drawing.Size(100, 25);
            this.BtnDelete.TabIndex = 2;
            this.BtnDelete.Text = "Delete";
            this.BtnDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnDelete.UseVisualStyleBackColor = true;
            this.BtnDelete.Click += new System.EventHandler(this.BtnDelete_Click);
            // 
            // BtnEdit
            // 
            this.BtnEdit.Image = global::MSI_Keyboard_LED_Controller.Properties.Resources.BtnEdit;
            this.BtnEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnEdit.Location = new System.Drawing.Point(112, 19);
            this.BtnEdit.Name = "BtnEdit";
            this.BtnEdit.Size = new System.Drawing.Size(100, 25);
            this.BtnEdit.TabIndex = 1;
            this.BtnEdit.Text = "Edit";
            this.BtnEdit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnEdit.UseVisualStyleBackColor = true;
            this.BtnEdit.Click += new System.EventHandler(this.BtnEdit_Click);
            // 
            // BtnNew
            // 
            this.BtnNew.Image = global::MSI_Keyboard_LED_Controller.Properties.Resources.BtnNew;
            this.BtnNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnNew.Location = new System.Drawing.Point(6, 19);
            this.BtnNew.Name = "BtnNew";
            this.BtnNew.Size = new System.Drawing.Size(100, 25);
            this.BtnNew.TabIndex = 0;
            this.BtnNew.Text = "New";
            this.BtnNew.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnNew.UseVisualStyleBackColor = true;
            this.BtnNew.Click += new System.EventHandler(this.BtnNew_Click);
            // 
            // ChkStartup
            // 
            this.ChkStartup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ChkStartup.AutoSize = true;
            this.ChkStartup.Location = new System.Drawing.Point(238, 215);
            this.ChkStartup.Name = "ChkStartup";
            this.ChkStartup.Size = new System.Drawing.Size(98, 17);
            this.ChkStartup.TabIndex = 0;
            this.ChkStartup.Text = "Run on Startup";
            this.ChkStartup.UseVisualStyleBackColor = true;
            this.ChkStartup.CheckedChanged += new System.EventHandler(this.ChkStartup_CheckedChanged);
            // 
            // ChkScreenOff
            // 
            this.ChkScreenOff.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ChkScreenOff.AutoSize = true;
            this.ChkScreenOff.Location = new System.Drawing.Point(12, 215);
            this.ChkScreenOff.Name = "ChkScreenOff";
            this.ChkScreenOff.Size = new System.Drawing.Size(142, 17);
            this.ChkScreenOff.TabIndex = 1;
            this.ChkScreenOff.Text = "Turn off when screen off";
            this.ChkScreenOff.UseVisualStyleBackColor = true;
            this.ChkScreenOff.CheckedChanged += new System.EventHandler(this.ChkScreenOff_CheckedChanged);
            // 
            // BtnAbout
            // 
            this.BtnAbout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnAbout.Location = new System.Drawing.Point(261, 238);
            this.BtnAbout.Name = "BtnAbout";
            this.BtnAbout.Size = new System.Drawing.Size(75, 23);
            this.BtnAbout.TabIndex = 2;
            this.BtnAbout.Text = "About";
            this.BtnAbout.UseVisualStyleBackColor = true;
            this.BtnAbout.Click += new System.EventHandler(this.BtnAbout_Click);
            // 
            // ChkScreenLocked
            // 
            this.ChkScreenLocked.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ChkScreenLocked.AutoSize = true;
            this.ChkScreenLocked.Location = new System.Drawing.Point(12, 238);
            this.ChkScreenLocked.Name = "ChkScreenLocked";
            this.ChkScreenLocked.Size = new System.Drawing.Size(162, 17);
            this.ChkScreenLocked.TabIndex = 3;
            this.ChkScreenLocked.Text = "Turn off when screen locked";
            this.ChkScreenLocked.UseVisualStyleBackColor = true;
            this.ChkScreenLocked.CheckedChanged += new System.EventHandler(this.ChkScreenLocked_CheckedChanged);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(348, 267);
            this.Controls.Add(this.ChkScreenLocked);
            this.Controls.Add(this.BtnAbout);
            this.Controls.Add(this.ChkScreenOff);
            this.Controls.Add(this.ChkStartup);
            this.Controls.Add(this.GroupBoxProfiles);
            this.Icon = global::MSI_Keyboard_LED_Controller.Properties.Resources.Application;
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MSI Keyboard LED Controller";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMain_FormClosing);
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.Shown += new System.EventHandler(this.FrmMain_Shown);
            this.VisibleChanged += new System.EventHandler(this.FrmMain_VisibleChanged);
            this.TrayMenu.ResumeLayout(false);
            this.GroupBoxProfiles.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NotifyIcon TrayIcon;
        private System.Windows.Forms.ContextMenuStrip TrayMenu;
        private System.Windows.Forms.GroupBox GroupBoxProfiles;
        private System.Windows.Forms.ListBox ListBoxProfiles;
        private System.Windows.Forms.Button BtnDelete;
        private System.Windows.Forms.Button BtnEdit;
        private System.Windows.Forms.Button BtnNew;
        private System.Windows.Forms.CheckBox ChkStartup;
        private System.Windows.Forms.CheckBox ChkScreenOff;
        private System.Windows.Forms.Button BtnAbout;
        private System.Windows.Forms.CheckBox ChkScreenLocked;
        private System.Windows.Forms.ToolStripMenuItem profilesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem enabledToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
    }
}

