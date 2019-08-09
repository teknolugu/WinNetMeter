using System;
using System.Linq;
using System.Windows.Forms;
using WinNetMeter.Core.Helper;
using WinNetMeter.Core.Model;

namespace WinNetMeter.UserControls.Pages
{
    public partial class General : UserControl
    {
        private RegistryManager registryManager = new RegistryManager();

        public General()
        {
            InitializeComponent();

            NetworkIntefaceModule netModule = new NetworkIntefaceModule();
            var adapters = netModule.GetNetworkInterface();
            foreach (String adapter in adapters)
            {
                ListAdapter.Items.Add(adapter);
            }

            //Set to default value
            cmbFormat.SelectedItem = "Auto";
            radioEnglish.Checked = true;
            if (ListAdapter.Items != null)
            {
                ListAdapter.SelectedIndex = 0;
            }

            if (EnvironmentHelper.IsUwpApp())
            {
                ToggleAutoUpdate.Checked = false;
                ToggleAutoUpdate.Enabled = false;
                label6.Text += " (Disabled)";
            }

            #region LoadConfiguration

            //Get app configuration
            var configuration = registryManager.GetGeneralConfiguration();

            //set configuration
            ToggleMonitor.Checked = (configuration.Monitoring) ? true : false;
            ToggleAutoUpdate.Checked = (configuration.AutoUpdate) ? true : false;

            if (configuration.Format != null)
            {
                cmbFormat.SelectedItem = configuration.Format;
            }

            if (configuration.Language == Language.English)
            {
                radioEnglish.Checked = true;
            }
            else
            {
                radioIndonesia.Checked = true;
            }

            if (configuration.MonitoredAdapter != null && ListAdapter.Items.Contains(configuration.MonitoredAdapter))
            {
                ListAdapter.SelectedItem = configuration.MonitoredAdapter;
            }

            #endregion LoadConfiguration
        }

        private void BtnSaveGeneral_Click(object sender, EventArgs e)
        {
            if (ListAdapter.SelectedItem == null)
            {
                MessageBox.Show(this, "You have not chosen the network inteface", "Oopss!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (!radioEnglish.Checked && !radioIndonesia.Checked)
            {
                MessageBox.Show(this, "You have not chosen something", "Oopss!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Configuration config = new Configuration
                {
                    Monitoring = ToggleMonitor.Checked,
                    AutoUpdate = ToggleAutoUpdate.Checked,
                    Language = (Language)Enum.Parse(typeof(Language), this.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked).Text),
                    Format = cmbFormat.SelectedItem.ToString(),
                    MonitoredAdapter = ListAdapter.SelectedItem.ToString()
                };

                // Save settings
                registryManager.Save(config);

                try
                {
                    NativeMethods.PostMessage(new IntPtr(Convert.ToInt32(registryManager.GetHwnd())), NativeMethods.WM_RESTART, IntPtr.Zero, IntPtr.Zero);
                }
                catch
                {
                }
            }
        }
    }
}