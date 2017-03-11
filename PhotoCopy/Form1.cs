using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Management;
using System.IO;
using System.Configuration;
using Microsoft.Win32;
using System.Diagnostics;

namespace PhotoCopy
{
    public partial class MainForm : Form
    {
        public static readonly string deviceConfigFilename = "photocopy_config.ini";
        public static readonly string[] rawExtensions = { ".arw", ".dng" };
        public static readonly string[] jpgExtensions = { ".jpg", ".jpeg" };
        
        private string sourceFolder;
        private string destinationFolder;

        private string deviceDrive;
        private string deviceUUID;
        private string deviceName;

        public MainForm()
        {
            InitializeComponent();

            notifyIcon.Visible = true;
            notifyIcon.ContextMenuStrip = trayMenu;
        
            checkBoxStartSystem.Checked = Boolean.Parse(AppSettings.Instance.Get("config", "auto_startup") ?? "false");

            UpdateProgress();
            InitUsb();

            //watch for USB changes
            Task.Run(() =>
            {
                ManagementEventWatcher watcher = new ManagementEventWatcher();
                WqlEventQuery query = new WqlEventQuery("SELECT * FROM Win32_VolumeChangeEvent");
                watcher.EventArrived += new EventArrivedEventHandler(UsbStatusChanged);
                watcher.Query = query;
                watcher.Start();
            });
        }

        private void BackupFiles()
        {
            Show();
            this.WindowState = FormWindowState.Normal;
           
            string[] deviceFiles = Directory.GetFiles(sourceFolder);

            string currentDestinationFolder = destinationFolder;

            string[] filesToCopy = deviceFiles.Select(f => Path.GetFileName(f)) //device filenames
                .Except(Directory.EnumerateFiles(currentDestinationFolder, "*.*", SearchOption.AllDirectories).Select(f => Path.GetFileName(f))) //except backed up filenames
                .Select(f => Path.Combine(sourceFolder, f)) //add path back to filenames
                .ToArray();

            int done = 0;
            int total = filesToCopy.Length;

            UpdateProgress(done, total, "");

            if(checkBoxNewFolder.Checked)
            {
                currentDestinationFolder = Path.Combine(currentDestinationFolder, "Backup " + DateTime.Now.ToShortDateString());
                Directory.CreateDirectory(currentDestinationFolder);
            }

            Task.Run(() =>
            {
                foreach (string file in filesToCopy.Reverse())
                {
                    bool deleteJpeg = checkBoxDeleteJpeg.Checked;
                    bool deleteRaw = checkBoxDeleteRaw.Checked;

                    string filename = Path.GetFileName(file);
                    string targetFile = Path.Combine(currentDestinationFolder, filename);
                    string extension = Path.GetExtension(file);

                    File.Copy(file, targetFile);
                    if ((deleteJpeg && jpgExtensions.Contains(extension)) ||
                        (deleteRaw && rawExtensions.Contains(extension)))
                    {
                        File.Delete(file);
                    }
                    
                    ++done;

                    Invoke((MethodInvoker)delegate
                    {
                        UpdateProgress(done, total, filename);
                    });

                }
            });
        }

        private void initializeDeviceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new InitDeviceForm().ShowDialog();
            InitUsb();
        }

        public void InitUsb()
        {
            //try to find a valid device in available drives
            deviceDrive = DriveInfo.GetDrives()
                .Select(drive => Path.GetPathRoot(drive.Name).Replace("\\", ""))
                .FirstOrDefault(drive => IsValidDevice(drive));

            DeviceStatusChanged();
        }

        private void UsbStatusChanged(object sender, EventArrivedEventArgs e)
        {
            string newDrive = Path.GetPathRoot(e.NewEvent.Properties["DriveName"].Value.ToString()).Replace("\\", "");
            bool connected = IsValidDevice(newDrive);
       
            if (connected && deviceDrive == null) //new device connected
            {
                deviceDrive = newDrive;
            }

            if (!connected && newDrive == deviceDrive) //device disconnected
            {
                deviceDrive = null;
                deviceUUID = null;
                deviceName = null;
            }

            Invoke((MethodInvoker)delegate
            {
                DeviceStatusChanged();
            });
        }

        private void DeviceStatusChanged()
        {
            if (deviceDrive != null)
            {
                setControlsEnabled(true, checkBoxDeleteJpeg, checkBoxDeleteRaw, checkBoxNewFolder, buttonOpenDestination, buttonOpenSource);
                labelStatus.ForeColor = Color.DarkGreen;

                LoadDeviceConfig();

                BackupFiles();
            }
            else
            {
                setControlsEnabled(false, checkBoxDeleteJpeg, checkBoxDeleteRaw, checkBoxNewFolder, buttonOpenDestination, buttonOpenSource);            
                labelStatus.Text = "No device connected";
                labelStatus.ForeColor = Color.DarkRed;
            }
        }

        private void UpdateProgress(int done = 0, int total = 0, String currentFile = "")
        {
            labelFile.Text = Path.GetFileName(currentFile);
            labelProgress.Text = total > 0 ? String.Format("{0}/{1}", done, total) : "";

            if (done == total)
            {
                labelFile.Text = total > 0 ? "Backup complete" : "";
            }

            progressBarCopying.Maximum = total;
            progressBarCopying.Value = done;
        }

        private void buttonOpenDestination_Click(object sender, EventArgs e)
        {
            Process.Start(destinationFolder);
        }

        private bool IsValidDevice(string drive)
        {
            string deviceConfigFile = Path.Combine(drive, deviceConfigFilename);

            bool connected = drive != null && File.Exists(deviceConfigFile);
            if (connected)
            {
                IniParser iniParser = new IniParser(deviceConfigFile);
                string uuid = iniParser.GetSetting("config", "uuid");

                if(AppSettings.Instance.Get(uuid, "target_directory") != null)
                {
                    deviceUUID = uuid;
                    return true;
                }
                return false; //config file exists, but the device is not paired yet
            }
            return false; //no config file on the device
        }

        private void LoadDeviceConfig()
        {
            deviceName = AppSettings.Instance.Get(deviceUUID, "device_name");

            destinationFolder = AppSettings.Instance.Get(deviceUUID, "target_directory");
            sourceFolder = Path.Combine(deviceDrive, AppSettings.Instance.Get(deviceUUID, "source_directory"));            

            checkBoxDeleteJpeg.Checked = Boolean.Parse(AppSettings.Instance.Get(deviceUUID, "delete_jpeg") ?? "false");
            checkBoxDeleteRaw.Checked = Boolean.Parse(AppSettings.Instance.Get(deviceUUID, "delete_raw") ?? "false");
            checkBoxNewFolder.Checked = Boolean.Parse(AppSettings.Instance.Get(deviceUUID, "create_new_directory") ?? "false");

            labelStatus.Text = String.Format("Device connected: {0} ({1})", deviceName, deviceDrive);
        }

        private void menuExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void notifyIcon_DoubleClick(object sender, EventArgs e)
        {
            Show();
            this.WindowState = FormWindowState.Normal;
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                Hide();
            }
        }

        private void checkBoxDeleteRaw_CheckedChanged(object sender, EventArgs e)
        {
            AppSettings.Instance.Put(deviceUUID, "delete_raw", checkBoxDeleteRaw.Checked.ToString());
        }

        private void checkBoxDeleteJpeg_CheckedChanged(object sender, EventArgs e)
        {
            AppSettings.Instance.Put(deviceUUID, "delete_jpeg", checkBoxDeleteJpeg.Checked.ToString());
        }

        private void checkBoxStartSystem_CheckedChanged(object sender, EventArgs e)
        {
            AppSettings.Instance.Put("config", "auto_startup", checkBoxStartSystem.Checked.ToString());
            SetStartup();
        }

        private void SetStartup()
        {
            RegistryKey rk = Registry.CurrentUser.OpenSubKey(
                "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);

            if (checkBoxStartSystem.Checked)
            {
                rk.SetValue("Photomatix", Application.ExecutablePath.ToString() + " -background");
            }
            else
            {
                rk.DeleteValue("Photomatix", false);
            }

        }



        private void buttonOpenSource_Click(object sender, EventArgs e)
        {
            Process.Start(Path.Combine(deviceDrive, AppSettings.Instance.Get(deviceUUID, "source_directory")));
        }

        private void checkBoxNewFolder_CheckedChanged(object sender, EventArgs e)
        {
            AppSettings.Instance.Put(deviceUUID, "create_new_directory", checkBoxNewFolder.Checked.ToString());
        }

        private void setControlsEnabled(bool enabled, params Control[] controls)
        {
            foreach(var control in controls)
            {
                control.Enabled = enabled;
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            if (Environment.GetCommandLineArgs().Contains("-background"))
            {
                BeginInvoke(new MethodInvoker(delegate
                {
                    Hide();
                }));
            }
        }
    }
}
