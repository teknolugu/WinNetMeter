using System;
using System.Collections.Generic;
using System.Windows.Forms;
using WinNetMeter.Core.Helper;
using WinNetMeter.Core.Model;
using WinNetMeter.Core.Services;

namespace WinNetMeter.UserControls.Pages
{
    public partial class Log : UserControl
    {
        private RegistryManager registryManager = new RegistryManager();

        public Log()
        {
            InitializeComponent();

            #region DatabaseConfiguration

            var dbConfig = registryManager.GetDatabaseConfiguration();
            toggleTraffic.Checked = dbConfig.TrafficLogging;
            txtLogPath.Text = dbConfig.CustomLogLocation;

            #endregion DatabaseConfiguration
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

        private void ToggleTraffic_CheckedChanged(object sender, EventArgs e)
        {
            bool check = (toggleTraffic.Checked) ? groupBox1.Enabled = true : groupBox1.Enabled = false;
        }

        private void Log_Load(object sender, EventArgs e)
        {
        }

        private void BtnTestHit_Click(object sender, EventArgs e)
        {
            //var data = new Dictionary<string, string>()
            //{
            //    {"date", DateTime.Now.ToShortDateString() },
            //    {"time", DateTime.Now.ToShortTimeString() },
            //    {"download", "1024" },
            //    {"upload", "768" }
            //};

            //TrafficLogs.Save(data);

            EventLog.WriteLog("Test log");
        }
    }
}