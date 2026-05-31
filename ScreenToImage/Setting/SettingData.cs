using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ScreenToImage.Setting
{
    public class SettingData
    {
        const string FILE_NAME = "setting.xml";


        public string tempFolder = "temp";

        public double zoomLevel = 8;
        public Size magnifierSize = new Size(200, 200);

        public int fps = 30;
        public string gifFileName = "gifFile";

        public string gifFilePath
        {
            get { return Path.Combine(tempFolder, (gifFileName + ".gif")); }
        }


        public static SettingData Open()
        {
            if (File.Exists(FILE_NAME))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(SettingData));
                using (FileStream stream = new FileStream(FILE_NAME, FileMode.Open, FileAccess.Read, FileShare.Read))
                using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
                {
                    return (SettingData)serializer.Deserialize(reader);
                }
            }
            else
            {
                SettingData setting = new SettingData();
                Save(setting);
                return setting;
            }
        }

        public static void Save(SettingData setting)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(SettingData));
            using (FileStream stream = new FileStream(FILE_NAME, FileMode.Create, FileAccess.Write, FileShare.Read))
            using (StreamWriter writer = new StreamWriter(stream, Encoding.UTF8))
            {
                serializer.Serialize(writer, setting);
            }
        }
    }
}
