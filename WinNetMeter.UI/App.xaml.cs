using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using System.Windows;
using System.Windows.Controls;
using Prism.Unity;
using WinNetMeter.UI.Autoloader;
using WinNetMeter.UI.Core;
using WinNetMeter.UI.Views;

namespace WinNetMeter.UI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : PrismApplication
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            const string appName = "DashboardInternal";
            var startMode = "Started";

            //            var startModeCookie = CookieHelper.GetCookie();
            //            if (startModeCookie != null)
            //            {
            //                startMode = startModeCookie;
            //            }
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            //            containerRegistry.RegisterForNavigation<GeneralPage>();
        }

        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            //base.ConfigureModuleCatalog(moduleCatalog);
            moduleCatalog.AddModule<ViewAutoloader>();
        }

        //        protected override void ConfigureRegionAdapterMappings(RegionAdapterMappings regionAdapterMappings)
        //        {
        //            base.ConfigureRegionAdapterMappings(regionAdapterMappings);
        //            regionAdapterMappings.RegisterMapping(typeof(StackPanel), Container.Resolve<StackPanelRegionAdapter>());
        //        }
    }
}