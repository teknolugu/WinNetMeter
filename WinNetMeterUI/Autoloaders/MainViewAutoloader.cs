using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using WinNetMeterUI.Views;

namespace WinNetMeterUI.Autoloaders
{
    internal class MainViewAutoloader : IModule
    {
        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<AboutPage>();
            containerRegistry.RegisterForNavigation<CustomizationPage>();
            containerRegistry.RegisterForNavigation<GeneralPage>();
            containerRegistry.RegisterForNavigation<IntegrationPage>();
            containerRegistry.RegisterForNavigation<RecoveryPage>();
            containerRegistry.RegisterForNavigation<TrafficLogsPage>();
            containerRegistry.RegisterForNavigation<UpdatePage>();
        }

        public void OnInitialized(IContainerProvider containerProvider)
        {
            var regionManager = containerProvider.Resolve<IRegionManager>();
            regionManager.RequestNavigate("MainRegion", "GeneralPage");
        }
    }
}