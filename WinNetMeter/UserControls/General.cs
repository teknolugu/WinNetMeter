using System;
using WinNetMeter.Model;
using WinNetMeter.Helper;
using System.Windows.Forms;

namespace WinNetMeter.UserControls
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
            comboBoxFormat.SelectedItem = "Auto";
            comboBoxLanguage.SelectedItem = "English";
            if (ListAdapter.Items != null)
            {
                ListAdapter.SelectedIndex = 0;
            }

            #region LoadConfiguration

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

            if (configuration.MonitoredAdapter != null && ListAdapter.Items.Contains(configuration.MonitoredAdapter))
            {
                ListAdapter.SelectedItem = configuration.MonitoredAdapter;
            }

            #endregion
        }

        private void BtnSaveGeneral_Click(object sender, EventArgs e)
        {
            if (ListAdapter.SelectedItem == null)
            {
                MessageBox.Show(this, "You have not chosen the network inteface", "Oopss!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (comboBoxLanguage.SelectedItem == null || comboBoxLanguage.SelectedItem == null)
            {
                MessageBox.Show(this, "You have not chosen something", "Oopss!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Configuration config = new Configuration
                {
                    Monitoring = ToggleMonitor.Checked,
                    AutoUpdate = ToggleAutoUpdate.Checked,
                    Language = (Language)Enum.Parse(typeof(Language), comboBoxLanguage.SelectedItem.ToString()),
                    Format = comboBoxFormat.SelectedItem.ToString(),
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

        private void LinkReset_Click(object sender, EventArgs e)
        {
            switch(MessageBox.Show(this, "Are you sure?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                case DialogResult.Yes:
                    // Delete all registry entries
                    registryManager.Reset();

                    // Restore to default
                    registryManager.CreateRegistry();
                    registryManager.MakeDefaultConfiguration();

                    MessageBox.Show("Application settings has been reset", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
            }
            
        }
    }
}
