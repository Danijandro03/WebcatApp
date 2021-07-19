using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebcatApp.Model;
using WebcatApp.ViewModel.Base;
using Windows.ApplicationModel;
using Windows.Storage;
using Windows.Storage.Search;
using Windows.Storage.Streams;
using Windows.UI.Xaml.Controls;


namespace WebcatApp.ViewModel
{
    
    public class UxPageModel : BasePageModel

    {

        public UxPageModel(INavigationService navigationService) : base(navigationService)
        {

        }
           
    }
}
