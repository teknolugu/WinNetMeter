using Microsoft.Win32;
using Prism.Commands;
using Prism.Mvvm;
using System;
using WinNetMeter.Core.Helper;
using WinNetMeter.Core.Model;

namespace WinNetMeterUI.ViewModels
{
    public class TrafficLogsPageViewModel : BindableBase
    {
        private string _selectedPath;
        private bool _isEnableLogs;

        private RegistryManager registryManager;

        public string SelectedPath
        {
            get
            {
                return _selectedPath;
            }
            set
            {
                SetProperty(ref _selectedPath, value);
                registryManager.WriteToRegistry(@"WinNetMeter\Database", "DbFilePath", value);
            }
        }

        public bool IsEnableLogs
        {
            get => _isEnableLogs;
            set
            {
                SetProperty(ref _isEnableLogs, value);
            }
        }

        public DelegateCommand ChangePathCommand { get; set; }
        public DelegateCommand SaveEnableTrafficLogCommand { get; set; }
        public DelegateCommand SaveDbPathCommand { get; set; }

        public TrafficLogsPageViewModel()
        {
            registryManager = new RegistryManager();

            ChangePathCommand = new DelegateCommand(OpenDialog);
            SaveEnableTrafficLogCommand = new DelegateCommand(SaveEnableTrafficLog);
            SaveDbPathCommand = new DelegateCommand(OnViewLoaded);

            IsEnableLogs = Convert.ToBoolean(registryManager.ReadFromRegistry(@"WinNetMeter\Database", "TrafficLogging"));
            SelectedPath = registryManager.ReadFromRegistry(@"WinNetMeter\Database", "DbFilePath").ToString();
        }

        private void OnViewLoaded()
        {
            registryManager.WriteToRegistry(@"WinNetMeter\Database", "TrafficLogging", IsEnableLogs.ToString());
        }

        private void OpenDialog()
        {
            var dialog = new SaveFileDialog()
            {
                InitialDirectory = SelectedPath
            };

            dialog.ShowDialog();
            if (dialog.FileName != "")
            {
                SelectedPath = dialog.FileName;
            }
            else
            {
                EventLog.WriteLog("Nothing path selected");
            }
        }

        private void SaveEnableTrafficLog()
        {
            registryManager.WriteToRegistry(@"WinNetMeter\Database", "TrafficLogging", IsEnableLogs.ToString());
        }
    }
}