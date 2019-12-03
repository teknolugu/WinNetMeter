using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Prism.Mvvm;
using WinNetMeter.Core.Helper;

namespace WinNetMeter.UI.ViewModels
{
    public class GeneralPageViewModel : BindableBase
    {
        private bool _enableNetworkMonitoring;
        private bool _enableAutoUpdates;
        private string _selectedNetworkAdapter;
        private bool _enableNetworkAdapterSelector;
        private bool _useAllNetworkAdapter;

        private RegistryManager registryManager;
        private ShellController shellController;

        public bool EnableNetworkMonitoring
        {
            get => _enableNetworkMonitoring;
            set
            {
                SetProperty(ref _enableNetworkMonitoring, value);
                registryManager.WriteToRegistry(@"WinNetMeter\General", "Monitoring", value.ToString());
            }
        }

        public bool EnableAutoUpdates
        {
            get => _enableNetworkMonitoring;
            set
            {
                SetProperty(ref _enableAutoUpdates, value);
                registryManager.WriteToRegistry(@"WinNetMeter\General", "AutoUpdate", value.ToString());
            }
        }

        public string SelectedNetworkAdapter
        {
            get { return _selectedNetworkAdapter; }
            set
            {
                SetProperty(ref _selectedNetworkAdapter, value);
                registryManager.WriteToRegistry(@"WinNetMeter\General", "MonitoredAdapter", value);
                shellController.RestartShell();
            }
        }

        public bool EnableNetworkAdapterSelector
        {
            get => _enableNetworkAdapterSelector;
            set { SetProperty(ref _enableNetworkAdapterSelector, value); }
        }

        public bool UseAllNetworkAdapter
        {
            get => _useAllNetworkAdapter;
            set
            {
                SetProperty(ref _useAllNetworkAdapter, value);
                EnableNetworkAdapterSelector = !UseAllNetworkAdapter;
            }
        }

        public IEnumerable<AdapterName> NetworkAdapters { get; set; }

        public GeneralPageViewModel()
        {
            registryManager = new RegistryManager();
            shellController = new ShellController();

            EnableNetworkAdapterSelector = !UseAllNetworkAdapter;
            EnableNetworkMonitoring = Convert.ToBoolean(registryManager.ReadFromRegistry(@"WinNetMeter\General", "Monitoring"));
            EnableAutoUpdates = Convert.ToBoolean(registryManager.ReadFromRegistry(@"WinNetMeter\General", "AutoUpdate"));

            LoadNetworkAdapter();
        }

        private void LoadNetworkAdapter()
        {
            NetworkIntefaceModule netModule = new NetworkIntefaceModule();
            var adapters = netModule.GetNetworkInterface();
            var data = new ObservableCollection<AdapterName>();
            foreach (var adapter in adapters)
            {
                var obj = new AdapterName()
                {
                    Name = adapter
                };
                data.Add(obj);
            }

            NetworkAdapters = data;
        }

        private void SaveNetworkAdapter(string adapterName)
        {
            registryManager.WriteToRegistry(@"WinNetMeter\General", "MonitoredAdapter", SelectedNetworkAdapter);
            shellController.RestartShell();
        }
    }

    public class AdapterName
    {
        public string Name { get; set; }
    }
}