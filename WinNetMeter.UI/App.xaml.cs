using Prism.Ioc;
using Prism.Modularity;
using Serilog;
using System.Windows;
using WinNetMeter.Core.Helper;
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
            // RegistryProvider.Init();
            //
            // Settings.AppDirectory = Environment.CurrentDirectory;
            // Settings.AppExePath = Assembly.GetExecutingAssembly().Location;
            //
            // SerilogProvider.Initialize();
            //
            // Log.Information("Starting App..");
            //
            // SqliteProvider.DbPath = Settings.AppDirectory + @"\Storage\Common\LocalStorage.db";
            //
            // EvolveProvider.Initialize();

            InitHelper.InitializeAll();
        }

        protected override Window CreateShell()
        {
            var container = Container.Resolve<MainWindow>();
            Log.Information("App Started");

            return container;
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