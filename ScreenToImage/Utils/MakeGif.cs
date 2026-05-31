using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScreenToImage.Utils
{
    public class MakeGif
    {
        /// <summary>
        /// Gifアニメーションの作成を開始します
        /// </summary>
        /// <param name="fileName">保存するファイル名</param>
        public MakeGif(string fileName)
        {
            stream = new FileStream(fileName, FileMode.Create, FileAccess.Write, FileShare.Read);
            writer = new BinaryWriter(stream);
        }


        ushort num_loop = 1;  // ループ回数
        string Comment = "Made with ScreenToImage";

        FileStream stream;
        BinaryWriter writer;

        bool isWrittenHeader = false;  // Headerが書き込まれているか


        /// <summary>
        /// 画像を追加します
        /// </summary>
        /// <param name="bitmap">追加する画像</param>
        /// <param name="Delay">表示する際の遅延時間(100分の1秒)</param>
        public void Add(Bitmap bitmap, ushort Delay)
        {
            if (isWrittenHeader == false)
            {
                // ヘッダーを書き込む
                WriteHeader(bitmap);
                isWrittenHeader = true;
            }

            writer.Write(GetImageBlock(bitmap, Delay));
        }


        /// <summary>
        /// 作成を終了します
        /// </summary>
        public void Close()
        {
            // Comment Extension(コメント)の書き込み
            writer.Write(new byte[] { 0x21, 0xfe });  // 固定値
            // メッセージ
            byte[] comment = Encoding.ASCII.GetBytes(Comment);
            writer.Write((byte)comment.Length);  // メッセージのバイト数(1バイト)
            writer.Write(comment);  // メッセージの書き込み
            writer.Write((byte)0x00);  // ブロックの終わり


            // 終わりを表す
            writer.Write((byte)0x3b);


            writer.Dispose();
            stream.Close();
        }



        /// <summary>
        /// Header部分を書き込む
        /// </summary>
        /// <param name="initializeBitmap">初期設定用の画像</param>
        private void WriteHeader(Bitmap initializeBitmap)
        {
            // GIF Header(ヘッダー)を書き込み
            using (MemoryStream ms = new MemoryStream())
            {
                initializeBitmap.Save(ms, ImageFormat.Gif);
                ms.Position = 0;
                writer.Write(readBytes(ms, 10));  // 固定値(幅・高さを含む)
                byte[] bits = readBytes(ms, 1);  // 設定取得
                writer.Write(bits[0]);  // 設定書き込み
                writer.Write(readBytes(ms, 2));
                // 2進数(1000 0000)を使って、1つめのビット(Global Color Tableが存在するか)を確認
                if ((bits[0] & 0x80) != 0)
                {
                    // Global Color Tableを書き込み

                    // 2進数(0000 0111)を使って、下位3ビット(Global Color Tableのサイズ)を取得
                    // この値(0～7)に1を足した値をnとして、2のn乗がGlobal Color Tableの個数となる
                    // ×3バイト(RGBの3色)
                    writer.Write(readBytes(ms, (int)Math.Pow(2, (bits[0] & 0x07) + 1) * 3));
                }
            }

            // Application Extension(アプリケーションデータ)を書き込み
            writer.Write(new byte[] { 0x21, 0xff, 0x0b });  // 固定値
            writer.Write(Encoding.ASCII.GetBytes("NETSCAPE"));  // Application Identifier
            writer.Write(Encoding.ASCII.GetBytes("2.0"));  // Application Authentication Code
            writer.Write((byte)0x03);  // Application Dataのバイト数
            // Application Data
            writer.Write((byte)0x01);  // 固定値(1バイト)
            writer.Write(BitConverter.GetBytes(num_loop));  // ループ回数(2バイト)

            writer.Write((byte)0x00);  // ブロックの終わり
        }


        /// <summary>
        /// GIFファイルのイメージブロックを作成
        /// </summary>
        /// <param name="bitmap">画像</param>
        /// <param name="Delay">表示する際の遅延時間(1/100s)</param>
        /// <returns>イメージブロックのバイト列</returns>
        private static byte[] GetImageBlock(Bitmap bitmap, ushort Delay)
        {
            List<byte> ret = new List<byte>();
            using (MemoryStream ms = new MemoryStream())
            {
                bitmap.Save(ms, ImageFormat.Gif);  // bitmap -> Gif

                // 先頭のGIF Headerの部分を飛ばし、Image Blockの部分まで進める
                ms.Position = 10;
                byte[] bits = readBytes(ms, 1);
                ms.Position += 2;
                // 2進数(1000 0000)を使って、1つめのビット(Global Color Tableが存在するか)を確認
                if ((bits[0] & 0x80) != 0)
                {
                    // Global Color Tableが存在した場合、そのビット数だけ飛ばす

                    // 2進数(0000 0111)を使って、下位3ビット(Global Color Tableのサイズ)を取得
                    // この値(0～7)に1を足した値をnとして、2のn乗がGlobal Color Tableの個数となる
                    // ×3バイト(RGBの3色)
                    ms.Position += (int)Math.Pow(2, (bits[0] & 0x07) + 1) * 3;
                }


                // Graphic Control Extension(表示データ)ブロックの追加
                ret.AddRange(readBytes(ms, 4));  // 固定値の4バイトを書き込み
                ret.AddRange(BitConverter.GetBytes(Delay));  // 遅延時間(2バイト)を書き込み
                ms.Position += 2;  // 遅延時間(2バイト)進める

                // 後ろの部分を追加 (Image Block)
                // -1 (終わりを表す1ビット)
                long mainLen = ms.Length - ms.Position - 1;
                // 残りがintの最大値になるまで追加
                for (; mainLen > int.MaxValue; mainLen -= int.MaxValue)
                {
                    ret.AddRange(readBytes(ms, int.MaxValue));
                }
                ret.AddRange(readBytes(ms, (int)mainLen));
            }
            return ret.ToArray();
        }



        /// <summary>
        /// ストリームを読み込む
        /// </summary>
        /// <param name="ms">読み込むストリーム</param>
        /// <param name="count">読み込む数</param>
        /// <returns>バイト列</returns>
        private static byte[] readBytes(MemoryStream ms, int count)
        {
            byte[] bytes = new byte[count];
            ms.Read(bytes, 0, count);  // 読み取り
            return bytes;
        }
    }
}
