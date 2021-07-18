using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Navigation;

namespace WebcatApp.ViewModel.Base
{
    public class BasePageModel : ViewModelBase
    {
        public INavigationService _navigationService;
        private bool isBusy;

        public event PropertyChangedEventHandler PropertyChanged;

        public bool IsBusy { get { return isBusy; } set { isBusy = value; RaisePropertyChanged(); } }

        public BasePageModel(INavigationService navigationservice)
        {
            _navigationService = navigationservice;
        }

        public void GoTo()
        {
            _navigationService.NavigateTo("AppPage");
        }

        internal void OnNavigatedTo(NavigationEventArgs e)
        {
            _navigationService.NavigateTo("InitPage");
        }

    }
}
