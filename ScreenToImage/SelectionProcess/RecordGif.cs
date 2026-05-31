using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ScreenToImage.Utils;
using System.Diagnostics;

namespace ScreenToImage.SelectionProcess
{
    public partial class RecordGif : UserControl
    {
        public RecordGif(Rectangle range, int fps = 30)
        {
            InitializeComponent();

            this.range = range;
            screen = new Bitmap(range.Width, range.Height);

            if (100 < fps) fps = 100;
            this.fps = fps;

            SetLayout(fps, "0:00:00", 0);
        }

        Rectangle range;
        Bitmap screen;

        MakeGif gif = null;
        Stopwatch stopwatch = new Stopwatch();
        int fps;

        public bool isEndRecord { get; private set; } = false;  // 録画を終了するか
        bool isRecording = false;  // 録画しているか


        delegate void SetLayoutDelegate(int fps, string time, int frame);


        /// <summary>
        /// 録画を開始します
        /// </summary>
        public void Record(string gifFilePath)
        {
            isPause = false;  // 開始時に一時停止になるのを防ぐ

            stopwatch.Restart();  // 時間をリセット

            if (gif != null) Save();  // 前のデータが残っていた場合、保存処理をする
            gif = new MakeGif(gifFilePath);  // 新規設定

            isEndRecord = false;  // 終了フラグをリセット
            DoWork();
        }

        /// <summary>
        /// 一時停止します
        /// </summary>
        public void Stop()
        {
            isPause = true;
        }

        /// <summary>
        /// 一時停止から再開します
        /// </summary>
        public void Start()
        {
            isPause = false;
        }

        /// <summary>
        /// 録画を終了し、Gifファイルを保存します
        /// </summary>
        public void Save()
        {
            if (gif == null) return;

            if (isRecording)
                isEndRecord = true;  // 停止

            isPause = false;  // 一時停止を解除

            while (isRecording)
                System.Threading.Thread.Sleep(5);  // キャンセル完了まで待機

            gif.Close();  // 保存
        }


        private Task DoWork()
        {
            Task task = Task.Run(() =>
            {
                isRecording = true;

                // fpsから間隔を計算
                int[] intervals = new int[fps];
                double count = 0;
                int bef_num = 0;
                for (int i = 0; i < intervals.Length; i++)
                {
                    count += (100d / fps);
                    intervals[i] = (int)Math.Round(count) - bef_num;
                    bef_num += intervals[i];
                }


                int frame = 0;
                int index = 0;
                TimeSpan nextTime = TimeSpan.FromMilliseconds(intervals[0] * 10);  // 次の処理の開始時間

                while (isEndRecord == false)
                {
                    Pause();  // 一時停止処理
                    if (isEndRecord) break;  // 一時停止中に終了した場合

                    TimeSpan time = stopwatch.Elapsed;
                    if (time >= nextTime)
                    {
                        // 画像を追加
                        gif.Add(GetScreenImage(), (ushort)intervals[index]);

                        // 次の場所
                        index++;
                        if (index >= fps) index = 0;

                        frame++;  // フレーム数 (表示用)

                        // 次の処理の開始時間を設定
                        nextTime += TimeSpan.FromMilliseconds(intervals[index] * 10);


                        // 表示
                        string time_str = time.ToString(@"h\:mm\:ss");  //01:10:15
                        if (InvokeRequired && isEndRecord == false)
                            Invoke(new SetLayoutDelegate(SetLayout), fps, time_str, frame);
                    }
                }

                isRecording = false;
            });

            return task;
        }



        private void SetLayout(int fps, string time, int frame)
        {
            int margin = 10;
            lbl.Text = $"{fps}FPS / {time} / {frame}Frame";

            lbl.Top = (Height - lbl.Height) / 2;
            lbl.Left = margin;
            Width = lbl.Width + (margin * 2);
        }


        /// <summary>
        /// 画面の画像を取得
        /// </summary>
        /// <returns>画像</returns>
        private Bitmap GetScreenImage()
        {
            return GetScreen.PrtSc(range, screen);
        }


        public bool isPause = false;
        /// <summary>
        /// 一時停止処理
        /// </summary>
        private void Pause()
        {
            if (isPause == false) return;
            stopwatch.Stop();  // 時間を進めない

            // 一時停止
            while (isPause)
            {
                System.Threading.Thread.Sleep(10);
            }
            stopwatch.Start();
        }
    }
}
