using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using WinNetMeter.Helper;
using WinNetMeter.Model;

namespace WinNetMeter
{
    public partial class Main : Form
    {
        private RegistryManager registryManager = new RegistryManager();

        public Main()
        {
            InitializeComponent();
            panel1.Width = 240;
            NetworkIntefaceModule netModule = new NetworkIntefaceModule();
            var adapters = netModule.GetNetworkInterface();
            foreach (String adapter in adapters)
            {
                ListAdapter.Items.Add(adapter);
            }

            //set to default value
            comboBoxFormat.SelectedItem = "Auto";
            comboBoxLanguage.SelectedItem = "English";
            if (ListAdapter.Items != null)
            {
                ListAdapter.SelectedIndex = 0;
            }

            foreach (FontFamily font in FontFamily.Families)
            {
                ComboboxFont.Items.Add(font.Name);
            }

            LoadSettings();
            try
            {
                if (ComboboxFont.Items.Contains("")) ComboboxFont.Items.Remove("");
            }
            catch { }
        }

        #region custom

        private void BtnGeneral_Click(object sender, EventArgs e)
        {
            PnlSelector.Location = new Point(0, BtnGeneral.Location.Y);
            setSelected(BtnGeneral, BtnCustomization, BtnDatabase, BtnAbout);
            tabControl1.SelectedTab = tabPage1;
        }

        private void BtnCustomization_Click(object sender, EventArgs e)
        {
            PnlSelector.Location = new Point(0, BtnCustomization.Location.Y);
            setSelected(BtnCustomization, BtnGeneral, BtnDatabase, BtnAbout);
            tabControl1.SelectedTab = tabPage2;
        }

        private void setSelected(Button selectedBtn, Button btn1, Button btn2, Button btn3)
        {
            selectedBtn.BackColor = ColorTranslator.FromHtml("#F0F0F0");
            btn1.BackColor = Color.Transparent;
            btn2.BackColor = Color.Transparent;
            btn3.BackColor = Color.Transparent;
        }

        private void BtnDatabase_Click(object sender, EventArgs e)
        {
            PnlSelector.Location = new Point(0, BtnDatabase.Location.Y);
            setSelected(BtnDatabase, BtnGeneral, BtnCustomization, BtnAbout);
            tabControl1.SelectedTab = tabPage3;
        }

        #endregion custom

        private void LoadSettings()
        {
            try
            {
                #region GeneralConfiguration

                //Get app configuration
                var configuration = registryManager.GetGeneralConfiguration();

                //set configuration
                ToggleMonitor.Checked = (configuration.Monitoring) ? true : false;
                ToggleAutoUpdate.Checked = (configuration.AutoUpdate) ? true : false;

                if (configuration.Format != null)
                {
                    comboBoxFormat.SelectedItem = configuration.Format;
                }

                if (configuration.Language == Language.English)
                {
                    comboBoxLanguage.SelectedItem = "English";
                }
                else
                {
                    comboBoxLanguage.SelectedItem = "Indonesian";
                }

                toggleTraffic.Checked = (configuration.TrafficLogging) ? true : false;

                if (configuration.TrafficLogging == true && configuration.CustomLogLocation != null)
                {
                    txtLogPath.Text = configuration.CustomLogLocation;
                }
                else
                {
                    txtLogPath.Text = AppDomain.CurrentDomain.BaseDirectory + @"Temp\log.db";
                }

                if (configuration.MonitoredAdapter != null && ListAdapter.Items.Contains(configuration.MonitoredAdapter))
                {
                    ListAdapter.SelectedItem = configuration.MonitoredAdapter;
                }

                #endregion GeneralConfiguration
            }
            catch { goto DbConfig; }

        DbConfig:
            try
            {
                #region DatabaseConfiguration

                var dbConfig = registryManager.GetDatabaseConfiguration();
                toggleTraffic.Checked = dbConfig.TrafficLogging;
                txtLogPath.Text = dbConfig.CustomLogLocation;

                #endregion DatabaseConfiguration
            }
            catch { goto StyleConfig; }

        StyleConfig:
            try
            {
                #region StyleConfiguration

                var styleConfig = registryManager.GetStyleConfiguration();
                colorGrid1.Color = ColorTranslator.FromHtml(styleConfig.TextColor);
                ComboboxFont.SelectedItem = styleConfig.FontFamily;
                if (styleConfig.Icon == IconStyle.Arrow) radioPictArrow.Checked = true;
                else if (styleConfig.Icon == IconStyle.TriangleArrow) radioPictTriangleArrow.Checked = true;
                else if (styleConfig.Icon == IconStyle.Outline_Arrow) radioPictOutline.Checked = true;

                #endregion StyleConfiguration
            }
            catch { }
        }

        private void ToggleTraffic_CheckedChanged(object sender, EventArgs e)
        {
            bool check = (toggleTraffic.Checked) ? groupBox1.Enabled = true : groupBox1.Enabled = false;
        }

        private void BtnSaveGeneral_Click(object sender, EventArgs e)
        {
            if (ListAdapter.SelectedItem == null) MessageBox.Show(this, "You have not chosen the network inteface", "Oopss!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (comboBoxLanguage.SelectedItem == null || comboBoxLanguage.SelectedItem == null) MessageBox.Show(this, "You have not chosen something", "Oopss!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                Configuration config = new Configuration
                {
                    Monitoring = ToggleMonitor.Checked,
                    AutoUpdate = ToggleAutoUpdate.Checked,
                    Language = (Language)Enum.Parse(typeof(Language), comboBoxLanguage.SelectedItem.ToString()),
                    Format = comboBoxFormat.SelectedItem.ToString(),
                    TrafficLogging = toggleTraffic.Checked,
                    MonitoredAdapter = ListAdapter.SelectedItem.ToString(),
                    CustomLogLocation = null
                };
                //save the settings
                registryManager.Save(config);
                MessageBox.Show(this, "Settings saved successfully", "Saved!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BtnSaveLog_Click(object sender, EventArgs e)
        {
            DatabaseConfiguration databaseConfiguration = new DatabaseConfiguration { TrafficLogging = toggleTraffic.Checked };
            if (toggleTraffic.Checked == true && txtLogPath.Text == "")
            {
                MessageBox.Show(this, "You have not set Log path", "Oopss!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (txtLogPath.Text != null && toggleTraffic.Checked == true)
                {
                    databaseConfiguration.CustomLogLocation = txtLogPath.Text;
                }
                else databaseConfiguration.CustomLogLocation = "Not available";
                registryManager.Save(databaseConfiguration);
                MessageBox.Show(this, "Settings saved successfully", "Saved!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BtnBrowseLog_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK) txtLogPath.Text = folderBrowserDialog.SelectedPath + @"Temp\log.db";
        }

        private void LinkDefaultLoc_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            txtLogPath.Text = AppDomain.CurrentDomain.BaseDirectory + @"Temp\log.db";
        }

        private void BtnSaveStyle_Click(object sender, EventArgs e)
        {
            if (ComboboxFont.SelectedItem != null)
            {
                StyleConfiguration styleConfiguration = new StyleConfiguration
                {
                    TextColor = ColorTranslator.ToHtml(colorGrid1.Color),
                    FontFamily = ComboboxFont.SelectedItem.ToString(),
                };

                if (radioPictArrow.Checked == true) styleConfiguration.Icon = IconStyle.Arrow;
                else if (radioPictTriangleArrow.Checked == true) styleConfiguration.Icon = IconStyle.TriangleArrow;
                else if (radioPictOutline.Checked == true) styleConfiguration.Icon = IconStyle.Outline_Arrow;

                registryManager.Save(styleConfiguration);
                MessageBox.Show(this, "Settings saved successfully", "Saved!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(this, "You have not chosen font style", "Oopss!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void KillWindowsExplorer()
        {
            foreach (var process in Process.GetProcessesByName("explorer"))
            {
                process.Kill();
            }
        }

        private void Main_Load(object sender, EventArgs e)
        {
        }

        private void BtnIntegrate_Click(object sender, EventArgs e)
        {
            PnlSelector.Location = new Point(0, BtnDatabase.Location.Y);
            setSelected(BtnDatabase, BtnGeneral, BtnCustomization, BtnAbout);
            tabControl1.SelectedTab = tabPage4;
        }

        private void BtnRegister_Click(object sender, EventArgs e)
        {
            try
            {
                Integration integration = new Integration();
                integration.ReinstallToolbar();
                MessageBox.Show("Re-Register .dll Successfully.", "WinNetMeter Integration");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Something happened. {ex.Message}", "WinNetMeter Integration");
            }
        }
    }
}