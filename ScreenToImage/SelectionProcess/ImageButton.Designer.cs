namespace ScreenToImage.SelectionProcess
{
    partial class ImageButton
    {
        /// <summary> 
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region コンポーネント デザイナーで生成されたコード

        /// <summary> 
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を 
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pic_Image = new System.Windows.Forms.PictureBox();
            this.pic_Hover = new System.Windows.Forms.PictureBox();
            this.description = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pic_Image)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_Hover)).BeginInit();
            this.SuspendLayout();
            // 
            // pic_Image
            // 
            this.pic_Image.BackColor = System.Drawing.Color.Transparent;
            this.pic_Image.Location = new System.Drawing.Point(17, 15);
            this.pic_Image.Name = "pic_Image";
            this.pic_Image.Size = new System.Drawing.Size(318, 275);
            this.pic_Image.TabIndex = 0;
            this.pic_Image.TabStop = false;
            // 
            // pic_Hover
            // 
            this.pic_Hover.BackColor = System.Drawing.Color.Transparent;
            this.pic_Hover.Location = new System.Drawing.Point(51, 43);
            this.pic_Hover.Name = "pic_Hover";
            this.pic_Hover.Size = new System.Drawing.Size(218, 188);
            this.pic_Hover.TabIndex = 1;
            this.pic_Hover.TabStop = false;
            this.pic_Hover.Click += new System.EventHandler(this.pic_Hover_Click);
            this.pic_Hover.MouseEnter += new System.EventHandler(this.pic_Hover_MouseEnter);
            this.pic_Hover.MouseLeave += new System.EventHandler(this.pic_Hover_MouseLeave);
            // 
            // description
            // 
            this.description.AutoPopDelay = 50000;
            this.description.InitialDelay = 1;
            this.description.ReshowDelay = 1;
            // 
            // ImageButton
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.pic_Hover);
            this.Controls.Add(this.pic_Image);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Name = "ImageButton";
            this.Size = new System.Drawing.Size(397, 354);
            ((System.ComponentModel.ISupportInitialize)(this.pic_Image)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_Hover)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pic_Image;
        private System.Windows.Forms.PictureBox pic_Hover;
        private System.Windows.Forms.ToolTip description;
    }
}
