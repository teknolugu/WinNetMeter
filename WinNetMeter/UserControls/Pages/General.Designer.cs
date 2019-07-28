namespace WinNetMeter.UserControls.Pages
{
    partial class General
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
            this.label26 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.ListAdapter = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ToggleMonitor = new MetroFramework.Controls.MetroToggle();
            this.ToggleAutoUpdate = new MetroFramework.Controls.MetroToggle();
            this.btnSaveGeneral = new System.Windows.Forms.Button();
            this.metroComboBox3 = new MetroFramework.Controls.MetroComboBox();
            this.cmbFormat = new MetroFramework.Controls.MetroComboBox();
            this.radioIndonesia = new MetroFramework.Controls.MetroRadioButton();
            this.radioEnglish = new MetroFramework.Controls.MetroRadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.Location = new System.Drawing.Point(25, 142);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(137, 17);
            this.label26.TabIndex = 14;
            this.label26.Text = "Server Update Stream";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(24, 11);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 17);
            this.label4.TabIndex = 5;
            this.label4.Text = "Monitoring";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(25, 98);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(49, 17);
            this.label7.TabIndex = 9;
            this.label7.Text = "Format";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(24, 53);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(187, 17);
            this.label6.TabIndex = 8;
            this.label6.Text = "Automatically check for update";
            // 
            // ListAdapter
            // 
            this.ListAdapter.BackColor = System.Drawing.SystemColors.Control;
            this.ListAdapter.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ListAdapter.CausesValidation = false;
            this.ListAdapter.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ListAdapter.FormattingEnabled = true;
            this.ListAdapter.ItemHeight = 15;
            this.ListAdapter.Location = new System.Drawing.Point(29, 274);
            this.ListAdapter.Name = "ListAdapter";
            this.ListAdapter.Size = new System.Drawing.Size(510, 90);
            this.ListAdapter.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label3.Location = new System.Drawing.Point(26, 238);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(143, 21);
            this.label3.TabIndex = 3;
            this.label3.Text = "Network Interface";
            // 
            // ToggleMonitor
            // 
            this.ToggleMonitor.AutoSize = true;
            this.ToggleMonitor.Location = new System.Drawing.Point(439, 11);
            this.ToggleMonitor.Name = "ToggleMonitor";
            this.ToggleMonitor.Size = new System.Drawing.Size(80, 17);
            this.ToggleMonitor.TabIndex = 4;
            this.ToggleMonitor.Text = "Off";
            this.ToggleMonitor.UseSelectable = true;
            // 
            // ToggleAutoUpdate
            // 
            this.ToggleAutoUpdate.AutoSize = true;
            this.ToggleAutoUpdate.Location = new System.Drawing.Point(439, 53);
            this.ToggleAutoUpdate.Name = "ToggleAutoUpdate";
            this.ToggleAutoUpdate.Size = new System.Drawing.Size(80, 17);
            this.ToggleAutoUpdate.TabIndex = 7;
            this.ToggleAutoUpdate.Text = "Off";
            this.ToggleAutoUpdate.UseSelectable = true;
            // 
            // btnSaveGeneral
            // 
            this.btnSaveGeneral.BackColor = System.Drawing.Color.Transparent;
            this.btnSaveGeneral.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnSaveGeneral.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveGeneral.ForeColor = System.Drawing.Color.Black;
            this.btnSaveGeneral.Image = global::WinNetMeter.Properties.Resources.Checked_outline_16px;
            this.btnSaveGeneral.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSaveGeneral.Location = new System.Drawing.Point(418, 376);
            this.btnSaveGeneral.Name = "btnSaveGeneral";
            this.btnSaveGeneral.Size = new System.Drawing.Size(121, 33);
            this.btnSaveGeneral.TabIndex = 16;
            this.btnSaveGeneral.Text = "  Save";
            this.btnSaveGeneral.UseVisualStyleBackColor = false;
            this.btnSaveGeneral.Click += new System.EventHandler(this.BtnSaveGeneral_Click);
            // 
            // metroComboBox3
            // 
            this.metroComboBox3.Enabled = false;
            this.metroComboBox3.FormattingEnabled = true;
            this.metroComboBox3.ItemHeight = 23;
            this.metroComboBox3.Location = new System.Drawing.Point(337, 137);
            this.metroComboBox3.Name = "metroComboBox3";
            this.metroComboBox3.Size = new System.Drawing.Size(182, 29);
            this.metroComboBox3.TabIndex = 21;
            this.metroComboBox3.UseSelectable = true;
            // 
            // cmbFormat
            // 
            this.cmbFormat.FormattingEnabled = true;
            this.cmbFormat.ItemHeight = 23;
            this.cmbFormat.Items.AddRange(new object[] {
            "Auto",
            "KB",
            "MB"});
            this.cmbFormat.Location = new System.Drawing.Point(337, 90);
            this.cmbFormat.Name = "cmbFormat";
            this.cmbFormat.Size = new System.Drawing.Size(182, 29);
            this.cmbFormat.TabIndex = 19;
            this.cmbFormat.UseSelectable = true;
            // 
            // radioIndonesia
            // 
            this.radioIndonesia.AutoSize = true;
            this.radioIndonesia.Enabled = false;
            this.radioIndonesia.Location = new System.Drawing.Point(438, 189);
            this.radioIndonesia.Name = "radioIndonesia";
            this.radioIndonesia.Size = new System.Drawing.Size(81, 15);
            this.radioIndonesia.TabIndex = 23;
            this.radioIndonesia.Text = "Indonesian";
            this.radioIndonesia.UseSelectable = true;
            // 
            // radioEnglish
            // 
            this.radioEnglish.AutoSize = true;
            this.radioEnglish.Location = new System.Drawing.Point(337, 189);
            this.radioEnglish.Name = "radioEnglish";
            this.radioEnglish.Size = new System.Drawing.Size(61, 15);
            this.radioEnglish.TabIndex = 24;
            this.radioEnglish.Text = "English";
            this.radioEnglish.UseSelectable = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(27, 184);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 17);
            this.label1.TabIndex = 25;
            this.label1.Text = "Language";
            // 
            // General
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.radioEnglish);
            this.Controls.Add(this.radioIndonesia);
            this.Controls.Add(this.metroComboBox3);
            this.Controls.Add(this.cmbFormat);
            this.Controls.Add(this.label26);
            this.Controls.Add(this.btnSaveGeneral);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.ListAdapter);
            this.Controls.Add(this.ToggleAutoUpdate);
            this.Controls.Add(this.ToggleMonitor);
            this.Controls.Add(this.label3);
            this.Name = "General";
            this.Size = new System.Drawing.Size(560, 420);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ListBox ListAdapter;
        private System.Windows.Forms.Label label3;
        private MetroFramework.Controls.MetroToggle ToggleMonitor;
        private MetroFramework.Controls.MetroToggle ToggleAutoUpdate;
        private System.Windows.Forms.Button btnSaveGeneral;
        private MetroFramework.Controls.MetroComboBox metroComboBox3;
        private MetroFramework.Controls.MetroComboBox cmbFormat;
        private MetroFramework.Controls.MetroRadioButton radioIndonesia;
        private MetroFramework.Controls.MetroRadioButton radioEnglish;
        private System.Windows.Forms.Label label1;
    }
}
