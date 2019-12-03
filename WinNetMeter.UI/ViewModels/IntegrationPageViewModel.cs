using System.Windows;
using Prism.Commands;
using Prism.Mvvm;
using WinNetMeter.Core.Helper;

namespace WinNetMeter.UI.ViewModels
{
    public class IntegrationPageViewModel : BindableBase
    {
        private ShellController shellController;
        private Integration integration;
        private bool _showShellOnTaskbar;
        private bool _isShellInstalled;

        public bool ShowShellOnTaskbar
        {
            get { return _showShellOnTaskbar; }
            set
            {
                SetProperty(ref _showShellOnTaskbar, value);
                ShellBehaviour(_showShellOnTaskbar);
            }
        }

        public bool IsShellInstalled
        {
            get { return _isShellInstalled; }
            set => SetProperty(ref _isShellInstalled, value);
        }

        public DelegateCommand RegisterShellCommand { get; set; }
        public DelegateCommand UninstallShellCommand { get; set; }

        public IntegrationPageViewModel()
        {
            shellController = new ShellController();
            integration = new Integration();

            RegisterShellCommand = new DelegateCommand(RegisterShell);
            UninstallShellCommand = new DelegateCommand(UninstallShell);

            ShowShellOnTaskbar = shellController.IsShellShown();
            IsShellInstalled = shellController.IsShellInstalled();
        }

        private void RegisterShell()
        {
            shellController.hideDeskband();
            integration.ReinstallToolbar();
            MessageBox.Show("Re-Register Shell Integration Successfully.", "WinNetMeter Integration",
                MessageBoxButton.OK, MessageBoxImage.Information);

            IsShellInstalled = shellController.IsShellInstalled();

            shellController.hideDeskband();
            shellController.callDeskband();
        }

        private void UninstallShell()
        {
            shellController.hideDeskband();
            integration.UninstallToolbar();
            MessageBox.Show("Uninstall Shell Integration Successfully.", "WinNetMeter Integration",
                MessageBoxButton.OK, MessageBoxImage.Information);

            ShowShellOnTaskbar = false;
            IsShellInstalled = shellController.IsShellInstalled();
        }

        private void ShellBehaviour(bool isShow)
        {
            if (isShow)
            {
                // MessageBox.Show("Shell shown");
                shellController.callDeskband();
            }
            else
            {
                shellController.hideDeskband();
                // MessageBox.Show("Shell hidden");
            }
        }
    }
}