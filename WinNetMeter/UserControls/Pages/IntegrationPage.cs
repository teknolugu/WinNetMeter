using System;
using System.Windows.Forms;
using WinNetMeter.Core;

namespace WinNetMeter.UserControls.Pages
{
    public partial class IntegrationPage : UserControl
    {
        private ShellController shellControlller = new ShellController();

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

        private void IntegrationPage_Load(object sender, EventArgs e)
        {
            CheckIsShellActive();
        }

        private void BtnShow_Click(object sender, EventArgs e)
        {
            // Call the shell
            shellControlller.callDeskband();

            // Refresh shell status
            CheckIsShellActive();
        }

        private void CheckIsShellActive()
        {
            if (shellControlller.IsShellShown() == 0)
            {
                lblStatus.Text = "Active";
                lblStatus.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                lblStatus.Text = "Not Active";
                lblStatus.ForeColor = System.Drawing.Color.Red;
            }
        }

        private void BtnHide_Click(object sender, EventArgs e)
        {
            // Hide the shell
            shellControlller.hideDeskband();

            // Refresh shell status
            CheckIsShellActive();
        }

        private void LinkRefresh_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CheckIsShellActive();
        }
    }
}