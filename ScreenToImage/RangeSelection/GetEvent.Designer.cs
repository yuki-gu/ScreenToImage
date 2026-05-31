namespace ScreenToImage.RangeSelection
{
    partial class GetEvent
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
            this.SuspendLayout();
            // 
            // GetEvent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Cursor = System.Windows.Forms.Cursors.Cross;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "GetEvent";
            this.Text = "GetEvent";
            this.TopMost = true;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.GetEvent_FormClosed);
            this.Load += new System.EventHandler(this.GetEvent_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.GetEvent_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.GetEvent_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.GetEvent_MouseUp);
            this.ResumeLayout(false);

        }

        #endregion
    }
}