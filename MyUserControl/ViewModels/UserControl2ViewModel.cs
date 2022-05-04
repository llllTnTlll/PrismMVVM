using MyUserControl.Views;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyUserControl.ViewModels
{
    public class UserControl2ViewModel: BindableBase
    {
        public UserControl2ViewModel(IEventAggregator eventAggregator)
        {
            
            this.eventAggregator = eventAggregator;
            this.MyTxt = "ddd";

            this.SubscribeCommand = new DelegateCommand(() =>
            {
                eventAggregator.GetEvent<MeggageEvent>().Subscribe(OnMessageRecved);
            });

            this.PublishCommand = new DelegateCommand(() =>
            {
                eventAggregator.GetEvent<MeggageEvent>().Publish("something");
            });

        }
        private string _myTxt;
        private readonly object eventAggregator;

        public string MyTxt
        {
            get { return _myTxt; }
            set { _myTxt = value;RaisePropertyChanged(); }
        }

        public DelegateCommand SubscribeCommand { get; set; }
        public DelegateCommand PublishCommand { get; set; }

        public void OnMessageRecved(string message)
        {
            this.MyTxt += "Recevied " + message + "\r\n";
        }

    }

    public class MeggageEvent: PubSubEvent<string>
    {

    }
}
