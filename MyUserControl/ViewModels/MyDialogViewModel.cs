using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyUserControl.ViewModels
{
    public class MyDialogViewModel : BindableBase, IDialogAware
    {
        public MyDialogViewModel()
        {
            this.Title = "";
            this.Jump = new DelegateCommand(() =>
            {
                DialogParameters param = new DialogParameters();
                param.Add("Result", JumpTo);
                RequestClose?.Invoke(new DialogResult(ButtonResult.OK, param));
            });
            this.Close = new DelegateCommand(() =>
            {
                RequestClose?.Invoke(new DialogResult(ButtonResult.Cancel, null));
            });
        }
        public DelegateCommand Jump { get; set; }
        public DelegateCommand Close { get; set; }

        private string _jumpTo;
        public string JumpTo
        {
            get { return _jumpTo; }
            set
            {
                _jumpTo = value;
                RaisePropertyChanged();
            }
        }

        private string _pageNow;
        public string PageNow
        {
            get { return _pageNow; }
            set { _pageNow = value;RaisePropertyChanged(); }
        }


        public string Title { get; set; }

        public event Action<IDialogResult> RequestClose;

        public bool CanCloseDialog()
        {
            if (JumpTo != null) return true;
            return false;
        }

        public void OnDialogClosed()
        {
           
        }

        public void OnDialogOpened(IDialogParameters parameters)
        {
            this.PageNow = parameters.GetValue<string>("PageNow");
        }
    }
}
