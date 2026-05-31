namespace ScreenToImage.Setting
{
    partial class SetSetting
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txt_tempFolder = new System.Windows.Forms.TextBox();
            this.num_zoomLevel = new System.Windows.Forms.NumericUpDown();
            this.num_magnifierWidth = new System.Windows.Forms.NumericUpDown();
            this.num_magnifierHeight = new System.Windows.Forms.NumericUpDown();
            this.num_fps = new System.Windows.Forms.NumericUpDown();
            this.txt_gifFileName = new System.Windows.Forms.TextBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lbl_tempFolder = new System.Windows.Forms.Label();
            this.lbl_magnifier = new System.Windows.Forms.Label();
            this.lbl_zoomLevel = new System.Windows.Forms.Label();
            this.lbl_screenSize = new System.Windows.Forms.Label();
            this.lbl_magnifierWidth = new System.Windows.Forms.Label();
            this.lbl_magnifierHeight = new System.Windows.Forms.Label();
            this.lbl_gif = new System.Windows.Forms.Label();
            this.lbl_fps = new System.Windows.Forms.Label();
            this.lbl_gifFileName = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.num_zoomLevel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_magnifierWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_magnifierHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_fps)).BeginInit();
            this.SuspendLayout();
            // 
            // txt_tempFolder
            // 
            this.txt_tempFolder.Font = new System.Drawing.Font("メイリオ", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txt_tempFolder.Location = new System.Drawing.Point(259, 351);
            this.txt_tempFolder.Name = "txt_tempFolder";
            this.txt_tempFolder.Size = new System.Drawing.Size(484, 32);
            this.txt_tempFolder.TabIndex = 0;
            // 
            // num_zoomLevel
            // 
            this.num_zoomLevel.Font = new System.Drawing.Font("メイリオ", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.num_zoomLevel.Location = new System.Drawing.Point(259, 52);
            this.num_zoomLevel.Maximum = new decimal(new int[] {
            64,
            0,
            0,
            0});
            this.num_zoomLevel.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.num_zoomLevel.Name = "num_zoomLevel";
            this.num_zoomLevel.Size = new System.Drawing.Size(120, 32);
            this.num_zoomLevel.TabIndex = 1;
            this.num_zoomLevel.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // num_magnifierWidth
            // 
            this.num_magnifierWidth.Font = new System.Drawing.Font("メイリオ", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.num_magnifierWidth.Location = new System.Drawing.Point(259, 120);
            this.num_magnifierWidth.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.num_magnifierWidth.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.num_magnifierWidth.Name = "num_magnifierWidth";
            this.num_magnifierWidth.Size = new System.Drawing.Size(120, 32);
            this.num_magnifierWidth.TabIndex = 2;
            this.num_magnifierWidth.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // num_magnifierHeight
            // 
            this.num_magnifierHeight.Font = new System.Drawing.Font("メイリオ", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.num_magnifierHeight.Location = new System.Drawing.Point(259, 158);
            this.num_magnifierHeight.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.num_magnifierHeight.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.num_magnifierHeight.Name = "num_magnifierHeight";
            this.num_magnifierHeight.Size = new System.Drawing.Size(120, 32);
            this.num_magnifierHeight.TabIndex = 3;
            this.num_magnifierHeight.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // num_fps
            // 
            this.num_fps.Font = new System.Drawing.Font("メイリオ", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.num_fps.Location = new System.Drawing.Point(259, 265);
            this.num_fps.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.num_fps.Name = "num_fps";
            this.num_fps.Size = new System.Drawing.Size(120, 32);
            this.num_fps.TabIndex = 4;
            this.num_fps.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // txt_gifFileName
            // 
            this.txt_gifFileName.Font = new System.Drawing.Font("メイリオ", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txt_gifFileName.Location = new System.Drawing.Point(259, 308);
            this.txt_gifFileName.Name = "txt_gifFileName";
            this.txt_gifFileName.Size = new System.Drawing.Size(484, 32);
            this.txt_gifFileName.TabIndex = 5;
            // 
            // btnOk
            // 
            this.btnOk.Font = new System.Drawing.Font("メイリオ", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnOk.Location = new System.Drawing.Point(540, 418);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(121, 37);
            this.btnOk.TabIndex = 6;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("メイリオ", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnCancel.Location = new System.Drawing.Point(667, 418);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(121, 37);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "キャンセル";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lbl_tempFolder
            // 
            this.lbl_tempFolder.AutoSize = true;
            this.lbl_tempFolder.Font = new System.Drawing.Font("メイリオ", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lbl_tempFolder.Location = new System.Drawing.Point(37, 353);
            this.lbl_tempFolder.Name = "lbl_tempFolder";
            this.lbl_tempFolder.Size = new System.Drawing.Size(139, 28);
            this.lbl_tempFolder.TabIndex = 8;
            this.lbl_tempFolder.Text = "Tempフォルダ";
            // 
            // lbl_magnifier
            // 
            this.lbl_magnifier.AutoSize = true;
            this.lbl_magnifier.Font = new System.Drawing.Font("メイリオ", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lbl_magnifier.Location = new System.Drawing.Point(20, 20);
            this.lbl_magnifier.Name = "lbl_magnifier";
            this.lbl_magnifier.Size = new System.Drawing.Size(107, 28);
            this.lbl_magnifier.TabIndex = 9;
            this.lbl_magnifier.Text = "拡大鏡設定";
            // 
            // lbl_zoomLevel
            // 
            this.lbl_zoomLevel.AutoSize = true;
            this.lbl_zoomLevel.Font = new System.Drawing.Font("メイリオ", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lbl_zoomLevel.Location = new System.Drawing.Point(37, 53);
            this.lbl_zoomLevel.Name = "lbl_zoomLevel";
            this.lbl_zoomLevel.Size = new System.Drawing.Size(69, 28);
            this.lbl_zoomLevel.TabIndex = 10;
            this.lbl_zoomLevel.Text = "拡大率";
            // 
            // lbl_screenSize
            // 
            this.lbl_screenSize.AutoSize = true;
            this.lbl_screenSize.Font = new System.Drawing.Font("メイリオ", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lbl_screenSize.Location = new System.Drawing.Point(37, 94);
            this.lbl_screenSize.Name = "lbl_screenSize";
            this.lbl_screenSize.Size = new System.Drawing.Size(126, 28);
            this.lbl_screenSize.TabIndex = 11;
            this.lbl_screenSize.Text = "拡大鏡サイズ";
            // 
            // lbl_magnifierWidth
            // 
            this.lbl_magnifierWidth.AutoSize = true;
            this.lbl_magnifierWidth.Font = new System.Drawing.Font("メイリオ", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lbl_magnifierWidth.Location = new System.Drawing.Point(203, 121);
            this.lbl_magnifierWidth.Name = "lbl_magnifierWidth";
            this.lbl_magnifierWidth.Size = new System.Drawing.Size(31, 28);
            this.lbl_magnifierWidth.TabIndex = 12;
            this.lbl_magnifierWidth.Text = "幅";
            // 
            // lbl_magnifierHeight
            // 
            this.lbl_magnifierHeight.AutoSize = true;
            this.lbl_magnifierHeight.Font = new System.Drawing.Font("メイリオ", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lbl_magnifierHeight.Location = new System.Drawing.Point(203, 159);
            this.lbl_magnifierHeight.Name = "lbl_magnifierHeight";
            this.lbl_magnifierHeight.Size = new System.Drawing.Size(50, 28);
            this.lbl_magnifierHeight.TabIndex = 13;
            this.lbl_magnifierHeight.Text = "高さ";
            // 
            // lbl_gif
            // 
            this.lbl_gif.AutoSize = true;
            this.lbl_gif.Font = new System.Drawing.Font("メイリオ", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lbl_gif.Location = new System.Drawing.Point(20, 236);
            this.lbl_gif.Name = "lbl_gif";
            this.lbl_gif.Size = new System.Drawing.Size(87, 28);
            this.lbl_gif.TabIndex = 14;
            this.lbl_gif.Text = "GIF設定";
            // 
            // lbl_fps
            // 
            this.lbl_fps.AutoSize = true;
            this.lbl_fps.Font = new System.Drawing.Font("メイリオ", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lbl_fps.Location = new System.Drawing.Point(37, 269);
            this.lbl_fps.Name = "lbl_fps";
            this.lbl_fps.Size = new System.Drawing.Size(46, 28);
            this.lbl_fps.TabIndex = 15;
            this.lbl_fps.Text = "FPS";
            // 
            // lbl_gifFileName
            // 
            this.lbl_gifFileName.AutoSize = true;
            this.lbl_gifFileName.Font = new System.Drawing.Font("メイリオ", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lbl_gifFileName.Location = new System.Drawing.Point(37, 310);
            this.lbl_gifFileName.Name = "lbl_gifFileName";
            this.lbl_gifFileName.Size = new System.Drawing.Size(140, 28);
            this.lbl_gifFileName.TabIndex = 16;
            this.lbl_gifFileName.Text = "GIFファイル名";
            // 
            // SetSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 467);
            this.Controls.Add(this.lbl_gifFileName);
            this.Controls.Add(this.lbl_fps);
            this.Controls.Add(this.lbl_gif);
            this.Controls.Add(this.lbl_magnifierHeight);
            this.Controls.Add(this.lbl_magnifierWidth);
            this.Controls.Add(this.lbl_screenSize);
            this.Controls.Add(this.lbl_zoomLevel);
            this.Controls.Add(this.lbl_magnifier);
            this.Controls.Add(this.lbl_tempFolder);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.txt_gifFileName);
            this.Controls.Add(this.num_fps);
            this.Controls.Add(this.num_magnifierHeight);
            this.Controls.Add(this.num_magnifierWidth);
            this.Controls.Add(this.num_zoomLevel);
            this.Controls.Add(this.txt_tempFolder);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SetSetting";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "設定";
            ((System.ComponentModel.ISupportInitialize)(this.num_zoomLevel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_magnifierWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_magnifierHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_fps)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_tempFolder;
        private System.Windows.Forms.NumericUpDown num_zoomLevel;
        private System.Windows.Forms.NumericUpDown num_magnifierWidth;
        private System.Windows.Forms.NumericUpDown num_magnifierHeight;
        private System.Windows.Forms.NumericUpDown num_fps;
        private System.Windows.Forms.TextBox txt_gifFileName;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lbl_tempFolder;
        private System.Windows.Forms.Label lbl_magnifier;
        private System.Windows.Forms.Label lbl_zoomLevel;
        private System.Windows.Forms.Label lbl_screenSize;
        private System.Windows.Forms.Label lbl_magnifierWidth;
        private System.Windows.Forms.Label lbl_magnifierHeight;
        private System.Windows.Forms.Label lbl_gif;
        private System.Windows.Forms.Label lbl_fps;
        private System.Windows.Forms.Label lbl_gifFileName;
    }
}