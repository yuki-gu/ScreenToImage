using ScreenToImage.RangeSelection;
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
    public partial class InfText : Form
    {
        public InfText()
        {
            InitializeComponent();
        }

        private void setText(string text)
        {
            lbl_text.Text = text;  // テキストを設定

            // 中心に持ってくる
            Point point = new Point(
                (Width - lbl_text.Width) / 2,
                (Height - lbl_text.Height) / 2);
            if (lbl_text.Location != point) lbl_text.Location = point;

            Refresh();  // 更新
        }


        /// <summary>
        /// 位置情報をテキスト表示する
        /// </summary>
        /// <param name="point">位置</param>
        public void setPoint(Point point)
        {
            setText($"{point.X}, {point.Y}");
        }


        /// <summary>
        /// 範囲情報をテキスト表示する
        /// </summary>
        /// <param name="range">範囲</param>
        public void setRange(Range range)
        {
            if (range == null)
                setText($"0 x 0");
            else
                setText($"{range.Width} x {range.Height}");
        }
    }
}
