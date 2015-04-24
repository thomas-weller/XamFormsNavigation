using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using FluxPlayer.Annotations;
using Xamarin.Forms;

// ReSharper disable once ExplicitCallerInfoArgument

namespace CoreLib.Mvvm
{
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        #region Fields

        private string _title;
        private bool _animatedNavigation;

        #endregion // Fields

        #region Properties

        public INavigator Navigator { get; internal set; }

        public bool AnimatedNavigation
        {
            get { return _animatedNavigation; }
            set { SetProperty(ref _animatedNavigation, value); }
        }

        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        #endregion // Properties

        #region Navigation Commands

        public ICommand PushCommand
        {
            get
            {
                return new Command<string>(async pageName => await Navigator.PushAsync(pageName, _animatedNavigation));
            }
        }

        public ICommand PopCommand
        {
            get
            {
                return new Command(async () => await Navigator.PopAsync(_animatedNavigation));
            }
        }

        public ICommand PopToRootCommand
        {
            get
            {
                return new Command(async () => await Navigator.PopToRootAsync(_animatedNavigation));
            }
        }

        public ICommand PushModalCommand
        {
            get
            {
                return new Command<string>(async pageName => await Navigator.PushModalAsync(pageName, _animatedNavigation));
            }
        }

        public ICommand PopModalCommand
        {
            get
            {
                return new Command(async () => await Navigator.PopModalAsync(_animatedNavigation));
            }
        }

        public ICommand RemovePageCommand
        {
            get
            {
                return new Command<string>(pageName => Navigator.RemovePage(pageName));
            }
        }

        public ICommand InsertPageBeforeCommand
        {
            get
            {
                return new Command<string>(ExecuteInsertPageBeforeCommand);
            }
        }

        private void ExecuteInsertPageBeforeCommand(string pageNames)
        {
            string[] pages = pageNames.Split(',').Select(s => s.Trim()).ToArray();

            if (pages.Length != 2)
            {
                return;
            }

            Navigator.InsertPageBefore(pages[0], pages[1]);
        }

        #endregion // Navigation Commands

        #region INotifyPropertyChanged implementation

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
        {
            if (Equals(storage, value))
            {
                return false;
            }

            storage = value;
            OnPropertyChanged(propertyName);

            return true;
        }

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion // INotifyPropertyChanged implementation

    }
}

