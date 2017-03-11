using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhotoCopy
{
    public partial class InitDeviceForm : Form
    {
        private string selectedDeviceDir;
        private string selectedTargetDir;

        public InitDeviceForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    selectedDeviceDir = fbd.SelectedPath;
                    labelSource.Text = selectedDeviceDir;
                }
            }
        }

        private void buttonChooseDestination_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    selectedTargetDir = fbd.SelectedPath;
                    labelDestination.Text = selectedTargetDir;
                }
            }
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            string uuid = Guid.NewGuid().ToString(); //new device uuid
            string deviceDrive = Path.GetPathRoot(selectedDeviceDir); //drive where the device is attached
            string deviceDirRelativePath = selectedDeviceDir.Replace(deviceDrive, ""); //get relative path of the desired directory w/o drive letter (it changes everytime)
            string deviceConfigFile = Path.Combine(deviceDrive, MainForm.deviceConfigFilename); //path to the config file on the attached device

            if (!File.Exists(deviceConfigFile))
            {
                File.Create(deviceConfigFile).Close();
            }

            IniParser iniParser = new IniParser(deviceConfigFile); //create config file on the device
            iniParser.AddSetting("config", "uuid", uuid);
            iniParser.SaveSettings();

            AppSettings.Instance.Put(uuid, "device_name", textBoxName.Text);
            AppSettings.Instance.Put(uuid, "source_directory", deviceDirRelativePath); //put device settings to program config file
            AppSettings.Instance.Put(uuid, "target_directory", selectedTargetDir);

            Close();
        }

    }
}
