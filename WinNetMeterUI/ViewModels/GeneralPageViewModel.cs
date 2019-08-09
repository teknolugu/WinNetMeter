using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using WinNetMeter.Core.Helper;

namespace WinNetMeterUI.ViewModels
{
    public class GeneralPageViewModel : BindableBase
    {
        private string _selectedNetworkAdapter;
        private bool _enableNetworkAdapterSelector;
        private bool _useAllNetworkAdapter;

        private RegistryManager registryManager;
        private ShellController shellController;

        public string SelectedNetworkAdapter
        {
            get { return _selectedNetworkAdapter; }
            set
            {
                SetProperty(ref _selectedNetworkAdapter, value);
                SaveNetworkAdapter(value);
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