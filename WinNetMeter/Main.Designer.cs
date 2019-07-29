using WinNetMeter.UserControls.Pages;

namespace WinNetMeter
{
    partial class Main
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.PanelMainMenu = new System.Windows.Forms.Panel();
            this.LineAboutSeparator = new System.Windows.Forms.GroupBox();
            this.LineVertikal = new System.Windows.Forms.Label();
            this.btnUpdateRecovery = new System.Windows.Forms.Button();
            this.BtnIntegrate = new System.Windows.Forms.Button();
            this.BtnAbout = new System.Windows.Forms.Button();
            this.BtnDatabase = new System.Windows.Forms.Button();
            this.BtnCustomization = new System.Windows.Forms.Button();
            this.BtnGeneral = new System.Windows.Forms.Button();
            this.PnlSelector = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.general = new WinNetMeter.UserControls.Pages.General();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.log = new WinNetMeter.UserControls.Pages.Log();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.customize = new WinNetMeter.UserControls.Pages.Customize();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.integrationPage = new WinNetMeter.UserControls.Pages.IntegrationPage();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.about = new WinNetMeter.UserControls.Pages.About();
            this.tabUpdateRecovery = new System.Windows.Forms.TabPage();
            this.updaterPage1 = new WinNetMeter.UserControls.Pages.UpdaterPage();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.colorSelector = new System.Windows.Forms.ColorDialog();
            this.panel2 = new System.Windows.Forms.Panel();
            this.LblTitlePages = new System.Windows.Forms.Label();
            this.PanelMainMenu.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.tabUpdateRecovery.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // PanelMainMenu
            // 
            this.PanelMainMenu.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.PanelMainMenu.Controls.Add(this.LineAboutSeparator);
            this.PanelMainMenu.Controls.Add(this.LineVertikal);
            this.PanelMainMenu.Controls.Add(this.btnUpdateRecovery);
            this.PanelMainMenu.Controls.Add(this.BtnIntegrate);
            this.PanelMainMenu.Controls.Add(this.BtnAbout);
            this.PanelMainMenu.Controls.Add(this.BtnDatabase);
            this.PanelMainMenu.Controls.Add(this.BtnCustomization);
            this.PanelMainMenu.Controls.Add(this.BtnGeneral);
            this.PanelMainMenu.Controls.Add(this.PnlSelector);
            this.PanelMainMenu.Controls.Add(this.label2);
            this.PanelMainMenu.Controls.Add(this.label1);
            this.PanelMainMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.PanelMainMenu.Location = new System.Drawing.Point(0, 0);
            this.PanelMainMenu.Name = "PanelMainMenu";
            this.PanelMainMenu.Size = new System.Drawing.Size(200, 483);
            this.PanelMainMenu.TabIndex = 0;
            // 
            // LineAboutSeparator
            // 
            this.LineAboutSeparator.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LineAboutSeparator.Location = new System.Drawing.Point(9, 425);
            this.LineAboutSeparator.Name = "LineAboutSeparator";
            this.LineAboutSeparator.Size = new System.Drawing.Size(176, 2);
            this.LineAboutSeparator.TabIndex = 10;
            this.LineAboutSeparator.TabStop = false;
            // 
            // LineVertikal
            // 
            this.LineVertikal.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LineVertikal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.LineVertikal.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.LineVertikal.Location = new System.Drawing.Point(193, 5);
            this.LineVertikal.Name = "LineVertikal";
            this.LineVertikal.Size = new System.Drawing.Size(2, 471);
            this.LineVertikal.TabIndex = 9;
            this.LineVertikal.Text = "label3";
            // 
            // btnUpdateRecovery
            // 
            this.btnUpdateRecovery.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnUpdateRecovery.FlatAppearance.BorderSize = 0;
            this.btnUpdateRecovery.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdateRecovery.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdateRecovery.Image = global::WinNetMeter.Properties.Resources.refresh_darkgrey_16px;
            this.btnUpdateRecovery.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUpdateRecovery.Location = new System.Drawing.Point(3, 289);
            this.btnUpdateRecovery.Name = "btnUpdateRecovery";
            this.btnUpdateRecovery.Size = new System.Drawing.Size(235, 46);
            this.btnUpdateRecovery.TabIndex = 8;
            this.btnUpdateRecovery.Text = "          Update and Recovery";
            this.btnUpdateRecovery.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUpdateRecovery.UseVisualStyleBackColor = false;
            this.btnUpdateRecovery.Click += new System.EventHandler(this.BtnUpdateRecovery_Click);
            // 
            // BtnIntegrate
            // 
            this.BtnIntegrate.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.BtnIntegrate.FlatAppearance.BorderSize = 0;
            this.BtnIntegrate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnIntegrate.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnIntegrate.Image = global::WinNetMeter.Properties.Resources.Chain_filled_16px;
            this.BtnIntegrate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnIntegrate.Location = new System.Drawing.Point(3, 237);
            this.BtnIntegrate.Name = "BtnIntegrate";
            this.BtnIntegrate.Size = new System.Drawing.Size(235, 46);
            this.BtnIntegrate.TabIndex = 7;
            this.BtnIntegrate.Text = "          Integration";
            this.BtnIntegrate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnIntegrate.UseVisualStyleBackColor = false;
            this.BtnIntegrate.Click += new System.EventHandler(this.BtnIntegrate_Click);
            // 
            // BtnAbout
            // 
            this.BtnAbout.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.BtnAbout.FlatAppearance.BorderSize = 0;
            this.BtnAbout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnAbout.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAbout.Image = global::WinNetMeter.Properties.Resources.About_flat_16px;
            this.BtnAbout.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnAbout.Location = new System.Drawing.Point(3, 429);
            this.BtnAbout.Name = "BtnAbout";
            this.BtnAbout.Size = new System.Drawing.Size(235, 46);
            this.BtnAbout.TabIndex = 6;
            this.BtnAbout.Text = "          About";
            this.BtnAbout.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnAbout.UseVisualStyleBackColor = false;
            this.BtnAbout.Click += new System.EventHandler(this.BtnAbout_Click);
            // 
            // BtnDatabase
            // 
            this.BtnDatabase.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.BtnDatabase.FlatAppearance.BorderSize = 0;
            this.BtnDatabase.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnDatabase.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnDatabase.Image = global::WinNetMeter.Properties.Resources.Database_filled_16px;
            this.BtnDatabase.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnDatabase.Location = new System.Drawing.Point(3, 185);
            this.BtnDatabase.Name = "BtnDatabase";
            this.BtnDatabase.Size = new System.Drawing.Size(235, 46);
            this.BtnDatabase.TabIndex = 4;
            this.BtnDatabase.Text = "          Database";
            this.BtnDatabase.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnDatabase.UseVisualStyleBackColor = false;
            this.BtnDatabase.Click += new System.EventHandler(this.BtnDatabase_Click);
            // 
            // BtnCustomization
            // 
            this.BtnCustomization.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.BtnCustomization.FlatAppearance.BorderSize = 0;
            this.BtnCustomization.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnCustomization.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCustomization.Image = global::WinNetMeter.Properties.Resources.Brush_filled_16px;
            this.BtnCustomization.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnCustomization.Location = new System.Drawing.Point(3, 133);
            this.BtnCustomization.Name = "BtnCustomization";
            this.BtnCustomization.Size = new System.Drawing.Size(235, 46);
            this.BtnCustomization.TabIndex = 3;
            this.BtnCustomization.Text = "          Customization";
            this.BtnCustomization.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnCustomization.UseVisualStyleBackColor = false;
            this.BtnCustomization.Click += new System.EventHandler(this.BtnCustomization_Click);
            // 
            // BtnGeneral
            // 
            this.BtnGeneral.BackColor = System.Drawing.SystemColors.Control;
            this.BtnGeneral.FlatAppearance.BorderSize = 0;
            this.BtnGeneral.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnGeneral.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnGeneral.Image = global::WinNetMeter.Properties.Resources.Settings_colored_16px;
            this.BtnGeneral.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnGeneral.Location = new System.Drawing.Point(3, 81);
            this.BtnGeneral.Name = "BtnGeneral";
            this.BtnGeneral.Size = new System.Drawing.Size(235, 46);
            this.BtnGeneral.TabIndex = 1;
            this.BtnGeneral.Text = "          General";
            this.BtnGeneral.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnGeneral.UseVisualStyleBackColor = false;
            this.BtnGeneral.Click += new System.EventHandler(this.BtnGeneral_Click);
            // 
            // PnlSelector
            // 
            this.PnlSelector.BackColor = System.Drawing.SystemColors.Highlight;
            this.PnlSelector.Location = new System.Drawing.Point(0, 81);
            this.PnlSelector.Name = "PnlSelector";
            this.PnlSelector.Size = new System.Drawing.Size(5, 46);
            this.PnlSelector.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semilight", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label2.Location = new System.Drawing.Point(14, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(193, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Realtime Network Speed Monitor";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semilight", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(136, 30);
            this.label1.TabIndex = 1;
            this.label1.Text = "WinNetMeter";
            // 
            // tabControl1
            // 
            this.tabControl1.Alignment = System.Windows.Forms.TabAlignment.Left;
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Controls.Add(this.tabUpdateRecovery);
            this.tabControl1.Location = new System.Drawing.Point(204, 50);
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(595, 438);
            this.tabControl1.TabIndex = 14;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.general);
            this.tabPage1.Location = new System.Drawing.Point(23, 4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(568, 430);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "General";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // general
            // 
            this.general.BackColor = System.Drawing.Color.White;
            this.general.Dock = System.Windows.Forms.DockStyle.Fill;
            this.general.Location = new System.Drawing.Point(3, 3);
            this.general.Name = "general";
            this.general.Size = new System.Drawing.Size(562, 424);
            this.general.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.log);
            this.tabPage3.Location = new System.Drawing.Point(23, 4);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(568, 430);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Log";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // log
            // 
            this.log.BackColor = System.Drawing.Color.White;
            this.log.Dock = System.Windows.Forms.DockStyle.Fill;
            this.log.Location = new System.Drawing.Point(0, 0);
            this.log.Name = "log";
            this.log.Size = new System.Drawing.Size(568, 430);
            this.log.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.customize);
            this.tabPage2.Location = new System.Drawing.Point(23, 4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(568, 430);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Customize";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // customize
            // 
            this.customize.BackColor = System.Drawing.Color.White;
            this.customize.Dock = System.Windows.Forms.DockStyle.Fill;
            this.customize.Location = new System.Drawing.Point(3, 3);
            this.customize.Name = "customize";
            this.customize.Size = new System.Drawing.Size(562, 424);
            this.customize.TabIndex = 0;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.integrationPage);
            this.tabPage4.Location = new System.Drawing.Point(23, 4);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(568, 430);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Integration";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // integrationPage
            // 
            this.integrationPage.BackColor = System.Drawing.Color.White;
            this.integrationPage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.integrationPage.Location = new System.Drawing.Point(3, 3);
            this.integrationPage.Name = "integrationPage";
            this.integrationPage.Size = new System.Drawing.Size(562, 424);
            this.integrationPage.TabIndex = 0;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.about);
            this.tabPage5.Location = new System.Drawing.Point(23, 4);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Size = new System.Drawing.Size(568, 430);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "About";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // about
            // 
            this.about.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.about.Dock = System.Windows.Forms.DockStyle.Fill;
            this.about.Location = new System.Drawing.Point(0, 0);
            this.about.Name = "about";
            this.about.Size = new System.Drawing.Size(568, 430);
            this.about.TabIndex = 0;
            // 
            // tabUpdateRecovery
            // 
            this.tabUpdateRecovery.Controls.Add(this.updaterPage1);
            this.tabUpdateRecovery.Location = new System.Drawing.Point(23, 4);
            this.tabUpdateRecovery.Name = "tabUpdateRecovery";
            this.tabUpdateRecovery.Padding = new System.Windows.Forms.Padding(3);
            this.tabUpdateRecovery.Size = new System.Drawing.Size(568, 430);
            this.tabUpdateRecovery.TabIndex = 5;
            this.tabUpdateRecovery.Text = "tabUpdate";
            this.tabUpdateRecovery.UseVisualStyleBackColor = true;
            // 
            // updaterPage1
            // 
            this.updaterPage1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.updaterPage1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.updaterPage1.Location = new System.Drawing.Point(3, 3);
            this.updaterPage1.Name = "updaterPage1";
            this.updaterPage1.Size = new System.Drawing.Size(562, 424);
            this.updaterPage1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.LblTitlePages);
            this.panel2.Location = new System.Drawing.Point(246, 9);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(548, 46);
            this.panel2.TabIndex = 15;
            // 
            // LblTitlePages
            // 
            this.LblTitlePages.AutoSize = true;
            this.LblTitlePages.Font = new System.Drawing.Font("Segoe UI Light", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTitlePages.Location = new System.Drawing.Point(3, 3);
            this.LblTitlePages.Name = "LblTitlePages";
            this.LblTitlePages.Size = new System.Drawing.Size(105, 37);
            this.LblTitlePages.TabIndex = 0;
            this.LblTitlePages.Text = "General";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(794, 483);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.PanelMainMenu);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(810, 522);
            this.MinimumSize = new System.Drawing.Size(810, 522);
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "WinNetMeter";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Main_FormClosed);
            this.Load += new System.EventHandler(this.Main_Load);
            this.PanelMainMenu.ResumeLayout(false);
            this.PanelMainMenu.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.tabPage5.ResumeLayout(false);
            this.tabUpdateRecovery.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private IntegrationPage integrationPage;
        private Customize customize;
        private Log log;
        private General general;
        private About about;
        private System.Windows.Forms.Panel PanelMainMenu;
        private System.Windows.Forms.Panel PnlSelector;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BtnGeneral;
        private System.Windows.Forms.Button BtnCustomization;
        private System.Windows.Forms.Button BtnDatabase;
        private System.Windows.Forms.Button BtnAbout;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ColorDialog colorSelector;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.TabPage tabUpdateRecovery;
        private UpdaterPage updaterPage1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label LblTitlePages;
        private System.Windows.Forms.Label LineVertikal;
        private System.Windows.Forms.Button btnUpdateRecovery;
        private System.Windows.Forms.Button BtnIntegrate;
        private System.Windows.Forms.GroupBox LineAboutSeparator;
    }
}

