namespace WinNetMeter.Page
{
    partial class StartPage4
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
            this.label2 = new System.Windows.Forms.Label();
            this.checkJoinDevelopment = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(92, 176);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(589, 36);
            this.label1.TabIndex = 4;
            this.label1.Text = "Join our development!";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::WinNetMeter.Properties.Resources.Join_our_development_256px;
            this.pictureBox1.Location = new System.Drawing.Point(278, 32);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(206, 129);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label2.Location = new System.Drawing.Point(176, 212);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(428, 70);
            this.label2.TabIndex = 6;
            this.label2.Text = "Help us to improve our apps, Let\'s build something great together.";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // checkJoinDevelopment
            // 
            this.checkJoinDevelopment.AutoSize = true;
            this.checkJoinDevelopment.BackColor = System.Drawing.Color.Transparent;
            this.checkJoinDevelopment.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkJoinDevelopment.Location = new System.Drawing.Point(296, 358);
            this.checkJoinDevelopment.Name = "checkJoinDevelopment";
            this.checkJoinDevelopment.Size = new System.Drawing.Size(150, 21);
            this.checkJoinDevelopment.TabIndex = 8;
            this.checkJoinDevelopment.Text = "I want to participate";
            this.checkJoinDevelopment.UseVisualStyleBackColor = false;
            this.checkJoinDevelopment.CheckedChanged += new System.EventHandler(this.CheckJoinDevelopment_CheckedChanged);
            // 
            // StartPage4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.checkJoinDevelopment);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Name = "StartPage4";
            this.Size = new System.Drawing.Size(819, 510);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox checkJoinDevelopment;
    }
}
