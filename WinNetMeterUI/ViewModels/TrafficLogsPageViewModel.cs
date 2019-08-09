using System;
using Microsoft.Win32;
using Prism.Commands;
using Prism.Mvvm;
using WinNetMeter.Core;
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
                registryManager.WriteToRegistry(@"WinNetMeter\Database", "EnableTrafficLog", value.ToString());
            }
        }

        public DelegateCommand ChangePathCommand { get; set; }

        public TrafficLogsPageViewModel()
        {
            registryManager = new RegistryManager();

            IsEnableLogs = Convert.ToBoolean(registryManager.ReadFromRegistry("WinNetMeter", "TrafficLogging"));

            ChangePathCommand = new DelegateCommand(OpenDialog);
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
    }
}