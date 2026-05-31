using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScreenToImage.ShowInformation
{
    public class LayoutInf
    {
        public LayoutInf()
        {
            magnifier.Resize += new EventHandler(Magnifier_Resize);

            // 初期設定
            text.Height = 30;
        }

        int margin = 10;

        public Magnifier magnifier = new Magnifier();
        public InfText text = new InfText();


        #region プロパティ
        public int Width
        {
            get { return magnifier.Width; }
        }


        public int Height
        {
            get { return text.Height + margin + magnifier.Height; }
        }


        private Point location;
        public Point Location
        {
            get { return location; }
            set
            {
                location = value;
                SetLocation();
            }
        }


        public bool Visible
        {
            get { return magnifier.Visible; }
            set
            {
                text.Visible      = value;
                magnifier.Visible = value;
            }
        }

        #endregion


        /// <summary>
        /// フォームを配置する
        /// </summary>
        private void SetLocation()
        {
            text.Location = location;
            magnifier.Location = new Point(location.X, location.Y + text.Height + margin);
        }


        private void Magnifier_Resize(object sender, EventArgs e)
        {
            text.Width = magnifier.Width;  // 横幅を合わせる
            SetLocation();
        }
    }
}
