namespace PhotoCopy
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.trayMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.labelStatus = new System.Windows.Forms.Label();
            this.checkBoxDeleteRaw = new System.Windows.Forms.CheckBox();
            this.checkBoxDeleteJpeg = new System.Windows.Forms.CheckBox();
            this.checkBoxStartSystem = new System.Windows.Forms.CheckBox();
            this.progressBarCopying = new System.Windows.Forms.ProgressBar();
            this.labelFile = new System.Windows.Forms.Label();
            this.labelProgress = new System.Windows.Forms.Label();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.initializeDeviceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.buttonOpenDestination = new System.Windows.Forms.Button();
            this.checkBoxNewFolder = new System.Windows.Forms.CheckBox();
            this.buttonOpenSource = new System.Windows.Forms.Button();
            this.trayMenu.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // notifyIcon
            // 
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "Photomatix";
            this.notifyIcon.Visible = true;
            this.notifyIcon.DoubleClick += new System.EventHandler(this.notifyIcon_DoubleClick);
            // 
            // trayMenu
            // 
            this.trayMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuExit});
            this.trayMenu.Name = "trayMenu";
            this.trayMenu.Size = new System.Drawing.Size(93, 26);
            // 
            // menuExit
            // 
            this.menuExit.Name = "menuExit";
            this.menuExit.Size = new System.Drawing.Size(92, 22);
            this.menuExit.Text = "Exit";
            this.menuExit.Click += new System.EventHandler(this.menuExit_Click);
            // 
            // labelStatus
            // 
            this.labelStatus.AutoSize = true;
            this.labelStatus.Location = new System.Drawing.Point(9, 29);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(112, 13);
            this.labelStatus.TabIndex = 1;
            this.labelStatus.Text = "Status: not connected";
            // 
            // checkBoxDeleteRaw
            // 
            this.checkBoxDeleteRaw.AutoSize = true;
            this.checkBoxDeleteRaw.Location = new System.Drawing.Point(12, 114);
            this.checkBoxDeleteRaw.Name = "checkBoxDeleteRaw";
            this.checkBoxDeleteRaw.Size = new System.Drawing.Size(226, 17);
            this.checkBoxDeleteRaw.TabIndex = 2;
            this.checkBoxDeleteRaw.Text = "Delete raw files after copying (*.arw, *.dng)";
            this.checkBoxDeleteRaw.UseVisualStyleBackColor = true;
            this.checkBoxDeleteRaw.CheckedChanged += new System.EventHandler(this.checkBoxDeleteRaw_CheckedChanged);
            // 
            // checkBoxDeleteJpeg
            // 
            this.checkBoxDeleteJpeg.AutoSize = true;
            this.checkBoxDeleteJpeg.Location = new System.Drawing.Point(12, 138);
            this.checkBoxDeleteJpeg.Name = "checkBoxDeleteJpeg";
            this.checkBoxDeleteJpeg.Size = new System.Drawing.Size(172, 17);
            this.checkBoxDeleteJpeg.TabIndex = 3;
            this.checkBoxDeleteJpeg.Text = "Delete JPEG files after copying";
            this.checkBoxDeleteJpeg.UseVisualStyleBackColor = true;
            this.checkBoxDeleteJpeg.CheckedChanged += new System.EventHandler(this.checkBoxDeleteJpeg_CheckedChanged);
            // 
            // checkBoxStartSystem
            // 
            this.checkBoxStartSystem.AutoSize = true;
            this.checkBoxStartSystem.Location = new System.Drawing.Point(12, 197);
            this.checkBoxStartSystem.Name = "checkBoxStartSystem";
            this.checkBoxStartSystem.Size = new System.Drawing.Size(122, 17);
            this.checkBoxStartSystem.TabIndex = 4;
            this.checkBoxStartSystem.Text = "Start on system boot";
            this.checkBoxStartSystem.UseVisualStyleBackColor = true;
            this.checkBoxStartSystem.CheckedChanged += new System.EventHandler(this.checkBoxStartSystem_CheckedChanged);
            // 
            // progressBarCopying
            // 
            this.progressBarCopying.Location = new System.Drawing.Point(12, 45);
            this.progressBarCopying.MarqueeAnimationSpeed = 1;
            this.progressBarCopying.Name = "progressBarCopying";
            this.progressBarCopying.Size = new System.Drawing.Size(405, 23);
            this.progressBarCopying.Step = 1;
            this.progressBarCopying.TabIndex = 5;
            this.progressBarCopying.Value = 50;
            // 
            // labelFile
            // 
            this.labelFile.AutoSize = true;
            this.labelFile.Location = new System.Drawing.Point(12, 75);
            this.labelFile.Name = "labelFile";
            this.labelFile.Size = new System.Drawing.Size(140, 13);
            this.labelFile.TabIndex = 6;
            this.labelFile.Text = "Copying file: IMG_12311.jpg";
            // 
            // labelProgress
            // 
            this.labelProgress.AutoSize = true;
            this.labelProgress.Location = new System.Drawing.Point(375, 71);
            this.labelProgress.Name = "labelProgress";
            this.labelProgress.Size = new System.Drawing.Size(42, 13);
            this.labelProgress.TabIndex = 7;
            this.labelProgress.Text = "14/258";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.initializeDeviceToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // initializeDeviceToolStripMenuItem
            // 
            this.initializeDeviceToolStripMenuItem.Name = "initializeDeviceToolStripMenuItem";
            this.initializeDeviceToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.initializeDeviceToolStripMenuItem.Text = "Initialize device";
            this.initializeDeviceToolStripMenuItem.Click += new System.EventHandler(this.initializeDeviceToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(435, 24);
            this.menuStrip1.TabIndex = 8;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // buttonOpenDestination
            // 
            this.buttonOpenDestination.Location = new System.Drawing.Point(280, 108);
            this.buttonOpenDestination.Name = "buttonOpenDestination";
            this.buttonOpenDestination.Size = new System.Drawing.Size(137, 23);
            this.buttonOpenDestination.TabIndex = 9;
            this.buttonOpenDestination.Text = "Open destination folder";
            this.buttonOpenDestination.UseVisualStyleBackColor = true;
            this.buttonOpenDestination.Click += new System.EventHandler(this.buttonOpenDestination_Click);
            // 
            // checkBoxNewFolder
            // 
            this.checkBoxNewFolder.AutoSize = true;
            this.checkBoxNewFolder.Location = new System.Drawing.Point(12, 161);
            this.checkBoxNewFolder.Name = "checkBoxNewFolder";
            this.checkBoxNewFolder.Size = new System.Drawing.Size(144, 17);
            this.checkBoxNewFolder.TabIndex = 10;
            this.checkBoxNewFolder.Text = "Copy files to a new folder";
            this.checkBoxNewFolder.UseVisualStyleBackColor = true;
            this.checkBoxNewFolder.CheckedChanged += new System.EventHandler(this.checkBoxNewFolder_CheckedChanged);
            // 
            // buttonOpenSource
            // 
            this.buttonOpenSource.Location = new System.Drawing.Point(280, 138);
            this.buttonOpenSource.Name = "buttonOpenSource";
            this.buttonOpenSource.Size = new System.Drawing.Size(137, 23);
            this.buttonOpenSource.TabIndex = 11;
            this.buttonOpenSource.Text = "Open source folder";
            this.buttonOpenSource.UseVisualStyleBackColor = true;
            this.buttonOpenSource.Click += new System.EventHandler(this.buttonOpenSource_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(435, 226);
            this.Controls.Add(this.buttonOpenSource);
            this.Controls.Add(this.checkBoxNewFolder);
            this.Controls.Add(this.buttonOpenDestination);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.labelProgress);
            this.Controls.Add(this.labelFile);
            this.Controls.Add(this.progressBarCopying);
            this.Controls.Add(this.checkBoxStartSystem);
            this.Controls.Add(this.checkBoxDeleteJpeg);
            this.Controls.Add(this.checkBoxDeleteRaw);
            this.Controls.Add(this.labelStatus);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Photomatix";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            this.trayMenu.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.ContextMenuStrip trayMenu;
        private System.Windows.Forms.ToolStripMenuItem menuExit;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.CheckBox checkBoxDeleteRaw;
        private System.Windows.Forms.CheckBox checkBoxDeleteJpeg;
        private System.Windows.Forms.CheckBox checkBoxStartSystem;
        private System.Windows.Forms.ProgressBar progressBarCopying;
        private System.Windows.Forms.Label labelFile;
        private System.Windows.Forms.Label labelProgress;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem initializeDeviceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.Button buttonOpenDestination;
        private System.Windows.Forms.CheckBox checkBoxNewFolder;
        private System.Windows.Forms.Button buttonOpenSource;
    }
}

