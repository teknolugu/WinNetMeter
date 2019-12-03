using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using WinNetMeter.UI.Views;

namespace WinNetMeter.UI.Autoloaders
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