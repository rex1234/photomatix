using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoCopy
{
    class AppSettings
    {
        public static readonly string configFilename = "photocopyconfig.ini";

        private static AppSettings instance;

        private IniParser iniConfig;

        private AppSettings()
        {
            string configFile = Path.Combine(Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath), configFilename);

            if (!File.Exists(configFile))
            {
                File.Create(configFile).Close();
            }

            iniConfig = new IniParser(configFile);
        }

        public static AppSettings Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new AppSettings();
                }
                return instance;
            }
        }

        public string Get(string section, string key)
        {
            return iniConfig.GetSetting(section, key);
        }

        public void Put(string section, string key, string value)
        {
            iniConfig.AddSetting(section, key, value);
            iniConfig.SaveSettings();
        }
    }
}
