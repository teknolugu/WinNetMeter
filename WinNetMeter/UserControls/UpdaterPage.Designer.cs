namespace WinNetMeter.UserControls
{
    partial class UpdaterPage
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
            this.label5 = new System.Windows.Forms.Label();
            this.appUpdater1 = new WinNetMeter.UserControls.AppUpdater();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.BtnReset = new WinNetMeter.Components.ButtonEx();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(18, 19);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(195, 25);
            this.label5.TabIndex = 8;
            this.label5.Text = "Update and Recovery";
            // 
            // appUpdater1
            // 
            this.appUpdater1.AutoSize = true;
            this.appUpdater1.Location = new System.Drawing.Point(23, 64);
            this.appUpdater1.Name = "appUpdater1";
            this.appUpdater1.Size = new System.Drawing.Size(502, 115);
            this.appUpdater1.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(31, 229);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(492, 38);
            this.label2.TabIndex = 22;
            this.label2.Text = "All application settings will be reset to default including general, style, shell" +
    " data, etc.\r\nWindows Explorer process may will be restarted. Make sure there is " +
    "no file operation activity.";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.Control;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(30, 199);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 21);
            this.label1.TabIndex = 20;
            this.label1.Text = "Reset Settings";
            // 
            // BtnReset
            // 
            this.BtnReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnReset.Location = new System.Drawing.Point(34, 280);
            this.BtnReset.Name = "BtnReset";
            this.BtnReset.Size = new System.Drawing.Size(140, 34);
            this.BtnReset.TabIndex = 23;
            this.BtnReset.Text = "ResetSettings";
            this.BtnReset.UseVisualStyleBackColor = true;
            this.BtnReset.Click += new System.EventHandler(this.BtnReset_Click);
            // 
            // UpdaterPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.BtnReset);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.appUpdater1);
            this.Controls.Add(this.label5);
            this.Name = "UpdaterPage";
            this.Size = new System.Drawing.Size(541, 344);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label5;
        private AppUpdater appUpdater1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private Components.ButtonEx BtnReset;
    }
}
