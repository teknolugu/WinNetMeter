namespace WinNetMeter.UserControls
{
    partial class Log
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
            this.label11 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.linkDefaultLoc = new System.Windows.Forms.LinkLabel();
            this.txtLogPath = new System.Windows.Forms.TextBox();
            this.btnBrowseLog = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.toggleTraffic = new MetroFramework.Controls.MetroToggle();
            this.lineShape1 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.shapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.lineShape4 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.btnSaveLog = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(33, 19);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(167, 25);
            this.label11.TabIndex = 13;
            this.label11.Text = "Log Configuration";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.linkDefaultLoc);
            this.groupBox1.Controls.Add(this.txtLogPath);
            this.groupBox1.Controls.Add(this.btnBrowseLog);
            this.groupBox1.Location = new System.Drawing.Point(38, 124);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(498, 110);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Log location";
            // 
            // linkDefaultLoc
            // 
            this.linkDefaultLoc.AutoSize = true;
            this.linkDefaultLoc.Location = new System.Drawing.Point(10, 81);
            this.linkDefaultLoc.Name = "linkDefaultLoc";
            this.linkDefaultLoc.Size = new System.Drawing.Size(110, 13);
            this.linkDefaultLoc.TabIndex = 10;
            this.linkDefaultLoc.TabStop = true;
            this.linkDefaultLoc.Text = "Set to default location";
            // 
            // txtLogPath
            // 
            this.txtLogPath.Location = new System.Drawing.Point(13, 43);
            this.txtLogPath.Name = "txtLogPath";
            this.txtLogPath.Size = new System.Drawing.Size(391, 20);
            this.txtLogPath.TabIndex = 8;
            // 
            // btnBrowseLog
            // 
            this.btnBrowseLog.Location = new System.Drawing.Point(410, 41);
            this.btnBrowseLog.Name = "btnBrowseLog";
            this.btnBrowseLog.Size = new System.Drawing.Size(75, 23);
            this.btnBrowseLog.TabIndex = 9;
            this.btnBrowseLog.Text = "...";
            this.btnBrowseLog.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(35, 82);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(66, 17);
            this.label9.TabIndex = 16;
            this.label9.Text = "Traffic log";
            // 
            // toggleTraffic
            // 
            this.toggleTraffic.AutoSize = true;
            this.toggleTraffic.Checked = true;
            this.toggleTraffic.CheckState = System.Windows.Forms.CheckState.Checked;
            this.toggleTraffic.Enabled = false;
            this.toggleTraffic.Location = new System.Drawing.Point(456, 82);
            this.toggleTraffic.Name = "toggleTraffic";
            this.toggleTraffic.Size = new System.Drawing.Size(80, 17);
            this.toggleTraffic.TabIndex = 15;
            this.toggleTraffic.Text = "On";
            this.toggleTraffic.UseSelectable = true;
            this.toggleTraffic.CheckedChanged += new System.EventHandler(this.ToggleTraffic_CheckedChanged);
            // 
            // lineShape1
            // 
            this.lineShape1.BorderColor = System.Drawing.SystemColors.Control;
            this.lineShape1.Name = "lineShape1";
            this.lineShape1.X1 = 21;
            this.lineShape1.X2 = 559;
            this.lineShape1.Y1 = 60;
            this.lineShape1.Y2 = 60;
            // 
            // shapeContainer1
            // 
            this.shapeContainer1.Location = new System.Drawing.Point(0, 0);
            this.shapeContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.shapeContainer1.Name = "shapeContainer1";
            this.shapeContainer1.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
            this.lineShape4,
            this.lineShape1});
            this.shapeContainer1.Size = new System.Drawing.Size(568, 485);
            this.shapeContainer1.TabIndex = 19;
            this.shapeContainer1.TabStop = false;
            // 
            // lineShape4
            // 
            this.lineShape4.BorderColor = System.Drawing.SystemColors.ControlLight;
            this.lineShape4.Name = "lineShape4";
            this.lineShape4.X1 = 13;
            this.lineShape4.X2 = 13;
            this.lineShape4.Y1 = 3;
            this.lineShape4.Y2 = 482;
            // 
            // btnSaveLog
            // 
            this.btnSaveLog.BackColor = System.Drawing.Color.Transparent;
            this.btnSaveLog.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnSaveLog.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveLog.ForeColor = System.Drawing.Color.Black;
            this.btnSaveLog.Image = global::WinNetMeter.Properties.Resources.Checked_outline_16px;
            this.btnSaveLog.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSaveLog.Location = new System.Drawing.Point(414, 441);
            this.btnSaveLog.Name = "btnSaveLog";
            this.btnSaveLog.Size = new System.Drawing.Size(121, 33);
            this.btnSaveLog.TabIndex = 18;
            this.btnSaveLog.Text = "  Save";
            this.btnSaveLog.UseVisualStyleBackColor = false;
            this.btnSaveLog.Click += new System.EventHandler(this.BtnSaveLog_Click);
            // 
            // Log
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Controls.Add(this.btnSaveLog);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.toggleTraffic);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.shapeContainer1);
            this.Name = "Log";
            this.Size = new System.Drawing.Size(568, 485);
            this.Load += new System.EventHandler(this.Log_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnSaveLog;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.LinkLabel linkDefaultLoc;
        private System.Windows.Forms.TextBox txtLogPath;
        private System.Windows.Forms.Button btnBrowseLog;
        private System.Windows.Forms.Label label9;
        private MetroFramework.Controls.MetroToggle toggleTraffic;
        private Microsoft.VisualBasic.PowerPacks.LineShape lineShape1;
        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer1;
        private Microsoft.VisualBasic.PowerPacks.LineShape lineShape4;
    }
}
