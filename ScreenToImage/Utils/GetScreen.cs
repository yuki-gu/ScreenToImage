using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScreenToImage.Utils
{
    public class GetScreen
    {

        /// <summary>
        /// スクリーンキャプチャを実行
        /// </summary>
        /// <param name="rect">キャプチャする範囲</param>
        /// <param name="bitmap">反映するビットマップ</param>
        /// <returns></returns>
        public static Bitmap PrtSc(Rectangle rect, Bitmap bitmap = null)
        {
            if (bitmap == null)
                bitmap = new Bitmap(rect.Width, rect.Height);

            using (Graphics g = Graphics.FromImage(bitmap))
            {
                g.CopyFromScreen(rect.X, rect.Y, 0, 0, rect.Size);
            }

            return bitmap;
        }
    }
}
