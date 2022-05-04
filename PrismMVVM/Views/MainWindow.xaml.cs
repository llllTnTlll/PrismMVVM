using Prism.Modularity;
using System.Windows;

namespace PrismMVVM.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        IModuleManager _moduleManager1;
        public MainWindow(IModuleManager moduleManager)
        {
            InitializeComponent();
            _moduleManager1 = moduleManager;
            _moduleManager1.LoadModule("MyModule");

        }
    }
}
