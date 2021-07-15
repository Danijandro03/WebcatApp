using GalaSoft.MvvmLight.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebcatApp.ViewModel.Base;
using Windows.UI.Xaml.Controls;

namespace WebcatApp.ViewModel
{
    public class InitPageModel: BasePageModel
    {
        public InitPageModel(INavigationService navigationService) : base(navigationService)
        {

        }
    }
}
