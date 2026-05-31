namespace ScreenToImage.RangeSelection
{
    partial class ShowRange
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
            this.pic_range = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pic_range)).BeginInit();
            this.SuspendLayout();
            // 
            // pic_range
            // 
            this.pic_range.Location = new System.Drawing.Point(37, 27);
            this.pic_range.Name = "pic_range";
            this.pic_range.Size = new System.Drawing.Size(308, 233);
            this.pic_range.TabIndex = 0;
            this.pic_range.TabStop = false;
            // 
            // ShowRange
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pic_range);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ShowRange";
            this.ShowInTaskbar = false;
            this.Text = "ShowRange";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.ShowRange_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pic_range)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pic_range;
    }
}