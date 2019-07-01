namespace WinNetMeter.Page
{
    partial class StartPage5
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
            this.progressInstaller = new System.Windows.Forms.ProgressBar();
            this.LblStatus = new System.Windows.Forms.Label();
            this.LabelProgressStatus = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // progressInstaller
            // 
            this.progressInstaller.Location = new System.Drawing.Point(40, 365);
            this.progressInstaller.Name = "progressInstaller";
            this.progressInstaller.Size = new System.Drawing.Size(744, 23);
            this.progressInstaller.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressInstaller.TabIndex = 10;
            // 
            // LblStatus
            // 
            this.LblStatus.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblStatus.Location = new System.Drawing.Point(130, 177);
            this.LblStatus.Name = "LblStatus";
            this.LblStatus.Size = new System.Drawing.Size(502, 36);
            this.LblStatus.TabIndex = 12;
            this.LblStatus.Text = "Finalizing setup";
            this.LblStatus.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // LabelProgressStatus
            // 
            this.LabelProgressStatus.AutoSize = true;
            this.LabelProgressStatus.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelProgressStatus.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.LabelProgressStatus.Location = new System.Drawing.Point(37, 340);
            this.LabelProgressStatus.Name = "LabelProgressStatus";
            this.LabelProgressStatus.Size = new System.Drawing.Size(78, 17);
            this.LabelProgressStatus.TabIndex = 13;
            this.LabelProgressStatus.Text = "Please wait..";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::WinNetMeter.Properties.Resources.refresh_192px;
            this.pictureBox1.Location = new System.Drawing.Point(278, 32);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(206, 129);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            // 
            // StartPage5
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.LabelProgressStatus);
            this.Controls.Add(this.LblStatus);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.progressInstaller);
            this.Name = "StartPage5";
            this.Size = new System.Drawing.Size(819, 510);
            this.Load += new System.EventHandler(this.StartPage5_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ProgressBar progressInstaller;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label LblStatus;
        private System.Windows.Forms.Label LabelProgressStatus;
    }
}
