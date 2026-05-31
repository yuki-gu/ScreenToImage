using ScreenToImage.SelectionProcess;
using ScreenToImage.Setting;
using ScreenToImage.ShowInformation;
using ScreenToImage.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScreenToImage.RangeSelection
{
    public partial class GetEvent : Form
    {
        public GetEvent()
        {
            InitializeComponent();
            Opacity = 0.004;  //透明化

            // アイコンをexeファイルのアイコンにする
            Icon = Icon.ExtractAssociatedIcon(System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName);
        }

        private void GetEvent_Load(object sender, EventArgs e)
        {
            setting = SettingData.Open();  // 設定を読み込み

            // フォームの表示
            showRange.Show();
            selectFunction.Show();
            inf.text.Show();
            inf.magnifier.Show();


            // 設定を反映
            ApplySetting();


            // フォームの設定
            SetLocation_Inf();
            selectFunction.Visible = false;
            selectFunction.Resize += delegate
            {
                SetLocation_SelectFunction();
            };
            SetFunction1();
        }

        private void GetEvent_FormClosed(object sender, FormClosedEventArgs e)
        {
            SettingData.Save(setting);  // 設定を保存
        }

        SettingData setting;

        // フォーム
        ShowRange showRange = new ShowRange();
        SelectFunction selectFunction = new SelectFunction();
        LayoutInf inf = new LayoutInf();

        RecordGif recordGif;




        bool flg_mouseDown = false;  // 選択中かどうか

        private void GetEvent_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;  // 左クリックのみ

            // 設定
            flg_mouseDown = true;  // マウスが押されている
            showRange.SetBasePoint(e.Location);  // 基準点を設定

            inf.Visible = true;
            SetLocation_Inf();
            selectFunction.Visible = false;
        }

        private void GetEvent_MouseMove(object sender, MouseEventArgs e)
        {
            if (flg_mouseDown)
                showRange.SetRange(e.Location);  // 範囲を描画

            SetCursor(e.Location);  // カーソルを設定

            if (inf.Visible)
            {
                if (flg_mouseDown)
                    inf.text.setRange(showRange.range);  // 範囲を表示
                else
                    inf.text.setPoint(e.Location);  // マウスの位置を表示

                inf.magnifier.SetScreen(e.Location);  // 拡大画像を表示
                SetLocation_Inf();  // 情報ウィンドウを配置
            }
        }

        private void GetEvent_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right) Close();
            if (e.Button != MouseButtons.Left) return;  // 左クリックのみ

            flg_mouseDown = false;  // マウスを離している
            showRange.SetRange(e.Location);  // 範囲を描画

            // 選択フォームの表示
            if (showRange.range == null)
            {
                inf.Visible = true;
                selectFunction.Visible = false;
            }
            else
            {
                inf.Visible = false;
                selectFunction.Visible = true;
                SetLocation_SelectFunction();
            }
        }




        // ShowRange
        private void SetCursor(Point point)
        {
            Direction direction = showRange.GetBorderLocation(point);

            if (direction == null || direction.isMatch(0, 0)) Cursor = Cursors.Cross;
            else
            {
                if (direction.X == 0 &&
                    direction.Y != 0)            Cursor = Cursors.SizeNS;

                if (direction.X != 0 ||
                    direction.Y == 0)            Cursor = Cursors.SizeWE;

                if (direction.X == direction.Y)  Cursor = Cursors.SizeNWSE;

                if (direction.X == -direction.Y) Cursor = Cursors.SizeNESW;
            }
            
        }





        // 配置
        private void SetLocation_Inf()
        {
            int margin = 15;
            int max = Math.Max(setting.magnifierSize.Width, setting.magnifierSize.Height);
            int min_margin = (int)(max / setting.zoomLevel) + 1;
            if (margin < min_margin) margin = min_margin;

            Point location = new Point();
            Range range = showRange.range;

            Direction dir = new Direction(1, 1);
            if (flg_mouseDown)
            {
                if (range == null) return;  // 選択範囲が0の場合
                dir = GetCursorDirection();  // 範囲から方向を取得
            }

            // 表示位置を計算
            Point pos = Cursor.Position;

            // はみ出したら、反転する
            if (IsProtrude(pos.X, dir.X, Width, inf.Width + margin))
                dir.X *= -1;
            if (IsProtrude(pos.Y, dir.Y, Height, inf.Height + margin))
                dir.Y *= -1;


            // 設定する
            location.X = pos.X + GetLocationFromPoint(dir.X, inf.Width,  margin);
            location.Y = pos.Y + GetLocationFromPoint(dir.Y, inf.Height, margin);


            inf.Location = location;  // 設定
        }

        private void SetLocation_SelectFunction()
        {
            int margin = 15;

            Range range = showRange.range;
            if (range == null) return;

            Point location = new Point();
            Direction dir = GetCursorDirection();


            // 表示位置を計算
            Point pos = new Point();
            Point opposite = new Point();

            pos.X      = (dir.X < 0) ? range.Left : range.Right;
            opposite.X = (dir.X > 0) ? range.Left : range.Right;
            pos.Y      = (dir.Y < 0) ? range.Top  : range.Bottom;
            opposite.Y = (dir.Y > 0) ? range.Top  : range.Bottom;


            // X方向の表示位置
            dir.X *= -1;
            if (IsProtrude(pos.X, dir.X, Width, selectFunction.Width))
            {
                dir.X *= -1;  // 方向の反転
                pos.X = opposite.X;  // 位置の反転
            }
            location.X = pos.X + GetLocationFromPoint(dir.X, selectFunction.Width);

            // Y方向の表示位置
            if (IsProtrude(pos.Y, dir.Y, Height, selectFunction.Height + margin))
            {
                dir.Y *= -1;  // 方向の反転
                // 反対の位置では、はみ出さない場合
                if (IsProtrude(opposite.Y, dir.Y, Height, selectFunction.Height + margin)
                    == false)
                {
                    // 位置の反転
                    int temp = pos.Y;
                    pos.Y = opposite.Y;
                    opposite.Y = temp;
                }
            }
            location.Y = pos.Y + GetLocationFromPoint(dir.Y, selectFunction.Height, margin);


            selectFunction.Location = location;  // 設定
        }

        /// <summary>
        /// 指定された位置から指定されたサイズで描画時に、<br />
        /// はみ出したかどうかを返す
        /// </summary>
        private bool IsProtrude(int pos, int dir, int max, int size)
        {
            int size_max;
            if (dir < 0)
                size_max = pos;
            else
                size_max = max - pos;


            return size_max < size;
        }

        /// <summary>
        /// 指定した座標から指定した方向に配置した場合の、フォームの位置を取得する
        /// </summary>
        private int GetLocationFromPoint(int dir, int size, int margin = 0)
        {
            if (dir < 0) return - (size + margin);
            else return margin;
        }

        /// <summary>
        /// 選択範囲のどの方向にカーソルがあるかを返す
        /// </summary>
        private Direction GetCursorDirection()
        {
            Range range = showRange.range;

            // 中心座標を計算
            Point center = new Point(range.Left + (range.Width / 2),
                                     range.Top + (range.Height / 2));
            Point cursor = Cursor.Position;

            // 中心座標のどちら側かで判断
            Direction direction = new Direction();
            direction.X = 1;
            if (cursor.X < center.X)
                direction.X *= -1;
            direction.Y = 1;
            if (cursor.Y < center.Y)
                direction.Y *= -1;

            return direction;
        }

        /// <summary>
        /// 設定を反映する
        /// </summary>
        private void ApplySetting()
        {
            inf.magnifier.Size = setting.magnifierSize;
            inf.magnifier.ZoomLevel = setting.zoomLevel;
        }




        // 機能
        private void SetFunction1()
        {
            List<Control> controls = new List<Control>();

            {
                ImageButton btn = new ImageButton(
                    GetIconResource("close.png"), "閉じる");
                btn.Click += delegate
                {
                    Close();
                };
                controls.Add(btn);
            }
            {
                ImageButton btn = new ImageButton(
                    GetIconResource("setting.png"), "設定");
                btn.Click += delegate
                {
                    SetSetting setSetting = new SetSetting(setting);
                    setSetting.ShowDialog(this);
                    ApplySetting();
                };
                controls.Add(btn);
            }
            {
                ImageButton btn = new ImageButton(
                    GetIconResource("gif.png"), "GIF");
                btn.Click += delegate
                {
                    Visible = false;
                    showRange.TopMost = true;
                    SetFunction2();
                };
                controls.Add(btn);
            }
            {
                ImageButton btn = new ImageButton(
                    GetIconResource("save.png"), "保存");
                btn.Click += delegate
                {
                    if (showRange.range == null) return;

                    // フォームが映らないようにする
                    Visible = false;
                    Refresh();
                    selectFunction.Visible = false;
                    selectFunction.Refresh();

                    // スクショ
                    Bitmap bitmap = GetScreen.PrtSc(showRange.range.Rect);

                    // 再表示
                    Visible = true;
                    Refresh();
                    selectFunction.Visible = true;
                    selectFunction.Refresh();

                    // ダイアログを表示
                    SaveFileDialog saveFile = new SaveFileDialog()
                    {
                        Title = "画像を保存",
                        Filter =
                            "PNG (*.png)|*.png|" +
                            "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
                            "GIF (*.gif)|*.gif|" +
                            "ビットマップ (*.bmp)|*.bmp|" +
                            "TIFF (*.tif;*.tiff)|*.tif;*.tiff|" +
                            "すべてのファイル (*.*)|*.*"
                    };

                    if (saveFile.ShowDialog(this) == DialogResult.OK)
                    {
                        bitmap.Save(saveFile.FileName);  // 保存
                        Close();
                    }
                };
                controls.Add(btn);
            }
            {
                ImageButton btn = new ImageButton(
                    GetIconResource("copy.png"), "コピー");
                btn.Click += delegate
                {
                    if (showRange.range == null) return;

                    // フォームが映らないようにする
                    Visible = false;
                    Refresh();
                    selectFunction.Visible = false;
                    selectFunction.Refresh();

                    // スクショ
                    Bitmap bitmap = GetScreen.PrtSc(showRange.range.Rect);

                    Clipboard.SetImage(bitmap);  // クリップボードに設定

                    Close();
                };
                controls.Add(btn);
            }
            selectFunction.SetControl(controls.ToArray());  // 反映
        }

        private void SetFunction2()
        {
            List<Control> controls = new List<Control>();

            {
                if (Directory.Exists(setting.tempFolder) == false)
                    Directory.CreateDirectory(setting.tempFolder);

                recordGif = new RecordGif(showRange.range.Rect, setting.fps);
                controls.Add(recordGif);
            }
            {
                ImageButton btn = new ImageButton(
                    GetIconResource("close.png"), "閉じる");
                btn.Click += delegate
                {
                    recordGif.Save();

                    if (File.Exists(setting.gifFilePath))
                        File.Delete(setting.gifFilePath);

                    Close();
                };
                controls.Add(btn);
            }
            {
                ImageButton btn = new ImageButton(
                    GetIconResource("stop.png"), "停止");
                btn.Click += delegate
                {
                    recordGif.Save();

                    if (recordGif.isEndRecord)
                        SetFunction3();
                };
                controls.Add(btn);
            }
            {
                ImageButton btn = new ImageButton(
                    GetIconResource("pause.png"), "一時停止");
                btn.Click += delegate
                {
                    recordGif.isPause = !recordGif.isPause;
                };
                controls.Add(btn);
            }
            {
                ImageButton btn = new ImageButton(
                    GetIconResource("start.png"), "新規録画");
                btn.Click += delegate
                {
                    recordGif.Record(setting.gifFilePath);
                };
                controls.Add(btn);
            }
            selectFunction.SetControl(controls.ToArray());  // 反映
        }

        private void SetFunction3()
        {
            List<Control> controls = new List<Control>();

            {
                ImageButton btn = new ImageButton(
                    GetIconResource("close.png"), "閉じる");
                btn.Click += delegate
                {
                    if (File.Exists(setting.gifFilePath))
                    File.Delete(setting.gifFilePath);
                    Close();
                };
                controls.Add(btn);
            }
            {
                ImageButton btn = new ImageButton(
                    GetIconResource("save.png"), "保存");
                btn.Click += delegate
                {
                    // ダイアログを表示
                    SaveFileDialog saveFile = new SaveFileDialog()
                    {
                        Title = "画像を保存",
                        Filter = 
                            "GIF (*.gif)|*.gif|" +
                            "すべてのファイル (*.*)|*.*"
                    };

                    if (saveFile.ShowDialog(this) == DialogResult.OK)
                    {
                        File.Move(setting.gifFilePath, saveFile.FileName);  // 保存
                        Close();
                    }
                };
                controls.Add(btn);
            }
            {
                ImageButton btn = new ImageButton(
                    GetIconResource("copy.png"), "コピー");
                btn.Click += delegate
                {
                    // クリップボードに設定
                    Clipboard.SetFileDropList(
                        new System.Collections.Specialized.StringCollection()
                        { Path.GetFullPath(setting.gifFilePath) });

                    Close();
                };
                controls.Add(btn);
            }
            selectFunction.SetControl(controls.ToArray());  // 反映
        }


        System.Reflection.Assembly assembly =
            System.Reflection.Assembly.GetExecutingAssembly();
        private Bitmap GetIconResource(string fileName)
        {
            var stream = assembly.GetManifestResourceStream("ScreenToImage.Icons." + fileName);
            return new Bitmap(stream);
        }
    }
}
