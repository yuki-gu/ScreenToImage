using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScreenToImage.RangeSelection
{
    public partial class ShowRange : Form
    {
        // コードが汚くなりすぎなければ、
        // 範囲の新規選択・リサイズの2つの関数に分け、
        // type取得、BasePointなどのマウスイベント系は、GetEventに移す

        public ShowRange()
        {
            InitializeComponent();
            pic_range.Dock = DockStyle.Fill;
            TransparencyKey = BackColor;
        }

        private void ShowRange_Load(object sender, EventArgs e)
        {
            // 初期設定
            bitmap_range = new Bitmap(pic_range.Width, pic_range.Height);
            g_range = Graphics.FromImage(bitmap_range);
            pic_range.Image = bitmap_range;
        }

        Bitmap bitmap_range;
        Graphics g_range;


        public Range range = null;

        Point BasePoint;
        Range bef_resize;  // リサイズ前の範囲
        Direction moving_line = null;  // リサイズで移動している辺



        /// <summary>
        /// 範囲選択の基準点(選択の開始点)を設定する
        /// </summary>
        /// <param name="point">点の座標</param>
        public void SetBasePoint(Point point)
        {
            moving_line = GetBorderLocation(point);

            if (moving_line == null)
                // 新規選択
                BasePoint = point;
            else if (range != null)
                // リサイズ
                bef_resize = new Range(range);  // リサイズ前の範囲を保存
        }


        /// <summary>
        /// 基準点と終了点を元に、範囲を設定する
        /// </summary>
        /// <param name="end">終了点</param>
        public void SetRange(Point end)
        {
            // 範囲決定
            if (moving_line == null)
            {
                // 新規選択
                range = new Range(BasePoint, end);
            }
            else
            {
                // リサイズ

                // 動かす場所
                bool left  = moving_line.X == -1;
                bool up    = moving_line.Y == -1;
                bool right = moving_line.X ==  1;
                bool down  = moving_line.Y ==  1;


                // 設定
                range = new Range(bef_resize);  // リサイズ前の範囲からリサイズ

                if (left) range.Left = end.X;
                else if (right) range.Right = end.X;
                if (up) range.Top = end.Y;
                else if (down) range.Bottom = end.Y;


                // 正規化
                range.Normalize();
            }


            // サイズが0の場合は描画しない
            if (range.Width * range.Height <= 1)
                range = null;


            // 範囲を描画
            drawRange();
        }



        /// <summary>
        /// 指定した座標が、枠のどの位置にあるのかを表す
        /// </summary>
        /// <param name="point">座標</param>
        /// <returns>位置を表すLocationTypeクラス</returns>
        public Direction GetBorderLocation(Point point)
        {
            if (range == null)
                return null;

            // 感知幅
            int borderWidth = 11;


            // 感知幅 (offset_s + 1 + offset_e = borderWidth)
            int offset_s = ((borderWidth - 1) / 2) + 1;
            int offset_e = (borderWidth / 2) + 1;


            // 判定用 (計算を簡単にする)
            int pointX_s = point.X + offset_s;
            int pointX_e = point.X - offset_e;
            int pointY_s = point.Y + offset_s;
            int pointY_e = point.Y - offset_e;


            // 判定
            bool left  = false;
            bool up    = false;
            bool right = false;
            bool down  = false;

            if (range.Left <= pointX_s &&
                              pointX_e <= range.Right)
            {
                up = (range.Top <= pointY_s &&
                                   pointY_e <= range.Top);

                down = (range.Bottom <= pointY_s &&
                                        pointY_e <= range.Bottom);
            }
            if (range.Top <= pointY_s &&
                             pointY_e <= range.Bottom)
            {

                left = (range.Left <= pointX_s &&
                                      pointX_e <= range.Left);

                right = (range.Right <= pointX_s &&
                                        pointX_e <= range.Right);
            }


            // 設定されていない場合
            if ((up || down || left || right) == false) return null;

            return new Direction(up, down, left, right);
        }



        /// <summary>
        /// 囲われる範囲を指定して、その周りに線を引く
        /// </summary>
        private void drawRange()
        {
            // サイズが0の場合は描画しない
            if (range == null)
            {
                g_range.Clear(pic_range.BackColor);
                pic_range.Refresh();
                return;
            }


            // 設定
            int width = 1;
            Pen pen = new Pen(Color.Blue, width);


            // 線幅
            int offset_s = ((width - 1) / 2) + 1;
            int offset_e = (width / 2) + 1;


            // 各値を計算
            int left = range.Left - offset_s;
            int top = range.Top - offset_s;
            int right = range.Right + offset_e;
            int bottom = range.Bottom + offset_e;


            // 描画処理
            g_range.Clear(pic_range.BackColor);
            g_range.DrawRectangle(pen, left, top, right - left, bottom - top);


            // 反映
            pic_range.Refresh();
        }
    }

    public class Range
    {
        public Range()
        {

        }

        public Range(Range range) : this(range.Left, range.Top, range.Right, range.Bottom)
        {
            // コピー用
        }
        public Range(Point start, Point end) : this(start.X, start.Y, end.X, end.Y)
        {
            
        }
        public Range(int left, int top, int right, int bottom)
        {
            Left = left;
            Top = top;
            Right = right;
            Bottom = bottom;

            Normalize();
        }


        public int Left = 0;
        public int Top = 0;
        public int Right = 0;
        public int Bottom = 0;



        public int Width
        {
            get { return Right - Left + 1; }
            set { Right = Left + value - 1; }
        }

        public int Height
        {
            get { return Bottom - Top + 1; }
            set { Bottom = Top + value - 1; }
        }

        public Rectangle Rect
        {
            get { return new Rectangle(Left, Top, Width, Height); }
            set { Left = value.X; Top = value.Y; Width = value.Width; Height = value.Height; }
        }



        /// <summary>
        /// 値を正規化する
        /// </summary>
        public void Normalize()
        {
            // 左右の正規化
            if (Right < Left)
            {
                int temp = Left;
                Left = Right;
                Right = temp;
            }

            // 上下の正規化
            if (Bottom < Top)
            {
                int temp = Top;
                Top = Bottom;
                Bottom = temp;
            }
        }
    }


    /// <summary>
    /// 上下右左の、どの位置にあるのかを表す
    /// </summary>
    public class Direction
    {
        public Direction()
        {

        }
        public Direction(int x, int y)
        {
            X = x;
            Y = y;
        }
        public Direction(bool up, bool down, bool left, bool right)
        {
            if (up) Y = -1;
            else if (down) Y = 1;
            else Y = 0;

            if (left) X = -1;
            else if (right) X = 1;
            else X = 0;
        }



        /// <summary>
        /// X軸の位置 (-1→Left,  0→Center,  1→Right)
        /// </summary>
        public int X { get; set; }


        /// <summary>
        /// Y軸の位置 (-1→Up,  0→Middle,  1→Down)
        /// </summary>
        public int Y { get; set; }


        /// <summary>
        /// 値が一致するか
        /// </summary>
        public bool isMatch(int x, int y)
        {
            return X == x && Y == y;
        }
        public bool isMatch(bool up, bool down, bool left, bool right)
        {
            return (Y == -1) == up &&
                   (Y ==  1) == down &&
                   (X == -1) == left &&
                   (X ==  1) == right;

        }
        public bool isMatch(string str)
        {
            return (Y == -1) == str.IndexOf("up", StringComparison.OrdinalIgnoreCase) >= 0 &&
                   (Y ==  1) == str.IndexOf("down", StringComparison.OrdinalIgnoreCase) >= 0 &&
                   (X == -1) == str.IndexOf("left", StringComparison.OrdinalIgnoreCase) >= 0 &&
                   (X ==  1) == str.IndexOf("right", StringComparison.OrdinalIgnoreCase) >= 0;
        }
    }
}
