using ScreenToImage.RangeSelection;
using ScreenToImage.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScreenToImage.ShowInformation
{
    public partial class Magnifier : Form
    {
        public Magnifier()
        {
            InitializeComponent();

            // コントロール設定
            pic_Screen.Dock = DockStyle.Fill;
            pic_cross.Dock = DockStyle.Fill;
            pic_cross.Parent = pic_Screen;
        }


        private double zoomLevel = 8;
        /// <summary>
        /// 拡大率
        /// </summary>
        public double ZoomLevel
        {
            get { return zoomLevel; }
            set
            {
                zoomLevel = value;
                Magnifier_Resize(null, null);
            }
        }


        int crossWidth = 2;  // 十字線の幅


        // 画面取得用
        Bitmap bitmap_screen;
        Graphics g_screen;
        Point start_getScreen;

        // 拡大後のサイズ
        Size size_expanded;

        // 表示用
        Bitmap bitmap_display;
        Graphics g_display;
        Point start_display;


        public void SetScreen(Point point)
        {
            // 取得する画面の範囲を計算
            Rectangle range = new Rectangle(
                    point.X + start_getScreen.X,
                    point.Y + start_getScreen.Y,
                    bitmap_screen.Width,
                    bitmap_screen.Height
                );


            // 画像を取得
            g_screen.Clear(Color.Black);
            GetScreen.PrtSc(range, bitmap_screen);


            // フォームの大きさに切り抜き、表示する
            g_display.DrawImage(bitmap_screen, 
                start_display.X, start_display.Y,
                size_expanded.Width, size_expanded.Height);


            // 反映
            pic_Screen.Refresh();
        }

        private void Magnifier_Resize(object sender, EventArgs e)
        {
            // 画像取得用の変数を設定
            Rectangle range = GetScreenRange();
            bitmap_screen = new Bitmap(range.Width, range.Height);
            g_screen = Graphics.FromImage(bitmap_screen);
            start_getScreen = new Point(range.X, range.Y);


            // 拡大後の画像サイズを設定
            size_expanded = new Size(
                (int)(range.Width * ZoomLevel),
                (int)(range.Height * ZoomLevel));


            // 表示用の変数を設定
            bitmap_display = new Bitmap(Width, Height);
            g_display = Graphics.FromImage(bitmap_display);
            pic_Screen.Image = bitmap_display;
            start_display  = GetTrimStart();


            // 拡大モード指定
            g_display.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
            g_display.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.Half;


            DrawCross();
        }


        /// <summary>
        /// 画面取得用の相対範囲を取得
        /// </summary>
        /// <returns>範囲</returns>
        private Rectangle GetScreenRange()
        {
            // ・・・□□■□□・・・
            // ・ -> 余剰ピクセル
            // □ -> 領域内ピクセル
            // ■ -> 中心ピクセル


            Rectangle range = new Rectangle();

            // 領域内ピクセルのサイズを決定
            int half_width  = (int)((Width - ZoomLevel)  / 2d / ZoomLevel);
            int half_height = (int)((Height - ZoomLevel) / 2d / ZoomLevel);

            // 余剰ピクセルを追加
            half_width  += 5;
            half_height += 5;

            // 画面取得サイズを決定
            range.Width  = half_width  * 2 + 1;
            range.Height = half_height * 2 + 1;

            // 画面取得の開始位置を決定
            range.X = - half_width;
            range.Y = - half_height;

            return range;
        }



        /// <summary>
        /// トリミングの開始位置(左上)を取得
        /// </summary>
        /// <returns>位置</returns>
        private Point GetTrimStart()
        {
            Point center_display  = new Point(bitmap_display.Width  / 2, bitmap_display.Height  / 2);
            Point center_expanded = new Point(size_expanded.Width / 2, size_expanded.Height / 2);

            // 中心 - 中心
            return new Point(
                center_display.X - center_expanded.X,
                center_display.Y - center_expanded.Y);
        }



        /// <summary>
        /// 十字線を描画
        /// </summary>
        private void DrawCross()
        {
            Pen pen = new Pen(Color.Blue, crossWidth);

            PointF center = new PointF(Width / 2f, Height / 2f);

            Bitmap cross = new Bitmap(Width, Height);
            using (Graphics g = Graphics.FromImage(cross))
            {
                // 十字線を描画
                g.DrawLine(pen, center.X, 0, center.X, Height);
                g.DrawLine(pen, 0, center.Y, Width, center.Y);


                // 枠線も描画
                g.DrawRectangle(Pens.Black, 0, 0, Width - 1, Height - 1);
            }
            pic_cross.Image = cross;
        }
    }
}
