using Prism.Commands;
using Prism.Regions;
using Prism.Mvvm;
using System;
using Prism.Services.Dialogs;

namespace PrismMVVM.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private readonly IRegionManager _regionManager;
        private IRegionNavigationJournal _journal;
        public MainWindowViewModel(IRegionManager regionManager, IRegionNavigationJournal journal, IDialogService dialog)
        {
            this.PageNow = "PageA";
            this._regionManager = regionManager;
            this._journal = journal;
            this.PageACommand = new DelegateCommand(() =>
            {
                NavigationParameters param = new NavigationParameters();
                param.Add("Word", "Jump2PageA");
                regionManager.RequestNavigate("ContentRegion", "PageA", callbackA, param);
            });

            this.PageBCommand = new DelegateCommand(() =>
            {
                regionManager.RequestNavigate("ContentRegion", "PageB", callbackB);
            });

            this.GoForward = new DelegateCommand(() =>
            {
                _journal.GoForward();
            });

            this.GoBack = new DelegateCommand(() =>
            {
                _journal.GoBack();
            });

            this.Jump2page = new DelegateCommand(() =>
            {
                DialogParameters param = new DialogParameters();
                param.Add("PageNow", PageNow);
                dialog.ShowDialog("MyDialog", param, arg =>
                {
                    if(arg.Result == ButtonResult.OK)
                    {
                        string newPage = arg.Parameters.GetValue<string>("Result");
                        regionManager.RequestNavigate("ContentRegion", newPage);
                        this.PageNow = newPage;
                    }
                });
            });
        }

        private void callbackA(NavigationResult obj)
        {
            _journal = obj.Context.NavigationService.Journal;
            this.PageNow = "PageA";

        }

        private void callbackB(NavigationResult obj)
        {
            _journal = obj.Context.NavigationService.Journal;
            this.PageNow = "PageB";

        }

        private string _title = "Prism Application";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        private string _pageNow;

        public string PageNow
        {
            get { return _pageNow; }
            set { _pageNow = value; RaisePropertyChanged(); }
        }


        public DelegateCommand PageACommand { get; set; }
        public DelegateCommand PageBCommand { get; set; }

        public DelegateCommand GoForward { get; set; }
        public DelegateCommand GoBack { get; set; }

        public DelegateCommand Jump2page { get; set; }
    }
}
