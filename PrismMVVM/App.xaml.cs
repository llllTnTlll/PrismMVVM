using MyUserControl;
using MyUserControl.ViewModels;
using MyUserControl.Views;
using Prism.Ioc;
using Prism.Modularity;
using PrismMVVM.Views;
using System.Windows;

namespace PrismMVVM
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<UserControl1>("PageA");
            containerRegistry.RegisterForNavigation<UserControl2>("PageB");

            containerRegistry.RegisterDialog<MyDialog, MyDialogViewModel>();
        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            var myType = typeof(MyModule);
            moduleCatalog.AddModule(new ModuleInfo()
            {
                ModuleName = myType.Name,
                ModuleType = myType.AssemblyQualifiedName,
                InitializationMode = InitializationMode.OnDemand,
            });
        }
    }
}
