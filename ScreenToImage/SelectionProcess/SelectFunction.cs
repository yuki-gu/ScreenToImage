using ScreenToImage.SelectionProcess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScreenToImage.SelectionProcess
{
    public partial class SelectFunction : Form
    {
        public SelectFunction()
        {
            InitializeComponent();

            panel.Left = borderWidth;
            panel.Top = borderWidth;
        }

        public void SetControl(params Control[] controls)
        {
            panel.Controls.Clear();
            foreach (Control control in controls)
            {
                control.Resize += delegate { SetLayout(); };
                panel.Controls.Add(control);
            }
            SetLayout();
        }

        int borderWidth = 1;

        private void SetLayout()
        {
            int maxHeight = 0;

            // X方向の位置決定
            int left = 0;
            foreach (Control control in panel.Controls)
            {
                // 横に並べる
                control.Left = left;
                left += control.Width;


                // 最大の高さを取得
                if (maxHeight < control.Height)
                    maxHeight = control.Height;
            }

            // Y方向の位置決定
            foreach (Control control in panel.Controls)
            {
                // 上下中央
                control.Top = (maxHeight - control.Height) / 2;
            }


            // サイズ変更
            panel.Width = left;
            panel.Height = maxHeight;
            Width = panel.Width + (borderWidth * 2);
            Height = panel.Height + (borderWidth * 2);
        }
    }
}
