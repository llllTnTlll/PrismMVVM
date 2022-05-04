using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Regions;

namespace MyUserControl.ViewModels
{
    public class UserControl1ViewModel: BindableBase, INavigationAware
    {
        public UserControl1ViewModel()
        {
            TextString = "Start";
            this.ClickCommand1 = new DelegateCommand(() =>
            {
                TextString = "Button1Clicked";
            });

            this.ClickCommand2 = new DelegateCommand(() =>
            {
                TextString = "";
            });
        }
        private string textString;

        public string TextString
        {
            get { return textString; }
            set { textString = value;RaisePropertyChanged(); }
        }

        public DelegateCommand ClickCommand1 { get; set; }
        public DelegateCommand ClickCommand2 { get; set; }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            this.TextString = navigationContext.Parameters.GetValue<String>("Word");
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
            
        }
    }
}
