namespace WinNetMeter.UserControls.Controls
{
    partial class AppUpdater
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
            this.Title = new System.Windows.Forms.Label();
            this.Description = new System.Windows.Forms.Label();
            this.BtnCheckUpdates = new System.Windows.Forms.Button();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.Changelog = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // Title
            // 
            this.Title.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Title.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Title.ForeColor = System.Drawing.Color.Black;
            this.Title.Location = new System.Drawing.Point(6, 6);
            this.Title.Name = "Title";
            this.Title.Size = new System.Drawing.Size(238, 20);
            this.Title.TabIndex = 0;
            this.Title.Text = "Check for Updates";
            // 
            // Description
            // 
            this.Description.AutoSize = true;
            this.Description.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Description.Location = new System.Drawing.Point(8, 35);
            this.Description.Name = "Description";
            this.Description.Size = new System.Drawing.Size(90, 13);
            this.Description.TabIndex = 1;
            this.Description.Text = "Get new version";
            // 
            // BtnCheckUpdates
            // 
            this.BtnCheckUpdates.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BtnCheckUpdates.BackColor = System.Drawing.SystemColors.Highlight;
            this.BtnCheckUpdates.FlatAppearance.BorderSize = 0;
            this.BtnCheckUpdates.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnCheckUpdates.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCheckUpdates.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.BtnCheckUpdates.Location = new System.Drawing.Point(5, 119);
            this.BtnCheckUpdates.Name = "BtnCheckUpdates";
            this.BtnCheckUpdates.Size = new System.Drawing.Size(117, 28);
            this.BtnCheckUpdates.TabIndex = 34;
            this.BtnCheckUpdates.Text = "Check for Updates";
            this.BtnCheckUpdates.UseVisualStyleBackColor = false;
            this.BtnCheckUpdates.Click += new System.EventHandler(this.BtnCheckUpdates_Click);
            // 
            // BtnCancel
            // 
            this.BtnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BtnCancel.FlatAppearance.BorderColor = System.Drawing.SystemColors.Highlight;
            this.BtnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnCancel.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCancel.ForeColor = System.Drawing.SystemColors.Highlight;
            this.BtnCancel.Location = new System.Drawing.Point(128, 119);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(116, 26);
            this.BtnCancel.TabIndex = 35;
            this.BtnCancel.Text = "Cancel Update";
            this.BtnCancel.UseVisualStyleBackColor = true;
            this.BtnCancel.Visible = false;
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // Changelog
            // 
            this.Changelog.AutoSize = true;
            this.Changelog.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Changelog.Location = new System.Drawing.Point(8, 52);
            this.Changelog.Name = "Changelog";
            this.Changelog.Size = new System.Drawing.Size(90, 13);
            this.Changelog.TabIndex = 36;
            this.Changelog.TabStop = true;
            this.Changelog.Text = "View changelog";
            this.Changelog.Visible = false;
            this.Changelog.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.Changelog_LinkClicked);
            // 
            // AppUpdater
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.Changelog);
            this.Controls.Add(this.BtnCancel);
            this.Controls.Add(this.BtnCheckUpdates);
            this.Controls.Add(this.Description);
            this.Controls.Add(this.Title);
            this.Name = "AppUpdater";
            this.Size = new System.Drawing.Size(250, 150);
            this.Load += new System.EventHandler(this.AppUpdater_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Title;
        private System.Windows.Forms.Label Description;
        private System.Windows.Forms.Button BtnCheckUpdates;
        private System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.LinkLabel Changelog;
    }
}
