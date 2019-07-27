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
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.BtnReset = new WinNetMeter.Components.ButtonEx();
            this.appUpdater1 = new WinNetMeter.UserControls.AppUpdater();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(27, 175);
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
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(20, 145);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 21);
            this.label1.TabIndex = 20;
            this.label1.Text = "Reset Settings";
            // 
            // BtnReset
            // 
            this.BtnReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnReset.Location = new System.Drawing.Point(31, 226);
            this.BtnReset.Name = "BtnReset";
            this.BtnReset.Size = new System.Drawing.Size(140, 34);
            this.BtnReset.TabIndex = 23;
            this.BtnReset.Text = "ResetSettings";
            this.BtnReset.UseVisualStyleBackColor = true;
            this.BtnReset.Click += new System.EventHandler(this.BtnReset_Click);
            // 
            // appUpdater1
            // 
            this.appUpdater1.AutoSize = true;
            this.appUpdater1.Location = new System.Drawing.Point(20, 10);
            this.appUpdater1.Name = "appUpdater1";
            this.appUpdater1.Size = new System.Drawing.Size(502, 115);
            this.appUpdater1.TabIndex = 9;
            // 
            // UpdaterPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Controls.Add(this.BtnReset);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.appUpdater1);
            this.Name = "UpdaterPage";
            this.Size = new System.Drawing.Size(541, 344);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private AppUpdater appUpdater1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private Components.ButtonEx BtnReset;
    }
}
