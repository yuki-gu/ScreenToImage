using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScreenToImage.Setting
{
    public partial class SetSetting : Form
    {
        public SetSetting(SettingData setting)
        {
            InitializeComponent();
            this.setting = setting;

            Size screenSize = Screen.PrimaryScreen.Bounds.Size;
            num_magnifierWidth.Maximum = screenSize.Width;
            num_magnifierHeight.Maximum = screenSize.Height;



            num_zoomLevel.Value = (decimal)setting.zoomLevel;

            num_magnifierWidth.Value = setting.magnifierSize.Width;
            num_magnifierHeight.Value = setting.magnifierSize.Height;
            num_fps.Value = setting.fps;

            txt_gifFileName.Text = setting.gifFileName;
            txt_tempFolder.Text = setting.tempFolder;


            btnOk.Select();
        }

        SettingData setting;


        private void btnOk_Click(object sender, EventArgs e)
        {
            ApplySetting();
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ApplySetting()
        {
            setting.zoomLevel = (double)num_zoomLevel.Value;
            setting.magnifierSize.Width = (int)num_magnifierWidth.Value;
            setting.magnifierSize.Height = (int)num_magnifierHeight.Value;

            setting.fps = (int)num_fps.Value;

            if (txt_gifFileName.Text != "")
                setting.gifFileName = txt_gifFileName.Text;
            if (txt_tempFolder.Text != "")
                setting.tempFolder = txt_tempFolder.Text;
        }
    }
}
