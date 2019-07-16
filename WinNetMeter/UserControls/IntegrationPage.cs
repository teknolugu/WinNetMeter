using System;
using System.Windows.Forms;
using WinNetMeter.Core;

namespace WinNetMeter.UserControls
{
    public partial class IntegrationPage : UserControl
    {
        public IntegrationPage()
        {
            InitializeComponent();
        }

        private void BtnRegister_Click(object sender, EventArgs e)
        {
            try
            {
                Integration integration = new Integration();
                integration.ReinstallToolbar();
                MessageBox.Show("Re-Register Shell Integration Successfully.", "WinNetMeter Integration",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Something happened. {ex.Message}", "WinNetMeter Integration",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnUninstall_Click(object sender, EventArgs e)
        {
            try
            {
                Integration integration = new Integration();
                integration.UninstallToolbar();
                MessageBox.Show("Uninstall Shell Integration Successfully.", "WinNetMeter Integration",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Something happened. {ex.Message}", "WinNetMeter Integration",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
