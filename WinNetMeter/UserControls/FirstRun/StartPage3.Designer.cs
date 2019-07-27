namespace WinNetMeter.UserControls.FirstRun
{
    partial class StartPage3
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
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.listAdapter = new System.Windows.Forms.ListBox();
            this.lblDetecting = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(92, 176);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(589, 36);
            this.label1.TabIndex = 2;
            this.label1.Text = "Select Network adapter";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::WinNetMeter.Properties.Resources.router_180px;
            this.pictureBox1.Location = new System.Drawing.Point(277, 32);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(206, 129);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // listAdapter
            // 
            this.listAdapter.BackColor = System.Drawing.SystemColors.Control;
            this.listAdapter.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listAdapter.Enabled = false;
            this.listAdapter.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listAdapter.FormattingEnabled = true;
            this.listAdapter.ItemHeight = 15;
            this.listAdapter.Location = new System.Drawing.Point(201, 234);
            this.listAdapter.Name = "listAdapter";
            this.listAdapter.Size = new System.Drawing.Size(384, 150);
            this.listAdapter.TabIndex = 4;
            this.listAdapter.SelectedIndexChanged += new System.EventHandler(this.ListAdapter_SelectedIndexChanged);
            // 
            // lblDetecting
            // 
            this.lblDetecting.AutoSize = true;
            this.lblDetecting.BackColor = System.Drawing.Color.Transparent;
            this.lblDetecting.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDetecting.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblDetecting.Location = new System.Drawing.Point(259, 296);
            this.lblDetecting.Name = "lblDetecting";
            this.lblDetecting.Size = new System.Drawing.Size(253, 17);
            this.lblDetecting.TabIndex = 6;
            this.lblDetecting.Text = "Detecting network adapter, please wait...";
            this.lblDetecting.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // StartPage3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblDetecting);
            this.Controls.Add(this.listAdapter);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Name = "StartPage3";
            this.Size = new System.Drawing.Size(819, 510);
            this.Load += new System.EventHandler(this.StartPage3_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ListBox listAdapter;
        private System.Windows.Forms.Label lblDetecting;
    }
}
