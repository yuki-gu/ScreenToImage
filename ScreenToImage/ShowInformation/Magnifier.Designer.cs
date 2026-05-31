namespace ScreenToImage.ShowInformation
{
    partial class Magnifier
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
            this.pic_Screen = new System.Windows.Forms.PictureBox();
            this.pic_cross = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pic_Screen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_cross)).BeginInit();
            this.SuspendLayout();
            // 
            // pic_Screen
            // 
            this.pic_Screen.Location = new System.Drawing.Point(46, 50);
            this.pic_Screen.Name = "pic_Screen";
            this.pic_Screen.Size = new System.Drawing.Size(325, 227);
            this.pic_Screen.TabIndex = 1;
            this.pic_Screen.TabStop = false;
            // 
            // pic_cross
            // 
            this.pic_cross.BackColor = System.Drawing.Color.Transparent;
            this.pic_cross.Location = new System.Drawing.Point(76, 81);
            this.pic_cross.Name = "pic_cross";
            this.pic_cross.Size = new System.Drawing.Size(197, 141);
            this.pic_cross.TabIndex = 2;
            this.pic_cross.TabStop = false;
            // 
            // Magnifier
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(512, 369);
            this.Controls.Add(this.pic_cross);
            this.Controls.Add(this.pic_Screen);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Magnifier";
            this.ShowInTaskbar = false;
            this.Text = "Magnifier";
            this.Resize += new System.EventHandler(this.Magnifier_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.pic_Screen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_cross)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pic_Screen;
        private System.Windows.Forms.PictureBox pic_cross;
    }
}