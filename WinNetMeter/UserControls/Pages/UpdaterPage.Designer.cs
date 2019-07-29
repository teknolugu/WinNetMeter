using WinNetMeter.UserControls.Controls;

namespace WinNetMeter.UserControls.Pages
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.appUpdater1 = new WinNetMeter.UserControls.Controls.AppUpdater();
            this.BtnReset = new WinNetMeter.Components.ButtonEx();
            this.panel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(8, 40);
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
            this.label1.Location = new System.Drawing.Point(8, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 21);
            this.label1.TabIndex = 20;
            this.label1.Text = "Reset Settings";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.BtnReset);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(3, 136);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(511, 162);
            this.panel1.TabIndex = 24;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.appUpdater1);
            this.flowLayoutPanel1.Controls.Add(this.panel1);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(13, 3);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(523, 316);
            this.flowLayoutPanel1.TabIndex = 25;
            // 
            // appUpdater1
            // 
            this.appUpdater1.Location = new System.Drawing.Point(3, 3);
            this.appUpdater1.Name = "appUpdater1";
            this.appUpdater1.Size = new System.Drawing.Size(511, 127);
            this.appUpdater1.TabIndex = 9;
            // 
            // BtnReset
            // 
            this.BtnReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnReset.Location = new System.Drawing.Point(14, 91);
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
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "UpdaterPage";
            this.Size = new System.Drawing.Size(555, 344);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private AppUpdater appUpdater1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private Components.ButtonEx BtnReset;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
    }
}
