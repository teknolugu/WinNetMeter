namespace WinNetMeter.Shell
{
    partial class UserControl1
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pictDownload = new System.Windows.Forms.PictureBox();
            this.pictUpload = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.LblUpload = new WinNetMeter.Shell.MyLabel();
            this.LblDownload = new WinNetMeter.Shell.MyLabel();
            ((System.ComponentModel.ISupportInitialize)(this.pictDownload)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictUpload)).BeginInit();
            this.SuspendLayout();
            // 
            // pictDownload
            // 
            this.pictDownload.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.pictDownload.Image = global::WinNetMeter.Shell.Properties.Resources.down_white_16px;
            this.pictDownload.Location = new System.Drawing.Point(3, 15);
            this.pictDownload.Name = "pictDownload";
            this.pictDownload.Size = new System.Drawing.Size(12, 15);
            this.pictDownload.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictDownload.TabIndex = 2;
            this.pictDownload.TabStop = false;
            // 
            // pictUpload
            // 
            this.pictUpload.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.pictUpload.Image = global::WinNetMeter.Shell.Properties.Resources.up_white_16px;
            this.pictUpload.Location = new System.Drawing.Point(3, 2);
            this.pictUpload.Name = "pictUpload";
            this.pictUpload.Size = new System.Drawing.Size(12, 15);
            this.pictUpload.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictUpload.TabIndex = 3;
            this.pictUpload.TabStop = false;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // LblUpload
            // 
            this.LblUpload.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblUpload.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.LblUpload.Location = new System.Drawing.Point(30, 0);
            this.LblUpload.Name = "LblUpload";
            this.LblUpload.Size = new System.Drawing.Size(68, 12);
            this.LblUpload.TabIndex = 5;
            this.LblUpload.Text = "......";
            this.LblUpload.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.LblUpload.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
            // 
            // LblDownload
            // 
            this.LblDownload.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblDownload.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.LblDownload.Location = new System.Drawing.Point(30, 15);
            this.LblDownload.Name = "LblDownload";
            this.LblDownload.Size = new System.Drawing.Size(68, 12);
            this.LblDownload.TabIndex = 6;
            this.LblDownload.Text = "......";
            this.LblDownload.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.LblDownload.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
            // 
            // UserControl1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.Black;
            this.Controls.Add(this.LblDownload);
            this.Controls.Add(this.LblUpload);
            this.Controls.Add(this.pictUpload);
            this.Controls.Add(this.pictDownload);
            this.Name = "UserControl1";
            this.Size = new System.Drawing.Size(101, 33);
            this.Load += new System.EventHandler(this.UserControl1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictDownload)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictUpload)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox pictDownload;
        private System.Windows.Forms.PictureBox pictUpload;
        private System.Windows.Forms.Timer timer1;
        private MyLabel LblUpload;
        private MyLabel LblDownload;
    }
}
