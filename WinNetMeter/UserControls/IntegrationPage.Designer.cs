namespace WinNetMeter.UserControls
{
    partial class IntegrationPage
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
            this.lineShape4 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.shapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.label12 = new System.Windows.Forms.Label();
            this.lineShape7 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.label21 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.BtnUninstall = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.BtnRegister = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lineShape4
            // 
            this.lineShape4.BorderColor = System.Drawing.SystemColors.ControlLight;
            this.lineShape4.Name = "lineShape4";
            this.lineShape4.X1 = 10;
            this.lineShape4.X2 = 10;
            this.lineShape4.Y1 = 3;
            this.lineShape4.Y2 = 482;
            // 
            // shapeContainer1
            // 
            this.shapeContainer1.Location = new System.Drawing.Point(0, 0);
            this.shapeContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.shapeContainer1.Name = "shapeContainer1";
            this.shapeContainer1.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
            this.lineShape7,
            this.lineShape4});
            this.shapeContainer1.Size = new System.Drawing.Size(568, 485);
            this.shapeContainer1.TabIndex = 0;
            this.shapeContainer1.TabStop = false;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(29, 17);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(108, 25);
            this.label12.TabIndex = 45;
            this.label12.Text = "Integration";
            // 
            // lineShape7
            // 
            this.lineShape7.BorderColor = System.Drawing.SystemColors.Control;
            this.lineShape7.Name = "lineShape7";
            this.lineShape7.X1 = 21;
            this.lineShape7.X2 = 559;
            this.lineShape7.Y1 = 60;
            this.lineShape7.Y2 = 60;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.label21.Location = new System.Drawing.Point(31, 249);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(135, 25);
            this.label21.TabIndex = 51;
            this.label21.Text = "Uninstall Shell";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.label17.Location = new System.Drawing.Point(31, 71);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(163, 25);
            this.label17.TabIndex = 50;
            this.label17.Text = "Re-Register Shell";
            // 
            // BtnUninstall
            // 
            this.BtnUninstall.Location = new System.Drawing.Point(354, 343);
            this.BtnUninstall.Name = "BtnUninstall";
            this.BtnUninstall.Size = new System.Drawing.Size(135, 40);
            this.BtnUninstall.TabIndex = 49;
            this.BtnUninstall.Text = "Uninstall Shell";
            this.BtnUninstall.UseVisualStyleBackColor = true;
            this.BtnUninstall.Click += new System.EventHandler(this.BtnUninstall_Click);
            // 
            // label13
            // 
            this.label13.Location = new System.Drawing.Point(33, 274);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(408, 35);
            this.label13.TabIndex = 48;
            this.label13.Text = "If you want update or uninstall WinNetMeter, you can Uninstall Shell before, \r\nth" +
    "en replace with new Version.";
            // 
            // label18
            // 
            this.label18.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(31, 101);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(410, 62);
            this.label18.TabIndex = 47;
            this.label18.Text = "If WinNetMeter is not working properly on the TaskBar, \r\nYou can try Re-Register " +
    "Shell. Before click Re-Register, please\r\nremove WinNetMeter from toolbar on the " +
    "TaskBar for better troubleshooting";
            // 
            // BtnRegister
            // 
            this.BtnRegister.Location = new System.Drawing.Point(354, 197);
            this.BtnRegister.Name = "BtnRegister";
            this.BtnRegister.Size = new System.Drawing.Size(135, 40);
            this.BtnRegister.TabIndex = 46;
            this.BtnRegister.Text = "Re-Register Shell";
            this.BtnRegister.UseVisualStyleBackColor = true;
            this.BtnRegister.Click += new System.EventHandler(this.BtnRegister_Click);
            // 
            // Integration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Controls.Add(this.label21);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.BtnUninstall);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.BtnRegister);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.shapeContainer1);
            this.Name = "Integration";
            this.Size = new System.Drawing.Size(568, 485);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.VisualBasic.PowerPacks.LineShape lineShape4;
        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer1;
        private System.Windows.Forms.Label label12;
        private Microsoft.VisualBasic.PowerPacks.LineShape lineShape7;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Button BtnUninstall;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Button BtnRegister;
    }
}
