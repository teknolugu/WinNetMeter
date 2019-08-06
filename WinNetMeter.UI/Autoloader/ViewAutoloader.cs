using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using WinNetMeter.UI.Views;

namespace WinNetMeter.UI.Autoloader
{
    internal class ViewAutoloader : IModule
    {
        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<GeneralPage>();
        }

        public void OnInitialized(IContainerProvider containerProvider)
        {
            var regionManager = containerProvider.Resolve<IRegionManager>();
            regionManager.RequestNavigate("MainRegion", "GeneralPage");
        }
    }
}