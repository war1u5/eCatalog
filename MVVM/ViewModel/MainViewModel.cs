using eCatalog.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCatalog.MVVM.ViewModel
{
    class MainViewModel : ObservableObject
    {
        public RelayCommand LoginViewCommand { get; set; }
        public RelayCommand DespreViewCommand { get; set; }
        public RelayCommand ContactViewCommand { get; set; }

        public LoginViewModel LoginVM { get; set; }
        public DespreViewModel DespreVM { get; set; }
        public ContactViewModel ContactVM { get; set; }

        private object _currentView;

        public object CurrentView
        {
            get { return _currentView; }
            set 
            { 
                _currentView = value;
                OnPropertyChanged();
            }
        }

        public MainViewModel()
        {
            LoginVM = new LoginViewModel();
            DespreVM = new DespreViewModel();
            ContactVM = new ContactViewModel();

            CurrentView = LoginVM;

            LoginViewCommand = new RelayCommand(o =>
            {
                CurrentView = LoginVM;
            });

            DespreViewCommand = new RelayCommand(o =>
            {
                CurrentView = DespreVM;
            });

            ContactViewCommand = new RelayCommand(o =>
            {
                CurrentView = ContactVM;
            });
        }
    }
}
