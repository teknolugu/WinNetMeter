namespace WinNetMeter.UserControls.FirstRun
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
            this.LblStatus = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ToggleInstaller = new MetroFramework.Controls.MetroToggle();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // LblStatus
            // 
            this.LblStatus.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblStatus.Location = new System.Drawing.Point(148, 178);
            this.LblStatus.Name = "LblStatus";
            this.LblStatus.Size = new System.Drawing.Size(482, 36);
            this.LblStatus.TabIndex = 12;
            this.LblStatus.Text = "Install Toolbar";
            this.LblStatus.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::WinNetMeter.Properties.Resources.Chain_grey_180px;
            this.pictureBox1.Location = new System.Drawing.Point(278, 32);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(206, 129);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label2.Location = new System.Drawing.Point(176, 212);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(428, 70);
            this.label2.TabIndex = 13;
            this.label2.Text = "Switch the toggle ON to install the toolbar";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(191, 255);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 17);
            this.label1.TabIndex = 14;
            this.label1.Text = "Toolbar Integration";
            // 
            // ToggleInstaller
            // 
            this.ToggleInstaller.AutoSize = true;
            this.ToggleInstaller.Location = new System.Drawing.Point(503, 255);
            this.ToggleInstaller.Name = "ToggleInstaller";
            this.ToggleInstaller.Size = new System.Drawing.Size(80, 17);
            this.ToggleInstaller.TabIndex = 15;
            this.ToggleInstaller.Text = "Off";
            this.ToggleInstaller.UseSelectable = true;
            this.ToggleInstaller.CheckedChanged += new System.EventHandler(this.ToggleInstaller_CheckedChanged);
            // 
            // StartPage5
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ToggleInstaller);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.LblStatus);
            this.Controls.Add(this.pictureBox1);
            this.Name = "StartPage5";
            this.Size = new System.Drawing.Size(819, 510);
            this.Load += new System.EventHandler(this.StartPage5_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label LblStatus;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private MetroFramework.Controls.MetroToggle ToggleInstaller;
    }
}
