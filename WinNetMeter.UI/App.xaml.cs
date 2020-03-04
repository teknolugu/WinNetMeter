using System;
using System.Windows;
using Prism.Ioc;
using Prism.Modularity;
using WinNetMeter.Core.Model;
using WinNetMeter.Core.Providers;
using WinNetMeter.UI.Autoloaders;
using WinNetMeter.UI.Views;

namespace WinNetMeter.UI
{
    /// <summary>
    ///     Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        public App()
        {
            RegistryProvider.Init();

            Settings.AppDirectory = Environment.CurrentDirectory;

            SqliteProvider.DbPath = Settings.AppDirectory + @"\Storage\Common\LocalStorage.db";

            EvolveProvider.Initialize();
        }

        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            //base.ConfigureModuleCatalog(moduleCatalog);
            moduleCatalog.AddModule<MainViewAutoloader>();
        }
    }
}