using System;
using System.Windows.Forms;
using WinNetMeter.Helper;

namespace WinNetMeter.UserControls
{
    public partial class UpdaterPage : UserControl
    {
        private RegistryManager registryManager = new RegistryManager();

        public UpdaterPage()
        {
            InitializeComponent();
        }

        private void BtnReset_Click(object sender, EventArgs e)
        {
            switch (MessageBox.Show(this, "Are you sure?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                case DialogResult.Yes:
                    // Delete all registry entries
                    registryManager.Reset();

                    // Restore to default
                    registryManager.CreateRegistry();
                    registryManager.MakeDefaultConfiguration();
                    var setupForm = new Setup();

                    MessageBox.Show("Application settings has been reset", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    setupForm.Show();
                    ((Form)this.TopLevelControl).Hide();
                    break;
            }
        }
    }
}