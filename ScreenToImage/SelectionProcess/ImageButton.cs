using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScreenToImage.SelectionProcess
{
    public partial class ImageButton : UserControl
    {
        public ImageButton(Bitmap bitmap, string desc = null)
        {
            InitializeComponent();
            pic_Image.Dock = DockStyle.Fill;
            pic_Hover.Dock = DockStyle.Fill;
            pic_Hover.Parent = pic_Image;
            Width = bitmap.Width;
            Height = bitmap.Height;
            if (desc != null)
                description.SetToolTip(pic_Hover, desc);


            // 初期設定
            pic_Image.Image = bitmap;

            bitmap_Hover = new Bitmap(bitmap.Width, bitmap.Height);
            g_Hover = Graphics.FromImage(bitmap_Hover);
            g_Hover.Clear(Color.Transparent);
            pic_Hover.Image = bitmap_Hover;
        }

        Bitmap bitmap_Hover;
        Graphics g_Hover;


        // マウスホバーアニメーション
        private void pic_Hover_MouseEnter(object sender, EventArgs e)
        {
            g_Hover.Clear(Color.FromArgb(100, BackColor));
            pic_Hover.Refresh();
        }

        private void pic_Hover_MouseLeave(object sender, EventArgs e)
        {
            g_Hover.Clear(Color.Transparent);
            pic_Hover.Refresh();
        }


        // クリックイベント
        public delegate void ClickHandler(object sender);
        /// <summary>
        /// ボタンがクリックされると発生します
        /// </summary>
        public new event ClickHandler Click;

        private void pic_Hover_Click(object sender, EventArgs e)
        {
            if (Click != null)
                Click(this);
        }
    }
}
