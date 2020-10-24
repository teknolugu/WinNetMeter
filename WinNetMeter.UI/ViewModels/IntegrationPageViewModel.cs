using Prism.Commands;
using Prism.Mvvm;
using System.Windows;
using WinNetMeter.Shell.Helper;

namespace WinNetMeter.UI.ViewModels
{
    public class IntegrationPageViewModel : BindableBase
    {
        // private ShellController shellController;
        // private Integration integration;
        private bool _showDeskbandOnTaskbar;

        private bool _isDeskbandInstalled;

        public bool ShowDeskbandOnTaskbar
        {
            get { return _showDeskbandOnTaskbar; }
            set
            {
                SetProperty(ref _showDeskbandOnTaskbar, value);
                ShellBehaviour(_showDeskbandOnTaskbar);
            }
        }

        public bool IsDeskbandInstalled
        {
            get { return _isDeskbandInstalled; }
            set => SetProperty(ref _isDeskbandInstalled, value);
        }

        public DelegateCommand RegisterShellCommand { get; set; }
        public DelegateCommand UninstallShellCommand { get; set; }

        public IntegrationPageViewModel()
        {
            // shellController = new ShellController();
            // integration = new Integration();

            RegisterShellCommand = new DelegateCommand(RegisterShell);
            UninstallShellCommand = new DelegateCommand(UninstallShell);

            // ShowShellOnTaskbar = shellController.IsShellShown();
            // IsShellInstalled = shellController.IsShellInstalled();

            ShowDeskbandOnTaskbar = DeskbandHelper.IsDeskbandVisible();
            IsDeskbandInstalled = DeskbandHelper.IsDeskbandInstalled();
        }

        private void RegisterShell()
        {
            // shellController.hideDeskband();
            DeskbandHelper.HideDeskband();

            //integration.ReinstallToolbar();
            IntegrationHelper.InstallShell();

            MessageBox.Show("Re-Register Shell Integration Successfully.", "WinNetMeter Integration",
                MessageBoxButton.OK, MessageBoxImage.Information);

            // IsShellInstalled = shellController.IsShellInstalled();
            IsDeskbandInstalled = DeskbandHelper.IsDeskbandInstalled();

            // shellController.hideDeskband();
            // shellController.callDeskband();

            DeskbandHelper.HideDeskband();
            DeskbandHelper.CallDeskband();
        }

        private void UninstallShell()
        {
            // shellController.hideDeskband();
            DeskbandHelper.HideDeskband();

            // integration.UninstallToolbar();
            IntegrationHelper.UninstallShell();

            MessageBox.Show("Uninstall Shell Integration Successfully.", "WinNetMeter Integration",
                MessageBoxButton.OK, MessageBoxImage.Information);

            ShowDeskbandOnTaskbar = false;
            // IsShellInstalled = shellController.IsShellInstalled();
            IsDeskbandInstalled = DeskbandHelper.IsDeskbandInstalled();
        }

        private void ShellBehaviour(bool isShow)
        {
            if (isShow)
            {
                // MessageBox.Show("Shell shown");
                // shellController.callDeskband();
                DeskbandHelper.CallDeskband();
            }
            else
            {
                DeskbandHelper.HideDeskband();
                // shellController.hideDeskband();
                // MessageBox.Show("Shell hidden");
            }
        }
    }
}